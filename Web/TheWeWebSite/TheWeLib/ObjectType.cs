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
        public string Password { set; get; }


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
                this.Password = dr["Password"] == null ? string.Empty : dr["Password"].ToString();

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

    public class ApprovalRatingObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ObiectId { set; get; }
        public string Type { set; get; }
        public string Score { set; get; }


        #endregion

        public ApprovalRatingObj() { }
        public ApprovalRatingObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ObiectId = dr["ObiectId"] == null ? string.Empty : dr["ObiectId"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
                this.Score = dr["Score"] == null ? string.Empty : dr["Score"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ChurchObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ChName { set; get; }
        public string EngName { set; get; }
        public string CountryId { set; get; }
        public string AreaId { set; get; }
        public string MealImg { set; get; }
        public string MapImg { set; get; }
        public string DmImg { set; get; }
        public string PhotoImg { set; get; }
        public string Capacities { set; get; }
        public string Price { set; get; }
        public string Remark { set; get; }

        #endregion

        public ChurchObj() { }
        public ChurchObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ChName = dr["ChName"] == null ? string.Empty : dr["ChName"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.MealImg = dr["MealImg"] == null ? string.Empty : dr["MealImg"].ToString();
                this.MapImg = dr["MapImg"] == null ? string.Empty : dr["MapImg"].ToString();
                this.DmImg = dr["DmImg"] == null ? string.Empty : dr["DmImg"].ToString();
                this.PhotoImg = dr["PhotoImg"] == null ? string.Empty : dr["PhotoImg"].ToString();
                this.Capacities = dr["Capacities"] == null ? string.Empty : dr["Capacities"].ToString();
                this.Price = dr["Price"] == null ? string.Empty : dr["Price"].ToString();
                this.Remark = dr["Remark"] == null ? string.Empty : dr["Remark"].ToString();

            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConferenceItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ConferenceLv { set; get; }

        #endregion

        public ConferenceItemObj() { }
        public ConferenceItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.ConferenceLv = dr["ConferenceLv"] == null ? string.Empty : dr["ConferenceLv"].ToString();

            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultationObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string StoreId { set; get; }
        public string EmployeeId { set; get; }
        public bool SeekerGender { set; get; }
        public string BridalName { set; get; }
        public string BridalEngName { set; get; }
        public string BridalPhone { set; get; }
        public DateTime BridalBday { set; get; }
        public string BridalEmail { set; get; }
        public string BridalWork { set; get; }
        public string BridalMsgerType { set; get; }
        public string BridalMsgerId { set; get; }
        public string GroomName { set; get; }
        public string GroomEngName { set; get; }
        public string GroomPhone { set; get; }
        public string GroomWork { set; get; }
        public DateTime GroomBday { set; get; }
        public string GroomEmail { set; get; }
        public string GroomMsgerType { set; get; }
        public string GroomMsgerId { set; get; }
        public bool OverseaWedding { set; get; }
        public bool OverseaFilming { set; get; }
        public bool LocalFilming { set; get; }
        public bool WeddingConsult { set; get; }
        public DateTime FilmingDate { set; get; }
        public DateTime WeddingDate { set; get; }
        public DateTime ReceptionDate { set; get; }
        public string StatusId { set; get; }
        public DateTime LastReceivedDate { set; get; }
        public string Remark { set; get; }
        public DateTime ConsultDate { set; get; }
        public bool IsReply { set; get; }
        public bool InfoSource { set; get; }
        public DateTime CloseDate { set; get; }
        public DateTime ContractDate { set; get; }
        public DateTime ReservationDate { set; get; }
        public string ContactMethod { set; get; }
        public string Description { set; get; }

        #endregion

        public ConsultationObj() { }
        public ConsultationObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.StoreId = dr["StoreId"] == null ? string.Empty : dr["StoreId"].ToString();
                this.EmployeeId = dr["EmployeeId"] == null ? string.Empty : dr["EmployeeId"].ToString();
                this.SeekerGender = dr["SeekerGender"] == null ? false : bool.Parse(dr["SeekerGender"].ToString());
                this.BridalName = dr["BridalName"] == null ? string.Empty : dr["BridalName"].ToString();
                this.BridalEngName = dr["BridalEngName"] == null ? string.Empty : dr["BridalEngName"].ToString();
                this.BridalPhone = dr["BridalPhone"] == null ? string.Empty : dr["BridalPhone"].ToString();
                this.BridalBday = dr["BridalBday"] == null ? new DateTime() : DateTime.Parse(dr["BridalBday"].ToString());
                this.BridalEmail = dr["BridalEmail"] == null ? string.Empty : dr["BridalEmail"].ToString();
                this.BridalWork = dr["BridalWork"] == null ? string.Empty : dr["BridalWork"].ToString();
                this.BridalMsgerType = dr["BridalMsgerType"] == null ? string.Empty : dr["BridalMsgerType"].ToString();
                this.BridalMsgerId = dr["BridalMsgerId"] == null ? string.Empty : dr["BridalMsgerId"].ToString();
                this.GroomName = dr["GroomName"] == null ? string.Empty : dr["GroomName"].ToString();
                this.GroomEngName = dr["GroomEngName"] == null ? string.Empty : dr["GroomEngName"].ToString();
                this.GroomPhone = dr["GroomPhone"] == null ? string.Empty : dr["GroomPhone"].ToString();
                this.GroomWork = dr["GroomWork"] == null ? string.Empty : dr["GroomWork"].ToString();
                this.GroomBday = dr["GroomBday"] == null ? new DateTime() : DateTime.Parse(dr["GroomBday"].ToString());
                this.GroomEmail = dr["GroomEmail"] == null ? string.Empty : dr["GroomEmail"].ToString();
                this.GroomMsgerType = dr["GroomMsgerType"] == null ? string.Empty : dr["GroomMsgerType"].ToString();
                this.GroomMsgerId = dr["GroomMsgerId"] == null ? string.Empty : dr["GroomMsgerId"].ToString();
                this.OverseaWedding = dr["OverseaWedding"] == null ? false : bool.Parse(dr["OverseaWedding"].ToString());
                this.OverseaFilming = dr["OverseaFilming"] == null ? false : bool.Parse(dr["OverseaFilming"].ToString());
                this.LocalFilming = dr["LocalFilming"] == null ? false : bool.Parse(dr["LocalFilming"].ToString());
                this.WeddingConsult = dr["WeddingConsult"] == null ? false : bool.Parse(dr["WeddingConsult"].ToString());
                this.FilmingDate = dr["FilmingDate"] == null ? new DateTime() : DateTime.Parse(dr["FilmingDate"].ToString());
                this.WeddingDate = dr["WeddingDate"] == null ? new DateTime() : DateTime.Parse(dr["WeddingDate"].ToString());
                this.ReceptionDate = dr["ReceptionDate"] == null ? new DateTime() : DateTime.Parse(dr["ReceptionDate"].ToString());
                this.StatusId = dr["StatusId"] == null ? string.Empty : dr["StatusId"].ToString();
                this.LastReceivedDate = dr["LastReceivedDate"] == null ? new DateTime() : DateTime.Parse(dr["LastReceivedDate"].ToString());
                this.Remark = dr["Remark"] == null ? string.Empty : dr["Remark"].ToString();
                this.ConsultDate = dr["ConsultDate"] == null ? new DateTime() : DateTime.Parse(dr["ConsultDate"].ToString());
                this.IsReply = dr["IsReply"] == null ? false : bool.Parse(dr["IsReply"].ToString());
                this.InfoSource = dr["InfoSource"] == null ? false : bool.Parse(dr["InfoSource"].ToString());
                this.CloseDate = dr["CloseDate"] == null ? new DateTime() : DateTime.Parse(dr["CloseDate"].ToString());
                this.ContractDate = dr["ContractDate"] == null ? new DateTime() : DateTime.Parse(dr["ContractDate"].ToString());
                this.ReservationDate = dr["ReservationDate"] == null ? new DateTime() : DateTime.Parse(dr["ReservationDate"].ToString());
                this.ContactMethod = dr["ContactMethod"] == null ? string.Empty : dr["ContactMethod"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultOverseaWeddingObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ChurchId { set; get; }
        public string AreaId { set; get; }
        public string ConsultId { set; get; }

        #endregion

        public ConsultOverseaWeddingObj() { }
        public ConsultOverseaWeddingObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ChurchId = dr["ChurchId"] == null ? string.Empty : dr["ChurchId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultServiceItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ConsultId { set; get; }
        public string ServiceCategoryId { set; get; }
        public string Description { set; get; }

        #endregion

        public ConsultServiceItemObj() { }
        public ConsultServiceItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
                this.ServiceCategoryId = dr["ServiceCategoryId"] == null ? string.Empty : dr["ServiceCategoryId"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultStatusObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        #endregion

        public ConsultStatusObj() { }
        public ConsultStatusObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultWeddingLocoationObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ConsultId { set; get; }
        public string ChurchId { set; get; }

        #endregion

        public ConsultWeddingLocoationObj() { }
        public ConsultWeddingLocoationObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
                this.ChurchId = dr["ChurchId"] == null ? string.Empty : dr["ChurchId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ConsultWeddingPhotoObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string LocationId { set; get; }
        public string ConsultId { set; get; }

        #endregion

        public ConsultWeddingPhotoObj() { }
        public ConsultWeddingPhotoObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.LocationId = dr["LocationId"] == null ? string.Empty : dr["LocationId"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class CurrencyObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Rate { set; get; }
        public string EmployeeId { set; get; }
        public string UpdateTime { set; get; }

        #endregion

        public CurrencyObj() { }
        public CurrencyObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Rate = dr["Rate"] == null ? string.Empty : dr["Rate"].ToString();
                this.EmployeeId = dr["EmployeeId"] == null ? string.Empty : dr["EmployeeId"].ToString();
                this.UpdateTime = dr["UpdateTime"] == null ? string.Empty : dr["UpdateTime"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string DressId { set; get; }
        public bool Gender { set; get; }
        public string Category { set; get; }
        public string Color { set; get; }
        public string Type { set; get; }
        public string Neckline { set; get; }
        public string Trailing { set; get; }
        public string Back { set; get; }
        public string Shoulder { set; get; }
        public string Material { set; get; }
        public string Worn { set; get; }
        public string Veil { set; get; }
        public string Fitting { set; get; }
        public string Corsage { set; get; }
        public string Gloves { set; get; }
        public string Other { set; get; }
        public string Supplier { set; get; }
        public DateTime PurchaseDate { set; get; }
        public string PurchaseCosts { set; get; }
        public string ModifyingCost { set; get; }
        public string RentalCosts { set; get; }
        public string RentPrice { set; get; }
        public string AmortizationCosts { set; get; }
        public DateTime DepreciatioStartDate { set; get; }
        public string DepreciableLife { set; get; }
        public DateTime DepreciationTerminationDate { set; get; }
        public string DepreciationAmortization { set; get; }
        public string StatusCode { set; get; }
        public string UseStatus { set; get; }
        public string StoreId { set; get; }

        #endregion

        public DressObj() { }
        public DressObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.DressId = dr["DressId"] == null ? string.Empty : dr["DressId"].ToString();
                this.Gender = dr["Gender"] == null ? false : bool.Parse(dr["Gender"].ToString());
                this.Category = dr["Category"] == null ? string.Empty : dr["Category"].ToString();
                this.Color = dr["Color"] == null ? string.Empty : dr["Color"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
                this.Neckline = dr["Neckline"] == null ? string.Empty : dr["Neckline"].ToString();
                this.Trailing = dr["Trailing"] == null ? string.Empty : dr["Trailing"].ToString();
                this.Back = dr["Back"] == null ? string.Empty : dr["Back"].ToString();
                this.Shoulder = dr["Shoulder"] == null ? string.Empty : dr["Shoulder"].ToString();
                this.Material = dr["Material"] == null ? string.Empty : dr["Material"].ToString();
                this.Worn = dr["Worn"] == null ? string.Empty : dr["Worn"].ToString();
                this.Veil = dr["Veil"] == null ? string.Empty : dr["Veil"].ToString();
                this.Fitting = dr["Fitting"] == null ? string.Empty : dr["Fitting"].ToString();
                this.Corsage = dr["Corsage"] == null ? string.Empty : dr["Corsage"].ToString();
                this.Gloves = dr["Gloves"] == null ? string.Empty : dr["Gloves"].ToString();
                this.Other = dr["Other"] == null ? string.Empty : dr["Other"].ToString();
                this.Supplier = dr["Supplier"] == null ? string.Empty : dr["Supplier"].ToString();
                this.PurchaseDate = dr["PurchaseDate"] == null ? new DateTime() : DateTime.Parse(dr["PurchaseDate"].ToString());
                this.PurchaseCosts = dr["PurchaseCosts"] == null ? string.Empty : dr["PurchaseCosts"].ToString();
                this.ModifyingCost = dr["ModifyingCost"] == null ? string.Empty : dr["ModifyingCost"].ToString();
                this.RentalCosts = dr["RentalCosts"] == null ? string.Empty : dr["RentalCosts"].ToString();
                this.RentPrice = dr["RentPrice"] == null ? string.Empty : dr["RentPrice"].ToString();
                this.AmortizationCosts = dr["AmortizationCosts"] == null ? string.Empty : dr["AmortizationCosts"].ToString();
                this.DepreciatioStartDate = dr["DepreciatioStartDate"] == null ? new DateTime() : DateTime.Parse(dr["DepreciatioStartDate"].ToString());
                this.DepreciableLife = dr["DepreciableLife"] == null ? string.Empty : dr["DepreciableLife"].ToString();
                this.DepreciationTerminationDate = dr["DepreciationTerminationDate"] == null ? new DateTime() : DateTime.Parse(dr["DepreciationTerminationDate"].ToString());
                this.DepreciationAmortization = dr["DepreciationAmortization"] == null ? string.Empty : dr["DepreciationAmortization"].ToString();
                this.StatusCode = dr["StatusCode"] == null ? string.Empty : dr["StatusCode"].ToString();
                this.UseStatus = dr["UseStatus"] == null ? string.Empty : dr["UseStatus"].ToString();
                this.StoreId = dr["StoreId"] == null ? string.Empty : dr["StoreId"].ToString();


            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressBackObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressBackObj() { }
        public DressBackObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressCategoryObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressCategoryObj() { }
        public DressCategoryObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressColorObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Code { set; get; }
        public string Description { set; get; }

        #endregion

        public DressColorObj() { }
        public DressColorObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Code = dr["Code"] == null ? string.Empty : dr["Code"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressCorsageObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressCorsageObj() { }
        public DressCorsageObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressFittingObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressFittingObj() { }
        public DressFittingObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressGlovesObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressGlovesObj() { }
        public DressGlovesObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressImgObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string DataSeq { set; get; }
        public string Description { set; get; }
        public string ImgId { set; get; }

        #endregion

        public DressImgObj() { }
        public DressImgObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.DataSeq = dr["DataSeq"] == null ? string.Empty : dr["DataSeq"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.ImgId = dr["ImgId"] == null ? string.Empty : dr["ImgId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressMaterialObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressMaterialObj() { }
        public DressMaterialObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressNecklineObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressNecklineObj() { }
        public DressNecklineObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressOtherObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressOtherObj() { }
        public DressOtherObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressShoulderObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressShoulderObj() { }
        public DressShoulderObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressStatusCodeObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressStatusCodeObj() { }
        public DressStatusCodeObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressSupplierObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }
        public string Country { set; get; }
        public string City { set; get; }
        public bool IsValid { set; get; }

        #endregion

        public DressSupplierObj() { }
        public DressSupplierObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.Country = dr["Country"] == null ? string.Empty : dr["Country"].ToString();
                this.City = dr["City"] == null ? string.Empty : dr["City"].ToString();
                this.IsValid = dr["IsValid"] == null ? false : bool.Parse(dr["IsValid"].ToString());
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressTrailingObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressTrailingObj() { }
        public DressTrailingObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressTypeObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressTypeObj() { }
        public DressTypeObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressUseStatusObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressUseStatusObj() { }
        public DressUseStatusObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressVeilObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressVeilObj() { }
        public DressVeilObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class DressWornObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Description { set; get; }

        #endregion

        public DressWornObj() { }
        public DressWornObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class FunctionItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Type { set; get; }

        #endregion

        public FunctionItemObj() { }
        public FunctionItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class InforSourceItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        #endregion

        public InforSourceItemObj() { }
        public InforSourceItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class InfoSourceObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string InfoId { set; get; }
        public string Description { set; get; }
        public string ConsultId { set; get; }
        public string CustomerId { set; get; }
        #endregion

        public InfoSourceObj() { }
        public InfoSourceObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.InfoId = dr["InfoId"] == null ? string.Empty : dr["InfoId"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
                this.CustomerId = dr["CustomerId"] == null ? string.Empty : dr["CustomerId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ItemUnitObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        #endregion

        public ItemUnitObj() { }
        public ItemUnitObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class MessengerObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        #endregion

        public MessengerObj() { }
        public MessengerObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class OrderInfoObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string ConsultId { set; get; }
        public string Sn { set; get; }
        public DateTime StartTime { set; get; }
        public string CustomerId { set; get; }
        public string PartnerId { set; get; }
        public string StatusId { set; get; }
        public DateTime CloseTime { set; get; }
        public string CountryId { set; get; }
        public string AreaId { set; get; }
        public string ChurchId { set; get; }
        public string SetId { set; get; }
        public string ServiceWindowId { set; get; }
        public string StoreId { set; get; }
        public string PermissionId { set; get; }
        public string Price { set; get; }
        public string CurrencyId { set; get; }

        #endregion

        public OrderInfoObj() { }
        public OrderInfoObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.StartTime = dr["StartTime"] == null ? new DateTime() : DateTime.Parse(dr["StartTime"].ToString());
                this.CustomerId = dr["CustomerId"] == null ? string.Empty : dr["CustomerId"].ToString();
                this.PartnerId = dr["PartnerId"] == null ? string.Empty : dr["PartnerId"].ToString();
                this.StatusId = dr["StatusId"] == null ? string.Empty : dr["StatusId"].ToString();
                this.CloseTime = dr["CloseTime"] == null ? new DateTime() : DateTime.Parse(dr["CloseTime"].ToString());
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.ChurchId = dr["ChurchId"] == null ? string.Empty : dr["ChurchId"].ToString();
                this.SetId = dr["SetId"] == null ? string.Empty : dr["SetId"].ToString();
                this.ServiceWindowId = dr["ServiceWindowId"] == null ? string.Empty : dr["ServiceWindowId"].ToString();
                this.StoreId = dr["StoreId"] == null ? string.Empty : dr["StoreId"].ToString();
                this.PermissionId = dr["PermissionId"] == null ? string.Empty : dr["PermissionId"].ToString();
                this.Price = dr["Price"] == null ? string.Empty : dr["Price"].ToString();
                this.CurrencyId = dr["CurrencyId"] == null ? string.Empty : dr["CurrencyId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class OrderResponsibleObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string EmployeeId { set; get; }
        public string OrderId { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public bool IsClose { set; get; }

        #endregion

        public OrderResponsibleObj() { }
        public OrderResponsibleObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.StartTime = dr["StartTime"] == null ? new DateTime() : DateTime.Parse(dr["StartTime"].ToString());
                this.EndTime = dr["EndTime"] == null ? new DateTime() : DateTime.Parse(dr["EndTime"].ToString());
                this.IsClose = dr["IsClose"] == null ? false : bool.Parse(dr["IsClose"].ToString());
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class PartnerObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string EngName { set; get; }
        public DateTime Bday { set; get; }
        public string MessengerType { set; get; }
        public string MessengerId { set; get; }
        public string Phone { set; get; }
        public string OrderId { set; get; }
        public string Email { set; get; }
        public string Works { set; get; }
        public string NickName { set; get; }
        public string PhotoImg { set; get; }

        #endregion

        public PartnerObj() { }
        public PartnerObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.EngName = dr["EngName"] == null ? string.Empty : dr["EngName"].ToString();
                this.Bday = dr["Bday"] == null ? new DateTime() : DateTime.Parse(dr["Bday"].ToString());
                this.MessengerType = dr["MessengerType"] == null ? string.Empty : dr["MessengerType"].ToString();
                this.MessengerId = dr["MessengerId"] == null ? string.Empty : dr["MessengerId"].ToString();
                this.Phone = dr["Phone"] == null ? string.Empty : dr["Phone"].ToString();
                this.OrderId = dr["OrderId"] == null ? string.Empty : dr["OrderId"].ToString();
                this.Email = dr["Email"] == null ? string.Empty : dr["Email"].ToString();
                this.Works = dr["Works"] == null ? string.Empty : dr["Works"].ToString();
                this.NickName = dr["NickName"] == null ? string.Empty : dr["NickName"].ToString();
                this.PhotoImg = dr["PhotoImg"] == null ? string.Empty : dr["PhotoImg"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class PerformItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Description { set; get; }
        public string Name { set; get; }

        #endregion

        public PerformItemObj() { }
        public PerformItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class PerformListObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string StaffId { set; get; }
        public string ProductSetId { set; get; }
        public string ChruchId { set; get; }

        #endregion

        public PerformListObj() { }
        public PerformListObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.StaffId = dr["StaffId"] == null ? string.Empty : dr["StaffId"].ToString();
                this.ProductSetId = dr["ProductSetId"] == null ? string.Empty : dr["ProductSetId"].ToString();
                this.ChruchId = dr["ChruchId"] == null ? string.Empty : dr["ChruchId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class PermissionObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ObjectId { set; get; }
        public string Type { set; get; }

        #endregion

        public PermissionObj() { }
        public PermissionObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.ObjectId = dr["ObjectId"] == null ? string.Empty : dr["ObjectId"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class PermissionItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string FunctionId  { set; get; }
        public string PermissionId { set; get; }
        public bool CanEntry { set; get; }
        public bool CanCreate { set; get; }
        public bool CanModify { set; get; }
        public bool CanDelete { set; get; }
        public bool CanExport { set; get; }


        #endregion

        public PermissionItemObj() { }
        public PermissionItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.FunctionId = dr["FunctionId"] == null ? string.Empty : dr["FunctionId"].ToString();
                this.PermissionId = dr["PermissionId"] == null ? string.Empty : dr["PermissionId"].ToString();
                this.CanEntry = dr["CanEntry"] == null ? false : bool.Parse(dr["CanEntry"].ToString());
                this.CanCreate = dr["CanCreate"] == null ? false : bool.Parse(dr["CanCreate"].ToString());
                this.CanModify = dr["CanModify"] == null ? false : bool.Parse(dr["CanModify"].ToString());
                this.CanDelete = dr["CanDelete"] == null ? false : bool.Parse(dr["CanDelete"].ToString());
                this.CanExport = dr["CanExport"] == null ? false : bool.Parse(dr["CanExport"].ToString());
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ProductSetObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string CountryId { set; get; }
        public bool Decoration { set; get; }
        public bool performence { set; get; }
        public string Price { set; get; }
        public string PriceCurrencyId { set; get; }
        public string Cost { set; get; }
        public string CostCurrencyId { set; get; }
        public string ChurchId { set; get; }
        public string DmImg { set; get; }
        public bool ChurchCost { set; get; }
        public bool Capacities { set; get; }
        public bool Ceritficate { set; get; }
        public bool RignPillow { set; get; }
        public bool SignPen { set; get; }
        public bool FlowerRain { set; get; }
        public string Champagne { set; get; }
        public string BridalMakeup { set; get; }
        public string GroomMakeup { set; get; }
        public string WeddingFilmingTime { set; get; }
        public string OtherFilmingTime { set; get; }
        public string FilmingLocation { set; get; }
        public string Moves { set; get; }
        public string PhotosNum { set; get; }
        public bool ChStaff { set; get; }
        public bool Lounge { set; get; }
        public string CorsageId { set; get; }
        public bool DressIroning { set; get; }
        public bool Kickoff { set; get; }
        public string StayNight { set; get; }
        public string RoomId { set; get; }
        public bool Breakfast { set; get; }
        public bool DetailSetting { set; get; }
        public bool SpecialService { set; get; }


        #endregion

        public ProductSetObj() { }
        public ProductSetObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.Decoration = dr["Decoration"] == null ? false : bool.Parse(dr["Decoration"].ToString());
                this.performence = dr["performence"] == null ? false : bool.Parse(dr["performence"].ToString());
                this.Price = dr["Price"] == null ? string.Empty : dr["Price"].ToString();
                this.PriceCurrencyId = dr["PriceCurrencyId"] == null ? string.Empty : dr["PriceCurrencyId"].ToString();
                this.Cost = dr["Cost"] == null ? string.Empty : dr["Cost"].ToString();
                this.CostCurrencyId = dr["CostCurrencyId"] == null ? string.Empty : dr["CostCurrencyId"].ToString();
                this.ChurchId = dr["ChurchId"] == null ? string.Empty : dr["ChurchId"].ToString();
                this.DmImg = dr["DmImg"] == null ? string.Empty : dr["DmImg"].ToString();
                this.ChurchCost = dr["ChurchCost"] == null ? false : bool.Parse(dr["ChurchCost"].ToString());
                this.Capacities = dr["Capacities"] == null ? false : bool.Parse(dr["Capacities"].ToString());
                this.Ceritficate = dr["Ceritficate"] == null ? false : bool.Parse(dr["Ceritficate"].ToString());
                this.RignPillow = dr["RignPillow"] == null ? false : bool.Parse(dr["RignPillow"].ToString());
                this.SignPen = dr["SignPen"] == null ? false : bool.Parse(dr["SignPen"].ToString());
                this.FlowerRain = dr["FlowerRain"] == null ? false : bool.Parse(dr["FlowerRain"].ToString());
                this.Champagne = dr["Champagne"] == null ? string.Empty : dr["Champagne"].ToString();
                this.BridalMakeup = dr["BridalMakeup"] == null ? string.Empty : dr["BridalMakeup"].ToString();
                this.GroomMakeup = dr["GroomMakeup"] == null ? string.Empty : dr["GroomMakeup"].ToString();
                this.WeddingFilmingTime = dr["WeddingFilmingTime"] == null ? string.Empty : dr["WeddingFilmingTime"].ToString();
                this.OtherFilmingTime = dr["OtherFilmingTime"] == null ? string.Empty : dr["OtherFilmingTime"].ToString();
                this.FilmingLocation = dr["FilmingLocation"] == null ? string.Empty : dr["FilmingLocation"].ToString();
                this.Moves = dr["Moves"] == null ? string.Empty : dr["Moves"].ToString();
                this.PhotosNum = dr["PhotosNum"] == null ? string.Empty : dr["PhotosNum"].ToString();
                this.ChStaff = dr["ChStaff"] == null ? false : bool.Parse(dr["ChStaff"].ToString());
                this.Lounge = dr["Lounge"] == null ? false : bool.Parse(dr["Lounge"].ToString());
                this.CorsageId = dr["CorsageId"] == null ? string.Empty : dr["CorsageId"].ToString();
                this.DressIroning = dr["DressIroning"] == null ? false : bool.Parse(dr["DressIroning"].ToString());
                this.Kickoff = dr["Kickoff"] == null ? false : bool.Parse(dr["Kickoff"].ToString());
                this.StayNight = dr["StayNight"] == null ? string.Empty : dr["StayNight"].ToString();
                this.RoomId = dr["RoomId"] == null ? string.Empty : dr["RoomId"].ToString();
                this.Breakfast = dr["Breakfast"] == null ? false : bool.Parse(dr["Breakfast"].ToString());
                this.DetailSetting = dr["DetailSetting"] == null ? false : bool.Parse(dr["DetailSetting"].ToString());
                this.SpecialService = dr["SpecialService"] == null ? false : bool.Parse(dr["SpecialService"].ToString());
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ProductSetServiceItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string SetId { set; get; }
        public string ItemId { set; get; }
        public string Number { set; get; }
        public string UnitId { set; get; }
        public string CategoryId { set; get; }

        #endregion

        public ProductSetServiceItemObj() { }
        public ProductSetServiceItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.SetId = dr["SetId"] == null ? string.Empty : dr["SetId"].ToString();
                this.ItemId = dr["ItemId"] == null ? string.Empty : dr["ItemId"].ToString();
                this.Number = dr["Number"] == null ? string.Empty : dr["Number"].ToString();
                this.UnitId = dr["UnitId"] == null ? string.Empty : dr["UnitId"].ToString();
                this.CategoryId = dr["CategoryId"] == null ? string.Empty : dr["CategoryId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class RoomStyleObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Description { set; get; }


        #endregion

        public RoomStyleObj() { }
        public RoomStyleObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ScheduleChurchObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public DateTime Date { set; get; }
        public string ChurchId { set; get; }
        public string Description { set; get; }
        public string CountryId { set; get; }
        public string AreaId { set; get; }
        public string ProductSetId { set; get; }


        #endregion

        public ScheduleChurchObj() { }
        public ScheduleChurchObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Date = dr["Date"] == null ? new DateTime() : DateTime.Parse(dr["Date"].ToString());
                this.ChurchId = dr["ChurchId"] == null ? string.Empty : dr["ChurchId"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.ProductSetId = dr["ProductSetId"] == null ? string.Empty : dr["ProductSetId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ScheduleEmployeeObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string EmployeeId { set; get; }
        public string Description { set; get; }
        public string EventType { set; get; }
        public string EventId { set; get; }
        public DateTime EventTime { set; get; }


        #endregion

        public ScheduleEmployeeObj() { }
        public ScheduleEmployeeObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.EmployeeId = dr["EmployeeId"] == null ? string.Empty : dr["EmployeeId"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.EventType = dr["EventType"] == null ? string.Empty : dr["EventType"].ToString();
                this.EventId = dr["EventId"] == null ? string.Empty : dr["EventId"].ToString();
                this.EventTime = dr["EventTime"] == null ? new DateTime() : DateTime.Parse(dr["EventTime"].ToString());
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ServiceItemObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Sn { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Type { set; get; }
        public string CategroyId { set; get; }
        public string SupplierId { set; get; }
        public string Cost { set; get; }
        public string CurrencyId { set; get; }

        #endregion

        public ServiceItemObj() { }
        public ServiceItemObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Sn = dr["Sn"] == null ? string.Empty : dr["Sn"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
                this.CategroyId = dr["CategroyId"] == null ? string.Empty : dr["CategroyId"].ToString();
                this.SupplierId = dr["SupplierId"] == null ? string.Empty : dr["SupplierId"].ToString();
                this.Cost = dr["Cost"] == null ? string.Empty : dr["Cost"].ToString();
                this.CurrencyId = dr["CurrencyId"] == null ? string.Empty : dr["CurrencyId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ServiceItemCategoryObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Type { set; get; }

        #endregion

        public ServiceItemCategoryObj() { }
        public ServiceItemCategoryObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
                this.Type = dr["Type"] == null ? string.Empty : dr["Type"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class ServiceWindowObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string CountryId { set; get; }
        public string Name { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string Description { set; get; }

        #endregion

        public ServiceWindowObj() { }
        public ServiceWindowObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.Phone = dr["Phone"] == null ? string.Empty : dr["Phone"].ToString();
                this.Email = dr["Email"] == null ? string.Empty : dr["Email"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class WeddingPhotoConsultationObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string LocationId { set; get; }
        public string ConsultId { set; get; }

        #endregion

        public WeddingPhotoConsultationObj() { }
        public WeddingPhotoConsultationObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.LocationId = dr["LocationId"] == null ? string.Empty : dr["LocationId"].ToString();
                this.ConsultId = dr["ConsultId"] == null ? string.Empty : dr["ConsultId"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

    public class WeddingPhotoLocationObj
    {
        #region Variable Initial
        public string Id { set; get; }
        public string Name { set; get; }
        public string CountryId { set; get; }
        public string AreaId { set; get; }
        public string Description { set; get; }

        #endregion

        public WeddingPhotoLocationObj() { }
        public WeddingPhotoLocationObj(DataRow dr)
        {
            try
            {
                this.Id = dr["Id"] == null ? string.Empty : dr["Id"].ToString();
                this.Name = dr["Name"] == null ? string.Empty : dr["Name"].ToString();
                this.CountryId = dr["CountryId"] == null ? string.Empty : dr["CountryId"].ToString();
                this.AreaId = dr["AreaId"] == null ? string.Empty : dr["AreaId"].ToString();
                this.Description = dr["Description"] == null ? string.Empty : dr["Description"].ToString();
            }
            catch (Exception ex)
            {
                // Output log
            }
        }
    }

}
