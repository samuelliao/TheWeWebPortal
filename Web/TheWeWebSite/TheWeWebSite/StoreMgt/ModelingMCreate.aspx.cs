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
                        SetStyleInfoData(Session["ModelingId"].ToString());
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
            string sql = "select * from HairStyleCategory";
            DataSet ds = GetDataSetFromTable(sql);
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlType.Items.Add(new ListItem(
                        dr["Name"].ToString()
                        , dr["Id"].ToString(), true));
                }
            }
            ddlType.Items.Add(new ListItem(Resources.Resource.CreateItemString, "CreateItem"));
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

            string typeId = CreateNewStyleType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackInfo(MsSqlTable.HairStyleItem, true, StyleDbObject(typeId), string.Empty);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["ModelingId"] == null) return;
            string typeId = CreateNewStyleType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackInfo(MsSqlTable.HairStyleItem, false, StyleDbObject(typeId), Session["ModelingId"].ToString());
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
            ImgFront.ImageUrl = "";
            ImgBack.ImageUrl = "";
            ImgSide.ImageUrl = "";
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



        private string CreateNewStyleType(string ddlValue)
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
                    List<DbSearchObject> lst = HairStyleCategoryDbObject();
                    result = WriteBackInfo(MsSqlTable.HairStyleCategory, true, lst, string.Empty);
                    if (!result) return string.Empty;
                    typeId = GetCreatedId(MsSqlTable.HairStyleCategory, lst);
                }
            }
            else
            {
                typeId = ddlValue;
            }
            return typeId;
        }

        private void SetStyleInfoData(string id)
        {
            string sql = "Select * From HairStyleItem Where Id = '" + id + "'";
            DataSet ds = GetDataSetFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];

            tbSn.Text = dr["Sn"].ToString();
            tbDescription.Text = dr["Description"].ToString();
            ddlType.SelectedValue = dr["Type"].ToString();

            string ImgFolderPath = "~/" + MakeRelative(@dr["Img"].ToString(), @"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\");
            ImgFront.ImageUrl = ImgFolderPath + "/" + tbSn.Text + "_1.jpg";
            ImgBack.ImageUrl = ImgFolderPath + "/" + tbSn.Text + "_2.jpg";
            ImgSide.ImageUrl = ImgFolderPath + "/" + tbSn.Text + "_3.jpg";
            tbFolderPath.Text = ImgFolderPath;
        }

        #region Db Instance
        private List<DbSearchObject> StyleDbObject(string typeId)
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
                , typeId
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "StroeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "Img"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , @"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text
                ));
            return lst;
        }
        private List<DbSearchObject> HairStyleCategoryDbObject()
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
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }
        #endregion

        #region Db Control
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
        #endregion

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbType.Visible = ddlType.SelectedValue == "CreateItem";
            tbType.Text = string.Empty;
        }
        protected void btnImgFrontUpload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text))
            {
                ImgFrontUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_1.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Directory.CreateDirectory(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text);
                ImgFrontUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_1.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            Response.AddHeader("Refresh", "0");
        }

        protected void btnImgBackUpload_Click(object sender, EventArgs e)
        {


            if (Directory.Exists(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text))
            {
                ImgBackUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_2.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Directory.CreateDirectory(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text);
                ImgBackUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_2.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            Response.AddHeader("Refresh", "0");
        }

        protected void btnImgSideUpload_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text))
            {
                ImgSideUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_3.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            else
            {
                Directory.CreateDirectory(@"C:\Jason_project\TheWeWebPortal\Web\TheWeWebSite\TheWeWebSite\photo\HairStyleItem\" + tbSn.Text);
                ImgSideUpload.PostedFile.SaveAs(Server.MapPath(tbFolderPath.Text) + "/" + tbSn.Text + "_3.jpg");
                Response.Redirect(Request.Url.AbsoluteUri);
            }
            Response.AddHeader("Refresh", "0");
        }

        public static string MakeRelative(string filePath, string referencePath)
        {
            var fileUri = new Uri(filePath);
            var referenceUri = new Uri(referencePath);
            return referenceUri.MakeRelativeUri(fileUri).ToString();
        }
    }
}