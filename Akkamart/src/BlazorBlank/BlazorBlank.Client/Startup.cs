using BionicExtensions.Attributes;
using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorBlank.Client
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            InjectableAttribute.RegisterInjectables(services);
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
