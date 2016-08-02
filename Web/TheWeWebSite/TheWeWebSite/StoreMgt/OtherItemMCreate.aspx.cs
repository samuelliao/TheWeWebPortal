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
    public partial class OtherItemMCreate : System.Web.UI.Page
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
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage()
        {
            Session.Remove("OthId");
            Response.Redirect("OtherItemMaintain.aspx", true);
        }
        private void InitialControl()
        {
            CategoryList();
            StoreList();
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

        #region DropDownList Control
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
        private void StoreList()
        {
            ddlStore.Items.Clear();
            DataSet ds = GetDataFromDb(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Store), " Where IsDelete=0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                    , dr["Id"].ToString()));
            }
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
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.ServiceItem), tbOthSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            string typeId = CreateNewType(ddlType.SelectedValue);
            bool result = WriteBackInfo(MsSqlTable.ServiceItem, true, OthItemInfoDbObject(typeId), string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["OthId"] == null) return;
            string typeId = CreateNewType(ddlType.SelectedValue);
            bool result = WriteBackInfo(MsSqlTable.ServiceItem, false, OthItemInfoDbObject(typeId), Session["OthId"].ToString());
            if (result)
            {
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
                    List<DbSearchObject> lst = CategoryDbObject(ddlOthCategory.SelectedValue);
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
            tbOthSn.Text = string.Empty;
            tbOthName.Text = string.Empty;
            tbOthPrice.Text = string.Empty;
            tbOthCost.Text = string.Empty;
            ddlOthCategory.SelectedIndex = 0;
            ddlStore.SelectedIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
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
            ddlType.SelectedValue = dr["Type"].ToString();
            ddlOthCategory.SelectedValue = dr["CategoryId"].ToString();
            ddlStore.SelectedValue = dr["StoreId"].ToString();
        }

        private List<DbSearchObject> OthItemInfoDbObject(string typeId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOthSn.Text
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
                "CategroyId"
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
        private List<DbSearchObject> CategoryDbObject(string cid)
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
                "Sn"
                , AtrrTypeItem.Integer
                , AttrSymbolItem.Equal
                , (ddlType.Items.Count - 1).ToString()
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }

        #region Db Control
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
    }
}