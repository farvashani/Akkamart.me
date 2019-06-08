using Microsoft.AspNetCore.Http;

namespace Akkamart.Home.Server.Domain.Client.Commands {
    public class LogClientDetails {
        public LogClientDetails (string clientId, IHeaderDictionary headers) {
            this.ClientId = clientId;
            this.Headers = headers;

        }
        public string ClientId { get; set; }
        public IHeaderDictionary Headers { get; set; }
    }
}