using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02Console
{
    public class Northwind
    {
        IDataOperation<Customer> customerOp = null;
        IDataOperation<Order> orderOp = null;

        public IDataOperation<Customer> Customers
        {
            get
            {
                if (customerOp == null)
                {
                    customerOp = new CustomerDataOperation();
                }
                return customerOp;
            }
        }
        public IDataOperation<Order> Orders
        {
            get
            {
                if (orderOp == null)
                {
                    orderOp = new OrderDataOperation();
                }
                return orderOp;
            }
        }
    }
}
