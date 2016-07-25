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
                    BindData();
                }
            }
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }

        #region DataGrid Control
        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                string storeId = ((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
                GetCaseList(storeId, "Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
                LinkButton hyperLink1 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink1.Text = dataItem1["ConsultSn"].ToString();
                hyperLink1.CommandArgument = dataItem1["ConsultId"].ToString();

                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("linkContract");
                hyperLink2.CommandArgument = dataItem1["Id"].ToString();
                hyperLink2.Text = dataItem1["Sn"].ToString();

                LinkButton hyperLink3 = (LinkButton)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                hyperLink3.CommandArgument= dataItem1["CustomerId"].ToString();


                ((Label)e.Item.FindControl("labelPartnerName")).Text = dataItem1["PartnerName"].ToString();


                Label label4 = (Label)e.Item.FindControl("labelConference");
                label4.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dataItem1["StatusName"].ToString()
                    , dataItem1["StatusCnName"].ToString()
                    , dataItem1["StatusEngName"].ToString()
                    , dataItem1["StatusJpName"].ToString());

                ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()))
                    + "(" + SysProperty.GetCountryById(dataItem1["CountryId"].ToString()) + ")";

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
            string storeId = ((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            GetCaseList(storeId, string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetCaseList(string storeId, string sortString)
        {
            string sqlTxt = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                + "o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName,o.EmployeeId,e.Name as EmployeeName"
                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                + ",o.TotalPrice"
                + " FROM[TheWe].[dbo].[OrderInfo] as o"
                + " Left join Consultation as c on c.Id = o.ConsultId"
                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " Left join ProductSet as p on p.Id = o.SetId"
                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                + " Left join Employee as e on e.Id = o.EmployeeId"
                + " WHERE o.IsDelete = 0"
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And o.StoreId='" + storeId + "'")
                + " " + sortString;
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

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["ConsultId"] = ((LinkButton)sender).CommandArgument;
            Server.Transfer("~/CaseMgt/AdvisoryMCreate.aspx");
        }

        protected void linkContract_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Server.Transfer("~/CaseMgt/CaseMCreate.aspx");
        }

        protected void linkCustomerName_Click(object sender, EventArgs e)
        {
            Session["CustomerId"] = ((LinkButton)sender).CommandArgument;
            Server.Transfer("~/CaseMgt/CustomerMCreate.aspx");
        }
    }
}