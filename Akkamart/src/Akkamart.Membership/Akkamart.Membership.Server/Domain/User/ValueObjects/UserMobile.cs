using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects
{

    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class UserMobile : SingleValueObject<string>
    {
        public UserMobile(string value) : base(value)
        {
        }
    }
}