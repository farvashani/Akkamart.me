using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazingPizza.Server {
    public class Program {
        public static void Main (string[] args) {
            var config = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddEnvironmentVariables ()
                .AddJsonFile ("appsettings.json", optional : false, reloadOnChange : true)
                .AddJsonFile ($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional : true, reloadOnChange : true)
                .Build ();

            var env = Environment.GetEnvironmentVariable ("ASPNETCORE_ENVIRONMENT");
            if (env == "Development") {

                string certificateFileName = "localhost.pfx";
                string certificatePassword = "abc+123";

                var certificate = new X509Certificate2 (certificateFileName, certificatePassword);
                var host = new WebHostBuilder ()
                    .UseConfiguration (config)

                    .UseKestrel (
                        options => {
                            options.AddServerHeader = false;
                            options.Listen (IPAddress.Loopback, 5001);
                            options.Listen (IPAddress.Loopback, 5002, listenOptions => {
                                listenOptions.UseHttps (certificate);
                            });
                        }
                    )
                    .UseStartup<Startup> ()

                    .Build ();
                host.Run ();

            } else {
                var host = CreateHostBuilder (args)
                    .Build ();

                // Initialize the database
                var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory> ();
                using (var scope = scopeFactory.CreateScope ()) {
                    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext> ();
                    if (db.Database.EnsureCreated ()) {
                        SeedData.Initialize (db);
                    }
                }

                host.Run ();
            }
        }
        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}