using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Chapter02Console
{
    public class DataOperationOrder : IDataOperation<Order>
    {
        private string _path = Environment.CurrentDirectory;
        private string _connectionstring = @"server=(localdb)\v11.0;  integrated security=true;AttachDbFileName=" + Environment.CurrentDirectory +
                                        @"\data\northwnd.mdf;";
        public IEnumerable<Order> Get()
        {
            IDbConnection connection =
                new SqlConnection(this._connectionstring);
            IDbCommand cmd = new SqlCommand("SELECT * FROM Orders");

            cmd.Connection = connection;
            connection.Open();

            IDataReader reader = cmd.ExecuteReader(
                CommandBehavior.CloseConnection | CommandBehavior.SingleResult);

            while (reader.Read())
            {
                Order order = new Order()
                {
                    OrderID = Convert.ToInt32(reader.GetValue(reader.GetOrdinal("OrderID"))),
                    OrderDate = (reader.GetValue(reader.GetOrdinal("OrderDate")) is System.DBNull) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("OrderDate"))),
                    EmployeeId = (reader.GetValue(reader.GetOrdinal("EmployeeId")) is System.DBNull) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("EmployeeId"))),
                    Freight = (reader.GetValue(reader.GetOrdinal("Freight")) is System.DBNull) ? new Nullable<double>() : Convert.ToDouble(reader.GetValue(reader.GetOrdinal("Freight"))),
                    RequiredDate = (reader.GetValue(reader.GetOrdinal("RequiredDate")) is System.DBNull) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("RequiredDate"))),
                    ShipAddress = reader.GetValue(reader.GetOrdinal("ShipAddress")).ToString(),
                    ShipCity = reader.GetValue(reader.GetOrdinal("ShipCity")).ToString(),
                    ShipCountry = reader.GetValue(reader.GetOrdinal("ShipCountry")).ToString(),
                    ShipName = reader.GetValue(reader.GetOrdinal("ShipName")).ToString(),
                    ShippedDate = (reader.GetValue(reader.GetOrdinal("ShippedDate")) is System.DBNull) ? new Nullable<DateTime>() : Convert.ToDateTime(reader.GetValue(reader.GetOrdinal("ShippedDate"))),
                    ShipPostalCode = reader.GetValue(reader.GetOrdinal("ShipPostalCode")).ToString(),
                    ShipRegion = reader.GetValue(reader.GetOrdinal("ShipRegion")).ToString(),
                    ShipVia = (reader.GetValue(reader.GetOrdinal("ShipVia")) is System.DBNull) ? new Nullable<int>() : Convert.ToInt32(reader.GetValue(reader.GetOrdinal("ShipVia")))

                };

                yield return order;
            }


            connection.Close();
        }

        public void Create(Order Item)
        {
            IDbConnection connection =
                 new SqlConnection(this._connectionstring);
            IDbCommand cmd = new SqlCommand(
                @"INSERT INTO Orders
                (   
OrderID,
CustomerID,
EmployeeID,
OrderDate,
RequiredDate,
ShippedDate,
ShipVia,
Freight,
ShipName,
ShipAdderss,
ShipCity,
ShipRegion,
ShipPostalCode,
ShipCountry
                )
                VALUES
                ( 
OrderID=@OrderID,
CustomerID=@CustomerID,
EmployeeID=@EmployeeID,
OrderDate=@OrderDate,
RequiredDate=@RequiredDate,
ShippedDate=@ShippedDate,
ShipVia=@ShipVia,
Freight=@Freight,
ShipName=@ShipName,
ShipAdderss=@ShipAdderss,
ShipCity=@ShipCity,
ShipRegion=@ShipRegion,
ShipPostalCode=@ShipPostalCode,
ShipCountry=@ShipCountry
                )"
                );

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@OrderID", Item.OrderID));
            cmd.Parameters.Add((Item.CustomerID == null) ? new SqlParameter("@CustomerID", DBNull.Value) : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add((Item.EmployeeId == null) ? new SqlParameter("@EmployeeId", DBNull.Value) : new SqlParameter("@EmployeeId", Item.EmployeeId));
            cmd.Parameters.Add((Item.OrderDate == null) ? new SqlParameter("@OrderDate", DBNull.Value) : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add((Item.RequiredDate == null) ? new SqlParameter("@RequiredDate", DBNull.Value) : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add((Item.ShippedDate == null) ? new SqlParameter("@ShippedDate", DBNull.Value) : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add((Item.ShipVia == null) ? new SqlParameter("@ShipVia", DBNull.Value) : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add((Item.Freight == null) ? new SqlParameter("@Freight", DBNull.Value) : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(new SqlParameter("@ShipCountry", Item.ShipCountry));

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(Order Item)
        {
            IDbConnection connection =
                 new SqlConnection(this._connectionstring);
            IDbCommand cmd = new SqlCommand(
                @"UPDATE  Orders SET

OrderID=@OrderID,
CustomerID=@CustomerID,
EmployeeID=@EmployeeID,
OrderDate=@OrderDate,
RequiredDate=@RequiredDate,
ShippedDate=@ShippedDate,
ShipVia=@ShipVia,
Freight=@Freight,
ShipName=@ShipName,
ShipAdderss=@ShipAdderss,
ShipCity=@ShipCity,
ShipRegion=@ShipRegion,
ShipPostalCode=@ShipPostalCode,
ShipCountry=@ShipCountry

                "
                );

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@OrderID", Item.OrderID));
            cmd.Parameters.Add((Item.CustomerID == null) ? new SqlParameter("@CustomerID", DBNull.Value) : new SqlParameter("@CustomerID", Item.CustomerID));
            cmd.Parameters.Add((Item.EmployeeId == null) ? new SqlParameter("@EmployeeId", DBNull.Value) : new SqlParameter("@EmployeeId", Item.EmployeeId));
            cmd.Parameters.Add((Item.OrderDate == null) ? new SqlParameter("@OrderDate", DBNull.Value) : new SqlParameter("@OrderDate", Item.OrderDate));
            cmd.Parameters.Add((Item.RequiredDate == null) ? new SqlParameter("@RequiredDate", DBNull.Value) : new SqlParameter("@RequiredDate", Item.RequiredDate));
            cmd.Parameters.Add((Item.ShippedDate == null) ? new SqlParameter("@ShippedDate", DBNull.Value) : new SqlParameter("@ShippedDate", Item.ShippedDate));
            cmd.Parameters.Add((Item.ShipVia == null) ? new SqlParameter("@ShipVia", DBNull.Value) : new SqlParameter("@ShipVia", Item.ShipVia));
            cmd.Parameters.Add((Item.Freight == null) ? new SqlParameter("@Freight", DBNull.Value) : new SqlParameter("@Freight", Item.Freight));
            cmd.Parameters.Add(new SqlParameter("@ShipName", Item.ShipName));
            cmd.Parameters.Add(new SqlParameter("@ShipAddress", Item.ShipAddress));
            cmd.Parameters.Add(new SqlParameter("@ShipCity", Item.ShipCity));
            cmd.Parameters.Add(new SqlParameter("@ShipRegion", Item.ShipRegion));
            cmd.Parameters.Add(new SqlParameter("@ShipPostalCode", Item.ShipPostalCode));
            cmd.Parameters.Add(new SqlParameter("@ShipCountry", Item.ShipCountry));

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }

        public void Delete(Order Item)
        {
            IDbConnection connection =
                 new SqlConnection(this._connectionstring);
            IDbCommand cmd = new SqlCommand(
                @"DELETE FROM   Orders 
                WHERE 

OrderID=@OrderID

                "
                );

            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlParameter("@OrderID", Item.OrderID));

            connection.Open();

            cmd.ExecuteNonQuery();

            connection.Close();
        }
    }
}