using System;

namespace Akkamart.Shared.Metadata
{
    public class MetadataAttribute : Attribute
    {
        
        public MetadataAttribute (string name) {
            this.Name = name;

        }
        public string Name { get; private set; }

    
    }
}