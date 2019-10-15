using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TracerLibrary;
using System.Collections.Generic;
using System.Threading;

namespace TracerUnitTests
{
    public class A
    {
        private Tracer _tracer;
        private B _innerClassB;
        public A(Tracer tracer)
        {
            this._tracer = tracer;
            _innerClassB = new B(_tracer);
        }
        public void MethodA()
        {
            _tracer.StartTrace();

            _innerClassB.MethodBWithCycle();

            _tracer.StopTrace();
        }

        public void MultiThreadedFoo()
        {
            _tracer.StartTrace();
            B b = new B(_tracer);

            Thread thread1 = new Thread(() => { b.MethodBWithCycle(); });

            thread1.Start();
            _tracer.StopTrace();
        }
    }

    public class B
    {
        private Tracer _tracer;
        private List<int> TestInt;
        public B(Tracer tracer)
        {
            this._tracer = tracer;
            TestInt = new List<int>();
        }
        public void MethodBWithCycle()
        {
            _tracer.StartTrace();
            for (int i = 0; i < 1000; i++)
            {
                TestInt.Add(i * 4);
            }
            _tracer.StopTrace();
        }
    }

    [TestClass]
    public class TracerUnitTest1
    {
        [TestMethod]
        public void ShouldTraceOneThread()
        {
            Tracer tracer = new Tracer();
            A a = new A(tracer);
            a.MethodA();
            Assert.AreEqual(1, tracer.GetTraceResult().Threads.Count);
        }
    }
}
