using System.Collections.Generic;
using System.Collections.Immutable;
using Akkamart.Home.Shared.Models;

namespace Akkamart.Home.Server.Domain.Home.Commands
{
    public class GetNavigationState
    {
        public ImmutableSortedSet<Navigation>  NavigationItems {get; private set;}
        public GetNavigationState(ImmutableSortedSet<Navigation>  navItems)
        {
            NavigationItems =  navItems;
        }
        
    }
}