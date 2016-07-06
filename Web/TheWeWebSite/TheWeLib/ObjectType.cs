using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib
{
    public class CustomerObj
    {
        #region Variable Initial
        string Id { set; get; }
        string Name { set; get; }
        string EngName { set; get; }
        string Addr { set; get; }
        string Msger { set; get; }
        string MsgerTypeId { set; get; }
        string CountryId { set; get; }
        string Phone { set; get; }
        string Mobile { set; get; }
        string Email { set; get; }
        DateTime Bday { set; get; }
        string Remark { set; get; }
        bool IsValid { set; get; }
        string StoreId { set; get; }
        string Account { set; get; }
        string Sn { set; get; }
        string NickName { set; get; }
        bool Gender { set; get; }
        bool InfoSource { set; get; }
        string MsgTitle { set; get; }
        string PhotoImg { set; get; }
        #endregion

        public CustomerObj(DataSet ds)
        {
            try
            {
                if (new DbConn().IsDataSetEmpty(ds)) return;
                DataRow dr = ds.Tables[0].Rows[0];
                this.Id = dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Account = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Addr = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.CountryId = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Email = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Gender = dr["Gender"] == null ? true : bool.Parse(dr["Gender"].ToString());
                this.Bday = dr["Bday"] == null ? new DateTime() : DateTime.Parse(dr["Bday"].ToString());
                this.InfoSource = dr["InfoSource"] == null ? false : bool.Parse(dr["InfoSource"].ToString());
                this.IsValid = dr["IsValid"] == null ? false : bool.Parse(dr["Name"].ToString());
                this.Mobile = dr["Mobile"] == null ? string.Empty : dr["Mobile"].ToString();
                this.Msger = dr["MessengerId"] == null ? string.Empty : dr["MessengerId"].ToString();
                this.MsgerTypeId = dr["MessengerType"] == null ? string.Empty : dr["MessengerType"].ToString();
                this.MsgTitle = dr["MsgTitle"] == null ? string.Empty : dr["MsgTitle"].ToString();
                this.NickName = dr["NickName"] == null ? string.Empty : dr["NickName"].ToString();
                this.Phone = dr["Phone"] == null ? string.Empty : dr["Phone"].ToString();
                this.PhotoImg = dr["PhotoImg"] == null ? string.Empty : dr["PhotoImg"].ToString();
                this.Remark = dr["Remark"] == null ? string.Empty : dr["Remark"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.StoreId = dr["StoreId"] == null ? string.Empty : dr["StoreId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log here.
            }
        }

        public CustomerObj() { }
    }

    public class EmployeeObj
    {
        #region Variable Initial
        string Id { set; get; }
        string Name { set; get; }
        string CountryId { set; get; }
        string Sn { set; get; }
        string Account { set; get; }
        string Password { set; get; }
        string Addr { set; get; }
        string Phone { set; get; }
        DateTime Bday { set; get; }
        DateTime OnBoard { set; get; }
        DateTime QuitDay { set; get; }
        string Salary { set; get; }
        string CurrencyId { set; get; }
        string Remark { set; get; }
        string StoreId { set; get; }
        bool IsValid { set; get; }
        #endregion

        public EmployeeObj(DataSet ds)
        {
            try
            {
                if (new DbConn().IsDataSetEmpty(ds)) return;
                DataRow dr = ds.Tables[0].Rows[0];
                this.Account = dr["Account"] == null ? string.Empty : dr["Account"].ToString();
                this.Addr = dr["Addr"] == null ? string.Empty : dr["Addr"].ToString();
                this.Bday = dr["Bday"] == null ? new DateTime() : DateTime.Parse(dr["Bday"].ToString());
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.CurrencyId = dr["CurrencyId"] == null ? string.Empty : dr["CurrencyId"].ToString();
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.IsValid = dr["IsValid"] == null ? false : bool.Parse(dr["IsValid"].ToString());
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.OnBoard = dr["OnBoard"] == null ? new DateTime() : DateTime.Parse(dr["OnBoard"].ToString());
                this.Password = dr["Password"] == null ? string.Empty : dr[""].ToString();
                this.Phone = dr["Phone"] == null ? string.Empty : dr[""].ToString();
                this.QuitDay = dr["QuitDay"] == null ? new DateTime() : DateTime.Parse(dr["QuitDay"].ToString());
                this.Remark = dr["Remark"] == null ? string.Empty : dr["Remark"].ToString();
                this.Salary = dr["Salary"] == null ? string.Empty : dr["Salary"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.StoreId = dr["StoreId"] == null ? string.Empty : dr["StoreId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }

        public EmployeeObj() { }
    }

    public class CountryObj
    {
        #region Variable Initial
        string Id { set; get; }
        string ChName { set; get; }
        string EngName { set; get; }
        string Code { set; get; }
        string CurrencyId { set; get; }
        string LangCode { set; get; }
        #endregion

        public CountryObj(DataSet ds)
        {
            try
            {
                if (new DbConn().IsDataSetEmpty(ds)) return;
                DataRow dr = ds.Tables[0].Rows[0];
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ChName = dr["ChName"] == null ? string.Empty : dr["ChName"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Code = dr["Code"] == null ? string.Empty : dr["Code"].ToString();
                this.LangCode = dr["LangCode"] == null ? string.Empty : dr["LangCode"].ToString();
                this.CurrencyId = dr["CurrencyId"] == null ? string.Empty : dr["CurrencyId"].ToString();
            }
            catch (Exception ex)
            {
                // output log.
            }
        }
        public CountryObj() { }
    }

    public class AreaObj
    {
        #region Variable Initial
        string Id { set; get; }
        string ChName { set; get; }
        string EngName { set; get; }
        string Code { set; get; }
        string CountryId { set; get; }
        #endregion

        public AreaObj(DataSet ds)
        {
            try
            {
                if (new DbConn().IsDataSetEmpty(ds)) return;
                DataRow dr = ds.Tables[0].Rows[0];
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ChName = dr["ChName"] == null ? string.Empty : dr["ChName"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Code = dr["Code"] == null ? string.Empty : dr["Code"].ToString();
                this.CountryId = dr["Country"] == null ? string.Empty : dr["Country"].ToString();
            }
            catch (Exception ex)
            {
                // Output log.
            }
        }
        public AreaObj() { }
    }

    public class StoreObj
    {
        #region Variable Initial
        string Id { set; get; }
        string Sn { set; get; }
        string CountryId { set; get; }
        string AreaId { set; get; }
        string ChName { set; get; }
        string EngName { set; get; }
        string Addr { set; get; }
        string Description { set; get; }
        #endregion

        public StoreObj() { }
        public StoreObj(DataSet ds)
        {
            try {
                if (new DbConn().IsDataSetEmpty(ds)) return;
                DataRow dr = ds.Tables[0].Rows[0];
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.ChName = dr["ChName"] == null ? string.Empty : dr["ChName"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Addr = dr["Addr"] == null ? string.Empty : dr["Addr"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch(Exception ex)
            {
                // Output log
            }
        }
    }

}
