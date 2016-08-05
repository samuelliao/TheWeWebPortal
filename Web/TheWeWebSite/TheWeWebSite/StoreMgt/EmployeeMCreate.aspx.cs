using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                    InitialControlWithPermission();
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
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnCreate.Visible = item.CanCreate;
            btnCreate.Enabled = item.CanCreate;
            btnDelete.Visible = item.CanDelete;
            btnDelete.Enabled = item.CanDelete;
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                ddlStore.Enabled = true;
            }
        }
        private void InitialControl()
        {
            CountryList();
            StoreList();
        }
        private void StoreList()
        {
            ddlStore.Items.Clear();
            try
            {
                string sql = "select * from Store Where IsDelete = 0 order by Sn";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStore.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(
                                Session["CultureCode"].ToString(), dr)
                                + "(" + dr["Sn"].ToString() + ")"
                            , dr["Id"].ToString(), true));
                }
                ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void CountryList()
        {
            ddlCountry.Items.Clear();
            try
            {
                ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty, true));
                string sql = "select * from Country Where IsDelete = 0 order by Name";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(
                                Session["CultureCode"].ToString(), dr)
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
            List<DbSearchObject> lst = EmployeeInfoDbObject();
            bool result = WriteBackInfo(true, lst, string.Empty);
            if (!result) return;
            string eid = GetCreatedDataId(MsSqlTable.vwEN_Employee, lst);
            if (string.IsNullOrEmpty(eid)) return;
            lst = PermissionDbObject(eid);
            result = WriteBackPermission(lst);
            if (!result) return;
            string pid = GetCreatedDataId(MsSqlTable.Permission, lst);
            if (!string.IsNullOrEmpty(pid)) return;
            result = WriteBackPermissionItem(PermissionItemDbObject(pid), pid, "Store");
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
            tbAccount.Text = string.Empty;
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
                + ", QuitDay='" + DateTime.Now.ToString("yyyy / MM / dd HH: mm: ss") + "'"
                + ", IsValid = 0"
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
            string sql = "Select * From vwEN_Employee Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbEmpAddress.Text = dr["Addr"].ToString();
            tbEmpSn.Text = dr["Sn"].ToString();
            tbEmpSalary.Text = SysProperty.Util.ParseMoney(dr["Salary"].ToString()).ToString("#0.00");
            tbEmpRemark.Text = dr["Remark"].ToString();
            tbEmpPhone.Text = dr["Phone"].ToString();
            tbEmpPassportName.Text = dr["PassportName"].ToString();
            tbEmpPassportId.Text = dr["PassportId"].ToString();
            tbEmpName.Text = dr["Name"].ToString();
            tbEmpInsurance.Text = dr["InsuranceId"].ToString();
            tbEmpEmail.Text = dr["Email"].ToString();
            tbEmpECTel.Text = dr["EmContPhone"].ToString();
            tbEmpEC.Text = dr["EmContName"].ToString();
            tbEmpBankBook.Text = dr["BankBookImg"].ToString();
            tbEmpBank.Text = dr["BankAccount"].ToString();
            EmpQuitDay.Text = dr["QuitDay"].ToString();
            EmpOnBoardDay.Text = dr["OnBoard"].ToString();
            EmpBDay.Text = dr["Bday"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            tbAccount.Text = dr["Account"].ToString();
            ddlStore.SelectedValue = dr["StoreId"].ToString();

            string imgPath = @dr["PhotoImg"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Employee\" + tbEmpSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;
        }

        #region Db Instance
        private List<DbSearchObject> EmployeeInfoDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();

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
                "Account"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAccount.Text
                ));
            lst.Add(new DbSearchObject(
                "EmContName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmpEC.Text
                ));
            lst.Add(new DbSearchObject(
                "EmContPhone"
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
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "PhotoImg"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , @"Employee\" + tbEmpSn.Text
                ));
            return lst;
        }
        private List<DbSearchObject> PermissionDbObject(string eid)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , eid
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "Store"
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAccount.Text
                ));
            return lst;
        }
        private List<DbSearchObject> PermissionItemDbObject(string pid)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Sn"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , "Store"
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "PermissionId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , pid
                ));
            lst.Add(new DbSearchObject(
                "ObjectSn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue
                ));
            lst.Add(new DbSearchObject(
            "CanEntry"
            , AtrrTypeItem.Bit
            , AttrSymbolItem.Equal
            , "1"
            ));
            lst.Add(new DbSearchObject(
            "CanCreate"
            , AtrrTypeItem.Bit
            , AttrSymbolItem.Equal
            , "1"
            ));
            lst.Add(new DbSearchObject(
            "CanModify"
            , AtrrTypeItem.Bit
            , AttrSymbolItem.Equal
            , "1"
            ));
            lst.Add(new DbSearchObject(
            "CanDelete"
            , AtrrTypeItem.Bit
            , AttrSymbolItem.Equal
            , "1"
            ));
            lst.Add(new DbSearchObject(
            "CanExport"
            , AtrrTypeItem.Bit
            , AttrSymbolItem.Equal
            , "1"
            ));
            return lst;
        }
        #endregion

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
        private string GetCreatedDataId(MsSqlTable table, List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(table)
                    , SysProperty.Util.SqlQueryConditionConverter(lst));
                if (SysProperty.Util.IsDataSetEmpty(ds)) return string.Empty;
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }
        private bool WriteBackPermission(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Permission)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        private bool WriteBackPermissionItem(List<DbSearchObject> lst, string permissionId, string type)
        {
            try
            {
                bool result = true;
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From PermissionItem"
                    + " Where PermissionId='" + permissionId + "' And Type = '" + type + "'");
                try
                {
                    result = result & SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst));
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                }
                return result;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 2:
                    ImgFront.ImageUrl = path + "/" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgBack.ImageUrl = path + "/" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 1:
                    ImgSide.ImageUrl = path + "/" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = path + "/" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = path + "/" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = path + "/" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }

        protected void btnImgFrontUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\Employee\" + tbEmpSn.Text);
            ImgFrontUpload.PostedFile.SaveAs(tbFolderPath.Text + "/" + tbEmpSn.Text + "_2.jpg");
            RefreshImage(2, tbFolderPath.Text);
        }

        protected void btnImgBackUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\Employee\" + tbEmpSn.Text);
            ImgBackUpload.PostedFile.SaveAs(tbFolderPath.Text + "/" + tbEmpSn.Text + "_3.jpg");
            RefreshImage(3, tbFolderPath.Text);
        }

        protected void btnImgSideUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\Employee\" + tbEmpSn.Text);
            ImgSideUpload.PostedFile.SaveAs(tbFolderPath.Text + "/" + tbEmpSn.Text + "_1.jpg");
            RefreshImage(1, tbFolderPath.Text);
        }

        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion
    }
}