using System.Collections.Generic;

namespace Akkamart.Shared.Metadata
{
    public class Metadata
    {
        
        public string Title { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public string BaseUrl { get; set; }

        public IList<ServiceAction> Actions { get; set; }
    }
}
