using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.Profile
{
    
      [JsonConverter(typeof(SingleValueObjectConverter))]
    public class ProfileId : Identity<ProfileId>
    {
        public ProfileId(string value)
            : base(value)
        {
        }
    }
}