using Akka.Actor;

namespace Akkamart.Home.Server.Domain.Cluster.Commands
{
    public class ReplyWithClusterState
    {
        public IActorRef  Receiver{get; private set;}
        public ReplyWithClusterState(IActorRef receiver)
        {
            Receiver = receiver;
            
        }
        
    }
}