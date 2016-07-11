using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheWeLib
{
    public static class SysProperty
    {
        public static string DbConcString;
        public static string CultureCode;
        public static EmployeeObj EmployeeInfo;

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
