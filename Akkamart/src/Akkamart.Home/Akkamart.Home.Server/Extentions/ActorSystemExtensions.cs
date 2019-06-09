using Akka.Actor;
using Akkamart.Server.Shared;
using Akkamart.Server.Shared.Client;
using Akkamart.Server.Shared.Cluster;
using Microsoft.Extensions.DependencyInjection;

namespace Akkamart.Home.Server.Actors.Extentions
{
    public static class ActorSystemExtensions {
        public static ActorSystem AddActorsystem (this IServiceCollection services, string confUrl) {
            // var config = ConfigurationLoader.Load (confUrl);
            // var actorSystem = Akka.Actor.ActorSystem.Create ("akkamart-system", config);
            var actorSystem = Common.CreateSystem (confUrl);

           var clusterListener =  actorSystem.ActorOf (Props.Create (typeof (ClusterListenerActor)),
                "clusterlistener");

            //var shardProxyRoleName = config.GetString ("akka.cluster.singleton-proxy.role");
            // var clientManagerProxy = StartUserClientClusterProxy (actorSystem,
            //     shardProxyRoleName);

            var clientManager = actorSystem.ActorOf (Props.Create (() =>
                new ClientManager ()), "client-manager");
            var NavigationActor = actorSystem.ActorOf (Props.Create (() =>
                new Navigator ()), "navigation-actor");


            services.AddAkkatecture (actorSystem)
                .AddActorReference<Navigator> (NavigationActor)
                .AddActorReference<ClientManager> (clientManager)
                .AddActorReference<ClusterListenerActor> (clusterListener);

            return actorSystem;
        }
        // public static IActorRef StartUserClientClusterProxy (ActorSystem actorSystem, string proxyRoleName) {
        //     var clusterProxy = ClusterFactory<ClientManager, ClientActor, ClientId>
        //         .StartAggregateClusterProxy (actorSystem, proxyRoleName);

        //     return clusterProxy;
        // }

    }
}