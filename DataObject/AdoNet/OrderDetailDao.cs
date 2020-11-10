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
    class OrderDetailDao : IOrderDetailDao
    {
        string connectionString;

        public OrderDetailDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        }
        public bool CreateOrderDetail(OrderDetail od)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //truyen value
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

        public bool DeleteOrderDetail(string orderID)
        {
            throw new NotImplementedException();
        }

        public OrderDetail GetOrderDetail()
        {
            OrderDetail orderDetail = null;
            string sql = "";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // truyen value
           

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public DataTable GetOrderDetails()
        {
            string sql = "";
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

        public bool UpdateOrderDetail(OrderDetail od)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
           // cmd.Parameters.AddWithValue();
           // cmd.Parameters.AddWithValue();
            //truyen value
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
