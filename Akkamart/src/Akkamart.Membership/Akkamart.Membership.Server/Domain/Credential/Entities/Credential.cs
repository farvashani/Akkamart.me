
using Akkamart.Membership.Server.Domain.Credential.ValueObjects;

namespace Akkamart.Membership.Server.Domain.Credential.Entities {
    public class MemberCredential {
        public Username Username { get; set; }
        public Password Password { get; set; }

    }
}