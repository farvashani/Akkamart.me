using System.Linq;
using System.Net.Mime;
using Akka.Actor;
using Akkamart.Home.Server.Actors.Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace Akkamart.Home.Server {
    public class Startup {
         private ActorSystem actorsystem;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices (IServiceCollection services) {
             services.AddCors (options => {
                options.AddPolicy ("AllowAnyOrigin",
                    builder => builder
                    .AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ());
            });

             actorsystem = services.AddActorsystem ("akkamart.home.conf");

            services.AddMvc ().AddNewtonsoftJson ();
            
            services.AddResponseCompression (opts => {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat (
                    new [] { MediaTypeNames.Application.Octet });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseCors ("AllowAnyOrigin");
            app.UseResponseCompression ();

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseBlazorDebugging ();
            }

            app.UseRouting ();

            app.UseEndpoints (endpoints => {
                endpoints.MapDefaultControllerRoute ();
            });
            app.UsePathBase ("/home/");
             

           //app.UseStaticFiles(); 
           app.UseClientActorMiddleware();
            app.UseBlazor<Client.Startup> ();
            
        }
    }
}