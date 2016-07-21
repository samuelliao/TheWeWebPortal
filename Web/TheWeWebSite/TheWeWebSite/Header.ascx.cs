using System;
using System.Collections.Generic;
using System.Data;
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
            if (((DataRow)Session["LocateStore"]) != null)
            {
                labelStoreName.Text = SysProperty.Util.OutputRelatedLangName(
                    ((string)Session["CultureCode"])
                    , ((DataRow)Session["LocateStore"]));
            }
            else labelStoreName.Text = string.Empty;
        }
    }
}