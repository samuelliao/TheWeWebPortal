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

        public DataSet GetDataFromTable(string instance, string tableName, string condition)
        {
                if (string.IsNullOrEmpty(tableName)) return null;
                string sqlTxt = "Select "
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
                return null;
            }
        }

        public bool InsertDataInToTable(string tableName, string instanceStr, string valueStr)
        {
                if (string.IsNullOrEmpty(tableName) 
                    || string.IsNullOrEmpty(instanceStr)
                    ||string.IsNullOrEmpty(valueStr))
                    return false;
                string sqlTxt = "Insert into " + tableName
                    + " ( " + instanceStr + " ) " // Insert instance
                    + "values ( " + valueStr + " )"; // Isert value
                return ModifyDataInTable(sqlTxt);
        }

        public bool ModifyDataInTable(string sqlTxt)
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
                return false;
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
                return ModifyDataInTable(sqlTxt);
        }

    }
}
