using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chapter02.Models
{
    public class CustomerDataOperation:IDataOperation<Customer>
    {
        private string _path = Environment.CurrentDirectory;
        private string _connectionstring = @"";
        public IEnumerable<Customer> Get()
        {
            throw new NotImplementedException();
        }

        public void Create(Customer Item)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer Item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Customer Item)
        {
            throw new NotImplementedException();
        }
    }
}