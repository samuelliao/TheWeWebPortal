using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class ConferenceItemDAO
    {
        DbConn DbConnection;
        Utility Util;

        public ConferenceItemDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public Dictionary<string, ConferenceItemObj> GetAllConferenceItem()
        {
            try {
                string sqlTxt = "Select * From ConferenceItem";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConferenceItemObj>();
                return DataSetConverter(ds);
            } catch(Exception ex)
            {
                // Output log
                return new Dictionary<string, ConferenceItemObj>();
            }
        }

        public Dictionary<string, ConferenceItemObj> GetConferenceItemByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name)) return new Dictionary<string, ConferenceItemObj>();
                string sqlTxt = "Select * From ConferenceItem Where Name like '%" + name + "%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConferenceItemObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, ConferenceItemObj>();
            }
        }

        public Dictionary<string, ConferenceItemObj> GetConferenceItemByLv(int lv)
        {
            try
            {
                string sqlTxt = "Select * From ConferenceItem Where ConferenceLv = "+lv;
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConferenceItemObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, ConferenceItemObj>();
            }
        }

        public ConferenceItemObj GetConferenceItemById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return new ConferenceItemObj();
                string sqlTxt = "Select * From ConferenceItem Where Id = '"+id+"'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new ConferenceItemObj();
                return new ConferenceItemObj(ds.Tables[0].Rows[0]);
            }catch(Exception ex)
            {
                // Output log
                return new ConferenceItemObj();
            }
        }

        public bool InsertConferenceItem(ConferenceItemObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[ConferenceItem]"
                    + "([Name],[Description],[ConferenceLv])VALUES("
                    + "N'" + obj.Name + "'"
                    + ",N'" + obj.Description + "'"
                    + "," + obj.ConferenceLv + ")";
                return DbConnection.ExecSqlText(sqlTxt);
            }catch(Exception ex)
            {
                // Output log
                return false;
            }
        }

        public bool UpdateConferenceItem(ConferenceItemObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[ConferenceItem]"
                    + " SET [Name] = N'" + obj.Name + "'"
                    + ",[Description] = N'" + obj.Description + "'"
                    + ",[ConferenceLv] = '" + obj.ConferenceLv + "'"
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log
                return false;
            }
        }

        private Dictionary<string, ConferenceItemObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConferenceItemObj>();
                Dictionary<string, ConferenceItemObj> lst = new Dictionary<string, ConferenceItemObj>();
                ConferenceItemObj obj = new ConferenceItemObj();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new ConferenceItemObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }catch(Exception ex)
            { // Output log
                return new Dictionary<string, ConferenceItemObj>();
            }
        }
    }
}
