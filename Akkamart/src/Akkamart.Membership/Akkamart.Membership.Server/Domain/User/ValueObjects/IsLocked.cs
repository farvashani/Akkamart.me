using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class IsLocked : SingleValueObject<bool>
    {
        public IsLocked(bool value) : base(value)
        {
        }
    }
}