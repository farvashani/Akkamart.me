using System.Collections.Generic;
using System.Reflection;
using Akkamart.Shared.Metadata;

namespace Akkamart.Server.Shared.Client.Commands
{
    public class RegisterServiceNavigation
    {
        public List<Metadata> Navigations { get; private set; }

        public RegisterServiceNavigation()
        {
            var metadata = MetadataExtractor.Extract(this.GetType());
            Navigations.Add(metadata);


        }
    }
}