using System;
using Akkamart.Home.Server.Domain.Client.Commands;
using Akkamart.Home.Server.Domain.Client.Events;
using Akkatecture.Aggregates;
using Akkatecture.Specifications.Provided;

namespace Akkamart.Home.Server.Domain.Client
{
    public class ClientActor : AggregateRoot<ClientActor, ClientId, ClientState>
    {
        public ClientActor(ClientId id) : base(id)
        {
            Command<RegisterClientDetails>(Execute);
            Command<LogClientRequest>(Execute);
        }

        private bool Execute(LogClientRequest cmd)
        {
            var spec = new AggregateIsNewSpecification();
            if(spec.IsSatisfiedBy(this))
            {
                var aggregateEvent = new RequestLogged(cmd.ClientId, cmd.ReuestUrl, cmd.Headers);
                Emit(aggregateEvent);
            }

            return true;
        }

        private bool Execute(RegisterClientDetails cmd)
        {
            var spec = new AggregateIsNewSpecification();
            if(spec.IsSatisfiedBy(this))
            {
                var aggregateEvent = new ClientRegisterd(cmd.ClientId, cmd.Details);
                Emit(aggregateEvent);
            }

            return true;
        }
    }
}