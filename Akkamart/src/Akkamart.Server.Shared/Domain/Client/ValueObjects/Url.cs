using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Server.Shared.Client.ValueObjects
{
    
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Url : SingleValueObject<string> {
        public Url (string value) : base (value) { }
    }
}