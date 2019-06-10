using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{

    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class MobileNumber : SingleValueObject<string> {
        public MobileNumber (string value) : base (value) { }
    }
}