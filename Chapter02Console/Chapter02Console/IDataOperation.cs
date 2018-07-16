﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02Console
{
    public interface IDataOperation<T>where   T:class,new() 
    {
        IEnumerable<T> Get();
        void Create(T Item);
        void Update(T Item);
        void Delete(T Item);
    }
}
