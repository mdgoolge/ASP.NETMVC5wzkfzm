using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogDb model = new BlogDb())
            {
                model.Database.CreateIfNotExists();
            }
        }
    }
}
