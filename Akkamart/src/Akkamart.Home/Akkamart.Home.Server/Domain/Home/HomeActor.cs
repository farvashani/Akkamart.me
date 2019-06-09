using System.Collections.Generic;
using System.Collections.Immutable;
using Akka.Actor;
using Akkamart.Home.Server.Domain.Home.Commands;
using Akkamart.Home.Shared.Models;

namespace Akkamart.Home.Server.Domain {
    public class HomeActor : ReceiveActor {
        ImmutableSortedSet<Navigation> _homeNavigationItems = ImmutableSortedSet<Navigation>.Empty;
        public int PropertyName { get; set; }
        public HomeActor () {
            //child = Context.ActorOf(Props.Create<Child>(), "child");
            Receive<UpdateHomeNavigationTile> (Handle);
            Receive<GetNavigationState> (Handle);
        }
        private bool Handle (UpdateHomeNavigationTile command) {
            // Revenue = Revenue + command.AmountToAdd;
            // Transactions++;
            return true;
        }
        private bool Handle (GetNavigationState command) {
            //Sender.Tell(_homeNavigationItems)
            return true;
        }

    }
}