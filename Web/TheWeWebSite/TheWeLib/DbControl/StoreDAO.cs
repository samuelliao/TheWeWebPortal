using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class StoreDAO
    {
        DbConn DbConnection;
        Utility Util;

        public StoreDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public StoreObj GetStoreById(string id)
        {
            try
            {
                StoreObj obj = new StoreObj();
                if (string.IsNullOrEmpty(SysProperty.DbConcString)) return obj;
                string sqlText = "Select * From Store Where Id = '" + id + "'";
                DataSet ds = DbConnection.GetDataSet(sqlText);
                if (Util.IsDataSetEmpty(ds)) return obj;
                return new StoreObj(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return new StoreObj();
            }
        }

        public Dictionary<string, StoreObj> GetAllStore()
        {
            try
            {
                if (string.IsNullOrEmpty(SysProperty.DbConcString))
                    return new Dictionary<string, StoreObj>();
                string sqlText = "Select * From Store";
                DataSet set = DbConnection.GetDataSet(sqlText);
                return DataSetConvert(set);
            }
            catch (Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, StoreObj>();
            }
        }

        public Dictionary<string, StoreObj> GetStoreByLocation(string countryId, string areaId)
        {
            try
            {
                string sqlText = "Select * From Store";
                string whereStr = string.Empty; ;
                if (!string.IsNullOrEmpty(countryId))
                {
                    whereStr += " Where CountryId = '" + countryId + "'";
                }
                if (!string.IsNullOrEmpty(areaId))
                {
                    if (string.IsNullOrEmpty(whereStr)) whereStr += " Where ";
                    else whereStr += ", ";
                    whereStr += "AreaId = '" + areaId + "'";
                }
                sqlText += whereStr;
                DataSet set = DbConnection.GetDataSet(sqlText);
                return DataSetConvert(set);
            }
            catch (Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, StoreObj>();
            }
        }

        public bool UpdateStore(StoreObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[Store]"
                    + " SET [Sn] = '" + obj.Sn + "'"
                    + ",[CountryId] = '" + obj.CountryId + "'"
                    + ",[AreaId] = '" + obj.AreaId + "'"
                    + ",[ChName] = N'" + obj.ChName + "'"
                    + ",[EngName] = '" + obj.EngName + "'"
                    + ",[Addr] = '" + obj.Addr + "'"
                    + ",[Descirption] = N'" + obj.Description + "'"
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return false;
            }
        }

        public bool InsertStore(StoreObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[Store]"
                    + "([Sn],[CountryId],[AreaId],[ChName],[EngName]"
                    + ",[Addr],[Descirption])VALUES("
                    + "'" + obj.Sn + "'"
                    + ",'" + obj.CountryId + "'"
                    + ",'" + obj.AreaId + "'"
                    + ",N'" + obj.ChName + "'"
                    + ",'" + obj.EngName + "'"
                    + ",'" + obj.Addr + "'"
                    + ",N'" + obj.Description + "')";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return false;
            }
        }

        private Dictionary<string, StoreObj> DataSetConvert(DataSet ds)
        {
            if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, StoreObj>();
            StoreObj obj = new StoreObj();
            Dictionary<string, StoreObj> lst = new Dictionary<string, StoreObj>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                obj = new StoreObj(dr);
                if (!string.IsNullOrEmpty(obj.Id))
                {
                    lst.Add(obj.Id, obj);
                }
            }
            return lst;
        }
    }
}
