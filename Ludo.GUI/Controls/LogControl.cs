using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.GUI.Controls
{
    public static class LogControl
    {
        public enum LogLevel { Information, Debug, Warning, Error, Space}

        public static void Init()
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Log.LOG"));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public static void Close()
        {
            Trace.Unindent();
            Trace.Flush();
        }

        public static void Log(string log, LogLevel level = LogLevel.Space)
        {
            switch (level)
            {
                case LogLevel.Information:
                    Trace.WriteLine(log, "INFORMATION");
                    break;
                case LogLevel.Debug:
                    Trace.WriteLine(log, "DEBUG");
                    break;
                case LogLevel.Warning:
                    Trace.WriteLine(log, "WARNING");
                    break;
                case LogLevel.Error:
                    Trace.WriteLine(log, "ERROR");
                    break;
                default:
                    Trace.WriteLine(log);
                    break;
            }
        }
    }
}
