using Akkatecture.Core;

namespace Akkamart.Membership.Server.Domain.User
{
    public class UserId : Identity<UserId> {
        public UserId (string value) : base (value) { }
    }
}