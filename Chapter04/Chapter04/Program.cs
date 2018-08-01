using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {

            //using (northwndEntities context=new northwndEntities())
            //{
            //    var query = from item in context.Alphabetical_list_of_products
            //                select new
            //                {
            //                    a = item.CategoryName,
            //                    b = item.ProductName,
            //                    c = item.QuantityPerUnit
            //                };

            //    foreach (var item in query )
            //    {
            //        Console.WriteLine(
            //            "a={0},b={1},c={2}",item.a,item.b,item.c);
            //    }
            //}

            decimal totalDue = 500.00M;
            using (AdventureWorks2012Entities  context = new AdventureWorks2012Entities())
            {
                DbSet<ContactType> contacts = context.ContactType;
                DbSet<SalesOrderHeader> orders = context.SalesOrderHeader;

                //var query=
                //    from  contact in contacts
                //    from  order in orders
                //    where contact.ContactTypeID==orde

            }
        }
    }
}
