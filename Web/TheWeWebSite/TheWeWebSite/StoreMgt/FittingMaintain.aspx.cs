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
            LinkFittingMCreate.Visible = item.CanCreate;
            LinkFittingMCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
        }
        private void InitialControls()
        {
            FittingCategoryList();
            FittingTypeList();
            StatusList();
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
            FittingTypeList();
        }
        private void FittingTypeList()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where IsDelete=0 And Type='"
                + GetTypeNameFromCategory(ddlCategory.SelectedValue) + "' Order by Sn";
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
            if (category.StartsWith("Accessory")) return category.Replace("Accessory", string.Empty);
            if (category.StartsWith("Dress")) return category.Replace("Dress", string.Empty);
            return category;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                Session["FittingCategory"] = ddlCategory.SelectedValue;
                OtherCondStr = string.IsNullOrEmpty(ddlType.SelectedValue) ? string.Empty : " And Category = '" + ddlType.SelectedValue + "'";
                OtherCondStr += string.IsNullOrEmpty(tbSn.Text) ? string.Empty : " And Sn like '%" + tbSn.Text + "%'";
                OtherCondStr += string.IsNullOrEmpty(ddlStatus.SelectedValue) ? string.Empty : "And StatusCode ='" + ddlStatus.SelectedValue + "'";
                BindData();
            }
        }

        #region DataGrid Control
        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null && Session["FittingCategory"] != null)
            {
                ((Label)e.Item.FindControl("dgLabelCategory")).Text = ddlCategory.Items.FindByValue(Session["FittingCategory"].ToString()).Text;
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
            if (Session["FittingCategory"] == null) return;
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE " + Session["FittingCategory"].ToString() + " SET IsDelete = 1"
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
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                GetFittingList(ddlCategory.SelectedValue, OtherCondStr, string.Empty);
                dataGrid.DataSource = DS;
                dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
                dataGrid.DataBind();
            }
        }

        private void GetFittingList(string tableName, string condStr, string sortStr)
        {
            string storeStr = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()) ? string.Empty : " And StoreId ='" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'";
            string sql = "Select * From " + tableName + " Where IsDelete = 0 " + storeStr + " " + condStr + " " + sortStr;
            DS = GetDataFromDb(sql);
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