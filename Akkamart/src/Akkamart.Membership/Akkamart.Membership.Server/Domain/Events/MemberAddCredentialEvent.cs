using System;
using Akkatecture.Aggregates;
using Akkatecture.Events;
using Akkamart.Membership.Server.Domain.Credential.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Events {
    public class MemberAddCredentialEvent : AggregateEvent<MemberActor, MemberId> {
        

        public MemberAddCredentialEvent (MemberId memberId,Username username,Password password) {
            this.MemberId = memberId;
            this.Username = username;
            this.Password = password;
        }
        // public bool IsSucceed { get; set; }
        public MemberId MemberId { get; private set; }
        public Username Username { get; private set; }
        public Password Password { get; private set; }
    }
}