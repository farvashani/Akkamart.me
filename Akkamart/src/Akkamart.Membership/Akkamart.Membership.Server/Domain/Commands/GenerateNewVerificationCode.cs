using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain{
    public class GenerateNewVerificationCode : Command<MemberActor, MemberId> {
        public GenerateNewVerificationCode (MemberId aggregateId) : base (aggregateId) {

        }

    }
}