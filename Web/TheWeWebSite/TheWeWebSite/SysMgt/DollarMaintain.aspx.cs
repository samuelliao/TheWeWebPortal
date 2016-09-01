using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.SysMgt
{
    public partial class DollarMaintain : System.Web.UI.Page
    {
        private DataSet CurrencyDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.CurrencyString;
                    InitialControlWithPermission();
                    BindData();
                }
            }
        }

        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            dgCurrency.Columns[dgCurrency.Columns.Count - 1].Visible = item.CanDelete;
            dgCurrency.Columns[dgCurrency.Columns.Count - 2].Visible = item.CanModify;
        }
        #region
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrency.Text) || string.IsNullOrEmpty(tbRate.Text))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCurrency.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                );
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
            "CreatedateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
            ));
            lst.Add(new DbSearchObject(
                "Rate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRate.Text)
                );
            try
            {
                if (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                {
                    BindData();
                    tbCurrency.Text = string.Empty;
                    tbRate.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbCurrency.Text = string.Empty;
            tbRate.Text = string.Empty;
        }
        #endregion

        private void BindData()
        {
            GetCurrencyList(string.Empty);
            dgCurrency.DataSource = CurrencyDataSet;
            dgCurrency.AllowPaging = !SysProperty.Util.IsDataSetEmpty(CurrencyDataSet);
            dgCurrency.DataBind();
        }

        private void GetCurrencyList(string sortString)
        {
            try
            {
                string sqlTxt = "SELECT c.[Id],c.Name,Rate,c.UpdateAccId,c.UpdateTime,c.IsDelete,e.Name as EmployeeName"
                    + " FROM [dbo].[Currency] as c"
                    + " inner join Employee as e on e.Id = c.UpdateAccId"
                    + " WHERE c.IsDelete = 0 " + sortString;
                CurrencyDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                CurrencyDataSet = null;
            }
        }

        #region DataGrid Control
        protected void dgCurrency_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgCurrency.EditItemIndex = -1;
            BindData();
        }

        protected void dgCurrency_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgCurrency.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE [dbo].[Currency] SET IsDelete = 1"
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

        protected void dgCurrency_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgCurrency.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dgCurrency_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgCurrency.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgCurrency_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("Rate", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].FindControl("tbRate")).Text));
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            try
            {
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgCurrency.DataKeys[dgCurrency.EditItemIndex].ToString() + "'"))
                {
                    dgCurrency.EditItemIndex = -1;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgCurrency_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (CurrencyDataSet == null)
            {
                GetCurrencyList("Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (CurrencyDataSet != null)
            {
                dgCurrency.DataSource = CurrencyDataSet;
                dgCurrency.DataBind();
            }
        }
        #endregion

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }

        protected void dgCurrency_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    TextBox text = (TextBox)e.Item.FindControl("tbRate");
                    text.Text = SysProperty.Util.ParseMoney(dataItem1["Rate"].ToString()).ToString("#0.00");
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("labelRate");
                    label.Text = SysProperty.Util.ParseMoney(dataItem1["Rate"].ToString()).ToString("#0.00");
                }
            }
        }
    }
}