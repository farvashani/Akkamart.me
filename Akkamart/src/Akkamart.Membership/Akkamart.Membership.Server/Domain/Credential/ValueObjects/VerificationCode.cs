using Akkatecture.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.ValueObjects
{
    public class VerificationCode : SingleValueObject<string>
    {
        public VerificationCode(string value) : base(value)
        {
        }
    }
}