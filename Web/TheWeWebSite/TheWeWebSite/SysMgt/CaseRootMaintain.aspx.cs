using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.SysMgt
{
    public partial class CaseRootMaintain : System.Web.UI.Page
    {
        string OtherCondStr;
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
                    labelPageTitle.Text = Resources.Resource.SysMgtString + " > " + Resources.Resource.CasePermissionMgtString;
                    InitialControlWithPermission();
                    InitialControls();
                }
            }
        }
        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
        }
        private void InitialControls()
        {
            CountryList();
            StoreList(ddlCountry.SelectedValue);
            EmployeeList(ddlCountry.SelectedValue, ddlStore.SelectedValue);
            PermissionTypeList();
        }
        #region DropDownList
        private void CountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Select * From Country Where Id in (Select Distinct CountryId From Store Where IsDelete = 0) And IsDelete = 0");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlCountry.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void StoreList(string countryId)
        {
            ddlStore.Items.Clear();
            ddlStore.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            DataSet ds = GetDataFromDb("Select * From Store Where IsDelete = 0 "
                + (string.IsNullOrEmpty(countryId) ? string.Empty : " And CountryId = '" + countryId + "'"));

            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlStore.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString()
                    ));
            }
        }
        private void EmployeeList(string countryId, string storeId)
        {
            ddlEmployee.Items.Clear();
            ddlEmployee.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            string condStr = " Where IsDelete = 0 And IsValid = 1 "
                + (string.IsNullOrEmpty(storeId) ? string.Empty : " And StoreId = '" + storeId + "'");
            DataSet ds = GetDataFromDb("Select * from Employee " + condStr);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlEmployee.Items.Add(new ListItem(dr["Account"].ToString() + "(" + dr["Name"].ToString() + ")", dr["Id"].ToString()));
            }
        }

        private void PermissionTypeList()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.StoreString, "Store"));
            ddlType.Items.Add(new ListItem(Resources.Resource.CountryString, "Country"));
        }
        #endregion

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["Employee"] == null) return;
            bool result = false;
            string pId = string.Empty;

            if (SysProperty.Util.IsDataSetEmpty(((DataSet)Session["PermissionItem"])))
            {
                List<DbSearchObject> lst = PermissionDbObject();
                result = WriteBackPermission(lst);
                if (!result) return;
                pId = GetCreatePermissionId(lst);
            }
            else
            {
                pId = ((DataSet)Session["PermissionItem"]).Tables[0].Rows[0]["PermissionId"].ToString();
            }
            if (string.IsNullOrEmpty(pId)) return;
            result = WriteBackPermissionItem(PermissionItemDbObject(pId), pId, ddlType.SelectedValue);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        #region DataGrid
        protected void dgServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                // Label txt = Name(Sn)
                ((Label)e.Row.FindControl("dgLabelName")).Text = SysProperty.Util.OutputRelatedLangName(
                        Session["CultureCode"].ToString()
                        , dataItem1["Name"].ToString()
                        , dataItem1["CnName"].ToString()
                        , dataItem1["EngName"].ToString()
                        , dataItem1["JpName"].ToString());
                if (ddlType.SelectedValue == "Store")
                {
                    ((Label)e.Row.FindControl("dgLabelSn")).Text += dataItem1["Sn"].ToString();
                }
                else
                {
                    ((Label)e.Row.FindControl("dgLabelSn")).Text += dataItem1["Code"].ToString();
                }
                if (SysProperty.Util.IsDataSetEmpty(((DataSet)Session["PermissionItem"])))
                {
                    if (ddlType.SelectedValue == "Store" &&
                        dataItem1["Id"].ToString() == ((DataSet)Session["Employee"]).Tables[0].Rows[0]["StoreId"].ToString())
                    {
                        ((CheckBox)e.Row.FindControl("dgCbEntry")).Checked = true;
                        ((CheckBox)e.Row.FindControl("dgCbCreate")).Checked = true;
                        ((CheckBox)e.Row.FindControl("dgCbDelete")).Checked = true;
                        ((CheckBox)e.Row.FindControl("dgCbModify")).Checked = true;
                        ((CheckBox)e.Row.FindControl("dgCbExport")).Checked = true;
                    }
                }
                else
                {
                    foreach (DataRow dr in ((DataSet)Session["PermissionItem"]).Tables[0].Select("ObjectId = '" + dataItem1["Id"].ToString() + "'"))
                    {
                        ((CheckBox)e.Row.FindControl("dgCbEntry")).Checked = bool.Parse(dr["CanEntry"].ToString());
                        ((CheckBox)e.Row.FindControl("dgCbCreate")).Checked = bool.Parse(dr["CanCreate"].ToString());
                        ((CheckBox)e.Row.FindControl("dgCbDelete")).Checked = bool.Parse(dr["CanDelete"].ToString());
                        ((CheckBox)e.Row.FindControl("dgCbModify")).Checked = bool.Parse(dr["CanModify"].ToString());
                        ((CheckBox)e.Row.FindControl("dgCbExport")).Checked = bool.Parse(dr["CanExport"].ToString());
                    }
                }
            }
        }
        #endregion

        private void BindData()
        {
            if (string.IsNullOrEmpty(ddlType.SelectedValue)) return;
            string sql = "Select * From " + ddlType.SelectedValue + " Where IsDelete = 0";
            dgServiceItem.DataSource = GetDataFromDb(sql);
            dgServiceItem.DataBind();
        }

        private DataSet GetPermissionItem(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            string sql = "Select * From PermissionItem Where IsDelete=0  And PermissionId = '" + id + "'";
            return GetDataFromDb(sql);
        }

        private string GetPermissionId(string type)
        {
            if (Session["Employee"] != null)
            {
                string eid = ((DataSet)Session["Employee"]).Tables[0].Rows[0]["Id"].ToString();
                string sql = "Select * From Permission Where IsDelete=0 And ObjectId = '" + eid + "' And [Type] ='" + type + "'";
                DataSet ds = GetDataFromDb(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return string.Empty;
                return ds.Tables[0].Rows[0]["Id"].ToString();
            }
            return string.Empty;
        }

        private DataSet GetEmployee()
        {
            string sql = "Select * from Employee Where IsDelete = 0 " + OtherCondStr;
            DataSet ds = GetDataFromDb(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return null;
            return ds;
        }

        private DataSet GetDataFromDb(string sql)
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
        private string GetCreatePermissionId(List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.Permission)
                    , SysProperty.Util.SqlQueryConditionConverter(lst));
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
        private bool WriteBackPermissionItem(List<List<DbSearchObject>> lst, string permissionId, string type)
        {
            try
            {
                bool result = true;
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From PermissionItem"
                    + " Where PermissionId='" + permissionId + "' And Type = '" + type + "'");
                foreach (List<DbSearchObject> item in lst)
                {
                    try
                    {
                        result = result & SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.PermissionItem)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                        , SysProperty.Util.SqlQueryInsertValueConverter(item));
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex.Message);
                        ShowErrorMsg(ex.Message);
                        continue;
                    }
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

        #region Db Instance
        private List<DbSearchObject> PermissionDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ObjectId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataSet)Session["Employee"]).Tables[0].Rows[0]["Id"].ToString()
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
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlType.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataSet)Session["Employee"]).Tables[0].Rows[0]["Account"].ToString()
                ));
            return lst;
        }
        private List<List<DbSearchObject>> PermissionItemDbObject(string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (dgServiceItem.Rows.Count > 0)
            {
                foreach (GridViewRow dr in dgServiceItem.Rows)
                {
                    if (!NeedSyncToDB(dr
                        , ((DataSet)Session["PermissionItem"])
                        , dgServiceItem.DataKeys[dr.RowIndex].Value.ToString())) continue;

                    lst = new List<DbSearchObject>();
                    lst.Add(new DbSearchObject(
                        "ObjectId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , dgServiceItem.DataKeys[dr.RowIndex].Value.ToString()
                        ));
                    lst.Add(new DbSearchObject(
                        "Type"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlType.SelectedValue
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
                    lst.Add(new DbSearchObject(
                        "PermissionId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , id
                        ));
                    lst.Add(new DbSearchObject(
                        "ObjectSn"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((Label)dr.FindControl("dgLabelSn")).Text.Trim()
                        ));
                    lst.Add(new DbSearchObject(
                    "CanEntry"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)dr.FindControl("dgCbEntry")).Checked ? "1" : "0"
                    ));
                    lst.Add(new DbSearchObject(
                    "CanCreate"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)dr.FindControl("dgCbCreate")).Checked ? "1" : "0"
                    ));
                    lst.Add(new DbSearchObject(
                    "CanModify"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)dr.FindControl("dgCbModify")).Checked ? "1" : "0"
                    ));
                    lst.Add(new DbSearchObject(
                    "CanDelete"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)dr.FindControl("dgCbDelete")).Checked ? "1" : "0"
                    ));
                    lst.Add(new DbSearchObject(
                    "CanExport"
                    , AtrrTypeItem.Bit
                    , AttrSymbolItem.Equal
                    , ((CheckBox)dr.FindControl("dgCbExport")).Checked ? "1" : "0"
                    ));
                    result.Add(lst);
                }
            }
            return result;
        }

        private bool NeedSyncToDB(GridViewRow dr, DataSet ds, string objectId)
        {
            bool result = ((CheckBox)dr.FindControl("dgCbEntry")).Checked
                | ((CheckBox)dr.FindControl("dgCbDelete")).Checked
                | ((CheckBox)dr.FindControl("dgCbModify")).Checked
                | ((CheckBox)dr.FindControl("dgCbCreate")).Checked
                | ((CheckBox)dr.FindControl("dgCbExport")).Checked;
            result = result | ds.Tables[0].Select("ObjectId = '" + objectId + "'").Length > 0;
            return result;
        }
        #endregion

        protected void main_Unload(object sender, EventArgs e)
        {
            if (Session["Employee"] != null) Session.Remove("Employee");
            if (Session["PermissionItem"] != null) Session.Remove("PermissionItem");
        }

        #region DropDownLisy Control
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            StoreList(ddlCountry.SelectedValue);
            EmployeeList(ddlCountry.SelectedValue, ddlStore.SelectedValue);
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmployeeList(ddlCountry.SelectedValue, ddlStore.SelectedValue);
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlEmployee.SelectedValue))
            {
                OtherCondStr = " And Id = '" + ddlEmployee.SelectedValue + "'";
                Session["Employee"] = GetEmployee();
                if (!SysProperty.Util.IsDataSetEmpty(((DataSet)Session["Employee"])))
                {
                    ddlCountry.SelectedValue = ((DataSet)Session["Employee"]).Tables[0].Rows[0]["CountryId"].ToString();
                    ddlStore.SelectedValue = ((DataSet)Session["Employee"]).Tables[0].Rows[0]["StoreId"].ToString();
                    string id = GetPermissionId(ddlType.SelectedValue);
                    if (string.IsNullOrEmpty(id)) Session["PermissionItem"] = null;
                    Session["PermissionItem"] = GetPermissionItem(id);
                    tbStore.Text = ddlStore.SelectedItem.Text;
                    tbName.Text = ddlEmployee.SelectedItem.Text;
                    BindData();
                }
            }
        }
        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Session["Employee"] != null)
            {
                string id = GetPermissionId(ddlType.SelectedValue);
                if (string.IsNullOrEmpty(id)) Session["PermissionItem"] = null;
                Session["PermissionItem"] = GetPermissionItem(id);
                BindData();
            }
        }
        #endregion
    }
}