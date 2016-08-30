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
    public partial class MsgMaintain : System.Web.UI.Page
    {
        private DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.SNSMgtString;
                    InitialControlWithPermission();
                    BindData(string.Empty);
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            dataGrid.Columns[dataGrid.Columns.Count - 1].Visible = item.CanDelete;
            dataGrid.Columns[dataGrid.Columns.Count - 2].Visible = item.CanModify;
        }
        public void GetSnsList(string sortString)
        {
            try
            {
                string sqlTxt = "SELECT s.[Id],s.Name,s.SnsContent,s.UpdateAccId,s.UpdateTime,e.Name as EmployeeName"
                    + " FROM [dbo].[SnsMgt] as s"
                    + " left join Employee as e on e.Id = s.UpdateAccId"
                    + " Where s.IsDelete=0 " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;

            }
        }

        private void BindData(string sortString)
        {
            GetSnsList(sortString);
            dataGrid.DataSource = DS;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dataGrid.DataBind();
        }

        protected void dataGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dataGrid.EditItemIndex = -1;
            BindData(string.Empty);
        }

        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dataGrid.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE [dbo].[SnsMgt] SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            try
            {
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    BindData(string.Empty);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dataGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dataGrid.EditItemIndex = e.Item.ItemIndex;
            BindData(string.Empty);
        }

        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData(string.Empty);
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetSnsList("Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dataGrid.DataSource = DS;
                dataGrid.DataBind();
            }
        }

        protected void dataGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("SnsContent", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text.Replace("'", "''")));
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            try
            {
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.SnsMgt)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dataGrid.DataKeys[dataGrid.EditItemIndex].ToString() + "'"))
                {
                    dataGrid.EditItemIndex = -1;
                    BindData(string.Empty);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"))
                );
            lst.Add(new DbSearchObject(
            "CreatedateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
            ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "SnsContent"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbContent.Text.Replace("'", "''"))
                );
            try
            {
                if (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.SnsMgt)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                {
                    BindData(string.Empty);
                    btnClear_Click(sender, e);
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
            tbContent.Text = string.Empty;
            tbName.Text = string.Empty;
        }
    }
}