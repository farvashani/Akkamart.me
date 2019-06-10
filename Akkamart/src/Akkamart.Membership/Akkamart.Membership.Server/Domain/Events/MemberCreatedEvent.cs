using System;
using Akkatecture.Aggregates;
using Akkatecture.Events;
using Akkamart.Membership.Server.Domain.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Events {
    public class MemberCreatedEvent : AggregateEvent<MemberActor, MemberId> {
        public MemberCreatedEvent (MobileNumber mobilenumber,
            MemberId memberId,
            bool isSucceed = true) {
            this.Mobilenumber = mobilenumber;
            this.MemberId = memberId;
            this.IsSucceed = isSucceed;
        }
        public bool IsSucceed { get; set; }
        public MemberId MemberId { get; private set; }
        public MobileNumber Mobilenumber { get; private set; }
    }
}