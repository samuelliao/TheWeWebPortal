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
    public partial class OtherItemMaintain : System.Web.UI.Page
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
                        + " > " + Resources.Resource.WeddingItemMaintainString;
                    InitialOthType();
                    BindData();
                }
            }


        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }

        private void InitialOthType()
        {
            ddlOthCategory.Items.Clear();
            try
            {
                ddlOthCategory.Items.Add(new ListItem(Resources.Resource.TypeSelectRemindString, string.Empty, true));
                string sql = "select DISTINCT Type from ServiceItem where CategroyId='4ec16237-2cb6-496f-ab85-8fa708aa4d55' and IsDelete =0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlOthCategory.Items.Add(
                        new ListItem(
                        dr["Type"].ToString()));
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
            if (!string.IsNullOrEmpty(tbOthSn.Text))
            {
                OtherConditionString += " And a.Sn like '%" + tbOthSn.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbOthName.Text))
            {
                OtherConditionString += " And a.Name like '%" + tbOthName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(ddlOthCategory.SelectedValue))
            {
                OtherConditionString += " And a.Type = '" + ddlOthCategory.SelectedValue + "'";
            }
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["OthId"] = id;
            Server.Transfer("OtherItemMCreate.aspx", true);
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE ServiceItem SET IsDelete = 1"
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
                label.Text = dataItem1["Type"].ToString();
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
                string sql = "select a.[Id],a.[Sn]"
                    + " ,a.[Name],a.[Description],a.[Type],a.[Price]"
                    + " ,a.[SupplierId],a.[Cost],a.[StoreId],a.[CnName]"
                    + " ,a.[EngName],a.[JpName],a.[IsDelete],a.[CategroyId]"
                    + " ,a.[UpdateAccId],a.[UpdateTime]"
                    + " from [TheWe].[dbo].[ServiceItem] as a "
                    + " WHERE a.IsDelete = 0 AND CategroyId='4ec16237-2cb6-496f-ab85-8fa708aa4d55'" + OtherConditionString
                    + (((DataRow)Session["LocateStore"]) == null ? string.Empty
                    : " and c.StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'")
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
