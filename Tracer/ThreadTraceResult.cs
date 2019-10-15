using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace Tracer
{
    public class ThreadTraceResult
    {

        public uint Id { get; set; }

        public List<MethodTraceResult> Methods { get; set; }

        public ThreadTraceResult(uint id)
            : this()
        {
            Id = id;
        }

        private ThreadTraceResult()
        {
            Methods = new List<MethodTraceResult>();
            Id = uint.MaxValue;
        }
        
        public static bool IsExist(int threadId, ConcurrentDictionary<int, ThreadTraceResult> threads)
        {
            foreach (KeyValuePair<int, ThreadTraceResult> thread in threads)
            {
                if (threadId == thread.Key)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
