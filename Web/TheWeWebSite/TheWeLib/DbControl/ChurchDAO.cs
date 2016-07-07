using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class ChurchDAO
    {
        DbConn DbConnection;
        Utility Util;

        public ChurchDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public Dictionary<string, ChurchObj> GetAllChurch()
        {
            try
            {
                string sqlTxt = "Select * From Church";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ChurchObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Ouput log
                return new Dictionary<string, ChurchObj>();
            }
        }

        public Dictionary<string, ChurchObj> GetChurchByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return new Dictionary<string, ChurchObj>();
                string sqlTxt = "Select * From Church Where ChName like N'%" + name + "%'"
                    + " OR EngName like N'%" + name + "%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ChurchObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Ouput log
                return new Dictionary<string, ChurchObj>();
            }
        }

        public Dictionary<string, ChurchObj> GetChurchByLocation(string countryId, string AreaId)
        {
            try
            {
                string sqlTxt = "Select * From Church";

                string whereStr = string.Empty;
                if (!string.IsNullOrEmpty(countryId))
                {
                    if (string.IsNullOrEmpty(whereStr))
                        whereStr += " Where ";
                    else
                        whereStr = " OR ";

                    whereStr += "CountryId = '" + countryId + "'";
                }
                if (!string.IsNullOrEmpty(AreaId))
                {
                    if (string.IsNullOrEmpty(whereStr))
                        whereStr += " Where ";
                    else
                        whereStr += " OR ";

                    whereStr += "AreaId = '" + AreaId + "'";
                }

                DataSet ds = DbConnection.GetDataSet(sqlTxt + whereStr);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ChurchObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Ouput log
                return new Dictionary<string, ChurchObj>();
            }
        }


        public bool UpdateChurch(ChurchObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[Area]"
                    + " SET [ChName] = N'" + obj.ChName + "'"
                    + ",[EngName] = '" + obj.EngName + "'"
                    + ",[CountryId] = '" + obj.CountryId + "'"
                    + ",[AreaId] = '" + obj.AreaId + "'"
                    + ",[MealImg] = '" + obj.MealImg + "'"
                    + ",[MapImg] = '" + obj.MapImg + "'"
                    + ",[DmImg] = '" + obj.DmImg + "'"
                    + ",[PhotoImg] = '" + obj.PhotoImg + "'"
                    + ",[Capacities] = " + obj.Capacities
                    + ",[Price] = " + Decimal.Parse( obj.Price)
                    + ",[Remark] = N'" + obj.Remark + "'"
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                return false;
            }
        }

        public bool InsertChurch(ChurchObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[Church]"
                    + "([ChName],[EngName],[CountryId],[AreaId]"
                    + ",[MealImg],[MapImg],[DmImg],[PhotoImg]"
                    + ",[Capacities],[Price],[Remark])VALUES("
                    + "N'" + obj.ChName + "'"
                    + ",'" + obj.EngName + "'"
                    + ",'" + obj.CountryId + "'"
                    + ",'" + obj.AreaId + "'"
                    + ",'" + obj.MealImg + "'"
                    + ",'" + obj.MapImg + "'"
                    + ",'" + obj.DmImg + "'"
                    + ",'" + obj.PhotoImg + "'"
                    + "," + obj.Capacities
                    + "," + Decimal.Parse(obj.Price)
                    + ",N'" + obj.Remark + "')";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log.
                return false;
            }
        }

        public Dictionary<string, ChurchObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ChurchObj>();
                Dictionary<string, ChurchObj> lst = new Dictionary<string, ChurchObj>();
                ChurchObj obj = new ChurchObj();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new ChurchObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, ChurchObj>();
            }
        }
    }
}
