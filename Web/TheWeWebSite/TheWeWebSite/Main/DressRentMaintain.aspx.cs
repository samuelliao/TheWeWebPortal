using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.Main
{
    public partial class DressRentMaintain : System.Web.UI.Page
    {
        DataSet RentData;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialLabelText();
                    labelPageTitle.Text = Resources.Resource.MainPageString + " > " + Resources.Resource.DressRentString;
                    InitialAllDropDownList();
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
        private void InitialLabelText()
        {
            labelContractSearchStartDate.Text = Resources.Resource.StartString;
            labelContractSearchEndDate.Text = Resources.Resource.EndString;
        }

        private void InitialControlWithPermission()
        {
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");            
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {                
                divStore.Attributes["style"] = "display: inline;";
            }
        }

        #region DropDownList
        public void InitialAllDropDownList()
        {
            CountryDropDownList();
            AreaDropDownList(string.Empty);            
            LocationDropDownList(string.Empty, string.Empty);
            ServiceCategoryDropDownList();
            StatusDropDownList();
            StoreList();
        }
        private void ServiceCategoryDropDownList()
        {
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("TypeLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItemCategory), lst, " Order by Type");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem
                    (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Store", " Where IsDelete=0 Order by GradeLv, Sn");
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
        public void CountryDropDownList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        public void AreaDropDownList(string countryId)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                if (!string.IsNullOrEmpty(countryId))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, countryId));
                }
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        public void LocationDropDownList(string countryId, string areaId)
        {
            ddlLocation.Items.Clear();
            ddlLocation.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                if (!string.IsNullOrEmpty(countryId))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, countryId));
                }
                if (!string.IsNullOrEmpty(areaId))
                {
                    lst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, areaId));
                }

                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlLocation.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private void StatusDropDownList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.DressStatusCode)
                    , lst
                    , string.Empty);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStatus.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        #region DropDownList Selected Index Change Control
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaDropDownList(ddlCountry.SelectedValue);
            LocationDropDownList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationDropDownList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }
        #endregion
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region DataGrid
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (RentData == null)
            {
                GetRentData(QueryCondStr()
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (RentData != null)
            {
                dataGrid.DataSource = RentData;
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
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                ((Label)e.Item.FindControl("labelStatus")).Text = ddlStatus.Items.FindByValue(dataItem1["StatusCode"].ToString()).Text;

                if (!string.IsNullOrEmpty(dataItem1["ChurchId"].ToString()))
                {
                    ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                        , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()))
                        + "(" + (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(),
                        SysProperty.GetCountryById(dataItem1["CountryId"].ToString()))) + ")";
                }

                LinkButton hyperLink1 = (LinkButton)e.Item.FindControl("linkDressSn");
                hyperLink1.CommandArgument = dataItem1["DressId"].ToString();
                hyperLink1.Text = dataItem1["DressSn"].ToString();
                hyperLink1.Enabled = IsHyperLinkEnable("DressMCreate");
                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink2.CommandArgument = dataItem1["OrderId"].ToString();
                hyperLink2.Text = dataItem1["OrderSn"].ToString();
                hyperLink2.Enabled = IsHyperLinkEnable("CaseMCreate");
            }
        }

        private bool IsHyperLinkEnable(string pageName)
        {
            PermissionUtil util = new PermissionUtil();
            string sn = util.OperationSn(pageName);
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], sn);
            if (item == null) return false;
            return item.CanEntry;
        }
        #endregion

        private void BindData()
        {
            GetRentData(QueryCondStr(), " Order by d.StartTime DESC");
            dataGrid.DataSource = RentData;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(RentData);
            dataGrid.DataBind();
        }        

        private string QueryCondStr()
        {
            string condStr = string.Empty;
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                condStr += " And d.StatusCode = '" + ddlStatus.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(tbContractSearchStartDate.Text))
            {
                condStr += " And d.StartTime = '" + tbContractSearchStartDate.Text + "'";
            }
            if (!string.IsNullOrEmpty(tbContractSearchEndDate.Text))
            {
                condStr += " And d.EndTime = '" + tbContractSearchEndDate.Text + "'";
            }
            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                condStr += " And o.CountryId = '" + ddlCountry.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
            {
                condStr += " And o.AreaId = '" + ddlArea.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(ddlLocation.SelectedValue))
            {
                condStr += " And o.ChurchId = '" + ddlLocation.SelectedValue + "'";
            }
            if (!String.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                condStr += " And dr.StoreId = '" + ddlStore.SelectedValue + "'";
            }
            return condStr;
        }

        #region DB Control
        private void GetRentData(string condStr, string sortStr)
        {
            string sql = "SELECT d.[Id],[DressId],d.[UpdateTime],d.[UpdateAccId],d.[CreatedateAccId],d.[CreatedateTime],d.[StartTime]"
                + ",[EndTime],d.StatusCode,[OrderId],o.ChurchId,o.Sn As OrderSn,o.CountryId,o.AreaId,dr.StoreId,dr.Sn As DressSn"
                + " FROM [dbo].[DressRent] AS d"
                + " Left join OrderInfo as o on o.Id = d.OrderId"
                + " Left join Dress as dr on dr.Id = d.DressId"
                + " Where d.IsDelete = 0 "
                + condStr
                + sortStr;
            RentData = GetDataSetFromTable(sql);
        }

        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst)
        {
            string sqlTxt = "Select * From " + tableName + SysProperty.Util.SqlQueryConditionConverter(lst);
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
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
        private DataSet GetDataSetFromTable(string sql)
        {
            return (DataSet)InvokeDbControlFunction(sql, true);
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
        #endregion

        protected void linkDressSn_Click(object sender, EventArgs e)
        {
            Session["DressId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/StoreMgt/DressMCreate.aspx");
        }

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CaseMCreate.aspx");
        }
    }
}