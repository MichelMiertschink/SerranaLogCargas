using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LogCargas.Data;
using LogCargas.Services;

namespace LogCargas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<LogCargasContext>(options =>
                options.UseMySql(
                    /*"server=mysql.mitecsuporte.com.br:3306; initial catalog=LogCargasSL; uid=mitecsupor_add2; pwd=Logcargas33",*/
                    "server=localhost; initial catalog=LOGCARGAS; uid=root; pwd=root",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql")));

            // Registrando injeção de dependencia para os serviços
            builder.Services.AddScoped<SeedingService>();
            builder.Services.AddScoped<CityService>();
            builder.Services.AddScoped<StateService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<VehicleService>();
            builder.Services.AddScoped<DriverService>();
            builder.Services.AddScoped<LoadSchedulingService>();


            // Seeding service
            var conectionString = builder.Configuration.GetConnectionString("AppDb");
            builder.Services.AddTransient<SeedingService>();



            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LogCargasContext>();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //SeedingService seedingService = new SeedingService(context);

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