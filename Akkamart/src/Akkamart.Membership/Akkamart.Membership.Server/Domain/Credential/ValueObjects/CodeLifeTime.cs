using Akkatecture.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.ValueObjects
{
    public class CodeLifeTime : SingleValueObject<int>
    {
        public CodeLifeTime(int value) : base(value)
        {
        }
    }
}