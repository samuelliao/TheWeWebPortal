using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeWebSite.Output;

namespace TheWeWebSite.CaseMgt
{
    public partial class CaseMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["Id"] != null)
            {
                Session["OrderId"] = Request.QueryString["Id"].ToString();
            }
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
            FirstGridViewRow();
            FirstGridViewRow2();
            TextHint();
            if (Session["OrderId"] != null)
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.ContractMaintainString
                + " > " + Resources.Resource.ModifyString;
                btnModify.Visible = true;
                btnDelete.Visible = true;
                SetOrderData(Session["OrderId"].ToString());
                SetByCasePermission();
            }
            else
            {
                labelPageTitle.Text = Resources.Resource.OrderMgtString
                + " > " + Resources.Resource.ContractMaintainString
                + " > " + Resources.Resource.CreateString;
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
            InitialControlWithPermission();
        }

        private void TextHint()
        {
            tbAddress.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AddressString);
            tbAdvisorySn.Attributes.Add("placeHolder", Resources.Resource.SystemString);
            tbBridalEmail.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalEmailString);
            tbBridalMsgerId.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalCommunicationIdString);
            tbBridalName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalNameString);
            tbBridalNickname.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalNicknameString);

            tbBridalPassportName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalPassportString);
            tbBridalPhone.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.BridalPhoneString);

            tbCaseSn.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.CaseIdString);
            tbContractPrice.Attributes.Add("placeHolder", "0.00");

            tbCustomerSn.Attributes.Add("placeHolder", Resources.Resource.SystemString);


            tbDiscount.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.DiscountString);

            tbGroomEmail.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomEmailString);
            tbGroomMsgerId.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomCommunicationIdString);
            tbGroomName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomNameString);
            tbGroomNickname.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomNicknameString);
            tbGroomPassportName.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomPassportString);
            tbGroomPhone.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.GroomPhoneString);
            tbMsgerTitle.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.SnsTitleString);


            tbReferrals.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.ReferralsString);

            tbRemark.Attributes.Add("placeHolder", Resources.Resource.AddString + Resources.Resource.RemarkString);
            tbTotalPrice.Attributes.Add("placeHolder", "0.00");
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
                Server.Transfer("CaseMaintain.aspx", true);
                Session.Remove("OrderId");
                if (Session["CustomerId"] != null) Session.Remove("CustomerId");
                if (Session["PartnerId"] != null) Session.Remove("PartnerId");
                ViewState.Remove("CurrentTable");
            }
        }

        private void InitialControl()
        {
            SetMsgerTypeList();
            SetCountryList();
            SetAreaList(ddlCountry.SelectedValue);
            SetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            SetOrderTypeList();
            SetStatusList();
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlCountry.SelectedValue, ddlOrderType.SelectedValue);
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
            btnExport.Enabled = item.CanExport;
            btnExport.Visible = item.CanExport;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                btnDelete.Visible = false;
                btnModify.Visible = false;
                btnCreate.Visible = false;
                btnClear.Visible = false;
                dgServiceItem.Enabled = false;
                btnUpload.Visible = false;
                panelBasicInfo.Enabled = false;
            }
        }

        private void SetByCasePermission()
        {
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                btnDelete.Visible = false;
                btnModify.Visible = false;
                btnCreate.Visible = false;
                btnClear.Visible = false;
                dgServiceItem.Enabled = false;
                btnUpload.Visible = false;
            }
            else
            {
                PermissionUtil util = new PermissionUtil();
                // Find by store id.
                PermissionItem StoreItem = util.GetPermissionByKey(
                    ((Dictionary<string, PermissionItem>)Session["CasePermission"])
                    , ((DataRow)Session["LocateStore"])["Id"].ToString());

                // Find by CountryId
                PermissionItem Countryitem = util.GetPermissionByKey(
                    ((Dictionary<string, PermissionItem>)Session["CasePermission"])
                    , ddlCountry.SelectedValue);

                if (StoreItem == null && Countryitem == null) return;
                if (StoreItem == null && Countryitem != null)
                {
                    if (btnDelete.Visible) btnDelete.Visible = Countryitem.CanDelete;
                    if (btnModify.Visible) btnModify.Visible = Countryitem.CanModify;
                    if (btnCreate.Visible) btnCreate.Visible = Countryitem.CanCreate;
                }
                if (StoreItem != null && Countryitem == null)
                {
                    if (btnDelete.Visible) btnDelete.Visible = StoreItem.CanDelete;
                    if (btnModify.Visible) btnModify.Visible = StoreItem.CanModify;
                    if (btnCreate.Visible) btnCreate.Visible = StoreItem.CanCreate;
                }
                else
                {
                    if (btnDelete.Visible) btnDelete.Visible = StoreItem.CanDelete & Countryitem.CanDelete;
                    if (btnModify.Visible) btnModify.Visible = StoreItem.CanModify & Countryitem.CanModify;
                    if (btnCreate.Visible) btnCreate.Visible = StoreItem.CanCreate & Countryitem.CanCreate;
                }
            }
        }

        #region DropDownList Setting
        private void SetMsgerTypeList()
        {
            ddlGroomMsgerType.Items.Clear();
            ddlBridalMsgerType.Items.Clear();
            ddlGroomMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            ddlBridalMsgerType.Items.Add(new ListItem(Resources.Resource.MsgSelectionRemindString, string.Empty));
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Messenger Where IsDelete = 0");
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

        private void SetCountryList()
        {
            ddlCountry.Items.Clear();
            ddlCountry.Items.Add(new ListItem(Resources.Resource.CountrySelectRemindString, string.Empty));
            try
            {
                string sql = "Select * From Country Where IsDelete = 0 And Id in (Select Distinct CountryId From ProductSet Where IsDelete=0";
                if (!string.IsNullOrEmpty(ddlOrderType.SelectedValue))
                {
                    sql += " And Category = '" + ddlOrderType.SelectedValue + "'";
                }
                sql += ")";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCountry.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
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
        private void SetAreaList(string cid)
        {
            ddlArea.Items.Clear();
            ddlArea.Items.Add(new ListItem(Resources.Resource.AreaSelectRemindString, string.Empty));
            try
            {
                string sql = "Select * From Area Where IsDelete = 0 "
                    + (string.IsNullOrEmpty(cid) ? string.Empty : " And CountryId = '" + cid + "'");
                sql += " And Id in (Select Distinct AreaId From ProductSet Where IsDelete=0";
                if (!string.IsNullOrEmpty(ddlOrderType.SelectedValue))
                {
                    sql += " And Category = '" + ddlOrderType.SelectedValue + "'";
                }
                sql += ")";

                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlArea.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
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
        private void SetChurchList(string cid, string aid)
        {
            ddlLocate.Items.Clear();
            ddlLocate.Items.Add(new ListItem(Resources.Resource.ChurchSelectRemindString, string.Empty));
            try
            {
                string condStr = string.Empty;
                condStr += (string.IsNullOrEmpty(cid) ? string.Empty : " And CountryId = '" + cid + "'");
                condStr += (string.IsNullOrEmpty(aid) ? string.Empty : " And AreaId = '" + aid + "'");

                string sql = "Select * From Church Where IsDelete = 0 " + condStr;
                sql += " And Id in (Select Distinct ChurchId From ProductSet Where IsDelete=0";
                if (!string.IsNullOrEmpty(ddlOrderType.SelectedValue))
                {
                    sql += " And Category = '" + ddlOrderType.SelectedValue + "'";
                }
                sql += ")";

                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlLocate.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
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
        private void SetProductSetList(string cid, string aid, string lid, string typeId)
        {
            ddlProductSet.Items.Clear();
            ddlProductSet.Items.Add(new ListItem(Resources.Resource.ProductSetString, string.Empty));
            try
            {
                string condStr = string.Empty;
                if (!string.IsNullOrEmpty(cid))
                {
                    condStr += " And CountryId='" + cid + "'";
                }
                if (!string.IsNullOrEmpty(aid))
                {
                    condStr += " And AreaId='" + aid + "'";
                }
                if (!string.IsNullOrEmpty(lid))
                {
                    condStr += " And ChurchId='" + lid + "'";
                }
                if (!string.IsNullOrEmpty(typeId))
                {
                    condStr += " And Category='" + typeId + "'";
                }

                string sql = "Select * From ProductSet Where IsDelete = 0 " + condStr + " And StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlProductSet.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
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
        private void SetOrderTypeList()
        {
            ddlOrderType.Items.Clear();
            ddlOrderType.Items.Add(new ListItem(Resources.Resource.ProjectString, string.Empty));
            try
            {
                string sql = "SELECT * FROM [dbo].[ServiceItemCategory] Where TypeLv=0 order by Sn";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlOrderType.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr) + "(" + dr["Code"].ToString() + ")"
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
        private void SetStatusList()
        {
            ddlStatus.Items.Clear();
            try
            {
                string sql = "select * from ConferenceItem Where ConferenceLv = 0 And Sn != '10' order by Sn";
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
        #region DropDownList Event Hanlder
        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            DynamicSn(ddlOrderType.SelectedValue, ddlCountry.SelectedValue);
            SetAreaList(ddlCountry.SelectedValue);
            SetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
        }

        private void DynamicSn(string oid, string cid)
        {
            string sn = string.Empty;
            if (!string.IsNullOrEmpty(oid)) sn = SplitOutOrderTypeCode(ddlOrderType.SelectedItem.Text).Trim();
            if (!string.IsNullOrEmpty(cid)) sn += (SysProperty.GetCountryById(ddlCountry.SelectedValue))["Code"].ToString().Trim();

            tbCaseSn.Text = sn + tbSysSn.Text;
        }

        private string SplitOutOrderTypeCode(string txt)
        {
            txt = txt.Replace(")", "");
            if (txt.Contains("("))
            {
                return txt.Split('(')[1].ToString();
            }
            return txt;
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
            {
                try
                {
                    DataRow dr = SysProperty.GetAreaById(ddlArea.SelectedValue);
                    ddlCountry.SelectedValue = dr["CountryId"].ToString();
                }
                catch (Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                }
            }
        }

        protected void ddlLocate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
            if (!string.IsNullOrEmpty(ddlLocate.SelectedValue))
            {
                try
                {
                    DataRow dr = SysProperty.GetChurchById(ddlLocate.SelectedValue);
                    ddlArea.SelectedValue = dr["AreaId"].ToString();
                    ddlCountry.SelectedValue = dr["CountryId"].ToString();
                }catch(Exception ex)
                {
                    SysProperty.Log.Error(ex.Message);
                }
            }
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DynamicSn(ddlOrderType.SelectedValue, ddlCountry.SelectedValue);
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlProductSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstGridViewRow();
            if (!string.IsNullOrEmpty(ddlProductSet.SelectedValue))
            {
                SetProductServiceItem(ddlProductSet.SelectedValue);
                SetProductInfo(ddlProductSet.SelectedValue);
            }
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.SelectedIndex > 1)
            {
                tbCloseDay.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                tbCloseDay.Text = string.Empty;
            }
        }
        #endregion
        #endregion

        #region Button Control
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage(false);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(Session["ChurchId"].ToString())) return;
                string sql = "UPDATE OrderInfo SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + Session["ChurchId"].ToString() + "'";
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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            tbAddress.Text = string.Empty;
            tbAdvisorySn.Text = string.Empty;
            tbAppointDate.Text = string.Empty;
            tbBridalBday.Text = string.Empty;
            tbBridalName.Text = string.Empty;
            tbBridalNickname.Text = string.Empty;
            tbBridalPassportName.Text = string.Empty;
            tbCaseSn.Text = string.Empty;
            tbCloseDay.Text = string.Empty;
            tbContractPrice.Text = string.Empty;
            tbContractTime.Text = string.Empty;
            tbDiscount.Text = string.Empty;
            tbGroomBday.Text = string.Empty;
            tbGroomName.Text = string.Empty;
            tbGroomNickname.Text = string.Empty;
            tbGroomPassportName.Text = string.Empty;
            tbBridalMsgerId.Text = string.Empty;
            tbMsgerTitle.Text = string.Empty;
            tbBridalPhone.Text = string.Empty;
            tbBridalEmail.Text = string.Empty;
            tbGroomPhone.Text = string.Empty;
            tbGroomEmail.Text = string.Empty;
            tbRemark.Text = string.Empty;
            tbTotalPrice.Text = string.Empty;
            ddlArea.SelectedIndex = 0;
            ddlBridalMsgerType.SelectedIndex = 0;
            ddlCountry.SelectedIndex = 0;
            ddlGroomMsgerType.SelectedIndex = 0;
            ddlLocate.SelectedIndex = 0;
            ddlProductSet.SelectedIndex = 0;
            FirstGridViewRow();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            List<DbSearchObject> partnerInfo = PartnerDbObject(true);
            List<DbSearchObject> customerInfo = CustomerDbObject(true);

            bool result = false;

            string partnerId = string.Empty;
            if (Session["PartnerId"] == null)
            {
                WriteBackData(MsSqlTable.Partner, true, partnerInfo, string.Empty);
                partnerId = GetCreateId(MsSqlTable.vwEN_Partner, partnerInfo);
            }
            else
            {
                partnerId = Session["PartnerId"].ToString();
                result = WriteBackData(MsSqlTable.Partner, false, partnerInfo, " Where Id = '" + partnerId + "'");
            }
            if (string.IsNullOrEmpty(partnerId)) return;


            if (!result) return;
            string customerId = string.Empty;
            if (Session["CustomerId"] == null)
            {
                result = WriteBackData(MsSqlTable.Customer, true, customerInfo, string.Empty);
                customerId = GetCreateId(MsSqlTable.vwEN_Customer, partnerInfo);
            }
            else
            {
                customerId = Session["CustomerId"].ToString();
                result = WriteBackData(MsSqlTable.Customer, false, customerInfo, " Where Id = '" + customerId + "'");
            }
            if (string.IsNullOrEmpty(customerId)) return;

            List<DbSearchObject> lst = OrderInfoDbObject(true, customerId, partnerId);
            result = WriteBackData(MsSqlTable.OrderInfo, true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateId(MsSqlTable.OrderInfo, lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackServiceItem(true, ServiceItemDbObject(true, id), id);
            if (result)
            {
                Session["OrderId"] = id;
                WriteBackReceiptInfo(ReceiptDbObject(id));
                TransferToOtherPage(true);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["OrderId"] == null || Session["CustomerId"] == null || Session["PartnerId"] == null) return;
            string id = Session["OrderId"].ToString();
            string partnerId = Session["PartnerId"].ToString();
            string customerId = Session["CustomerId"].ToString();
            if (string.IsNullOrEmpty(id)) return;
            bool result = WriteBackData(MsSqlTable.OrderInfo, false, OrderInfoDbObject(false, customerId, partnerId), " Where Id='" + id + "'");
            if (!result) return;
            result = WriteBackData(MsSqlTable.Customer, false, CustomerDbObject(false), " Where Id='" + customerId + "'");
            if (!result) return;
            result = WriteBackData(MsSqlTable.Partner, false, PartnerDbObject(false), " Where Id='" + partnerId + "'");
            if (!result) return;
            result = WriteBackServiceItem(false, ServiceItemDbObject(false, id), id);
            if (result)
            {
                WriteBackReceiptInfo(ReceiptDbObject(id));
                TransferToOtherPage(true);
            }
        }
        #endregion

        #region Set modified data
        private DataSet GetOrderInfo(string id)
        {
            try
            {
                string sql = "SELECT o.[Id],[ConsultId],c.Sn as ConsultSn,o.[Sn]"
                    + ",o.[StartTime],[CustomerId],[PartnerId],o.[StatusId]"
                    + ",o.[CloseTime],[CountryId],o.[AreaId],o.[ChurchId],o.[SetId]"
                    + ",[ServiceWindowId],o.[StoreId],[PermissionId],[Price]"
                    + ",[CurrencyId],[DepositFirst],[PS_FirstHotelName],[PS_SecondHotelName],[CustomerImg]"
                    + ",o.[BookingDate],[OverseaWeddingDate],[DepositFirstDate]"
                    + ",[DepositSecondDate],[DepositSecond],[OverseaFilmDate]"
                    + ",[LocalFilmingDate],[LocalEngagementDate],[LocalWeddingDate]"
                    + ",[LocalMotheringDate],[LocalReceptionDate],[BalancePayementDate]"
                    + ",o.[ServiceType],o.[IsDelete],o.[UpdateAccId],o.[UpdateTime],o.[ServiceType]"
                    + ",[WeddingRecord],[DynamicRecord],[BridalSecretary],[WeddingPerform],[WeddingType]"
                    + ",[WeddingDecorate],[WeddingHost],[TotalPrice],[Discount],o.[Remark],[Referral],o.Img"
                    + ",DepositFirstType,DepositSecondType,BalancePayementType"
                    + " FROM [dbo].[OrderInfo] as o"
                    + " Left join Consultation as c on c.Id = o.ConsultId"
                    + " Where o.IsDelete = 0 And o.Id = '" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private void SetOrderData(string id)
        {
            DataSet ds = GetOrderInfo(id);
            if (SysProperty.Util.IsDataSetEmpty(ds))
            {
                TransferToOtherPage(false);
            }

            DataRow dr = ds.Tables[0].Rows[0];
            Session["CustomerId"] = dr["CustomerId"].ToString();
            Session["PartnerId"] = dr["PartnerId"].ToString();
            InitialCustomerInfo(dr["CustomerId"].ToString());
            InitialPartnerInfo(dr["PartnerId"].ToString());

            tbAdvisorySn.Text = dr["ConsultSn"].ToString();
            tbAppointDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
            if (dr["Sn"].ToString().Length > 10)
            {
                tbSysSn.Text = dr["Sn"].ToString().Substring(dr["Sn"].ToString().Length - 10, 10);
                tbCaseSn.Text = dr["Sn"].ToString().Substring(0, dr["Sn"].ToString().Length - 11);
            }
            else
            {
                tbSysSn.Text = dr["Sn"].ToString();
            }

            labelCaseSn.Text = dr["Sn"].ToString();

            tbCloseDay.Text = SysProperty.Util.ParseDateTime("DateTime", dr["CloseTime"].ToString());
            tbContractPrice.Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
            tbContractTime.Text = SysProperty.Util.ParseDateTime("DateTime", dr["StartTime"].ToString());
            tbDiscount.Text = SysProperty.Util.ParseMoney(dr["Discount"].ToString()).ToString("#0.00");
            tbDomesticEngagementDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalEngagementDate"].ToString());
            tbDomesticMotheringDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalMotheringDate"].ToString());
            tbDomesticWeddingDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalWeddingDate"].ToString());
            tbDomesticWeddReceptionDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalReceptionDate"].ToString());
            tbDomesticWedFilmDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalFilmingDate"].ToString());
            tbOverseaWeddingDate.Text = SysProperty.Util.ParseDateTime("Date", dr["OverseaWeddingDate"].ToString());
            tbOverSeaWedFilmDate.Text = SysProperty.Util.ParseDateTime("Date", dr["OverseaFilmDate"].ToString());
            tbReferrals.Text = dr["Referral"].ToString();
            tbRemark.Text = dr["Remark"].ToString();
            tbTotalPrice.Text = string.IsNullOrEmpty(dr["TotalPrice"].ToString())
                ? tbContractPrice.Text
                : SysProperty.Util.ParseMoney(dr["TotalPrice"].ToString()).ToString("#0.00");

            ddlStatus.SelectedValue = dr["StatusId"].ToString();
            if (ddlStatus.SelectedIndex != 0)
            {
                btnModify.Visible = false;
                btnDelete.Visible = false;
            }
            ddlProductSet.SelectedValue = dr["SetId"].ToString();
            ddlOrderType.SelectedValue = dr["ServiceType"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            ddlLocate.SelectedValue = dr["ChurchId"].ToString();

            if (!string.IsNullOrEmpty(ddlLocate.SelectedValue))
            {
                labelLocation.Text = ddlLocate.SelectedItem.Text + "(" + ddlCountry.SelectedItem.Text + ")";
            }

            // Additional Item Table
            SetOrderServiceItem(id);

            DynamicSn(ddlOrderType.SelectedValue, ddlCountry.SelectedValue);


            // Photo Setting
            string imgPath = @dr["Img"].ToString();
            if (string.IsNullOrEmpty(imgPath)) imgPath = SysProperty.ImgRootFolderpath + @"OrderInfo\" + tbCaseSn.Text;
            else imgPath = SysProperty.ImgRootFolderpath + imgPath;
            string ImgFolderPath = imgPath;
            RefreshImage(ImgFolderPath);
            tbFolderPath.Text = ImgFolderPath;

            // Receipt
            SetReceiptDetail(id);
        }

        private void InitialCustomerInfo(string id)
        {
            DataSet ds = GetDataFromTable(MsSqlTable.vwEN_Customer, " Where IsDelete = 0 And Id = '" + id + "'");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                tbBridalName.Text = dr["Name"].ToString();
                labelBridalName.Text = tbBridalName.Text;
                tbBridalMsgerId.Text = dr["MessengerId"].ToString();
                tbBridalBday.Text = SysProperty.Util.ParseDateTime("Date", dr["Bday"].ToString());
                tbBridalNickname.Text = dr["Nickname"].ToString();
                tbBridalPassportName.Text = dr["EngName"].ToString();
                ddlBridalMsgerType.SelectedValue = dr["MessengerType"].ToString();
                tbBridalPhone.Text = dr["Phone"].ToString();
                tbBridalEmail.Text = dr["Email"].ToString();
                tbMsgerTitle.Text = dr["MsgTitle"].ToString();
                tbAddress.Text = dr["Addr"].ToString();
                tbCustomerSn.Text = dr["Sn"].ToString();
            }
        }
        private void InitialPartnerInfo(string id)
        {
            DataSet ds = GetDataFromTable(MsSqlTable.vwEN_Partner, " Where IsDelete = 0 And Id = '" + id + "'");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                tbGroomName.Text = dr["Name"].ToString();
                labelGroomName.Text = tbGroomName.Text;
                tbGroomMsgerId.Text = dr["MessengerId"].ToString();
                tbGroomBday.Text = SysProperty.Util.ParseDateTime("Date", dr["Bday"].ToString());
                tbGroomNickname.Text = dr["Nickname"].ToString();
                tbGroomPassportName.Text = dr["EngName"].ToString();
                ddlGroomMsgerType.SelectedValue = dr["MessengerType"].ToString();
                tbGroomPhone.Text = dr["Phone"].ToString();
                tbGroomEmail.Text = dr["Email"].ToString();
            }
        }

        private void SetOrderServiceItem(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;
            string sql = "SELECT ps.[Id],[SetId],[ItemId],[Number],[UnitId],ps.[CategoryId]"
                + ", ps.[OrderId],ps.[IsDelete],ps.[Price],si.IsStore,si.Price as Cost"
                + " FROM [dbo].[ProductSetServiceItem] as ps"
                + " Left join ServiceItem as si on si.Id = ps.ItemId"
                + " Where ps.IsDelete = 0 And ps.OrderId='" + orderId + "'";
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgServiceItem.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlCategory")).SelectedValue = dr["IsStore"].ToString();
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((Label)dgServiceItem.Rows[cnt].FindControl("labelCost")).Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbPrice")).Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
                cnt++;
                AddNewRow();
            }
        }

        private void SetProductServiceItem(string setId)
        {
            if (string.IsNullOrEmpty(setId)) return;
            string sql = "SELECT ps.[Id],[SetId],[ItemId],[Number],[UnitId],ps.[CategoryId]"
                + ", ps.[OrderId],ps.[IsDelete],ps.[Price],si.IsStore,si.Price as Cost"
                + " FROM [dbo].[ProductSetServiceItem] as ps"
                + " Left join ServiceItem as si on si.Id = ps.ItemId"
                + " Where ps.IsDelete = 0 And ps.SetId='" + setId + "'";
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgServiceItem.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlCategory")).SelectedValue = dr["IsStore"].ToString() + ";" + cnt;
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString() + ";" + SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00") + ";" + cnt;
                ((Label)dgServiceItem.Rows[cnt].FindControl("labelCost")).Text = SysProperty.Util.ParseMoney(dr["Cost"].ToString()).ToString("#0.00");
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbPrice")).Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
                cnt++;
                AddNewRow();
            }
        }

        private void SetReceiptDetail(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ReceiptDetail Where IsDelete = 0 And OrderId = '" + orderId + "' order by Type, CreatedateTime");
            int cnt = 0;
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (GridView2.Rows.Count == 0)
                    {
                        AddNewRow2();
                    }
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbReceiptId")).Text = dr["Id"].ToString();
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbCategory")).Text = dr["Category"].ToString();
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbIncomeDate")).Text = SysProperty.Util.ParseDateTime("DateTime", dr["PayDate"].ToString());
                    ((DropDownList)GridView2.Rows[cnt].FindControl("ddlCurrency")).SelectedValue = dr["Currency"].ToString();
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbCash")).Text = SysProperty.Util.ParseMoney(dr["Cash"].ToString()).ToString("#0.00");
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbRemit")).Text = SysProperty.Util.ParseMoney(dr["Remit"].ToString()).ToString("#0.00");
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbReceiptDate")).Text = SysProperty.Util.ParseDateTime("DateTime", dr["ReceiptDate"].ToString());
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbReceiptSn")).Text = dr["ReceiptSn"].ToString();
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbTotalPrice")).Text = SysProperty.Util.ParseMoney(dr["TotalPrice"].ToString()).ToString("#0.00");
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbSales")).Text = SysProperty.Util.ParseMoney(dr["SalesPrice"].ToString()).ToString("#0.00");
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbTax")).Text = SysProperty.Util.ParseMoney(dr["Tax"].ToString()).ToString("#0.00");
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbType")).Text = dr["Type"].ToString();
                    GridView2.Rows[cnt].Cells[GridView2.Rows[cnt].Cells.Count - 1].Controls[0].Visible = false;
                    cnt++;
                    AddNewRow2();
                }
            }
            else
            {
                if (GridView2.Rows.Count == 0)
                {
                    AddNewRow2();
                }
                for (cnt = 0; cnt < 2; cnt++)
                {
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbCategory")).Text = (cnt == 0 ? Resources.Resource.DepositString : Resources.Resource.BalanceDueString);
                    ((TextBox)GridView2.Rows[cnt].FindControl("tbType")).Text = cnt.ToString();
                    GridView2.Rows[cnt].Cells[GridView2.Rows[cnt].Cells.Count - 1].Controls[0].Visible = false;
                    AddNewRow2();
                }
            }
        }
        #endregion

        #region Db Instance
        private List<DbSearchObject> OrderInfoDbObject(bool isCreate, string customerId, string partnerId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "Sn"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbCaseSn.Text
                ));
            lst.Add(new DbSearchObject(
                "CustomerId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , customerId
                ));
            lst.Add(new DbSearchObject(
                "PartnerId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , partnerId
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbAppointDate.Text) ? string.Empty : tbAppointDate.Text
                ));
            lst.Add(new DbSearchObject(
                "CloseTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbCloseDay.Text) ? string.Empty : tbCloseDay.Text
                ));
            lst.Add(new DbSearchObject(
                "LocalEngagementDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDomesticEngagementDate.Text) ? string.Empty : tbDomesticEngagementDate.Text
                ));
            lst.Add(new DbSearchObject(
                "LocalMotheringDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDomesticMotheringDate.Text) ? string.Empty : tbDomesticMotheringDate.Text
                ));
            lst.Add(new DbSearchObject(
                "LocalWeddingDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDomesticWeddingDate.Text) ? string.Empty : tbDomesticWeddingDate.Text
                ));
            lst.Add(new DbSearchObject(
                "LocalReceptionDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDomesticWeddReceptionDate.Text) ? string.Empty : tbDomesticWeddReceptionDate.Text
                ));
            lst.Add(new DbSearchObject(
                "LocalFilmingDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDomesticWedFilmDate.Text) ? string.Empty : tbDomesticWedFilmDate.Text
                ));
            lst.Add(new DbSearchObject(
                "OverseaWeddingDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbOverseaWeddingDate.Text) ? string.Empty : tbOverseaWeddingDate.Text
                ));
            lst.Add(new DbSearchObject(
                "OverseaFilmDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbOverSeaWedFilmDate.Text) ? string.Empty : tbOverSeaWedFilmDate.Text
                ));
            lst.Add(new DbSearchObject(
                "TotalPrice"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbTotalPrice.Text
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRemark.Text
                ));
            lst.Add(new DbSearchObject(
                "Referral"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbReferrals.Text
                ));
            lst.Add(new DbSearchObject(
                "Discount"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDiscount.Text
                ));
            lst.Add(new DbSearchObject(
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
            ));
            lst.Add(new DbSearchObject(
                "Price"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbContractPrice.Text
                ));
            if (!string.IsNullOrEmpty(ddlOrderType.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "ServiceType"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlOrderType.SelectedValue
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
                    , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                    ));
            if (!string.IsNullOrEmpty(ddlProductSet.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                    "SetId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , ddlProductSet.SelectedValue
                    ));
            }
            if (!string.IsNullOrEmpty(ddlCountry.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "CountryId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlCountry.SelectedValue
                ));
            }
            if (!string.IsNullOrEmpty(ddlArea.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "AreaId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlArea.SelectedValue
                ));
            }
            if (!string.IsNullOrEmpty(ddlLocate.SelectedValue))
            {
                lst.Add(new DbSearchObject(
                "ChurchId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlLocate.SelectedValue
                ));
            }
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
                "StoreId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["LocateStore"])["Id"].ToString()
                ));
            if (isCreate)
            {
                lst.Add(new DbSearchObject(
                "StartTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
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
        private List<DbSearchObject> CustomerDbObject(bool isCreate)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                        "Name"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalName.Text));
            lst.Add(new DbSearchObject(
                        "EngName"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalPassportName.Text));
            lst.Add(new DbSearchObject(
                        "Addr"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbAddress.Text));
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
                        "Email"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalEmail.Text));
            lst.Add(new DbSearchObject(
                        "MessengerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalMsgerId.Text));
            lst.Add(new DbSearchObject(
                        "Nickname"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbBridalNickname.Text));
            lst.Add(new DbSearchObject(
                        "MsgTitle"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbMsgerTitle.Text));
            lst.Add(new DbSearchObject(
                        "Sn"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbCustomerSn.Text));
            lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString()));
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
        private List<DbSearchObject> PartnerDbObject(bool isCreate)
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
                        , tbGroomPassportName.Text));
            lst.Add(new DbSearchObject(
                        "Bday"
                        , AtrrTypeItem.Date
                        , AttrSymbolItem.Equal
                        , tbGroomBday.Text));
            lst.Add(new DbSearchObject(
                        "MessengerId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomMsgerId.Text));
            lst.Add(new DbSearchObject(
                        "Nickname"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomNickname.Text));
            lst.Add(new DbSearchObject(
                        "Phone"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomPhone.Text));
            lst.Add(new DbSearchObject(
                        "Email"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , tbGroomEmail.Text));
            lst.Add(new DbSearchObject(
                        "UpdateAccId"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , ((DataRow)Session["AccountInfo"])["Id"].ToString()));
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
        private List<List<DbSearchObject>> ServiceItemDbObject(bool isCreate, string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (ViewState["CurrentTable"] != null)
            {
                string str = string.Empty;
                if (dgServiceItem.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in dgServiceItem.Rows)
                    {
                        lst = new List<DbSearchObject>();
                        str = ((DropDownList)dr.Cells[1].FindControl("ddlServiceItem")).SelectedValue;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "ItemId"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str.Split(';')[0]
                            ));
                        str = ((TextBox)dr.Cells[3].FindControl("tbNumber")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Number"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((TextBox)dr.Cells[4].FindControl("tbPrice")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Price"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        lst.Add(new DbSearchObject(
                            "OrderId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , id
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
                        result.Add(lst);
                    }
                }
            }
            return result;
        }
        private List<List<DbSearchObject>> ReceiptDbObject(string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (ViewState["CurrentTable2"] != null)
            {
                string str = string.Empty;
                bool isCreate = false;
                if (GridView2.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in GridView2.Rows)
                    {
                        lst = new List<DbSearchObject>();
                        str = ((TextBox)dr.Cells[0].FindControl("tbReceiptId")).Text;
                        isCreate = string.IsNullOrEmpty(str);
                        str = ((TextBox)dr.Cells[1].FindControl("tbCategory")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Category"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        lst.Add(new DbSearchObject(
                            "OrderId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , id
                            ));
                        lst.Add(new DbSearchObject(
                            "PayDate"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[2].FindControl("tbIncomeDate")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "Currency"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((DropDownList)dr.Cells[3].FindControl("ddlCurrency")).SelectedValue
                            ));
                        lst.Add(new DbSearchObject(
                            "Cash"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[4].FindControl("tbCash")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "Remit"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[5].FindControl("tbRemit")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "ReceiptDate"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[6].FindControl("tbReceiptDate")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "ReceiptSn"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[7].FindControl("tbReceiptSn")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "TotalPrice"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[8].FindControl("tbTotalPrice")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "SalesPrice"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[9].FindControl("tbSales")).Text
                            ));
                        str = ((TextBox)dr.Cells[11].FindControl("tbType")).Text;
                        lst.Add(new DbSearchObject(
                            "Type"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , string.IsNullOrEmpty(str) ? "2" : str
                            ));
                        lst.Add(new DbSearchObject(
                            "Tax"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[10].FindControl("tbTax")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "UpdateAccId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                            ));
                        result.Add(lst);
                        if (isCreate)
                        {
                            lst.Add(new DbSearchObject(
                            "CreatedateAccId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                            ));
                        }
                        else
                        {
                            lst.Add(new DbSearchObject(
                            "Id"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[0].FindControl("tbReceiptId")).Text
                            ));
                        }
                    }
                }
            }
            return result;
        }
        #endregion

        #region DB Control
        private bool WriteBackData(MsSqlTable tableName, bool isInsert, List<DbSearchObject> lst, string condStr)
        {
            try
            {
                return isInsert ?
                    (SysProperty.GenDbCon.InsertDataInToTable(
                    SysProperty.Util.MsSqlTableConverter(tableName)
                    , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                    , SysProperty.Util.SqlQueryInsertValueConverter(lst))) :
                    (SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(tableName)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , condStr));
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

        private string GetCreateId(MsSqlTable tableName, List<DbSearchObject> lst)
        {
            try
            {
                DataSet ds = GetDataFromTable(tableName, SysProperty.Util.SqlQueryConditionConverter(lst));
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

        private DataSet GetDataFromTable(MsSqlTable table, string conStr)
        {
            try
            {
                return SysProperty.GenDbCon.GetDataFromTable("*"
                    , SysProperty.Util.MsSqlTableConverter(table)
                    , conStr);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private bool WriteBackServiceItem(bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            string condStr = " Where OrderId = '" + id + "'";
            if (!isInsert)
            {
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From ProductSetServiceItem " + condStr);
            }
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                result = result | WriteBackData(MsSqlTable.ProductSetServiceItem, true, item, condStr);
            }
            return result;
        }

        private bool WriteBackPartner(bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            string condStr = " Where Id = '" + id + "'";
            if (!isInsert)
            {
                SysProperty.GenDbCon.ModifyDataInToTable("Delete From Partner " + condStr);
            }
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                result = result | WriteBackData(MsSqlTable.Partner, true, item, condStr);
            }
            return result;
        }

        private bool WriteBackCustomer(bool isInsert, List<List<DbSearchObject>> lst, string id)
        {
            string condStr = " Where Id = '" + id + "'";
            bool result = true;
            foreach (List<DbSearchObject> item in lst)
            {
                result = result | WriteBackData(MsSqlTable.Customer, isInsert, item, condStr);
            }
            return result;
        }

        private bool WriteBackReceiptInfo(List<List<DbSearchObject>> lst)
        {
            bool result = true;
            bool isInsert = false;
            string condStr = string.Empty;
            foreach (List<DbSearchObject> item in lst)
            {
                if (item.Exists(x => x.AttrName == "Id"))
                {
                    isInsert = false;
                    condStr = " Where Id = '" + item.Find(x => x.AttrName == "Id").AttrValue + "'";
                }
                else
                {
                    isInsert = true;
                    condStr = string.Empty;
                }
                result = result | WriteBackData(MsSqlTable.ReceiptDetail, isInsert, item, condStr);
            }
            return result;
        }
        #endregion

        #region Service Item Table
        protected void dgBookTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    dgServiceItem.DataSource = dt;
                    dgServiceItem.DataBind();

                    SetPreviousData();
                }
            }
        }

        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Category", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Cost", typeof(string)));
            dr = dt.NewRow();
            dr["Category"] = string.Empty;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Cost"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            dgServiceItem.DataSource = dt;
            dgServiceItem.DataBind();
        }

        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList DdlCategory =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlCategory");
                        DropDownList DdlItem =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        TextBox TextStart =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[3].FindControl("tbNumber");
                        TextBox TextEnd =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[4].FindControl("tbPrice");
                        Label LabelCost =
                          (Label)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("labelCost");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Category"] = DdlCategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextEnd.Text;
                        dtCurrentTable.Rows[i - 1]["Cost"] = LabelCost.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    dgServiceItem.DataSource = dtCurrentTable;
                    dgServiceItem.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DropDownList DdlCategory = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlCategory");
                        DropDownList DdlItem = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        Label LabelCost = (Label)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("labelCost");
                        TextBox TextStart = (TextBox)dgServiceItem.Rows[rowIndex].Cells[3].FindControl("tbNumber");
                        TextBox TextEnd = (TextBox)dgServiceItem.Rows[rowIndex].Cells[4].FindControl("tbPrice");
                        if (TextStart == null) continue;
                        if (TextEnd == null) continue;
                        DdlCategory.SelectedValue = dt.Rows[i]["Category"].ToString();
                        ddlCategory_SelectedIndexChanged(DdlCategory, new EventArgs());
                        DdlItem.SelectedValue = dt.Rows[i]["Col1"].ToString();
                        TextStart.Text = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        TextEnd.Text = dt.Rows[i]["Col3"] == null ? string.Empty : dt.Rows[i]["Col3"].ToString();
                        LabelCost.Text = dt.Rows[i]["Cost"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetRowData()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        DropDownList DdlCategory =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlCategory");
                        DropDownList DdlItem =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        TextBox TextNumber =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[3].FindControl("tbNumber");
                        TextBox TextPrice =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[4].FindControl("tbPrice");
                        Label LabelCost =
                          (Label)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("labelCost");

                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Category"] = DdlCategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextNumber.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextPrice.Text;
                        dtCurrentTable.Rows[i - 1]["Cost"] = LabelCost.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void dgServiceItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable"] = dt;
                    dgServiceItem.DataSource = dt;
                    dgServiceItem.DataBind();

                    SetPreviousData();
                }
            }
        }
        protected void dgServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                SetCategoryControl(e, e.Row.RowIndex);
                SetServiceItemControl(e, e.Row.RowIndex, ((DropDownList)e.Row.FindControl("ddlCategory")).SelectedValue.Split(';')[0]);
                ((Label)e.Row.FindControl("LabelCost")).Text = dataItem1["Cost"].ToString();
            }
        }
        private void SetCategoryControl(GridViewRowEventArgs e, int index)
        {
            DropDownList ddlCategory = null;
            if (e == null)
            {
                ddlCategory = (DropDownList)dgServiceItem.Rows[index].FindControl("ddlCategory");
            }
            else
            {
                ddlCategory = ((DropDownList)e.Row.FindControl("ddlCategory"));
            }
            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem(Resources.Resource.ChurchString, "Church;" + index));
            ddlCategory.Items.Add(new ListItem(Resources.Resource.StoreString, "Store;" + index));
        }

        private void SetServiceItemControl(GridViewRowEventArgs e, int index, string category)
        {
            if (string.IsNullOrEmpty(category)) return;

            DropDownList ddlService = null;

            if (e == null)
            {
                ddlService = (DropDownList)dgServiceItem.Rows[index].FindControl("ddlServiceItem");
            }
            else
            {
                ddlService = ((DropDownList)e.Row.FindControl("ddlServiceItem"));
            }
            ddlService.Items.Clear();
            DataSet ds = null;
            if (category.Trim() == "Store")
            {
                ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsDelete = 0 And IsStore = 1 "
                    + "And StoreId = '" + ((DataRow)Session["LocateStore"])["Id"].ToString() + "'");
            }
            else if (category.Trim() == "Church")
            {
                if (string.IsNullOrEmpty(ddlLocate.SelectedValue)) return;
                ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsStore = 0 And SupplierId = '" + ddlLocate.SelectedValue + "'");
            }

            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            ddlService.Items.Add(new ListItem(Resources.Resource.ServiceItemSelectRemindString, string.Empty));
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ddlService.Items.Add(new ListItem(
                    SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                    , dr["Id"].ToString() + ";" + dr["Price"].ToString() + ";" + index
                    ));
            }
            ddlService.SelectedIndex = 0;

        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] strs = ((DropDownList)sender).SelectedValue.Split(';');
            SetServiceItemControl(null, int.Parse(strs[1]), strs[0]);
            ((Label)dgServiceItem.Rows[int.Parse(strs[1])].FindControl("labelCost")).Text = "0";
            ((TextBox)dgServiceItem.Rows[int.Parse(strs[1])].FindControl("tbNumber")).Text = "0";
            ((TextBox)dgServiceItem.Rows[int.Parse(strs[1])].FindControl("tbPrice")).Text = "0";
        }

        protected void ddlServiceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = ((DropDownList)sender).SelectedValue;
            if (string.IsNullOrEmpty(value) || !value.Contains(";")) return;
            string[] strs = value.Split(';');
            ((Label)dgServiceItem.Rows[int.Parse(strs[2])].FindControl("labelCost")).Text = strs[1];
        }

        protected void tbPrice_TextChanged(object sender, EventArgs e)
        {
            //bool result = false;
            //decimal dec = 0;
            //result = decimal.TryParse(((TextBox)sender).Text, out dec);
            //if (result)
            //{
            //    //tbTotalPrice.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text) + dec).ToString();
            //}
        }
        #endregion                

        private void SetProductInfo(string setId)
        {
            if (string.IsNullOrEmpty(setId))
            {
                tbContractPrice.Text = "0";
            }
            else
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSet Where IsDelete = 0 And Id='" + setId + "'");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                tbContractPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                tbTotalPrice.Text = ds.Tables[0].Rows[0]["Price"].ToString();
                ddlArea.SelectedValue = ds.Tables[0].Rows[0]["AreaId"].ToString();
                ddlLocate.SelectedValue = ds.Tables[0].Rows[0]["ChurchId"].ToString();
                ddlCountry.SelectedValue = ds.Tables[0].Rows[0]["CountryId"].ToString();
                ddlOrderType.SelectedValue = ds.Tables[0].Rows[0]["Category"].ToString();
            }
        }

        #region Price related TextBox Event
        protected void tbDiscount_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbTotalPrice.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text) - dec).ToString();
            }
        }

        protected void tbContractPrice_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbTotalPrice.Text = (dec).ToString();
            }
        }
        #endregion

        #region Photo
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderPath.Text)) return;
            CheckFolder(tbFolderPath.Text);
            ImgUpload.PostedFile.SaveAs(tbFolderPath.Text + "\\" + tbCaseSn.Text + "_1.jpg");
            RefreshImage(tbFolderPath.Text);
        }

        private void RefreshImage(string path)
        {
            ImgFront.ImageUrl = "http:" + path + "\\" + tbCaseSn.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
        }

        private void CheckFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        #endregion

        #region Document Export
        private void CreateContrctDoc(string sn
            , string bridalName, string bridalEmail, string bridalPhone
            , string groomName, string groomEmail, string groomPhone
            , string ServiceName, string setName, string totalPrice, string price, string expectDate)
        {
            string otherPrice = (SysProperty.Util.ParseMoney(totalPrice) - SysProperty.Util.ParseMoney(price)).ToString("#0.00");
            string filePath = new ContractDoc().CreateContractDoc(sn
                , bridalName, bridalEmail, bridalPhone
                , groomName, groomEmail, groomPhone
                , ServiceName, setName, otherPrice, price, expectDate);
            Uri uri = new Uri(filePath); // Here I get the error
            string fName = Path.GetFullPath(uri.LocalPath);
            FileInfo fileInfo = new FileInfo(fName);
            if (fileInfo.Exists)
            {
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();

                Response.Buffer = true;
                Response.ContentType = "application/application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                //Response.ContentType = "application/Octet-stream";
                Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                Response.Charset = "UTF-8";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.WriteFile(filePath);
                Response.End();

            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            CreateContrctDoc(tbCaseSn.Text
                , tbBridalName.Text, tbBridalEmail.Text, tbBridalPhone.Text
                , tbGroomName.Text, tbGroomEmail.Text, tbGroomPhone.Text
                , ddlOrderType.SelectedItem.Text, ddlProductSet.SelectedItem.Text, tbTotalPrice.Text, tbTotalPrice.Text, GetExpectDate());
        }

        private string GetExpectDate()
        {
            string time;
            switch (ddlOrderType.SelectedIndex)
            {
                case 0:
                    time = SysProperty.Util.ParseDateTime("Date", tbOverseaWeddingDate.Text);
                    break;
                case 1:
                    time = SysProperty.Util.ParseDateTime("Date", tbDomesticWeddingDate.Text);
                    break;
                case 2:
                    time = SysProperty.Util.ParseDateTime("Date", tbOverseaWeddingDate.Text);
                    break;
                case 3:
                    time = SysProperty.Util.ParseDateTime("Date", tbDomesticWedFilmDate.Text);
                    break;
                case 4:
                    time = SysProperty.Util.ParseDateTime("Date", tbOverSeaWedFilmDate.Text);
                    break;
                default:
                    return DateTime.Now.ToString("dd/MM/yyyy");
            }
            if (string.IsNullOrEmpty(time)) return time;

            DateTime tmp;
            bool result = DateTime.TryParse(time, out tmp);
            if (result) return tmp.ToString("dd/MM/yyyy");
            else return string.Empty;
        }
        #endregion

        #region Receipt Table
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                if (Session["CultureCode"] == null) return;
                string cultureCode = Session["CultureCode"].ToString();
                DropDownList ddlCurrency = (DropDownList)e.Row.FindControl("ddlCurrency");
                ddlCurrency.Items.Clear();
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From Currency Where IsDelete = 0");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlCurrency.Items.Add(new ListItem(
                        dr["Name"].ToString()
                        , dr["Id"].ToString()
                        ));
                }
                if (string.IsNullOrEmpty(dataItem1["Col3"].ToString()))
                {
                    ddlCurrency.SelectedValue = ((DataRow)Session["LocateStore"])["Currency"].ToString();
                }

                if (!string.IsNullOrEmpty(dataItem1["Id"].ToString()))
                {
                    e.Row.Cells[e.Row.Cells.Count - 1].Controls[0].Visible = false;
                }

            }
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData2();
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    GridView2.DataSource = dt;
                    GridView2.DataBind();

                    SetPreviousData2();
                }
            }
        }

        protected void btnAddRow2_Click(object sender, EventArgs e)
        {
            AddNewRow2();
        }

        private void FirstGridViewRow2()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            for (int i = 1; i <= 11; i++)
            {
                dt.Columns.Add(new DataColumn("Col" + i, typeof(string)));
            }
            dr = dt.NewRow();
            dr["Id"] = string.Empty;
            for (int i = 1; i <= 11; i++)
            {
                dr["Col" + i] = string.Empty;
            }
            dt.Rows.Add(dr);

            ViewState["CurrentTable2"] = dt;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }

        private void AddNewRow2()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextReceiptId = (TextBox)GridView2.Rows[rowIndex].Cells[0].FindControl("tbReceiptId");
                        TextBox TextCategory = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("tbCategory");
                        TextBox TextDate = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("tbIncomeDate");
                        DropDownList DdlItem = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("ddlCurrency");
                        TextBox TextCash = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("tbCash");
                        TextBox TextRemit = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("tbRemit");
                        TextBox TextReceiptDate = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("tbReceiptDate");
                        TextBox TextReceiptSn = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("tbReceiptSn");
                        TextBox TextTotalPrice = (TextBox)GridView2.Rows[rowIndex].Cells[8].FindControl("tbTotalPrice");
                        TextBox TextSales = (TextBox)GridView2.Rows[rowIndex].Cells[9].FindControl("tbSales");
                        TextBox TextTax = (TextBox)GridView2.Rows[rowIndex].Cells[10].FindControl("tbTax");
                        TextBox TextType = (TextBox)GridView2.Rows[rowIndex].Cells[11].FindControl("tbType");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Id"] = TextReceiptId.Text;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextDate.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextCash.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = TextRemit.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = TextReceiptDate.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = TextReceiptSn.Text;
                        dtCurrentTable.Rows[i - 1]["Col8"] = TextTotalPrice.Text;
                        dtCurrentTable.Rows[i - 1]["Col9"] = TextSales.Text;
                        dtCurrentTable.Rows[i - 1]["Col10"] = TextTax.Text;
                        dtCurrentTable.Rows[i - 1]["Col11"] = TextType.Text;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable2"] = dtCurrentTable;

                    GridView2.DataSource = dtCurrentTable;
                    GridView2.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData2();
        }

        private void SetPreviousData2()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox TextReceiptId = (TextBox)GridView2.Rows[rowIndex].Cells[0].FindControl("tbReceiptId");
                        TextBox TextCategory = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("tbCategory");
                        TextBox TextDate = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("tbIncomeDate");
                        DropDownList DdlItem = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("ddlCurrency");
                        TextBox TextCash = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("tbCash");
                        TextBox TextRemit = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("tbRemit");
                        TextBox TextReceiptDate = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("tbReceiptDate");
                        TextBox TextReceiptSn = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("tbReceiptSn");
                        TextBox TextTotalPrice = (TextBox)GridView2.Rows[rowIndex].Cells[8].FindControl("tbTotalPrice");
                        TextBox TextSales = (TextBox)GridView2.Rows[rowIndex].Cells[9].FindControl("tbSales");
                        TextBox TextTax = (TextBox)GridView2.Rows[rowIndex].Cells[10].FindControl("tbTax");
                        TextBox TextType = (TextBox)GridView2.Rows[rowIndex].Cells[11].FindControl("tbType");

                        TextReceiptId.Text = dt.Rows[i]["Id"] == null ? string.Empty : dt.Rows[i]["Id"].ToString();
                        TextCategory.Text = dt.Rows[i]["Col1"] == null ? string.Empty : dt.Rows[i]["Col1"].ToString();
                        TextDate.Text = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        DdlItem.SelectedValue = dt.Rows[i]["Col3"].ToString();
                        TextCash.Text = dt.Rows[i]["Col4"] == null ? string.Empty : dt.Rows[i]["Col4"].ToString();
                        TextRemit.Text = dt.Rows[i]["Col5"] == null ? string.Empty : dt.Rows[i]["Col5"].ToString();
                        TextReceiptDate.Text = dt.Rows[i]["Col6"] == null ? string.Empty : dt.Rows[i]["Col6"].ToString();
                        TextReceiptSn.Text = dt.Rows[i]["Col7"] == null ? string.Empty : dt.Rows[i]["Col7"].ToString();
                        TextTotalPrice.Text = dt.Rows[i]["Col8"] == null ? string.Empty : dt.Rows[i]["Col8"].ToString();
                        TextSales.Text = dt.Rows[i]["Col9"] == null ? string.Empty : dt.Rows[i]["Col9"].ToString();
                        TextTax.Text = dt.Rows[i]["Col10"] == null ? string.Empty : dt.Rows[i]["Col10"].ToString();
                        TextType.Text = dt.Rows[i]["Col11"] == null ? string.Empty : dt.Rows[i]["Col11"].ToString();
                        rowIndex++;
                    }
                }
            }
        }
        private void SetRowData2()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox TextReceiptId = (TextBox)GridView2.Rows[rowIndex].Cells[0].FindControl("tbReceiptId");
                        TextBox TextCategory = (TextBox)GridView2.Rows[rowIndex].Cells[1].FindControl("tbCategory");
                        TextBox TextDate = (TextBox)GridView2.Rows[rowIndex].Cells[2].FindControl("tbIncomeDate");
                        DropDownList DdlItem = (DropDownList)GridView2.Rows[rowIndex].Cells[3].FindControl("ddlCurrency");
                        TextBox TextCash = (TextBox)GridView2.Rows[rowIndex].Cells[4].FindControl("tbCash");
                        TextBox TextRemit = (TextBox)GridView2.Rows[rowIndex].Cells[5].FindControl("tbRemit");
                        TextBox TextReceiptDate = (TextBox)GridView2.Rows[rowIndex].Cells[6].FindControl("tbReceiptDate");
                        TextBox TextReceiptSn = (TextBox)GridView2.Rows[rowIndex].Cells[7].FindControl("tbReceiptSn");
                        TextBox TextTotalPrice = (TextBox)GridView2.Rows[rowIndex].Cells[8].FindControl("tbTotalPrice");
                        TextBox TextSales = (TextBox)GridView2.Rows[rowIndex].Cells[9].FindControl("tbSales");
                        TextBox TextTax = (TextBox)GridView2.Rows[rowIndex].Cells[10].FindControl("tbTax");
                        TextBox TextType = (TextBox)GridView2.Rows[rowIndex].Cells[11].FindControl("tbType");

                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Id"] = TextReceiptId.Text;
                        dtCurrentTable.Rows[i - 1]["Col1"] = TextCategory.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextDate.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col4"] = TextCash.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = TextRemit.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = TextReceiptDate.Text;
                        dtCurrentTable.Rows[i - 1]["Col7"] = TextReceiptSn.Text;
                        dtCurrentTable.Rows[i - 1]["Col8"] = TextTotalPrice.Text;
                        dtCurrentTable.Rows[i - 1]["Col9"] = TextSales.Text;
                        dtCurrentTable.Rows[i - 1]["Col10"] = TextTax.Text;
                        dtCurrentTable.Rows[i - 1]["Col11"] = TextType.Text;
                        rowIndex++;
                    }

                    ViewState["CurrentTable2"] = dtCurrentTable;
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
        }

        #endregion        
    }
}