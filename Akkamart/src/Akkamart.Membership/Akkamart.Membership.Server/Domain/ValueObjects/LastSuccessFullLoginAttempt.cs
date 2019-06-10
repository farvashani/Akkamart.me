using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class LastSuccessFullLoginAttempt : SingleValueObject<DateTime> {
        public LastSuccessFullLoginAttempt (DateTime value) : base (value) { }
    }
}