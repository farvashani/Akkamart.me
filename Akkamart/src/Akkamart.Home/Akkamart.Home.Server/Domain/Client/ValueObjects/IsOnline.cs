using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Home.Server.Domain.Client.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class IsOnline : SingleValueObject<bool> {
        public IsOnline (bool value) : base (value) { }
    }
}