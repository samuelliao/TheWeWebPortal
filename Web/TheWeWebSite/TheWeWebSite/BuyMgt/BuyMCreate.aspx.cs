using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.BuyMgt
{
    public partial class BuyMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void InitialPage() { }

        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnSave.Visible = item.CanCreate;
            btnSubmit.Visible = item.CanCreate;
            btnUpload.Visible = item.CanCreate;
            btnAbandon.Visible = item.CanCreate;
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                divApproval.Visible = false;
                
            }
        }

        private void InitialPageControls()
        {
            CategoryList();
            TypeList(ddlCategory.SelectedValue);
            StatusList();
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage(bool reload)
        {
            if (reload)
            {
                InitialPage();
            }
            else
            {
                Session.Remove("BuyId");
                Response.Redirect("BuyMgt.aspx", true);
            }
        }

        #region Button Control
        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAbandon_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        #endregion

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        #region DropDownList Control
        private void CategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("Lv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            ddlCategory.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }

        private void TypeList(string category)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("Lv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "1"));
            if (!string.IsNullOrEmpty(category))
                lst.Add(new DbSearchObject("ParentId", AtrrTypeItem.String, AttrSymbolItem.Equal, category));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString() + ";" + dr["ParentId"].ToString()));
                }
            }
            ddlType.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCategory.Visible = ddlType.SelectedValue == "CreateItem";
            if (ddlCategory.SelectedValue == "CreateItem")
            {
                tbCategory.Text = string.Empty;
            }
            else
            {
                tbCategory.Text = ddlCategory.SelectedItem.Text;
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbType.Visible = ddlType.SelectedValue == "CreateItem";
            if (ddlType.SelectedValue == "CreateItem")
            {
                tbType.Text = string.Empty;
            }
            else
            {
                tbType.Text = ddlType.SelectedItem.Text;
                ddlCategory.SelectedValue = ddlType.SelectedValue.Split(';')[1];
            }
        }

        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStatus), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStatus.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
        }
        #endregion

        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst, string sortStr)
        {
            string sqlTxt = "Select * From " + tableName
                + SysProperty.Util.SqlQueryConditionConverter(lst)
                + " " + sortStr;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private DataSet GetDataFromDb(string tableName, string whereString)
        {
            string sqlTxt = "Select * From " + tableName + whereString;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private Object InvokeDbControlFunction(string sql, bool isSelect)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                if (isSelect)
                    return SysProperty.GenDbCon.GetDataFromTable(sql);
                else
                    return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
    }    
}