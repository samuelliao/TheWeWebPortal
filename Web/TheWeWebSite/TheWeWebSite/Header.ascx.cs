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
            SetOperationPermission();
            StoreName();
        }

        public void SetOperationPermission()
        {
            DataSet ds = ((DataSet)Session["Operation"]);
            if (SysProperty.Util.IsDataSetEmpty(ds))
            {
                liSysMgt.Visible = false;
            }
            else
            {                
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    switch (dr["ObjectSn"].ToString())
                    {
                        case "1":
                            liStoreMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                        case "2":
                            liOrderMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                        case "3":
                            liPurchaseMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                        case "4":
                            liSalesMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                        case "5":
                            liFinMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                        case "6":
                            liSysMgt.Visible = bool.Parse(dr["CanEntry"].ToString());
                            break;
                    }
                }
            }
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