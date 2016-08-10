using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeWebSite.Output;

namespace TheWeWebSite.CaseMgt
{
    public partial class AdvisoryMCreate : System.Web.UI.Page
    {
        DataSet DS;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                Session["ConsultId"] = Request.QueryString["Id"].ToString();
            }
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;

                    InitialControls();
                    InitialControlWithPermission();

                    if (Session["ConsultId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.CustomerMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        GetConsultInfo(Session["ConsultId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.CustomerMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                        btnClear.Visible = false;
                        tbLastReceived.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                        tbBookingDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    }
                }
            }
        }

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }

        #region Control Initial
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
            btnExport.Enabled = item.CanExport;
            btnExport.Visible = item.CanExport;
        }
        private void InitialControls()
        {
            InitialMsgerType();
            InitialSourceInfo();
            InitialAdvisory();
            InitialArea(string.Empty);
            InitialChurch(string.Empty);
            InitialCountry(string.Empty);
            InitialService();
            InitialStatus();
        }
        private void InitialStatus()
        {
            ddlStatus.Items.Clear();
            try
            {
                string sql = "select * from ConferenceItem"
                    + " Where ConferenceLv = 0 order by Sn";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlStatus.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()
                        ));
                }
                ddlStatus.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialAdvisory()
        {
            cblAdvisory.Items.Clear();
            try
            {
                string sql = "Select * From ServiceItemCategory"
                    + " Where IsDelete = 0 And TypeLv = 0 "
                    + " Order by Type";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                ListItem item = new ListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cblAdvisory.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialService()
        {
            cblWeddingPlanner.Items.Clear();
            try
            {
                string sql = "Select * From ServiceItemCategory"
                    + " Where IsDelete = 0 And TypeLv = 1 "
                    + " Order by Type";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                ListItem item = new ListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cblWeddingPlanner.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                        , dr["Id"].ToString()));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialMsgerType()
        {
            ddlGroomMsgerType.Items.Clear();
            ddlGroomMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            ddlBridalMsgerType.Items.Clear();
            ddlBridalMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            try
            {
                string sql = "Select * From Messenger Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                ListItem item = new ListItem();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    item = new ListItem(dr["Name"].ToString(), dr["Id"].ToString());
                    ddlGroomMsgerType.Items.Add(item);
                    ddlBridalMsgerType.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialSourceInfo()
        {
            ddlSourceInfo.Items.Clear();
            try
            {
                string sql = "Select * From InforSourceItem Where IsDelete = 0";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlSourceInfo.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()
                        ));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialCountry(string sql)
        {
            cblCountry.Items.Clear();
            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql = "SELECT * FROM [TheWe].[dbo].[Country]"
                        + " Where IsDelete = 0"
                        + " And Id in (Select Distinct CountryId From Church)";
                }
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cblCountry.Items.Add(
                        new ListItem(
                            SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            , dr["Id"].ToString()
                        ));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialArea(string sql)
        {
            cblArea.Items.Clear();
            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql = "SELECT * FROM [TheWe].[dbo].[Area]"
                        + " Where IsDelete = 0"
                        + " And Id in (Select Distinct AreaId From Church)";
                }
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cblArea.Items.Add(
                        new ListItem(
                            (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            + "(" + SysProperty.Util.OutputRelatedLangName
                            (((string)Session["CultureCode"]), SysProperty.GetCountryById(dr["CountryId"].ToString())) + ")")
                            , dr["Id"].ToString()
                        ));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialChurch(string sql)
        {
            cblLocation.Items.Clear();
            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    sql = "SELECT * FROM [TheWe].[dbo].[Church]"
                        + " Where IsDelete = 0";
                }

                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    cblLocation.Items.Add(
                        new ListItem(
                            (SysProperty.Util.OutputRelatedLangName(((string)Session["CultureCode"]), dr)
                            + "(" + SysProperty.Util.OutputRelatedLangName
                            (((string)Session["CultureCode"]), SysProperty.GetAreaById(dr["AreaId"].ToString())) + ")")
                            , dr["Id"].ToString()
                        ));
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        #region Button Control
        protected void btnExport_Click(object sender, EventArgs e)
        {
            GenerateDoc(tbSn.Text, DateTime.Parse(labelConsultDate.Text)
                , tbBridalName.Text, tbBridalEngName.Text, tbBridalPhone.Text, tbBridalMsgId.Text + "(" + ddlBridalMsgerType.SelectedItem.Text + ")", tbBridalBday.Text, tbBridalWork.Text, tbBridalEmail.Text
                , tbGroomName.Text, tbGroomEngName.Text, tbGroomPhone.Text, tbGroomMsgId.Text + "(" + ddlGroomMsgerType.SelectedItem.Text + ")", tbGroomBday.Text, tbGroomWork.Text, tbGroomEmail.Text);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["ConsultId"].ToString())) return;
                string sql = "UPDATE Customer SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ConsultId"].ToString() + "'";
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbBridalBday.Text = string.Empty;
            tbBridalEmail.Text = string.Empty;
            tbBridalEngName.Text = string.Empty;
            tbBridalMsgId.Text = string.Empty;
            tbBridalName.Text = string.Empty;
            tbBridalPhone.Text = string.Empty;
            tbBridalWork.Text = string.Empty;
            tbGroomBday.Text = string.Empty;
            tbGroomEmail.Text = string.Empty;
            tbGroomEngName.Text = string.Empty;
            tbGroomMsgId.Text = string.Empty;
            tbGroomName.Text = string.Empty;
            tbGroomPhone.Text = string.Empty;
            tbGroomWork.Text = string.Empty;
            tbLastReceived.Text = string.Empty;
            tbReception.Text = string.Empty;
            tbSn.Text = string.Empty;
            tbWeddingDate.Text = string.Empty;
            tbWeddingFilm.Text = string.Empty;
            tbRemark.Text = string.Empty;
            ddlBridalMsgerType.SelectedIndex = 0;
            ddlGroomMsgerType.SelectedIndex = 0;
            InitialControls();
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            List<DbSearchObject> lst = ConsultDbObject();
            if (string.IsNullOrEmpty(Session["ConsultId"].ToString())) return;
            string id = Session["ConsultId"].ToString();
            bool result = WriteBackConsult(false, lst, id);
            if (!result) return;
            result = WriteBackService(false, ServiceDbObject(id), id);
            if (!result)
            {
                WriteBackService(false, new List<List<DbSearchObject>>(), id);
                return;
            }
            result = WriteBackLocation(false, LocationDbObject(id), id);
            if (!result)
            {
                WriteBackLocation(false, new List<List<DbSearchObject>>(), id);
                return;
            }
            result = WriteBackSourceInfo(false, SourceInfoDbObject(id), id);

            if (!result)
            {
                WriteBackSourceInfo(false, new List<List<DbSearchObject>>(), id);
                return;
            }

            if (ddlStatus.SelectedIndex == 1)
            {
                result = ChangeToOrder(id);
            }

            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.Consultation), tbSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            List<DbSearchObject> lst = ConsultDbObject();
            lst.Add(new DbSearchObject(
                "ConsultDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            bool result = WriteBackConsult(true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateConsultId(lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackService(true, ServiceDbObject(id), id);
            if (!result)
            {
                WriteBackService(false, new List<List<DbSearchObject>>(), id);
                return;
            }
            result = WriteBackLocation(true, LocationDbObject(id), id);
            if (!result)
            {
                WriteBackLocation(false, new List<List<DbSearchObject>>(), id);
                return;
            }
            result = WriteBackSourceInfo(true, SourceInfoDbObject(id), id);
            if (!result)
            {
                WriteBackSourceInfo(false, new List<List<DbSearchObject>>(), id);
                return;
            }

            if (ddlStatus.SelectedIndex == 1)
            {
                result = ChangeToOrder(id);
            }

            if (result)
            {
                TransferToOtherPage();
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }
        #endregion

        #region DB Control
        #region DB Insatnce Object
        private List<DbSearchObject> ConsultDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSn.Text));
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
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "UpdateAccId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "SeekerGender"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , "0"
                ));
            lst.Add(new DbSearchObject(
                "BridalName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalName.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalEngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalEngName.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalPhone"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalPhone.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalWork"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalWork.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalBday"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbBridalBday.Text
                ));
            lst.Add(new DbSearchObject(
                "BridalEmail"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalEmail.Text
                ));
            if (!string.IsNullOrEmpty(ddlBridalMsgerType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "BridalMsgerType"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlBridalMsgerType.SelectedValue
                ));
            }
            lst.Add(new DbSearchObject(
                "BridalMsgerId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalMsgId.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomName.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomEngName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomEngName.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomWork"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomWork.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomBday"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomBday.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomPhone"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomPhone.Text
                ));
            lst.Add(new DbSearchObject(
                "GroomEmail"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomEmail.Text
                ));
            if (!string.IsNullOrEmpty(ddlGroomMsgerType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "GroomMsgerType"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlGroomMsgerType.SelectedValue
                    ));
            }
            lst.Add(new DbSearchObject(
               "IsReply"
               , AtrrTypeItem.Bit
               , AttrSymbolItem.Equal
               , cbReply.Checked ? "1" : "0"
               ));
            lst.Add(new DbSearchObject(
                "GroomMsgerId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomMsgId.Text
                ));
            lst.Add(new DbSearchObject(
                "FilmingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbWeddingFilm.Text
                ));
            lst.Add(new DbSearchObject(
                "ReceptionDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbReception.Text
                ));
            lst.Add(new DbSearchObject(
                "LastReceivedDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbLastReceived.Text
                ));
            lst.Add(new DbSearchObject(
                "WeddingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbWeddingDate.Text
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbBookingDate.Text
                ));
            lst.Add(new DbSearchObject(
                "StatusId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlStatus.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "CloseDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , ddlStatus.SelectedIndex != 0 ? DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") : string.Empty
                ));
            if (ddlStatus.SelectedIndex == 1)
            {
                lst.Add(new DbSearchObject(
                "ContractDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                ));
            }
            return lst;
        }

        private List<List<DbSearchObject>> SourceInfoDbObject(string id)
        {
            List<List<DbSearchObject>> lst = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst2 = new List<DbSearchObject>();
            foreach (ListItem item in ddlSourceInfo.Items)
            {
                if (item.Selected)
                {
                    lst2 = new List<DbSearchObject>();
                    lst2.Add(new DbSearchObject(
                        "InfoId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , item.Value));
                    lst2.Add(new DbSearchObject(
                        "Desciption"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , string.Empty));
                    lst2.Add(new DbSearchObject(
                        "ConsultId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , id));
                    lst2.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                        );
                    lst.Add(lst2);
                }
            }
            return lst;
        }

        private List<List<DbSearchObject>> LocationDbObject(string id)
        {
            List<List<DbSearchObject>> lst2 = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            DataRow dr = null;
            foreach (ListItem item in cblLocation.Items)
            {
                if (item.Selected)
                {
                    dr = SysProperty.GetChurchById(item.Value);
                    lst = new List<DbSearchObject>();
                    lst.Add(new DbSearchObject(
                        "ChurchId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , item.Value));
                    lst.Add(new DbSearchObject(
                        "ConsultId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , id));
                    lst.Add(new DbSearchObject(
                        "AreaId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , dr["AreaId"].ToString()));
                    lst.Add(new DbSearchObject(
                        "CountryId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , dr["CountryId"].ToString()));
                    lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])[0].ToString()));
                    lst2.Add(lst);
                }
            }
            return lst2;
        }

        private List<List<DbSearchObject>> ServiceDbObject(string id)
        {
            List<List<DbSearchObject>> lst2 = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            foreach (ListItem item in cblAdvisory.Items)
            {
                if (item.Selected)
                {
                    lst = new List<DbSearchObject>();
                    lst.Add(new DbSearchObject(
                        "ConsultId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , id));
                    lst.Add(new DbSearchObject(
                        "ServiceCategoryId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , item.Value));
                    lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                        );
                    lst.Add(new DbSearchObject(
                        "Lv"
                        , AtrrTypeItem.Bit
                        , AttrSymbolItem.Equal
                        , "0")
                        );
                    lst2.Add(lst);
                }
            }
            foreach (ListItem item in cblWeddingPlanner.Items)
            {
                if (item.Selected)
                {
                    lst = new List<DbSearchObject>();
                    lst.Add(new DbSearchObject(
                        "ConsultId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , id));
                    lst.Add(new DbSearchObject(
                        "ServiceCategoryId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , item.Value));
                    lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString())
                        );
                    lst.Add(new DbSearchObject(
                        "Lv"
                        , AtrrTypeItem.Bit
                        , AttrSymbolItem.Equal
                        , "1")
                        );
                    lst2.Add(lst);
                }
            }
            return lst2;
        }

        private List<DbSearchObject> CustomerDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                        "Name"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalName.Text));
            lst.Add(new DbSearchObject(
                        "CountryId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , Session["LocateStore"] != null
                        ? ((DataRow)Session["LocateStore"])["CountryId"].ToString()
                        : string.Empty));
            lst.Add(new DbSearchObject(
                        "EngName"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalEngName.Text));
            lst.Add(new DbSearchObject(
                        "Email"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalEmail.Text));
            lst.Add(new DbSearchObject(
                        "Bday"
                        , AtrrTypeItem.Date
                        , AttrSymbolItem.Equal
                        , tbBridalBday.Text));
            lst.Add(new DbSearchObject(
                        "Phone"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalPhone.Text));
            lst.Add(new DbSearchObject(
                        "MessengerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalMsgId.Text));
            lst.Add(new DbSearchObject(
                        "Works"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalWork.Text));
            lst.Add(new DbSearchObject(
                        "Gender"
                        , AtrrTypeItem.Bit
                        , AttrSymbolItem.Equal
                        , "0"));
            lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            lst.Add(new DbSearchObject(
                        "StoreId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , Session["LocateStore"] != null
                        ? ((DataRow)Session["LocateStore"])["Id"].ToString()
                        : string.Empty));
            if (!string.IsNullOrEmpty(ddlBridalMsgerType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                        "MessengerType"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlBridalMsgerType.SelectedValue));
            }
            return lst;
        }
        private List<DbSearchObject> PartnerDbObject()
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                        "Name"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomName.Text));
            lst.Add(new DbSearchObject(
                        "EngName"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomEngName.Text));
            lst.Add(new DbSearchObject(
                        "Email"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomEmail.Text));
            lst.Add(new DbSearchObject(
                        "Bday"
                        , AtrrTypeItem.Date
                        , AttrSymbolItem.Equal
                        , tbGroomBday.Text));
            lst.Add(new DbSearchObject(
                        "Phone"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomPhone.Text));
            lst.Add(new DbSearchObject(
                        "MessengerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomMsgId.Text));
            lst.Add(new DbSearchObject(
                        "Works"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomWork.Text));
            lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString()));
            if (!string.IsNullOrEmpty(ddlGroomMsgerType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                        "MessengerType"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlGroomMsgerType.SelectedValue));
            }
            return lst;
        }
        private List<DbSearchObject> OrderDbObject(string consultId, string customerId, string partnerId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                        "ConsultId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , consultId));
            lst.Add(new DbSearchObject(
                        "CustomerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , customerId));
            lst.Add(new DbSearchObject(
                        "PartnerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , partnerId));
            lst.Add(new DbSearchObject(
                        "StatusId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlStatus.Items[0].Value));
            lst.Add(new DbSearchObject(
                        "ConferenceCategory"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ddlStatus.Items[0].Value));
            lst.Add(new DbSearchObject(
                        "StartTime"
                        , AtrrTypeItem.DateTime
                        , AttrSymbolItem.Equal
                        , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            lst.Add(new DbSearchObject(
                        "StoreId"
                        , AtrrTypeItem.DateTime
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["LocateStore"])["Id"].ToString()));

            return lst;
        }
        #endregion

        private string GetCreateConsultId(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Consultation)
                    , " Where Sn=N'" + tbSn.Text + "'"
                    + " And StoreId=N'" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'"
                    + " And EmployeeId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString()
                    + "'").Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }

        private bool WriteBackConsult(bool isInsert, List<DbSearchObject> lst, string id)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Consultation)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst)
                    ))
                    : (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(MsSqlTable.Consultation)
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

        private bool WriteBackSourceInfo(bool isInsert, List<List<DbSearchObject>> lst, string consultId)
        {
            bool result = true;
            string sql = "DELETE FROM [dbo].[InfoSource] WHERE ConsultId = '" + consultId + "'";
            if (!isInsert)
            {
                SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            foreach (List<DbSearchObject> item in lst)
            {
                try
                {
                    result = result | SysProperty.GenDbCon.InsertDataInToTable
                        (SysProperty.Util.MsSqlTableConverter(MsSqlTable.InfoSource)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                        , SysProperty.Util.SqlQueryInsertValueConverter(item));
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

        private bool WriteBackLocation(bool isInsert, List<List<DbSearchObject>> lst, string consultId)
        {
            bool result = true;
            try
            {
                string sql = "DELETE FROM [dbo].[ConsultLocation] WHERE ConsultId = '" + consultId + "'";
                if (!isInsert)
                {
                    SysProperty.GenDbCon.ModifyDataInToTable(sql);
                }
                if (result)
                {
                    foreach (List<DbSearchObject> item in lst)
                    {
                        try
                        {
                            result = result |
                                (SysProperty.GenDbCon.InsertDataInToTable
                                (SysProperty.Util.MsSqlTableConverter(MsSqlTable.ConsultLocation)
                                , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                                , SysProperty.Util.SqlQueryInsertValueConverter(item)));
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
                return false;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        private bool WriteBackService(bool isInsert, List<List<DbSearchObject>> lst, string consultId)
        {
            bool result = true;
            try
            {
                string sql = "DELETE FROM [dbo].[ConsultServiceItem] WHERE ConsultId = '" + consultId + "'";
                if (!isInsert)
                {
                    SysProperty.GenDbCon.ModifyDataInToTable(sql);
                }
                if (result)
                {
                    foreach (List<DbSearchObject> item in lst)
                    {
                        try
                        {
                            result = result |
                                (SysProperty.GenDbCon.InsertDataInToTable
                                (SysProperty.Util.MsSqlTableConverter(MsSqlTable.ConsultServiceItem)
                                , SysProperty.Util.SqlQueryInsertInstanceConverter(item)
                                , SysProperty.Util.SqlQueryInsertValueConverter(item)));
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
                return false;
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        #region DB Related
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

        #endregion

        private void TransferToOtherPage()
        {
            Session.Remove("ConsultId");
            Server.Transfer("AdvisoryMaintain.aspx", true);
        }

        #region Existence Data Set
        private void GetConsultInfo(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return;
                DS = SysProperty.GenDbCon.GetDataFromTable(string.Empty
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Consultation)
                    , " Where Id='" + id + "'");
                if (SysProperty.Util.IsDataSetEmpty(DS)) TransferToOtherPage();
                SetAllControlValue(DS);
            }
            catch (Exception ex)
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
                tbBridalBday.Text = SysProperty.Util.ParseDateTime("Date", dr["BridalBday"].ToString());
                tbBridalEmail.Text = dr["BridalEmail"].ToString();
                tbBridalEngName.Text = dr["BridalEngName"].ToString();
                tbBridalMsgId.Text = dr["BridalMsgerId"].ToString();
                tbBridalName.Text = dr["BridalName"].ToString();
                tbBridalPhone.Text = dr["BridalPhone"].ToString();
                tbBridalWork.Text = dr["BridalWork"].ToString();
                tbGroomBday.Text = SysProperty.Util.ParseDateTime("Date", dr["GroomBday"].ToString());
                cbReply.Checked = bool.Parse(dr["IsReply"].ToString());
                tbGroomEmail.Text = dr["GroomEmail"].ToString();
                tbGroomEngName.Text = dr["GroomEngName"].ToString();
                tbGroomMsgId.Text = dr["GroomMsgerId"].ToString();
                tbGroomName.Text = dr["GroomName"].ToString();
                tbGroomPhone.Text = dr["GroomPhone"].ToString();
                tbGroomWork.Text = dr["GroomWork"].ToString();
                tbLastReceived.Text = SysProperty.Util.ParseDateTime("DateTime", dr["LastReceivedDate"].ToString());
                tbBookingDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
                tbReception.Text = SysProperty.Util.ParseDateTime("Date", dr["ReceptionDate"].ToString());
                tbWeddingDate.Text = SysProperty.Util.ParseDateTime("Date", dr["WeddingDate"].ToString());
                tbWeddingFilm.Text = SysProperty.Util.ParseDateTime("Date", dr["FilmingDate"].ToString());
                tbSn.Text = dr["Sn"].ToString();
                labelConsultDate.Text = SysProperty.Util.ParseDateTime("Date", dr["ConsultDate"].ToString());
                tbRemark.Text = dr["Remark"].ToString();
                ddlBridalMsgerType.SelectedValue = dr["BridalMsgerType"].ToString();
                ddlGroomMsgerType.SelectedValue = dr["GroomMsgerType"].ToString();
                ddlStatus.SelectedValue = dr["StatusId"].ToString();
                if (ddlStatus.SelectedIndex != 0)
                {
                    btnModify.Visible = false;
                    btnDelete.Visible = false;
                }
                SetLocation(GetLocationInConsult(dr["Id"].ToString()));
                SetInfoSource(GetInfoSource(dr["Id"].ToString()));
                SetService(GetConsultService(dr["Id"].ToString()));
            }
        }

        private DataSet GetLocationInConsult(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            try
            {
                string sql = "Select * From ConsultLocation Where IsDelete = 0 And ConsultId = '" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetConsultService(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            try
            {
                string sql = "SELECT c.[Id],c.[ConsultId],c.[ServiceCategoryId],c.[Description]"
                    + ",c.[IsDelete],c.[UpdateAccId],c.[UpdateTime],s.TypeLv"
                    + " FROM [TheWe].[dbo].[ConsultServiceItem] as c"
                    + " left join ServiceItemCategory as s on s.Id = c.ServiceCategoryId"
                    + " Where c.IsDelete = 0 And c.ConsultId = '" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetInfoSource(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            try
            {
                string sql = "SELECT *"
                    + "FROM [TheWe].[dbo].[InfoSource]"
                    + " Where IsDelete = 0 And ConsultId = '" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetLocation(DataSet ds)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    if (dr["CountryId"] != null || !string.IsNullOrEmpty(dr["CountryId"].ToString()))
                    {
                        cblCountry.Items.FindByValue(dr["CountryId"].ToString()).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
            cblCountry_SelectedIndexChanged(cblCountry, new EventArgs());

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    if (dr["AreaId"] != null || !string.IsNullOrEmpty(dr["AreaId"].ToString()))
                    {
                        cblArea.Items.FindByValue(dr["AreaId"].ToString()).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
            cblArea_SelectedIndexChanged(cblArea, new EventArgs());

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    if (dr["ChurchId"] != null)
                    {
                        if (!string.IsNullOrEmpty(dr["ChurchId"].ToString()))
                            cblLocation.Items.FindByValue(dr["ChurchId"].ToString()).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        private void SetService(DataSet ds)
        {
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    if (dr["TypeLv"].ToString() == "0")
                    {
                        cblAdvisory.Items.FindByValue(dr["ServiceCategoryId"].ToString()).Selected = true;
                    }
                    else
                    {
                        cblWeddingPlanner.Items.FindByValue(dr["ServiceCategoryId"].ToString()).Selected = true;
                    }
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }

        private void SetInfoSource(DataSet ds)
        {
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                try
                {
                    ddlSourceInfo.Items.FindByValue(dr["InfoId"].ToString()).Selected = true;
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                    ShowErrorMsg(ex.Message);
                    continue;
                }
            }
        }
        #endregion

        #region CheckBoxList Control
        protected void cblCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condStr = string.Empty;
            foreach (ListItem item in cblCountry.Items)
            {
                if (item.Selected)
                {
                    condStr += (string.IsNullOrEmpty(condStr) ? string.Empty : ",")
                        + "'" + item.Value + "'";
                }
            }

            if (!string.IsNullOrEmpty(condStr))
            {
                string sql = "SELECT * FROM [TheWe].[dbo].[Area]"
                             + " Where IsDelete = 0"
                             + " And Id in ( Select Distinct AreaId From Church Where CountryId in (" + condStr + "))";
                InitialArea(sql);

                List<string> churchTmp = GetCurrentChurchSelection(cblLocation);
                sql = "SELECT * FROM [TheWe].[dbo].[Church]"
                             + " Where IsDelete = 0"
                             + " And CountryId in (" + condStr + ")";
                InitialChurch(sql);
                RecoveryLocationSelection(churchTmp);
            }
        }

        protected void cblArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string condStr = string.Empty;
            foreach (ListItem item in cblArea.Items)
            {
                if (item.Selected)
                {
                    condStr += (string.IsNullOrEmpty(condStr) ? string.Empty : ",")
                        + "'" + item.Value + "'";
                }
            }
            if (!string.IsNullOrEmpty(condStr))
            {
                List<string> churchTmp = GetCurrentChurchSelection(cblLocation);
                string sql = "SELECT * FROM [TheWe].[dbo].[Church]"
                         + " Where IsDelete = 0"
                         + " And AreaId in (" + condStr + ")";
                InitialChurch(sql);
                RecoveryLocationSelection(churchTmp);
            }
        }

        private List<string> GetCurrentChurchSelection(CheckBoxList lst)
        {
            List<string> churchs = new List<string>();
            foreach (ListItem item in lst.Items)
            {
                if (item.Selected)
                {
                    churchs.Add(item.Value);
                }
            }
            return churchs;
        }
        private void RecoveryLocationSelection(List<string> churchs)
        {
            ListItem item = null;
            DataRow dr = null;
            foreach (string cid in churchs)
            {
                dr = SysProperty.GetChurchById(cid);
                if (dr != null)
                {
                    item = cblArea.Items.FindByValue(dr["AreaId"].ToString());
                    if (item != null) item.Selected = true;
                }
                item = cblLocation.Items.FindByValue(cid);
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }
        #endregion

        #region Advisory change to Order
        private bool ChangeToOrder(string consultId)
        {
            List<DbSearchObject> lst = CustomerDbObject();
            bool result = WriteBackCustomer(lst);
            if (!result) return false;
            string customerId = GetCreateCustomerId(lst);
            if (string.IsNullOrEmpty(customerId)) return false;

            lst = PartnerDbObject();
            result = WriteBackPartner(lst);
            if (!result) return false;
            string partnerId = GetCreatePartner(lst);
            if (string.IsNullOrEmpty(partnerId)) return false;

            return WriteBackOrderInfo(OrderDbObject(consultId, customerId, partnerId));
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

        private string GetCreatePartner(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("Id"
                    , SysProperty.Util.MsSqlTableConverter(MsSqlTable.vwEN_Partner)
                    , SysProperty.Util.SqlQueryConditionConverter(lst)).Tables[0].Rows[0]["Id"].ToString();
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return string.Empty;
            }
        }

        private bool WriteBackCustomer(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Customer)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private bool WriteBackPartner(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.Partner)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        private bool WriteBackOrderInfo(List<DbSearchObject> lst)
        {
            try
            {
                return SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(MsSqlTable.OrderInfo)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        #endregion

        protected void tbBookingDate_TextChanged(object sender, EventArgs e)
        {
            cbReply.Checked = true;
        }

        public void GenerateDoc(string sn, DateTime time
            , string bridalName, string bridalEngName, string bridalPhone, string bridalMsg, string bridalBday, string bridalWork, string bridalMail
            , string groomName, string groomEngName, string groomPhone, string groomMsg, string groomBday, string groomWork, string groomMail)
        {
            //Response.Redirect("~/Output/Download.aspx");
            //Response.AddHeader("Content-Disposition", "attachment; filename=" + sn + ".docx");
            string filePath = new GroupPhotoNotification().CreateGroupPhoto(sn, bridalName, groomName, "", new DateTime());
            Uri uri = new Uri(filePath); // Here I get the error
            string fName = Path.GetFullPath(uri.LocalPath);
            FileInfo fileInfo = new FileInfo(fName);
            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                Response.Buffer = true;
                Response.ContentType = "application/msword";
                //Response.ContentType = "application/Octet-stream";
                Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                Response.Charset = "UTF-8";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.WriteFile(filePath);
                Response.End();
            }
        }
    }
}
