using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects
{
     [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Username : SingleValueObject<string>
    {
        public Username(string value) : base(value)
        {
        }
    }
}