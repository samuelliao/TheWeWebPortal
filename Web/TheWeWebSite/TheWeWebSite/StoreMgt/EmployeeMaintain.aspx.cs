using NLog;
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
    public partial class EmployeeMaintain : System.Web.UI.Page
    {
        DataSet DS;
        private Logger Log;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Log == null)
            {
                Log = NLog.LogManager.GetCurrentClassLogger();
            }
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.EmployeeMaintainString;
                    InitialOthType();
                    InitialStoreList();
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

            bool holder = IsEmployeeStoreHolder(((DataRow)Session["AccountInfo"]));
            if (holder)
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                LinkEmployeeMCreate.Visible = item.CanCreate;
                LinkEmployeeMCreate.Enabled = item.CanCreate;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            }
            else
            {
                LinkEmployeeMCreate.Enabled = false;
                LinkEmployeeMCreate.Visible = false;
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
                dataGrid.Columns[0].Visible = false;
            }

            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                divStore.Attributes["style"] = "display: inline;";
            }
        }
        private bool IsEmployeeStoreHolder(DataRow acc)
        {
            return bool.Parse(acc["StoreHolder"].ToString());
        }
        private void InitialOthType()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                string sql = "select * from Country Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                            , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialStoreList()
        {
            ddlStore.Items.Clear();
            try
            {
                ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty, true));
                string sql = "select * from Store Where IsDelete = 0 Order by GradeLv, Sn";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStore.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                            , dr["Id"].ToString()));
                }

                if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    divStore.Attributes["style"] = "display: inline;";
                    ddlStore.SelectedIndex = 0;
                }
                else
                {
                    divStore.Attributes["style"] = "display: none;";
                    ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
                }                
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dataGrid.CurrentPageIndex = 0;
            BindData();
        }

        private string GetQueryString()
        {
            string OtherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbEmpSn.Text))
            {
                OtherConditionString += " And a.Sn like '%" + tbEmpSn.Text + "%'";
            }

            if (!string.IsNullOrEmpty(tbEmpName.Text))
            {
                OtherConditionString += " And a.Name like '%" + tbEmpName.Text + "%'";
            }

            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                OtherConditionString += " And d.Name ='" + ddlCountry.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(tbEmpTel.Text))
            {
                OtherConditionString += " And a.Phone like '%" + tbEmpTel.Text + "%'";
            }
            return OtherConditionString;
        }

        #region DataGrid Control
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["EmpId"] = id;
            Response.Redirect("~/StoreMgt/EmployeeMCreate.aspx", true);
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE Employee SET IsDelete = 1"
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetEmployeeList("Order by a." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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

                Label labe1 = (Label)e.Item.FindControl("dgLabelStoreId");
                labe1.Text = dataItem1["StoreName"].ToString();

                Label labe2 = (Label)e.Item.FindControl("dgLabelCountry");
                labe2.Text = dataItem1["CountryName"].ToString();
            }

        }
        #endregion

        private void BindData()
        {
            GetEmployeeList(" Order by a.Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetEmployeeList(string sortStr)
        {
            try
            {
                string sql = "select TOP 100 a.[Id],a.[CountryId],d.[Name] as [CountryName] ,a.[Sn],a.[Name],a.[Addr],a.[Phone]"
                    + " ,a.[Bday],a.[OnBoard],a.[QuitDay],a.[Salary],a.[CurrencyId],a.[Remark]"
                    + " ,a.[StoreId],b.[Name] as [StoreName],a.[IsValid],a.[IsDelete], a.Account,a.[StoreHolder]"
                    + " from  [dbo].[vwEN_Employee] as a"
                    + " left join Store as b on b.[Id]=a.[StoreId]"
                    + " left join Country as d on d.[Id]=a.[CountryId]"
                    + " where a.[IsValid]=1 and a.[IsDelete]=0 " + GetQueryString()
                    + (string.IsNullOrEmpty(ddlStore.SelectedValue)
                    ? string.Empty
                    : " and a.[StoreId] = '" + ddlStore.SelectedValue + "'")
                    + " " + sortStr;
                DS = SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }

        protected void LinkEmployeeMCreate_Click(object sender, EventArgs e)
        {
            Session.Remove("EmpId");
            Response.Redirect("~/StoreMgt/EmployeeMCreate.aspx", true);
        }
    }
}
