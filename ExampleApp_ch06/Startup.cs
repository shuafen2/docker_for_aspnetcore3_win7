using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExampleApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace ExampleApp
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env) {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // var host = Configuration["DBHOST"] ?? "localhost";
            // var port = Configuration["DBPORT"] ?? "3306";
            // var password = Configuration["DBPASSWORD"] ?? "mySecret!123";

            // services.AddDbContext<ProductDbContext>(options =>
            //     options.UseMySql($"server={host};userid=root;pwd={password};"
            //         + $"port={port};database=products"));

            services.AddDbContext<ProductDbContext>();

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddTransient<IRepository, ProductRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            //SeedData.EnsurePopulated(app);
        }
    }
}
