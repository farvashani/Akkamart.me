using Akkatecture.Aggregates;

namespace Akkamart.Membership.Server.Domain.Events {
    public class MemberStateResponse : AggregateEvent<MemberActor, MemberId> {
        public MemberStateResponse () { }

        public MemberStateResponse (MemberState memberState) {
            this.MemberState = memberState;

        }
        public MemberState MemberState { get; private set; }

    }
}