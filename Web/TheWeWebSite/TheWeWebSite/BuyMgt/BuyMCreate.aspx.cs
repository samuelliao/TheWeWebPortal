using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.BuyMgt
{
    public partial class BuyMCreate : System.Web.UI.Page
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
            ResetControlStatus();
            InitialPageControls();
            //TextHint();
            if (Session["BuyId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.PurchaseMgtString
                + " > " + Resources.Resource.ModifyString;                
                SetBuyRequestInfo(Session["BuyId"].ToString());                
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.PurchaseMgtString
                + " > " + Resources.Resource.CreateString;
                tbReqeuster.Text = ((DataRow)Session["AccountInfo"])["Id"].ToString();
            }
            InitialControlWithPermission();
            EnableControlWithPermission(tbReqeuster.Text);            
        }

        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnSave.Visible = item.CanCreate;
            btnSubmit.Visible = item.CanCreate;
            btnUpload.Visible = item.CanCreate;
            btnAbandon.Visible = item.CanCreate;
        }

        private void EnableControlWithPermission(string requester)
        {
            bool isRequester = ((DataRow)Session["AccountInfo"])["Id"].ToString() == requester;
            bool isHQ = bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString());
            panelRequest.Enabled = isRequester;
            panelApproval.Enabled = isHQ;
            RecognizeStatus();
        }

        private void ResetControlStatus()
        {
            panelApproval.Enabled = true;
            panelApproval.Enabled = true;
            panelApproval.Visible = true;
            panelRequest.Visible = true;
            btnAbandon.Visible = true;
            btnSave.Visible = true;
            btnSubmit.Visible = true;
            btnUpload.Visible = true;
        }

        private void RecognizeStatus()
        {
            int requestIndex = ddlRequestStatus.SelectedIndex;
            tbRequestStatus.Text = ddlRequestStatus.SelectedItem.Text;
            switch (requestIndex)
            {
                case 0:
                    panelApproval.Visible = false;
                    btnAbandon.Visible = false;
                    btnSubmit.Visible = false;                    
                    break;
                case 1:
                default:
                    // User request 
                    panelApproval.Visible = false;                    
                    break;
                case 2:
                    tbRequestStatus.Text = ddlStatus.SelectedItem.Text;
                    switch (ddlStatus.SelectedIndex)
                    {
                        case 0:
                        default:
                            panelRequest.Enabled = false;
                            btnSave.Visible = false;
                            btnAbandon.Visible = false;
                            btnUpload.Visible = false;
                            break;
                        case 1:
                        case 2:
                            panelApproval.Enabled = false;
                            panelRequest.Enabled = false;
                            btnSave.Visible = false;
                            btnAbandon.Visible = false;
                            btnUpload.Visible = false;
                            btnSubmit.Visible = false;                            
                            break;
                    }
                    break;
                case 3:
                    panelApproval.Visible = false;
                    panelRequest.Enabled = false;
                    btnSubmit.Visible = false;
                    btnSave.Visible = false;
                    btnAbandon.Visible = false;
                    btnUpload.Visible = false;
                    break;
            }
        }



        private void InitialPageControls()
        {
            CategoryList();
            TypeList(ddlCategory.SelectedValue);
            ApprovalStatusList();
            RequestStatusList();
            CurrencyList();
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
                Session.Remove("BuyId");
                Response.Redirect("BuyMgt.aspx", true);
            }
        }

        #region Button Control
        protected void btnSave_Click(object sender, EventArgs e)
        {
            bool isCreate = Session["BuyId"] == null;
            string category = GetCategoryOrTypeId(false, string.Empty);
            if (string.IsNullOrEmpty(category))
            {
                ShowErrorMsg(isCreate ? Resources.Resource.CreateFailedString : Resources.Resource.ModifyFailedString);
                return;
            }
            string type = GetCategoryOrTypeId(true, category);
            if (string.IsNullOrEmpty(type))
            {
                ShowErrorMsg(isCreate ? Resources.Resource.CreateFailedString : Resources.Resource.ModifyFailedString);
                return;
            }
            ddlRequestStatus.SelectedIndex = 1;
            string buyId = GetBuyRequestId(IsRequest(), isCreate, string.Empty, category, type);
            if (string.IsNullOrEmpty(buyId))
            {
                ShowErrorMsg(isCreate ? Resources.Resource.CreateFailedString : Resources.Resource.ModifyFailedString);
                return;
            }
            else
            {
                Session["BuyId"] = buyId;
                TransferToOtherPage(true);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
        }

        protected void btnAbandon_Click(object sender, EventArgs e)
        {
            ddlRequestStatus.SelectedIndex = 3; // Change to Abandon            
            string buyId = Session["BuyId"].ToString();
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            List<DbSearchObject> lst = BuyRequest(true, false, ddlCategory.SelectedValue, ddlType.SelectedValue.Split(';')[0], dateTime);
            bool result = WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyRequest), lst, false, buyId);
            if (string.IsNullOrEmpty(buyId))
            {
                ShowErrorMsg(Resources.Resource.ModifyFailedString);
                return;
            }
            else
            {
                Session["BuyId"] = buyId;
                TransferToOtherPage(false);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string buyId = Session["BuyId"].ToString();
            bool isRequest = ddlRequestStatus.SelectedIndex == 1 && ddlStatus.SelectedIndex == 0;
            if (isRequest)
            {
                ddlRequestStatus.SelectedIndex = 2; // Change to Review
                ddlStatus.SelectedIndex = 1; // Change to Review
            }
            string dateTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            List<DbSearchObject> lst = BuyRequest(isRequest, false, ddlCategory.SelectedValue, ddlType.SelectedValue.Split(';')[0], dateTime);
            bool result = WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyRequest), lst, false, buyId);
            if (string.IsNullOrEmpty(buyId))
            {
                ShowErrorMsg(Resources.Resource.ModifyFailedString);
                return;
            }
            else
            {
                Session["BuyId"] = buyId;
                TransferToOtherPage(false);
            }
        }

        public bool IsRequest()
        {
            bool result = true;
            return result;
        }

        private string GetCategoryOrTypeId(bool isType, string categoryId)
        {
            string value = isType ? ddlType.SelectedValue.Split(';')[0] : ddlCategory.SelectedValue;
            string text = isType ? tbType.Text : tbCategory.Text;
            if (value == "CreateItem")
            {
                string nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                List<DbSearchObject> lst = CategoryDbObject(true, isType, categoryId, text, nowTime);
                bool result = WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory), lst, true, string.Empty);
                if (!result) return string.Empty;
                return GetCreatedId(MsSqlTable.BuyStuffCategory, lst);
            }
            else
            {
                return value;
            }
        }
        private string GetBuyRequestId(bool isRequest, bool isCreate, string buyId, string category, string type)
        {
            string nowTime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            List<DbSearchObject> lst = BuyRequest(isRequest, isCreate, category, type, nowTime);
            bool result = WriteBackData(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyRequest), lst, isCreate, buyId);
            if (!result) return string.Empty;
            return GetCreatedId(MsSqlTable.BuyRequest, lst);
        }
        #endregion

        private void SetBuyRequestInfo(string buyId)
        {
            if (string.IsNullOrEmpty(buyId)) TransferToOtherPage(false);
            DataSet ds = GetBuyRequestInfo(buyId);
            if (SysProperty.Util.IsDataSetEmpty(ds)) TransferToOtherPage(false);
            DataRow dr = ds.Tables[0].Rows[0];

            #region User Request Info
            tbReqeuster.Text = dr["EmployeeId"].ToString();
            tbName.Text = dr["Name"].ToString();
            tbRequestDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["CreatedateTime"].ToString());
            tbSn.Text = dr["Sn"].ToString();
            tbRemark.Text = dr["Remark"].ToString();
            tbNumber.Text = dr["Number"].ToString();
            tbPrice.Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
            ddlCurrency.SelectedValue = dr["CurrencyId"].ToString();
            ddlCategory.SelectedValue = dr["CategoryId"].ToString();
            ddlCategory_SelectedIndexChanged(ddlCategory, new EventArgs());
            ddlType.SelectedValue = dr["TypeId"].ToString() + ";" + dr["CategoryId"].ToString();
            ddlRequestStatus.SelectedValue = dr["RequestStatusId"].ToString();
            tbRequestStatus.Text = ddlRequestStatus.SelectedItem.Text;
            #endregion

            #region Admin Approval Info
            ddlStatus.SelectedValue = dr["StatusId"].ToString();
            cbAutoPass.Checked = bool.Parse(dr["AutoPass"].ToString());
            tbApprovalRemark.Text = dr["AuditRemark"].ToString();
            tbApprovalDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["AuditDay"].ToString());
            #endregion

            #region Photo Control
            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"BuyRequest\" + tbSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(0, ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;
            #endregion
        }
        private DataSet GetBuyRequestInfo(string id)
        {
            return GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyRequest), " Where Id = '" + id + "'");
        }

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
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
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
            for (int i = 1; i <= 2; i++)
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

        #region DropDownList Control
        private void CurrencyList()
        {
            ddlCurrency.Items.Clear();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Currency), lst, string.Empty);
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCurrency.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
            }
        }
        private void CategoryList()
        {
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("Lv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCategory.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            ddlCategory.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }

        private void TypeList(string category)
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("Lv", AtrrTypeItem.Integer, AttrSymbolItem.Equal, "1"));
            if (!string.IsNullOrEmpty(category))
                lst.Add(new DbSearchObject("ParentId", AtrrTypeItem.String, AttrSymbolItem.Equal, category));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStuffCategory), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString() + ";" + dr["ParentId"].ToString()));
                }
            }
            ddlType.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCategory.Visible = ddlCategory.SelectedValue == "CreateItem";
            if (ddlCategory.SelectedValue == "CreateItem")
            {
                tbCategory.Text = string.Empty;
            }
            else
            {
                tbCategory.Text = ddlCategory.SelectedItem.Text;
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbType.Visible = ddlType.SelectedValue == "CreateItem";
            if (ddlType.SelectedValue == "CreateItem")
            {
                tbType.Text = string.Empty;
            }
            else
            {
                tbType.Text = ddlType.SelectedItem.Text;
                ddlCategory.SelectedValue = ddlType.SelectedValue.Split(';')[1];
            }
        }

        private void ApprovalStatusList()
        {
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("IsHQ", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "1"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStatus), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStatus.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
        }
        private void RequestStatusList()
        {
            ddlRequestStatus.Items.Clear();
            ddlRequestStatus.Items.Add(new ListItem(Resources.Resource.CreateString, string.Empty));
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject("IsDelete", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            lst.Add(new DbSearchObject("IsHQ", AtrrTypeItem.Bit, AttrSymbolItem.Equal, "0"));
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.BuyStatus), lst, " Order by Sn");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlRequestStatus.Items.Add(new ListItem
                        (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
        }
        #endregion

        #region Db Control
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
        private DataSet GetDataFromDb(string sql)
        {
            return (DataSet)InvokeDbControlFunction(sql, true);
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
            return GetCreatedId(SysProperty.Util.MsSqlTableConverter(table), lst);
        }
        private string GetCreatedId(string table, List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Id"
                    , table
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
        #endregion

        #region Db Instance
        private List<DbSearchObject> BuyRequest(bool isRequest, bool isCreate, string category, string type, string dateTime)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            #region Buy Request
            if (isRequest)
            {
                lst.Add(new DbSearchObject(
                    "Name"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbName.Text
                    ));
                lst.Add(new DbSearchObject(
                    "Remark"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbRemark.Text
                    ));
                lst.Add(new DbSearchObject(
                    "StoreId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ((DataRow)Session["LocateStore"])["Id"].ToString()
                    ));
                lst.Add(new DbSearchObject(
                    "TypeId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , type
                    ));
                lst.Add(new DbSearchObject(
                    "CategoryId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , category
                    ));
                lst.Add(new DbSearchObject(
                    "EmployeeId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                    ));
                lst.Add(new DbSearchObject(
                    "CurrencyId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlCurrency.SelectedValue
                    ));
                lst.Add(new DbSearchObject(
                    "Number"
                    , AtrrTypeItem.Integer
                    , AttrSymbolItem.Equal
                    , tbNumber.Text
                    ));
                lst.Add(new DbSearchObject(
                    "Price"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbPrice.Text
                    ));
                lst.Add(new DbSearchObject(
                    "RequestStatusId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlRequestStatus.SelectedValue
                    ));
            }
            #endregion
            #region Buy Approval
            else
            {
                lst.Add(new DbSearchObject(
                    "Auditor"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                    ));
                lst.Add(new DbSearchObject(
                    "AuditDay"
                    , AtrrTypeItem.DateTime
                    , AttrSymbolItem.Equal
                    , dateTime
                    ));
                lst.Add(new DbSearchObject(
                    "AutoPass"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , cbAutoPass.Checked ? "1" : "0"
                    ));
                lst.Add(new DbSearchObject(
                    "AuditRemark"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , tbApprovalRemark.Text
                    ));
            }
            #endregion
            if (!string.IsNullOrEmpty(ddlStatus.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                        "StatusId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlStatus.SelectedValue
                        ));
            }
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
                    , dateTime
                    ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "CreatedateTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , dateTime
                ));
                lst.Add(new DbSearchObject(
                "CreatedateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            }
            return lst;
        }
        private List<DbSearchObject> CategoryDbObject(bool isCreate, bool isType, string category, string name, string dateTime)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , name
                ));
            if (isType)
            {
                lst.Add(new DbSearchObject(
                    "ParentId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , category
                    ));
            }
            lst.Add(new DbSearchObject(
                    "Lv"
                    , AtrrTypeItem.Integer
                    , AttrSymbolItem.Equal
                    , isType ? "1" : "0"
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
                , dateTime
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
                , dateTime
                ));
            }
            return lst;
        }
        #endregion

        #region Auto Pass
        private bool CanAutoPass(string category, string type, int number, decimal price)
        {
            bool result = false;
            DataSet ds = GetAutoPassInfo(category, type);
            decimal comPrice = 0;
            int comNum = 0;
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    comPrice = SysProperty.Util.ParseMoney(dr["PriceLimit"].ToString());
                    comNum = int.Parse(dr["NumberLimit"].ToString());
                    if (comPrice == 0) { result = true; }
                    else
                    {
                        result = price <= comPrice;
                    }
                    if (comNum == 0) { result = true; }
                    else
                    {
                        result = number <= comNum;
                    }
                    if (!result) break;
                }
            }
            return result;
        }
        private DataSet GetAutoPassInfo(string category, string type)
        {

            string sql = "Select * From BuyAutoPass From CategoryId = '" + category + "' And TypeId is null";
            sql += " Union Select* From BuyAutoPass From CategoryId = '" + category + "' And TypeId = '" + type + "'";
            sql = "Select * From (" + sql + ")TBL";
            return GetDataFromDb(sql);
        }
        #endregion
    }
}