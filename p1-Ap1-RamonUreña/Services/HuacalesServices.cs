using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using p1_Ap1_RamonUreña.DAL;
using p1_Ap1_RamonUreña.Models;
using System.Drawing;
using System.Linq.Expressions;

namespace p1_Ap1_RamonUreña.Services;

public class HuacalesServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Insertar(EntradasHuacales Entrada) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(Entrada);
        await AfectarHuacales(Entrada.DetallesHuacales.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync()>0;
    }

    public async Task<bool> Eliminar(int EntradaId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var Entrada = await contexto.EntradasHuacales
            .Include(c => c.DetallesHuacales)
            .FirstOrDefaultAsync(c => c.IdEntrada == EntradaId);

        if (Entrada == null) return false;

        await AfectarHuacales(Entrada.DetallesHuacales.ToArray(), TipoOperacion.Resta);

        contexto.DetallesHuacales.RemoveRange(Entrada.DetallesHuacales);
        contexto.EntradasHuacales.Remove(Entrada);
        var cantidad = await contexto.SaveChangesAsync();
        return cantidad > 0;
    }

    public async Task<bool> Existe(int id) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales.AnyAsync( h => h.IdEntrada == id);
    }

    public async Task<bool> Modificar(EntradasHuacales entradas) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var original = await contexto.EntradasHuacales
            .Include(e => e.DetallesHuacales)
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.IdEntrada == entradas.IdEntrada);

        if (original == null) return false;

        await AfectarHuacales(original.DetallesHuacales.ToArray(), TipoOperacion.Resta);

        contexto.DetallesHuacales.RemoveRange(original.DetallesHuacales);

        contexto.Update(entradas);

        await AfectarHuacales(entradas.DetallesHuacales.ToArray(), TipoOperacion.Suma);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales entradas) 
    {
        if (!await Existe(entradas.IdEntrada))
        {
            return await Insertar(entradas);
        }
        else
        {
            return await Modificar(entradas);
        }
    }

    public async Task<EntradasHuacales?> Buscar(int id) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales
            .Include(e => e.DetallesHuacales) // 👈 Esto incluye los detalles
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdEntrada == id);
    }


    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(criterio).AsNoTracking().ToListAsync();

    }

    public async Task<List<TiposHuacales>> ListarTipos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TipoHuacales.Where(e => e.TipoId > 0).AsNoTracking().ToListAsync();

    }

    private async Task AfectarHuacales(DetallesHuacales[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach (var item in detalle)
        {
            var Tipo = await contexto.TipoHuacales.SingleAsync(p => p.TipoId == item.TiposId);

            if (tipoOperacion == TipoOperacion.Resta)
                Tipo.Existencia -= item.Cantidad;
            else
                Tipo.Existencia += item.Cantidad;

            await contexto.SaveChangesAsync();
        }
    }

    public enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }

}
