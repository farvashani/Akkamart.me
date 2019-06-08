using Akkatecture.Core;

namespace Akkamart.Home.Server.Domain.Client
{
    public class ClientId : Identity<ClientId> {
        public ClientId (string value) : base (value) { }
    }
}