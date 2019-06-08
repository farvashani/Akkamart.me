using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain.User
{
    public class UserManager : AggregateManager<UserActor, UserId, Command<UserActor, UserId>> {

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberAggregate> (() => new MemberAggregate (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}