using Akkatecture.Aggregates;
using Akkatecture.Core;
using Akkatecture.Events;
namespace Akkamart.Membership.Server.Domain.Events {

    [EventVersion ("CredentialRequested", 1)]
    public class CredentialRequested : AggregateEvent<MemberActor, MemberId> {
        public CredentialRequested (MemberId memberId, IIdentity credentialId) {
            this.MemberId = MemberId;
            this.CredentialId = credentialId;

        }
        public MemberId MemberId { get; private set; }
        public IIdentity CredentialId { get; private set; }
    }

}