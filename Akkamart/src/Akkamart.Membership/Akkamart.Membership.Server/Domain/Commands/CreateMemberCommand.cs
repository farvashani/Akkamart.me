using System.Reflection;
using Akkatecture.Commands;


namespace Akkamart.Membership.Server.Domain{
    public class CreateMemberCommand : Command<MemberActor, MemberId> {
        public CreateMemberCommand (MemberId aggregateId, string mobilenumber) : base (aggregateId) {
            Mobilenumber = mobilenumber;
        }
        public string Mobilenumber { get; private set; }
    }
}