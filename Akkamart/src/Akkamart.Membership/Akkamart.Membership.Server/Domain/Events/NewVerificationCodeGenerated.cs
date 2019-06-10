using Akkatecture.Aggregates;
using Akkatecture.Commands;
using Akkamart.Membership.Server.Domain.ValueObjects;
using Akkamart.Membership.Server.Domain.Credential.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Events {
    public class NewVerificationCodeGeneratedEvent : AggregateEvent<MemberActor, MemberId> {
        public NewVerificationCodeGeneratedEvent (VerificationCode verificationCode) {
            this.VerificationCode = verificationCode;

        }
        public NewVerificationCodeGeneratedEvent (VerificationCode verificationCode, MobileNumber mobileNumber) {
            this.VerificationCode = verificationCode;
            this.MobileNumber = mobileNumber;

        }
        public VerificationCode VerificationCode { get; set; }
        public MobileNumber MobileNumber { get; set; }

    }
}