using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    public class Tracer : ITracer
    {
        public TraceResult Traceresult;

        public Tracer()
        {
            Traceresult = new TraceResult();
        }

        public void StartTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            MethodTraceResult newMethod = new MethodTraceResult(method.Name, method.ReflectedType.Name);
            newMethod.StartTrace();
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            MethodTraceResult lastMethod = Traceresult.Threads[threadId].Methods.Last();
            lastMethod.StopTrace();
        }

        public TraceResult GetTraceResult()
        {
            return Traceresult;
        }
    }
}
