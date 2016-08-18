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
    public partial class AdvisoryMaintain : System.Web.UI.Page
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
                    labelPageTitle.Text = Resources.Resource.OrderMgtString + " > " + Resources.Resource.ConsultMaintainString;
                    InitialLabelText();
                    StoreList();
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
            labelBookStartDate.Text = Resources.Resource.AppointmentDateString + "(" + Resources.Resource.StartString + ")";
            labelBookEndDate.Text = Resources.Resource.AppointmentDateString + "(" + Resources.Resource.EndString + ")";
            labelSearchStartDate.Text = Resources.Resource.StartDateString + "(" + Resources.Resource.StartString + ")";
            labelSearchStartDate.Text = Resources.Resource.StartDateString + "(" + Resources.Resource.EndString + ")";
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Store", " Where IsDelete=0 And GradeLv != 0");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            LinkAdvisoryMCreate.Visible = item.CanCreate;
            LinkAdvisoryMCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                LinkAdvisoryMCreate.Visible = false;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
                divStore.Attributes["style"] = "display: inline;";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbConsultSn.Text))
            {
                OtherConditionString += " And c.Sn like '%" + tbConsultSn.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbBridalName.Text))
            {
                OtherConditionString += " And (c.BridalName like N'%" + tbBridalName.Text + "%' Or c.BridalEngName like N'%" + tbBridalName.Text + "%')";
            }

            if (!string.IsNullOrEmpty(tbGroomName.Text))
            {
                OtherConditionString += " And (c.GroomName like N'%" + tbGroomName.Text + "%' Or c.GroomEngName like N'%" + tbGroomName.Text + "%')";
            }
            OtherConditionString += ((string.IsNullOrEmpty(tbSearchStartDate.Text)) ? string.Empty : " And c.ConsultDate >='" + tbSearchStartDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbSearchEndDate.Text)) ? string.Empty : " And c.ConsultDate <='" + tbSearchEndDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbBookStartDate.Text)) ? string.Empty : " And c.BookingDate >='" + tbBookStartDate.Text + "'");
            OtherConditionString += ((string.IsNullOrEmpty(tbBookEndDate.Text)) ? string.Empty : " And c.BookingDate <='" + tbBookEndDate.Text + "'");
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE Consultation SET IsDelete = 1"
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
        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
            }
        }
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["ConsultId"] = id;
            Response.Redirect("~/CaseMgt/AdvisoryMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetConsultList(
                    (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()) ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString())
                    , OtherConditionString
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
        #endregion

        private void BindData()
        {
            string storeId = string.IsNullOrEmpty(ddlStore.SelectedValue) ? string.Empty : ddlStore.SelectedValue;
            GetConsultList(storeId, OtherConditionString, " Order by Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        #region DB Control
        private void GetConsultList(string storeId, string otherCondition, string sortStr)
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
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And c.StoreId='" + storeId + "'")
                + otherCondition
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


    }
}