using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheWeLib.DbControl;

namespace TheWeLib
{
    public static class SysProperty
    {
        public static string DbConcString;
        public static string CultureCode;
        public static EmployeeObj EmployeeInfo;        
        public static Logger Log;
        public static GeneralDbDAO GenDbCon;
        public static Utility Util;

        public static bool IsEnglish()
        {
            switch (CultureCode)
            {
                case "zh-TW":
                case "zh-CHT":
                case "zh-CHS":
                case "zh-CN":
                case "zh-HK":
                    return false;
                case "ja-JP":
                    return true;
                default:
                    return true;

            }
        }
    }
}
