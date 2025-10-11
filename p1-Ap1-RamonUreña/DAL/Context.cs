using Microsoft.EntityFrameworkCore;
using p1_Ap1_RamonUreña.Models;

namespace p1_Ap1_RamonUreña.DAL;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<EntradasHuacales> EntradasHuacales { get; set; }

    public DbSet<TiposHuacales> TipoHuacales { get; set; }

    public virtual DbSet<DetallesHuacales> DetallesHuacales { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TiposHuacales>().HasData(new List<TiposHuacales>()
        {

            new TiposHuacales() { TipoId = 1, TipoColor = "Verde" , TipoTamano = "Grande" },
            new TiposHuacales() { TipoId = 2, TipoColor = "Rojo", TipoTamano = "Grande" }
        });

    }
}

