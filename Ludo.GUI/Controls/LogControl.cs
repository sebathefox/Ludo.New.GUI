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

        /// <summary>
        /// Creates a new logger
        /// </summary>
        public static void Init()
        {
            // Logs information to a log file
            Trace.Listeners.Add(new TextWriterTraceListener("Log.LOG"));
            Trace.AutoFlush = true; // Flushes the buffer and sends the data to the disk
            Trace.Indent(); // Newline
        }

        /// <summary>
        /// Closes the logger
        /// </summary>
        public static void Close()
        {
            Trace.Unindent(); //Removes the indentation
            Trace.Flush(); // Writes the data
        }

        /// <summary>
        /// Logs a string
        /// </summary>
        /// <param name="log">The string to log</param>
        /// <param name="level">The loglevel to use (blank for default)</param>
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
