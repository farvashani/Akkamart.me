using System;
using Akkamart.Server.Shared.Client.Commands;
using Akkamart.Server.Shared.Client.Events;
using Akkatecture.Aggregates;
using Akkatecture.Specifications.Provided;


namespace Akkamart.Server.Shared.Client
{
    public class ClientActor : AggregateRoot<ClientActor, ClientId, ClientState>
    {
        public ClientActor(ClientId id) : base(id)
        {
            Command<RegisterClientDetails>(Execute);
            
        }

        private bool Execute(RegisterClientDetails cmd)
        {
            var spec = new AggregateIsNewSpecification();
            if(spec.IsSatisfiedBy(this))
            {
                var aggregateEvent = new ClientRegisterd(cmd.ClientId);
                Emit(aggregateEvent);
            }

            return true;
        }
    }
}