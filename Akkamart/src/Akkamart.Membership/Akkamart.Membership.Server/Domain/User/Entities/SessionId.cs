using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.User.Entities
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class SessionId : Identity<SessionId>
    {
        public SessionId(string value) : base(value)
        {
        }
    }
}