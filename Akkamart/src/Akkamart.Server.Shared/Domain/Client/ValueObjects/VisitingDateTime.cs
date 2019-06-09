using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Akkamart.Server.Shared.Client.ValueObjects
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class VisitingDateTime : SingleValueObject<DateTime>
    {
        public VisitingDateTime(DateTime value) : base(value)
        {
        }
    }




}