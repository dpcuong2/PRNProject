using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject.AdoNet
{
    public class OrderDao:IOrderDao
    {
        string connectionString;

        public OrderDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        }

        public bool CreateOrder(Order o)
        {
            bool result = false;
            
            string sql = "dbo.AddOrder";
            SqlConnection conn = new SqlConnection(connectionString);
            
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen value
            cmd.Parameters.AddWithValue("@customerId" , o.CustomerID);
            cmd.Parameters.AddWithValue("@Date" , o.Date);
            cmd.Parameters.AddWithValue("@Price" , o.TotalPrice);
            cmd.Parameters.AddWithValue("@Discount" , o.Discount);
            cmd.Parameters.AddWithValue("@Address" , o.Address);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }  

        public DataTable GetOrderList()
        {
            string sql = "dbo.GetOrdersList";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        public Order GetOrder(int orderId)
        {
            Order order = null;
            string sql = "dbo.GetOrderById";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int customerID = dr.GetInt32(1);
                    string name = dr.GetString(2);
                    string phone = dr.GetString(3);
                    

                }
                return order;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public bool DeleteOrder(Order o)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.DeleteOrder";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen value
            cmd.Parameters.AddWithValue("@OrderID", o.OrderID);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool UpdateOrder(Order o)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.UpdateOrder";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen value
            cmd.Parameters.AddWithValue("@OrderID" , o.OrderID);
            cmd.Parameters.AddWithValue("@CustomerId", o.CustomerID);
            cmd.Parameters.AddWithValue("@Date", o.Date);
            cmd.Parameters.AddWithValue("@Price", o.TotalPrice);
            cmd.Parameters.AddWithValue("@Discount", o.Discount);
            cmd.Parameters.AddWithValue("@Address", o.Address);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = cmd.ExecuteNonQuery() > 0;
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
