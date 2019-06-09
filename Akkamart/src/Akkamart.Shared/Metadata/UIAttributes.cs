using System;

namespace Akkamart.Shared.Metadata {
    [AttributeUsage (AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class UIAttributes : Attribute {

        public UIAttributes (string name) {
            this.Name = name;
        }
        public UIAttributes (string name, string uRL) {
            this.Name = name;
            this.URL = uRL;

        }
        public string Name { get; private set; }
        public string URL { get; private set; }

    }
}