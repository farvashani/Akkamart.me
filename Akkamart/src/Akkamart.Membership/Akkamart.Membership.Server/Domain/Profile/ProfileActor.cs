using Akkatecture.Aggregates;

namespace Akkamart.Membership.Server.Domain.Profile
{
    public class ProfileActor : AggregateRoot<ProfileActor, ProfileId, ProfileState>
    {
        public ProfileActor(ProfileId id) : base(id)
        {
        }
    }
}