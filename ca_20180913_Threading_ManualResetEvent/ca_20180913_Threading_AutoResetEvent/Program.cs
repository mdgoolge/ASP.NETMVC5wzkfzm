using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ca_20180913_Threading_AutoResetEvent
{
    class Program
    {
        static AutoResetEvent ar = new AutoResetEvent(true);
        static void Main(string[] args)
        {
            Thread t = new Thread(Run);
            t.Start();

            bool state = ar.WaitOne(1000);
            Console.WriteLine("当前的信号量状态:{0}", state);

            state = ar.WaitOne(1000);
            Console.WriteLine("再次WaitOne后现在的状态是:{0}", state);

            state = ar.WaitOne(1000);
            Console.WriteLine("再次WaitOne后现在的状态是:{0}", state);

            Console.ReadKey();
        }
        static void Run()
        {
            Console.WriteLine("当前时间" + DateTime.Now.ToString("mm:ss"));
        }
    }
}
