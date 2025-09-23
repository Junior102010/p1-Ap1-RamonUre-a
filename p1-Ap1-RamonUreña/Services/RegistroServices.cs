using Microsoft.EntityFrameworkCore;
using p1_Ap1_RamonUreña.DAL;
using p1_Ap1_RamonUreña.Models;
using System.Linq.Expressions;

namespace p1_Ap1_RamonUreña.Services;

public class RegistroServices(IDbContextFactory<Context> DbFactory)
{
    public async Task<List<Registro>> Listar(Expression<Func<Registro, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registro.Where(criterio).AsNoTracking().ToListAsync();

    }
}
