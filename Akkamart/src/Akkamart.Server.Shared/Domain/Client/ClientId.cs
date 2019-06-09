using Akkatecture.Core;

namespace Akkamart.Server.Shared.Client
{
    public class ClientId : Identity<ClientId> {
        public ClientId (string value) : base (value) { }
    }
}