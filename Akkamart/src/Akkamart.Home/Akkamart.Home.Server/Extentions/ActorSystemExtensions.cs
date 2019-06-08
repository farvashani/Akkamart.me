using System;
using Akka.Actor;
using Akkamart.Home.Server.Config;
using Akkamart.Home.Server.Domain;
using Akkamart.Home.Server.Domain.Client;
using Akkamart.Shared;
using Akkatecture.Clustering.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Akkamart.Home.Server.Actors.Extentions {
    public static class ActorSystemExtensions {
        public static ActorSystem AddActorsystem (this IServiceCollection services, string confUrl) {
            // var config = ConfigurationLoader.Load (confUrl);
            // var actorSystem = Akka.Actor.ActorSystem.Create ("akkamart-system", config);
            var actorSystem = Common.CreateSystem (confUrl);

            actorSystem.ActorOf (Props.Create (typeof (ClusterListenerActor)),
                "ClusterListenerActor");

            //var shardProxyRoleName = config.GetString ("akka.cluster.singleton-proxy.role");
            // var clientManagerProxy = StartUserClientClusterProxy (actorSystem,
            //     shardProxyRoleName);

            var clientManager = actorSystem.ActorOf (Props.Create (() =>
                new ClientManager ()), "client-manager");

            services.AddAkkatecture (actorSystem)
                .AddActorReference<ClientManager> (clientManager);

            return actorSystem;
        }
        // public static IActorRef StartUserClientClusterProxy (ActorSystem actorSystem, string proxyRoleName) {
        //     var clusterProxy = ClusterFactory<ClientManager, ClientActor, ClientId>
        //         .StartAggregateClusterProxy (actorSystem, proxyRoleName);

        //     return clusterProxy;
        // }

    }
}