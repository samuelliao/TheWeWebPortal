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
    public partial class DressMCreate : System.Web.UI.Page
    {
        public DataSet RentData;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            if (Session["DressId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.DressMaintainString
                + " > " + Resources.Resource.ModifyString;
                SetDressInfoData(Session["DressId"].ToString());
                tabRentRecord.Visible = true;
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.DressMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
                ddlStore.SelectedValue = Session["LocateStore"] == null
                    ? string.Empty
                    : ((DataRow)Session["LocateStore"])["Id"].ToString();
                tabRentRecord.Visible = false;
            }
        }

        private void TextHint()
        {
            tbSn.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SnString);
            tbColor.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ColorString);
            tbColor2.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ColorString);
            tbMaterial.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.MaterialString);
            tbMaterial2.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.MaterialString);
            tbFitting.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.FittingString);
            tbOthers.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.OtherString);
            tbCustomPrice.Attributes.Add("placeHolder", "0.00");
            tbOutdoorPlusPrice.Attributes.Add("placeHolder", "0.00");
            tbPlusItemPrice.Attributes.Add("placeHolder", "0.00");
            tbRentPrice.Attributes.Add("placeHolder", "0.00");
            tbSellsPrice.Attributes.Add("placeHolder", "0.00");
            tbCost.Attributes.Add("placeHolder", "0.00");
        }


        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage(bool transfer)
        {
            if (transfer)
            {
                Session.Remove("DressId");
                Response.Redirect("DressMaintain.aspx", true);
            }
            else
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
            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                btnCreate.Visible = false;
            }
        }
        private void InitialControl()
        {
            DressCategoryList();
            VeilList();
            DressTypeList();
            GlovesList();
            StoreList();
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
        private void StoreList()
        {
            ddlStore.Items.Clear();
            string sql = "Select * From Store Where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
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
            ddlStatus2.Items.Clear();
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            ddlStatus2.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode where IsDelete = 0";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus2.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
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
            List<DbSearchObject> lst = DressInfoMainDbObject(true);
            bool result = WriteBackInfo(MsSqlTable.Dress, true, lst, string.Empty);
            string dressId = GetCreatedDressId(MsSqlTable.Dress, lst);
            if (!string.IsNullOrEmpty(dressId))
            {
                WriteBackDressStatus(dressId);
                Session["DressId"] = dressId;
                TransferToOtherPage(false);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["DressId"] == null) return;
            bool result = WriteBackInfo(MsSqlTable.Dress, false, DressInfoMainDbObject(false), Session["DressId"].ToString());            
            if (result)
            {
                WriteBackDressStatus(Session["DressId"].ToString());
                TransferToOtherPage(false);
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
            tbOutdoorPlusPrice.Text = string.Empty;
            tbPlusItemPrice.Text = string.Empty;
            tbSellsPrice.Text = string.Empty;
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
            ImgFront.ImageUrl = null;
            ImgBack.ImageUrl = null;
            ImgSide.ImageUrl = null;
            ImgOther1.ImageUrl = null;
            ImgOther2.ImageUrl = null;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(true);
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
                    TransferToOtherPage(true);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
            tbSellsPrice.Text = SysProperty.Util.ParseMoney(dr["SellsPrice"].ToString()).ToString("#0.00");
            tbRentPrice.Text = SysProperty.Util.ParseMoney(dr["RentPrice"].ToString()).ToString("#0.00");
            tbFitting.Text = dr["Fitting"].ToString();
            tbSn.Text = dr["Sn"].ToString();
            ddlBack.SelectedValue = dr["Back"].ToString();
            ddlCorsage.SelectedValue = dr["Corsage"].ToString();
            ddlDressCategory.SelectedValue = dr["Category"].ToString();
            ddlDressType.SelectedValue = dr["Type"].ToString();
            ddlGender.SelectedValue = bool.Parse(dr["Gender"].ToString()) ? "1" : "0";
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
            ddlStore.SelectedValue = dr["StoreId"].ToString();

            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Dress\" + tbSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;

            if (cbPlusItem.Checked)
            {
                tbPlusItemPrice.Text = SysProperty.Util.ParseMoney
                    (dr["PlusItemPrice"].ToString()).ToString("#0.00");
            }
            else
            {
                tbPlusItemPrice.Text = string.Empty;
            }
            if (cbOutPhoto.Checked)
            {
                tbOutdoorPlusPrice.Text = SysProperty.Util.ParseMoney
                    (dr["OutdoorPlusPrice"].ToString()).ToString("#0.00");
            }
            else
            {
                tbOutdoorPlusPrice.Text = string.Empty;
            }

            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    #region Disbale all the control, excluding control that related to price.
                    tbColor.Enabled = false;
                    tbColor2.Enabled = false;
                    tbFitting.Enabled = false;
                    tbMaterial.Enabled = false;
                    tbMaterial2.Enabled = false;
                    tbOthers.Enabled = false;
                    tbSn.Enabled = false;
                    tbSn.CssClass = "Enable";
                    ddlDressCategory.CssClass = "Enable";
                    cbBigSize.Enabled = false;
                    cbDomesticWedding.Enabled = false;
                    cbOutPhoto.Enabled = false;
                    cbPlusItem.Enabled = false;
                    btnClear.Visible = false;
                    ddlBack.Enabled = false;
                    ddlCorsage.Enabled = false;
                    ddlDressCategory.Enabled = false;
                    ddlDressType.Enabled = false;
                    ddlGender.Enabled = false;
                    ddlGloves.Enabled = false;
                    ddlNeckline.Enabled = false;
                    ddlShoulder.Enabled = false;
                    ddlSupplier.Enabled = false;
                    ddlTrailing.Enabled = false;
                    ddlVeil.Enabled = false;
                    ddlWorn.Enabled = false;
                    ddlStore.Enabled = false;
                    divPhotoUpload.Attributes["style"] = "display: none;";
                    #endregion
                }
            }

            // Set Dress Rent Table
            tbDressId2.Text = tbSn.Text;
            BindData();
            if (!SysProperty.Util.IsDataSetEmpty(RentData))
            {
                ddlStatus.SelectedValue = RentData.Tables[0].Rows[0]["StatusCode"].ToString();
            }
        }

        #region Db object instance
        private List<DbSearchObject> DressInfoMainDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text
                ));
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
                    , tbOutdoorPlusPrice.Text
                    ));
            }
            if (cbPlusItem.Checked)
            {
                lst.Add(new DbSearchObject(
                    "PlusItemPrice"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbPlusItemPrice.Text
                    ));
            }
            lst.Add(new DbSearchObject(
                "SellsPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSellsPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "RentPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRentPrice.Text
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
                lst.Add(new DbSearchObject(
                "CreatedateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            }
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "Img"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , @"Dress\" + tbSn.Text
                ));
            return lst;
        }
        private List<DbSearchObject> DressRentDbObject(string dressId, bool isStart)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "DressId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dressId
                ));
            lst.Add(new DbSearchObject(
                (isStart ? "StartTime" : "EndTime")
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            if (isStart && !string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                        "StatusCode"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlStatus.SelectedValue
                        ));
            }
            if (isStart)
            {
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
            return lst;
        }
        #endregion

        private void WriteBackDressStatus(string dressId)
        {
            if (SysProperty.Util.IsDataSetEmpty(RentData))
            {
                GetRentData(dressId, string.Empty, " Order by StartTime DESC");
            }
            if (!SysProperty.Util.IsDataSetEmpty(RentData))
            {
                DataRow dr = RentData.Tables[0].Rows[0];
                string endTime = SysProperty.Util.ParseDateTime("DateTime", dr["EndTime"].ToString());

                // Check the latest status.
                if (string.IsNullOrEmpty(endTime))
                {
                    // Not finish yet, then finish.
                    WriteBackInfo(MsSqlTable.DressRent, false, DressRentDbObject(dressId, false), dr["Id"].ToString());
                }
                if (ddlStatus.SelectedValue != dr["StatusCode"].ToString())
                {
                    WriteBackInfo(MsSqlTable.DressRent, true, DressRentDbObject(dressId, true), dr["Id"].ToString());
                }
            }else
            {
                WriteBackInfo(MsSqlTable.DressRent, true, DressRentDbObject(dressId, true), string.Empty);
            }            
        }

        private string GetCreatedDressId(MsSqlTable table, List<DbSearchObject> item)
        {
            try
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(item.Find(x=>x.AttrName=="Category"));
                lst.Add(item.Find(x => x.AttrName == "StoreId"));
                lst.Add(item.Find(x => x.AttrName == "UpdateAccId"));
                lst.Add(item.Find(x => x.AttrName == "CreatedateAccId"));
                lst.Add(item.Find(x => x.AttrName == "UpdateTime"));
                lst.Add(item.Find(x => x.AttrName == "CreatedateTime"));
                DataSet ds = GetDataFromTable(table, SysProperty.Util.SqlQueryConditionConverter(lst));
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
        private DataSet GetDataFromTable(MsSqlTable table, string conStr)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("*"
                    , SysProperty.Util.MsSqlTableConverter(table)
                    , conStr);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private bool WriteBackInfo(MsSqlTable table, bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            SysProperty.Util.MsSqlTableConverter(table)
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

        protected void cbOutPhoto_CheckedChanged(object sender, EventArgs e)
        {
            tbOutdoorPlusPrice.Enabled = ((CheckBox)sender).Checked;
        }

        protected void cbPlusItem_CheckedChanged(object sender, EventArgs e)
        {
            tbPlusItemPrice.Enabled = ((CheckBox)sender).Checked;
        }

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 1:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 4:
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 5:
                    ImgOther2.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther2.ImageUrl = "http:" + path + "\\" + tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }

        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            bool needRefresh = false;
            CheckFolder(tbFolderPath.Text);
            for (int i = 1; i <= 5; i++)
            {
                FileUpload upload = Page.FindControl("FileUpload" + i) as FileUpload;
                if (upload.HasFile)
                {
                    upload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbSn.Text + "_" + i + ".jpg");
                    needRefresh = true;
                }
            }

            if (needRefresh)
            {
                RefreshImage(0, tbFolderPath.Text);
            }
        }
        #endregion

        #region Rent Data Page
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Session["DressId"] == null) return;
            GetRentData(Session["DressId"].ToString(), QueryCondStr(), " Order by d.StartTime DESC");
            BindData();
        }

        private void BindData()
        {
            if (RentData == null)
            {
                if (Session["DressId"] == null) return;
                GetRentData(Session["DressId"].ToString(), QueryCondStr(), " Order by d.StartTime DESC");
            }
            dataGrid.DataSource = RentData;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(RentData);
            dataGrid.DataBind();
        }

        private void GetRentData(string dressId, string condStr, string sortStr)
        {
            string sql = "SELECT d.[Id],[DressId],d.[UpdateTime],d.[UpdateAccId],d.[CreatedateAccId],d.[CreatedateTime],d.[StartTime]"
                + ",[EndTime],d.StatusCode,[OrderId],o.ChurchId,o.Sn As OrderSn,o.CountryId"
                + " FROM [dbo].[DressRent] AS d"
                + " Left join OrderInfo as o on o.Id = d.OrderId"
                + " Where d.IsDelete = 0 And d.DressId = '" + dressId + "'"
                + condStr
                + sortStr;
            RentData = GetDataSetFromTable(sql);
        }

        private string QueryCondStr()
        {
            string condStr = string.Empty;
            if (!string.IsNullOrEmpty(ddlStatus2.SelectedValue))
            {
                condStr += " And d.StatusCode = '" + ddlStatus2.SelectedValue + "'";
            }
            if (!string.IsNullOrEmpty(tbSearchStartDate.Text))
            {
                condStr += " And d.StartTime = '" + tbSearchStartDate.Text + "'";
            }
            if (!string.IsNullOrEmpty(tbSearchEndDate.Text))
            {
                condStr += " And d.EndTime = '" + tbSearchEndDate.Text + "'";
            }
            return condStr;
        }

        #region Rent Table
        protected void dataGrid_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dataGrid.CurrentPageIndex = e.NewPageIndex;
            BindData();
        }

        protected void dataGrid_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Item.DataItem;
            if (dataItem1 != null)
            {
                ((Label)e.Item.FindControl("labelStatus")).Text = ddlStatus2.Items.FindByValue(dataItem1["StatusCode"].ToString()).Text;
                if (!string.IsNullOrEmpty(dataItem1["ChurchId"].ToString()))
                {
                    ((Label)e.Item.FindControl("labelLocation")).Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , SysProperty.GetChurchById(dataItem1["ChurchId"].ToString()))
                    + "(" + (SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(),
                    SysProperty.GetCountryById(dataItem1["CountryId"].ToString()))) + ")";
                }
                LinkButton hyperLink2 = (LinkButton)e.Item.FindControl("linkConsult");
                hyperLink2.CommandArgument = dataItem1["OrderId"].ToString();
                hyperLink2.Text = dataItem1["OrderSn"].ToString();
                hyperLink2.Enabled = IsHyperLinkEnable("CaseMCreate");
            }
        }

        private bool IsHyperLinkEnable(string pageName)
        {
            PermissionUtil util = new PermissionUtil();
            string sn = util.OperationSn(pageName);
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], sn);
            if (item == null) return false;
            return item.CanEntry;
        }

        protected void dataGrid_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            if (RentData == null)
            {
                if (Session["DressId"] == null) return;
                GetRentData(Session["DressId"].ToString(), QueryCondStr()
                    , "Order by d." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (RentData != null)
            {
                dataGrid.DataSource = RentData;
                dataGrid.DataBind();
            }
        }
        #endregion

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CaseMCreate.aspx");
        }
        #endregion

    }
}