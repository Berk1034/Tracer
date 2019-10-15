using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Diagnostics;

namespace Tracer
{
    public class MethodTraceResult
    {
        public static MethodTraceResult StackTop { get; }
        public List<MethodTraceResult> Methods { get; }
        private Stopwatch _stopwatch;

        public string WorkTimeStr
        {
            get
            {
                return Math.Round((double)WorkTime) + "ms";
            }
            set
            {
                WorkTimeStr = value;
            }
        }

        public long WorkTime { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }

        static MethodTraceResult()
        {
            StackTop = new MethodTraceResult();
            StackTop.ClassName = null;
            StackTop.MethodName = null;
        }

        public MethodTraceResult(string methodName, string className)
            : this()
        {
            MethodName = methodName;
            ClassName = className;
        }

        private MethodTraceResult()
        {
            Methods = new List<MethodTraceResult>();
            _stopwatch = new Stopwatch();
        }

        public void StartTrace()
        {
            _stopwatch.Start();
        }

        public long GetWorkTime()
        {
            return _stopwatch.ElapsedMilliseconds;
        }

        public void StopTrace()
        {
            _stopwatch.Stop();
            WorkTime = _stopwatch.ElapsedMilliseconds;
        }

        public static bool AddNestedMethod(MethodTraceResult parent, MethodTraceResult child)
        {
            if (child == null)
                return false;

            parent.Methods.Add(child);

            return true;
        }
    }
}
