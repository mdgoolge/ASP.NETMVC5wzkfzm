﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BlogDbModel model = new BlogDbModel())
            {
                model.Database.CreateIfNotExists();
            }
        }
    }
}
