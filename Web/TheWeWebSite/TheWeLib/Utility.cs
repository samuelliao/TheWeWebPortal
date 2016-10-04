using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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

        #region Instance Parser
        public string ParseDateTime(string type, string str)
        {
            bool result = false;
            string time = string.Empty;
            DateTime dt = new DateTime();
            result = DateTime.TryParse(str, out dt);
            switch (type)
            {
                case "Time":
                    return result ? dt.ToString("HH:mm") : string.Empty;
                case "Date":
                    time = result ? dt.ToString("yyyy-MM-dd") : string.Empty;
                    break;
                case "DateTime":
                    time = result ? dt.ToString("yyyy-MM-dd HH:mm") : string.Empty;
                    break;
                default:
                    time = string.Empty;
                    break;
            }
            if (result)
            {
                if (dt > new DateTime(1900, 12, 31))
                {
                    return time;
                }
                else
                {
                    return string.Empty;
                }
            }
            return time;
        }

        public decimal ParseMoney(string str)
        {
            bool result = false;
            decimal dec = new decimal();
            result = decimal.TryParse(str, out dec);
            return result ? dec : 0;
        }
        #endregion

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

        public string OutputRelatedLangName(string cultureCode, DataRow dr)
        {
            try
            {
                return OutputRelatedLangName(cultureCode
                    , dr["Name"].ToString()
                    , dr["CnName"].ToString()
                    , dr["EngName"].ToString()
                    , dr["JpName"].ToString());
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return string.Empty;
            }
        }

        public string OutputRelatedLangName(string cultureCode, string name, string cnName, string engName, string jpName)
        {
            try
            {
                if (string.IsNullOrEmpty(cultureCode))
                {
                    cultureCode = CultureInfo.CurrentCulture.ToString();
                }
                string result = string.Empty;
                switch (cultureCode)
                {
                    case "zh-TW":
                        result = !string.IsNullOrEmpty(name) ? name :
                            !string.IsNullOrEmpty(cnName) ? cnName :
                            !string.IsNullOrEmpty(engName) ? engName :
                            !string.IsNullOrEmpty(jpName) ? jpName : string.Empty;
                        break;
                    case "zh-CHT":
                    case "zh-CHS":
                    case "zh-CN":
                    case "zh-HK":
                        result = !string.IsNullOrEmpty(cnName) ? cnName :
                            !string.IsNullOrEmpty(name) ? name :
                            !string.IsNullOrEmpty(engName) ? engName :
                            !string.IsNullOrEmpty(jpName) ? jpName : string.Empty;
                        break;
                    case "ja-JP":
                        result = !string.IsNullOrEmpty(jpName) ? jpName :
                            !string.IsNullOrEmpty(cnName) ? cnName :
                            !string.IsNullOrEmpty(name) ? name :
                            !string.IsNullOrEmpty(engName) ? engName : string.Empty;
                        break;
                    default:
                        result = !string.IsNullOrEmpty(engName) ? engName :
                            !string.IsNullOrEmpty(cnName) ? cnName :
                            !string.IsNullOrEmpty(name) ? name :
                            !string.IsNullOrEmpty(jpName) ? jpName : string.Empty;
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return string.Empty;
            }
        }

        public Dictionary<string, PermissionItem> AdminPermission()
        {
            Dictionary<string, PermissionItem> lst = new Dictionary<string, PermissionItem>();
            for (int cnt = 0; cnt < 7; cnt++)
            {
                PermissionItem item = new PermissionItem();
                item.CanCreate = true;
                item.CanDelete = true;
                item.CanModify = true;
                item.CanExport = true;
                item.CanEntry = true;
                item.ObjectSn = cnt.ToString();
                item.ObjectId = "7F8FF2CE-659B-4B7F-8B48-FF1778DC4ABC";
                lst.Add(cnt.ToString(), item);
            }
            return lst;
        }
        public Dictionary<string, PermissionItem> WebPermission(bool isOperation, DataSet permission)
        {
            try
            {
                Dictionary<string, PermissionItem> lst = new Dictionary<string, PermissionItem>();
                if (IsDataSetEmpty(permission)) return null;
                foreach(DataRow dr in permission.Tables[0].Rows)
                {
                    lst.Add(
                        (isOperation ? dr["ObjectSn"].ToString() : dr["ObjectId"].ToString())
                        , new PermissionItem(dr));
                }

                if (isOperation)
                {
                    // Add MainPage inside
                    PermissionItem item = new PermissionItem();
                    item.CanCreate = true;
                    item.CanDelete = true;
                    item.CanModify = true;
                    item.CanExport = true;
                    item.CanEntry = true;
                    item.ObjectSn = "0";
                    item.ObjectId = "7F8FF2CE-659B-4B7F-8B48-FF1778DC4ABC";
                    lst.Add("0", item);

                    // Add Setting page inside
                    item = new PermissionItem();
                    item.CanCreate = true;
                    item.CanDelete = true;
                    item.CanModify = true;
                    item.CanExport = true;
                    item.CanEntry = true;
                    item.ObjectSn = "7";
                    item.ObjectId = "7F8FF2CE-659B-4B7F-8B48-FF1778DC4ABC";
                    lst.Add("7", item);
                }
                return lst;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return null;
            }
        }        

        #region DB Controller
        public string GetSortDirection(string column)
        {
            string sortDirect = "ASC";
            if (SysProperty.DataSetSortType)
            {
                SysProperty.DataSetSortType = false;
                sortDirect = "ASC";
            }
            else
            {
                SysProperty.DataSetSortType = true;
                sortDirect = "DESC";
            }
            return sortDirect;
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
                result += (string.IsNullOrEmpty(result) ? string.Empty : ",") + ConditionConverter(obj);
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

                    str = string.IsNullOrEmpty(obj.AttrValue) ? "0" : obj.AttrValue;
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
                    cond += AttrSymbolConverter(obj.AttrSymbol)
                        + (string.IsNullOrEmpty(obj.AttrValue) ? "0" : obj.AttrValue);
                    break;
                case AtrrTypeItem.DateTime:
                case AtrrTypeItem.Date:
                    DateTime tmp = new DateTime();
                    bool result = DateTime.TryParse(obj.AttrValue, out tmp);
                    string reStr = result ? tmp.ToString("yyyy/MM/dd HH:mm:ss") : null;
                    cond += AttrSymbolConverter(obj.AttrSymbol)
                            + (obj.AttrSymbol != AttrSymbolItem.Like
                            ? "N'" + reStr + "'"
                            : "N'%" + reStr + "%'");
                    break;
                case AtrrTypeItem.String:
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
                case MsSqlTable.ConsultLocation:
                    return "ConsultLocation";
                case MsSqlTable.ConsultServiceItem:
                    return "ConsultServiceItem";
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
                case MsSqlTable.ProductSetChurchServiceItem:
                    return "ProductSetChurchServiceItem";
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
                    return "vwEN_Partner";
                case MsSqlTable.SnsMgt:
                    return "SnsMgt";
                case MsSqlTable.vwEN_Consultation:
                    return "vwEN_Consultation";
                case MsSqlTable.ChurchBookingTime:
                    return "ChurchBookingTime";
                case MsSqlTable.WeddingCategory:
                    return "WeddingCategory";
                case MsSqlTable.RentRecord:
                    return "RentRecord";
                case MsSqlTable.StoreLvSetPrice:
                    return "StoreLvSetPrice";
                case MsSqlTable.DressRent:
                    return "DressRent";
                case MsSqlTable.ReceiptDetail:
                    return "ReceiptDetail";
                case MsSqlTable.DressOrder:
                    return "DressOrder";
                case MsSqlTable.PaymentMethod:
                    return "PaymentMethod";
                case MsSqlTable.BuyAutoPass:
                    return "BuyAutoPass";
                case MsSqlTable.BuyRequest:
                    return "BuyRequest";
                case MsSqlTable.BuyStatus:
                    return "BuyStatus";
                case MsSqlTable.BuyStuffCategory:
                    return "BuyStuffCategory";
                default:
                    return string.Empty;

            }
        }
        #endregion
    }
}
