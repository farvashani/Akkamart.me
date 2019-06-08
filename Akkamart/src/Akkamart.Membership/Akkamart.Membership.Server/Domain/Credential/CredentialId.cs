using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.Credential
{

    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class CredentialId : Identity<CredentialId>
    {
        public CredentialId(string value)
            : base(value)
        {
        }
    }
}