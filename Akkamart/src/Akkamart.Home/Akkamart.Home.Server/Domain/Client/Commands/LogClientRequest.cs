using Akkamart.Home.Server.Domain.Client.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Akkamart.Home.Server.Domain.Client.Commands {
    public class LogClientRequest {
        public LogClientRequest (ClientId clientId, ReuestUrl reuestUrl) {
            this.ClientId = clientId;
            this.ReuestUrl = reuestUrl;

        }
        public ClientId ClientId { get; set; }
        public ReuestUrl ReuestUrl { get; set; }
        public IHeaderDictionary Headers { get; private set; }
        //public IBodyDictionary Headers { get; private set; }

    }
}