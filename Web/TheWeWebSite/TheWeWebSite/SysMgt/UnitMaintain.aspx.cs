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
    public partial class UnitMaintain : System.Web.UI.Page
    {
        DataSet UnitDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialLangList();
                    InitialControlWithPermission();
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.UnitString;
                    BindData();
                }
            }
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            dgUnit.Columns[dgUnit.Columns.Count - 1].Visible = item.CanDelete;
            dgUnit.Columns[dgUnit.Columns.Count - 2].Visible = item.CanModify;
        }
        private void GetUnitList()
        {
            string sqlTxt = "SELECT i.[Id],i.[Name],i.[CnName],i.[JpName],i.[EngName]"
                + ",i.[IsDelete],i.[UpdateAccId],i.[UpdateTime],e.Name as EmployeeName"
                + " FROM[TheWe].[dbo].[ItemUnit] as i"
                + " left join Employee as e on e.Id = i.UpdateAccId";
            try
            {
                UnitDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                UnitDataSet = null;
                ShowErrorMsg(ex.Message);
            }
        }

        private void BindData()
        {
            GetUnitList();
            dgUnit.DataSource = UnitDataSet;
            dgUnit.AllowPaging = !SysProperty.Util.IsDataSetEmpty(UnitDataSet);
            dgUnit.DataBind();
        }

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUnit.Text))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbUnit.Text)
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
            try
            {
                if (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.ItemUnit)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                {
                    BindData();
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
            tbUnit.Text = string.Empty;
        }
        #endregion

        #region DataGrid Control
        protected void dgUnit_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgUnit.EditItemIndex = -1;
            BindData();
        }

        protected void dgUnit_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgUnit.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgUnit_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgUnit.DataKeys[(int)e.Item.ItemIndex].ToString();
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

        protected void dgUnit_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            try
            {
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.ItemUnit)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgUnit.DataKeys[dgUnit.EditItemIndex].ToString() + "'"))
                {
                    dgUnit.EditItemIndex = -1;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgUnit_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgUnit.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        #endregion

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
    }
}