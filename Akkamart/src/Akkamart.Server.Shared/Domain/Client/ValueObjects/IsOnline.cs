using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Server.Shared.Client.ValueObjects
{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class IsOnline : SingleValueObject<bool> {
        public IsOnline (bool value) : base (value) { }
    }
}