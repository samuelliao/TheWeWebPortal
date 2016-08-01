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
    public partial class ModelingMCreate : System.Web.UI.Page
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
                    if (Session["ModelingId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.StoreMgtString
                        + " > " + Resources.Resource.WeddingItemMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetOthItemInfoData(Session["ModelingId"].ToString());
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
            Session.Remove("ModelingId");
            Response.Redirect("ModelingMaintain.aspx", true);
        }
        private void InitialControl()
        {
            TypeList();
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
        private void TypeList()
        {
            ddlType.Items.Clear();
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty, true));
            string sql = "select * from HairStyleCategory";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlType.Items.Add(new ListItem(
                    dr["Name"].ToString()
                    , dr["Id"].ToString(), true));
            }
        }
        #endregion

        #region Button Control
        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.HairStyleItem), tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            bool result = WriteBackInfo(true, OthItemInfoDbObject(), string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["ModelingId"] == null) return;
            bool result = WriteBackInfo(false, OthItemInfoDbObject(), Session["ModelingId"].ToString());
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbSn.Text = string.Empty;
            tbDescription.Text = string.Empty;
            ddlType.SelectedIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["ModelingId"].ToString())) return;
                string sql = "UPDATE HairStyleItem SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ModelingId"].ToString() + "'";
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
            string sql = "Select * From HairStyleItem Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbSn.Text = dr["Sn"].ToString();
            tbDescription.Text = dr["Description"].ToString();
            ddlType.SelectedValue = dr["Type"].ToString();
        }

        private List<DbSearchObject> OthItemInfoDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text
                ));

            lst.Add(new DbSearchObject(
                "Description"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDescription.Text
                ));
            lst.Add(new DbSearchObject(
                "Type"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlType.SelectedValue
                ));
            return lst;
        }

        private bool WriteBackInfo(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.HairStyleItem)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst))
                        : SysProperty.GenDbCon.UpdateDataIntoTable(
                            SysProperty.Util.MsSqlTableConverter(MsSqlTable.HairStyleItem)
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


    }
}