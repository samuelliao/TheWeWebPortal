using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.StoreMgt
{
    public partial class ModelingMaintain : System.Web.UI.Page
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
                    labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.StyleMaintainString;
                    InitialHairCategory();
                    InitialControlWithPermission();
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
            LinkModelingMCreate.Visible = item.CanCreate;
            LinkModelingMCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
        }
        private void InitialHairCategory()
        {
            ddlCategory.Items.Clear();
            try
            {
                ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty, true));
                string sql = "select * from HairStyleCategory";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(
                        new ListItem(
                        dr["Name"].ToString()
                        ,  dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                OtherConditionString += " And a.Sn like '%" + tbSn.Text + "%'";
            }

            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                OtherConditionString += " And a.Type = '" + ddlCategory.SelectedValue + "'";
            }
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["ModelingId"] = id;
            Server.Transfer("ModelingMCreate.aspx", true);
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE HairStyleItem SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            try
            {
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetCustomerList("Order by a." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
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
                Label label = (Label)e.Item.FindControl("dgLabelType");
                label.Text = dataItem1["Name"].ToString();
            }
        }
        #endregion

        private void BindData()
        {
            GetCustomerList(string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetCustomerList(string sortStr)
        {
            try
            {
                string sql = "select a.[Id],a.[Sn],b.[Name],a.[Type],a.[Img],a.[IsDelete],a.[UpdateAccId],a.[UpdateTime],a.[Description],a.[Img]"
                    + " from [TheWe].[dbo].[HairStyleItem] as a "
                    + " left join HairStyleCategory as b on b.Id=a.Type"
                    + " where a.IsDelete =0" + OtherConditionString
                    + (((DataRow)Session["LocateStore"]) == null ? string.Empty
                    : " and a.StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'")
                    + " " + sortStr;
                DS = SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }
    }
}
