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
        public DataTable GetBrands()
        {
            string sql = "";
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

        public Brand GetBrandByProduct(int productId)
        {
            Brand brand = null;
            string sql = "";
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

        public DataTable getBrands()
        {
            throw new NotImplementedException();
        }

        public bool UpdateBrand()
        {
            throw new NotImplementedException();
        }

        public bool AddBrand()
        {
            throw new NotImplementedException();
        }

        public bool DeleteBrand()
        {
            throw new NotImplementedException();
        }
    }
}
