using System.Threading.Tasks;
using Akka.Actor;
using Akkamart.Home.Server.Domain.Client;
using Akkamart.Home.Server.Domain.Client.Commands;
using Akkamart.Shared;
using Akkatecture.Akka;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;

namespace Akkamart.Home.Server.Actors.Extentions {
    public class ClientActorMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        //private readonly ActorRefProvider<ClientManager> _clientManager;
        private readonly ActorRefProvider<ClientManager> _clientManager;

        public ClientActorMiddleware (RequestDelegate next, ILoggerFactory loggerFactory,
            ActorRefProvider<ClientManager> clientManager) {
            _next = next;
            _logger = loggerFactory.CreateLogger<ClientActorMiddleware> ();
            _clientManager = clientManager;
        }
        public async Task Invoke (HttpContext context) {
            var url1 =context.Request.GetDisplayUrl();
            var url2  = context.Request.GetEncodedUrl();    
            if (url1.EndsWith (@"/home/")) {

                _logger.LogInformation ("**Handling request: " + context.Request.Path + "**");
                ClientId clientid;

                //var sys = Common.CreateSystem("akkamart.home.conf");
                if (!string.IsNullOrEmpty (context.Connection.Id))
                    clientid = ClientId.NewDeterministic (ClientNameSpace.Instance,
                        context.Connection.Id);
                else
                    clientid = ClientId.NewDeterministic (ClientNameSpace.Instance, "clint-0");

                var LogReqCmd = new LogClientDetails (clientid, context.Request.Headers);

                // var clientManager = _actorSystem.ActorOf (Props.Create (() =>
                //      new ClientManager ()), "client-manager");
                _clientManager.Tell (LogReqCmd);

                context.Items.Add ("clientManager", _clientManager);
                await _next.Invoke (context);
                _logger.LogInformation ("**Finished handling request.**");
            } else {
                await _next.Invoke (context);

            }
        }
    }

    public static class ClientActorMiddlewareExtension {
        public static IApplicationBuilder UseClientActorMiddleware (this IApplicationBuilder builder) {
            return builder.UseMiddleware<ClientActorMiddleware> ();
        }
    }
}