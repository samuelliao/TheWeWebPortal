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
    public partial class DressMCreate : System.Web.UI.Page
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

                    if (Session["DressId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.DressString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetDressInfoData(Session["DressId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.DressString
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
            Session.Remove("DressId");
            Response.Redirect("DressMaintain.aspx", true);
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
        }
        private void InitialControl()
        {
            DressCategoryList();
            VeilList();
            DressTypeList();            
            GlovesList();
            NecklineList();
            ShoulderList();
            StatusCodeList();
            UserStatusList();
            SupplierList();
            WornList();
            TrailingList();
            CorsageList();
            GenderList();
            DressBackList();
        }

        #region DropDownList Control
        private void DressBackList()
        {
            ddlBack.Items.Clear();
            ddlBack.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressBack Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlBack.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void VeilList()
        {
            ddlVeil.Items.Clear();
            ddlVeil.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressVeil where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlVeil.Items.Add(new ListItem(
                    dr["Sn"].ToString()
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void DressTypeList()
        {
            ddlDressType.Items.Clear();
            ddlDressType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressType where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlDressType.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void DressCategoryList()
        {
            ddlDressCategory.Items.Clear();
            ddlDressCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressCategory where IsDelete = 0 And Type='Dress'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlDressCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void GlovesList()
        {
            ddlGloves.Items.Clear();
            ddlGloves.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressGloves where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlGloves.Items.Add(new ListItem(
                    dr["Sn"].ToString()
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void NecklineList()
        {
            ddlNeckline.Items.Clear();
            ddlNeckline.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressNeckline where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlNeckline.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void ShoulderList()
        {
            ddlShoulder.Items.Clear();
            ddlShoulder.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressShoulder where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlShoulder.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void StatusCodeList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void UserStatusList()
        {
            ddlUseStatus.Items.Clear();
            ddlUseStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressUseStatus where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlUseStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void SupplierList()
        {
            ddlSupplier.Items.Clear();
            ddlSupplier.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressSupplier where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlSupplier.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void WornList()
        {
            ddlWorn.Items.Clear();
            ddlWorn.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressWorn where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlWorn.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void TrailingList()
        {
            ddlTrailing.Items.Clear();
            ddlTrailing.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressTrailing where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlTrailing.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void CorsageList()
        {
            ddlCorsage.Items.Clear();
            ddlCorsage.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressCorsage where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCorsage.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void GenderList()
        {
            ddlGender.Items.Clear();
            ddlGender.Items.Add(new ListItem(Resources.Resource.FemaleString, "0"));
            ddlGender.Items.Add(new ListItem(Resources.Resource.MaleString, "1"));
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Dress), tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            bool result = WriteBackInfo(true, DressInfoDbObject(), string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {            
            if (Session["DressId"] == null) return;
            bool result = WriteBackInfo(false, DressInfoDbObject(), Session["DressId"].ToString());
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbColor.Text = string.Empty;
            tbCost.Text = string.Empty;
            tbCustomPrice.Text = string.Empty;
            tbMaterial.Text = string.Empty;
            tbOthers.Text = string.Empty;
            tbFitting.Text = string.Empty;
            tbOutPhotoPrice.Text = string.Empty;
            tbPlusItemPrice.Text = string.Empty;
            tbPrice.Text = string.Empty;
            tbRentPrice.Text = string.Empty;
            tbSn.Text = string.Empty;
            ddlBack.SelectedIndex = 0;
            ddlCorsage.SelectedIndex = 0;
            ddlDressCategory.SelectedIndex = 0;
            ddlDressType.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            ddlGloves.SelectedIndex = 0;
            ddlNeckline.SelectedIndex = 0;
            ddlShoulder.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlSupplier.SelectedIndex = 0;
            ddlTrailing.SelectedIndex = 0;
            ddlUseStatus.SelectedIndex = 0;
            ddlVeil.SelectedIndex = 0;
            ddlWorn.SelectedIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE Dress SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ChurchId"].ToString() + "'";
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

        protected void btnUpload4_Click(object sender, EventArgs e)
        {

        }

        protected void btnUpload5_Click(object sender, EventArgs e)
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

        private void SetDressInfoData(string id)
        {
            string sql = "Select * From Dress Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbColor.Text = dr["Color"].ToString();
            tbColor2.Text = dr["Color2"].ToString();
            tbCost.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbCustomPrice.Text = SysProperty.Util.ParseMoney(dr["CustomPrice"].ToString()).ToString("#0.00");
            tbMaterial.Text = dr["Material"].ToString();
            tbMaterial2.Text = dr["Material2"].ToString();
            tbOthers.Text = dr["Description"].ToString();            
            tbPrice.Text = SysProperty.Util.ParseMoney(dr["SellsPrice"].ToString()).ToString("#0.00");
            tbRentPrice.Text = SysProperty.Util.ParseMoney(dr["RentPrice"].ToString()).ToString("#0.00");
            tbFitting.Text = dr["Fitting"].ToString();
            tbSn.Text = dr["Sn"].ToString();
            ddlBack.SelectedValue = dr["Back"].ToString();
            ddlCorsage.SelectedValue = dr["Corsage"].ToString();
            ddlDressCategory.SelectedValue = dr["Category"].ToString();
            ddlDressType.SelectedValue = dr["Type"].ToString();
            ddlGender.SelectedValue = dr["Gender"].ToString();
            ddlGloves.SelectedValue = dr["Gloves"].ToString();
            ddlNeckline.SelectedValue = dr["Neckline"].ToString();
            ddlShoulder.SelectedValue = dr["Shoulder"].ToString();
            ddlStatus.SelectedValue = dr["StatusCode"].ToString();
            ddlSupplier.SelectedValue = dr["Supplier"].ToString();
            ddlTrailing.SelectedValue = dr["Trailing"].ToString();
            ddlUseStatus.SelectedValue = dr["UseStatus"].ToString();
            ddlVeil.SelectedValue = dr["Veil"].ToString();
            ddlWorn.SelectedValue = dr["Worn"].ToString();
            cbBigSize.Checked = bool.Parse(dr["BigSize"].ToString());
            cbDomesticWedding.Checked = bool.Parse(dr["DomesticWedding"].ToString());
            cbOutPhoto.Checked = bool.Parse(dr["OutPicture"].ToString());
            cbPlusItem.Checked = bool.Parse(dr["AddPrice"].ToString());
            if (cbPlusItem.Checked)
            {
                tbPlusItemPrice.Text = SysProperty.Util.ParseMoney(dr["PlusItemPlrice"].ToString()).ToString("#0.00");
            }
            else
            {
                tbPlusItemPrice.Text = string.Empty;
            }
            if (cbOutPhoto.Checked)
            {
                tbOutPhotoPrice.Text = SysProperty.Util.ParseMoney(dr["OutdoorPlusPrice"].ToString()).ToString("#0.00");
            }
            else
            {
                tbOutPhotoPrice.Text = string.Empty;
            }            
        }

        private List<DbSearchObject> DressInfoDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Color"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbColor.Text
                ));
            lst.Add(new DbSearchObject(
                "Color2"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbColor2.Text
                ));
            lst.Add(new DbSearchObject(
                "Fitting"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbFitting.Text
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCost.Text
                ));
            lst.Add(new DbSearchObject(
                "CustomPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCustomPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Material2"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMaterial2.Text
                ));
            lst.Add(new DbSearchObject(
                "Material"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMaterial.Text
                ));
            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthers.Text
                ));
            if (cbOutPhoto.Checked)
            {
                lst.Add(new DbSearchObject(
                    "OutdoorPlusPrice"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbOutPhotoPrice.Text
                    ));
            }
            if (cbPlusItem.Checked)
            {
                lst.Add(new DbSearchObject(
                    "PlusItemPlrice"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbPlusItemPrice.Text
                    ));
            }
            lst.Add(new DbSearchObject(
                "SellsPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "RentPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRentPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text
                ));
            if (!string.IsNullOrEmpty(ddlBack.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Back"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlBack.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlCorsage.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Corsage"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlCorsage.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlDressCategory.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Category"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlDressCategory.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlDressType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlDressType.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlGender.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Gender"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ddlGender.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlGloves.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Gloves"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlGloves.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlNeckline.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Neckline"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlNeckline.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlShoulder.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Shoulder"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlShoulder.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "StatusCode"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlStatus.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlSupplier.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Supplier"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlSupplier.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlTrailing.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Trailing"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlTrailing.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlUseStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "UseStatus"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlUseStatus.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlVeil.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Veil"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlVeil.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlWorn.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Worn"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlWorn.SelectedValue
                    ));
            }
            lst.Add(new DbSearchObject(
                "BigSize"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbBigSize.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "DomesticWedding"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbDomesticWedding.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "OutPicture"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbOutPhoto.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "AddPrice"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbPlusItem.Checked ? "1" : "0"
                ));

            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
                ));
            return lst;
        }

        private bool WriteBackInfo(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Dress)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            SysProperty.Util.MsSqlTableConverter(MsSqlTable.Dress)
                            , SysProperty.Util.SqlQueryUpdateConverter(lst)
                            , " Where Id = '" + id + "'");
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        protected void cbOutPhoto_CheckedChanged(object sender, EventArgs e)
        {
            tbOutPhotoPrice.Enabled = ((CheckBox)sender).Checked;
        }

        protected void cbPlusItem_CheckedChanged(object sender, EventArgs e)
        {
            tbPlusItemPrice.Enabled = ((CheckBox)sender).Checked;
        }
    }
}