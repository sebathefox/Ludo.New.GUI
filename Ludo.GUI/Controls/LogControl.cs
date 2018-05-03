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
        public static void Init()
        {
            Trace.Listeners.Add(new TextWriterTraceListener("Output.log"));
            Trace.AutoFlush = true;
            Trace.Indent();
        }

        public static void Close()
        {
            Trace.Unindent();
            Trace.Flush();
        }

        public static void Log(string log)
        {
            Trace.WriteLine(log);
        }
    }
}
