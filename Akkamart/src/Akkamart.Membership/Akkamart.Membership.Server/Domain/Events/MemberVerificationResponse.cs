using Akkatecture.Aggregates;
using Akkatecture.Events;
namespace Akkamart.Membership.Server.Domain.Events {
    [EventVersion ("MemberVerificationResponse", 1)]
    public class MemberVerificationResponse : AggregateEvent<MemberActor, MemberId> {
        public MemberVerificationResponse (bool isSucceed, MemberId memberId) {
            this.IsSucceed = isSucceed;
            this.MemberId = memberId;

        }
        public bool IsSucceed { get; set; }
        public MemberId MemberId { get; set; }
    }
}