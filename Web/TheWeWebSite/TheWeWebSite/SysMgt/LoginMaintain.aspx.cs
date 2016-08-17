using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.SysMgt
{
    public partial class LoginMaintain : System.Web.UI.Page
    {
        DataSet DS;
        string OtherConditionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.LoginMaintainString;
                    StoreList();
                    BindData();
                }
            }
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From Store Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlStore.SelectedValue) || string.IsNullOrEmpty(tbAccount.Text) || string.IsNullOrEmpty(tbPwd.Text) || string.IsNullOrEmpty(tbPwdConfirm.Text))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            if (tbPwd.Text != tbPwdConfirm.Text)
            {
                ShowErrorMsg(Resources.Resource.AccountOrPasswordErrorString);
                return;
            }

            if (Session["EmployeeId"] == null) return;
            string condStr = Session["EmployeeId"].ToString();
            if (ModifyDataToDb(EmployeeDbObject(), condStr))
            {
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString += string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : " And StoreId='" + ddlStore.SelectedValue + "'";
            OtherConditionString += string.IsNullOrEmpty(tbAccount.Text) ? string.Empty : " And Account = '" + tbAccount.Text + "'";
        }
        #endregion

        #region DataGrid Control
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(((Label)dataGrid.SelectedItem.FindControl("labelStore")).Text))
            {
                ddlStore.SelectedValue = ddlStore.Items.FindByText(((Label)dataGrid.SelectedItem.FindControl("labelStore")).Text).Value;
            }
            cbIsValid.Checked = ((Label)dataGrid.SelectedItem.FindControl("labelIsValid")).Text == Resources.Resource.YesString;
            tbAccount.Text = dataGrid.SelectedItem.Cells[3].Text;
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = string.IsNullOrEmpty(dataItem1["StoreId"].ToString())
                    ? string.Empty : ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                ((Label)e.Item.FindControl("labelIsValid")).Text = bool.Parse(dataItem1["IsValid"].ToString()) 
                    ? Resources.Resource.YesString : Resources.Resource.NoString;
            }
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetEmployeeList(OtherConditionString
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        #endregion

        private void GetEmployeeList(string condStr, string sortStr)
        {
            string sql = "Select * From Employee Where IsDelete = 0 " + condStr + " " + sortStr;
            try
            {
                DS = SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private void BindData()
        {
            GetEmployeeList(OtherConditionString, string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private bool ModifyDataToDb(List<DbSearchObject> lst, string condStr)
        {
            try
            {
                return SysProperty.GenDbCon.UpdateDataIntoTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Employee)
                    , SysProperty.Util.SqlQueryUpdateConverter(lst)
                    , condStr
                    );
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private List<DbSearchObject> EmployeeDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Account"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAccount.Text
                ));
            lst.Add(new DbSearchObject(
                "Password"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , SysProperty.Util.GetMD5(tbPwd.Text)
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "IsValid"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbIsValid.Checked ? "1" : "0"
                ));
            return lst;
        }

        protected void Unnamed_Unload(object sender, EventArgs e)
        {
            if (Session["EmployeeId"] != null) Session.Remove("EmployeeId");
        }
    }
}