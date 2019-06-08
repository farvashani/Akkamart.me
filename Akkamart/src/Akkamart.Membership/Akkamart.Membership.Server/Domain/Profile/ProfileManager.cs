using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Akkamart.Membership.Server.Domain.Profile
{
    
    public class ProfileManager : AggregateManager<ProfileActor, ProfileId, Command<ProfileActor, ProfileId>>
    {
        
    }
}