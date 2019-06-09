using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static Akkamart.Shared.Metadata.Metadata;

namespace Akkamart.Shared.Metadata
{
    public class MetadataExtractor
    {
         
            public static Metadata Extract (Type type) {
                
               
                var uiTypes =  type.Assembly.GetTypes ().Where (t =>
                    t.GetCustomAttributes<UIAttributes> ().Any ());

                // var commandTypes = serviceType.GetType ().Assembly.GetTypes ().Where (t => t.BaseType != null && t.BaseType.IsGenericType &&
                //     t.BaseType.GetGenericTypeDefinition () == typeof (ICommand<TAggregate, TIdentity>));

                var serviceMetadata = new Metadata ();
                //serviceMetadata.Title = typeof (TAggregate).Name;

                foreach (var cmd in uiTypes) {
                    var action = new ServiceAction () { Title = cmd.Name };
                    action.Params = getParams (cmd);

                }
                return serviceMetadata;

            }

            private static Dictionary<string, Type> getParams (Type cmd) {
                var paramsDict = new Dictionary<string, Type> ();
                var ctor = cmd.GetConstructors ().OrderBy (np => np.GetParameters ().Count ()).FirstOrDefault ();
                var constParams = ctor.GetParameters ();
                foreach (var p in constParams) {
                    paramsDict.Add (p.GetType ().Name, p.GetType ());

                }
                return paramsDict;

            }
        
    }
}