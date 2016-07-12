using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class ConsultationDAO
    {
        DbConn DbConnection;
        Utility Util;
        public ConsultationDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public Dictionary<string, ConsultationObj> GetAllConsultation()
        {
            try
            {
                string sqlTxt = "Select * From Consultation";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConsultationObj>();
                return DataSetConverter(ds);
            }catch(Exception ex)
            {
                // Output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, ConsultationObj>();
            }
        }

        public Dictionary<string, ConsultationObj> GetConsultationByStore(string storeId)
        {
            try
            {
                if (string.IsNullOrEmpty(storeId)) return new Dictionary<string, ConsultationObj>(); 
                string sqlTxt = "Select * From Consultation  Where StoreId like '%"+storeId+"%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConsultationObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, ConsultationObj>();
            }
        }

        public Dictionary<string, ConsultationObj> GetConsultationByEmployee(string employeeId)
        {
            try
            {
                if (string.IsNullOrEmpty(employeeId)) return new Dictionary<string, ConsultationObj>();
                string sqlTxt = "Select * From Consultation  Where   like '%"+employeeId+"%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConsultationObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, ConsultationObj>();
            }
        }

        private Dictionary<string, ConsultationObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ConsultationObj>();
                Dictionary<string, ConsultationObj> lst = new Dictionary<string, ConsultationObj>();
                ConsultationObj obj = new ConsultationObj();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new ConsultationObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }
            catch(Exception ex)
            {
                // Output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, ConsultationObj>();
            }
        }
    }
}
