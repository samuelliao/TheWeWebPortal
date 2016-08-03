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
    public partial class ChurchReservation : System.Web.UI.Page
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
                        + " > " + Resources.Resource.LocationReservationString;
                    InitialControl();
                    InitialCalendarSechdule();
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
            ChurchList();
            calendar.SelectedDate = DateTime.Now;

        }

        private void ChurchList()
        {
            string churchId = Session["ChurchId"] == null ? string.Empty : Session["ChurchId"].ToString();
            tvChurch.Nodes.Clear();
            TreeNode node1 = new TreeNode(Resources.Resource.LocateString, string.Empty);
            if (string.IsNullOrEmpty(churchId)) node1.Selected = true;
            tvChurch.Nodes.Add(node1);

            string sql = "Select * From Church Where IsDelete=0 Order by CountryId, AreaId";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;

            TreeNode node2 = new TreeNode();
            TreeNode leaf = new TreeNode();
            DataTable countryLst = ds.Tables[0].DefaultView.ToTable(true, "CountryId");
            DataTable areaLst = ds.Tables[0].DefaultView.ToTable(true, new string[] { "CountryId", "AreaId" });
            foreach (DataRow country in countryLst.Rows)
            {
                node1 = new TreeNode(
                    SysProperty.Util.OutputRelatedLangName(
                        Session["CultureCode"].ToString(),
                        SysProperty.GetCountryById(country["CountryId"].ToString()))
                        , "Country;"+country["CountryId"].ToString());
                foreach (DataRow area in areaLst.Select("CountryId='" + country["CountryId"].ToString() + "'"))
                {
                    node2 = new TreeNode(
                    SysProperty.Util.OutputRelatedLangName(
                        Session["CultureCode"].ToString(),
                        SysProperty.GetAreaById(area["AreaId"].ToString()))
                        , "Area;" + area["AreaId"].ToString());
                    foreach (DataRow dr in ds.Tables[0].Select("CountryId='" + area["CountryId"].ToString() + "' And AreaId = '" + area["AreaId"].ToString() + "'"))
                    {
                        leaf = new TreeNode(
                            SysProperty.Util.OutputRelatedLangName(
                                Session["CultureCode"].ToString(), dr)
                                , "Church;" + dr["Id"].ToString());
                        if (churchId == leaf.Value) leaf.Selected = true;
                        node2.ChildNodes.Add(leaf);
                    }
                    node1.ChildNodes.Add(node2);
                }
                tvChurch.Nodes.Add(node1);
            }
        }

        protected void tvChurch_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (tvChurch.SelectedValue.Contains(";"))
            {
                string[] value = tvChurch.SelectedValue.Split(';');
                Session["PermissionItem"] = value[0];
                Session["ChurchId"] = value[1];
            }
            //InitialCalendarSechdule();
            this.Load += this.Page_Load;
            //Response.Redirect("~/Main/Calendar.aspx");
        }
        private void InitialCalendarSechdule()
        {
            string churchId = Session["ChurchId"] == null ? string.Empty : Session["ChurchId"].ToString();
            string type = Session["PermissionItem"] == null ? string.Empty : Session["PermissionItem"].ToString();
            CalendarSet = GetCalendarData(type, churchId);
        }

        #region Calendar Control
        protected void calendar_PreRender(object sender, EventArgs e)
        {
            InitialCalendarSechdule();
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsToday) calendar.SelectedDate = e.Day.Date;
            if (!SysProperty.Util.IsDataSetEmpty(CalendarSet))
            {
                string condStr = "OverseaWeddingDate = '" + e.Day.Date + "'"
                    + " OR OverseaFilmDate='" + e.Day.Date + "'"
                    + " OR LocalWeddingDate='" + e.Day.Date + "'"
                    + " OR LocalFilmingDate='" + e.Day.Date + "'";
                foreach (DataRow dr in CalendarSet.Tables[0].Select(condStr))
                {
                    LinkButton link = new LinkButton();
                    string store = SysProperty.Util.OutputRelatedLangName(
                            Session["CultureCode"].ToString()
                            , dr["StoreName"].ToString()
                            , dr["StoreCnName"].ToString()
                            , dr["StoreEngName"].ToString()
                            , dr["StoreJpName"].ToString());
                    string type = SysProperty.Util.OutputRelatedLangName(
                            Session["CultureCode"].ToString()
                            , dr["TypeName"].ToString()
                            , dr["TypeCnName"].ToString()
                            , dr["TypeEngName"].ToString()
                            , dr["TypeJpName"].ToString());
                    link.Text = store + " " + type;
                    link.ToolTip = SysProperty.Util.OutputRelatedLangName(
                            Session["CultureCode"].ToString()
                            , dr["ChurchName"].ToString()
                            , dr["ChurchCnName"].ToString()
                            , dr["ChurchEngName"].ToString()
                            , dr["ChurchJpName"].ToString());
                    link.CommandArgument = dr["Id"].ToString();
                    link.Font.Size = FontUnit.Small;
                    e.Cell.Controls.Add(link);//將這些Link擺入對應得日期cell內
                }
            }
        }

        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            Session["ChoseMonth"] = e.NewDate;
        }
        #endregion

        #region DB Control
        private DataSet GetCalendarData(string type, string churchId)
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
            string condStr = " Where o.IsDelete=0 And ChurchId is not null "
                + (string.IsNullOrEmpty(churchId) ? string.Empty : "And o."+ type + "Id='" + churchId + "'")
                + " And ( (OverseaWeddingDate>='" + currentMonth + "' AND OverseaWeddingDate<'" + nextMonth + "')"
                + " OR(OverseaFilmDate >= '" + currentMonth + "' AND OverseaFilmDate < '" + nextMonth + "')"
                + " OR(LocalWeddingDate >= '" + currentMonth + "' AND LocalWeddingDate < '" + nextMonth + "')"
                + " OR(LocalFilmingDate >= '" + currentMonth + "' AND LocalFilmingDate < '" + nextMonth + "'))";
            // Get Advisory Schedule Data
            string sql = "select o.Id,o.Sn,o.ServiceType, o.CountryId, o.AreaId, o.ChurchId, o.LocalFilmingDate, o.LocalWeddingDate, o.OverseaFilmDate, o.OverseaWeddingDate"
                + ",c.Name as ChurchName,c.CnName as ChurchCnName,c.EngName as ChurchEngName,c.JpName as ChurchJpName"
                + ",sic.Name as TypeName,sic.CnName as TypeCnName,sic.EngName as TypeEngName,sic.JpName as TypeJpName, sic.Sn as TypeSn"
                + ",s.Name as StoreName,s.CnName as StoreCnName,s.EngName as StoreEngName,s.JpName as StoreJpName"
                + " From OrderInfo as o"
                + " Left join Store as s on s.Id = o.StoreId"
                + " Left join ServiceItemCategory as sic on sic.Id = o.ServiceType"
                + " Left join Church as c on c.Id = o.ChurchId";
            sql += condStr;
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
    }
}