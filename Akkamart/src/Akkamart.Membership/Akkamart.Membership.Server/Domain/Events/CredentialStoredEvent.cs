using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;
namespace Akkamart.Membership.Server.Domain.Events {

    [EventVersion ("CredentialStoredEvent", 1)]
    public class CredentialStoredEvent : AggregateEvent<MemberActor, MemberId> {
        public CredentialStoredEvent (MemberId memberId) {
            this.MemberId = MemberId;
        }
        public MemberId MemberId { get; set; }
        public IIdentity CredentialId { get; internal set; }
    }

}