using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib.DbControl
{
    public class ApprovalRatingDAO
    {
        DbConn DbConnection;
        Utility Util;

        public ApprovalRatingDAO()
        {
            DbConnection = new DbConn(SysProperty.DbConcString);
            Util = new Utility();
        }

        public ApprovalRatingObj GetApprovalRatingById(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return new ApprovalRatingObj();
                string sqlTxt = "Select * From ApprovalRating Where Id = '" + id + "'";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new ApprovalRatingObj();
                return new ApprovalRatingObj(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                // Output log
                return new ApprovalRatingObj();
            }
        }

        public Dictionary<string, ApprovalRatingObj> GetAllApprovalRating()
        {
            try
            {
                string sqlTxt = "Select * From ApprovalRating";
                DataSet ds = DbConnection.GetDataSet(sqlTxt);
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ApprovalRatingObj>();
                return DataSetConverter(ds);
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, ApprovalRatingObj>();
            }
        }

        public bool InsertApprovalRating(ApprovalRatingObj obj)
        {
            try
            {
                string sqlTxt = "UPDATE [dbo].[ApprovalRating]"
                    + " SET [ObjectId] = '" + obj.ObiectId + "'"
                    + ",[Type] = " + obj.Type
                    + ",[Score] = " + obj.Score
                    + " WHERE Id = '" + obj.Id + "'";
                return DbConnection.ExecSqlText(sqlTxt);

            }
            catch (Exception ex)
            {
                // Output log
                return false;
            }
        }

        public bool UpdateApprovalRating(ApprovalRatingObj obj)
        {
            try
            {
                string sqlTxt = "INSERT INTO [dbo].[ApprovalRating]"
                    + "([ObjectId],[Type],[Score])VALUES("                    
                    + "'" + obj.ObiectId + "'"
                    + "," + obj.Type
                    + "," + obj.Score + ")";
                return DbConnection.ExecSqlText(sqlTxt);
            }
            catch (Exception ex)
            {
                // Output log
                return false;
            }
        }

        public Dictionary<string, ApprovalRatingObj> DataSetConverter(DataSet ds)
        {
            try
            {
                if (Util.IsDataSetEmpty(ds)) return new Dictionary<string, ApprovalRatingObj>();
                Dictionary<string, ApprovalRatingObj> lst = new Dictionary<string, ApprovalRatingObj>();
                ApprovalRatingObj obj = new ApprovalRatingObj();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    obj = new ApprovalRatingObj(dr);
                    if (!string.IsNullOrEmpty(obj.Id))
                        lst.Add(obj.Id, obj);
                }
                return lst;
            }
            catch (Exception ex)
            {
                // Output log
                return new Dictionary<string, ApprovalRatingObj>();
            }
        }
    }
}
