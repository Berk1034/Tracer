using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tracer
{
    class Program
    {
        public static void TestMe()
        {
            int z = 100;
            for (int i = 1; i < 100; i++)
            {
                z = z - i;
            }
        }

        static void Main(string[] args)
        {
            Tracer tracer = new Tracer();
            tracer.StartTrace();
            TestMe();
            Thread.Sleep(100);
            tracer.StopTrace();
            ConsoleTraceResultWriter rw = new ConsoleTraceResultWriter();
            /*
            XMLSerializer xml = new XMLSerializer();
            rw.WriteResult(xml.Serialize(tracer.GetTraceResult()));
            */
            JSONSerializer json = new JSONSerializer();
            rw.WriteResult(json.Serialize(tracer.GetTraceResult()));
            Console.ReadLine();
        }
    }
}
