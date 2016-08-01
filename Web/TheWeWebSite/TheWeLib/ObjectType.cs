using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace TheWeLib
{
    public class PermissionItem
    {
        public bool CanEntry;
        public bool CanCreate;
        public bool CanModify;
        public bool CanDelete;
        public bool CanExport;
        public string ObjectSn;
        public string ObjectId;
        public string Type;
        public string PermissionId;
        public DateTime GetTime;

        public PermissionItem(DataRow dr)
        {
            ObjectSn = dr["ObjectSn"].ToString();
            Type = dr["Type"].ToString();
            ObjectId = dr["ObjectId"].ToString();
            CanEntry = bool.Parse(dr["CanEntry"].ToString());
            CanCreate = bool.Parse(dr["CanCreate"].ToString());
            CanDelete = bool.Parse(dr["CanDelete"].ToString());
            CanModify = bool.Parse(dr["CanModify"].ToString());
            CanExport = bool.Parse(dr["CanExport"].ToString());
            PermissionId = dr["PermissionId"].ToString();
            GetTime = DateTime.Now;
        }
        public PermissionItem() { GetTime = DateTime.Now; }
    }
}
