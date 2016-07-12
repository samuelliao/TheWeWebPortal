using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeLib.DbControl;

namespace TheWeWebSite.SysMgt
{
    public partial class system_dollar : System.Web.UI.Page
    {
        GeneralDbDAO DbDAO;
        DataSet ds = new DataSet();
        Utility Util;
        protected void Page_Load(object sender, EventArgs e)
        {
            Util = new Utility();
            if (!Util.VerifyBasicVariable())
            {
                Response.Redirect("../Login.aspx", true);
            }
            else
            {
                DbDAO = new GeneralDbDAO();
                BindData();
            }
        }

        private void BindData()
        {
            ds = DbDAO.GetDataFromTable("select C.Id, C.Name, C.Rate, C.UpdateTime"
                + ", C.EmployeeId, E.Account AS EmployeeAccount, E.Name AS EmployeeName"
                + " from Currency as C inner join Employee as E on C.EmployeeId = E.Id");
            dgCurrency.DataSource = ds;
            dgCurrency.DataBind();
        }

        protected void dgCurrency_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgCurrency.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }
        protected void dgCurrency_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dgCurrency.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }
        protected void dgCurrency_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dgCurrency.EditItemIndex = -1;
            BindData();
        }
        protected void dgCurrency_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int EmpId = (int)dgCurrency.DataKeys[(int)e.Item.ItemIndex];
            string sqlTxt = "Delete from Employee where EmpId=" + EmpId;
            if (DbDAO.ModifyDataInToTable(sqlTxt))
            {
                BindData();
            }
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sqlTxt = "INSERT INTO [dbo].[Currency]([Name],[EmployeeId],[UpdateTime])"
                + " VALUES (N'" + tbCurrencyName.Text + "', '" + SysProperty.EmployeeInfo.Id + "', N'" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "')";
            if (DbDAO.ModifyDataInToTable(sqlTxt))
                DataBind();
        }
    }
}