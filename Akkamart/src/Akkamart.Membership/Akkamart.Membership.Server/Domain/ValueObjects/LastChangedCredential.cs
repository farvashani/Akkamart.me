using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Membership.Server.Domain.ValueObjects{
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class LastChangedCredential : SingleValueObject<DateTime> {
        public LastChangedCredential (DateTime value) : base (value) { }
    }

}