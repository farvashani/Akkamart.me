using System;
using System.Collections.Generic;
using System.Reflection;
using Akkamart.Shared.Metadata;

namespace Akkamart.Server.Shared.Client.Commands {
    public class RegisterServiceNavigation
    {
        private List<Metadata> navigations;

        public RegisterServiceNavigation(Type serviceType)
        {
            this.ServiceType = serviceType;
            var metadata = MetadataExtractor.Extract(this.GetType());
            Navigations.Add(metadata);

        }
        public Type ServiceType { get; set; }
        public List<Metadata> Navigations
        {
            get {
                if(navigations  == null) 
                    navigations = new List<Metadata>();
                    return navigations; }
            private set
            {
                navigations = value;
            }
        }


    }
}