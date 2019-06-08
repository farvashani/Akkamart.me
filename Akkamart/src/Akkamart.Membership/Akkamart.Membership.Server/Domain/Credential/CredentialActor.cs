using Akkatecture.Aggregates;

namespace Akkamart.Membership.Server.Domain.Credential
{
    public class CredentialActor : AggregateRoot<CredentialActor, CredentialId, CredentialState>
    {
        public CredentialActor(CredentialId id) : base(id)
        {
        }
    }
}