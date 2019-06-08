using Akkamart.Home.Server.Domain.Client.ValueObjects;
using Akkatecture.Aggregates;

namespace Akkamart.Home.Server.Domain.Client {
    public class ClientState : AggregateState<ClientActor, ClientId> {
        public ClientState (ClientName clientName, IsOnline propertyName) {
            this.ClientName = clientName;
            this.PropertyName = propertyName;

        }
        public ClientName ClientName { get; set; }
        public IsOnline PropertyName { get; set; }

    }
}