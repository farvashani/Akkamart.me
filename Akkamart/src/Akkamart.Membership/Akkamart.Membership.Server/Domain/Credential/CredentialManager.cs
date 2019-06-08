using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain.Credential
{
    public class CredentialManager : AggregateManager<CredentialActor, CredentialId, Command<CredentialActor, CredentialId>>
    {
        
    }
}