using NLog;
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
        private Logger Log;
        private const string KeyOpenString = "OPEN SYMMETRIC KEY RM_SY DECRYPTION BY PASSWORD = 'CheesWedding';";

        public DbConn(string str)
        {
            if (Log == null)
            {
                Log = NLog.LogManager.GetCurrentClassLogger();
            }
            this.ConnStr = str;
            SqlConn = new SqlConnection(this.ConnStr);
        }

        public DbConn() {
            if (Log == null)
            {
                Log = NLog.LogManager.GetCurrentClassLogger();
            }
        }

        public DataSet GetDataSet(string sqlStr)
        {
            try
            {
                SqlConn.Open();
                //SqlDataAdapter da = new SqlDataAdapter(KeyOpenString + sqlStr, SqlConn);
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, SqlConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;                
            }
            catch(Exception ex)
            {
                // Output log here.
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
        }

        public bool ExecSqlText(string sqlStr)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConn.Open();
                //SqlCommand cmd = new SqlCommand(KeyOpenString + sqlStr, SqlConn);
                SqlCommand cmd = new SqlCommand(sqlStr, SqlConn);
                int result = cmd.ExecuteNonQuery();
                return result != 0;                
            }
            catch(Exception ex)
            {
                // Output log.
                Log.Error(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlConn.State == ConnectionState.Open) SqlConn.Close();
            }
        }
    }
}
