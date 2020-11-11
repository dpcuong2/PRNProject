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
    public class ProductDao : IProductDao
    {
        string connectionString;

        public ProductDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        }

        public bool AddProduct(Product p)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "insert into tblProduct " +
                "(productID , name , quantity , weight , categoryID , brandID , price) " +
                "values (@ID , @Name , @Quantity, @Weight , @categoryID , @brandID , @price)";
            SqlCommand cmd = new SqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@ID", p.ProductID);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);
            cmd.Parameters.AddWithValue("@categoryID", p.CategoryID);
            cmd.Parameters.AddWithValue("@brandID", p.BrandID);
            cmd.Parameters.AddWithValue("@price", p.Price);





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

        public bool DeleteProduct(Product p)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "delete from tblProduct " +
                "where productID = @ProductID";
            SqlCommand cmd = new SqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
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

        public Product GetProduct(string productId)
        {
            Product product = null;
            string sql = "dbo.GetProduct";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            // truyen value
            cmd.Parameters.AddWithValue("@ProductId" , productId);

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    string name = dr.GetString(0);
                    int quantity = dr.GetInt32(1);
                    float weight = dr.GetFloat(2);
                    string categoryId = dr.GetString(3);
                    string brandId = dr.GetString(4);
                    float price = dr.GetFloat(5);
                    product = new Product
                    {
                        ProductID = productId,
                        Name = name,
                        Weight = weight,
                        CategoryID = categoryId,
                        BrandID = brandId,
                        Price = price
                    };
                    

                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public DataTable GetProductsByBrand(string brand)
        {
            string sql = "dbo.GetProductsByBrand";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@brandName", brand);
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

        public DataTable GetProductsByCategory(string category)
        {
            string sql = "dbo.GetProductsByCategory";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@categoryName", category);
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

        public DataTable GetProductsByName(string name)
        {
            string sql = "dbo.GetProductsByName";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", name);
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

        public bool UpdateProduct(Product p)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "update tblProduct " +
                "set  name = @Name, quantity = @Quantity, weight = @Weight , categoryID = @categoryID , brandID =@brandID , price = @price" +
                "where productID = @ID ,";
            SqlCommand cmd = new SqlCommand(sql, conn);


            cmd.Parameters.AddWithValue("@ID", p.ProductID);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
            cmd.Parameters.AddWithValue("@Weight", p.Weight);
            cmd.Parameters.AddWithValue("@categoryID", p.CategoryID);
            cmd.Parameters.AddWithValue("@brandID", p.BrandID);
            cmd.Parameters.AddWithValue("@price", p.Price);
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
