using Akkatecture.Aggregates;
using Akkatecture.Events;
using Akkamart.Membership.Server.Domain;

namespace Membership {
    [EventVersion ("LoginResultResponse", 1)]
    public class LoginResultResponse : AggregateEvent<MemberActor, MemberId> {
        public LoginResultResponse (bool isSucceed, MemberId memberId) {
            this.IsSucceed = isSucceed;
            this.MemberId = memberId;

        }
        public bool IsSucceed { get; set; }
        public MemberId MemberId { get; set; }
    }
}