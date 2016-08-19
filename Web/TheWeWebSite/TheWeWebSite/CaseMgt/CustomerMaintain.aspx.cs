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
    public partial class CustomerMaintain : System.Web.UI.Page
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
                        + " > " + Resources.Resource.CustomerMaintainString;
                    InitialMsgerType();
                    StoreList();
                    InitialControlWithPermission();
                    BindData();
                    TextHint();
                }
            }
        }

        private void TextHint()
        {
            tbMsgId.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.MsgIdString);
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
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            LinkCustomerMCreate.Visible = item.CanCreate;
            LinkCustomerMCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                LinkCustomerMCreate.Visible = false;
                divStore.Attributes["style"] = "display: inline;";
                dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = false;
            }
        }
        private void InitialMsgerType()
        {
            ddlMsgerType.Items.Clear();
            ddlMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            try
            {
                string sql = "Select * From Messenger Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlMsgerType.Items.Add(
                        new ListItem(
                        dr["Name"].ToString()
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            try
            {
                string sql = "SELECT * From Store Where IsDelete=0 And GradeLv != 0 Order by GradeLv, Sn";
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OtherConditionString = string.Empty;
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                OtherConditionString += " And (c.Name like '%" + tbName.Text + "%'"
                    + " or c.EngName like '%" + tbName.Text + "%'"
                    + " or c.Nickname like '%" + tbName.Text + "%')";
            }
            if (!string.IsNullOrEmpty(tbSn.Text))
            {
                OtherConditionString += " And c.Sn like '%" + tbSn.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tbPhone.Text))
            {
                OtherConditionString += " And c.Phone like '%" + tbPhone.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tbMsgId.Text))
            {
                OtherConditionString += " And c.MessengerId like '%" + tbMsgId.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tbEmail.Text))
            {
                OtherConditionString += " And c.Email like '%" + tbEmail.Text + "%'";
            }
            if (!string.IsNullOrEmpty(tbBday.Text))
            {
                OtherConditionString += " And c.Bday like '%" + tbBday.Text + "%'";
            }

            if (!string.IsNullOrEmpty(ddlMsgerType.SelectedValue))
            {
                OtherConditionString += " And c.MessengerType = '" + ddlMsgerType.SelectedValue + "'";
            }
            BindData();
        }

        #region DataGrid Control
        protected void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dataGrid.DataKeys[dataGrid.SelectedIndex].ToString();
            Session["CustomerId"] = id;
            Server.Transfer("CustomerMCreate.aspx", true);
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE Customer SET IsDelete = 1"
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
                GetCustomerList("Order by c." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
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
                ((Label)e.Item.FindControl("labelStore")).Text = ddlStore.Items.FindByValue(dataItem1["StoreId"].ToString()).Text;
                Label label = (Label)e.Item.FindControl("dgLabelMsg");
                label.Text = dataItem1["MessengerId"].ToString() + "(" + dataItem1["MsgerName"].ToString() + ")";
            }
        }
        #endregion

        private void BindData()
        {
            GetCustomerList(" Order by c.Sn");
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        private void GetCustomerList(string sortStr)
        {
            try
            {
                string sql = "SELECT c.[Id],c.Sn,c.Name,c.EngName,c.Nickname"
                    + ",c.Phone,c.Email,c.Bday,m.Name as MsgerName,c.MessengerId"
                    + ",c.[IsDelete],c.UpdateAccId,c.UpdateTime,c.StoreId"
                    + " FROM[TheWe].[dbo].[vwEN_Customer] as c"
                    + " left join Messenger as m on m.Id = c.MessengerType"
                    + " where c.IsDelete = 0 " + OtherConditionString
                    + (string.IsNullOrEmpty(ddlStore.SelectedValue)
                    ? string.Empty
                    : " and c.StoreId = '" + ddlStore.SelectedValue + "'")
                    + " " + sortStr;
                DS = SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }
    }
}