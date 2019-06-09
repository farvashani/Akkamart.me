using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;

namespace Akkamart.Server.Shared {
    public static class Common {
        public static ActorSystem CreateSystem (string configFile) {
            Console.WriteLine ("Starting..");

            StandardOutLogger.UseColors = true;
            var config = LoadConfig (configFile);
            return ActorSystem.Create ("akkamart", config);
        }
        private static Akka.Configuration.Config LoadConfig (string configFile) {
            Console.WriteLine ($"$%%%%%%%%OWN_HOST%%%%%% : {Environment.GetEnvironmentVariable ("OWN_HOST")}");
            var basepath = AppDomain.CurrentDomain.BaseDirectory;
            if (!configFile.StartsWith (basepath))
                configFile = Path.Combine (basepath, configFile);

            if (File.Exists (configFile)) {
                string config = File.ReadAllText (configFile);
                config = config
                    .Replace ("{{OWN_HOST}}", Environment.GetEnvironmentVariable ("OWN_HOST") ??
                        (Environment.CommandLine.Contains ("--local") ?
                            "localhost" :
                            System.Net.Dns.GetHostName ()))
                    .Replace ("{{SEED_NODE_HOST}}", Environment.GetEnvironmentVariable ("SEED_NODE_HOST") ?? "localhost")
                    .Replace ("{{SEED_NODE_PORT}}", Environment.GetEnvironmentVariable ("SEED_NODE_PORT") ?? "5050")
                    .Replace ("{{SQLSERVER_CONNECTION}}", Environment.GetEnvironmentVariable ("SQLSERVER_CONNECTION") ?? "");
                Console.WriteLine (config);
                return ConfigurationFactory.ParseString (config);
            }
            return Akka.Configuration.Config.Empty;
        }

        public static void WaitForExit () {
            var r = new ManualResetEvent (false);
            Console.CancelKeyPress += (_, e) => { Console.WriteLine ("Caught ctrl-c.."); e.Cancel = true; r.Set (); };
            r.WaitOne ();

            Console.WriteLine ("Exiting..");
        }

        public static void Shutdown (ActorSystem sys) {
            CoordinatedShutdown.Get (sys).Run ().Wait (TimeSpan.FromSeconds (10));

            Console.WriteLine ("Bye");
        }
    }
}