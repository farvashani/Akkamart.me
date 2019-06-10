using Akka.Actor;
using Akkamart.Home.Membership.Config;
using Akkamart.Membership.Server.Domain;
using Akkamart.Server.Shared.Client;
using Akkatecture.Clustering.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Akkamart.Home.Membership.Extentions
{
    public static class ActorSystemExtensions {
        public static ActorSystem AddActorsystem (this IServiceCollection services, string confUrl) {
              var config = ConfigurationLoader.Load (confUrl);
             var actorSystem = Akka.Actor.ActorSystem.Create("akkamart-system", config);
             var membermanager = actorSystem.ActorOf(Props.Create(() => new MemberManager()),"memeber-manager");
            // var sagaManager = actorSystem.ActorOf(Props.Create(() => new ResourceCreationSagaManager(() => new ResourceCreationSaga())),"resourcecreation-sagamanager");
            // var resourceStorage = actorSystem.ActorOf(Props.Create(() => new ResourcesStorageHandler()), "resource-storagehandler");
            // var operationStorage = actorSystem.ActorOf(Props.Create(() => new OperationsStorageHandler()), "operation-storagehandler");

            // // Add Actors to DI as ActorRefProvider<T>
             services.AddAkkatecture(actorSystem)
                 .AddActorReference<MemberManager>(membermanager );
            //     .AddActorReference<ResourceCreationSagaManager>(sagaManager)
            //     .AddActorReference<ResourcesStorageHandler>(resourceStorage)
            //     .AddActorReference<OperationsStorageHandler>(operationStorage);
           
            return actorSystem;
        }
        //  public static IActorRef StartUserClientClusterProxy(ActorSystem actorSystem, string proxyRoleName)
        // {
        //     var clusterProxy = ClusterFactory<ClientManager, ClientActor, ClientId>
        //         .StartAggregateClusterProxy(actorSystem, proxyRoleName);

        //     return clusterProxy;
        // }

    }
}