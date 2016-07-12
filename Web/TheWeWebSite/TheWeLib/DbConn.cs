using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TheWeLib
{
    public class DbConn
    {
        private string ConnStr;
        private SqlConnection SqlConn;
        private const string KeyOpenString = "OPEN SYMMETRIC KEY RM_SY DECRYPTION BY PASSWORD = 'CheesWedding';";

        public DbConn(string str)
        {
            this.ConnStr = str;
            SqlConn = new SqlConnection(this.ConnStr);
        }

        public DbConn() { }

        public DataSet GetDataSet(string sqlStr)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(KeyOpenString + sqlStr, SqlConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;                
            }
            catch(Exception ex)
            {
                // Output log here.
                SysProperty.Log.Error(ex.Message);
                return null;
            }
        }

        public bool ExecSqlText(string sqlStr)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConn.Open();
                SqlCommand cmd = new SqlCommand(KeyOpenString + sqlStr, SqlConn);
                int result = cmd.ExecuteNonQuery();
                return result == -1;                
            }
            catch(Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return false;
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
        }
    }
}
