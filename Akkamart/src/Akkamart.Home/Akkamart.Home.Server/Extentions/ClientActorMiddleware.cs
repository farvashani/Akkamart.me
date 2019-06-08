using System.Threading.Tasks;
using Akka.Actor;
using Akkamart.Home.Server.Domain.Client;
using Akkamart.Home.Server.Domain.Client.Commands;
using Akkamart.Shared;
using Akkatecture.Akka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Akkamart.Home.Server.Actors.Extentions {
    public class ClientActorMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly ActorRefProvider<ClientManager> _clientManager;
        
        public ClientActorMiddleware (RequestDelegate next, ILoggerFactory loggerFactory, ActorRefProvider<ClientManager> clientManager) {
            _next = next;
            _logger = loggerFactory.CreateLogger<ClientActorMiddleware> ();
            _clientManager = clientManager;
        }
        public async Task Invoke (HttpContext context) {
            _logger.LogInformation ("**Handling request: " + context.Request.Path + "**");
            var sys = Common.CreateSystem("akkamart.home.conf");
            var clientId = ClientId.NewDeterministic(ClientNameSpace.Instance, context.Request.Headers["X-Request-ID"]).ToString();
            var cmd = new LogClientDetails(clientId, context.Request.Headers);
            _clientManager.Tell(cmd);
            await _next.Invoke (context);
            _logger.LogInformation ("**Finished handling request.**");
        }
    }
    public static class ClientActorMiddlewareExtension
{
    public static IApplicationBuilder UseClientActorMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ClientActorMiddleware>();
    }
}
}