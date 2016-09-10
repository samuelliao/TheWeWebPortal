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
    public partial class OtherItemMCreate : System.Web.UI.Page
    {
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
            if (Session["OthId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.WeddingItemMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetOthItemInfoData(Session["OthId"].ToString());
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.WeddingItemMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void TextHint()
        {
            tbOthSn.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SnString);
            tbOthCost.Attributes.Add("placeHolder", "0.00");
            tbOthDescription.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.DescriptionString);
            tbOthName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.NameString);
            tbOthPrice.Attributes.Add("placeHolder", "0.00");
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
                Session.Remove("OthId");
                Response.Redirect("OtherItemMaintain.aspx", true);
            }
        }
        private void InitialControl()
        {
            HolderCategoryList();
            CategoryList();
            if (!string.IsNullOrEmpty(ddlOthCategory.SelectedValue))
            {
                TypeList(ddlOthCategory.SelectedValue);
            }
            CountryList(ddlCategory.SelectedValue);
            AreaList(ddlCategory.SelectedValue, ddlCountry.SelectedValue);
            StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
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
                btnDelete.Visible = false;
                ddlCategory.Enabled = false;
                ddlCountry.Enabled = false;
                ddlArea.Enabled = false;
                ddlStore.Enabled = false;
            }
        }

        #region DropDownList Control
        private void HolderCategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.StoreString, "Store"));
            ddlCategory.Items.Add(new ListItem(Resources.Resource.LocateString, "Church"));
            ddlCategory.SelectedIndex = 0;
            ddlCategory_SelectedIndexChanged(ddlCategory, new EventArgs());
        }
        private void CategoryList()
        {
            ddlOthCategory.Items.Clear();
            ddlOthCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("TypeLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "1"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItemCategory), lst, " Order by Sn");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlOthCategory.Items.Add(new ListItem
                    (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void TypeList(string category)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("TypeLv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "2"));
            if (!string.IsNullOrEmpty(category))
                lst.Add(new DbSearchObject("Type", AtrrTypeItem.String, AttrSymbolItem.Equal, category));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItemCategory), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            ddlType.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }
        private void CountryList(string holder)
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataSetFromTable("Select * From Country Where IsDelete = 0 And Id in (Select Distinct CountryId From " + holder + " Where IsDelete = 0)");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCountry.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void AreaList(string holder, string cid)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string countryCond = " And CountryId ";
            if (!string.IsNullOrEmpty(cid))
            {
                countryCond += " = '" + cid + "'";
            }
            else
            {
                countryCond += "in (Select Distinct CountryId From " + holder + " Where IsDelete = 0)";
            }
            DataSet ds = GetDataSetFromTable("Select * From Area Where IsDelete = 0" + countryCond);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlArea.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()));
            }
        }
        private void StoreList(bool isStore, string cid, string aid)
        {
            ddlStore.Items.Clear();
            DataSet ds;
            string condStr = string.Empty;
            if (!string.IsNullOrEmpty(cid))
            {
                condStr += " And CountryId = '" + cid + "'";
            }
            if (!string.IsNullOrEmpty(aid))
            {
                condStr += " And AreaId = '" + aid + "'";
            }
            string sql = " Where IsDelete=0" + condStr;
            if (isStore)
            {
                ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), sql);
            }
            else
            {
                ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Church), sql);
            }
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
            if (isStore)
            {
                ddlStore.SelectedValue = ((DataRow)Session["LocateStore"])["Id"].ToString();
                ddlStore_SelectedIndexChanged(ddlStore, new EventArgs());
            }
            //ddlStore.Enabled = false;
        }

        #region DropDownList Event
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbType.Visible = ddlType.SelectedValue == "CreateItem";
            tbType.Text = string.Empty;
        }

        protected void ddlOthCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeList(ddlOthCategory.SelectedValue);
            btnCreate.Enabled = ddlOthCategory.SelectedIndex != 0;
            btnModify.Enabled = ddlOthCategory.SelectedIndex != 0;
        }
        #endregion
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            List<DbSearchObject> lst = OthItemInfoDbObject(true, typeId);
            bool result = WriteBackInfo(MsSqlTable.ServiceItem, true, lst, string.Empty);
            string id = GetCreatedId(MsSqlTable.ServiceItem, lst);
            if (!string.IsNullOrEmpty(id))
            {
                Session["OthId"] = id;
                TransferToOtherPage(true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["OthId"] == null) return;
            string typeId = CreateNewType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackInfo(MsSqlTable.ServiceItem, false, OthItemInfoDbObject(false, typeId), Session["OthId"].ToString());
            if (result)
            {
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
                    List<DbSearchObject> lst = CategoryDbObject(true, ddlOthCategory.SelectedValue);
                    result = WriteBackInfo(
                        MsSqlTable.ServiceItemCategory
                        , true, lst, string.Empty);
                    if (!result) return string.Empty;
                    typeId = GetCreatedId(MsSqlTable.ServiceItemCategory, lst);
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
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                tbOthSn.Text = string.Empty;
                tbOthName.Text = string.Empty;
                tbOthCost.Text = string.Empty;
                ddlOthCategory.SelectedIndex = 0;
                ddlStore.SelectedIndex = 0;
                ddlType.SelectedIndex = 0;
                tbType.Text = string.Empty;
                tbOthDescription.Text = string.Empty;
            }
            tbOthPrice.Text = string.Empty;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["OthId"].ToString())) return;
                string sql = "UPDATE ServiceItem SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["OthId"].ToString() + "'";
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

        private void SetOthItemInfoData(string id)
        {
            string sql = "Select * From ServiceItem Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbOthSn.Text = dr["Sn"].ToString();
            tbOthCost.Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
            tbOthPrice.Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
            tbOthDescription.Text = dr["Description"].ToString();
            tbOthName.Text = dr["Name"].ToString();
            ddlCategory.SelectedValue = (bool.Parse(dr["IsStore"].ToString()) ? "Store" : "Church");
            ddlCategory_SelectedIndexChanged(ddlCategory, new EventArgs());            
            ddlOthCategory.SelectedValue = dr["CategoryId"].ToString();
            ddlOthCategory_SelectedIndexChanged(ddlOthCategory, new EventArgs());
            ddlType.SelectedValue = dr["Type"].ToString();
            ddlType_SelectedIndexChanged(ddlType, new EventArgs());
            ddlStore.SelectedValue = dr["StoreId"].ToString();
            ddlStore_SelectedIndexChanged(ddlStore, new EventArgs());

            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"\Item\" + tbOthSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            tbFolderPath.Text = ImgFolderPath;
            RefreshImage(0, ImgFolderPath);

            if (bool.Parse(dr["IsGeneral"].ToString()))
            {
                btnModify.Visible = false;
                btnDelete.Visible = false;
                btnClear.Visible = false;
            }

            if (!bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                tbFolderPath.Enabled = false;
                tbOthCost.Enabled = false;
                tbOthDescription.Enabled = false;
                tbOthName.Enabled = false;
                tbOthSn.Enabled = false;
                tbType.Enabled = false;
                ddlOthCategory.Enabled = false;
                ddlStore.Enabled = false;
                ddlType.Enabled = false;
                divPhotoUpload.Attributes["style"] = "display: none;";
            }
        }

        #region Db Instance
        private List<DbSearchObject> OthItemInfoDbObject(bool isCreate, string typeId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthSn.Text
                ));
            lst.Add(new DbSearchObject(
                "IsGeneral"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , IsGeneral() ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthName.Text
                ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Cost"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthCost.Text
                ));
            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthDescription.Text
                ));
            lst.Add(new DbSearchObject(
                "CategoryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlOthCategory.SelectedValue
                ));
            if (!string.IsNullOrEmpty(typeId))
            {
                lst.Add(new DbSearchObject(
                    "Type"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , typeId
                    ));
            }

            lst.Add(new DbSearchObject(
                (ddlCategory.SelectedValue == "Store" ? "StoreId" : "SupplierId")
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStore.SelectedValue
                ));

            lst.Add(new DbSearchObject(
                "IsStore"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , (ddlCategory.SelectedValue == "Store" ? "1" : "0")
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

        private bool IsGeneral()
        {
            if (ddlCategory.SelectedValue == "Store")
            {
                if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()) && ddlStore.SelectedValue == ((DataRow)Session["LocateStore"])["Id"].ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        private List<DbSearchObject> CategoryDbObject(bool isCreate, string cid)
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
                , tbType.Text
                ));
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , cid
                ));
            lst.Add(new DbSearchObject(
                "TypeLv"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , "2"
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
        #endregion

        #region Db Control
        private string GetCreatedId(MsSqlTable table, List<DbSearchObject> lst)
        {
            try
            {
                List<DbSearchObject> conds = new List<DbSearchObject>();
                if (table == MsSqlTable.ServiceItem)
                {
                    conds.Add(lst.Find(x => x.AttrName == "CategoryId"));
                    conds.Add(lst.Find(x => x.AttrName == "IsStore"));
                    conds.Add(lst.Find(x => x.AttrName == (ddlCategory.SelectedValue == "Store" ? "StoreId" : "SupplierId")));
                    conds.Add(lst.Find(x => x.AttrName == "Name"));
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
                    , SysProperty.Util.MsSqlTableConverter(table)
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
        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst, string sortStr)
        {
            string sqlTxt = "Select * From " + tableName
                + SysProperty.Util.SqlQueryConditionConverter(lst)
                + " " + sortStr;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private DataSet GetDataFromDb(string tableName, string whereString)
        {
            string sqlTxt = "Select * From " + tableName + whereString;
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
        }
        private Object InvokeDbControlFunction(string sql, bool isSelect)
        {
            try
            {
                if (string.IsNullOrEmpty(sql)) return null;
                if (isSelect)
                    return SysProperty.GenDbCon.GetDataFromTable(sql);
                else
                    return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        #endregion

        #region Image Related
        private void RefreshImage(int type, string path)
        {
            switch (type)
            {
                case 1:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 2:
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 3:
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 4:
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgOther1.ImageUrl = "http:" + path + "\\" + tbOthSn.Text + "_4.jpg?" + DateTime.Now.Ticks.ToString();
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
            for (int i = 1; i <= 4; i++)
            {
                FileUpload upload = divUpload.FindControl("FileUpload" + i) as FileUpload;
                if (upload == null) continue;
                if (upload.HasFile)
                {
                    upload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbOthSn.Text + "_" + i + ".jpg");
                    needRefresh = true;
                }
            }

            if (needRefresh)
            {
                RefreshImage(0, tbFolderPath.Text);
            }
        }
        #endregion

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlCategory.SelectedValue))
            {
                CountryList(ddlCategory.SelectedValue);
                AreaList(ddlCategory.SelectedValue, ddlCountry.SelectedValue);
                StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
            try
            {
                if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
                {
                    string countryId = SysProperty.GetAreaById(ddlArea.SelectedValue)["Id"].ToString();
                    if(ddlCountry.SelectedValue!= countryId)
                    {
                        ddlCountry.SelectedValue = countryId;
                    }
                }
            }catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaList(ddlCategory.SelectedValue, ddlCountry.SelectedValue);
            StoreList(ddlCategory.SelectedValue == "Store", ddlCountry.SelectedValue, ddlArea.SelectedValue);
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ddlStore.SelectedValue))
                {
                    string countryId = string.Empty;
                    string areaId = string.Empty;
                    if (ddlCategory.SelectedValue == "Church")
                    {
                        DataRow dr = SysProperty.GetChurchById(ddlStore.SelectedValue);
                        countryId = dr["CountryId"].ToString();
                        areaId = dr["AreaId"].ToString();
                    }else
                    {
                        DataSet ds = GetDataSetFromTable("Select * From Store Where Id = '" + ddlStore.SelectedValue + "'");
                        if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                        countryId = ds.Tables[0].Rows[0]["CountryId"].ToString();
                        areaId = ds.Tables[0].Rows[0]["AreaId"].ToString();
                    }

                    if (ddlCountry.SelectedValue != countryId)
                    {
                        ddlCountry.SelectedValue = countryId;
                    }
                    if (ddlArea.SelectedValue != areaId)
                    {
                        ddlArea.SelectedValue = areaId;
                    }
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
    }
}