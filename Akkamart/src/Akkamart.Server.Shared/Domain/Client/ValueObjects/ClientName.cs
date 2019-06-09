using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Server.Shared.Client.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class ClientName : SingleValueObject<string>
    {
        public ClientName(string value) : base(value)
        {
        }
    }
}