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
    public partial class Calendar : System.Web.UI.Page
    {
        DataSet CalendarSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.MainPageString
                        + " > " + Resources.Resource.ScheduleString;
                    InitialControl();
                    //InitialCalendarSechdule();
                }
            }        
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }


        private void InitialControl()
        {
            string storeId = Session["LocateStore"] == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            EmployeeList(storeId);
            calendar.SelectedDate = DateTime.Now;

        }

        private void EmployeeList(string storeId)
        {
            tvEmployee.Nodes.Clear();
            string sql = "Select * From vwEN_Employee Where IsDelete=0 "
                + (string.IsNullOrEmpty(storeId) ? string.Empty : "And StoreId='" + storeId + "'");
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            string selectedNodeValue = Session["EmployeeId"] == null ? string.Empty : Session["EmployeeId"].ToString();
            TreeNode node = new TreeNode();
            node.Text = SysProperty.Util.OutputRelatedLangName(
                    ((string)Session["CultureCode"])
                    , ((DataRow)Session["LocateStore"]));
            node.Value = string.Empty;
            if (string.IsNullOrEmpty(selectedNodeValue)) node.Selected = true;
            tvEmployee.Nodes.Add(node);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                node = new TreeNode(dr["Account"].ToString() + "(" + dr["Name"].ToString() + ")", dr["Id"].ToString());
                if (selectedNodeValue == node.Value) node.Selected = true;
                tvEmployee.Nodes.Add(node);
            }
            
        }

        private void InitialCalendarSechdule()
        {
            string storeId = Session["LocateStore"] == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
            string employeeId = Session["EmployeeId"] == null ? string.Empty : Session["EmployeeId"].ToString();
            CalendarSet = GetCalendarData(storeId, employeeId);
        }        

        protected void tvEmployee_SelectedNodeChanged(object sender, EventArgs e)
        {
            string id = tvEmployee.SelectedValue;
            Session["EmployeeId"] = id;
            //InitialCalendarSechdule();
            this.Load += this.Page_Load;
            //Response.Redirect("~/Main/Calendar.aspx");
        }

        #region Calendar Control
        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            Session["ChoseMonth"] = e.NewDate;
            //InitialCalendarSechdule();
        }
        protected void calendar_PreRender(object sender, EventArgs e)
        {
            InitialCalendarSechdule();
        }
        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsToday) calendar.SelectedDate = e.Day.Date;
            if (!SysProperty.Util.IsDataSetEmpty(CalendarSet))
            {
                foreach (DataRow dr in CalendarSet.Tables[0].Select("BookingDate='" + e.Day.Date + "'"))
                {
                    if (string.IsNullOrEmpty(dr["BookingDate"].ToString())) continue;
                    LinkButton link = new LinkButton();
                    link.Text = dr["Name"].ToString() + " "
                        + SysProperty.Util.OutputRelatedLangName(
                            Session["CultureCode"].ToString()
                            , dr["StatusName"].ToString()
                            , dr["StatusCnName"].ToString()
                            , dr["StatusEngName"].ToString()
                            , dr["StatusJpName"].ToString());
                    link.ToolTip = dr["Hint"].ToString();
                    link.CommandArgument = dr["Type"].ToString() + ";" + dr["Id"].ToString();
                    link.Font.Size = FontUnit.Small;
                    link.Click += new EventHandler(linkConsult_Click);
                    e.Cell.Controls.Add(link);//將這些Link擺入對應得日期cell內
                }
            }
        }
        #endregion

        #region DB Control
        private DataSet GetCalendarData(string storeId, string employeeId)
        {
            string currentMonth = string.Empty;
            string nextMonth = string.Empty;
            if (Session["ChoseMonth"] == null)
            {
                currentMonth = DateTime.Now.ToString("yyyy/MM") + "/01";
                nextMonth = DateTime.Now.AddMonths(1).ToString("yyyy/MM") + "/01";
            }
            else
            {
                DateTime tmp = (DateTime)Session["ChoseMonth"];
                currentMonth = tmp.ToString("yyyy/MM") + "/01";
                nextMonth = tmp.AddMonths(1).ToString("yyyy/MM") + "/01";
            }
            string condStr = " Where c.IsDelete=0 "
                + (string.IsNullOrEmpty(storeId) ? string.Empty : "And c.StoreId='" + storeId + "'")
                + (string.IsNullOrEmpty(employeeId) ? string.Empty : "And c.EmployeeId='" + employeeId + "'")
                + " And c.BookingDate >= '" + currentMonth + "' And c.BookingDate < '" + nextMonth + "'";
            // Get Advisory Schedule Data
            string sql = "select c.Id,c.Sn as Hint,BridalName as Name,BookingDate,c.EmployeeId"
                + ",c.StatusId,'Consultation' as Type,c.StoreId"
                + ",ci.Name as StatusName,ci.CnName as StatusCnName,ci.EngName as StatusEngName,ci.JpName as StatusJpName";
            sql += " From Consultation as c";
            sql += " Left join ConferenceItem as ci on ci.Id=c.StatusId";
            sql += condStr;
            // Get Case Schedule Data
            sql += " Union";
            sql += " select c.Id,c.Sn as Hint,i.Name as Name,BookingDate,c.EmployeeId"
                + ",c.ConferenceCategory as StatusId,'Order' as Type,c.StoreId"
            + ",ci.Name as StatusName,ci.CnName as StatusCnName,ci.EngName as StatusEngName,ci.JpName as StatusJpName";
            sql += " From OrderInfo as c";
            sql += " Left join vwEN_Customer as i on i.Id = c.CustomerId";
            sql += " Left join ConferenceItem as ci on ci.Id=c.ConferenceCategory";
            sql += condStr;
            // Get Employee Schedule Data
            sql += " union";
            sql += " select c.Id,c.EventDescription,c.EventTitle as Name,c.EventStartTime"
                + ",c.EmployeeId,c.EventType as StatusId,'Schedule' as Type,c.StoreId"
                + ",ci.Name as StatusName,ci.CnName as StatusCnName,ci.EngName as StatusEngName,ci.JpName as StatusJpName";
            sql += " From ScheduleEmployee as c";
            sql += " Left join  ScheduleItemCategory as ci on ci.Id=c.EventType";
            sql += condStr.Replace("BookingDate", "EventStartTime");
            return GetDataFromDb(sql);
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
        private DataSet GetDataFromDb(string sql)
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