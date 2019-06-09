using System.Collections.Generic;
using System.Linq;

namespace Akkamart.Shared.Metadata
{
    public class NavigationState
    {
        
       public List<Metadata> TopNavigation { get; set; } = new List<Metadata>(){
                        new Metadata{Title = "Home", BaseUrl = "/home/", Actions={}},
                        new Metadata{Title = "Membership", BaseUrl = "/membership/", Actions = {}}
                    };

    }
}