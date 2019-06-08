using Akkatecture.Aggregates;

namespace Akkamart.Membership.Server.Domain.User
{
     public class UserActor : AggregateRoot<UserActor, UserId, UserState>
    {
        public UserActor(UserId id) : base(id)
        {
        }
    }
}