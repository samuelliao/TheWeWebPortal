using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheWeWebSite.SysMgt
{
    public partial class StoreMaintain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void dgStore_CancelCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void dgStore_DeleteCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void dgStore_EditCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void dgStore_UpdateCommand(object source, DataGridCommandEventArgs e)
        {

        }

        protected void dgStore_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {

        }

        protected void dgStore_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

        }

        protected void dgStore_SortCommand(object source, DataGridSortCommandEventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            tbName.Text = string.Empty;
            ddlArea.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
        }
    }
}