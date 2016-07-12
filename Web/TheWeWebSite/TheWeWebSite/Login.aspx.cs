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

namespace TheWeWebSite
{
    public partial class Login : System.Web.UI.Page
    {
        private GeneralDbDAO DbDAO;
        Utility Util;

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
            DbDAO = new GeneralDbDAO();
            SysProperty.CultureCode = this.Culture;
            Util = new Utility();
        }

        protected void ddlStore_Load(object sender, EventArgs e)
        {
            InitialStoreList();
        }
        private void InitialStoreList()
        {
            Dictionary<string, string> stores = GetStoreList();
            ddlStore.Items.Clear();
            ListItem item = new ListItem(Resources.Resource.SelectStoreString, string.Empty, true);
            ddlStore.Items.Add(item);
            foreach (KeyValuePair<string, string> kvp in stores)
            {
                item = new ListItem(kvp.Value, kvp.Key);
                ddlStore.Items.Add(item);
            }
            ddlStore.Items[0].Selected = true;
        }

        private Dictionary<string, string> GetStoreList()
        {
            try
            {
                Dictionary<string, string> lst = new Dictionary<string, string>();
                DataSet ds = DbDAO.GetDataFromTable("*", Util.MsSqlTableConverter(MsSqlTable.Store), string.Empty);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(dr["Id"].ToString(), (SysProperty.IsEnglish() ? dr["EngName"].ToString() : dr["ChName"].ToString()));
                }
                return new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                // output log
                SysProperty.Log.Error(ex.Message);
                return new Dictionary<string, string>();
            }
        }

        private bool VerifyAccountAndPassword(string acc, string pwd, string storeId)
        {
            DataSet ds = DbDAO.GetDataFromTable(string.Empty
                , Util.MsSqlTableConverter(MsSqlTable.vwEN_Employee)
                , " Where Account= N'" + acc.ToLower() + "'"
                +(acc.ToLower().Equals("admin")?string.Empty:" and StoreId = '" + storeId + "'"));
            if (Util.IsDataSetEmpty(ds)) return false;
            if (new DataEncryption().GetMD5(pwd) == ds.Tables[0].Rows[0]["Password"].ToString())
            {
                SysProperty.EmployeeInfo = new EmployeeObj(ds.Tables[0].Rows[0]);
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
                Server.Transfer("Main/first.aspx", true);
            }
        }        
    }
}