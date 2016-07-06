using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class EmployeeDAO
    {
        DbConn DbConnection;
        Utility Util;
        public EmployeeDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public EmployeeObj GetEmployeeById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return new EmployeeObj();
                string sqlTxt = "Select * From Employee Where Id = '"+id+"'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new EmployeeObj();
                return new EmployeeObj(ds.Tables[0].Rows[0]);
            }catch(Exception ex)
            {
                // Output log
                return new EmployeeObj();
            }
        }

        public Dictionary<string, EmployeeObj> GetAllEmployee()
        {
            try
            {
                string sqlTxt = "Select * From vwEN_Employee";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                return DataSetConverter(ds);
            }
            catch(Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }

        public Dictionary<string, EmployeeObj> GetEmployeeByName(string name)
        {
            try { if (string.IsNullOrEmpty(name)) return new Dictionary<string, EmployeeObj>();
                string sqlTxt = "Select * From vwEN_Employee Where Name like '%" + name + "%'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                return DataSetConverter(ds);
            } catch(Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }

        public Dictionary<string, EmployeeObj> GetEmployeeByCountry(string countryId)
        {
            try { if (string.IsNullOrEmpty(countryId)) return new Dictionary<string, EmployeeObj>();
                string sqlTxt = "Select * From vwEN_Employee Where CountryId = '"+countryId+"'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                return DataSetConverter(ds);
            } catch(Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }

        public Dictionary<string, EmployeeObj> GetEmployeeByStore(string storeId)
        {
            try
            {
                if (string.IsNullOrEmpty(storeId)) return new Dictionary<string, EmployeeObj>();
                string sqlTxt = "Select * From vwEN_Employee Where StoreId = '" + storeId + "'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }

        public Dictionary<string, EmployeeObj> GetEmployeeByValid(bool isValid)
        {
            try
            {
                string sqlTxt = "Select * From vwEN_Employee Where IsValid = " 
                    + (isValid ? 1 : 0);
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }

        public bool UpdateEmployee(EmployeeObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[Employee]"
                    + " SET [CountryID] = N'" + obj.CountryId + "'"
                    + ",[Sn] = '" + obj.Sn + "'"
                    + ",[Name] = N'" + obj.Name + "'"
                    + ",[Addr] = '" + obj.Addr + "'"
                    + ",[Phone] = '" + obj.Phone + "'"
                    + ",[Bday] = '" + obj.Bday.ToString("yyyy/MM/dd") + "'"
                    + ",[OnBoard] = '" + obj.OnBoard.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + ",[QuitDay] = '" + obj.QuitDay.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + ",[Salary] = " + float.Parse(obj.Salary)
                    + ",[CurrencyId] = '" + obj.CurrencyId + "'"
                    + ",[Remark] = N'" + obj.Remark + "'"
                    + ",[StoreId] = '" + obj.StoreId + "'"
                    + ",[IsValid] = " + (obj.IsValid?1:0)
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // output log
                return false;
            }
        }

        public bool InsertEmployee(EmployeeObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[Employee]"
                    + "([CountryId],[Sn],[Name],[Account],[Addr],[Phone],[Bday],[OnBoard]"
                    +",[Salary],[CurrencyId],[Remark],[StoreId],[IsValid])VALUES("
                    + "'" + obj.CountryId + "'"
                    + ",'" + obj.Sn + "'"
                    + ",N'" + obj.Name + "'"
                    + ",'" + obj.Account + "'"
                    + ",N'" + obj.Addr + "'"
                    + ",'" + obj.Phone + "'"
                    + ",'" + obj.Bday.ToString("yyyy/MM/dd") + "'"
                    + ",'" + obj.OnBoard.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + "," + float.Parse(obj.Salary)
                    + ",'" + obj.CurrencyId + "'"
                    + ",N'" + obj.Remark + "'"
                    + ",'" + obj.StoreId + "'"
                    + "," + (obj.IsValid?1:0) + ")";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log.
                return false;
            }
        }
        
        public Dictionary<string, EmployeeObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, EmployeeObj>();
                Dictionary<string, EmployeeObj> lst = new Dictionary<string, EmployeeObj>();
                EmployeeObj obj = new EmployeeObj();
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new EmployeeObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }catch(Exception ex)
            {
                // Output log
                return new Dictionary<string, EmployeeObj>();
            }
        }
    }
}
