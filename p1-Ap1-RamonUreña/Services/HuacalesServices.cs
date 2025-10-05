using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using p1_Ap1_RamonUreña.DAL;
using p1_Ap1_RamonUreña.Models;
using System.Linq.Expressions;

namespace p1_Ap1_RamonUreña.Services;

public class HuacalesServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<bool> Insertar(EntradasHuacales Entrada) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Add(Entrada);
        return await contexto.SaveChangesAsync()>0;
    }

    public async Task<bool> Eliminar(EntradasHuacales Entrada)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        
        return await contexto.EntradasHuacales.Where(h => h.IdEntrada == Entrada.IdEntrada).ExecuteDeleteAsync() > 0;
    }
    public async Task<bool> Existe(int id) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.EntradasHuacales.AnyAsync( h => h.IdEntrada == id);
    }

    public async Task<bool> Modificar(EntradasHuacales entradas) 
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Update(entradas);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales entradas) 
    {
        if (await Existe(entradas.IdEntrada))
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
        return await contexto.EntradasHuacales.FirstOrDefaultAsync(H => H.IdEntrada == id);
    }


    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(criterio).AsNoTracking().ToListAsync();

    }

}
