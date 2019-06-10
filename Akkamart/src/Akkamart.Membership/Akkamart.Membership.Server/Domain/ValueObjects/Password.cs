using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Password : SingleValueObject<string> {
        public Password (string value) : base (value) { }
    }
}