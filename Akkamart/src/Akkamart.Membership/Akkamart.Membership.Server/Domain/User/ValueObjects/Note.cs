using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Note : SingleValueObject<string>
    {
        public Note(string value) : base(value)
        {
        }
    }

}