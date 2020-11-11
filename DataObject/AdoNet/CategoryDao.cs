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
    public class CategoryDao : ICategoryDao
    {
        string connectionString;

        public CategoryDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        }

        public bool AddCategory(Category c)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "dbo.AddCategory";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", c.CategoryId);
            cmd.Parameters.AddWithValue("@Name", c.CategoryName);
            //truyen value
            
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
            return result;

        }

        

        public DataTable GetCategoryList()
        {
            string sql ="dbo.GetAllCategory";
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

        public Category GetCategoryByProduct(int productId)
        {
            Category category = null;
            string sql ="dbo.GetCategoryByProduct";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@productId" , productId);
            
            
            

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
                    string CategoryName = dr["categoryName"].ToString();
                    string CategoryID = dr["categoryID"].ToString();
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

        

        public bool UpdateCategory(Category c)
        {

            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "dbo.UpdateCategory";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", c.CategoryId);
            cmd.Parameters.AddWithValue("@Name", c.CategoryName);
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
