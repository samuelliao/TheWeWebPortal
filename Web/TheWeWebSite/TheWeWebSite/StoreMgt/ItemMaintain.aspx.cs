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
    public partial class ItemMaintain : System.Web.UI.Page
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
                    labelPageTitle.Text = Resources.Resource.StoreMgtString + " > " + Resources.Resource.ProductMaintainString;
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                LinkItemMCreate.Visible = false;
                LinkItemMCreate.Enabled = false;
            }
            else
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkItemMCreate.Visible = item.CanCreate;
                LinkItemMCreate.Enabled = item.CanCreate;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            }
        }

        #region DropDownList Control
        public void InitialAllDropDownList()
        {
            CountryDropDownList();
            AreaDropDownList(string.Empty);
            LocationDropDownList(string.Empty, string.Empty);
            ServiceCategoryDropDownList();
            WeddingTypeDropDownList();
            StoreList();
        }
        private void WeddingTypeDropDownList()
        {
            ddlWeddingType.Items.Clear();
            ddlWeddingType.Items.Add(new ListItem(Resources.Resource.WeddingTypeSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.WeddingCategory), lst);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlWeddingType.Items.Add(new ListItem
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
            DataRow store = (DataRow)Session["LocateStore"];
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            if (bool.Parse(store["HoldingCompany"].ToString()))
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), lst, " Order by Sn");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStore.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            else
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                lst.Add(new DbSearchObject("GradeLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "0"));
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), lst, " Order by Sn");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStore.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), store)
                    , store["Id"].ToString()));
            }

            ddlStore.SelectedValue = store["Id"].ToString();
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

        #region DB Control
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

        #region DataGrid Control
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE ProductSet SET IsDelete = 1"
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

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["SetId"] = id;
            Server.Transfer("ItemMCreate.aspx", true);
        }

        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                ((Label)e.Item.FindControl("labelCountry")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetCountryById(dataItem1["CountryId"].ToString()));
                ((Label)e.Item.FindControl("labelArea")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetAreaById(dataItem1["AreaId"].ToString()));
                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()));
                ((Label)e.Item.FindControl("labelCategroy")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["CategoryName"].ToString()
                    , dataItem1["CategoryCnName"].ToString()
                    , dataItem1["CategoryEngName"].ToString()
                    , dataItem1["CategoryJpName"].ToString());
                ((Label)e.Item.FindControl("labelWeddingStyle")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["TypeName"].ToString()
                    , dataItem1["TypeCnName"].ToString()
                    , dataItem1["TypeEngName"].ToString()
                    , dataItem1["TypeJpName"].ToString());
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    if (!string.IsNullOrEmpty(dataItem1["BaseId"].ToString()))
                    {
                        ((Label)e.Item.FindControl("dgLabelPrice")).Text = SysProperty.Util.ParseMoney(dataItem1["Price"].ToString()).ToString("#0.00");
                    }
                    else
                    {
                        ((Label)e.Item.FindControl("dgLabelPrice")).Text = SysProperty.Util.ParseMoney(dataItem1["LvPrice"].ToString()).ToString("#0.00");
                    }

                    if (dataItem1["StoreId"].ToString() != ((DataRow)Session["LocateStore"])["Id"].ToString())
                    {
                        e.Item.Cells[e.Item.Cells.Count - 1].Controls[0].Visible = false;
                    }
                }
                else
                {
                    ((Label)e.Item.FindControl("dgLabelPrice")).Text = string.Empty;
                }
            }
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetProductList(OtherConditionString,
                    " Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString = string.Empty;
            // Create Case Sn
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                OtherConditionString += " And p.Sn like '%" + tbSn.Text + "%'";
            }

            OtherConditionString += (string.IsNullOrEmpty(ddlCountry.SelectedValue) ? string.Empty : " And p.CountryId = '" + ddlCountry.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlArea.SelectedValue) ? string.Empty : " And p.AreaId = '" + ddlArea.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlLocation.SelectedValue) ? string.Empty : " And p.ChurchId = '" + ddlLocation.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlCategory.SelectedValue) ? string.Empty : " And p.Category = '" + ddlCategory.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlWeddingType.SelectedValue) ? string.Empty : " And p.WeddingCategory = '" + ddlWeddingType.SelectedValue + "'");
            BindData();
        }

        private void BindData()
        {
            GetProductList(OtherConditionString, " Order by st.Sn, p.Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetProductList(string condStr, string sortStr)
        {
            string sqlTxt = "SELECT p.[Id],p.Sn,p.[CountryId],[Decoration],p.[Price],[PriceCurrencyId],[Cost]"
                + ",[CostCurrencyId],[ChurchId],[ChurchCost],p.[IsDelete],p.[UpdateAccId],p.[UpdateTime]"
                + ",p.[Name],p.StoreId, p.BaseId,p.[EngName],p.[JpName],p.[CnName],[Category],[WeddingCategory],p.[AreaId],w.Name as TypeName"
                + ",w.CnName as TypeCnName,w.EngName as TypeEngName,w.JpName as TypeJpName,s.Name as CategoryName"
                + ",s.CnName as CategoryCnName,s.EngName as CategoryEngName,s.JpName as CategoryJpName"
                + ",lv.Price AS LvPrice"
                + " FROM [dbo].[ProductSet] as p"
                + " Left join WeddingCategory as w on w.Id = p.WeddingCategory"
                + " Left join ServiceItemCategory as s on s.Id = p.Category"
                + " Left Join Store as st on st.Id = p.StoreId"
                + " LEFT JOIN StoreLvSetPrice as lv on lv.SetId = p.Id and lv.StoreLv=" + ((DataRow)Session["LocateStore"])["GradeLv"].ToString()
                + " Where p.IsDelete = 0 ";

            sqlTxt += " And p.StoreId in (" + StoreListToString() + ")";
            sqlTxt += " " + condStr;
            sqlTxt += " " + sortStr;
            try
            {
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private string StoreListToString()
        {
            string str = string.Empty;
            if (string.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                foreach (ListItem item in ddlStore.Items)
                {
                    if (string.IsNullOrEmpty(item.Value)) continue;
                    str += string.IsNullOrEmpty(str) ? string.Empty : ",";
                    str += "'" + item.Value + "'";
                }
            }
            else
            {
                str = "'" + ddlStore.SelectedValue + "'";
            }
            return str;
        }
    }
}