using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Tracer
{
    public class TraceResult
    {
        public ConcurrentDictionary<int, ThreadTraceResult> Threads { get; set; }

        public TraceResult()
        {
            Threads = new ConcurrentDictionary<int, ThreadTraceResult>();
        }

        public int GetSummOfMethodsWorkTimes(int Indexofthread)
        {
            if (this.Threads.IsEmpty || !this.Threads.Keys.Contains(Indexofthread))
            {
                return -1;
            }

            double result = 0;
            ThreadTraceResult Threadtraceresult = this.Threads[Indexofthread];

            foreach (MethodTraceResult method in Threadtraceresult.RootMethods)
            {
                result += Math.Round(method.WorkTime + GetSummOfInnerMethodsWorkTimes(method.Methods));
            }

            return (int)Math.Truncate(result);

        }

        private double GetSummOfInnerMethodsWorkTimes(List<MethodTraceResult> Methods)
        {
            if (Methods == null)
            {
                return 0;
            }

            double sum = 0;

            foreach (MethodTraceResult method in Methods)
            {
                sum += Math.Round(method.WorkTime + GetSummOfInnerMethodsWorkTimes(method.Methods));
            }

            return sum;
        }
    }
}
