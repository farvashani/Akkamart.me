using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Home.Server.Domain.Client.ValueObjects
{
    
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class ReuestUrl : SingleValueObject<string> {
        public ReuestUrl (string value) : base (value) { }
    }
}