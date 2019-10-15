using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class ConsoleTraceResultWriter : IResultWriter
    {
        public void WriteResult(string result)
        {
            System.Console.WriteLine(result);
        }
    }
}
