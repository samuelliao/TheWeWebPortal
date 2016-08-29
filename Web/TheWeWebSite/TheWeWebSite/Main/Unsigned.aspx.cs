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
    public partial class Unsigned : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    StoreList();
                    labelPageTitle.Text = Resources.Resource.MainPageString + " > " + Resources.Resource.ConsultScheduleString;
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

        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                LinkButton hyperLink1 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink1.Text = dataItem1["Sn"].ToString();
                hyperLink1.CommandArgument = dataItem1["Id"].ToString();
                hyperLink1.Enabled = IsHyperLinkEnable("AdvisoryMCreate");

                ((Label)e.Item.FindControl("labelIsReply")).Text = bool.Parse(dataItem1["IsReply"].ToString())
                    ? Resources.Resource.YesString : Resources.Resource.NoString;
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

        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["ConsultId"] = id;
            Server.Transfer("AdvisoryMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetConsultList(
                    (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                    ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString())
                    , "Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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


        private void BindData()
        {
            string storeId = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString())
                ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            GetConsultList(storeId, string.Empty);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetConsultList(string storeId, string sortStr)
        {
            string sqlTxt = "SELECT c.[Id],c.[Sn],[EmployeeId],e.Name as EmployeeName"
                + ",[SeekerGender],[BridalName],[BridalEngName],[BridalPhone],[GroomName]"
                + ",[GroomEngName],c.[StatusId],con.Name as StatusName,[LastReceivedDate],c.[Remark]"
                + ",[ConsultDate],[IsReply],[CloseDate],c.[BookingDate],[ContactMethod]"
                + ",c.[Description],c.[IsDelete],c.[UpdateAccId],c.[UpdateTime],c.StoreId"
                + " FROM[TheWe].[dbo].[Consultation] as c"
                + " left join ConferenceItem as con on c.StatusId = con.Id"
                + " left join Employee as e on e.Id = c.EmployeeId"
                + " WHERE c.IsDelete = 0"
                + " And BookingDate >='" + DateTime.Now.ToString("yyyy/MM/dd") + " 00:00:00'"
                + " And BookingDate <='" + DateTime.Now.AddDays(1).ToString("yyyy/MM/dd") + " 00:00:00'"
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And c.StoreId='" + storeId + "'")
                + " " + sortStr;
            try
            {
                DS = (DataSet)InvokeDbControlFunction(sqlTxt, true);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
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

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["ConsultId"] = ((LinkButton)sender).CommandArgument;
            Server.Transfer("~/CaseMgt/AdvisoryMCreate.aspx");
        }
    }
}