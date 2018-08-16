using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyModel model = new MyModel())
            {

                model.Database.CreateIfNotExists();
            }
        }
    }
}
