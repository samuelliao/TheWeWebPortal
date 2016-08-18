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
    public partial class FittingMaintain : System.Web.UI.Page
    {
        DataSet DS;
        string OtherCondStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.StoreMgtString + " > " + Resources.Resource.AccessoryMaintainString;
                    InitialControls();
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
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkFittingMCreate.Visible = item.CanCreate;
                LinkFittingMCreate.Enabled = item.CanCreate;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
                divStore.Attributes["style"] = "display: inline;";
            }
            else
            {
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
                LinkFittingMCreate.Visible = false;
                LinkFittingMCreate.Enabled = false;
            }
        }
        private void InitialControls()
        {
            FittingCategoryList();
            FittingTypeList(string.Empty);
            StatusList();
            StoreList();
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From Store Where IsDelete=0 Order by GradeLv, Sn";
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlStore.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr) + "(" + dr["Code"].ToString() + ")"
                            , dr["Id"].ToString()));
                    }
                    if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                    {
                        ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void FittingCategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where Type='Accessory' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Description"].ToString()
                    ));
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FittingTypeList(GetTypeNameFromCategory(ddlCategory.SelectedValue));
        }
        private void FittingTypeList(string typeStr)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where IsDelete=0"
                + (string.IsNullOrEmpty(typeStr) ? " And Type not in ('Dress','Accessory')" : " And Type='" + typeStr + "'")
                + " Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds))
            {
                ddlType.Enabled = false;
            }
            else
            {
                ddlType.Enabled = true;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()
                        ));
                }
            }
        }
        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }

        private string GetTypeNameFromCategory(string category)
        {
            if (string.IsNullOrEmpty(category)) return string.Empty;
            if (category.StartsWith("Accessory")) return category.Replace("Accessory", string.Empty);
            if (category.StartsWith("Dress")) return category.Replace("Dress", string.Empty);
            return category;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["FittingCategory"] = ddlCategory.SelectedValue;
            OtherCondStr = string.IsNullOrEmpty(ddlType.SelectedValue) ? string.Empty : " And Category = '" + ddlType.SelectedValue + "'";
            OtherCondStr += string.IsNullOrEmpty(tbSn.Text) ? string.Empty : " And Sn like '%" + tbSn.Text + "%'";
            OtherCondStr += string.IsNullOrEmpty(ddlStatus.SelectedValue) ? string.Empty : "And StatusCode ='" + ddlStatus.SelectedValue + "'";
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                //((Label)e.Item.FindControl("dgLabelCategory")).Text = ddlCategory.Items.FindByValue(Session["FittingCategory"].ToString()).Text;
                ((Label)e.Item.FindControl("dgLabelCategory")).Text = ddlCategory.Items.FindByValue(dataItem1["TypeName"].ToString()).Text;
                if (!string.IsNullOrEmpty(dataItem1["Category"].ToString()))
                {
                    ((Label)e.Item.FindControl("dgLabelType")).Text = ddlType.Items.FindByValue(dataItem1["Category"].ToString()).Text;
                }
                ((Label)e.Item.FindControl("dgLabelRentPrice")).Text = SysProperty.Util.ParseMoney(dataItem1["RentPrice"].ToString()).ToString("#0.00");
                ((Label)e.Item.FindControl("dgLabelSalesPrice")).Text = SysProperty.Util.ParseMoney(dataItem1["SellsPrice"].ToString()).ToString("#0.00");
                if (!string.IsNullOrEmpty(dataItem1["StatusCode"].ToString()))
                {
                    ((Label)e.Item.FindControl("dgLabelStatus")).Text = ddlStatus.Items.FindByValue(dataItem1["StatusCode"].ToString()).Text;
                }
            }
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string str = ((Label)e.Item.FindControl("dgLabelCategory")).Text;
            string tableName = ddlCategory.Items.FindByText(str).Value;
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();

            string sqlTxt = "UPDATE " + tableName + " SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            if (ModifyDataToDb(sqlTxt))
            {
                BindData();
            }
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["FittingId"] = id;
            string str = ((Label)dataGrid.SelectedItem.FindControl("dgLabelCategory")).Text;
            Session["FittingCategory"] = ddlCategory.Items.FindByText(str).Value;
            Response.Redirect("~/StoreMgt/FittingMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (Session["FittingCategory"] == null) return;
            if (DS == null)
            {
                GetFittingList(
                    Session["FittingCategory"].ToString()
                    , OtherCondStr
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        #endregion

        private void BindData()
        {
            GetFittingList(ddlCategory.SelectedValue, OtherCondStr, " Order by Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetFittingList(string tableName, string condStr, string sortStr)
        {
            string sql = string.Empty;
            string storeStr = string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : " And StoreId ='" + ddlStore.SelectedValue + "'";
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                foreach (ListItem item in ddlCategory.Items)
                {
                    if (string.IsNullOrEmpty(item.Value)) continue;
                    sql += string.IsNullOrEmpty(sql) ? string.Empty : " union ";
                    sql += "Select Id, Sn, StoreId, Category, RentPrice, SellsPrice, IsDelete"
                        + ", StatusCode, '" + item.Value + "' As TypeName"
                    + " From " + item.Value + " Where IsDelete = 0 " + storeStr;

                }
                DS = GetDataFromDb("Select * From (" + sql + ")TBL Where IsDelete=0 " + condStr + " " + sortStr);
            }
            else
            {
                sql = "Select Id, Sn, StoreId, Category, RentPrice, SellsPrice, IsDelete"
                    +", StatusCode, '" + ddlCategory.SelectedValue + "' As TypeName"
                    + " From " + tableName + " Where IsDelete = 0 " + storeStr + " " + condStr + " " + sortStr;
                DS = GetDataFromDb(sql);
            }
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
        private bool ModifyDataToDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
    }
}