using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.Setting
{
    public partial class AccInfoSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null || Session["AccountInfo"] == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    labelPageTitle.Text = Resources.Resource.SettingString
                    + " > " + Resources.Resource.AccountSettingString;
                    SetEmpInfoData(((DataRow)Session["AccountInfo"]));
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
            Response.Redirect("AccInfoSetting.aspx", true);
        }
        #region Button Control
        protected void btnModify_Click(object sender, EventArgs e)
        {
            bool modifyPw = !string.IsNullOrEmpty(tbPwd.Text);
            if (tbPwd.Text != tbPwdConfirm.Text)
            {
                ShowErrorMsg(Resources.Resource.PasswordValidationErrorString);
                tbPwd.Text = string.Empty;
                tbPwdConfirm.Text = string.Empty;
                return;
            }
            bool result = WriteBackInfo(false, EmployeeInfoDbObject(modifyPw), ((DataRow)Session["AccountInfo"])["Id"].ToString());
            if (result)
            {
                ResetAccountInfo();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }
        private void ResetAccountInfo()
        {
            string sql = "Select * From vwEN_Employee Where Id = '" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                Session["AccountInfo"] = ds.Tables[0].Rows[0];
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
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetEmpInfoData(DataRow dr)
        {
            tbEmpAddress.Text = dr["Addr"].ToString();
            labelPw.Text = string.IsNullOrEmpty(dr["AccInfo"].ToString()) ? string.Empty : "1";
            tbEmpSn.Text = dr["Sn"].ToString();
            tbEmpPhone.Text = dr["Phone"].ToString();
            tbEmpPassportName.Text = dr["PassportName"].ToString();
            tbEmpPassportId.Text = dr["PassportId"].ToString();
            tbEmpName.Text = dr["Name"].ToString();
            tbEmpEmail.Text = dr["Email"].ToString();
            tbEmpECTel.Text = dr["EmContPhone"].ToString();
            tbEmpEC.Text = dr["EmContName"].ToString();
            tbEmpBankBook.Text = dr["BankBookImg"].ToString();
            tbEmpBank.Text = dr["BankAccount"].ToString();
            EmpOnBoardDay.Text = SysProperty.Util.ParseDateTime("Date", dr["OnBoard"].ToString());
            EmpBDay.Text = SysProperty.Util.ParseDateTime("Date", dr["Bday"].ToString());
            tbAccount.Text = dr["Account"].ToString();

            string imgPath = @dr["PhotoImg"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Employee\" + tbEmpSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;
        }

        #region Db Instance
        private List<DbSearchObject> EmployeeInfoDbObject(bool changePwd)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (changePwd)
            {
                lst.Add(new DbSearchObject(
                "AccInfo"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , SysProperty.Util.GetMD5(tbPwd.Text)
                ));
            }
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
                "Bday"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , EmpBDay.Text
                ));
            lst.Add(new DbSearchObject(
                "PhotoImg"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , @"Employee\" + tbEmpSn.Text
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

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 2:
                    ImgFront.ImageUrl = "http:"+path + "\\" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 1:
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbEmpSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbEmpSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbEmpSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }

        protected void btnImgFrontUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(tbFolderPath.Text);
            ImgFrontUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbEmpSn.Text + "_2.jpg");
            RefreshImage(2, tbFolderPath.Text);
        }

        protected void btnImgBackUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(tbFolderPath.Text);
            ImgBackUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbEmpSn.Text + "_3.jpg");
            RefreshImage(3, tbFolderPath.Text);
        }

        protected void btnImgSideUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(tbFolderPath.Text);
            ImgSideUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbEmpSn.Text + "_1.jpg");
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