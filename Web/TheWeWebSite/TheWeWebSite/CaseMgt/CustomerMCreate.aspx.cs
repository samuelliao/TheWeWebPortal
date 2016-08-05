using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;

namespace TheWeWebSite.CaseMgt
{
    public partial class CustomerMCreate : System.Web.UI.Page
    {
        private DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {                    
                    InitialMsgerType();
                    InitialControlWithPermission();
                    if (Session["CustomerId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.ChurchMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        GetCustomerInfo(Session["CustomerId"].ToString());                        
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.ChurchMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                    }
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }

        #region Item Initial        
        private void InitialMsgerType()
        {
            ddlMsgerType.Items.Clear();
            ddlMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            try
            {
                string sql = "Select * From Messenger Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlMsgerType.Items.Add(
                        new ListItem(
                        dr["Name"].ToString()
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
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
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Customer), tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            List<DbSearchObject> lst = CustomerDbObject();
            bool result = WriteBackCustomer(true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateCustomerId(lst);
            //if (string.IsNullOrEmpty(id)) return;
            //List<List<DbSearchObject>> lst2 = SourceInfoDbObject();
            //result = WriteBackSourceInfo(true, lst2, id);
            if (result)
            {
                TransferToOtherPage();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbAddr.Text = string.Empty;
            tbBday.Text = string.Empty;
            tbMsgId.Text = string.Empty;
            tbName.Text = string.Empty;
            tbPassportName.Text = string.Empty;
            tbPhone.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbSn.Text = string.Empty;
            tbNickName.Text = string.Empty;
            tbSnsTitle.Text = string.Empty;
            ddlMsgerType.SelectedIndex = 0;           
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["CustomerId"].ToString())) return;
            List<DbSearchObject> lst = CustomerDbObject();
            bool result = WriteBackCustomer(false, lst, Session["CustomerId"].ToString());
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["CustomerId"].ToString())) return;
                string sql = "UPDATE Customer SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["CustomerId"].ToString() + "'";
                if (((bool)InvokeDbControlFunction(sql, false)))
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

        private List<DbSearchObject> CustomerDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Name"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbName.Text
                ));
            lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["CountryId"].ToString())
                ));
            
            lst.Add(new DbSearchObject(
                "EngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPassportName.Text
                ));
            lst.Add(new DbSearchObject(
                "Nickname"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbNickName.Text
                ));
            lst.Add(new DbSearchObject(
                "Phone"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPhone.Text
                ));
            lst.Add(new DbSearchObject(
                "Email"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbEmail.Text
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text
                ));
            lst.Add(new DbSearchObject(
                "Bday"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBday.Text
                ));
            if (!string.IsNullOrEmpty(ddlMsgerType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "MessengerType"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlMsgerType.SelectedValue
                    ));
            }
            lst.Add(new DbSearchObject(
                "MessengerId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbMsgId.Text
                ));
            lst.Add(new DbSearchObject(
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , (((DataRow)Session["LocateStore"]) == null ? string.Empty : ((DataRow)Session["LocateStore"])["Id"].ToString())
                ));
            lst.Add(new DbSearchObject(
                "Gender"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , "0"
                ));
            lst.Add(new DbSearchObject(
                "MsgTitle"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSnsTitle.Text
                ));
            return lst;
        }
        

        private string GetCreateCustomerId(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Customer)
                    , SysProperty.Util.SqlQueryConditionConverter(lst)).Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }

        private bool WriteBackCustomer(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Customer)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Customer)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , " Where Id = '" + id + "'"));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }        

        private bool WriteBackSourceInfo(bool isInsert, List<List<DbSearchObject>> lst, string customerId)
        {
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result |
                        (isInsert ? SysProperty.GenDbCon.InsertDataInToTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.InfoSource)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                        , SysProperty.Util.SqlQueryInsertValueConverter(item))
                        : (SysProperty.GenDbCon.UpdateDataIntoTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.InfoSource)
                        , SysProperty.Util.SqlQueryUpdateConverter(item)
                        , " Where CustomerId = '" + customerId
                        + "' And InfoId='" + item[0].AttrValue + "'")));
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    result = false;
                }
            }
            return result;
        }


        #region DB Control
        private DataSet GetDataFromDb(string tableName, List<DbSearchObject> lst)
        {
            string sqlTxt = "Select * From " + tableName + SysProperty.Util.SqlQueryConditionConverter(lst);
            return (DataSet)InvokeDbControlFunction(sqlTxt, true);
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
                return null;
            }
        }
        #endregion

        private void TransferToOtherPage() {
            Server.Transfer("CustomerMaintain.aspx", true);
            Session.Remove("CustomerId");
        }

        private void GetCustomerInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return;
                DS = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Customer)
                    , " Where Id='" + id + "'");
                SetAllControlValue(DS);
            }
            catch(Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                DS = null;
            }
        }

        private void SetAllControlValue(DataSet ds)
        {
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                tbName.Text = dr["Name"].ToString();
                tbPassportName.Text = dr["EngName"].ToString();
                tbNickName.Text = dr["Nickname"].ToString();
                tbEmail.Text = dr["Email"].ToString();
                tbAddr.Text = dr["Addr"].ToString();
                if (!string.IsNullOrEmpty(dr["Bday"].ToString()))
                {
                    if (DateTime.Parse(dr["Bday"].ToString()) > new DateTime(1900, 12, 31))
                    {
                        tbBday.Text = DateTime.Parse(dr["Bday"].ToString()).ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        tbBday.Text = string.Empty;
                    }
                }
                tbMsgId.Text = dr["MessengerId"].ToString();
                tbPhone.Text = dr["Phone"].ToString();
                tbRemark.Text = dr["Remark"].ToString();
                tbSn.Text = dr["Sn"].ToString();
                tbSnsTitle.Text = dr["MsgTitle"].ToString();
                ddlMsgerType.SelectedValue = dr["MessengerType"].ToString();
                //ddlSourceInfo
            }
        }        
    }
}