using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.StoreMgt
{
    public partial class EmployeeMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialControl();
                    if (Session["EmpId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.EmployeeMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetEmpInfoData(Session["EmpId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.EmployeeMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                        btnDelete.Visible = false;
                    }
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage()
        {
            Session.Remove("EmpId");
            Response.Redirect("EmployeeMaintain.aspx", true);
        }
        private void InitialControl()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                string sql = "select * from Country";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(
                        new ListItem(
                        dr["Name"].ToString()
                    , dr["Id"].ToString(), true));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }


        }



        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Employee), tbEmpSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            bool result = WriteBackInfo(true, EmployeeInfoDbObject(), string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["EmpId"] == null) return;
            bool result = WriteBackInfo(false, EmployeeInfoDbObject(), Session["EmpId"].ToString());
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbEmpSn.Text = string.Empty;
            tbEmpPassportName.Text = string.Empty;
            tbEmpPassportId.Text = string.Empty;
            tbEmpName.Text = string.Empty;
            tbEmpEmail.Text = string.Empty;
            tbEmpECTel.Text = string.Empty;
            tbEmpEC.Text = string.Empty;
            tbEmpBankBook.Text = string.Empty;
            tbEmpBank.Text = string.Empty;
            tbEmpAddress.Text = string.Empty;
            ddlCountry.SelectedIndex = 0;
            EmpBDay.Text = string.Empty;
            EmpOnBoardDay.Text = string.Empty;
            EmpQuitDay.Text = string.Empty;
            tbEmpInsurance.Text = string.Empty;
            tbEmpSalary.Text = string.Empty;
            tbEmpRemark.Text = string.Empty;
            tbEmpPhone.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["EmpId"].ToString())) return;
                string sql = "UPDATE Employee SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["EmpId"].ToString() + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sql))
                {
                    TransferToOtherPage();
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        #region Photo Control
        protected void btnUpload1_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload2_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload3_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private DataSet GetDataSetFromTable(string sql)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetEmpInfoData(string id)
        {
            string sql = "Select * From Employee Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbEmpAddress.Text = dr["Addr"].ToString();
            tbEmpSn.Text = dr["Sn"].ToString();
            tbEmpSalary.Text = dr["Salary"].ToString();
            tbEmpRemark.Text = dr["Remark"].ToString();
            tbEmpPhone.Text = dr["Phone"].ToString();
            tbEmpPassportName.Text = dr["PassportName"].ToString();
            tbEmpPassportId.Text = dr["PassportId"].ToString();
            tbEmpName.Text = dr["Name"].ToString();
            tbEmpInsurance.Text = dr["InsuranceId"].ToString();
            tbEmpEmail.Text = dr["Email"].ToString();
            tbEmpECTel.Text = dr["EmergencyContactTel"].ToString();
            tbEmpEC.Text = dr["EmergencyContact"].ToString();
            tbEmpBankBook.Text = dr["BankBookImg"].ToString();
            tbEmpBank.Text = dr["BankAccount"].ToString();
            EmpQuitDay.Text = dr["QuitDay"].ToString();
            EmpOnBoardDay.Text = dr["OnBoard"].ToString();
            EmpBDay.Text = dr["Bday"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();


        }

        private List<DbSearchObject> EmployeeInfoDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpSn.Text
                ));

            lst.Add(new DbSearchObject(
                "PassportName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpPassportName.Text
                ));
            lst.Add(new DbSearchObject(
                "PassportId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpPassportId.Text
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpName.Text
                ));
            lst.Add(new DbSearchObject(
                "Email"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpEmail.Text
                ));
            lst.Add(new DbSearchObject(
                "EmergencyContact"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpEC.Text
                ));
            lst.Add(new DbSearchObject(
                "EmergencyContactTel"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpECTel.Text
                ));
            lst.Add(new DbSearchObject(
                "BankBookImg"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpBankBook.Text
                ));
            lst.Add(new DbSearchObject(
                "BankAccount"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpBank.Text
                ));
            lst.Add(new DbSearchObject(
                "Addr"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpAddress.Text
                ));
            lst.Add(new DbSearchObject(
                "IsValid"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "1"
                ));
            lst.Add(new DbSearchObject(
                "Salary"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpSalary.Text
                ));
            lst.Add(new DbSearchObject(
                "InsuranceId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpInsurance.Text
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpRemark.Text
                ));
            lst.Add(new DbSearchObject(
                "OnBoard"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , EmpOnBoardDay.Text
                ));
            lst.Add(new DbSearchObject(
                "QuitDay"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , EmpQuitDay.Text
                ));
            lst.Add(new DbSearchObject(
                "Bday"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , EmpBDay.Text
                ));
            lst.Add(new DbSearchObject(
                 "CountryId"
                 , AtrrTypeItem.String
                 , AttrSymbolItem.Equal
                 , ddlCountry.SelectedValue
                 ));
            return lst;
        }

        private bool WriteBackInfo(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Employee)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            SysProperty.Util.MsSqlTableConverter(MsSqlTable.Employee)
                            , SysProperty.Util.SqlQueryUpdateConverter(lst)
                            , " Where Id = '" + id + "'");
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }


    }
}