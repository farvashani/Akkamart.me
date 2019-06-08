using System.Collections.Generic;

namespace Akkamart.Home.Shared.Models
{
    public class ServiceRegistery
    {
        public string RoleName { get; set; }
        public IList<Navigation> Navigations { get; set; }
    }
}