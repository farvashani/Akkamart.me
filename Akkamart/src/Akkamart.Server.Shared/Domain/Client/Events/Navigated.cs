using Akkamart.Server.Shared.Client;
using Akkamart.Server.Shared.Client.ValueObjects;
using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Akkamart.Server.Shared.Client.Events
{
    [EventVersion("Navigated", 1)]
    public class Navigated : AggregateEvent<ClientActor, ClientId>  {
        public Navigated (ClientId clientId, Url url) {
            this.ClientId = clientId;
            this.Url = url;

        }
        public ClientId ClientId { get; private set; }
        public Url Url { get; private  set; }

    }
     
}
