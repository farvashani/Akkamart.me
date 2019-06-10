using Akkamart.Membership.Server.Domain.ValueObjects;
using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Akkamart.Membership.Server.Domain.Events {
    [EventVersion ("MemberMobileChangedEvent", 1)]
    public class MemberMobileChangedEvent : AggregateEvent<MemberActor, MemberId> {
        public MobileNumber MobileNumber { get; internal set; }
    }
}