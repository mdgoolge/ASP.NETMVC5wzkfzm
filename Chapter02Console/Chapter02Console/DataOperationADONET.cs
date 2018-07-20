using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02Console
{
    public class DataOperationADONET
    {
        static string _path = Environment.CurrentDirectory;
        static string _connectionstring = @"server=(localdb)\v11.0;  integrated security=true;AttachDbFileName=" + Environment.CurrentDirectory +
                                        @"\data\northwnd.mdf;";
        public static void FillDataSet(DataSet ds)
        {
            SqlConnection connection = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Orders");
            cmd.Connection = connection;
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.TableName = "Orders";
            ad.Fill(dt);
            ds.Tables.Add(dt);

            cmd = new SqlCommand("SELECT * FROM Products");
            ad.SelectCommand = cmd;
            dt = new DataTable();
            dt.TableName = "Products";
            ad.Fill(dt);
            ds.Tables.Add(dt);
        }

        public static void test1()
        {
            DataSet ds = new DataSet();
            ds.Locale = CultureInfo.InvariantCulture;
            FillDataSet(ds);

            DataTable orders = ds.Tables["Orders"];

            IEnumerable<DataRow> query =
                from order in orders.AsEnumerable()
                where order.Field<DateTime>("OrderDate") > new DateTime(1995, 8, 1)
                select order;

            DataTable boundTable = query.CopyToDataTable<DataRow>();

            foreach (DataRow row in boundTable.Rows)
            {
                string str = "";
                foreach (DataColumn col in boundTable.Columns)
                {
                    str += row[col.ColumnName].ToString();
                    str += ",";
                }

                Console.WriteLine(str);
            }

        }
        public static void test2()
        {
            SqlConnection connection = new SqlConnection(_connectionstring);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Products");
            cmd.Connection = connection;
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = cmd;

            DataTable dt = new DataTable();
            ad.Fill(dt);

            var query =
                   from product in dt.AsEnumerable()
                   where product.Field<int>("CategoryID") == 2
                   select new
               {
                   ProductName = product.Field<string>("ProductName"),
                   QuantityPerUnit = product.Field<string>("QuantityPerUnit"),
                   Price = product.Field<decimal>("UnitPrice")
               };


            foreach (var item in query)
            {
                Console.WriteLine("Name:{0},QuantityPerUnit:{0},Price:{0}", item.ProductName, item.QuantityPerUnit, item.Price);
            }

        }
    }
}
