using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using System;

namespace Logging
{
    public class Logger
    {
        public static void InitializeConsoleLogger()
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()
                        .WriteTo.Console(theme: SystemConsoleTheme.Colored)
                        .CreateLogger();
        }
    }
}
