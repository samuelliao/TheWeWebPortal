using NLog;
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
        private Logger Log;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Log == null)
            {
                Log = NLog.LogManager.GetCurrentClassLogger();
            }
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialPage();
                }
            }
        }

        private void InitialPage()
        {
            InitialControl();
            InitialControlWithPermission();
            TextHint();
            if (Session["EmpId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.EmployeeMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetEmpInfoData(Session["EmpId"].ToString());
                CheckStoreHolderPermission();
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.EmployeeMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
                EmpOnBoardDay.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void TextHint()
        {
            tbAccount.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AccountString);
            tbEmpAddress.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.AddressString);
            tbEmpBank.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BankString);
            tbEmpBankBook.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BankBookString);
            tbEmpEC.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.EmergencyContactString);
            tbEmpECTel.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.EmergencyContactTelString);
            tbEmpEmail.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.EmailString);
            tbEmpInsurance.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.InsuranceString);
            tbEmpName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.NameString);
            tbEmpPassportId.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.PassportIdString);
            tbEmpPassportName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.PassportNameString);
            tbEmpPhone.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.PhoneString);
            tbEmpRemark.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.RemarkString);
            tbEmpSalary.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.SalaryString);
            tbEmpSn.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.SnString);
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage(bool reload)
        {
            if (!reload)
            {
                Session.Remove("EmpId");
                Response.Redirect("EmployeeMaintain.aspx", true);
            }else
            {
                InitialPage();
            }
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
            if (ddlStore.Enabled == false)
            {
                ddlStore.CssClass = "Enable";
            }
            else ddlStore.CssClass = "required";
        }
        private void CheckStoreHolderPermission()
        {
            DataRow user = Session["AccountInfo"] as DataRow;
            bool holder = bool.Parse(user["StoreHolder"].ToString());
            if (!holder)
            {
                TransferToOtherPage(false);
            }
        }

        private void InitialControl()
        {
            CountryList();
            StoreList();
        }

        #region DropDownList Control
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
                Log.Error(ex.Message);
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAccount.Text) || string.IsNullOrEmpty(tbEmpName.Text))
            {
                ShowErrorMsg(Resources.Resource.FieldEmptyString);
                return;
            }
            if (SysProperty.GenDbCon.IsAccountDuplicate(tbAccount.Text, ddlStore.SelectedValue))
            {
                ShowErrorMsg(Resources.Resource.DuplicateAccountString);
                tbAccount.Text = string.Empty;
                return;
            }
            List<DbSearchObject> lst = EmployeeInfoDbObject(true);
            bool result = WriteBackInfo(true, lst, string.Empty);
            if (!result) return;
            //string eid = GetCreatedDataId(MsSqlTable.vwEN_Employee, lst);


            string eid = GetCreatedDataId(true, MsSqlTable.vwEN_Employee, lst);
            if (string.IsNullOrEmpty(eid)) return;

            //這段沒做到
            lst = PermissionDbObject(true, eid);

            //OK
            result = WriteBackPermission(lst);
            if (!result) return;


            string pid = GetCreatedDataId(false, MsSqlTable.Permission, lst);
            if (string.IsNullOrEmpty(pid)) return;

            result = WriteBackPermissionItem(PermissionItemDbObject(true, pid), pid, "Store");
            if (result)
            {
                Session["EmpId"] = eid;
                TransferToOtherPage(true);
            }
            //
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["EmpId"] == null) return;
            bool result = WriteBackInfo(false, EmployeeInfoDbObject(string.IsNullOrEmpty(labelPw.Text)), Session["EmpId"].ToString());
            if (result)
            {
                TransferToOtherPage(true);
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
            ImgFront.ImageUrl = null;
            ImgBack.ImageUrl = null;
            ImgSide.ImageUrl = null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
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
                    TransferToOtherPage(false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
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
                Log.Error(ex.Message);
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
            labelPw.Text = string.IsNullOrEmpty(dr["AccInfo"].ToString()) ? string.Empty : "1";
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
            cbStoreHolder.Checked = bool.Parse(dr["StoreHolder"].ToString());
            tbEmpBankBook.Text = dr["BankBookImg"].ToString();
            tbEmpBank.Text = dr["BankAccount"].ToString();
            EmpQuitDay.Text = SysProperty.Util.ParseDateTime("Date", dr["QuitDay"].ToString());
            EmpOnBoardDay.Text = SysProperty.Util.ParseDateTime("Date", dr["OnBoard"].ToString());
            EmpBDay.Text = SysProperty.Util.ParseDateTime("Date", dr["Bday"].ToString());
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
        private List<DbSearchObject> EmployeeInfoDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "AccInfo"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , SysProperty.Util.GetMD5(tbAccount.Text.Trim())
                ));
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
            lst.Add(new DbSearchObject(
                "StoreHolder"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbStoreHolder.Checked ? "1" : "0"
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
                "Account"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAccount.Text.Trim()
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
                , AtrrTypeItem.Bit
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
            "UpdateAccId"
            , AtrrTypeItem.String
            , AttrSymbolItem.Equal
            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
            ));
            lst.Add(new DbSearchObject(
                            "UpdateTime"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            ));
            return lst;
        }
        private List<DbSearchObject> PermissionDbObject(bool isCreate, string eid)
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
                            "UpdateTime"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
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
        private List<DbSearchObject> PermissionItemDbObject(bool isCreate, string pid)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue
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
                            "UpdateTime"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                            ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
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
                , (ddlStore.SelectedItem.Text.Split('('))[1].Replace(")", "")
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

        #region Db data writeback
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        private string GetCreatedDataId(bool isAccount, MsSqlTable table, List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds;
                if (isAccount)
                {
                    string sql = "SELECT Id From " + SysProperty.Util.MsSqlTableConverter(table)
                        + " Where AccInfo=N'" + lst.Where(x => x.AttrName == "AccInfo").ToList()[0].AttrValue + "'"
                        + " And StoreHolder=" + (cbStoreHolder.Checked ? "1" : "0")
                        + " And Name=N'" + tbEmpName.Text + "'"
                        + " And Account=N'" + tbAccount.Text + "'"
                        + " And IsValid=1"
                        + " And OnBoard=N'" + EmpOnBoardDay.Text + "'"
                        + " And CountryId=N'" + ddlCountry.SelectedValue + "'"
                        + " And StoreId=N'" + ddlStore.SelectedValue + "'";
                    ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                }
                else
                {
                    ds = SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(table)
                    , SysProperty.Util.SqlQueryConditionConverter(lst));
                }
                if (SysProperty.Util.IsDataSetEmpty(ds)) return string.Empty;
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
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
                Log.Error(ex.Message);
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
                    Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                }
                return result;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        #endregion

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 2:
                    ImgFront.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgBack.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 1:
                    ImgSide.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "/" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            bool needRefresh = false;
            CheckFolder(tbFolderPath.Text);
            for (int i = 1; i <= 3; i++)
            {
                FileUpload upload = divUpload.FindControl("FileUpload" + i) as FileUpload;
                if (upload == null) continue;
                if (upload.HasFile)
                {
                    upload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbEmpSn.Text + "_" + i + ".jpg");
                    needRefresh = true;
                }
            }

            if (needRefresh)
            {
                RefreshImage(0, tbFolderPath.Text);
            }
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