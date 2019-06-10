using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain{
    public class MemberAuthenticated : Command<MemberActor, MemberId> {
        public MemberAuthenticated (MemberId aggregateId) : base (aggregateId) { }
    }
}