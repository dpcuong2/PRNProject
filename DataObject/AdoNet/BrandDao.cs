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
    class BrandDao : IBrandDao
    {
        
        public DataTable getBrands()
        {
            string sql = "dbo.GetAllBrandsList";
            SqlConnection conn = new SqlConnection();
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

        public Brand GetBrandByProduct(int productId)
        {
            Brand brand = null;
            string sql = "dbo.GetBrandByProduct";
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            
            // truyen value
            cmd.Parameters.AddWithValue("@productId" , productId);
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    String BrandName = dr["name"].ToString();
                    String BrandId = dr["brandID"].ToString();
                    brand = new Brand
                    {
                       Name = BrandName,
                       BrandId = BrandId,
                    };
                }
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return brand;
        }

       

        public bool UpdateBrand(Brand b)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.UpdateBrand";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen value
            cmd.Parameters.AddWithValue("@brandID" , b.BrandId);
            cmd.Parameters.AddWithValue("@name", b.Name);
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

        public bool AddBrand(Brand b)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.AddBrand";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen value
            cmd.Parameters.AddWithValue("@brandID", b.BrandId);
            cmd.Parameters.AddWithValue("@name", b.Name);
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

        public bool DeleteBrand(Brand b)
        {
            bool result = false;
            SqlConnection conn = new SqlConnection();
            string sql = "dbo.DeleteBranch";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //truyen value
            cmd.Parameters.AddWithValue("@brandID", b.BrandId);
            cmd.Parameters.AddWithValue("@name", b.Name);
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
