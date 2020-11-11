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
    public class OrderDetailDao : IOrderDetailDao
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
            string sql = "dbo.CreateOrderDetail";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue("@date", od.Date);
            cmd.Parameters.AddWithValue("@totalPrice", od.ProductID);
            cmd.Parameters.AddWithValue("@Phone", od.Phone);
            cmd.Parameters.AddWithValue("@OrderId", od.OrderDetailID);
            cmd.Parameters.AddWithValue("@Quantity", od.Quantity);


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
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "dbo.CreateOrderDetail";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderDetail", orderID);
            


            

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

        public OrderDetail GetOrderDetail(int orderDetailId)
        {
            OrderDetail orderDetail = null;
            string sql = "dbo.GetOrderDetail";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // truyen value
            cmd.Parameters.AddWithValue("@OrderDetailId", orderDetailId);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string productId = dr.GetString(1);
                    DateTime date = dr.GetDateTime(2);
                    float totalPrice = dr.GetFloat(3);
                    string phone = dr.GetString(4);
                    int quantity = dr.GetInt32(5);
                    int orderID = dr.GetInt32(6);
                    orderDetail = new OrderDetail
                    {
                        OrderDetailID = orderDetailId,
                        Date = date,
                        TotalPrice = totalPrice,
                        Phone = phone,
                        Quantity = quantity,
                        OrderId = orderID
                    };

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
                string sql = "dbo.GetOrderDetails";
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
            cmd.Parameters.AddWithValue("@detailId",od.OrderDetailID);
            cmd.Parameters.AddWithValue("@date" , od.Date);
            cmd.Parameters.AddWithValue("@totalPrice", od.TotalPrice);
            cmd.Parameters.AddWithValue("@Phone", od.Phone);
            cmd.Parameters.AddWithValue("@Quantity", od.Quantity);
            


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
