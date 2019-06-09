using Akkatecture.Aggregates;
using Akkatecture.Events;
using Microsoft.AspNetCore.Http;

namespace Akkamart.Home.Server.Domain.Client.Events
{
    [EventVersion("ClientRegisterd", 1)]
    public class ClientRegisterd : AggregateEvent<ClientActor, ClientId> 
    {
         public ClientRegisterd (ClientId clientId, IHeaderDictionary details) {
            this.ClientId = clientId;
            this.Details = details;
        }
        
        public ClientId ClientId { get; private set; }
        public IHeaderDictionary Details { get; private set; }
        
    }
}