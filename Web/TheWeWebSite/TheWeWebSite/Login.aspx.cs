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
using NLog;

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
                InitialImgFolderPath();
                GetAccInfoCookie();
            }
        }

        private void GetAccInfoCookie()
        {
            HttpCookie myCookie = Request.Cookies["TheWeWebMgtAccInfo"];
            if (myCookie != null)
            {
                ddlStore.SelectedValue = myCookie.Values["Store"];
                tbAccount.Text = myCookie.Values["Acc"];
                cbRemember.Checked = true;
            }

        }

        private void InitialImgFolderPath()
        {
            if (string.IsNullOrEmpty(SysProperty.ImgRootFolderpath))
            {
                System.Configuration.Configuration rootWebConfig1 =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(null);
                if (0 < rootWebConfig1.AppSettings.Settings.Count)
                {
                    System.Configuration.KeyValueConfigurationElement customSetting =
                        rootWebConfig1.AppSettings.Settings["ImgFolderPath"];
                    if (null != customSetting)
                    {
                        SysProperty.ImgRootFolderpath = customSetting.Value;
                    }
                }
            }

            if (string.IsNullOrEmpty(SysProperty.ImgRootFolderpath))
            {
                SysProperty.ImgRootFolderpath = @"\\60.205.146.133\Photo\";
            }
        }

        private void InitialStoreList()
        {
            DataSet stores = GetStoreList();
            if (SysProperty.Util.IsDataSetEmpty(stores)) return;
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
                    , " Where IsDelete = 0 Order by GradeLv, Sn");
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
                , " Where Account= N'" + acc.Trim() + "' and StoreId = '" + storeId + "'"
                + " And IsDelete = 0 And IsValid = 1");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return false;
            //if (acc=="admin"||SysProperty.Util.GetMD5(pwd) == ds.Tables[0].Rows[0]["AccInfo"].ToString())
            if (SysProperty.Util.GetMD5(pwd) == ds.Tables[0].Rows[0]["AccInfo"].ToString())
            {
                SysProperty.UpdateCountries();
                SysProperty.UpdateAreas();
                SysProperty.UpdateChurch();
                if (ddlStore.SelectedIndex == 1) SysProperty.UpdateStore();
                Session["AccountInfo"] = ds.Tables[0].Rows[0];
                GetLocateStoreInfo(ddlStore.SelectedValue);
                GetOperationPermission(ddlStore.SelectedValue);
                GetCasePermission(ds.Tables[0].Rows[0]["Id"].ToString());
                if (cbRemember.Checked) SetCookie();
                return true;
            }
            else return false;
        }

        private void SetCookie()
        {
            HttpCookie newCookie = new HttpCookie("TheWeWebMgtAccInfo");
            newCookie.Values.Add("Store", ddlStore.SelectedValue.Trim());
            newCookie.Values.Add("Acc", tbAccount.Text.Trim());
            newCookie.Expires = DateTime.Now.AddMonths(1);
            Response.AppendCookie(newCookie);
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
            if (string.IsNullOrEmpty(ddlStore.SelectedValue))
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
                Response.Redirect("Main/Case.aspx");
            }
        }

        #region Get Basic Info
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
            }
            catch
            {
                Session["LocateStore"] = null;
            }
        }
        private void GetCasePermission(string accId)
        {
            try
            {
                if (string.IsNullOrEmpty(accId))
                {
                    Session["CasePermission"] = null;
                }
                else
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                    , " Where IsDelete = 0 And PermissionId in "
                    + "(Select Id From Permission Where IsDelete = 0 "
                    + "And ObjectId = '" + accId + "' And Type in ('Country','Store'))"
                    + " And Type in ('Country','Store')");
                    if (SysProperty.Util.IsDataSetEmpty(ds)) Session["CasePermission"] = null;
                    Session["CasePermission"] = SysProperty.Util.WebPermission(false, ds);
                }
            }
            catch
            {
                Session["CasePermission"] = null;
            }
        }
        private void GetOperationPermission(string storeId)
        {
            try
            {
                if (string.IsNullOrEmpty(storeId))
                {
                    Session["Operation"] = null;
                }
                else
                {
                    DataSet ds = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                    , " Where IsDelete = 0 And PermissionId = "
                    + "( Select TOP(1) Id From Permission Where IsDelete = 0 And ObjectId = '" + storeId + "' And Type = 'Operation')"
                    + " Order by ObjectSn");
                    if (SysProperty.Util.IsDataSetEmpty(ds)) Session["Operation"] = null;
                    Session["Operation"] = SysProperty.Util.WebPermission(true, ds);
                }
            }
            catch
            {
                Session["Operation"] = null;
            }
        }
        #endregion
    }
}