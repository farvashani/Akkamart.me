using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Home.Server.Domain.Client
{
    public class ClientManager : AggregateManager<ClientActor, ClientId, Command<ClientActor, ClientId>> {

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberAggregate> (() => new MemberAggregate (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}