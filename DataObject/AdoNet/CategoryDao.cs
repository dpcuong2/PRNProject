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
    class CategoryDao : ICategoryDao
    {
        static Db db = new Db();

        public DataTable GetCategories()
        {
            string sql ="";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
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

        public Category GetCategoryByProduct(int productId)
        {
            Category category = null;
            string sql ="";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            // truyen value
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                if (dr.Read())
                {
                    String CategoryName = dr["categoryName"].ToString();
                    String CategoryID = dr["categoryID"].ToString();
                    category = new Category
                    {
                        CategoryId = CategoryID,
                        CategoryName = CategoryName,
                    };
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

    }
}
