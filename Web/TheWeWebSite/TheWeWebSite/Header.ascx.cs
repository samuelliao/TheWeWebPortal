using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Timer1.Enabled = true;
            Timer1_Tick(Timer1, new EventArgs());
            SetOperationPermission();
            StoreName();
        }

        public void SetOperationPermission()
        {
            if (Session["Operation"] == null) liSysMgt.Visible = false;
            Dictionary<string, PermissionItem> permission = ((Dictionary<string, PermissionItem>)Session["Operation"]);
            if (permission == null) liSysMgt.Visible = false;
            else
            {
                SetHeaderLink(permission);
                if (!CheckPermission(permission))
                {
                    Response.Redirect("~/Main/Case.aspx");
                }
            }
        }

        private bool CheckPermission(Dictionary<string, PermissionItem> permission)
        {
            PermissionUtil util = new PermissionUtil();
            string sn = util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath);
            PermissionItem item = util.GetPermissionByKey(permission, sn);
            if (item == null) return false;
            return item.CanEntry;
        }

        private void SetHeaderLink(Dictionary<string, PermissionItem> permission)
        {
            foreach (KeyValuePair<string, PermissionItem> item in permission)
            {
                switch (item.Key.ToString())
                {
                    case "1":
                        liStoreMgt.Visible = item.Value.CanEntry;
                        break;
                    case "2":
                        liOrderMgt.Visible = item.Value.CanEntry;
                        break;
                    case "3":
                        liPurchaseMgt.Visible = item.Value.CanEntry;
                        break;
                    case "4":
                        liSalesMgt.Visible = item.Value.CanEntry;
                        break;
                    case "5":
                        liFinMgt.Visible = item.Value.CanEntry;
                        break;
                    case "6":
                        liSysMgt.Visible = item.Value.CanEntry;
                        break;
                }
            }
        }

        public void StoreName()
        {
            if (((DataRow)Session["LocateStore"]) != null)
            {
                labelStoreName.Text = SysProperty.Util.OutputRelatedLangName(
                    ((string)Session["CultureCode"])
                    , ((DataRow)Session["LocateStore"]));
            }
            else labelStoreName.Text = string.Empty;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/Login.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (Session["AccountInfo"] != null)
            {
                string employeeId = ((DataRow)Session["AccountInfo"])["Id"].ToString();
                if (string.IsNullOrEmpty(employeeId)) return;
                DateTime startTime = DateTime.Now;
                DateTime endTime = DateTime.Now.AddHours(1);
                string sql = "Select 'Case' as Type, Id, Sn, BookingDate From OrderInfo Where StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'"
                    + " And BookingDate >= '" + startTime.ToString("yyyy/MM/dd") + " 00:00:00' And BookingDate <= '" + endTime.AddDays(1).ToString("yyyy/MM/dd") + " 00:00:00'";                
                try
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                    linkCaseReminder.Text = Resources.Resource.ContractScheduleString + ": " + ds.Tables[0].Rows.Count;
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                }

                sql = "Select 'Advisory' as Type, Id, Sn, BookingDate From Consultation Where StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'"
                    + " And BookingDate >= '" + startTime.ToString("yyyy/MM/dd") + " 00:00:00' And BookingDate <= '" + endTime.AddDays(1).ToString("yyyy/MM/dd") + " 00:00:00'";
                try
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                    LinkAdvisoryReminder.Text = Resources.Resource.ConsultScheduleString + ": " + ds.Tables[0].Rows.Count;
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                }
            }
            else
            {
                Session.RemoveAll();
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void linkCaseReminder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main/Case.aspx");
        }

        protected void LinkAdvisoryReminder_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Main/Unsigned.aspx");
        }
    }
}