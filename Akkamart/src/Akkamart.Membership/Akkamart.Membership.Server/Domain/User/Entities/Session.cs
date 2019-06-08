using Akkamart.Membership.Server.Domain.User.ValueObjects;
using Akkatecture.Entities;

namespace Akkamart.Membership.Server.Domain.User.Entities {
    public class UserSession : Entity<SessionId> {
        public UserSession (SessionId id) : base (id) { }

        
        public SessionId SessionId { get; set; }
        public SessionTitle SessionTitle { get; set; }
        public ClientIP ClientIP { get; set; }
        public SessionDate StartDate { get; set; }
    }
}