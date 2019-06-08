using Akkatecture.Aggregates;

namespace Akkamart.Home.Server.Domain.Client
{
    public class ClientActor : AggregateRoot<ClientActor, ClientId, ClientState>
    {
        public ClientActor(ClientId id) : base(id)
        {
        }
    }
}