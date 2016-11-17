using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TheWeWebSite
{
    public partial class LogMgt : System.Web.UI.Page
    {
        private string LogFolderPath = HttpContext.Current.Server.MapPath("~") + @"\Logs\";
        protected void Page_Load(object sender, EventArgs e)
        {
            InitialLogList();
        }

        private void InitialLogList()
        {
            listLogs.Items.Clear();
            string[] files = Directory.GetFiles(LogFolderPath, "*", SearchOption.AllDirectories);
            foreach(string file in files)
            {
                //ListViewDataItem item = new ListViewDataItem(0, 0);
                listLogs.Items.Add(new ListItem(file, file));
                //listLogs.Items.Add(new ListViewDataItem())
            }
            //listLogs.SelectedIndex = 0;
            ReadFile(listLogs.SelectedValue);
        }

        protected void listLogs_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadFile(listLogs.SelectedValue);
        }

        private void ReadFile(string file)
        {
            if (File.Exists(file))
            {
                tbLog.Text = File.ReadAllText(file, Encoding.Default);
            }
        }
    }
}