using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ca_20180913_Threading_ManualResetEvent
{
    class Program
    {
        //一开始设置为false才会等待收到信号才执行
        static ManualResetEvent mr = new ManualResetEvent(false);
        static void Main(string[] args)
        {
        }
    }
}
