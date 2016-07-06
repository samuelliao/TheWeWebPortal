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

        public DbConn(string str)
        {
            this.ConnStr = str;
            SqlConn = new SqlConnection();
        }

        public DbConn() { }

        public DataSet GetDataSet(string sqlStr)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sqlStr, SqlConn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;                
            }
            catch(Exception ex)
            {
                // Output log here.
                return null;
            }
        }
    }
}
