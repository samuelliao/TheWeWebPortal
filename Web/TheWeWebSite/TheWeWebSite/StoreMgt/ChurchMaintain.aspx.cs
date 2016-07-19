using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeWebSite.StoreMgt
{
    public partial class ChurchMaintain : System.Web.UI.Page
    {
        DataSet ChurchDataSet;
        DataSet CountryDataSet;
        DataSet AreaDataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    //InitialAllList();
                }
            }
        }

        private void InitialAllList()
        {
            GetCountryList();
            GetAreaList(string.Empty);
            GetChurchList(string.Empty, string.Empty, string.Empty);
            RefreshChurchDropDownList();
            InitialLangList();
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

        private void GetCountryList()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                CountryDataSet = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), string.Empty);
                foreach (DataRow dr in CountryDataSet.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(dr)
                        , dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return;
            }
        }

        private void GetAreaList(string countryId)
        {
            ddlArea.Items.Clear();
            try
            {
                ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty, true));
                AreaDataSet = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                    , string.IsNullOrEmpty(countryId) ? string.Empty : " Where CountryId = '" + countryId + "'");
                foreach (DataRow dr in AreaDataSet.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(dr)
                        , dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return;
            }
        }

        private void RefreshChurchDropDownList()
        {
            ddlChruch.Items.Clear();
            ddlChruch.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty, true));
            if (SysProperty.Util.IsDataSetEmpty(ChurchDataSet)) return;
            foreach (DataRow dr in ChurchDataSet.Tables[0].Rows)
            {
                ddlChruch.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(dr)
                    , dr["Id"].ToString(), true));
            }
        }

        private void GetChurchList(string countryId, string areaId, string churchId)
        {
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                if (!string.IsNullOrEmpty(countryId))
                {
                    lst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, countryId));
                }
                if (!string.IsNullOrEmpty(areaId))
                {
                    lst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, areaId));
                }
                if (!string.IsNullOrEmpty(churchId))
                {
                    lst.Add(new DbSearchObject("Id", AtrrTypeItem.String, AttrSymbolItem.Equal, churchId));
                }

                ChurchDataSet = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                    , SysProperty.Util.SqlQueryConditionConverter(lst));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return;
            }
        }


        #region DropDownList Controller
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAreaList(ddlCountry.SelectedValue);
            GetChurchList(ddlCountry.SelectedValue, string.Empty, string.Empty);
            RefreshChurchDropDownList();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue, string.Empty);
            RefreshChurchDropDownList();
        }

        protected void ddlChruch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion
        
        #region DataGrid Control
        private void BindData()
        {
            GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlChruch.SelectedValue);
            dgChurch.DataSource = ChurchDataSet;
                dgChurch.DataBind();
        }

        protected void dgChurch_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgChurch.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }

        protected void dgChurch_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgChurch.EditItemIndex = -1;
            BindData();
        }

        protected void dgChurch_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            string id = (string)dgChurch.DataKeys[(int)e.Item.ItemIndex];
            string sqlTxt = "Delete from " + SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                + " Where Id ='" + id + "'";
            if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
            {
                BindData();
                RefreshChurchDropDownList();
            }
        }

        protected void dgChurch_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgChurch.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dgChurch_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            DropDownList ddl1 = (DropDownList)dgChurch.Items[dgChurch.EditItemIndex].FindControl("dgDdlCountry");
            DropDownList ddl2 = (DropDownList)dgChurch.Items[dgChurch.EditItemIndex].FindControl("dgDdlArea");

            List<DbSearchObject> updateLst = new List<DbSearchObject>();
            updateLst.Add(new DbSearchObject("CountryId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl1.SelectedValue));
            updateLst.Add(new DbSearchObject("AreaId", AtrrTypeItem.String, AttrSymbolItem.Equal, ddl2.SelectedValue));
            updateLst.Add(new DbSearchObject("Name", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[5].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("CnName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[6].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("EngName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[7].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("JpName", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[8].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("Capacities", AtrrTypeItem.Integer, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[9].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("Price", AtrrTypeItem.Integer, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[10].Controls[0]).Text));
            updateLst.Add(new DbSearchObject("Remark", AtrrTypeItem.String, AttrSymbolItem.Equal, ((TextBox)e.Item.Cells[11].Controls[0]).Text));

            if (SysProperty.GenDbCon.UpdateDataIntoTable
                (SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                , SysProperty.Util.SqlQueryUpdateConverter(updateLst)
                , " Where Id = '" + dgChurch.DataKeys[dgChurch.EditItemIndex].ToString() + "'"))
            {
                dgChurch.EditItemIndex = -1;
                BindData();
            }
        }
        protected void dgChurch_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                if (e.Item.ItemType == ListItemType.EditItem)
                {
                    DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("dgDdlCountry");
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), string.Empty);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dropDownList1.Items.Add(new ListItem(SysProperty.Util.OutputRelatedLangName(dr), dr["Id"].ToString()));
                    }
                    dropDownList1.SelectedValue = dataItem1["CountryId"].ToString();

                    DropDownList dropDownList2 = (DropDownList)e.Item.FindControl("dgDdlArea");
                    ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                        , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area), " Where CountryId = '" + dataItem1["CountryId"].ToString() + "'");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        dropDownList2.Items.Add(new ListItem(SysProperty.Util.OutputRelatedLangName(dr), dr["Id"].ToString()));
                    }
                    dropDownList1.SelectedValue = dataItem1["AreaId"].ToString();
                }
                else
                {
                    Label label = (Label)e.Item.FindControl("dgLabelCountry");
                    /*
                    label.Text = SysProperty.CountryList.ContainsKey(dataItem1["CountryId"].ToString())
                        ? SysProperty.Util.OutputRelatedLangName((DataRow)SysProperty.CountryList[dataItem1["CountryId"].ToString()])
                        : string.Empty;

                    Label label2 = (Label)e.Item.FindControl("dgLabelArea");
                    label2.Text = SysProperty.AreaList.ContainsKey(dataItem1["AreaId"].ToString())
                        ? SysProperty.Util.OutputRelatedLangName((DataRow)SysProperty.AreaList[dataItem1["AreaId"].ToString()])
                        : string.Empty;
                        */
                }
            }
        }
        protected void dgDdlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = (DropDownList)dgChurch.Items[dgChurch.EditItemIndex].FindControl("dgDdlArea");
            ddl.Items.Clear();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                , " Where CountryId='" + (sender as DropDownList).SelectedValue + "'");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddl.Items.Add(new ListItem(SysProperty.Util.OutputRelatedLangName(dr), dr["Id"].ToString()));
            }
        }
        #endregion

        #region Button Control
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbChurchName.Text = string.Empty;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlChruch.SelectedValue))
            {
                string sqlTxt = "Delete From Church Where Id = '" + ddlChruch.SelectedValue + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sqlTxt))
                {
                    GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue, string.Empty);
                    RefreshChurchDropDownList();
                }
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                new ResourceUtil().OutputLangNameToAttrName(ddlLang.SelectedValue)
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbChurchName.Text)
                );
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue)
                );
            lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlArea.SelectedValue)
                );
           

            if (SysProperty.GenDbCon.InsertDataInToTable(
                SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church)
                , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                , SysProperty.Util.SqlQueryInsertValueConverter(lst)                
                ))
            {
                GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue, string.Empty);
                RefreshChurchDropDownList();
            }
        }
        #endregion
    }
}