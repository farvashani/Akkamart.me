using Akka.Actor;
using Akka.Cluster;
using Akka.Event;
using Akkamart.Server.Shared.Client.Commands;
using Akkamart.Shared.Metadata;
using static Akka.Cluster.ClusterEvent;

namespace Akkamart.Server.Shared.Client {
    public class Navigator : UntypedActor {
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
        protected CurrentClusterState currentClusterState;
        protected ILoggingAdapter Log = Context.GetLogger ();
        protected Akka.Cluster.Cluster Cluster = Akka.Cluster.Cluster.Get (Context.System);

        /// <summary>
        /// Need to subscribe to cluster changes
        /// </summary>
        protected override void PreStart () {
            Cluster.Subscribe (Self, ClusterEvent.InitialStateAsEvents,
                new [] {
                    typeof (ClusterEvent.IMemberEvent),
                    typeof (ClusterEvent.UnreachableMember)
                });
        }

        /// <summary>
        /// Re-subscribe on restart
        /// </summary>
        protected override void PostStop () {
            Cluster.Unsubscribe (Self);
        }

        protected override void OnReceive (object message) {
            if (message is GetNavigationState) {
                //Cluster.SendCurrentClusterState (Self);
                  Sender.Tell (State);

            } else if(message is RegisterServiceNavigation)
            {
                var cmd = (message as RegisterServiceNavigation);
                State.TopNavigation.AddRange(cmd.Navigations);
                
            }
            else {
                HandelClusterEvents (message);
            }

        }
        private void HandelClusterEvents (object message) {
            var up = message as ClusterEvent.MemberUp;
            if (up != null) {
                var mem = up;
                Log.Info ("Member is Up: {0}", mem.Member);
            } else if (message is ClusterEvent.UnreachableMember) {
                var unreachable = (ClusterEvent.UnreachableMember) message;
                Log.Info ("Member detected as unreachable: {0}", unreachable.Member);
            } else if (message is ClusterEvent.MemberRemoved) {
                var removed = (ClusterEvent.MemberRemoved) message;
                Log.Info ("Member is Removed: {0}", removed.Member);
            } else if (message is ClusterEvent.MemberJoined) {
                var joined = (ClusterEvent.MemberJoined) message;
                Log.Info ("Member is Joined: {0}", joined.Member);
            } else if (message is ClusterEvent.IMemberEvent) {
                //IGNORE                
            } else if (message is ClusterEvent.CurrentClusterState) {
                currentClusterState = (message as ClusterEvent.CurrentClusterState);

            } else {
                Unhandled (message);

            }
        }

        // // private void Handle (RegisterServiceNavigation cmd) {
        // //     _state.TopNavigation.AddRange (cmd.Navigations);
        // // }

        // private bool Handle (GetNavigationState command) {
        //     Cluster.SendCurrentClusterState (Self);

        //     Sender.Tell (State);
        //     return true;
        // }

    }
}