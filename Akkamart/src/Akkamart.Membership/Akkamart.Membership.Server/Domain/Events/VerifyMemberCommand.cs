using Akkatecture.Commands;


namespace Akkamart.Membership.Server.Domain.Events {
    public class VerifyMemberCommand : Command<MemberActor, MemberId> {
        public string Code { get; set; }
        public VerifyMemberCommand (MemberId aggregateId, string code) : base (aggregateId) {
            Code = code;
        }
    }
}