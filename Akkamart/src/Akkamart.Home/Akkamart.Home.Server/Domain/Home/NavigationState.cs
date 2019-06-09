using System.Collections.Immutable;
using Akkamart.Home.Shared.Models;

namespace Akkamart.Home.Server.Domain.Home
{
    public class NavigationState
    {
        public ImmutableSortedSet<Navigation> NavigationItems {get; set;}
        
    }
}