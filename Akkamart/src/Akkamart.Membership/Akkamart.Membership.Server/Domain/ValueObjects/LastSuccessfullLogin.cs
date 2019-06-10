using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class LastSuccessfullLogin : SingleValueObject<DateTime> {
        public LastSuccessfullLogin (DateTime value) : base (value) { }
    }
}