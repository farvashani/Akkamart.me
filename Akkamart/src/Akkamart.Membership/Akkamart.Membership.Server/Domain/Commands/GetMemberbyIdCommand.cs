using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain{
    public class GetMemberbyIdCommand : Command<MemberActor, MemberId> {
        public GetMemberbyIdCommand (MemberId aggregateId) : base (aggregateId) { }
    }
}