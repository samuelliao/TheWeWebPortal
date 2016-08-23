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
    public partial class DressMaintain : System.Web.UI.Page
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
                    labelPageTitle.Text = Resources.Resource.MainPageString + " > " + Resources.Resource.ContractScheduleString;
                    InitialLabelText();
                    InitialControlWithPermission();
                    InitialAllDropDownList();
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

        #region Permission Related
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                divStore.Attributes["style"] = "display: inline;";
            }
        }
        #endregion

        #region DropDownList
        public void InitialAllDropDownList()
        {
            AreaDropDownList(string.Empty);
            CountryDropDownList();
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
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItemCategory), lst, " Order by TypeLv");
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
            DataSet ds = GetDataFromDb("Store", " Where IsDelete=0 And GradeLv != 0 Order by GradeLv, Sn");
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

        }

        #region DataGrid
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                OtherConditionString += string.IsNullOrEmpty(OtherConditionString) ? " Where " : string.Empty;
                OtherConditionString += string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : "StoreId = '" + ddlStore.SelectedValue + "'";
                OtherConditionString += " Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression);
                GetDressList(
                    bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                    ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString());
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["DressId"] = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Response.Redirect("~/StoreMgt/DressMCreate.aspx");
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

                LinkButton hyperLink1 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink1.Text = dataItem1["ConsultSn"].ToString();
                hyperLink1.CommandArgument = dataItem1["ConsultId"].ToString();
                hyperLink1.Enabled = IsHyperLinkEnable("CaseMCreate");

                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("LinkSn");
                hyperLink2.CommandArgument = dataItem1["Id"].ToString();
                hyperLink2.Text = dataItem1["Sn"].ToString();
                hyperLink2.Enabled = IsHyperLinkEnable("DressMCreate");

                LinkButton hyperLink3 = (LinkButton)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                hyperLink3.CommandArgument = dataItem1["CustomerId"].ToString();
                hyperLink3.Enabled = IsHyperLinkEnable("CustomerMCreate");

                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()))
                    + "("
                    + (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), SysProperty.GetAreaById(dataItem1["AreaId"].ToString()))) + ")"
                    + " " + (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), SysProperty.GetCountryById(dataItem1["CountryId"].ToString()))) +
                    ")";

                ((Label)e.Item.FindControl("labelSet")).Text = ddlCategory.Items.FindByValue(dataItem1["ProjectString"].ToString()).Text;
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

        private void GetDressDataSet()
        {
            OtherConditionString += string.IsNullOrEmpty(OtherConditionString) ? " Where " : string.Empty;
            OtherConditionString += string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : "StoreId = '" + ddlStore.SelectedValue + "'";
            if (OtherConditionString.Trim().Equals("Where")) OtherConditionString = string.Empty;
            GetDressList(OtherConditionString + " Order by StartTime");
            Session["DataSet"] = DS;
        }

        private void BindData()
        {
            if (Session["DataSet"] == null)
            {
                GetDressDataSet();
            }

            DS = Session["DataSet"] as DataSet;
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        #region DB Control
        private void GetDressList(string condStr)
        {
            string sqlTxt = "  Select * From (Select dr.Id, dr.StartTime, dr.EndTime, dr.DressId, dr.OrderId"
                + ", d.Sn as DressSn, d.StatusCode,d.StoreId"
                + ",oi.Sn as OrderSn, oi.CountryId, oi.AreaId, oi.ChurchId, oi.ServiceType"
                + ",c.Sn as CustomerSn,c.Name as CustomerName"
                + " From DressRent as dr"
                + " Left join Dress as d on d.Id = dr.DressId"
                + " Left join OrderInfo as oi on oi.Id = dr.OrderId"
                + " Left join vwEN_Customer as c on c.Id = oi.CustomerId)TBL "
                + condStr;
            DS = (DataSet)GetDataSetFromTable(sqlTxt);
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

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CaseMCreate.aspx");
        }

        protected void linkSn_Click(object sender, EventArgs e)
        {
            Session["DressId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/StoreMgt/DressMCreate.aspx");
        }

        protected void linkCustomerName_Click(object sender, EventArgs e)
        {
            Session["CustomerId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CustomerMCreate.aspx");
        }
    }
}