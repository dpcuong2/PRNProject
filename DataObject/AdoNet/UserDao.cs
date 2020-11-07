using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObject.AdoNet
{
    class UserDao
    {
        public bool CheckLogin(string userID, string password)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            //truyen value
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                result = (bool) cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}
