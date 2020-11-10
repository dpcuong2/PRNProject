using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObject;

namespace DataObject.AdoNet
{
    class CustomerDao:ICustomerDao
    {
        


        public Customer GetCustomer(string customerId)
        {
            Customer customer = null;
            string sql = "dbo.GetCustomers";
            SqlConnection conn = new SqlConnection();
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
                    customer = new Customer
                    {
                        CustomerID = customerID,
                        Name = name,
                        Phone = phone

                    };

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return customer;
        }

        public bool AddCustomer(Customer c)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.AddCustomer";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //truyen value
            cmd.Parameters.AddWithValue("@Name", c.Name);
            cmd.Parameters.AddWithValue("@Phone", c.Phone);
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
