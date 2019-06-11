using System;
using System.Collections.Generic;

namespace Akkamart.Shared.Metadata
{
    public class ActionParam
    {
        public string Name { get; set; }
        public string HelpUrl { get; set; }
        public string Type { get; set; }
        public KeyValuePair<string, string> Options { get; set; }
        public string ValidationRule { get; set; }
        public bool IsRequired  { get; set; }
    }
    
}