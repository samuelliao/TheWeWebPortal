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
            DbDAO = new GeneralDbDAO();
            SysProperty.CultureCode = this.Culture;
            Util = new Utility();
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
                DataSet ds = DbDAO.GetDataFromTable("*", "Store", string.Empty);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(dr["Id"].ToString(), (SysProperty.IsEnglish() ? dr["EngName"].ToString() : dr["ChName"].ToString()));
                }
                return new Dictionary<string, string>();
            }
            catch (Exception ex)
            {
                // output log
                return new Dictionary<string, string>();
            }
        }

        private bool VerifyAccountAndPassword(string acc, string pwd, string storeId)
        {
            DataSet ds = DbDAO.GetDataFromTable("*", "vmEN_Employee", " Where Account= N'" + acc + "' and StoreId = '" + storeId + "'");
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
            if (string.IsNullOrEmpty(ddlStore.SelectedValue)) {
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
            }
        }
    }
}