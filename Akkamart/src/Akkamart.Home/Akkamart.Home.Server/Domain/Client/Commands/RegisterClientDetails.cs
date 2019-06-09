using Microsoft.AspNetCore.Http;

namespace Akkamart.Home.Server.Domain.Client.Commands {
    public class RegisterClientDetails {
        public RegisterClientDetails (ClientId clientId, IHeaderDictionary headers) {
            this.ClientId = clientId;
            this.Details = headers;

        }
        
        public ClientId ClientId { get; private set; }
        public IHeaderDictionary Details { get; private set; }
    }
}