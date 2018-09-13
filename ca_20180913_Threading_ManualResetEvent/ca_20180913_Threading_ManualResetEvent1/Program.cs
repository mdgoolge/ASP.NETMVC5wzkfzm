using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ca_20180913_Threading_ManualResetEvent1
{
    class Program
    {
        //一开始设置为false才会等待收到信号才执行
        static ManualResetEvent mr = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Thread t = new Thread(Run);
            Console.WriteLine("开始" + DateTime.Now.ToString("mm:ss"));
            t.Start();
            mr.WaitOne();
            Console.WriteLine("第一次等待完成!" + DateTime.Now.ToString("mm:ss"));
            mr.Reset();     //重置后，又能WaitOne()啦,  如果不使用Reset，则直接输出第二次等待完成，而不会等待2秒。
            mr.WaitOne(3000);
            Console.WriteLine("第二次等待完成!" + DateTime.Now.ToString("mm:ss"));
            Console.ReadKey();
        }
        static void Run()
        {
            //模拟长时间任务
            Thread.Sleep(3000);
            Console.WriteLine("辅助线程长时间任务完成！" + DateTime.Now.ToString("mm:ss"));
            mr.Set();
        }
    }
}
