using StardewModdingAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode
{
    public class Logger
    {
        private static IMonitor monitor;

        public static void Init(IMonitor monitor)
        {
            Logger.monitor = monitor;
        }

        public static void Info(string message)
        {
            monitor.Log(message, LogLevel.Info);
        }

        public static void Warn(string message)
        {
            monitor.Log(message, LogLevel.Warn);
        }

        public static void Error(string message)
        {
            monitor.Log(message, LogLevel.Error);
        }

        public static void Trace(string message)
        {
            monitor.Log(message, LogLevel.Trace);
        }
    }
}
