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
                    InitialOthCategory();
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
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                LinkOtherItemMCreate.Visible = false;
                LinkOtherItemMCreate.Enabled = false;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
            }
            else
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkOtherItemMCreate.Visible = item.CanCreate;
                LinkOtherItemMCreate.Enabled = item.CanCreate;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            }
        }
        private void InitialOthCategory()
        {
            ddlOthCategory.Items.Clear();
            try
            {
                ddlOthCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty, true));
                string sql = "select * from ServiceItemCategory where TypeLv = 1 and IsDelete =0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlOthCategory.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()));
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
                OtherConditionString += " And a.CategoryId = '" + ddlOthCategory.SelectedValue + "'";
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
                GetOtherItemList("Order by a." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
                Label label = (Label)e.Item.FindControl("dgLabelCategory");
                label.Text = dataItem1["CategoryName"].ToString();
                Label labe2 = (Label)e.Item.FindControl("dgLabelType");
                labe2.Text = dataItem1["TypeName"].ToString();
            }
        }
        
        #endregion

        private void BindData()
        {
            GetOtherItemList(string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetOtherItemList(string sortStr)
        {
            try
            {
                string sql = string.Empty;
                string condStr = string.Empty;
                if (string.IsNullOrEmpty(ddlOthCategory.SelectedValue))
                {
                    condStr = OtherConditionString + " And CategoryId = '4ec16237-2cb6-496f-ab85-8fa708aa4d55'"
                        + (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                            ? string.Empty
                            : " and a.StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'");
                    DS = GetServiceItem(condStr+" And a.IsStore = 1", sortStr);
                    condStr = OtherConditionString + " And IsGeneral = 1";
                    DS.Merge(GetServiceItem(condStr, sortStr));
                }
                else
                {
                    if (ddlOthCategory.SelectedValue == "4ec16237-2cb6-496f-ab85-8fa708aa4d55")
                    {
                        condStr = OtherConditionString
                            + (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                                ? string.Empty
                                : " and a.StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'");
                        DS = GetServiceItem(condStr, sortStr);
                    }
                    else
                    {
                        DS = GetServiceItem(condStr, sortStr);
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }

        private DataSet GetServiceItem(string condStr, string sortStr)
        {
            try
            {
                string sql = "select a.[Id],a.[Sn]"
                        + " ,a.[Name],a.[Description],a.[Type],a.[Price]"
                        + " ,a.[SupplierId],a.[Cost],a.[StoreId],a.[CnName]"
                        + " ,a.[EngName],a.[JpName],a.[IsDelete],a.[CategoryId]"
                        + " ,a.[UpdateAccId],a.[UpdateTime],a.IsGeneral,b.Name as TypeName,c.Name as CategoryName,a.StoreId"
                        + " from  [dbo].[ServiceItem] as a "
                        + " left join ServiceItemCategory as b on b.id=a.Type "
                        + " left join ServiceItemCategory as c on c.id=a.CategoryId"
                        + " WHERE a.IsDelete = 0 " + condStr + " " + sortStr;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        protected void LinkOtherItemMCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("OthId");
            Server.Transfer("OtherItemMCreate.aspx", true);
        }
    }
}
