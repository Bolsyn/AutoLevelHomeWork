using System;
using System.Data;
using System.Data.SqlClient;

namespace AutoLevelHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("ShopDb");

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from People", "Server = DESKTOP-9EP80DV; DataBase = ShopDb; Trusted_Connection = True;");

            adapter.Fill(dataSet);

            DataTable Orders = dataSet.Tables[0];
            DataColumn column1 = Orders.Columns.Add("Id", typeof(int));
            DataColumn column2 = Orders.Columns.Add("Name of order", typeof(string));

            Orders.Constraints.Add(new UniqueConstraint(column1, false));

            Console.WriteLine("is unique: " + Orders.Columns[0].Unique);
            Console.WriteLine("Primary key columns count: " + Orders.PrimaryKey.Length);

            if (Orders.PrimaryKey.Length != 0)
                Console.WriteLine("Primary key column name: " + Orders.PrimaryKey[0].ColumnName);
            else
                Console.WriteLine("Primary key column name: No data");
            DataRow newRow = Orders.NewRow();
            int lastIndexOrders = Orders.Rows[Orders.Rows.Count - 1].Field<int>(0);

            newRow.ItemArray = new object[] { ++lastIndexOrders, "First" };

            Orders.Rows.Add(newRow);

            DataTable Customers = dataSet.Tables[1];
            column1 = Customers.Columns.Add("Id", typeof(int));
            column2 = Customers.Columns.Add("Name", typeof(string));

            Customers.Constraints.Add(new UniqueConstraint(column1, false));

            Console.WriteLine("is unique: " + Customers.Columns[0].Unique);
            Console.WriteLine("Primary key columns count: " + Customers.PrimaryKey.Length);

            if (Customers.PrimaryKey.Length != 0)
                Console.WriteLine("Primary key column name: " + Customers.PrimaryKey[0].ColumnName);
            else
                Console.WriteLine("Primary key column name: No data");
            newRow = Customers.NewRow();
            int lastIndexCustomers = Customers.Rows[Customers.Rows.Count - 1].Field<int>(0);

            newRow.ItemArray = new object[] { ++lastIndexCustomers, "Ivan" };

            Customers.Rows.Add(newRow);

            DataTable Employees = dataSet.Tables[2];
            newRow = Customers.NewRow();
            int lastIndexEmployees = Employees.Rows[Employees.Rows.Count - 1].Field<int>(0);

            newRow.ItemArray = new object[] { ++lastIndexEmployees, "Leonid" };

            Employees.Rows.Add(newRow);

            DataTable OrderDetails = dataSet.Tables[3];
            newRow = Customers.NewRow();
            int lastIndexOrderDetails = OrderDetails.Rows[OrderDetails.Rows.Count - 1].Field<int>(0);

            newRow.ItemArray = new object[] { ++lastIndexOrderDetails, "150" };

            OrderDetails.Rows.Add(newRow);

            DataTable Products = dataSet.Tables[4];
            newRow = Customers.NewRow();
            int lastIndexProducts = Products.Rows[Products.Rows.Count - 1].Field<int>(0);

            newRow.ItemArray = new object[] { ++lastIndexProducts, "Bread" };

            Products.Rows.Add(newRow);

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);
            dataSet.AcceptChanges();
        }
    }
}
