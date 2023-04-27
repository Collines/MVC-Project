using MVC_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using MVC_Project.Interfaces;
using MVC_Project.Models.Identity;
using MVC_Project.Repositories;
using Microsoft.Data.SqlClient;

namespace MVC_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnectionString")
                    ));

            builder.Services.AddRazorPages();
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(30);
                options.SlidingExpiration = true;
                options.AccessDeniedPath = "/Home/Forbidden";
                options.LoginPath = "/Account/Login";
                //options.ReturnUrlParameter = "/Account/Dashboard";
            });

            builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
            
            builder.Services.AddTransient<InterfaceWishlistRepository, WishlistRepository>();

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Request.Path = "/Home/Notfound";
                    await next();
                }
            });

            //app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
              );
            app.MapControllerRoute(
                name: "Account",
                pattern: "Account/{action=Dashboard}",
                defaults: new { controller = "Account", action = "Dashboard"});

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();



            //ezz
        }
    }
}