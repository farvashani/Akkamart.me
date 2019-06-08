using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects
{
    
     [JsonConverter (typeof (SingleValueObjectConverter))]
    public class IsVerified : SingleValueObject<bool>
    {
        public IsVerified(bool value) : base(value)
        {
        }
    }
}