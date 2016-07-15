using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace TheWeLib
{
    public class Utility
    {
        /// <summary>
        /// True, dataset is null or empty.
        /// False, dataset in not empty.
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public bool IsDataSetEmpty(DataSet ds)
        {
            return ds == null ? true :
                (ds.Tables.Count == 0 ? true :
                (ds.Tables[0].Rows.Count == 0));
        }

        public string GetMD5(string inputStr)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] b = md5.ComputeHash(Encoding.UTF8.GetBytes(inputStr));
            return BitConverter.ToString(b).Replace("-", string.Empty);
        }


        /// <summary>
        /// Return the input variable name.
        /// For example: GetVariableName(() => A.testA)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expr"></param>
        /// <returns></returns>
        public string GetVariableName<T>(Expression<Func<T>> expr)
        {
            var body = (MemberExpression)expr.Body;

            return body.Member.Name;
        }

        public string OutputRelatedLangName(DataRow dr)
        {
            try
            {
                string result = string.Empty;
                switch (SysProperty.CultureCode)
                {
                    case "zh-TW":
                        result = !string.IsNullOrEmpty(dr["Name"].ToString()) ? dr["Name"].ToString() :
                            !string.IsNullOrEmpty(dr["CnName"].ToString()) ? dr["CnName"].ToString():
                            !string.IsNullOrEmpty(dr["EngName"].ToString()) ? dr["EngName"].ToString() :
                            !string.IsNullOrEmpty(dr["JpName"].ToString()) ? dr["JpName"].ToString() : string.Empty;                        
                        break;
                    case "zh-CHT":
                    case "zh-CHS":
                    case "zh-CN":
                    case "zh-HK":
                        result = !string.IsNullOrEmpty(dr["CnName"].ToString()) ? dr["CnName"].ToString() :
                            !string.IsNullOrEmpty(dr["Name"].ToString()) ? dr["Name"].ToString() :
                            !string.IsNullOrEmpty(dr["EngName"].ToString()) ? dr["EngName"].ToString() :
                            !string.IsNullOrEmpty(dr["JpName"].ToString()) ? dr["JpName"].ToString() : string.Empty;
                        break;
                    case "ja-JP":
                        result = !string.IsNullOrEmpty(dr["JpName"].ToString()) ? dr["JpName"].ToString() :
                            !string.IsNullOrEmpty(dr["CnName"].ToString()) ? dr["CnName"].ToString() :
                            !string.IsNullOrEmpty(dr["Name"].ToString()) ? dr["Name"].ToString() :
                            !string.IsNullOrEmpty(dr["EngName"].ToString()) ? dr["EngName"].ToString() : string.Empty;
                        break;
                    default:
                        result = !string.IsNullOrEmpty(dr["EngName"].ToString()) ? dr["EngName"].ToString() :
                            !string.IsNullOrEmpty(dr["CnName"].ToString()) ? dr["CnName"].ToString() :
                            !string.IsNullOrEmpty(dr["Name"].ToString()) ? dr["Name"].ToString() :
                            !string.IsNullOrEmpty(dr["JpName"].ToString()) ? dr["JpName"].ToString() : string.Empty;
                        break;
                }
                return result;
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return string.Empty;
            }
        }

        public bool VerifyBasicVariable()
        {
            try
            {
                if (string.IsNullOrEmpty(SysProperty.DbConcString)) { return false; }
                if (SysProperty.AccountInfo == null
                    || string.IsNullOrEmpty(SysProperty.AccountInfo["Id"].ToString()))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return false;
            }
        }

        public string SqlQuerySelectInstanceConverter(List<string> lst)
        {
            if (lst.Count == 0) return "*";
            string result = string.Empty;
            foreach (string str in lst)
            {
                result += (string.IsNullOrEmpty(str) ? string.Empty : ",") + str;
            }
            return result;
        }

        public string SqlQueryUpdateConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach (DbSearchObject obj in lst)
            {
                result += (string.IsNullOrEmpty(result) ? string.Empty : "," )+ ConditionConverter(obj);
            }
            return result;
        }

        public string SqlQueryInsertInstanceConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach (DbSearchObject obj in lst)
            {
                result += (string.IsNullOrEmpty(result) ? string.Empty : ",") + obj.AttrName;
            }
            return result;
        }

        public string SqlQueryInsertValueConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach (DbSearchObject obj in lst)
            {
                result += (string.IsNullOrEmpty(result) ? string.Empty : ",") + ValueConverter(obj);
            }
            return result;
        }

        public string SqlQueryConditionConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string condStr = string.Empty;
            foreach (DbSearchObject obj in lst)
            {
                condStr += (string.IsNullOrEmpty(condStr) ? " Where " : " And ") + ConditionConverter(obj);
            }
            return condStr;
        }

        public string ValueConverter(DbSearchObject obj)
        {
            if (obj == null) return string.Empty;
            string str = string.Empty;
            switch (obj.AttrType)
            {
                case AtrrTypeItem.Integer:
                case AtrrTypeItem.Bit:
                    str = obj.AttrValue;
                    break;
                case AtrrTypeItem.String:
                case AtrrTypeItem.DateTime:
                case AtrrTypeItem.Date:
                default:
                    str = "N'" + obj.AttrValue + "'";
                    break;
            }
            return str;
        }

        private string ConditionConverter(DbSearchObject obj)
        {
            if (obj == null) return string.Empty;
            string cond = obj.AttrName;
            switch (obj.AttrType)
            {
                case AtrrTypeItem.Integer:
                case AtrrTypeItem.Bit:
                    cond += AttrSymbolConverter(obj.AttrSymbol) + obj.AttrValue;
                    break;
                case AtrrTypeItem.String:
                case AtrrTypeItem.DateTime:
                case AtrrTypeItem.Date:
                default:
                    cond += AttrSymbolConverter(obj.AttrSymbol)
                        + (obj.AttrSymbol != AttrSymbolItem.Like
                        ? "N'" + obj.AttrValue + "'"
                        : "N'%" + obj.AttrValue + "%'");
                    break;
            }
            return cond;
        }

        public string AttrSymbolConverter(AttrSymbolItem item)
        {
            switch (item)
            {
                case AttrSymbolItem.Greater:
                    return ">";
                case AttrSymbolItem.GreaterOrEqual:
                    return ">=";
                case AttrSymbolItem.Less:
                    return "<";
                case AttrSymbolItem.LessOrEqual:
                    return "<=";
                case AttrSymbolItem.Like:
                    return "like";
                case AttrSymbolItem.Equal:
                default:
                    return "=";
            }
        }

        public string MsSqlTableConverter(MsSqlTable item)
        {
            switch (item)
            {
                case MsSqlTable.Accessory:
                    return "Accessory";
                case MsSqlTable.AccessoryMan:
                    return "AccessoryMan";
                case MsSqlTable.AccessoryOther:
                    return "AccessoryOther";
                case MsSqlTable.AccessoryRingPillow:
                    return "AccessoryRingPillow";
                case MsSqlTable.ApprovalRating:
                    return "ApprovalRating";
                case MsSqlTable.Area:
                    return "Area";
                case MsSqlTable.Church:
                    return "Church";
                case MsSqlTable.ConferenceInfo:
                    return "ConferenceInfo";
                case MsSqlTable.ConferenceItem:
                    return "ConferenceItem";
                case MsSqlTable.Consultation:
                    return "Consultation";
                case MsSqlTable.ConsultOverseaWedding:
                    return "ConsultOverseaWedding";
                case MsSqlTable.ConsultServiceItem:
                    return "ConsultServiceItem";
                case MsSqlTable.ConsultStatus:
                    return "ConsultStatus";
                case MsSqlTable.ConsultWeddingLocoation:
                    return "ConsultWeddingLocoation";
                case MsSqlTable.ConsultWeddingPhoto:
                    return "ConsultWeddingPhoto";
                case MsSqlTable.Country:
                    return "Country";
                case MsSqlTable.Currency:
                    return "Currency";
                case MsSqlTable.Customer:
                    return "Customer";
                case MsSqlTable.Dress:
                    return "Dress";
                case MsSqlTable.DressBack:
                    return "DressBack";
                case MsSqlTable.DressBouquet:
                    return "DressBouquet";
                case MsSqlTable.DressBracelet:
                    return "DressBracelet";
                case MsSqlTable.DressCategory:
                    return "DressCategory";
                case MsSqlTable.DressClogs:
                    return "DressClogs";
                case MsSqlTable.DressColor:
                    return "DressColor";
                case MsSqlTable.DressCorsage:
                    return "DressCorsage";
                case MsSqlTable.DressEarring:
                    return "DressEarring";
                case MsSqlTable.DressFitting:
                    return "DressFitting";
                case MsSqlTable.DressGloves:
                    return "DressGloves";
                case MsSqlTable.DressHeadwear:
                    return "DressHeadwear";
                case MsSqlTable.DressImg:
                    return "DressImg";
                case MsSqlTable.DressMaterial:
                    return "DressMaterial";
                case MsSqlTable.DressNecklace:
                    return "DressNecklace";
                case MsSqlTable.DressNeckline:
                    return "DressNeckline";
                case MsSqlTable.DressOther:
                    return "DressOther";
                case MsSqlTable.DressShawl:
                    return "DressShawl";
                case MsSqlTable.DressShoulder:
                    return "DressShoulder";
                case MsSqlTable.DressStatusCode:
                    return "DressStatusCode";
                case MsSqlTable.DressSupplier:
                    return "DressSupplier";
                case MsSqlTable.DressTrailing:
                    return "DressTrailing";
                case MsSqlTable.DressType:
                    return "DressType";
                case MsSqlTable.DressUseStatus:
                    return "DressUseStatus";
                case MsSqlTable.DressVeil:
                    return "DressVeil";
                case MsSqlTable.DressWorn:
                    return "DressWorn";
                case MsSqlTable.Employee:
                    return "Employee";
                case MsSqlTable.FunctionItem:
                    return "FunctionItem";
                case MsSqlTable.HairStyleCategory:
                    return "HairStyleCategory";
                case MsSqlTable.HairStyleItem:
                    return "HairStyleItem";
                case MsSqlTable.InforSourceItem:
                    return "InforSourceItem";
                case MsSqlTable.InfoSource:
                    return "InfoSource";
                case MsSqlTable.ItemUnit:
                    return "ItemUnit";
                case MsSqlTable.Messenger:
                    return "Messenger";
                case MsSqlTable.OrderInfo:
                    return "OrderInfo";
                case MsSqlTable.OrderOutput:
                    return "OrderOutput";
                case MsSqlTable.OrderResponsible:
                    return "OrderResponsible";
                case MsSqlTable.Partner:
                    return "Partner";
                case MsSqlTable.PerformItem:
                    return "PerformItem";
                case MsSqlTable.PerformList:
                    return "PerformList";
                case MsSqlTable.Permission:
                    return "Permission";
                case MsSqlTable.PermissionItem:
                    return "PermissionItem";
                case MsSqlTable.PermissonGroup:
                    return "PermissonGroup";
                case MsSqlTable.ProductSet:
                    return "ProductSet";
                case MsSqlTable.ProductSetServiceItem:
                    return "ProductSetServiceItem";
                case MsSqlTable.ReadMe:
                    return "ReadMe";
                case MsSqlTable.RelDressAccessory:
                    return "RelDressAccessory";
                case MsSqlTable.RoomStyle:
                    return "RoomStyle";
                case MsSqlTable.ScheduleChurch:
                    return "ScheduleChurch";
                case MsSqlTable.ScheduleEmployee:
                    return "ScheduleEmployee";
                case MsSqlTable.ScheduleEventDetail:
                    return "ScheduleEventDetail";
                case MsSqlTable.ScheduleItemCategory:
                    return "ScheduleItemCategory";
                case MsSqlTable.ServiceItem:
                    return "ServiceItem";
                case MsSqlTable.ServiceItemCategory:
                    return "ServiceItemCategory";
                case MsSqlTable.ServiceWindow:
                    return "ServiceWindow";
                case MsSqlTable.Store:
                    return "Store";
                case MsSqlTable.WeddingPhotoConsultation:
                    return "WeddingPhotoConsultation";
                case MsSqlTable.vwEN_Customer:
                    return "vwEN_Customer";
                case MsSqlTable.vwEN_Employee:
                    return "vwEN_Employee";
                case MsSqlTable.vwEN_Partner:
                    return "vmEN_Partner";
                default:
                    return string.Empty;

            }
        }
    }

    public class AreaHashList
    {
        private Hashtable Areas = new Hashtable();
        private Object locker = new object();
        public void InsertArea(string key, DataRow dr)
        {
            lock (locker)
            {
                Areas.Add(key, dr);
            }
        }

        public DataRow GetAreaById(string id)
        {
            lock (locker)
            {
                if (CheckKeyInArea(id))
                    return (DataRow)Areas[id];
                else
                    return null;
            }
        }

        public bool CheckKeyInArea(string id)
        {
            lock (locker)
            {
                return Areas.ContainsKey(id);
            }
        }
    }

    public class CountryHashList
    {
        private Hashtable Conutries = new Hashtable();
        private Object locker = new object();
        public void InsertCountry(string key, DataRow dr)
        {
            lock (locker)
            {
                Conutries.Add(key, dr);
            }
        }

        public DataRow GetCountryById(string id)
        {
            lock (locker)
            {
                if (CheckKeyInCountry(id))
                    return (DataRow)Conutries[id];
                else
                    return null;
            }
        }

        public bool CheckKeyInCountry(string id)
        {
            lock (locker)
            {
                return Conutries.ContainsKey(id);
            }
        }
    }
}
