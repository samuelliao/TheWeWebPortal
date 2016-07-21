﻿using System;
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
            
            Session["CultureCode"] = CultureInfo.CurrentCulture.ToString();
            
            if (!Page.IsPostBack)
            {
                SysProperty.GenDbCon = new GeneralDbDAO();
                SysProperty.Util = new Utility();
                InitialStoreList();
            }
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
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
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
                SysProperty.UpdateCountries();
                SysProperty.UpdateAreas();
                SysProperty.UpdateChurch();
                Session["AccountInfo"] = ds.Tables[0].Rows[0];
                GetLocateStoreInfo(ddlStore.SelectedValue);
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

        private void GetLocateStoreInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    Session["LocateStore"] = null;
                }
                else
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store)
                    , " Where IsDelete = 0 And Id = '" + id + "'");
                    Session["LocateStore"] = ds.Tables[0].Rows[0];
                }
            }catch(Exception ex)
            {
                Session["LocateStore"] = null;
            }
        }
    }
}