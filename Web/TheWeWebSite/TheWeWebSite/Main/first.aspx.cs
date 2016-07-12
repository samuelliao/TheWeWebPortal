using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeWebSite.Main
{
    public partial class first : System.Web.UI.Page
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
            Util = new Utility();
        }

        public void TimetableInit()
        {
            DataSet ds = GetConsultListByEmployee();
        }

        private DataSet GetConsultListByEmployee()
        {
            try
            {
                if (SysProperty.EmployeeInfo == null 
                    || string.IsNullOrEmpty(SysProperty.EmployeeInfo.Id))
                    return null;
                return DbDAO.GetDataFromTable(string.Empty, Util.MsSqlTableConverter(MsSqlTable.Consultation), " Where EmployeeId='" + SysProperty.EmployeeInfo.Id + "' order by Sn");

            }
            catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                return null;
            }
            
        }

        protected void btnSystemMgt_Click(object sender, EventArgs e)
        {
            Server.Transfer("/SysMgt/system_dollar.aspx");
        }
    }
}