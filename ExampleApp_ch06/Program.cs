using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ExampleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                 .AddCommandLine(args)
                 .AddEnvironmentVariables()
                 .Build();

            if ((config["INITDB"] ?? "false") == "true") {
                System.Console.WriteLine("Preparing Database...");
                Models.SeedData.EnsurePopulated(new Models.ProductDbContext());
                System.Console.WriteLine("Database Preparation Complete");
            } else {
                CreateHostBuilder(args).Build().Run();
            }   
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
