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
                    InitialAllList();
                }
            }
        }

        private void InitialAllList()
        {
            //ddlArea.SelectedIndexChanged += ddlArea_SelectedIndexChanged;
            //ddlCountry.SelectedIndexChanged += ddlCountry_SelectedIndexChanged;
            //ddlChruch.SelectedIndexChanged += ddlChruch_SelectedIndexChanged;
            GetCountryList();
            GetAreaList(string.Empty);
            GetChurchList(string.Empty, string.Empty, string.Empty);
            RefreshChurchDropDownList();
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
                        SysProperty.IsEnglish() ? dr["EngName"].ToString() : dr["ChName"].ToString()
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
                        SysProperty.IsEnglish() ? dr["EngName"].ToString() : dr["ChName"].ToString()
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
                    SysProperty.IsEnglish() ? dr["EngName"].ToString() : dr["ChName"].ToString()
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
            string sqlTxt = "Delete from " + SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church) + " Where Id ='" + id + "'";
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

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void dgChurch_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.EditItem)
            {
                DropDownList dropDownList1 = (DropDownList)e.Item.FindControl("dgDdlCountry");
                dropDownList1.DataValueField = "Id";
                dropDownList1.DataTextField = SysProperty.IsEnglish() ? "EngName" : "ChName";
                dropDownList1.DataSource = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country), string.Empty);
                dropDownList1.DataBind();
                DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
                dropDownList1.SelectedValue = dataItem1["CountryId"].ToString();
            }
            else
            {
                Label label = (Label)e.Item.FindControl("dgLabelCountry");
                //label.Text = 
            }
        }
    }
}