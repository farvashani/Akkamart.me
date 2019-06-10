using Akka.Actor;
using Akkamart.Server.Shared.Client.Commands;
using Akkamart.Shared.Metadata;
using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain {
    
    public class MemberManager : AggregateManager<MemberActor, MemberId, Command<MemberActor, MemberId>> {

        protected override void PreStart()
        {
            var navigator = Context.ActorSelection("../user/navigation-actor");
            //var meadata = MetadataExtractor.Extract(this.GetType());
            var cmd = new RegisterServiceNavigation(this.GetType());
            var getNavigationState = new GetNavigationState();
            navigator.Tell(getNavigationState);
            
            

        }

        // protected override IActorRef CreateAggregate (MemberId aggregateId) {
        //     var aggregateRef = Context.ActorOf (Props.Create<MemberActor> (() => new MemberActor (aggregateId)));
        //     Context.Watch (aggregateRef);
        //     return aggregateRef;
        // }
    }
}