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
    public partial class CaseMCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    InitialControl();
                    FirstGridViewRow();
                    if (Session["OrderId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        btnDelete.Visible = true;
                        SetOrderData(Session["OrderId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.OrderMgtString
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
            Server.Transfer("CaseMaintain.aspx", true);
            Session.Remove("OrderId");
            if (Session["CustomerId"] != null) Session.Remove("CustomerId");
            if (Session["PartnerId"] != null) Session.Remove("PartnerId");
            ViewState.Remove("CurrentTable");
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

                string sql = "Select * From ProductSet Where IsDelete = 0 " + condStr;
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
                string sql = "SELECT * FROM [TheWe].[dbo].[ServiceItemCategory] Where TypeLv=0 order by Type";
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable(sql);
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlOrderType.Items.Add(new ListItem(
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

        private void SetStatusList()
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
                ddlStatus.SelectedIndex = 1;
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
            SetAreaList(ddlCountry.SelectedValue);
            SetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetChurchList(ddlCountry.SelectedValue, ddlArea.SelectedValue);
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlLocate_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetProductSetList(ddlCountry.SelectedValue, ddlArea.SelectedValue, ddlLocate.SelectedValue, ddlOrderType.SelectedValue);
            FirstGridViewRow();
        }

        protected void ddlOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                tbCloseDay.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
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
            TransferToOtherPage();
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
            tbDeposit1.Text = string.Empty;
            tbDeposit1Date.Text = string.Empty;
            tbDeposit2.Text = string.Empty;
            tbDeposit2Date.Text = string.Empty;
            tbDiscount.Text = string.Empty;
            tbGroomBday.Text = string.Empty;
            tbGroomName.Text = string.Empty;
            tbGroomNickname.Text = string.Empty;
            tbGroomPassportName.Text = string.Empty;
            tbBridalMsgerId.Text = string.Empty;
            tbMsgerTitle.Text = string.Empty;
            tbPayOff.Text = string.Empty;
            tbPayOffDate.Text = string.Empty;
            tbPhone.Text = string.Empty;
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
            if (SysProperty.GenDbCon.IsSnDuplicate(SysProperty.Util.MsSqlTableConverter(MsSqlTable.OrderInfo), tbCaseSn.Text))
            {
                ShowErrorMsg(Resources.Resource.SnDuplicateErrorString);
                return;
            }
            if (Session["CustomerId"] != null) return;
            string customerId = Session["CustomerId"].ToString();
            List<DbSearchObject> partnerInfo = PartnerDbObject();
            bool result = WriteBackData(MsSqlTable.Partner, true, partnerInfo, string.Empty);
            if (!result) return;
            string partnerId = GetCreateId(MsSqlTable.vwEN_Partner, partnerInfo);
            if (string.IsNullOrEmpty(partnerId)) return;
            List<DbSearchObject> lst = OrderInfoDbObject(customerId, partnerId);
            result = WriteBackData(MsSqlTable.OrderInfo, true, lst, string.Empty);
            if (!result) return;
            string id = GetCreateId(MsSqlTable.OrderInfo, lst);
            if (string.IsNullOrEmpty(id)) return;
            result = WriteBackData(MsSqlTable.Customer, false, CustomerDbObject(), " Where Id='" + customerId + "'");
            if (!result) return;
            result = WriteBackServiceItem(true, ServiceItemDbObject(id), id);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            if (Session["OrderId"] == null || Session["CustomerId"] == null || Session["PartnerId"] == null) return;
            string id = Session["OrderId"].ToString();
            string partnerId = Session["PartnerId"].ToString();
            string customerId = Session["CustomerId"].ToString();
            if (string.IsNullOrEmpty(id)) return;
            bool result = WriteBackData(MsSqlTable.OrderInfo, false, OrderInfoDbObject(customerId, partnerId), " Where Id='" + id + "'");
            if (!result) return;
            result = WriteBackData(MsSqlTable.Customer, false, CustomerDbObject(), " Where Id='" + customerId + "'");
            if (!result) return;
            result = WriteBackData(MsSqlTable.Partner, false, PartnerDbObject(), " Where Id='" + partnerId + "'");
            if (!result) return;
            result = WriteBackServiceItem(false, ServiceItemDbObject(id), id);
            if (result)
            {
                TransferToOtherPage();
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

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
                    + ",[CurrencyId],[DepositFirst],[HotelName],[CustomerImg]"
                    + ",o.[BookingDate],[OverseaWeddingDate],[DepositFirstDate]"
                    + ",[DepositSecondDate],[DepositSecond],[OverseaFilmDate]"
                    + ",[LocalFilmingDate],[LocalEngagementDate],[LocalWeddingDate]"
                    + ",[LocalMotheringDate],[LocalReceptionDate],[BalancePayementDate]"
                    + ",o.[ServiceType],o.[IsDelete],o.[UpdateAccId],o.[UpdateTime],o.[ServiceType]"
                    + ",[WeddingRecord],[DynamicRecord],[BridalSecretary],[WeddingPerform],[WeddingType]"
                    + ",[WeddingDecorate],[WeddingHost],[TotalPrice],[Discount],o.[Remark],[Referral]"
                    + " FROM[TheWe].[dbo].[OrderInfo] as o"
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
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;

            DataRow dr = ds.Tables[0].Rows[0];
            Session["CustomerId"] = dr["CustomerId"].ToString();
            Session["PartnerId"] = dr["PartnerId"].ToString();
            InitialCustomerInfo(dr["CustomerId"].ToString());
            InitialPartnerInfo(dr["PartnerId"].ToString());

            tbAdvisorySn.Text = dr["ConsultSn"].ToString();
            tbAppointDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
            tbCaseSn.Text = dr["Sn"].ToString();
            tbCloseDay.Text = SysProperty.Util.ParseDateTime("DateTime", dr["CloseTime"].ToString());
            tbContractPrice.Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
            tbContractTime.Text = SysProperty.Util.ParseDateTime("DateTime", dr["StartTime"].ToString());
            tbDeposit1.Text = SysProperty.Util.ParseMoney(dr["DepositFirst"].ToString()).ToString("#0.00");
            tbDeposit1Date.Text = SysProperty.Util.ParseDateTime("DateTime", dr["DepositFirstDate"].ToString());
            tbDeposit2.Text = SysProperty.Util.ParseMoney(dr["DepositSecond"].ToString()).ToString("#0.00");
            tbDeposit2Date.Text = SysProperty.Util.ParseDateTime("DateTime", dr["DepositSecondDate"].ToString());
            tbDiscount.Text = SysProperty.Util.ParseMoney(dr["Discount"].ToString()).ToString("#0.00");
            tbDomesticEngagementDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalEngagementDate"].ToString());
            tbDomesticMotheringDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalMotheringDate"].ToString());
            tbDomesticWeddingDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalWeddingDate"].ToString());
            tbDomesticWeddReceptionDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalReceptionDate"].ToString());
            tbDomesticWedFilmDate.Text = SysProperty.Util.ParseDateTime("Date", dr["LocalFilmingDate"].ToString());
            tbOverseaWeddingDate.Text = SysProperty.Util.ParseDateTime("Date", dr["OverseaWeddingDate"].ToString());
            tbOverSeaWedFilmDate.Text = SysProperty.Util.ParseDateTime("Date", dr["OverseaFilmDate"].ToString());
            tbPayOffDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BalancePayementDate"].ToString());
            tbReferrals.Text = dr["Referral"].ToString();
            tbRemark.Text = dr["Remark"].ToString();
            tbTotalPrice.Text = string.IsNullOrEmpty(dr["TotalPrice"].ToString()) 
                ? tbContractPrice.Text 
                : SysProperty.Util.ParseMoney(dr["TotalPrice"].ToString()).ToString("#0.00");

            tbPayOff.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text) - (
                SysProperty.Util.ParseMoney(tbDiscount.Text)
                + SysProperty.Util.ParseMoney(tbDeposit1.Text)
                + SysProperty.Util.ParseMoney(tbDeposit2.Text)
                )).ToString("#0.00");

            ddlStatus.SelectedValue = dr["StatusId"].ToString();
            ddlProductSet.SelectedValue = dr["SetId"].ToString();
            ddlOrderType.SelectedValue = dr["ServiceType"].ToString();
            ddlCountry.SelectedValue = dr["CountryId"].ToString();
            ddlArea.SelectedValue = dr["AreaId"].ToString();
            ddlLocate.SelectedValue = dr["ChurchId"].ToString();
            
            SetOrderServiceItem(id);
        }

        private void InitialCustomerInfo(string id)
        {
            DataSet ds = GetDataFromTable(MsSqlTable.vwEN_Customer, " Where IsDelete = 0 And Id = '" + id + "'");
            if (!SysProperty.Util.IsDataSetEmpty(ds))
            {
                DataRow dr = ds.Tables[0].Rows[0];
                tbBridalName.Text = dr["Name"].ToString();
                tbBridalMsgerId.Text = dr["MessengerId"].ToString();
                tbBridalBday.Text = dr["Bday"].ToString();
                tbBridalNickname.Text = dr["Nickname"].ToString();
                tbBridalPassportName.Text = dr["EngName"].ToString();
                ddlBridalMsgerType.SelectedValue = dr["MessengerType"].ToString();
                tbPhone.Text = dr["Phone"].ToString();
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
                tbGroomMsgerId.Text = dr["MessengerId"].ToString();
                tbGroomBday.Text = dr["Bday"].ToString();
                tbGroomNickname.Text = dr["Nickname"].ToString();
                tbGroomPassportName.Text = dr["EngName"].ToString();
                ddlGroomMsgerType.SelectedValue = dr["MessengerType"].ToString();                
            }
        }

        private void SetOrderServiceItem(string orderId)
        {
            if (string.IsNullOrEmpty(orderId)) return;
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSetServiceItem Where IsDelete = 0 And OrderId='" + orderId + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgServiceItem.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbPrice")).Text = SysProperty.Util.ParseMoney(dr["Price"].ToString()).ToString("#0.00");
                cnt++;
                AddNewRow();
            }
        }

        private void SetProductServiceItem(string setId)
        {
            if (string.IsNullOrEmpty(setId)) return;
            DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ProductSetServiceItem Where IsDelete = 0 And SetId='" + setId + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int cnt = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgServiceItem.Rows.Count == 0)
                {
                    AddNewRow();
                }
                ((DropDownList)dgServiceItem.Rows[cnt].FindControl("ddlServiceItem")).SelectedValue = dr["ItemId"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbNumber")).Text = dr["Number"].ToString();
                ((TextBox)dgServiceItem.Rows[cnt].FindControl("tbPrice")).Text = "0";
                cnt++;
                AddNewRow();
            }
        }
        #endregion

        #region Db Instance
        private List<DbSearchObject> OrderInfoDbObject(string customerId, string partnerId)
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
                "DepositFirstDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDeposit1Date.Text) ? string.Empty : tbDeposit1Date.Text
                ));
            lst.Add(new DbSearchObject(
                "DepositSecondDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbDeposit2Date.Text) ? string.Empty : tbDeposit2Date.Text
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
                "BalancePayementDate"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , string.IsNullOrEmpty(tbPayOffDate.Text) ? string.Empty : tbPayOffDate.Text
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
                "DepositSecond"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDeposit2.Text
            ));
            lst.Add(new DbSearchObject(
                "DepositFirst"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDeposit1.Text
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
            return lst;
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
                        , tbPhone.Text));
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
        private List<List<DbSearchObject>> ServiceItemDbObject(string id)
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
                        str = ((DropDownList)dr.Cells[0].FindControl("ddlServiceItem")).SelectedValue;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "ItemId"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((TextBox)dr.Cells[1].FindControl("tbNumber")).Text;
                        if (string.IsNullOrEmpty(str)) continue;
                        lst.Add(new DbSearchObject(
                            "Number"
                            , AtrrTypeItem.Date
                            , AttrSymbolItem.Equal
                            , str
                            ));
                        str = ((TextBox)dr.Cells[2].FindControl("tbPrice")).Text;
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
                        result.Add(lst);
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
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dr = dt.NewRow();
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
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
                        DropDownList DdlItem =
                            (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd =
                          (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextStart.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextEnd.Text;
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
                        DropDownList DdlItem = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextStart = (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextEnd = (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
                        if (TextStart == null) continue;
                        if (TextEnd == null) continue;
                        DdlItem.SelectedValue = dt.Rows[i]["Col1"].ToString();
                        TextStart.Text = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        TextEnd.Text = dt.Rows[i]["Col3"] == null ? string.Empty : dt.Rows[i]["Col3"].ToString();
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
                        DropDownList DdlItem = (DropDownList)dgServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem");
                        TextBox TextNumber = (TextBox)dgServiceItem.Rows[rowIndex].Cells[1].FindControl("tbNumber");
                        TextBox TextPrice = (TextBox)dgServiceItem.Rows[rowIndex].Cells[2].FindControl("tbPrice");
                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = TextNumber.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = TextPrice.Text;
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
                if (Session["CultureCode"] == null) return;
                string cultureCode = Session["CultureCode"].ToString();
                DropDownList ddlService = (DropDownList)e.Row.FindControl("ddlServiceItem");
                ddlService.Items.Add(new ListItem(Resources.Resource.ServiceItemSelectRemindString, string.Empty));
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsDelete = 0 And IsGeneral = 1");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(cultureCode, dr)
                        , dr["Id"].ToString()
                        ));
                }
                if (string.IsNullOrEmpty(ddlLocate.SelectedValue)) return;
                ds = SysProperty.GenDbCon.GetDataFromTable("Select * From ServiceItem Where IsGeneral = 0 And SupplierId = '" + ddlLocate.SelectedValue + "'");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(cultureCode, dr)
                        , dr["Id"].ToString()
                        ));
                }
                ddlService.SelectedIndex = 0;
            }
        }
        protected void tbPrice_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbTotalPrice.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text) + dec).ToString();
            }
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

        protected void tbDeposit1_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbPayOff.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text)
                    - (dec + SysProperty.Util.ParseMoney(tbDeposit2.Text)))
                    .ToString();
                tbDeposit1Date.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }

        protected void tbTotalPrice_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbPayOff.Text = (dec
                    - (SysProperty.Util.ParseMoney(tbDeposit1.Text) + SysProperty.Util.ParseMoney(tbDeposit2.Text)))
                    .ToString();
            }
        }

        protected void tbDeposit2_TextChanged(object sender, EventArgs e)
        {
            bool result = false;
            decimal dec = 0;
            result = decimal.TryParse(((TextBox)sender).Text, out dec);
            if (result)
            {
                tbPayOff.Text = (SysProperty.Util.ParseMoney(tbTotalPrice.Text)
                    - (dec + SysProperty.Util.ParseMoney(tbDeposit1.Text)))
                    .ToString();
                tbDeposit2Date.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
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
    }
}