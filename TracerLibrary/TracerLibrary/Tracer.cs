﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;

namespace TracerLibrary
{
    public class Tracer : ITracer
    {
        public bool Calculated { get; private set; }
        public TraceResult Traceresult;

        public Tracer()
        {
            Traceresult = new TraceResult();
        }

        public void StartTrace()
        {
            Calculated = false;
            int threadId = Thread.CurrentThread.ManagedThreadId;
            if (!ThreadTraceResult.IsExist(threadId, Traceresult.Threads))
            {
                var temp = new ThreadTraceResult((uint)threadId);
                Traceresult.Threads.GetOrAdd(threadId, temp);
            }

            MethodTraceResult Stacktop = Traceresult.Threads[threadId].InnerMethods.Peek();

            StackTrace Stacktrace = new StackTrace();
            MethodBase method = Stacktrace.GetFrame(1).GetMethod();
            MethodTraceResult Newmethod = new MethodTraceResult(method.Name, method.ReflectedType.Name);
            Newmethod.StartTrace();
            MethodTraceResult.AddNestedMethod(Stacktop, Newmethod);
            if (Stacktop.ClassName == null)
            {
                Traceresult.Threads[threadId].RootMethods.Add(Newmethod);
            }

            Traceresult.Threads[threadId].InnerMethods.Push(Newmethod);
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            MethodTraceResult lastMethod = Traceresult.Threads[threadId].InnerMethods.Pop();
            lastMethod.StopTrace();
        }

        public TraceResult GetTraceResult()
        {
            if (!Calculated)
            {
                CalculateThreadsTime();
                Calculated = true;
            }
            return Traceresult;
        }

        private void CalculateThreadsTime()
        {
            foreach (KeyValuePair<int, ThreadTraceResult> thread in Traceresult.Threads)
            {
                thread.Value.CalculateFullTime();
            }
        }
    }
}