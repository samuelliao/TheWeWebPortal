using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class AreaDAO
    {
        DbConn DbConnection;
        Utility Util;
        public AreaDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public Dictionary<string, AreaObj> GetAllArea()
        {
            try
            {
                string sqlTxt = "Select * From Area";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, AreaObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, AreaObj>();
            }
        }

        public AreaObj GetAreaById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return new AreaObj();
                string sqlTxt = "Select * From Area Where Id = '" + id + "'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new AreaObj();
                return new AreaObj(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                // Output log.
                return new AreaObj();
            }
        }

        public Dictionary<string, AreaObj> GetAreaByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return new Dictionary<string, AreaObj>();
                string sqlTxt = "Select * From Area Where ChName like '%" + name + "%' OR EngName like '%" + name + "%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, AreaObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, AreaObj>();
            }
        }

        public Dictionary<string, AreaObj> GetAreaByCode(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code)) return new Dictionary<string, AreaObj>();
                string sqlTxt = "Select * From Area Where Code like '%" + code + "%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, AreaObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, AreaObj>();
            }
        }

        public Dictionary<string, AreaObj> GetAreaByCountry(string countryId)
        {
            try
            {
                if (string.IsNullOrEmpty(countryId)) return new Dictionary<string, AreaObj>();
                string sqlTxt = "Select * From Area Where CountryId = '" + countryId + "'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, AreaObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, AreaObj>();
            }
        }

        public bool UpdateArea(AreaObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[Area]"
                    + " SET [ChName] = N'" + obj.ChName + "'"
                    + ",[EngName] = '" + obj.EngName + "'"
                    + ",[Code] = '" + obj.Code + "'"
                    + ",[CountryId] = '" + obj.CountryId + "'"
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                return false;
            }
        }

        public bool InsertArea(AreaObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[Area]"
                    + "([ChName],[EngName],[Code],[CountryId])VALUES("
                    + "N'" + obj.ChName + "'"
                    + ",'" + obj.EngName + "'"
                    + ",'" + obj.Code + "'"
                    + ",'" + obj.CountryId + "')";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log.
                return false;
            }
        }

        public Dictionary<string, AreaObj> DataSetConverter(DataSet set)
        {
            try
            {
                if (Util.IsDataSetEmpty(set)) return new Dictionary<string, AreaObj>();
                Dictionary<string, AreaObj> lst = new Dictionary<string, AreaObj>();
                AreaObj obj = new AreaObj();
                foreach (DataRow dr in set.Tables[0].Rows)
                {
                    obj = new AreaObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                // Output log.
                return new Dictionary<string, AreaObj>();
            }
        }
    }
}
