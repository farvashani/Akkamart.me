using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Server.Shared.Client
{
    public class ClientManager : AggregateManager<ClientActor, ClientId, Command<ClientActor, ClientId>> {

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberActor> (() => new MemberActor (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}