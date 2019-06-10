using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain{
    public class MemberStateRequest : Command<MemberActor, MemberId> {
        public MemberStateRequest (MemberId aggregateId) : base (aggregateId) { }
    }
}