using Akkamart.Home.Server.Domain.Client.ValueObjects;
using Akkatecture.Aggregates;
using Akkatecture.Events;
using Microsoft.AspNetCore.Http;

namespace Akkamart.Home.Server.Domain.Client.Events {

    [EventVersion ("RequestLogged", 1)]
    public class RequestLogged : AggregateEvent<ClientActor, ClientId> {
        
        public RequestLogged (ClientId clientId, ReuestUrl reuestUrl, IHeaderDictionary headers) {
            this.ClientId = clientId;
            this.ReuestUrl = reuestUrl;
            this.Headers = headers;

        }
        public ClientId ClientId { get; private set; }
        public ReuestUrl ReuestUrl { get; set; }
        public IHeaderDictionary Headers { get; private set; }

    }
}