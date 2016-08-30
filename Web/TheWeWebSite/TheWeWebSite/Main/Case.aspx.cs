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
    public partial class Case : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.MainPageString + " > " + Resources.Resource.ContractScheduleString;
                    StoreList();
                    BindData();
                }
            }
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
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

        #region DataGrid Control
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                string storeId = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                    ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
                GetCaseList(storeId, "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
                hyperLink1.Enabled = IsHyperLinkEnable("AdvisoryMCreate");

                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("linkContract");
                hyperLink2.CommandArgument = dataItem1["Id"].ToString();
                hyperLink2.Text = dataItem1["Sn"].ToString();
                hyperLink2.Enabled = IsHyperLinkEnable("CaseMCreate");

                LinkButton hyperLink3 = (LinkButton)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                hyperLink3.CommandArgument = dataItem1["CustomerId"].ToString();
                hyperLink3.Enabled = IsHyperLinkEnable("CustomerMCreate");

                ((Label)e.Item.FindControl("labelPartnerName")).Text = dataItem1["PartnerName"].ToString();


                Label label4 = (Label)e.Item.FindControl("labelConference");
                label4.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["StatusName"].ToString()
                    , dataItem1["StatusCnName"].ToString()
                    , dataItem1["StatusEngName"].ToString()
                    , dataItem1["StatusJpName"].ToString());

                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()))
                    + "(" + (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(),
                    SysProperty.GetCountryById(dataItem1["CountryId"].ToString()))) + ")";

                ((Label)e.Item.FindControl("labelSet")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["SetName"].ToString()
                    , dataItem1["SetCnName"].ToString()
                    , dataItem1["SetEngName"].ToString()
                    , dataItem1["SetJpName"].ToString());
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

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        private void BindData()
        {
            string storeId = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            GetCaseList(storeId, " Order by Sn DESC");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetCaseList(string storeId, string sortString)
        {
            string sqlTxt = SqlQueryByCasePermission(storeId, sortString);
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

        private string SqlQueryByCasePermission(string storeId, string otherCondition)
        {
            string sqlTxt = "";
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                if (Session["CasePermission"] == null) Response.Redirect("~/Login.aspx");
                Dictionary<string, PermissionItem> lst = Session["CasePermission"] as Dictionary<string, PermissionItem>;
                try
                {
                    if (lst == null || lst.Count == 0)
                    {
                        sqlTxt = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                            + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                            + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                            + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.EmployeeId,e.Name as EmployeeName"
                            + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                            + ",o.TotalPrice,o.StoreId"
                            + " FROM [dbo].[OrderInfo] as o"
                            + " Left join Consultation as c on c.Id = o.ConsultId"
                            + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                            + " Left join ProductSet as p on p.Id = o.SetId"
                            + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                            + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                            + " Left join Employee as e on e.Id = o.EmployeeId"
                            + " WHERE o.IsDelete = 0"
                            + " And o.BookingDate >='" + DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00'"
                            + " And o.BookingDate <='" + DateTime.Now.AddDays(1).ToString("yyyy/MM/dd") + " 00:00:00'"
                            + (string.IsNullOrEmpty(storeId) ? string.Empty : " And o.StoreId='" + storeId + "'");
                    }

                    foreach (KeyValuePair<string, PermissionItem> item in lst)
                    {
                        if (item.Value.CanEntry)
                        {
                            sqlTxt += string.IsNullOrEmpty(sqlTxt) ? string.Empty : " Union ";
                            sqlTxt += "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                                + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                                + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.EmployeeId,e.Name as EmployeeName"
                                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                                + ",o.TotalPrice,o.StoreId"
                                + " FROM [dbo].[OrderInfo] as o"
                                + " Left join Consultation as c on c.Id = o.ConsultId"
                                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                                + " Left join ProductSet as p on p.Id = o.SetId"
                                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                                + " Left join Employee as e on e.Id = o.EmployeeId"
                                + " WHERE o.IsDelete = 0" 
                                + " And o.BookingDate >='" + DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00'"
                                + " And o.BookingDate <='" + DateTime.Now.AddDays(1).ToString("yyyy/MM/dd") + " 00:00:00'";
                            if (item.Value.Type == "Store")
                            {
                                sqlTxt += " And o.StoreId ='" + item.Value.ObjectId + "'";
                            }
                            else if (item.Value.Type == "Country")
                            {
                                sqlTxt += " And o.CountryId = '" + item.Value.ObjectId + "'";
                            }
                        }
                    }

                    return "Select * From (" + sqlTxt + ")TBL " + otherCondition;
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    return string.Empty;
                }
            }
            else
            {
                sqlTxt = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                            + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                            + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                            + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.EmployeeId,e.Name as EmployeeName"
                            + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                            + ",o.TotalPrice,o.StoreId"
                            + " FROM [dbo].[OrderInfo] as o"
                            + " Left join Consultation as c on c.Id = o.ConsultId"
                            + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                            + " Left join ProductSet as p on p.Id = o.SetId"
                            + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                            + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                            + " Left join Employee as e on e.Id = o.EmployeeId"
                            + " WHERE o.IsDelete = 0";
                return "Select * From (" + sqlTxt + ")TBL " + otherCondition;
            }
        }

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