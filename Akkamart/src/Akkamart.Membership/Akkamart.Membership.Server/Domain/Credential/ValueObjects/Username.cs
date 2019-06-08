using Akkatecture.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.ValueObjects
{
    public class Username : SingleValueObject<string>
    {
        public Username(string value) : base(value)
        {
        }
    }
}