using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class CountryDAO
    {
        DbConn DbConnection;
        public CountryDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
        }

        public CountryObj GetCountryById(string id)
        {
            try
            {
                string sqlTxt = "Select * From Country Where Id = '" + id + "'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (new Utility().IsDataSetEmpty(ds)) return new CountryObj();
                return new CountryObj(ds.Tables[0].Rows[0]);
            }catch(Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new CountryObj();
            }
        }

        public Dictionary<string, CountryObj> GeAllCountry()
        {
            try
            {
                string sqlTxt = "Select * From Country";
                DataSet set = DbConnection.GetDataSet(sqlTxt);
                if (new Utility().IsDataSetEmpty(set)) return new Dictionary<string, CountryObj>();
                return DataSetConverter(set);
            }catch(Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, CountryObj>();
            }
        }

        public Dictionary<string, CountryObj> GetCountryByCurrency(string currencyId)
        {
            try
            {
                string sqlTxt = "Select * From Country Where CurrencyId = '"+currencyId+"'";
                DataSet set = DbConnection.GetDataSet(sqlTxt);
                if (new Utility().IsDataSetEmpty(set)) return new Dictionary<string, CountryObj>();
                return DataSetConverter(set);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, CountryObj>();
            }
        }

        public Dictionary<string, CountryObj> GetCountryByCode(string code)
        {
            try
            {
                string sqlTxt = "Select * From Country Where Code like '%" + code + "%'";
                DataSet set = DbConnection.GetDataSet(sqlTxt);
                if (new Utility().IsDataSetEmpty(set)) return new Dictionary<string, CountryObj>();
                return DataSetConverter(set);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, CountryObj>();
            }
        }

        /// <summary>
        /// Search the country info by name(Eng. name or Ch. name)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Dictionary<string, CountryObj> GetCountryByName(string name)
        {
            try
            {
                string sqlTxt = "Select * From Country Where ChName like '%" + name + "%'"
                    + " or EngName like '%" + name + "%'";
                DataSet set = DbConnection.GetDataSet(sqlTxt);
                if (new Utility().IsDataSetEmpty(set)) return new Dictionary<string, CountryObj>();
                return DataSetConverter(set);
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, CountryObj>();
            }
        }

        public bool UpdateCountry(CountryObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[Country]"
                    + " SET [ChName] = N'" + obj.Name + "'"
                    + ",[EngName] = '" + obj.EngName + "'"
                    + ",[Code] = '" + obj.Code + "'"
                    + ",[CurrencyId] = '" + obj.CurrencyId + "'"
                    + ",[LangCode] = '" + obj.LangCode + "'"
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }catch(Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return false;
            }
        }

        public bool InsertCountry(CountryObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[Store]"
                    + "([ChName],[EngName],[Code],[CurrencyId],[LangCode])VALUES("
                    + "N'" + obj.Name + "'"
                    + ",'" + obj.EngName + "'"
                    + ",'" + obj.Code + "'"
                    + ",'" + obj.CurrencyId + "'"
                    + ",'" + obj.LangCode + "')";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log.
                SysProperty.Log.Error(ex.Message);
                return false;
            }
        }

        public Dictionary<string, CountryObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (new Utility().IsDataSetEmpty(ds)) return new Dictionary<string, CountryObj>();
                Dictionary<string, CountryObj> lst = new Dictionary<string, CountryObj>();
                CountryObj obj = new CountryObj();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new CountryObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }catch(Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, CountryObj>();
            }
        }
    }
}
