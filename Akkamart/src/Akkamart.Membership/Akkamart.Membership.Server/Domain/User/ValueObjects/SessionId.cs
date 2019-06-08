using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.ValueObjects {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class SessionId : SingleValueObject<string> {
        public SessionId (string value) : base (value) { }
    }
}