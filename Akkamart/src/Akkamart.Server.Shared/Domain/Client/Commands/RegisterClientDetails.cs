namespace Akkamart.Server.Shared.Client.Commands
{
    public class RegisterClientDetails {
        public RegisterClientDetails (ClientId clientId) {
            this.ClientId = clientId;
        }
        
        public ClientId ClientId { get; private set; }
        
    }
}