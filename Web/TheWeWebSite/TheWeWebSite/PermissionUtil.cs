using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheWeLib;


namespace TheWeWebSite
{
    public class PermissionUtil
    {
        public PermissionItem GetPermissionByKey(object permission, string key)
        {
            if (permission == null) return null;
            Dictionary<string, PermissionItem> lst = permission as Dictionary<string, PermissionItem>;
            if (lst == null) return null;
            if (!lst.ContainsKey(key)) return null;
            return lst[key];
        }

        public string GetOperationSnByPage(string pagePath)
        {
            if (string.IsNullOrEmpty(pagePath)) return "8";
            string pageName = System.IO.Path.GetFileNameWithoutExtension(pagePath);
            return OperationSn(pageName);
        }
        public string OperationSn(string OpName)
        {
            switch (OpName)
            {
                case "Calendar":
                case "Case":
                case "ChurchReservation":
                case "Unsigned":
                case "DressRentMaintain":
                    return "0";
                case "ChurchMaintain":
                case "DressMaintain":
                case "EmployeeMaintain":
                case "FittingMaintain":
                case "ItemMaintain":
                case "ModelingMaintain":
                case "OtherItemMaintain":
                case "ChurchMCreate":
                case "DressMCreate":
                case "EmployeeMCreate":
                case "FittingMCreate":
                case "ItemMCreate":
                case "ModelingMCreate":
                case "OtherItemMCreate":
                    return "1";
                case "AdvisoryMaintain":
                case "CaseMaintain":
                case "CustomerMaintain":
                case "TimeMaintain":
                case "AdvisoryMCreate":
                case "CaseMCreate":
                case "CustomerMCreate":
                case "TimeMCreate":
                    return "2";
                case "AreaMaintain":
                case "CaseRootMaintain":
                case "CountryMaintain":
                case "DollarMaintain":
                case "LoginMaintain":
                case "MsgMaintain":
                case "RootMaintain":
                case "StoreMaintain":
                case "UnitMaintain":
                case "PaymentMethod":
                    return "6";
                case "AccInfoSetting":
                    return "7";
                default:
                    return "8";
            }
        }
    }
}