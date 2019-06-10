using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.Credential.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class VerificationCode : SingleValueObject<string>
    {
        public VerificationCode(string value) : base(value)
        {
        }
    }
}