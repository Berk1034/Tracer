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
    }
}
