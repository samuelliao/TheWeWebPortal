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
                    labelPageTitle.Text = Resources.Resource.OrderMgtString + " > " + Resources.Resource.TimetableMaintainString;
                    InitialLabelText();
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
            labelContractStartDate.Text = Resources.Resource.ContractDateString + "(" + Resources.Resource.StartString + ")";
            labelContractEndDate.Text = Resources.Resource.ContractDateString + "(" + Resources.Resource.EndString + ")";
            labelConStartDate.Text = Resources.Resource.MeetingDateString + "(" + Resources.Resource.StartString + ")";
            labelConEndDate.Text = Resources.Resource.MeetingDateString + "(" + Resources.Resource.EndString + ")";
        }

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
            Session["CustomerId"] = id;
            Server.Transfer("CustomerMCreate.aspx", true);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetCaseList("Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression), OtherConditionString);
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
                HyperLink hyperLink1 = (HyperLink)e.Item.FindControl("linkConsult");
                hyperLink1.Text = dataItem1["ConsultSn"].ToString();
                Label label1 = (Label)e.Item.FindControl("labelConsultId");
                label1.Text = dataItem1["ConsultId"].ToString();

                HyperLink hyperLink2 = (HyperLink)e.Item.FindControl("linkContract");
                hyperLink2.Text = dataItem1["Sn"].ToString();

                HyperLink hyperLink3 = (HyperLink)e.Item.FindControl("linkCustomerName");
                hyperLink3.Text = dataItem1["CustomerName"].ToString();
                Label label3 = (Label)e.Item.FindControl("labelCustomerId");
                label3.Text = dataItem1["CustomerId"].ToString();
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
            GetCaseList(storeId, OtherConditionString);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        #region DB Control
        private void GetCaseList(string storeId, string otherCondition)
        {
            string sqlTxt = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                + ",o.[CustomerId],cus.Name AS CustomerName,o.[StatusId], ci.Name As StatusName, ci.JpName AS StatusJpName"
                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId],"
                + "o.[ChurchId],loc.Name AS ChurchName,loc.JpName AS ChurchJpName, loc.CnName As ChurchCnName"
                + ",loc.EngName AS ChurchEngName,[SetId], p.Name AS SetName, p.EngName AS SetEngName,o.Category"
                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,BookingDate,o.PartnerId, pr.Name AS PartnerName"
                + " FROM[TheWe].[dbo].[OrderInfo] as o"
                + " inner join Consultation as c on c.Id = o.ConsultId"
                + " inner join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " inner join Church as loc on loc.Id = o.ChurchId"
                + " inner join ProductSet as p on p.Id = o.SetId"
                + " inner join ConferenceItem as ci on ci.Id = o.StatusId"
                + " inner join vwEN_Partner as pr on pr.Id = o.PartnerId"
                + " WHERE o.IsDelete = 0"
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And o.StoreId='" + storeId + "'")
                + otherCondition;
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
    }
}