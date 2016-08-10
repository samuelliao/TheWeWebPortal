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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialControls();
                    InitialControlWithPermission();
                    if (Session["FittingId"] != null && Session["FittingCategory"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.AccessoryMaintainString
                        + " > " + Resources.Resource.ModifyString;                        
                        SetAllData(Session["FittingCategory"].ToString(), Session["FittingId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.AccessoryMaintainString
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
            Session.Remove("FittingId");
            Session.Remove("FittingCategory");
            Server.Transfer("FittingMaintain.aspx", true);
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
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "select * from DressCategory Where Type='Accessory' Order by Sn";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCategory.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Description"].ToString()
                    ));
            }
        }
        private void FittingTypeList()
        {
            ddlType.Items.Clear();
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
            tbType.Visible = ddlType.SelectedValue == "CreateItem";
            tbType.Text = string.Empty;
        }
        private void StatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string sql = "Select * From DressStatusCode Where IsDelete = 0";
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStatus.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            if (string.IsNullOrEmpty(tbSn.Text) || string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            if (SysProperty.GenDbCon.IsSnDuplicate(ddlCategory.SelectedValue, tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackData(ddlCategory.SelectedValue, AccessoryDbObject(typeId), true, string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSn.Text)) return;
            if (Session["FittingId"] == null || Session["FittingCategory"] == null) return;
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackData(ddlCategory.SelectedValue, AccessoryDbObject(typeId), false, Session["FittingId"].ToString());
            if (result)
            {
                UpdateRentRecords(typeId, Session["FittingId"].ToString());
                TransferToOtherPage();
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
                    List<DbSearchObject> lst = DressCategoryDbObject();
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
                    TransferToOtherPage();
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
            TransferToOtherPage();
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
            tbColor1.Text = dr["Color"].ToString();
            tbMaterial1.Text = dr["Material"].ToString();
            ddlType.SelectedValue = dr["Category"].ToString();
            ddlSupplier.SelectedValue = dr["SupplierId"].ToString();
            ddlStatus.SelectedValue = dr["StatusCode"].ToString();
            ddlStore.SelectedValue = Session["LocateStore"] == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString();
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
            BindRentRecordsTable(id);

            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath +  tableName + @"\" + tbSn.Text;
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
                    tbType.Enabled = false;
                    ddlCategory.Enabled = false;
                    ddlEarringType.Enabled = false;
                    ddlGender.Enabled = false;
                    ddlLength.Enabled = false;
                    ddlRelatedCategory.Enabled = false;
                    ddlStore.Enabled = false;
                    ddlSupplier.Enabled = false;
                    ddlType.Enabled = false;
                    btnImgBackUpload.Visible = false;
                    btnImgFrontUpload.Visible = false;
                    btnImgOther1.Visible = false;
                    btnImgOther2.Visible = false;
                    btnImgSideUpload.Visible = false;
                    ImgBackUpload.Visible = false;
                    ImgFrontUpload.Visible = false;
                    ImgSideUpload.Visible = false;
                    ImgOther1Upload.Visible = false;
                    ImgOther2Upload.Visible = false;
                }
            }
        }

        #region Rent Records
        private DataSet GetRentRecords(string dressId)
        {
            string sql = "Select * From RentRecord Where DressId='" + dressId + "' order by RentStartTime DESC";
            return GetDataFromDb(sql);
        }
        private void BindRentRecordsTable(string dressId)
        {
            DataSet ds = GetRentRecords(dressId);
            dataGrid.DataSource = ds;
            dataGrid.DataBind();
        }
        private void UpdateRentRecords(string typeId, string dressId)
        {
            string status = CheckStatusForRent(ddlStatus.SelectedValue);
            if (status == "Rent")
            {
                WriteBackData(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.RentRecord)
                    , RentRecordDbObject(typeId, dressId, true)
                    , true
                    , string.Empty);
            }
            else if (status == "Return")
            {
                WriteBackData(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.RentRecord)
                    , RentRecordDbObject(typeId, dressId, false)
                    , false
                    , dataGrid.DataKeys[0].ToString());
            }
        }
        private string CheckStatusForRent(string ddlValue)
        {
            if (ddlValue.ToUpper() == "67F14E3B-5294-44EE-97CF-948BB2FC3031")
            {
                if (dataGrid.Items.Count > 0)
                {
                    if (!string.IsNullOrEmpty(SysProperty.Util.ParseDateTime("DateTime", dataGrid.Items[0].Cells[2].Text)))
                    {
                        return "Rent";
                    }
                }
                else
                {
                    return "Rent";
                }
            }
            else
            {
                if (dataGrid.Items.Count > 0)
                {
                    if (string.IsNullOrEmpty(SysProperty.Util.ParseDateTime("DateTime", dataGrid.Items[0].Cells[2].Text)))
                    {
                        return "Return";
                    }
                }
            }
            return string.Empty;
        }
        #endregion

        #region Db Instance
        private List<DbSearchObject> AccessoryDbObject(string typeId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
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
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "Img"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlCategory.SelectedValue + @"\" + tbSn.Text
                    ));
            }
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

            if (string.IsNullOrEmpty(ddlStore.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "StoreId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlStore.SelectedValue
                    ));
            }
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }
        private List<DbSearchObject> DressCategoryDbObject()
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
            return lst;
        }
        private List<DbSearchObject> RentRecordDbObject(string typeId, string id, bool isRent)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                isRent ? "RentStartTime" : "RentEndTime"
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

        private string GetCreatedId(MsSqlTable table, List<DbSearchObject> lst)
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
                    ImgFront.ImageUrl = path + "\\"+ tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = path + "\\"+ tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = path + "\\"+ tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 4:
                    ImgOther1.ImageUrl = path + "\\"+ tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 5:
                    ImgOther2.ImageUrl = path + "\\"+ tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = path + "\\"+ tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = path + "\\"+ tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = path + "\\"+ tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther1.ImageUrl = path + "\\"+ tbSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther2.ImageUrl = path + "\\"+ tbSn.Text + "_5.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }

        protected void btnImgFrontUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\" + ddlCategory.SelectedValue + @"\" + tbSn.Text);
            ImgFrontUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\"+ tbSn.Text + "_1.jpg");
            RefreshImage(1, tbFolderPath.Text);
        }

        protected void btnImgBackUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\" + ddlCategory.SelectedValue + @"\" + tbSn.Text);
            ImgBackUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\"+ tbSn.Text + "_2.jpg");
            RefreshImage(2, tbFolderPath.Text);
        }

        protected void btnImgSideUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\" + ddlCategory.SelectedValue + @"\" + tbSn.Text);
            ImgSideUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\"+ tbSn.Text + "_3.jpg");
            RefreshImage(3, tbFolderPath.Text);
        }

        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        protected void btnImgOther2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\" + ddlCategory.SelectedValue + @"\" + tbSn.Text);
            ImgSideUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\"+ tbSn.Text + "_5.jpg");
            RefreshImage(5, tbFolderPath.Text);
        }

        protected void btnImgOther1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            if (string.IsNullOrEmpty(ddlCategory.SelectedValue)) return;
            CheckFolder(SysProperty.ImgRootFolderpath + @"\" + ddlCategory.SelectedValue + @"\" + tbSn.Text);
            ImgSideUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\"+ tbSn.Text + "_4.jpg");
            RefreshImage(4, tbFolderPath.Text);
        }
        #endregion
    }
}