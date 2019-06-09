using System;
using System.Collections.Generic;

namespace Akkamart.Shared.Metadata {
    public class ServiceAction {
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Type> Params { get; set; }

    }
}