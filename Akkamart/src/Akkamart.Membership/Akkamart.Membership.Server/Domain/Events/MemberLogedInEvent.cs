using Akkatecture.Aggregates;
using Akkatecture.Events;
namespace Akkamart.Membership.Server.Domain.Events {
    public class MemberLogedInEvent : AggregateEvent<MemberActor, MemberId> {

    }
}