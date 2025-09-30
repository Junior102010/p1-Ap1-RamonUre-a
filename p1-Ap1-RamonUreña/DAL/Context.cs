using Microsoft.EntityFrameworkCore;
using p1_Ap1_RamonUreña.Models;

namespace p1_Ap1_RamonUreña.DAL;

    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<EntradasHuacales> EntradasHuacales { get; set; }

    }

