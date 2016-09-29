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
    public partial class BuyMgt : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.PurchaseMgtString;
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

        #region Page Initialize
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkBuyMCreate.Visible = item.CanCreate;
                LinkBuyMCreate.Enabled = item.CanCreate;
                divStore.Attributes["style"] = "display: inline;";
            }
            else
            {
                LinkBuyMCreate.Visible = false;
                LinkBuyMCreate.Enabled = false;
            }
        }
        private void InitialControls()
        {
            StoreList();
            CategoryList();
            TypeList(ddlCategory.SelectedValue);
            StatusList();

        }
        #endregion

        #region DropDownList Control
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
        private void CategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Select * From BuyStuffCategory Where IsDelete = 0 And Lv = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void TypeList(string categoryId)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string cond = string.IsNullOrEmpty(categoryId) ? string.Empty : " And ParentId = '" + categoryId + "'";
            DataSet ds = GetDataFromDb("Select * From BuyStuffCategory Where IsDelete = 0 And Lv = 1" + cond);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlType.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Select * From BuyStatus Where IsDelete = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeList(ddlCategory.SelectedValue);
        }
        #endregion


        #region DataGrid Control
        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                if (!string.IsNullOrEmpty(dataItem1["CategoryId"].ToString()))
                {
                    ((Label)e.Item.FindControl("dgLabelCategory")).Text = ddlCategory.Items.FindByValue(dataItem1["CategoryId"].ToString()).Text;
                }
                if (!string.IsNullOrEmpty(dataItem1["TypeId"].ToString()))
                {
                    ((Label)e.Item.FindControl("dgLabelType")).Text = ddlCategory.Items.FindByValue(dataItem1["TypeId"].ToString()).Text;
                }
                ((Label)e.Item.FindControl("dgLabelPrice")).Text = SysProperty.Util.ParseMoney(dataItem1["Price"].ToString()).ToString("#0.00");
                if (!string.IsNullOrEmpty(dataItem1["StatusCode"].ToString()))
                {
                    ((Label)e.Item.FindControl("dgLabelStatus")).Text = ddlStatus.Items.FindByValue(dataItem1["StatusCode"].ToString()).Text;
                }
                ((Label)e.Item.FindControl("dgLabelSubmit")).Text = SysProperty.Util.ParseDateTime("DateTime", dataItem1["CreatedateTime"].ToString());
                ((Label)e.Item.FindControl("dgLabelApproval")).Text = SysProperty.Util.ParseDateTime("DateTime", dataItem1["AuditDay"].ToString());
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
            Session["BuyId"] = id;
            Response.Redirect("~/BuyMgt/BuyMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetBuyRequest(
                    ConditionString()
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        #endregion

        #region Button Control
        protected void LinkBuyMCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("BuyId");
            Response.Redirect("~/BuyMgt/BuyMCreate.aspx", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetBuyRequest(ConditionString(), " Order by StoreId, Sn");
            BindData();
        }
        #endregion

        private string ConditionString()
        {
            string str = string.Empty;
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                str += " And Sn like '%" + tbSn.Text + "%'";
            }
            if (!string.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                str += " And StoreId='" + ddlStore.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                str += " And StatusId='" + ddlStatus.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                str += " And CategoryId='" + ddlCategory.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                str += " And TypeId='" + ddlType.SelectedValue + "'";
            }
            return str;
        }

        private void GetBuyRequest(string condStr, string sortStr)
        {
            string sql = "Select * From BuyRequest Where IsDelete = 0 " + condStr + " " + sortStr;
            DS = GetDataFromDb(sql);
        }

        private void BindData()
        {
            if (SysProperty.Util.IsDataSetEmpty(DS))
            {
                GetBuyRequest(ConditionString(), " Order by StoreId, Sn");
            }
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
    }
}