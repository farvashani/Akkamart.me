using System;
using Akkatecture.Aggregates;
using Akkamart.Server.Shared.Client.ValueObjects;
using Akkamart.Server.Shared.Client.Events;
using Akkamart.Server.Shared.Client.Commands;
using Akkamart.Server.Shared.Client.Entity;

namespace Akkamart.Server.Shared.Client{
    public class ClientState : AggregateState<ClientActor, ClientId>,
    IApply<Navigated>
     {
        public ClientState (ClientName clientName, IsOnline isOnline) {
            this.ClientName = clientName;
            this.IsOnline = isOnline;

        }
        public ClientName ClientName { get; set; }
        public IsOnline IsOnline { get; set; }
        public History History { get; set; }

        public void Apply(Navigated aggregateEvent)
        {
              var Item = new HistoryItem(){
                Url = aggregateEvent.Url,
                VisitDateTime=new VisitingDateTime(DateTime.Now)
                
            };
            History.Add(Item);
        }
    }
}