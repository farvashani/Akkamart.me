using System;
using System.Collections.Generic;
using System.Reflection;
using Akkamart.Shared.Metadata;

namespace Akkamart.Server.Shared.Client.Commands {
    public class RegisterServiceNavigation {
        public RegisterServiceNavigation (Type serviceType) {
            this.ServiceType = serviceType;
            var metadata = MetadataExtractor.Extract (this.GetType ());
            Navigations.Add (metadata);

        }
        public Type ServiceType { get; set; }
        public List<Metadata> Navigations { get; private set; }

       
    }
}