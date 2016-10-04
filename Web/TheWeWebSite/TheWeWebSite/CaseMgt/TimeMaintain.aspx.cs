using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.CaseMgt
{
    public partial class TimeMaintain : System.Web.UI.Page
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
                    InitialControlWithPermission();
                    labelPageTitle.Text = Resources.Resource.OrderMgtString + " > " + Resources.Resource.TimetableMaintainString;
                    InitialLabelText();
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                divStore.Attributes["style"] = "display: inline;";
            }
        }
        private void InitialLabelText()
        {
            labelContractStartDate.Text = Resources.Resource.ContractDateString + "(" + Resources.Resource.StartString + ")";
            labelContractEndDate.Text = Resources.Resource.ContractDateString + "(" + Resources.Resource.EndString + ")";
            labelConStartDate.Text = Resources.Resource.MeetingDateString + "(" + Resources.Resource.StartString + ")";
            labelConEndDate.Text = Resources.Resource.MeetingDateString + "(" + Resources.Resource.EndString + ")";
        }
        #region DropDownList Control
        public void InitialAllDropDownList()
        {
            AreaDropDownList(string.Empty);
            CountryDropDownList();
            LocationDropDownList(string.Empty, string.Empty);
            ProductSetDropDownList();
            StoreList();
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
        private void ProductSetDropDownList()
        {
            ddlProductSet.Items.Clear();
            ddlProductSet.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
                if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlCountry.SelectedValue));
                }
                if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                {
                    lst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlArea.SelectedValue));
                }
                if (!string.IsNullOrEmpty(ddlLocation.SelectedValue))
                {
                    lst.Add(new DbSearchObject("ChurchId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddlLocation.SelectedValue));
                }
                DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ProductSet), lst);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlProductSet.Items.Add(new ListItem
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
            OtherConditionString = string.Empty;
            DataSet ds;
            string tmpStr = string.Empty;
            // Create Case Sn
            if (!string.IsNullOrEmpty(tbCaseSn.Text))
            {
                OtherConditionString += " And Sn like '%" + tbCaseSn.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbBridalName.Text))
            {
                ds = SearchCustomerOrPartnerByName(MsSqlTable.vwEN_Customer, tbBridalName.Text);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    OtherConditionString += " And CustomerId in (";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tmpStr += (string.IsNullOrEmpty(tmpStr) ? string.Empty : ", ")
                            + "'" + dr["Id"].ToString() + "'";
                    }
                    OtherConditionString += tmpStr + ")";
                }
            }

            if (!string.IsNullOrEmpty(tbGroomName.Text))
            {
                ds = SearchCustomerOrPartnerByName(MsSqlTable.vwEN_Partner, tbGroomName.Text);
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    OtherConditionString += " And PartnerId in (";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        tmpStr += (string.IsNullOrEmpty(tmpStr) ? string.Empty : ", ")
                            + "'" + dr["Id"].ToString() + "'";
                    }
                    OtherConditionString += tmpStr + ")";
                }
            }

            OtherConditionString += (string.IsNullOrEmpty(ddlCountry.SelectedValue) ? string.Empty : " And CountryId = '" + ddlCountry.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlArea.SelectedValue) ? string.Empty : " And AreaId = '" + ddlArea.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlLocation.SelectedValue) ? string.Empty : " And ChurchId = '" + ddlLocation.SelectedValue + "'");
            OtherConditionString += (string.IsNullOrEmpty(ddlProductSet.SelectedValue) ? string.Empty : " And SetId = '" + ddlProductSet.SelectedValue + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbContractStartDate.Text)) ? string.Empty : " And StartTime >='" + tbContractStartDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbContractEndDate.Text)) ? string.Empty : " And StartTime <='" + tbContractEndDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbConStartDate.Text)) ? string.Empty : " And BookingDate >='" + tbConStartDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbConEndDate.Text)) ? string.Empty : " And BookingDate <='" + tbConEndDate.Text + "'");
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE OrderInfo SET IsDelete = 1"
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
            Session["OrderId"] = id;
            Response.Redirect("~/CaseMgt/TimeMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                string storeId = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                    ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
                GetCaseList(storeId, OtherConditionString
                    + " Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
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

                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("linkContract");
                hyperLink2.CommandArgument = dataItem1["Id"].ToString();
                hyperLink2.Text = dataItem1["Sn"].ToString();

                LinkButton hyperLink3 = (LinkButton)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                hyperLink3.CommandArgument = dataItem1["CustomerId"].ToString();

                Label label4 = (Label)e.Item.FindControl("labelConference");
                label4.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["StatusName"].ToString()
                    , dataItem1["StatusCnName"].ToString()
                    , dataItem1["StatusEngName"].ToString()
                    , dataItem1["StatusJpName"].ToString());

                ((Label)e.Item.FindControl("labelCountry")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetCountryById(dataItem1["CountryId"].ToString()));
                ((Label)e.Item.FindControl("labelArea")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetAreaById(dataItem1["AreaId"].ToString()));
                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()));

                ((Label)e.Item.FindControl("labelSet")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["SetName"].ToString()
                    , dataItem1["SetCnName"].ToString()
                    , dataItem1["SetEngName"].ToString()
                    , dataItem1["SetJpName"].ToString());
            }
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        private void BindData()
        {
            string storeId = string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : ddlStore.SelectedValue;
            GetCaseList(storeId, OtherConditionString + " Order by Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        #region DB Control
        private void GetCaseList(string storeId, string otherCondition)
        {
            string sqlTxt = SqlQueryByCasePermission(storeId, otherCondition);
            try
            {
                if (string.IsNullOrEmpty(sqlTxt)) DS = null;
                else DS = (DataSet)InvokeDbControlFunction(sqlTxt, true);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        private string SqlQueryByCasePermission(string storeId, string otherCondition)
        {
            string sqlTxt = "";
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                if (Session["CasePermission"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }

                #region Get case permission of normal stores
                Dictionary<string, PermissionItem> lst = Session["CasePermission"] as Dictionary<string, PermissionItem>;
                try
                {
                    if (lst == null || lst.Count == 0)
                    {
                        sqlTxt = "SELECT TOP 100 o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                            + ",o.[CustomerId],cus.Name AS CustomerName,o.[StatusId], ci.Name As StatusName, ci.JpName AS StatusJpName"
                            + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                            + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.StoreId"
                            + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                            + " FROM [dbo].[OrderInfo] as o"
                            + " Left join Consultation as c on c.Id = o.ConsultId"
                            + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                            + " Left join ProductSet as p on p.Id = o.SetId"
                            + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                            + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                            + " WHERE o.IsDelete = 0"
                            + (string.IsNullOrEmpty(storeId) ? string.Empty : " And o.StoreId='" + storeId + "'");
                        //+ otherCondition;
                    }

                    foreach (KeyValuePair<string, PermissionItem> item in lst)
                    {
                        if (item.Value.CanEntry)
                        {
                            sqlTxt += string.IsNullOrEmpty(sqlTxt) ? string.Empty : " Union ";
                            sqlTxt += "SELECT TOP 100 o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                            + ",o.[CustomerId],cus.Name AS CustomerName,o.[StatusId], ci.Name As StatusName, ci.JpName AS StatusJpName"
                            + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                            + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.StoreId"
                            + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                            + " FROM [dbo].[OrderInfo] as o"
                            + " Left join Consultation as c on c.Id = o.ConsultId"
                            + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                            + " Left join ProductSet as p on p.Id = o.SetId"
                            + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                            + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                            + " WHERE o.IsDelete = 0";
                            if (item.Value.Type == "Store")
                            {
                                sqlTxt += " And o.StoreId ='" + item.Value.ObjectId + "'";
                            }
                            else if (item.Value.Type == "Country")
                            {
                                sqlTxt += " And o.CountryId = '" + item.Value.ObjectId + "'";
                            }
                            //sqlTxt += " " + otherCondition;
                        }
                    }
                    return "Select TOP 100 * From (" + sqlTxt + ")TBL " + otherCondition;
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    return string.Empty;
                }
                #endregion
            }
            else
            {
                #region Holding Company
                sqlTxt = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                            + ",o.[CustomerId],cus.Name AS CustomerName,o.[StatusId], ci.Name As StatusName, ci.JpName AS StatusJpName"
                            + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                            + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.StoreId"
                            + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                            + " FROM [dbo].[OrderInfo] as o"
                            + " Left join Consultation as c on c.Id = o.ConsultId"
                            + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                            + " Left join ProductSet as p on p.Id = o.SetId"
                            + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                            + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                            + " WHERE o.IsDelete = 0";
                return "Select * From (" + sqlTxt + ")TBL " + otherCondition;
                #endregion
            }
        }

        private DataSet SearchConsultBySn(string sn)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("Sn", AtrrTypeItem.String, AttrSymbolItem.Like, sn));
            return GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Consultation), lst);
        }

        private DataSet SearchCustomerOrPartnerByName(MsSqlTable table, string name)
        {
            string whereStr = " Where IsDelete = 0"
                + " And Name like '%" + name + "%'"
                + " Or NickName like '%" + name + "%'"
                + " Or EngName like '%" + name + "%'"
                + (table == MsSqlTable.vwEN_Customer ? " Or Account like '%" + name + "%'" : string.Empty);
            return GetDataFromDb(SysProperty.Util.MsSqlTableConverter(table), whereStr);
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
                return null;
            }
        }
        #endregion

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["ConsultId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/AdvisoryMCreate.aspx");
        }

        protected void linkContract_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CaseMCreate.aspx");
        }

        protected void linkCustomerName_Click(object sender, EventArgs e)
        {
            Session["CustomerId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CustomerMCreate.aspx");
        }
    }
}