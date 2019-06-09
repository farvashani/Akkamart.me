﻿using System;
using System.IO;
using System.Threading;
using Akka.Actor;
using Akka.Configuration;
using Akka.Event;
using Akkamart.Shared;
using Akkamart.Server.Shared;

namespace Akkamart.Seed1 {
    internal static class Program {
        [Obsolete]
        private static void Main (string[] args) {
            var sys = Common.CreateSystem (args[0]);

            Common.WaitForExit ();
            Common.Shutdown (sys);
        }
    }
}