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
        GeneralDbDAO DbCon;
        Utility Util;
        protected void Page_Load(object sender, EventArgs e)
        {
            Util = new Utility();
            if (Util.VerifyBasicVariable())
            {
                DbCon = new GeneralDbDAO();
                InitialAllList();
            }
            else
            {
                Response.Redirect("../Login.aspx");
            }
        }

        private void InitialAllList()
        {
            GetCountryList();
            GetAreaList(string.Empty);
            GetChurchList(string.Empty, string.Empty);
        }

        private void GetCountryList()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                DataSet ds = DbCon.GetDataFromTable(string.Empty, Util.MsSqlTableConverter(MsSqlTable.Country), string.Empty);
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem(
                        SysProperty.IsEnglish()?dr["EngName"].ToString():dr["ChName"].ToString()
                        , dr["Id"].ToString(), true));
                }
            }catch(Exception ex)
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
                DataSet ds = DbCon.GetDataFromTable(string.Empty
                    , Util.MsSqlTableConverter(MsSqlTable.Country)
                    , string.IsNullOrEmpty(countryId) ? string.Empty : " Where CountryId = '" + countryId + "'");
                foreach (DataRow dr in ds.Tables[0].Rows)
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

        private void GetChurchList(string countryId, string areaId)
        {
            ddlChruch.Items.Clear();
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


                ddlChruch.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty, true));
                DataSet ds = DbCon.GetDataFromTable(string.Empty
                    , Util.MsSqlTableConverter(MsSqlTable.Country)
                    , Util.SqlQueryConditionConverter(lst));
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlChruch.Items.Add(new ListItem(
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



        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetAreaList(ddlCountry.SelectedValue);
            GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }

        protected void ddlChruch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}