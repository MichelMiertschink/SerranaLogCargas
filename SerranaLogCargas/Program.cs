using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SerranaLogCargas.Data;

namespace SerranaLogCargas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<SerranaLogCargasContext>(options =>
                options.UseMySql(
                    "server=localhost; initial catalog=SERRANALOGCARGAS; uid=root; pwd=root",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")));

            // Registrando injeção de dependencia para os serviços
            builder.Services.AddScoped<SeedingService>();

            
            // Seeding service
            var conectionString = builder.Configuration.GetConnectionString("AppDb");
            builder.Services.AddTransient<SeedingService>();



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SerranaLogCargasContext>();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}