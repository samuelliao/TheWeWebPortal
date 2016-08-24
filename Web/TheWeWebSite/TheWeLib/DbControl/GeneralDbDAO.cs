using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class GeneralDbDAO
    {
        DbConn DbConnection;
        Utility Util;

        public GeneralDbDAO()
        {
            Util = new Utility();
            DbConnection = new DbConn(SysProperty.DbConcString);
        }
        public GeneralDbDAO(string dbConn)
        {
            Util = new Utility();
            DbConnection = new DbConn(dbConn);
        }

        public DataSet GetDataFromTable(string instance, string tableName, string condition)
        {
            if (string.IsNullOrEmpty(tableName)) return null;
            string sqlTxt = "Select "
                + (string.IsNullOrEmpty(instance) ? "*" : instance)
                + " From " + tableName
                + condition;
            return GetDataFromTable(sqlTxt);
        }

        public DataSet GetTopDataFromTable(string instance, string tableName, string condition)
        {
            if (string.IsNullOrEmpty(tableName)) return null;
            string sqlTxt = "Select top 1"
                + (string.IsNullOrEmpty(instance) ? "*" : instance)
                + " From " + tableName
                + condition;
            return GetDataFromTable(sqlTxt);
        }



        public DataSet GetDataFromTable(string sqlTxt)
        {
            try
            {
                if (string.IsNullOrEmpty(sqlTxt)) return null;
                return DbConnection.GetDataSet(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                throw ex;
            }
        }

        public bool InsertDataInToTable(string tableName, string instanceStr, string valueStr)
        {
            if (string.IsNullOrEmpty(tableName)
                || string.IsNullOrEmpty(instanceStr)
                || string.IsNullOrEmpty(valueStr))
                return false;
            string sqlTxt = "Insert into " + tableName
                + " ( " + instanceStr + " ) " // Insert instance
                + "values ( " + valueStr + " )"; // Isert value
            return ModifyDataInToTable(sqlTxt);
        }

        public bool ModifyDataInToTable(string sqlTxt)
        {
            try
            {
                if (string.IsNullOrEmpty(sqlTxt))
                    return false;
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                throw ex;
            }
        }

        public bool UpdateDataIntoTable(string tableName, string valueStr, string condStr)
        {
            if (string.IsNullOrEmpty(tableName)
                || string.IsNullOrEmpty(valueStr))
                return false;
            string sqlTxt = "Update " + tableName
                + " Set " + valueStr  // Set value
                + " " + condStr; // Where string
            return ModifyDataInToTable(sqlTxt);
        }

        public bool IsAccountDuplicate(string account, string storeId)
        {
            if (string.IsNullOrEmpty(account))
                return false;
            string sql = "Select Account From Employee Where Account ='" + account + "' And StoreId = '" + storeId + "'";
            try
            {
                DataSet ds = GetDataFromTable(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    return true;
                else return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
