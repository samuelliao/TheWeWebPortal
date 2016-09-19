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
    public partial class AreaMaintain : System.Web.UI.Page
    {
        DataSet AreaDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.AreaString;
                    InitialLangList();
                    InitialCountryList();
                    InitialControlWithPermission();
                    BindData(GenQueryCond());
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
            dgArea.Columns[dgArea.Columns.Count - 1].Visible = item.CanDelete;
            dgArea.Columns[dgArea.Columns.Count - 2].Visible = item.CanModify;
        }

        private void GetAreaList(string condStr, string sortString)
        {
            try
            {
                string sqlTxt = "SELECT [Id],[Name],[EngName],JpName,CnName"
                    + ",IsDelete,UpdateAccId as EmployeeId,UpdateTime,CountryId"
                    + " FROM [dbo].[Area]"
                    + " where IsDelete = 0 " + condStr + " " + sortString;
                AreaDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                AreaDataSet = null;
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
        private void InitialCountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Country where IsDelete = 0");
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlCountry.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()));
                    }
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
            tbName.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text)
                || string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
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
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                );
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue)
                );
            lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
            ));

            if (SysProperty.GenDbCon.InsertDataInToTable(
                SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                ))
            {
                BindData(GenQueryCond());
                tbName.Text = string.Empty;
                ddlCountry.SelectedIndex = 0;
            }
        }

        private void BindData(string condStr)
        {
            GetAreaList(condStr, string.Empty);
            dgArea.DataSource = AreaDataSet;
            dgArea.AllowPaging = !SysProperty.Util.IsDataSetEmpty(AreaDataSet);
            dgArea.DataBind();
        }

        protected void dgArea_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgArea.EditItemIndex = -1;
            BindData(GenQueryCond());
        }

        protected void dgArea_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgArea.EditItemIndex = e.Item.ItemIndex;
            BindData(GenQueryCond());
        }

        protected void dgArea_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgArea.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE [dbo].[Area] SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
            {
                BindData(GenQueryCond());
            }
        }

        protected void dgArea_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgArea.CurrentPageIndex = e.NewPageIndex;
            BindData(GenQueryCond());
        }

        protected void dgArea_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            try
            {
                DropDownList ddl1 = (DropDownList)dgArea.Items[dgArea.EditItemIndex].FindControl("ddlDgCountry");
                List<DbSearchObject> updateLst = new List<DbSearchObject>();
                updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));
                updateLst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
                updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
                updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgArea.DataKeys[dgArea.EditItemIndex].ToString() + "'"))
                {
                    dgArea.EditItemIndex = -1;
                    BindData(GenQueryCond());
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgArea_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlDgCountry");
                    dropDownList1.Items.Clear();
                    try
                    {
                        DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                            , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                            , " Where IsDelete = 0");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dropDownList1.Items.Add(new ListItem(
                                SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                                , dr["Id"].ToString()));
                        }
                        dropDownList1.SelectedValue = dataItem1["CountryId"].ToString();
                    }
                    catch (Exception ex)
                    {
                        SysProperty.Log.Error(ex.Message);
                    }
                }
                else
                {
                    ((Label)e.Item.FindControl("labelDgCountry")).Text = ddlCountry.Items.FindByValue(dataItem1["CountryId"].ToString()).Text;
                }
            }
        }

        protected void dgArea_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (AreaDataSet == null)
            {
                GetAreaList(GenQueryCond(), "Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (AreaDataSet != null)
            {
                dgArea.DataSource = AreaDataSet;
                dgArea.DataBind();
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(GenQueryCond());
        }

        private string GenQueryCond()
        {
            string condStr = string.Empty;
            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                condStr += " And CountryId = '" + ddlCountry.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                condStr = " And ( Name like N'%" + tbName.Text + "%'"
                    + " OR ChName like N'%" + tbName.Text + "%'"
                    + " OR EngName like N'%" + tbName.Text + "%'"
                    + " OR JpName like N'%" + tbName.Text + "%')";
            }
            return condStr;
        }
    }
}