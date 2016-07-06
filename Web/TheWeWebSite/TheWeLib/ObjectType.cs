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
        public string Id { set; get; }
        public string Name { set; get; }
        public string EngName { set; get; }
        public string Addr { set; get; }
        public string Msger { set; get; }
        public string MsgerTypeId { set; get; }
        public string CountryId { set; get; }
        public string Phone { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public DateTime Bday { set; get; }
        public string Remark { set; get; }
        public bool IsValid { set; get; }
        public string StoreId { set; get; }
        public string Account { set; get; }
        public string Sn { set; get; }
        public string NickName { set; get; }
        public bool Gender { set; get; }
        public bool InfoSource { set; get; }
        public string MsgTitle { set; get; }
        public string PhotoImg { set; get; }
        #endregion

        public CustomerObj(DataRow dr)
        {
            try
            {
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
                this.IsValid = dr["IsValid"] == null ? false : bool.Parse(dr["IsValid"].ToString());
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
        public string Id { set; get; }
        public string Name { set; get; }
        public string CountryId { set; get; }
        public string Sn { set; get; }
        public string Account { set; get; }
        public string Password { set; get; }
        public string Addr { set; get; }
        public string Phone { set; get; }
        public DateTime Bday { set; get; }
        public DateTime OnBoard { set; get; }
        public DateTime QuitDay { set; get; }
        public string Salary { set; get; }
        public string CurrencyId { set; get; }
        public string Remark { set; get; }
        public string StoreId { set; get; }
        public bool IsValid { set; get; }
        #endregion

        public EmployeeObj(DataRow dr)
        {
            try
            {
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
        public string Id { set; get; }
        public string ChName { set; get; }
        public string EngName { set; get; }
        public string Code { set; get; }
        public string CurrencyId { set; get; }
        public string LangCode { set; get; }
        #endregion

        public CountryObj(DataRow dr)
        {
            try
            {
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
        public string Id { set; get; }
        public string ChName { set; get; }
        public string EngName { set; get; }
        public string Code { set; get; }
        public string CountryId { set; get; }
        #endregion

        public AreaObj(DataRow dr)
        {
            try
            {
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
        public string Id { set; get; }
        public string Sn { set; get; }
        public string CountryId { set; get; }
        public string AreaId { set; get; }
        public string ChName { set; get; }
        public string EngName { set; get; }
        public string Addr { set; get; }
        public string Description { set; get; }
        #endregion

        public StoreObj() { }
        public StoreObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.ChName = dr["ChName"] == null ? string.Empty : dr["ChName"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Addr = dr["Addr"] == null ? string.Empty : dr["Addr"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

}
