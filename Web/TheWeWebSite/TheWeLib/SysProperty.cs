using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        public static Hashtable CountryList;
        public static Hashtable AreaList;
    }
}
