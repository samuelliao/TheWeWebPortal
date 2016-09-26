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
    public partial class PaymentMethod : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.PaymentMethodString;
                    InitialLangList();
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
            dgMethod.Columns[dgMethod.Columns.Count - 1].Visible = item.CanDelete;
            dgMethod.Columns[dgMethod.Columns.Count - 2].Visible = item.CanModify;
        }
        private void InitialLangList()
        {
            ddlLang.Items.Clear();
            ddlLang.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "zh-TW"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "zh-CN"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.EnglishString, "en"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.JapaneseString, "ja-JP"));
            ddlLang.SelectedIndex = new ResourceUtil().OutputLangNameNumber(((string)Session["CultureCode"]));
        }

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            bool result = WriteBackData(MsSqlTable.PaymentMethod, true, CreateDbObject(true), string.Empty);
            if (result)
            {
                BindData(string.Empty);
                btnClear_Click(sender, e);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            tbRemark.Text = string.Empty;
        }
        #endregion

        private void BindData(string condStr)
        {
            GetPaymentMethod(condStr, string.Empty);
            dgMethod.DataSource = DS;
            dgMethod.AllowPaging = !SysProperty.Util.IsDataSetEmpty(DS);
            dgMethod.DataBind();
        }

        private void GetPaymentMethod(string condString, string sortString)
        {
            try
            {
                string sqlTxt = "SELECT * From PaymentMethod"
                    + " WHERE IsDelete = 0 " + condString + " " + sortString;
                DS = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }

        #region GridView Control
        protected void dgMethod_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgMethod.EditItemIndex = -1;
            BindData(string.Empty);
        }

        protected void dgMethod_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgMethod.EditItemIndex = e.Item.ItemIndex;
            BindData(string.Empty);
        }

        protected void dgMethod_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                string id = dgMethod.DataKeys[(int)e.Item.ItemIndex].ToString();
                string sqlTxt = "UPDATE [dbo].[PaymentMethod] SET IsDelete = 1"
                    + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                    + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                    + " Where Id = '" + id + "'";
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

        protected void dgMethod_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgMethod.CurrentPageIndex = e.NewPageIndex;
            BindData(string.Empty);
        }

        protected void dgMethod_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (DS == null)
            {
                GetPaymentMethod(string.Empty
                    , "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (DS != null)
            {
                dgMethod.DataSource = DS;
                dgMethod.DataBind();
            }
        }

        protected void dgMethod_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("Remark", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[5].Controls[0]).Text));
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.PaymentMethod)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgMethod.DataKeys[dgMethod.EditItemIndex].ToString() + "'"))
                {
                    dgMethod.EditItemIndex = -1;
                    BindData(string.Empty);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private bool WriteBackData(MsSqlTable table, bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(table)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , " Where Id = '" + id + "'"));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private List<DbSearchObject> CreateDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text)
                );
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "UpdateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text)
                );
            return lst;
        }
    }
}