using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace PointOfSale.Server {
     
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
                            options.Listen (IPAddress.Loopback, 4001);
                            options.Listen (IPAddress.Loopback, 4002, listenOptions => {
                                listenOptions.UseHttps (certificate);
                            });
                        }
                    )
                    .UseStartup<Startup> ()

                    .Build ();
                host.Run ();

            } else {
                var host = BuildWebHost (args);
                    
                host.Run ();

            }

        }

        public static IWebHost BuildWebHost (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .UseConfiguration (new ConfigurationBuilder ()
                .AddCommandLine (args)
                .Build ())
            
            .UseStartup<Startup> ()
            .Build ();
    }
}