using Microsoft.EntityFrameworkCore;
using p1_Ap1_RamonUreña.Components;
using p1_Ap1_RamonUreña.DAL;
using p1_Ap1_RamonUreña.Services;

namespace p1_Ap1_RamonUreña;
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
        
            builder.Services.AddDbContextFactory<Context>(options => options.UseSqlite(builder.Configuration.GetConnectionString("ConStr")));

            builder.Services.AddScoped<RegistroServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }

