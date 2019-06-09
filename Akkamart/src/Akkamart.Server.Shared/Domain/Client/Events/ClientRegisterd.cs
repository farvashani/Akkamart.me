using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Akkamart.Server.Shared.Client.Events
{
    [EventVersion("ClientRegisterd", 1)]
    public class ClientRegisterd : AggregateEvent<ClientActor, ClientId> 
    {
         public ClientRegisterd (ClientId clientId) {
            this.ClientId = clientId;
        }
        
        public ClientId ClientId { get; private set; }
        
        
    }
}