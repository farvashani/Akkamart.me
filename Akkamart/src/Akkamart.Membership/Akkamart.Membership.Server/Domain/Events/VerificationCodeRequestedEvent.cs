using Akkamart.Membership.Server.Domain.Credential.ValueObjects;
using Akkamart.Membership.Server.Domain.ValueObjects;
using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Akkamart.Membership.Server.Domain.Events {

    [EventVersion ("VerificationCodeRequestedEvent", 1)]
    public class VerificationCodeRequestedEvent : AggregateEvent<MemberActor, MemberId> {
        public VerificationCodeRequestedEvent (
            VerificationCode verificationCode, MobileNumber mobileNumber) {
            this.VerificationCode = verificationCode;
            this.MobileNumber = mobileNumber;
        }
        public VerificationCode VerificationCode { get; set; }
        public MobileNumber MobileNumber { get; set; }
    }
}