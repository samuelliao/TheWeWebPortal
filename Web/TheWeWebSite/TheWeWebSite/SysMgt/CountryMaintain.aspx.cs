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
    public partial class CountryMaintain : System.Web.UI.Page
    {
        DataSet CountryDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {                    
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.CountryString;
                    InitialUseLang();
                    InitialLangList();
                    InitialCurrencyList();
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
            dgCountry.Columns[dgCountry.Columns.Count - 1].Visible = item.CanDelete;
            dgCountry.Columns[dgCountry.Columns.Count - 2].Visible = item.CanModify;
        }

        #region DropDownList Control
        private void InitialUseLang()
        {
            ddlUseLang.Items.Clear();
            ddlUseLang.Items.Add(new ListItem(Resources.Resource.LanguageSelectionReminderString, string.Empty));
            ddlUseLang.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "1"));
            ddlUseLang.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "2"));
            ddlUseLang.Items.Add(new ListItem(Resources.Resource.EnglishString, "0"));
            ddlUseLang.Items.Add(new ListItem(Resources.Resource.JapaneseString, "3"));
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
        private void InitialCurrencyList()
        {
            ddlCurrency.Items.Clear();
            ddlCurrency.Items.Add(new ListItem(Resources.Resource.CurrencySelectionReminderString, string.Empty));
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Currency where IsDelete = 0");
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                    }
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        #region DataGrid Control
        protected void dgCountry_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgCountry.EditItemIndex = -1;
            BindData();
        }

        protected void dgCountry_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = dgCountry.DataKeys[(int)e.Item.ItemIndex].ToString();
            string sqlTxt = "UPDATE [dbo].[Country] SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            try
            {
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    BindData();
                }
            } catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void dgCountry_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgCountry.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgCountry_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgCountry.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dgCountry_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            DropDownList ddl1 = (DropDownList)dgCountry.Items[dgCountry.EditItemIndex].FindControl("ddlDgCurrency");
            DropDownList ddl2 = (DropDownList)dgCountry.Items[dgCountry.EditItemIndex].FindControl("ddlDgLang");
            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[1].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[2].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[3].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[4].Controls[0]).Text));            
            updateLst.Add(new DbSearchObject("Code", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[5].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("CurrencyId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
            updateLst.Add(new DbSearchObject("LangCode", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl2.SelectedValue));
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            try
            {
                if (SysProperty.GenDbCon.UpdateDataIntoTable
                    (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                    , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                    , " Where Id = '" + dgCountry.DataKeys[dgCountry.EditItemIndex].ToString() + "'"))
                {
                    dgCountry.EditItemIndex = -1;
                    BindData();
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        protected void dgCountry_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("ddlDgCurrency");
                    dropDownList1.Items.Clear();
                    try
                    {
                        DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                            , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency)
                            , " Where IsDelete = 0");
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            dropDownList1.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                        }
                        dropDownList1.SelectedValue = dataItem1["CurrencyId"].ToString();
                    }catch(Exception ex)
                    {
                        SysProperty.Log.Error(ex.Message);
                    }

                    DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("ddlDgLang");
                    dropDownList2.Items.Clear();
                    dropDownList2.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "1"));
                    dropDownList2.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "2"));
                    dropDownList2.Items.Add(new ListItem(Resources.Resource.EnglishString, "0"));
                    dropDownList2.Items.Add(new ListItem(Resources.Resource.JapaneseString, "3"));
                    dropDownList2.SelectedValue = dataItem1["LangCode"] == null ? "1" : dataItem1["LangCode"].ToString();
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("labelDgCurrency");
                    label.Text = dataItem1["CurrencyName"].ToString();
                    Label label2 = (Label)e.Item.FindControl("labelDgLang");
                    label2.Text = ddlUseLang.Items.FindByValue(dataItem1["LangCode"].ToString()).Text;
                }
            }
        }
        protected void dgCountry_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (CountryDataSet == null)
            {
                GetCountryList("Order by " + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (CountryDataSet != null)
            {
                dgCountry.DataSource = CountryDataSet;
                dgCountry.DataBind();
            }
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text) 
                || string.IsNullOrEmpty(tbCode.Text) 
                || string.IsNullOrEmpty(ddlCurrency.SelectedValue))
            {
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
                "Code"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCode.Text)
                );
            lst.Add(new DbSearchObject(
                "CurrencyId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCurrency.SelectedValue)
                );
            lst.Add(new DbSearchObject(
                "LangCode"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlUseLang.SelectedValue)
                );
            try
            {
                if (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                {
                    BindData();
                    tbCode.Text = string.Empty;
                    tbName.Text = string.Empty;
                    ddlCurrency.SelectedIndex = 0;
                    ddlUseLang.SelectedIndex = 0;
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;
            tbName.Text = string.Empty;
            ddlCurrency.SelectedIndex = 0;
            ddlUseLang.SelectedIndex = 0;
        }
        #endregion

        private void BindData()
        {
            GetCountryList(string.Empty);
            dgCountry.DataSource = CountryDataSet;
            dgCountry.AllowPaging = !SysProperty.Util.IsDataSetEmpty(CountryDataSet);
            dgCountry.DataBind();
        }

        private void GetCountryList(string sortString)
        {
            try
            {
                string sqlTxt = "SELECT co.[Id],co.[Name],co.[EngName],co.[Code]"
                    +",co.[CurrencyId],co.[LangCode],co.[CnName],co.[JpName]"
                    +",co.[IsDelete],co.[UpdateAccId],co.[UpdateTime]"
                    +",cu.Name as CurrencyName, em.Name as EmployeeName"
                    +" FROM[TheWe].[dbo].[Country] as co"
                    +" left join Currency as cu on cu.Id = co.CurrencyId"
                    +" left join vwEN_Employee as em on em.Id = co.UpdateAccId"
                    +" where co.IsDelete = 0 "+ sortString;
                CountryDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                CountryDataSet = null;
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnStr.Text = msg;
            labelWarnStr.Visible = !string.IsNullOrEmpty(msg);
        }
    }
}