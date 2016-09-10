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
                    InitialPage();
                }
            }
        }

        private void InitialPage()
        {
            InitialControl();
            InitialControlWithPermission();
            TextHint();
            if (Session["ModelingId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.StyleMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetStyleInfoData(Session["ModelingId"].ToString());
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.StoreMgtString
                + " > " + Resources.Resource.StyleMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
        }

        private void TextHint()
        {
            tbSn.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SnString);
            tbDescription.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.DescriptionString);

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
                Session.Remove("ModelingId");
                Response.Redirect("ModelingMaintain.aspx", true);
            }
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
            ddlType.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
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
            string typeId = CreateNewStyleType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            List<DbSearchObject> lst = StyleDbObject(true, typeId);
            bool result = WriteBackInfo(MsSqlTable.HairStyleItem, true, lst, string.Empty);
            string id = GetCreatedId(MsSqlTable.HairStyleItem, lst);
            if (!string.IsNullOrEmpty(id))
            {
                Session["ModelingId"] = id;
                TransferToOtherPage(true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["ModelingId"] == null) return;
            string typeId = CreateNewStyleType(ddlType.SelectedValue);
            if (string.IsNullOrEmpty(typeId)) return;
            bool result = WriteBackInfo(MsSqlTable.HairStyleItem, false, StyleDbObject(false, typeId), Session["ModelingId"].ToString());
            if (result)
            {
                TransferToOtherPage(true);
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
            TransferToOtherPage(false);
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
                    List<DbSearchObject> lst = HairStyleCategoryDbObject(true);
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
            ddlType_SelectedIndexChanged(ddlType, new EventArgs());
            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"HairStyleItem\" + tbSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;

            string ImgFolderPath = imgPath;

            tbFolderPath.Text = ImgFolderPath;
            RefreshImage(0, ImgFolderPath);

        }

        #region Db Instance
        private List<DbSearchObject> StyleDbObject(bool isCreate, string typeId)
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
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
                ));

            return lst;
        }
        private List<DbSearchObject> HairStyleCategoryDbObject(bool isCreate)
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
                List<DbSearchObject> conds = new List<DbSearchObject>();
                if (table == MsSqlTable.HairStyleItem)
                {
                    conds.Add(lst.Find(x => x.AttrName == "Type"));
                    conds.Add(lst.Find(x => x.AttrName == "StoreId"));
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
                case 0:
                default:
                    ImgFront.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgBack.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_2.jpg?" + DateTime.Now.Ticks.ToString();
                    ImgSide.ImageUrl = "http:" + path + @"\" + tbSn.Text + "_3.jpg?" + DateTime.Now.Ticks.ToString();
                    break;
            }
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            bool needRefresh = false;
            CheckFolder(tbFolderPath.Text);
            for (int i = 1; i <= 3; i++)
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
        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion
    }
}