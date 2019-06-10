using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Akkamart.Membership.Server.Domain.Events {
    public class MemberVerifiedEvent : AggregateEvent<MemberActor, MemberId> {
        public MemberVerifiedEvent (bool isSucceed, MemberId memberId) {
            this.IsSucceed = isSucceed;
            this.MemberId = memberId;

        }
        public bool IsSucceed { get; set; }
        public MemberId MemberId { get; set; }
    }
}