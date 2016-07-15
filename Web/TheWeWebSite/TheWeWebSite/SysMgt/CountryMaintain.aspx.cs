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
                    BindData();
                }
            }
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
            ddlLang.SelectedIndex = new ResourceUtil().OutputLangNameNumber(SysProperty.CultureCode);
        }
        private void InitialCurrencyList()
        {
            ddlCurrency.Items.Clear();
            ddlCurrency.Items.Add(new ListItem(Resources.Resource.CurrencySelectionReminderString, string.Empty));

            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Currency where IsDelete = 0");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
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
                + ", UpdateAccId=N'" + SysProperty.AccountInfo["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
            if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
            {
                BindData();
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
            updateLst.Add(new DbSearchObject("UpdateAccId", AtrrTypeItem.String, AttrSymbolItem.Equal, SysProperty.AccountInfo["Id"].ToString()));
            updateLst.Add(new DbSearchObject("UpdateTime", AtrrTypeItem.String, AttrSymbolItem.Equal, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            if (SysProperty.GenDbCon.UpdateDataIntoTable
                (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                , " Where Id = '" + dgCountry.DataKeys[dgCountry.EditItemIndex].ToString() + "'"))
            {
                dgCountry.EditItemIndex = -1;
                BindData();
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
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency)
                        , " Where IsDelete = 0");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dropDownList1.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                    }
                    dropDownList1.SelectedValue = dataItem1["CurrencyId"].ToString();

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
        #endregion

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
                , SysProperty.AccountInfo["Id"].ToString())
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
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbCode.Text = string.Empty;
            tbName.Text = string.Empty;
            ddlCurrency.SelectedIndex = 0;
            ddlUseLang.SelectedIndex = 0;
        }

        private void BindData()
        {
            GetCountryList();
            dgCountry.DataSource = CountryDataSet;
            dgCountry.AllowPaging = !SysProperty.Util.IsDataSetEmpty(CountryDataSet);
            dgCountry.DataBind();
        }

        private void GetCountryList()
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
                    +" where co.IsDelete = 0";
                CountryDataSet = SysProperty.GenDbCon.GetDataFromTable(sqlTxt);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                CountryDataSet = null;
            }
        }
    }
}