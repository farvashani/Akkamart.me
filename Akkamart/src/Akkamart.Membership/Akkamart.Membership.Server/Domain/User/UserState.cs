using System.Collections.Generic;
using Akkamart.Membership.Server.Domain.User.Entities;
using Akkamart.Membership.Server.Domain.User.ValueObjects;
using Akkatecture.Aggregates;

namespace Akkamart.Membership.Server.Domain.User
{
    public class UserState : AggregateState<UserActor, UserId> 
    {
        public IList<UserSession> ActiveSessions { get; set; }
        public IsLocked IsLocked { get; set; }
        public IsVerified IsVerified { get; set; }
        public UserMobile UserMobile { get; set; }
        public Username Username { get; set; }
        
        
    }
}