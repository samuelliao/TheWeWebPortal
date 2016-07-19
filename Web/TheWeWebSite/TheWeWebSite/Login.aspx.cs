using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib.DbControl;
using TheWeLib;
using System.Web.Configuration;
using System.Globalization;

namespace TheWeWebSite
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SysProperty.DbConcString))
            {
                SysProperty.DbConcString = WebConfigurationManager.ConnectionStrings["TheWeConnectionString"].ConnectionString;
            }

            if (SysProperty.Log == null)
            {
                SysProperty.Log = NLog.LogManager.GetCurrentClassLogger();
            }
            SysProperty.GenDbCon = new GeneralDbDAO();
            SysProperty.CultureCode = CultureInfo.CurrentCulture.ToString();
            SysProperty.Util = new Utility();
        }

        protected void ddlStore_Load(object sender, EventArgs e)
        {
            InitialStoreList();
        }
        private void InitialStoreList()
        {
            DataSet stores = GetStoreList();
            ddlStore.Items.Clear();
            ListItem item = new ListItem(Resources.Resource.SelectStoreString, string.Empty, true);
            ddlStore.Items.Add(item);
            foreach (DataRow dr in stores.Tables[0].Rows)
            {
                item = new ListItem(
                    SysProperty.Util.OutputRelatedLangName(dr)
                    , dr["Id"].ToString());
                ddlStore.Items.Add(item);
            }
            ddlStore.Items[0].Selected = true;
        }

        private DataSet GetStoreList()
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("*"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store)
                    , " Where IsDelete = 0");
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return null;
            }
        }

        private bool VerifyAccountAndPassword(string acc, string pwd, string storeId)
        {
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Employee)
                , " Where Account= N'" + acc.ToLower() + "'"
                +(acc.ToLower().Equals("admin")?string.Empty:" and StoreId = '" + storeId + "'")
                +" And IsDelete = 0 And IsValid = 1");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return false;
            if (new DataEncryption().GetMD5(pwd) == ds.Tables[0].Rows[0]["Password"].ToString())
            {
                GetCountryList();
                GetAreaList();
                SysProperty.AccountInfo = ds.Tables[0].Rows[0];
                GetLocateStoreInfo(ds.Tables[0].Rows[0]["StoreId"].ToString());
                return true;
            }
            else return false;
        }        

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAccount.Text)
                || string.IsNullOrEmpty(tbPassword.Text))
            {
                labelWarnText.Text = Resources.Resource.AccountOrPasswordNullString;
                labelWarnText.Visible = true;
                return;
            }
            if (string.IsNullOrEmpty(ddlStore.SelectedValue) && !tbAccount.Text.ToLower().Equals("admin"))
            {
                labelWarnText.Text = Resources.Resource.LoginStoreNotSelectedString;
                labelWarnText.Visible = true;
                return;
            }
            bool result = VerifyAccountAndPassword(tbAccount.Text, tbPassword.Text, ddlStore.SelectedItem.Value);
            if (!result)
            {
                labelWarnText.Text = Resources.Resource.AccountOrPasswordErrorString;
                labelWarnText.Visible = true;
                return;
            }
            else
            {
                labelWarnText.Visible = false;
                Server.Transfer("Main/Case.aspx", true);
            }
        }

        public void GetCountryList() {
            SysProperty.CountryList = new CountryHashList();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Country)
                , string.Empty);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SysProperty.CountryList.InsertCountry(dr["Id"].ToString(), dr);
            }
        }
        public void GetAreaList() { 
            SysProperty.AreaList = new AreaHashList();
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Area)
                , string.Empty);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                SysProperty.AreaList.InsertArea(dr["Id"].ToString(), dr);
            }
        }
        private void GetLocateStoreInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    SysProperty.LocateStore = null;
                }
                else
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store)
                    , " Where IsDelete = 0 And StoreId = '" + id + "'");
                    SysProperty.LocateStore = ds.Tables[0].Rows[0];
                }
            }catch(Exception ex)
            {
                SysProperty.LocateStore = null;
            }
        }
    }
}