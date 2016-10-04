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
    public partial class FittingMCreate : System.Web.UI.Page
    {
        DataSet RentData;
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
            InitialControls();
            InitialControlWithPermission();
            TextHint();
            if (Session["FittingId"] != null && Session["FittingCategory"] != null)
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.AccessoryMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetAllData(Session["FittingCategory"].ToString(), Session["FittingId"].ToString());
                btnCreate.Visible = false;
                tabRentRecord.Visible = true;
                ddlCategory.Enabled = false;
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.AccessoryMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
                tabRentRecord.Visible = false;
                ddlCategory.Enabled = true;
            }
        }
        private void TextHint()
        {
            tbSn.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SnString);
            tbColor1.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ColorString);
            tbColor2.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ColorString);
            tbCost.Attributes.Add("placeHolder", "0.00");
            tbLace.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.Lacestring);
            tbMaterial1.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.MaterialString);
            tbMaterial2.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.MaterialString);
            tbOptionalPrice.Attributes.Add("placeHolder", "0.00");
            tbRelatedSn.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.CorrespondSnString);
            tbRentPrice.Attributes.Add("placeHolder", "0.00");
            tbSalesPrice.Attributes.Add("placeHolder", "0.00");
            tbType.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.CreateItemString);


        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage(bool reload)
        {
            if (reload)
            {
                InitialPage();
            }
            else
            {
                Session.Remove("FittingId");
                Session.Remove("FittingCategory");
                Response.Redirect("~/StoreMgt/FittingMaintain.aspx", true);
            }
        }

        private void InitialControls()
        {
            FittingCategoryList();
            FittingTypeList();
            StatusList();
            EarringDropDownList();
            LengthDropDownList();
            GenderList();
            SupplierList();
            RelatedCategory();
            StoreList();

        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    btnCreate.Visible = false;
                    btnClear.Visible = false;
                    ddlStore.Enabled = false;
                }
            }
            else
            {
                PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
                btnCreate.Visible = item.CanCreate;
                btnCreate.Enabled = item.CanCreate;
                btnDelete.Visible = item.CanDelete;
                btnDelete.Enabled = item.CanDelete;
                btnModify.Visible = item.CanModify;
                btnModify.Enabled = item.CanModify;
                ddlStore.Enabled = true;
            }
        }

        private void SetDivByAccessoryCategory(string category)
        {
            ResetAllDivControl();
            switch (category)
            {
                case "AccessoryMan":
                    divLength.Visible = true;
                    break;
                case "DressGloves":
                    divGender.Visible = true;
                    divLength.Visible = true;
                    break;
                case "DressEarring":
                    //this.Page.FindControl("divColor2")
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    divEarringType.Visible = true;
                    break;
                case "DressNecklace":
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    break;
                case "DressVeil":
                    divMaterial1.Visible = false;
                    divLength.Visible = true;
                    break;
                case "DressClogs":
                    divRelatedCategory.Visible = true;
                    divRelatedSn.Visible = true;
                    break;
                case "DressBouquet":
                case "DressBracelet":
                case "DressHeadwear":
                    divColor2.Visible = true;
                    divMaterial2.Visible = true;
                    break;
                case "DressShawl":
                case "AccessoryOther":
                case "AccessoryRingPillow":
                default:
                    break;
            }
        }

        private void ResetAllDivControl()
        {
            divColor2.Visible = false;
            divEarringType.Visible = false;
            divGender.Visible = false;
            divLace.Visible = false;
            divLength.Visible = false;
            divMaterial1.Visible = true;
            divMaterial2.Visible = false;
            divRelatedCategory.Visible = false;
            divRelatedSn.Visible = false;
        }

        #region DropDownList
        private void StoreList()
        {
            ddlStore.Items.Clear();
            string sql = "select * from Store Where IsDelete=0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
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
        private void EarringDropDownList()
        {
            ddlEarringType.Items.Clear();
            ddlEarringType.Items.Add(new ListItem(Resources.Resource.EarPiercingString, "0"));
            ddlEarringType.Items.Add(new ListItem(Resources.Resource.EarClipString, "1"));
        }
        private void LengthDropDownList()
        {
            ddlLength.Items.Clear();
            ddlLength.Items.Add(new ListItem(Resources.Resource.ExtraShortString, "0"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.ShortString, "1"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.MediumString, "2"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.LongString, "3"));
            ddlLength.Items.Add(new ListItem(Resources.Resource.ExtraLongString, "4"));
            ddlLength.SelectedValue = "2";
        }
        private void FittingCategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory2.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            ddlCategory2.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where Type='Accessory' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Description"].ToString()
                    ));
                ddlCategory2.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
            //ddlCategory.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
            //ddlCategory2.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }
        private void FittingTypeList()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where IsDelete=0 And Type='"
                + GetTypeNameFromCategory(ddlCategory.SelectedValue) + "' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString()
                        ));
                }
            }
            ddlType.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));            
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "CreateItem")
            {
                //  divNewType.Attributes.Add("visible", "ture");
                tbType.Attributes["style"] = "display: inline;";
                tbType.Text = string.Empty;
                divNewType.Attributes["style"] = "display: inline;";
            }
            else
            {
                //  divNewType.Attributes.Add("visible", "false");
                tbType.Attributes["style"] = "display: none;";
                divNewType.Attributes["style"] = "display: none;";
                tbType.Text = string.Empty;
            }
        }
        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus2.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            ddlStatus2.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
                ddlStatus2.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCategory2.SelectedIndex = ddlCategory.SelectedIndex;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            FittingTypeList();
            SetDivByAccessoryCategory(ddlCategory.SelectedValue);            
        }
        private void SupplierList()
        {
            ddlSupplier.Items.Clear();
            ddlSupplier.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressSupplier Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlSupplier.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void RelatedCategory()
        {
            ddlRelatedCategory.Items.Clear();
            ddlRelatedCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where Type in ('Accessory','Dress') Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlRelatedCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Description"].ToString()
                    ));
            }
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            List<DbSearchObject> lst = AccessoryDbObject(true, typeId);
            bool result = WriteBackData(ddlCategory.SelectedValue, lst, true, string.Empty);
            string id = GetCreatedId(ddlCategory.SelectedValue, lst);
            if (!string.IsNullOrEmpty(id))
            {
                Session["FittingCategory"] = ddlCategory.SelectedValue;
                Session["FittingId"] = id;
                WriteBackDressStatus(ddlCategory2.SelectedValue, Session["FittingId"].ToString());
                TransferToOtherPage(true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSn.Text)) return;
            if (Session["FittingId"] == null || Session["FittingCategory"] == null) return;
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackData(ddlCategory.SelectedValue, AccessoryDbObject(false, typeId), false, Session["FittingId"].ToString());
            if (result)
            {
                WriteBackDressStatus(ddlCategory2.SelectedValue, Session["FittingId"].ToString());
                TransferToOtherPage(true);
            }
        }

        private string CreateNewType(string ddlValue)
        {
            bool result = true;
            string typeId = string.Empty;
            if (ddlValue == "CreateItem")
            {
                if (string.IsNullOrEmpty(tbType.Text))
                {
                    ShowErrorMsg(Resources.Resource.BlankFieldString);
                    return string.Empty;
                }
                else
                {
                    List<DbSearchObject> lst = DressCategoryDbObject(true);
                    result = WriteBackData(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.DressCategory)
                        , lst, true, string.Empty);
                    if (!result) return string.Empty;
                    typeId = GetCreatedId(MsSqlTable.DressCategory, lst);
                }
            }
            else
            {
                typeId = ddlValue;
            }
            return typeId;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbColor1.Text = string.Empty;
            tbColor2.Text = string.Empty;
            tbCost.Text = string.Empty;
            tbMaterial1.Text = string.Empty;
            tbMaterial2.Text = string.Empty;
            tbOptionalPrice.Text = string.Empty;
            tbRelatedSn.Text = string.Empty;
            tbRentPrice.Text = string.Empty;
            tbSalesPrice.Text = string.Empty;
            tbSn.Text = string.Empty;
            ddlCategory.SelectedIndex = 0;
            ddlLength.SelectedIndex = 0;
            ddlRelatedCategory.SelectedIndex = 0;
            ddlStatus.SelectedIndex = 0;
            ddlSupplier.SelectedIndex = 0;
            ddlType.SelectedIndex = 0;
            ImgFront.ImageUrl = null;
            ImgSide.ImageUrl = null;
            ImgOther1.ImageUrl = null;
            ImgOther2.ImageUrl = null;
            ImgBack.ImageUrl = null;
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["FittingCategory"] == null || Session["FittingId"] == null) return;
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE " + Session["FittingCategory"].ToString() + " SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["FittingId"].ToString() + "'";
                if (SysProperty.GenDbCon.ModifyDataInToTable(sql))
                {
                    TransferToOtherPage(false);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
        }
        #endregion

        private string GetTypeNameFromCategory(string category)
        {
            if (category.StartsWith("Accessory")) return category.Replace("Accessory", string.Empty);
            if (category.StartsWith("Dress")) return category.Replace("Dress", string.Empty);
            return category;
        }

        private void SetAllData(string tableName, string id)
        {
            if (string.IsNullOrEmpty(tableName) || string.IsNullOrEmpty(id)) return;
            ddlCategory.SelectedValue = tableName;
            ddlCategory2.SelectedIndex = ddlCategory.SelectedIndex;
            FittingTypeList();
            SetDivByAccessoryCategory(tableName);
            string sql = "Select * From " + tableName + " Where Id='" + id + "'";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbCost.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbOptionalPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbRentPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbSalesPrice.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbSn.Text = dr["Sn"].ToString();
            tbDressId2.Text = tbSn.Text;
            tbColor1.Text = dr["Color"].ToString();
            tbMaterial1.Text = dr["Material"].ToString();
            ddlType.SelectedValue = dr["Category"].ToString();
            ddlType_SelectedIndexChanged(ddlType, new EventArgs());
            ddlSupplier.SelectedValue = dr["SupplierId"].ToString();
            ddlStatus.SelectedValue = dr["StatusCode"].ToString();            
            ddlStore.SelectedValue = dr["StoreId"].ToString();
            try { tbColor2.Text = dr["Color2"].ToString(); }
            catch { tbColor2.Text = string.Empty; }
            try { tbMaterial2.Text = dr["Material2"].ToString(); }
            catch { tbMaterial2.Text = string.Empty; }
            try { tbRelatedSn.Text = dr["PairSn"].ToString(); }
            catch { tbRelatedSn.Text = string.Empty; }
            try { ddlEarringType.SelectedValue = dr["Type"].ToString(); }
            catch { ddlEarringType.SelectedIndex = 0; }
            try { ddlGender.SelectedValue = dr["Gender"].ToString(); }
            catch { ddlGender.SelectedIndex = 0; }
            try { ddlLength.SelectedValue = dr["Length"].ToString(); }
            catch { ddlLength.SelectedIndex = 0; }
            try { ddlRelatedCategory.SelectedValue = dr["PairId"].ToString(); }
            catch { ddlRelatedCategory.SelectedIndex = 0; }
            BindData();
            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\" + tableName + @"\" + tbSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;

            if (Session["LocateStore"] != null)
            {
                if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
                {
                    tbColor1.Enabled = false;
                    tbColor2.Enabled = false;
                    tbCost.Enabled = false;
                    tbFolderPath.Enabled = false;
                    tbLace.Enabled = false;
                    tbMaterial1.Enabled = false;
                    tbMaterial2.Enabled = false;
                    tbRelatedSn.Enabled = false;
                    tbSn.Enabled = false;
                    tbSn.CssClass = "Enable";
                    ddlCategory.CssClass = "Enable";
                    ddlType.CssClass = "Enable";
                    tbType.Enabled = false;
                    ddlCategory.Enabled = false;
                    ddlEarringType.Enabled = false;
                    ddlGender.Enabled = false;
                    ddlLength.Enabled = false;
                    ddlRelatedCategory.Enabled = false;
                    ddlStore.Enabled = false;
                    ddlSupplier.Enabled = false;
                    ddlType.Enabled = false;
                    divPhotoUpload.Attributes["style"] = "display: none;";
                }
            }
        }

        #region Db Instance
        private List<DbSearchObject> AccessoryDbObject(bool isCreate, string typeId)
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
                , tbColor1.Text
                ));
            lst.Add(new DbSearchObject(
                "Material"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMaterial1.Text
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCost.Text
                ));
            lst.Add(new DbSearchObject(
                "OptionalPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOptionalPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "RentPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRentPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "SellsPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSalesPrice.Text
                ));
            if (!string.IsNullOrEmpty(ddlType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Category"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , typeId
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
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "StatusCode"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlStatus.SelectedValue
                    ));
            }
            if (divColor2.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Color2"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbColor2.Text
                    ));
            }
            if (divMaterial2.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Material2"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbMaterial2.Text
                    ));
            }
            if (divRelatedSn.Visible)
            {
                lst.Add(new DbSearchObject(
                    "PairSn"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbRelatedSn.Text
                    ));
            }
            if (divRelatedCategory.Visible
                && string.IsNullOrEmpty(ddlRelatedCategory.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "PairId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlRelatedCategory.SelectedValue
                    ));
            }
            if (divGender.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Gender"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ddlGender.SelectedValue
                    ));
            }
            if (divLace.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Lace"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbLace.Text
                    ));
            }
            if (divLength.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Length"
                    , AtrrTypeItem.Integer
                    , AttrSymbolItem.Equal
                    , ddlLength.SelectedValue
                    ));
            }
            if (divEarringType.Visible)
            {
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlEarringType.SelectedValue
                    ));
            }
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
            return lst;
        }
        private List<DbSearchObject> DressCategoryDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbType.Text
                ));

            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCategory.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , GetTypeNameFromCategory(ddlCategory.SelectedValue)
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
            return lst;
        }
        private List<DbSearchObject> RentRecordDbObject(bool isStart, string typeId, string id)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                (isStart ? "StartTime" : "EndTime")
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            lst.Add(new DbSearchObject(
                "DressId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , id
                ));
            lst.Add(new DbSearchObject(
                "Category"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , typeId
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
                lst.Add(new DbSearchObject(
                "CreatedateTime"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            }
            return lst;
        }
        #endregion

        #region Db General Control
        private bool WriteBackData(string tableName, List<DbSearchObject> lst, bool isInsert, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        tableName
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            tableName
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
        private void WriteBackDressStatus(string typeId, string dressId)
        {
            if (string.IsNullOrEmpty(typeId) || string.IsNullOrEmpty(dressId)) return;

            if (SysProperty.Util.IsDataSetEmpty(RentData))
            {
                GetRentData(typeId, dressId, string.Empty, " Order by StartTime DESC");
            }
            if (!SysProperty.Util.IsDataSetEmpty(RentData))
            {
                DataRow dr = RentData.Tables[0].Rows[0];
                string endTime = SysProperty.Util.ParseDateTime("DateTime", dr["EndTime"].ToString());

                // Check the latest status.
                if (string.IsNullOrEmpty(endTime))
                {
                    // Not finish yet, then finish.
                    WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.RentRecord), RentRecordDbObject(false, typeId, dressId), false, dr["Id"].ToString());
                }
                if (ddlStatus.SelectedValue != dr["StatusCode"].ToString())
                {
                    WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.RentRecord), RentRecordDbObject(true, typeId, dressId), true, dr["Id"].ToString());
                }
            }
            else
            {
                WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.RentRecord), RentRecordDbObject(true, typeId, dressId), true, string.Empty);
            }
        }
        private string GetCreatedId(MsSqlTable table, List<DbSearchObject> lst)
        {
            return GetCreatedId(SysProperty.Util.MsSqlTableConverter(table), lst);
        }
        private string GetCreatedId(string table, List<DbSearchObject> lst)
        {
            try
            {
                List<DbSearchObject> conds = new List<DbSearchObject>();
                if (table != SysProperty.Util.MsSqlTableConverter(MsSqlTable.DressCategory))
                {
                    conds.Add(lst.Find(x => x.AttrName == "Category"));
                    conds.Add(lst.Find(x => x.AttrName == "StoreId"));
                    conds.Add(lst.Find(x => x.AttrName == "StatusCode"));
                    conds.Add(lst.Find(x => x.AttrName == "UpdateAccId"));
                    conds.Add(lst.Find(x => x.AttrName == "CreatedateAccId"));
                    conds.Add(lst.Find(x => x.AttrName == "UpdateTime"));
                    conds.Add(lst.Find(x => x.AttrName == "CreatedateTime"));
                }
                else
                {
                    conds = lst;
                }
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Id"
                    , table
                    , SysProperty.Util.SqlQueryConditionConverter(conds));
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
        private DataSet GetDataFromDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private bool ModifyDataToDb(string sql)
        {
            try
            {
                return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
                case 1:
                    ImgFront.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 4:
                    ImgOther1.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 5:
                    ImgOther2.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther1.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther2.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
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
                FileUpload upload = divUpload.FindControl("FileUpload" + i) as FileUpload;
                if (upload == null) continue;
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

        #region Rent Table
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Session["FittingId"] == null && Session["FittingCategory"] == null) return;
            GetRentData(ddlCategory2.SelectedValue, Session["FittingId"].ToString(), QueryCondStr(), " Order by d.StartTime DESC");
            BindData();
        }

        private void BindData()
        {
            if (RentData == null)
            {
                if (Session["FittingId"] == null && Session["FittingCategory"] == null) return;
                GetRentData(ddlCategory2.SelectedValue, Session["FittingId"].ToString(), QueryCondStr(), " Order by d.StartTime DESC");
            }
            dataGrid.DataSource = RentData;
            dataGrid.AllowPaging = !SysProperty.Util.IsDataSetEmpty(RentData);
            dataGrid.DataBind();
        }

        private void GetRentData(string category, string dressId, string condStr, string sortStr)
        {
            string sql = "SELECT d.[Id],[DressId],d.[UpdateTime],d.[UpdateAccId],d.[CreatedateAccId],d.[CreatedateTime],d.[StartTime]"
                + ",[EndTime],d.StatusCode,[OrderId],o.ChurchId,o.Sn As OrderSn,o.CountryId"
                + " FROM [dbo].[RentRecord] AS d"
                + " Left join OrderInfo as o on o.Id = d.OrderId"
                + " Where d.IsDelete = 0 And d.DressId = '" + dressId + "' And Category = '"+category+"'"
                + condStr
                + sortStr;
            RentData = GetDataFromDb(sql);
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
                if (Session["FittingId"] == null && Session["FittingCategory"] == null) return;
                GetRentData(ddlStatus2.SelectedValue, Session["FittingId"].ToString(), QueryCondStr()
                    , "Order by d." + e.SortExpression + " " + SysProperty.Util.GetSortDirection(e.SortExpression));
            }
            if (RentData != null)
            {
                dataGrid.DataSource = RentData;
                dataGrid.DataBind();
            }
        }

        protected void linkConsult_Click(object sender, EventArgs e)
        {
            Session["OrderId"] = ((LinkButton)sender).CommandArgument;
            Response.Redirect("~/CaseMgt/CaseMCreate.aspx");
        }
        #endregion
    }
}