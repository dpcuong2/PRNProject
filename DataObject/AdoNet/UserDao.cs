using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.AdoNet
{
    class UserDao:IUser
    {
        string connectionString;

        public UserDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        }
        public bool CheckLogin(string userID, string password)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", userID);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            //truyen value
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (dr.Read())
                {
                    result = dr.GetInt32(0) > 0;
                }
                
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        
    }
}
