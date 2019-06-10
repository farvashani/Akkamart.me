using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class FullName : SingleValueObject<string> {
        public FullName (string value) : base (value) { }
    }
}