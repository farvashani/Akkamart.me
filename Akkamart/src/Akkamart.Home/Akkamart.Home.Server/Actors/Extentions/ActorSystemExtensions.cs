using System;
using Akka.Actor;
using Akkamart.Home.Server.Config;
using Akkamart.Home.Server.Domain;
using Akkamart.Home.Server.Domain.Client;
using Akkatecture.Clustering.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Akkamart.Home.Server.Actors.Extentions {
    public static class ActorSystemExtensions {
        public static ActorSystem AddActorsystem (this IServiceCollection services, string confUrl) {
              var config = ConfigurationLoader.Load (confUrl);
             var actorSystem = Akka.Actor.ActorSystem.Create("akkamart-system", config);
             actorSystem.ActorOf(Props.Create(typeof(ClusterListenerActor)), "ClusterListenerActor");
             var shardProxyRoleName = config.GetString("akka.cluster.singleton-proxy.role");
             var clientManagerProxy = StartUserClientClusterProxy(actorSystem, shardProxyRoleName);
             var clientManager = actorSystem.ActorOf(Props.Create(() => new ClientManager()),"client-manager");
            // var sagaManager = actorSystem.ActorOf(Props.Create(() => new ResourceCreationSagaManager(() => new ResourceCreationSaga())),"resourcecreation-sagamanager");
            // var resourceStorage = actorSystem.ActorOf(Props.Create(() => new ResourcesStorageHandler()), "resource-storagehandler");
            // var operationStorage = actorSystem.ActorOf(Props.Create(() => new OperationsStorageHandler()), "operation-storagehandler");

            // // Add Actors to DI as ActorRefProvider<T>
             services.AddAkkatecture(actorSystem)
                 .AddActorReference<ClientManager>(clientManager );
            //     .AddActorReference<ResourceCreationSagaManager>(sagaManager)
            //     .AddActorReference<ResourcesStorageHandler>(resourceStorage)
            //     .AddActorReference<OperationsStorageHandler>(operationStorage);
           
            return actorSystem;
        }
         public static IActorRef StartUserClientClusterProxy(ActorSystem actorSystem, string proxyRoleName)
        {
            var clusterProxy = ClusterFactory<ClientManager, ClientActor, ClientId>
                .StartAggregateClusterProxy(actorSystem, proxyRoleName);

            return clusterProxy;
        }

    }
}