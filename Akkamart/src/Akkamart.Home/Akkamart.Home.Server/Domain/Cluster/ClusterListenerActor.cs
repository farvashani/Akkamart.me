using Akka.Actor;
using Akka.Cluster;
using Akka.Event;
using Akkamart.Home.Server.Domain.Cluster.Commands;
using Akkatecture.Akka;
using static Akka.Cluster.ClusterEvent;

namespace Akkamart.Home.Server.Domain
{
    public class ClusterListenerActor : UntypedActor
    {
        private readonly ActorRefProvider<HomeActor> _homeActor;
        protected CurrentClusterState CurrentClusterState;
        protected ILoggingAdapter Log = Context.GetLogger();
        protected Akka.Cluster.Cluster Cluster = Akka.Cluster.Cluster.Get(Context.System);

        /// <summary>
        /// Need to subscribe to cluster changes
        /// </summary>
        protected override void PreStart()
        {
            Cluster.Subscribe(Self, ClusterEvent.InitialStateAsEvents, 
                        new []{ typeof(ClusterEvent.IMemberEvent), 
                                typeof(ClusterEvent.UnreachableMember) });
        }

        /// <summary>
        /// Re-subscribe on restart
        /// </summary>
        protected override void PostStop()
        {
            Cluster.Unsubscribe(Self);
        }

        protected override void OnReceive(object message)
        {
            if(message is ReplyWithClusterState)
            {
                var sender = (message as ReplyWithClusterState).Receiver;
                Cluster.SendCurrentClusterState (sender);
            }
            var up = message as ClusterEvent.MemberUp;
            if (up != null)
            {
                var mem = up;
                Log.Info("Member is Up: {0}", mem.Member);
            } 
            else if(message is ClusterEvent.UnreachableMember)
            {
                var unreachable = (ClusterEvent.UnreachableMember) message;
                Log.Info("Member detected as unreachable: {0}", unreachable.Member);
            }
            else if (message is ClusterEvent.MemberRemoved)
            {
                var removed = (ClusterEvent.MemberRemoved) message;
                Log.Info("Member is Removed: {0}", removed.Member);
            }
             else if (message is ClusterEvent.MemberJoined)
            {
                var joined = (ClusterEvent.MemberJoined) message;
                Log.Info("Member is Joined: {0}", joined.Member);
            }
            else if (message is ClusterEvent.IMemberEvent)
            {
                //IGNORE                
            }
            else if (message is ClusterEvent.CurrentClusterState)
            {
                CurrentClusterState = (message as ClusterEvent.CurrentClusterState);

                
            }
            else
            {
                Unhandled(message);
                
            }
        }
    }
}