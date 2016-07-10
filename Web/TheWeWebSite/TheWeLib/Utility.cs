using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

        public string SqlQuerySelectInstanceConverter(List<string> lst)
        {
            if (lst.Count == 0) return "*";
            string result = string.Empty;
            foreach(string str in lst)
            {
                result += (string.IsNullOrEmpty(str) ? string.Empty : ",") + str;
            }
            return result;
        }

        public string SqlQueryUpdateConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach(DbSearchObject obj in lst)
            {
                result += string.IsNullOrEmpty(result) ? string.Empty : "," + ConditionConverter(obj);
            }
            return result;
        }

        public string SqlQueryInsertInstanceConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach(DbSearchObject obj in lst)
            {
                result += string.IsNullOrEmpty(result) ? string.Empty : "," + obj.AttrName;
            }
            return result;
        }

        public string SqlQueryInsertValueConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string result = string.Empty;
            foreach(DbSearchObject obj in lst)
            {
                result += string.IsNullOrEmpty(result) ? string.Empty : "," + ValueConverter(obj);
            }
            return result;
        }

        public string SqlQueryConditionConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string condStr = string.Empty;
            foreach(DbSearchObject obj in lst)
            {
                condStr += string.IsNullOrEmpty(condStr) ? " Where " : " And " + ConditionConverter(obj);
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
                        + (obj.AttrSymbol == AttrSymbolItem.Like 
                        ? "N'" + obj.AttrValue + "'" 
                        : "N'%" + obj.AttrValue + "%'");
                    break;
            }
            

            return cond;
        }        

        public string AttrSymbolConverter(AttrSymbolItem item)
        {
            switch(item)
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
    }
}
