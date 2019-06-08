using Akkatecture.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.ValueObjects
{
    public class Password : SingleValueObject<string>
    {
        public Password(string value) : base(value)
        {
        }
    }
}