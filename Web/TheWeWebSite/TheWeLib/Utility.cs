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

        public string SqlQueryConditionConverter(List<DbSearchObject> lst)
        {
            if (lst.Count == 0) return string.Empty;
            string condStr = string.Empty;
            foreach(DbSearchObject obj in lst)
            {
                if (string.IsNullOrEmpty(condStr))
                    condStr += " Where ";
                else condStr += " And ";
            }
            return condStr;
        }

        private string ConditionConverter(DbSearchObject obj)
        {
            if (obj == null) return string.Empty;
            string cond = string.Empty;
            switch (obj.AttrType)
            {
                case AtrrTypeItem.Integer:
                case AtrrTypeItem.Bit:
                case AtrrTypeItem.DateTime:
                case AtrrTypeItem.Date:
                    cond += AttrSymbolConverter(obj.AttrSymbol) + obj.AttrValue;
                    break;
                case AtrrTypeItem.String:
                default:
                    cond += AttrSymbolConverter(obj.AttrSymbol)
                        + (obj.AttrSymbol == AttrSymbolItem.Like 
                        ? "'" + obj.AttrValue + "'" 
                        : "'%" + obj.AttrValue + "%'");
                    break;
            }
            cond = obj.AttrName;

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
