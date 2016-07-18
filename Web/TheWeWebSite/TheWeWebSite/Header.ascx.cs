using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void StoreName()
        {
            if (SysProperty.LocateStore != null)
            {
                labelStoreName.Text = SysProperty.Util.OutputRelatedLangName(SysProperty.LocateStore);
            }
            else labelStoreName.Text = string.Empty;
        }
    }
}