using Microsoft.EntityFrameworkCore;
using Talabat.Me.BLL;
using Talabat.Me.BLL.Interfaces;
using Talabat.Me.DAL;
using Talabat.Me.DAL.Data.Contexts;

namespace Talabat.Me.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TalabatDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            var app = builder.Build();

            //TalabatDbContext talabatDbContext = new TalabatDbContext(app);
            //talabatDbContext.Database.Migrate();

            using var scope =  app.Services.CreateScope();
            var service = scope.ServiceProvider;
            var context = service.GetRequiredService<TalabatDbContext>();
            var logger = service.GetRequiredService<ILoggerFactory>();
            try 
            {
                await context.Database.MigrateAsync();
                await TalabatDbContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                var log = logger.CreateLogger<Program>();
                log.LogError(ex, "There Are Problem During Apply Migrations ");
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
