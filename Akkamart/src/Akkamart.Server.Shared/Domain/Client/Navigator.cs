using Akka.Actor;
using Akkamart.Server.Shared.Client.Commands;
using Akkamart.Shared.Metadata;

namespace Akkamart.Server.Shared.Client
{
    public class Navigator : ReceiveActor {
        private NavigationState _state;

        public NavigationState State {
            get {
                if (_state == null)
                    _state = new NavigationState ();
                return _state;
            }
            private set {
                _state = value;
            }
        }
        protected override void PreStart () {
           
        }
        public Navigator () {

            //child = Context.ActorOf(Props.Create<Child>(), "child");

            Receive<GetNavigationState> (Handle);
             Receive<RegisterServiceNavigation> (Handle);
        }

        private void Handle(RegisterServiceNavigation cmd)
        {
            _state.TopNavigation.AddRange(cmd.Navigations);
        }

        private bool Handle (GetNavigationState command) {

            Sender.Tell (State);
            return true;
        }

    }
}