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
                    HolderCategoryList();
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
        #region DropDownList
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
        private void HolderCategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            ddlCategory.Items.Add(new ListItem(Resources.Resource.StoreString, "Store"));
            ddlCategory.Items.Add(new ListItem(Resources.Resource.LocateString, "Church"));
            ddlCategory.SelectedIndex = 0;
            ddlCategory_SelectedIndexChanged(ddlCategory, new EventArgs());
        }

        private void CountryList(string holder)
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataSetFromTable("Select * From Country Where IsDelete = 0 And Id in (Select Distinct CountryId From " + holder + " Where IsDelete = 0)");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCountry.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void AreaList(string holder, string cid)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string countryCond = " And CountryId ";
            if (!string.IsNullOrEmpty(cid))
            {
                countryCond += " = '" + cid + "'";
            }
            else
            {
                countryCond += "in (Select Distinct CountryId From " + holder + " Where IsDelete = 0)";
            }
            DataSet ds = GetDataSetFromTable("Select * From Area Where IsDelete = 0" + countryCond);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlArea.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void StoreList(bool isStore, string cid, string aid)
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds;
            string condStr = string.Empty;
            if (!string.IsNullOrEmpty(cid))
            {
                condStr += " And CountryId = '" + cid + "'";
            }
            if (!string.IsNullOrEmpty(aid))
            {
                condStr += " And AreaId = '" + aid + "'";
            }
            string sql = " Where IsDelete=0" + condStr;
            if (isStore)
            {
                ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), sql + " Order by Sn");
            }
            else
            {
                ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church), sql + " Order by Sn");
            }
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
            if (isStore)
            {
                ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
                ddlStore_SelectedIndexChanged(ddlStore, new EventArgs());
            }
            //ddlStore.Enabled = false;
        }
        #endregion

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
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                OtherConditionString += " And a.IsStore = " + (ddlCategory.SelectedValue == "Store" ? "1" : "0");
                if (!string.IsNullOrEmpty(ddlStore.SelectedValue))
                {
                    OtherConditionString += " And a." + (ddlCategory.SelectedValue == "Store" ? "StoreId" : "SupplierId") + " = '" + ddlStore.SelectedValue + "'";
                }
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
                ((Label)e.Item.FindControl("labelCategory")).Text = dataItem1["IsStore"].ToString() == "1" ? Resources.Resource.StoreString : Resources.Resource.ChurchString;
                DataRow location = null;
                if (dataItem1["IsStore"].ToString() == "1")
                {
                    location = SysProperty.GetStoreById(dataItem1["SupplierId"].ToString());
                    ((Label)e.Item.FindControl("labelChurch")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), location);
                    ((Label)e.Item.FindControl("labelChurchOth")).Text = location["EngName"].ToString();
                }
                else
                {
                    location = SysProperty.GetChurchById(dataItem1["SupplierId"].ToString());
                    ((Label)e.Item.FindControl("labelChurch")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), location);
                    ((Label)e.Item.FindControl("labelChurchOth")).Text = SysProperty.GetCountryById(location["CountryId"].ToString())["Code"].ToString().Trim() == "JP" ? location["JpName"].ToString() : location["EngName"].ToString();
                }


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
                    condStr = OtherConditionString + " And CategoryId in ('4ec16237-2cb6-496f-ab85-8fa708aa4d55', '907C7E99-73A5-4B2A-8484-FB7BBD0BC1BA')"
                        + (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                            ? string.Empty
                            : " and a.StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'");
                    DS = GetServiceItem(condStr + " And a.IsStore = 1", sortStr);
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
                string sql = "select TOP 100 a.[Id],a.[Sn]"
                        + " ,a.[Name],a.[Description],a.[Type],a.[Price]"
                        + " ,a.[SupplierId],a.[Cost],a.[StoreId],a.[CnName]"
                        + " ,a.[EngName],a.[JpName],a.[IsDelete],a.[CategoryId]"
                        + " ,a.[UpdateAccId],a.[UpdateTime],a.IsGeneral,b.Name as TypeName,c.Name as CategoryName,a.IsStore"
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

        private DataSet GetDataSetFromTable(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
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

        protected void LinkOtherItemMCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("OthId");
            Server.Transfer("OtherItemMCreate.aspx", true);
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaList(ddlCategory.SelectedValue, ddlCountry.SelectedValue);
            StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
            try
            {
                if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                {
                    string countryId = SysProperty.GetAreaById(ddlArea.SelectedValue)["Id"].ToString();
                    if (ddlCountry.SelectedValue != countryId)
                    {
                        ddlCountry.SelectedValue = countryId;
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlStore.SelectedValue))
                {
                    string countryId = string.Empty;
                    string areaId = string.Empty;
                    if (ddlCategory.SelectedValue == "Church")
                    {
                        DataRow dr = SysProperty.GetChurchById(ddlStore.SelectedValue);
                        countryId = dr["CountryId"].ToString();
                        areaId = dr["AreaId"].ToString();
                    }
                    else
                    {
                        DataSet ds = GetDataSetFromTable("Select * From Store Where Id = '" + ddlStore.SelectedValue + "'");
                        if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                        countryId = ds.Tables[0].Rows[0]["CountryId"].ToString();
                        areaId = ds.Tables[0].Rows[0]["AreaId"].ToString();
                    }

                    if (ddlCountry.SelectedValue != countryId)
                    {
                        ddlCountry.SelectedValue = countryId;
                    }
                    if (ddlArea.SelectedValue != areaId)
                    {
                        ddlArea.SelectedValue = areaId;
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                divLocation.Visible = true;
                CountryList(ddlCategory.SelectedValue);
                AreaList(ddlCategory.SelectedValue, ddlCountry.SelectedValue);
                StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
                if(ddlCategory.SelectedValue == "Store")
                {
                    if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                    {
                        LocationDdlControl(false);
                    }
                    else
                    {
                        LocationDdlControl(true);
                    }
                }else
                {
                    LocationDdlControl(true);
                }
            }
            else
            {
                divLocation.Visible = false;
            }
        }

        private void LocationDdlControl(bool enable)
        {
            ddlCountry.Enabled = enable;
            ddlArea.Enabled = enable;
            ddlStore.Enabled = enable;
        }
    }
}
