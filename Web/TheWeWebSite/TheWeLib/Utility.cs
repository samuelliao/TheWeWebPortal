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
    }
}
