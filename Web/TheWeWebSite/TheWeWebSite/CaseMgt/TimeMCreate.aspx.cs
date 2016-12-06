using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using TheWeLib;
using TheWeWebSite.Output;

namespace TheWeWebSite.CaseMgt
{
    public partial class TimeMCreate : System.Web.UI.Page
    {
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
                    SysProperty.DataSetSortType = true;
                    InitialPage();                 
                    FirstGridViewRow_dgCutomServiceItem();
                    FirstGridViewRow2();
                    if (Session["OrderId"] != null)
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.TimetableMaintainString
                        + " > " + Resources.Resource.ModifyString;
                        btnModify.Visible = true;
                        InitialConferenceItem();
                        SetOrderInfo(Session["OrderId"].ToString());
                    }
                    else
                    {
                        labelPageTitle.Text = Resources.Resource.OrderMgtString
                        + " > " + Resources.Resource.TimetableMaintainString
                        + " > " + Resources.Resource.CreateString;
                        btnModify.Visible = false;
                    }
                    InitialControlWithPermission();
                }
            }
        }

        #region Page initialize
        private void InitialPage()
        {
            WPProductSet();
            InitialPastorLanguage();
            InitialConferenceItem();
            InitialLangList();
            InitialOrderType();
            InitialTextAndHint();
        }
        private void InitialTextAndHint()
        {
            InitiallblText();
            InitialtbPlaceHolder();
            Div();
        }
        private void InitialPastorLanguage()
        {
            ddlLangPastor.Items.Add(new ListItem(Resources.Resource.LanguageSelectionReminderString, string.Empty));
            ddlLangPastor.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "1"));
            ddlLangPastor.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "2"));
            ddlLangPastor.Items.Add(new ListItem(Resources.Resource.EnglishString, "0"));
            ddlLangPastor.Items.Add(new ListItem(Resources.Resource.JapaneseString, "3"));
        }        
        private void InitiallblText()
        {
            //1-1
            lblHotelName.Text = Resources.Resource.HotelString + "1" + Resources.Resource.NameString;
            lblHotelOthName.Text = Resources.Resource.HotelString + "1" + Resources.Resource.OtherNameString;
            lblHotelAddr.Text = Resources.Resource.HotelString + "1" + Resources.Resource.AddressString;
            lblHotelName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.NameString;
            lblHotelOthName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.OtherNameString;
            lblHotelAddr2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.AddressString;
            lblTravelPeriod.Text = Resources.Resource.TravelPeriodString;
            lblStayNight.Text = Resources.Resource.StayNightString;
            lblFlight.Text = Resources.Resource.FlightInfoString;
            lblContact.Text = Resources.Resource.ContactString;


            //1-2
            //lblWeddingStyle.Text = Resources.Resource.WeddingStyleString;
            cbLegalWedding.Text = Resources.Resource.LegalWeddingString;
            lblPastorLanguage.Text = Resources.Resource.PastorString + Resources.Resource.LanguageString;
            lblWelcomeCard.Text = Resources.Resource.WelcomeCardString;
            lblBouquetCorsage.Text = Resources.Resource.BouquetPictureString;
            lblChampagne.Text = Resources.Resource.ChampagneString;
            lblGuest.Text = Resources.Resource.GuestString;
            lblWeddingSequence.Text = Resources.Resource.WeddingSequenceString;
            lblChurchArrangements.Text = Resources.Resource.ChurchArrangementsString;
            lblWSp.Text = Resources.Resource.AdditionServiceString;

            //1-3
            lblRoutePlan.Text = Resources.Resource.RoutePlanString;
            lblPhotoItem.Text = Resources.Resource.PhotoItemString;
            lblPhotoBouquet.Text = Resources.Resource.PhotoBouquetString;
            lblPhotoAvoid.Text = Resources.Resource.PhotoAvoidString;
            lblPSp.Text = Resources.Resource.PhotoSpecialClaimString;
            lblAttractions.Text = Resources.Resource.AttractionsString;


            //1-4
            /*
            lblBridalDress1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString;
            lblBridalDress2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString;
            lblBridalDress3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString;
            lblBridalDress4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString;
            lblBridalDress5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString;
            lblBridalDress6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString;
            */
            lblGroomDressNum.Text = Resources.Resource.GroomString + Resources.Resource.SuitString + Resources.Resource.NumberString;
            lblGroomSpecialClaim.Text = Resources.Resource.GroomString + Resources.Resource.SuitString + Resources.Resource.SpecialClaimString;
            lblBridalSpecialClaim.Text = Resources.Resource.BridalString + Resources.Resource.DressString + Resources.Resource.SpecialClaimString;
            //1-5
            lblSitePlan.Text = Resources.Resource.SitePlanString;
            lblDinnerContent.Text = Resources.Resource.BanquetContentString;
            lblFood.Text = Resources.Resource.FoodString;
            lblDinnerGuest.Text = Resources.Resource.BanquetPeopleString;
            lblBSp.Text = Resources.Resource.AdditionServiceString;


            //2-1
            lblBridalTryDress1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString;
            lblBridalTryDress2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString;
            lblBridalTryDress3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString;
            lblBridalTryDress4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString;
            lblBridalTryDress5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString;
            lblBridalTryDress6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString;

            //2-2
            lblBridalModeling.Text = Resources.Resource.BridalString + Resources.Resource.ModelingString;
            lblBridalMakeupEmphasis.Text = Resources.Resource.BridalString + Resources.Resource.MakeupEmphasisString;
            lblBridalHair1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.HairString;
            lblBridalHair2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.HairString;
            lblBridalHair3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.HairString;
            lblBridalHair4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.HairString;
            lblBridalHair5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.HairString;
            lblBridalHair6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.HairString;
            lblBridalHairSpecailClaim.Text = Resources.Resource.BridalString + Resources.Resource.HairString + Resources.Resource.SpecialClaimString;
            lblGroomHair.Text = Resources.Resource.GroomString + Resources.Resource.HairString;
            lblGroomHairSpecailClaim.Text = Resources.Resource.GroomString + Resources.Resource.HairString + Resources.Resource.SpecialClaimString;

            //3-1
            lblBridalCheckDress1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.SizeCheckString;
            lblBridalCheckDress2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.SizeCheckString;
            lblBridalCheckDress3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.SizeCheckString;
            lblBridalCheckDress4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.SizeCheckString;
            lblBridalCheckDress5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.SizeCheckString;
            lblBridalCheckDress6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.SizeCheckString;


            //3-3
            lblGetDress.Text = Resources.Resource.GetDressString;
            //lblDeposit.Text = Resources.Resource.DepositString + Resources.Resource.PaymentString;
            //lblBalanceDue.Text = Resources.Resource.BalanceDueString + Resources.Resource.PaymentString;

            //Oth
            lblOth.Text = Resources.Resource.RemarkString;

        }
        private void InitialtbPlaceHolder()
        {
            tbOsp.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SpecialClaimString);

            //1-1
            tbHotelName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.NameString);
            tbHotelOthName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.OtherNameString);
            tbHotelAddr.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.AddressString);
            tbHotelName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.NameString);
            tbHotelOthName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.OtherNameString);
            tbHotelAddr2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.AddressString);
            tbTravelPeriod.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.TravelPeriodString);
            tbStayNight.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.StayNightString);
            tbContact.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ContactString);
            tbFlight.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.FlightInfoString);


            //1-2
            //tbWeddingStyle.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WeddingStyleString);
            tbWelcomeCard.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WelcomeCardString);
            tbBouquetCorsage.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BouquetPictureString);
            tbChampagne.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ChampagneString);
            tbGuest.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GuestString);
            tbWeddingSequence.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WeddingSequenceString);
            tbChurchArrangements.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ChurchArrangementsString);
            tbWSp.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AdditionServiceString);

            //1-3
            tbPSp.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoSpecialClaimString);
            tbAttractions.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AttractionsString);
            tbRoutePlan.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RoutePlanString);
            tbPhotoItem.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoItemString);
            tbPhotoBouquet.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoBouquetString);
            tbPhotoAvoid.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoAvoidString);

            //1-4
            /*
            tbBridalDress1.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString);
            tbBridalDress2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString);
            tbBridalDress3.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString);
            tbBridalDress4.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString);
            tbBridalDress5.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString);
            tbBridalDress6.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString);
            */
            tbBridalSpecialClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.DressString + Resources.Resource.SpecialClaimString);
            tbGroomDressNum.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GroomString + Resources.Resource.SuitString + Resources.Resource.NumberString);
            tbGroomSpecialClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GroomString + Resources.Resource.SuitString + Resources.Resource.SpecialClaimString);

            //1-5
            tbSitePlan.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.SitePlanString);
            tbDinnerContent.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BanquetContentString);
            tbFood.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.FoodString);
            tbDinnerGuest.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BanquetPeopleString);
            tbBSp.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AdditionServiceString);


            //2-1
            tbBridalTryDress1.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString);
            tbBridalTryDress2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString);
            tbBridalTryDress3.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString);
            tbBridalTryDress4.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString);
            tbBridalTryDress5.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString);
            tbBridalTryDress6.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString);

            //2-2
            tbBridalModeling.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.ModelingString);
            tbBridalMakeupEmphasis.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.MakeupEmphasisString);
            tbBridalHair1.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.HairString);
            tbBridalHair2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.HairString);
            tbBridalHair3.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.HairString);
            tbBridalHair4.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.HairString);
            tbBridalHair5.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.HairString);
            tbBridalHair6.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.HairString);
            tbBridalHairSpecailClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.HairString + Resources.Resource.SpecialClaimString);
            tbGroomHair.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GroomString + Resources.Resource.HairString);
            tbGroomHairSpecailClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GroomString + Resources.Resource.HairString + Resources.Resource.SpecialClaimString);

            //3-1
            tbBridalCheckDress1.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.SizeCheckString);
            tbBridalCheckDress2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.SizeCheckString);
            tbBridalCheckDress3.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.SizeCheckString);
            tbBridalCheckDress4.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.SizeCheckString);
            tbBridalCheckDress5.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.SizeCheckString);
            tbBridalCheckDress6.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.SizeCheckString);


            //3-3
            tbGetDress.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GetDressString);
            //tbDeposit.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.DepositString + Resources.Resource.PaymentString);
            //tbBalanceDue.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BalanceDueString + Resources.Resource.PaymentString);

            //Oth
            tbOth.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RemarkString);
        }
        private void Div()
        {
            divCehckDress.Visible = false;
            divChooseDress.Visible = false;
            divDinner.Visible = false;
            divGetDress.Visible = false;
            divHotel.Visible = false;
            divModelCheck.Visible = false;
            divTakePicture.Visible = false;
            divTryDress.Visible = false;
            divWeddingInfo.Visible = false;
            divDress.Visible = false;

        }
        private void InitialControlWithPermission()
        {
            PermissionUtil util = new PermissionUtil();
            if (Session["Operation"] == null) Response.Redirect("~/Login.aspx");
            PermissionItem item = util.GetPermissionByKey(Session["Operation"], util.GetOperationSnByPage(this.Page.AppRelativeVirtualPath));
            btnModify.Visible = item.CanModify;
            btnModify.Enabled = item.CanModify;
            btnPhotoExport.Enabled = item.CanExport;
            btnPhotoExport.Visible = item.CanExport;
            btnCouplesInfo.Enabled = item.CanExport;
            btnCouplesInfo.Visible = item.CanExport;
            if (bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                btnModify.Visible = false;
                panelBasicInfo.Enabled = false;
            }
        }
        private void InitialConferenceItem()
        {
            try
            {
                tvConf.Nodes.Clear();
                DataSet ds = GetConferenceItem(" And ConferenceLv != 0");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                TreeNode conNode = new TreeNode();
                TreeNode itemNode = new TreeNode();
                foreach (int cnt in ds.Tables[0].AsEnumerable().Select(x => x["ConferenceLv"]).Distinct().ToList())
                {
                    conNode = new TreeNode(cnt.ToString(), string.Empty);
                    foreach (DataRow dr in ds.Tables[0].Select("ConferenceLv = " + cnt))
                    {
                        conNode.ChildNodes.Add(new TreeNode(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                            , dr["Id"].ToString() + ";" + dr["Sn"].ToString()));
                    }
                    tvConf.Nodes.Add(conNode);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialOrderType()
        {
            ddlOrderType.Items.Clear();
            ddlOrderType.Items.Add(new ListItem(Resources.Resource.ProjectString, string.Empty));
            try
            {
                string sql = "SELECT * FROM [dbo].[ServiceItemCategory] Where TypeLv=0 order by Type";
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void WPProductSet()
        {
            ddlWPProductSet.Items.Clear();
            ddlWPProductSet.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
            try
            {
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("select * From ServiceItemCategory Where IsDelete=0 And TypeLv = 1");
                if (!SysProperty.Util.IsDataSetEmpty(ds))
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ddlWPProductSet.Items.Add(new ListItem(
                            SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                            , dr["Id"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        #endregion

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage()
        {
            Session.Remove("OrderId");
            Response.Redirect("~/CaseMgt/TimeMaintain.aspx", true);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            string itemId = tvConf.SelectedValue.Split(';')[0];
            string orderId = Session["OrderId"].ToString();
            if (string.IsNullOrEmpty(itemId)) return;
            bool result = WriteBackData(MsSqlTable.ConferenceInfo, ConferenceItemDbObject(itemId, orderId), orderId, itemId);
            if (!result) return;
            else
            {
                tvConf.SelectedNode.Checked = cbCompleted.Checked;
                WriteBackData(MsSqlTable.OrderInfo, OrderInfoDbObject(itemId), orderId, itemId);
                SetDivByItemId(tvConf.SelectedValue.Split(';')[1], orderId, itemId);
                SetDivByItemId(tvConf.SelectedValue.Split(';')[1]);
            }
        }

        private void SetDivByItemId(string ItemSn, string orderId, string itemId)
        {
            ResetAllDivControl();
            switch (ItemSn)
            {
                case "CI1008":
                case "CI2011":
                case "CI2012":
                case "CI3015":
                    //divCehckDress.Visible = true;
                    WriteBackMultipleInfo(MsSqlTable.DressOrder, DressOrderDbObject(orderId));
                    break;
                //
                case "CI3017":
                    if (!string.IsNullOrEmpty(tbGetDress.Text))
                    {
                        DataSet ds = GetDressOrder(orderId);
                        WriteBackMultipleInfo(MsSqlTable.DressRent, DressRentDbObject(orderId, ds, tbGetDress.Text));
                    }
                    WriteBackMultipleInfo(MsSqlTable.ReceiptDetail, ReceiptDbObject(orderId));
                    break;
                default:
                    break;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            TransferToOtherPage();
        }

        #region Get Data Info
        private DataSet GetProductSet(string id)
        {
            try
            {
                string sql = "select * from ProductSet "
                    + " where id ='" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetOrderInfo(string id)
        {
            try
            {
                string sql = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                + ", cus.EngName AS CustomerEngName, pr.EngName AS PartnerEngName, cus.Phone As CustomerPhone, pr.Phone AS PartnerPhone"
                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId] , o.PS_CheckLegal"
                + ", o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName, o.ServiceType"
                + ", o.[OverseaFilmDate], o.[OverseaWeddingDate], o.[LocalFilmingDate], o.[LocalWeddingDate]"
                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                + ", p.WeddingCategory , o.PS_PastorLanguage , o.PS_WelcomeCard , o.PS_Guest , o.PS_Champagne ,o.PS_TravelPeriod "
                + ", o.PS_Flight , o.PS_SpecialClaim as OSp , o.PS_ChurchArrangements , o.PS_WeddingSequence"
                + ", o.PS_BridalHopeName , o.PS_Suit , o.PS_FirstHotelName , o.PS_FirstHotelName2 , o.PS_FirstHotelAddress"
                + ", o.PS_SecondHotelName , o.PS_SecondHotelName2 , o.PS_SecondHotelAddress , o.PS_Contact , wc.Name as WCname"
                + ", o.PS_HotelStayNight ,o.PS_WeddingSpecial as WSp"
                + ", o.PS_SuitSpC , o.PS_DressSpC,o.PS_GetDress"
                + ", o.PS_BModel , o.PS_BModelFocus , o.PS_BSPc , o.PS_GModel , o.PS_GSPc"
                + ", p.IsLegal , p.StayNight , p.Corsage , p.Decoration"
                + ", o.PS_RoutePlan , o.PS_Attractions , o.PS_PhotoItem , o.PS_Avoid , o.PS_PSpecialClaim"
                + ", o.PS_SitePlan , o.PS_BanquetContent , o.PS_Food, o.PS_BanquetGuest , o.PS_BSpecialClaim , o.PS_BouquetCheck ,o.PS_TakePictureBouquetCheck"
                + ", do.Bust , do.Waist , do.Hips , do.IsCheck , do.IsTry "
                + ", ch.BouquetImg , ch.Sn as ChSn"
                + " FROM [dbo].[OrderInfo] as o"
                + " Left join Consultation as c on c.Id = o.ConsultId"
                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " Left join ProductSet as p on p.Id = o.SetId"
                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                + " Left join WeddingCategory as wc on wc.id=p.WeddingCategory"
                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                + " Left join DressOrder as do on do.OrderId = o.id"
                + " Left join Church as ch on ch.id = o.ChurchId"
                + " WHERE o.IsDelete = 0 and o.Id='" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private DataSet GetConferenceList(string condStr)
        {
            try
            {
                string sql = "SELECT info.[Id],[ItemId],[OrderId],[BookingDate],[IsCheck]"
                    + ",[CheckTime],[EmployeeId],info.Remark,info.[IsDelete],info.[UpdateAccId]"
                    + ",info.[UpdateTime],item.ConferenceLv"
                    + " FROM [dbo].[ConferenceInfo] as info"
                    + " Left join ConferenceItem as item on item.Id = info.ItemId"
                    + " Where info.IsDelete=0 " + condStr;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }

        private DataSet GetDressOrder(string orderId)
        {
            try
            {
                string sql = "SELECT do.[id],do.[OrderId],do.[DressId],do.[HairItemId]"
                    + ",do.[Bust],do.[Waist],do.[Hips],do.[Remark],do.[IsCheck]"
                    + ",do.[IsDelete],do.[CreatedateAccId],do.[UpdateAccId]"
                    + ",do.[CreatedateTime],do.[UpdatedateTime]"
                    + ",do.[SpecialClaim],do.[IsTry],d.Sn as DressSn"
                    + ",hs.Sn as HairItemSn,d.Category as DressCategory,hs.Type as HairItemType"
                    + " FROM [DressOrder] as do"
                    + " Left join Dress as d on d.Id = do.DressId"
                    + " Left Join HairStyleItem as hs on hs.Id = do.HairItemId"
                    + " Where do.IsDelete=0 And do.OrderId='" + orderId + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private DataSet GetConferenceItem(string condStr)
        {
            try
            {
                string sql = "Select * From ConferenceItem Where IsDelete = 0 " + condStr + " order by Sn";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private DataSet GetWeddingCategory(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return null;
                string sql = "Select * From WeddingCategory Where Id = '" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        #endregion

        private void SetOrderInfo(string id)
        {
            string cultureCode = Session["CultureCode"].ToString();
            DataSet ds = GetOrderInfo(id);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            bool isWP = dr["Sn"].ToString().Trim().StartsWith("WC");
            tbBridalName.Text = dr["CustomerName"].ToString();
            tbGroomName.Text = dr["PartnerName"].ToString();

            if (isWP)
            {
                tbProductSet.Text = ddlWPProductSet.Items.FindByValue(dr["SetId"].ToString()).Text;
            }
            else
            {
                tbProductSet.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , dr["SetName"].ToString()
                    , dr["SetCnName"].ToString()
                    , dr["SetEngName"].ToString()
                    , dr["SetJpName"].ToString());
            }

            ddlOrderType.SelectedValue = dr["ServiceType"].ToString();
            tbLocation.Text = SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString()
                    , (isWP ? SysProperty.GetStoreById(dr["StoreId"].ToString()) : SysProperty.GetChurchById(dr["ChurchId"].ToString())));
            tbArea.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetAreaById(dr["AreaId"].ToString()));
            tbCountry.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetCountryById(dr["CountryId"].ToString()));
            tbContractDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["StartTime"].ToString());
            labelSn.Text = dr["Sn"].ToString();
            labelBridalEngName.Text = dr["CustomerEngName"].ToString();
            labelBridalPhone.Text = dr["CustomerPhone"].ToString();
            labelGroomEngName.Text = dr["PartnerEngName"].ToString();
            labelGroomPhone.Text = dr["PartnerPhone"].ToString();
            tbContractDate.Text = GetExpectDate(dr);
            tbOsp.Text = dr["OSp"].ToString();

            //1-1
            tbHotelName.Text = dr["PS_FirstHotelName"].ToString();
            tbHotelOthName.Text = dr["PS_FirstHotelName2"].ToString();
            tbHotelAddr.Text = dr["PS_FirstHotelAddress"].ToString();
            tbHotelName2.Text = dr["PS_SecondHotelName"].ToString();
            tbHotelOthName2.Text = dr["PS_SecondHotelName2"].ToString();
            tbHotelAddr2.Text = dr["PS_SecondHotelAddress"].ToString();
            tbTravelPeriod.Text = dr["PS_TravelPeriod"].ToString();
            tbStayNight.Text = dr["PS_HotelStayNight"].ToString();
            tbContact.Text = dr["PS_Contact"].ToString();
            tbFlight.Text = dr["PS_Flight"].ToString();


            //1-2
            //tbWeddingStyle.Text = dr["WCname"].ToString();
            //cbLegalWedding 從productset
            cbLegalWedding.Checked = bool.Parse(dr["PS_CheckLegal"].ToString());
            if (dr["IsLegal"].ToString() == "True")
            { cbLegalWedding.Enabled = false; }
            tbWelcomeCard.Text = dr["PS_WelcomeCard"].ToString();
            tbBouquetCorsage.Text = dr["PS_BouquetCheck"].ToString();
            tbChampagne.Text = dr["PS_Champagne"].ToString();
            tbGuest.Text = dr["PS_Guest"].ToString();
            tbWeddingSequence.Text = dr["PS_WeddingSequence"].ToString();
            tbChurchArrangements.Text = dr["PS_ChurchArrangements"].ToString();
            tbWSp.Text = dr["WSp"].ToString();
            ddlLangPastor.SelectedValue = dr["PS_PastorLanguage"].ToString();

            //1-3
            tbRoutePlan.Text = dr["PS_RoutePlan"].ToString();
            tbPhotoItem.Text = dr["PS_PhotoItem"].ToString();
            tbPhotoBouquet.Text = dr["PS_TakePictureBouquetCheck"].ToString();
            tbPhotoAvoid.Text = dr["PS_Avoid"].ToString();
            tbPSp.Text = dr["PS_PSpecialClaim"].ToString();
            tbAttractions.Text = dr["PS_Attractions"].ToString();

            //1-4
            tbBridalSpecialClaim.Text = dr["PS_DressSpC"].ToString();
            tbGroomDressNum.Text = dr["PS_Suit"].ToString();
            tbGroomSpecialClaim.Text = dr["PS_SuitSpC"].ToString();

            //1-5
            tbSitePlan.Text = dr["PS_SitePlan"].ToString();
            tbDinnerContent.Text = dr["PS_BanquetContent"].ToString();
            tbFood.Text = dr["PS_Food"].ToString();
            tbDinnerGuest.Text = dr["PS_BanquetGuest"].ToString();
            tbBSp.Text = dr["PS_BSpecialClaim"].ToString();

            //2-1 從DressOrder那撈
            //2-2
            tbBridalHairSpecailClaim.Text = dr["PS_BSPc"].ToString();
            tbGroomHair.Text = dr["PS_GModel"].ToString();
            tbGroomHairSpecailClaim.Text = dr["PS_GSPc"].ToString();
            tbBridalModeling.Text = dr["PS_BModel"].ToString();
            tbBridalMakeupEmphasis.Text = dr["PS_BModelFocus"].ToString();
            //3-1 從DressOrder那撈
            //3-3 Receipt
            tbGetDress.Text = SysProperty.Util.ParseDateTime("DateTime", dr["PS_GetDress"].ToString());//?

            // Set wedding category data
            DataSet weddingType = GetWeddingCategory(dr["WeddingCategory"].ToString());
            if (!SysProperty.Util.IsDataSetEmpty(weddingType))
            {
                labelWeddingCategory.Text = SysProperty.Util.OutputRelatedLangName(
                cultureCode
                , weddingType.Tables[0].Rows[0]
                );
            }

            SetConferenceItem(id, dr["ConferenceCategory"].ToString());

            // Hide edit button when case closed.
            bool isClose = !string.IsNullOrEmpty(SysProperty.Util.ParseDateTime("DateTime", dr["CloseTime"].ToString()));
            cbIsClose.Checked = isClose;
            if (isClose || bool.Parse(((DataRow)Session["LocateStore"])["HoldingCompany"].ToString()))
            {
                btnModify.Visible = false;
                cbCompleted.Enabled = false;
                tbOth.Enabled = false;
            }


            lblBouquet1.Text = Resources.Resource.PhotoBouquetString;
            ImgBouquet1.ImageUrl = "http:" + SysProperty.ImgRootFolderpath + dr["BouquetImg"].ToString() + @"\" + dr["ChSn"].ToString() + "_" + "1" + @".jpg?" + DateTime.Now.Ticks.ToString();

        }

        private string GetExpectDate(DataRow dr)
        {
            string time;
            switch (ddlOrderType.SelectedIndex)
            {
                case 0:
                    time = SysProperty.Util.ParseDateTime("Date", dr["OverseaWeddingDate"].ToString());
                    break;
                case 1:
                    time = SysProperty.Util.ParseDateTime("Date", dr["LocalWeddingDate"].ToString());
                    break;
                case 2:
                    time = SysProperty.Util.ParseDateTime("Date", dr["OverseaWeddingDate"].ToString());
                    break;
                case 3:
                    time = SysProperty.Util.ParseDateTime("Date", dr["LocalFilmingDate"].ToString());
                    break;
                case 4:
                    time = SysProperty.Util.ParseDateTime("Date", dr["OverseaFilmDate"].ToString());
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

        private void SetConferenceItem(string id, string nowConf)
        {
            DataSet ds = GetConferenceList(" And OrderId = '" + id + "'");
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int index = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (bool.Parse(dr["IsCheck"].ToString()))
                {
                    index = int.Parse(dr["ConferenceLv"].ToString()) - 1;
                    for (int i = 0; i < tvConf.Nodes[index].ChildNodes.Count; i++)
                    {
                        try
                        {
                            if (tvConf.Nodes[index].ChildNodes[i].Value.Trim().StartsWith(nowConf))
                            {
                                tvConf.Nodes[index].ChildNodes[i].Selected = true;
                                tvConf_SelectedNodeChanged(tvConf, new EventArgs());
                            }

                            if (tvConf.Nodes[index].ChildNodes[i].Value.Trim().StartsWith(dr["ItemId"].ToString()))
                            {
                                tvConf.Nodes[index].ChildNodes[i].Checked = true;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Error(ex.Message);
                            continue;
                        }
                    }
                }
            }
        }

        protected void tvConf_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (Session["OrderId"] == null) TransferToOtherPage();
            string[] var = tvConf.SelectedValue.Split(';');
            if (string.IsNullOrEmpty(var[0]))
            {
                tbConDate.Enabled = false;
                cbCompleted.Enabled = false;
                tbOth.Enabled = false;
                btnModify.Enabled = false;
            }
            else
            {
                tbConDate.Enabled = !cbIsClose.Checked;
                cbCompleted.Enabled = !cbIsClose.Checked;
                tbOth.Enabled = !cbIsClose.Checked;
                btnModify.Enabled = !cbIsClose.Checked;
                DataSet ds = GetConferenceList(
                    " And OrderId = '" + Session["OrderId"].ToString() + "'"
                    + " And ItemId = '" + var[0] + "'");
                SetDivByItemId(var[1]);
                if (SysProperty.Util.IsDataSetEmpty(ds))
                {
                    tbOth.Text = string.Empty;
                    tbConDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:00");
                    cbCompleted.Checked = false;
                }
                else
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    tbOth.Text = dr["Remark"].ToString();
                    tbConDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
                    if (string.IsNullOrEmpty(tbConDate.Text)) tbConDate.Text = DateTime.Now.ToString("yyyy/MM/dd HH:00");
                    cbCompleted.Checked = bool.Parse(dr["IsCheck"].ToString());
                }
            }
        }

        private void SetDressOrder(string orderId)
        {
            FirstGridViewRow_dgCutomServiceItem();
            DataSet ds = GetDressOrder(orderId);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            int rowIndex = 0;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dgCutomServiceItem.Rows.Count == 0)
                {
                    AddNewRow_dgCutomServiceItem();
                }
                ((TextBox)dgCutomServiceItem.Rows[rowIndex].FindControl("tbId")).Text = dr["Id"].ToString();
                DropDownList ddlService = ((DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("ddlServiceItem"));
                ddlService.SelectedValue = dr["DressCategory"].ToString() + ";" + rowIndex;
                ddlServiceItem_SelectedIndexChanged(ddlService, new EventArgs());
                AjaxControlToolkit.ComboBox cbxDress = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("cbxChooseDSn");
                cbxDress.Text = dr["DressSn"].ToString();
                cbxDress.SelectedValue = dr["DressId"] + ";" + rowIndex;
                cbxChooseDSn_SelectedIndexChanged(cbxDress, new EventArgs());
                ((TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("tbBust")).Text = dr["Bust"].ToString();
                ((TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[3].FindControl("tbWaist")).Text = dr["Waist"].ToString();
                ((TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[4].FindControl("tbHips")).Text = dr["Hips"].ToString();
                ((CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[5].FindControl("cbIsTry")).Checked = bool.Parse(dr["IsTry"].ToString());
                ((CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[6].FindControl("cbIsCheck")).Checked = bool.Parse(dr["IsCheck"].ToString());
                DropDownList ddlHairType = ((DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[10].FindControl("ddlHairCategory"));
                ddlHairType.SelectedValue = dr["HairItemType"].ToString() + ";" + rowIndex;
                ddlHairCategory_SelectedIndexChanged(ddlHairType, new EventArgs());
                AjaxControlToolkit.ComboBox cbxHair = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[11].FindControl("cbxChooseHSn");
                cbxHair.SelectedValue = dr["HairItemId"].ToString() + ";" + rowIndex;
                cbxHair.Text = dr["HairItemSn"].ToString();
                cbxChooseHSn_SelectedIndexChanged(cbxHair, new EventArgs());

                rowIndex++;
                AddNewRow_dgCutomServiceItem();
            }
        }
        private void SetReceiptDetail(string orderId)
        {
            FirstGridViewRow2();
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

        #region Db Instance
        private List<DbSearchObject> OrderInfoDbObject(string itemId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "ConferenceCategory"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , itemId
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , SysProperty.Util.ParseDateTime("DateTime", tbConDate.Text)
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
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            lst.Add(new DbSearchObject(
                "PS_SpecialClaim"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOsp.Text
                ));

            //1-1
            lst.Add(new DbSearchObject(
                "PS_FirstHotelName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelName.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_FirstHotelName2"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelOthName.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_FirstHotelAddress"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelAddr.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_SecondHotelName"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelName2.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_SecondHotelName2"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelOthName2.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_SecondHotelAddress"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbHotelAddr2.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_TravelPeriod"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbTravelPeriod.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_Contact"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbContact.Text
                ));
            lst.Add(new DbSearchObject(
               "PS_HotelStayNight"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbStayNight.Text
               ));
            lst.Add(new DbSearchObject(
               "PS_Flight"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbFlight.Text
               ));

            //1-2
            lst.Add(new DbSearchObject(
                "PS_CheckLegal"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , cbLegalWedding.Checked ? "1" : "0"
                ));
            lst.Add(new DbSearchObject(
               "PS_WelcomeCard"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbWelcomeCard.Text
               ));
            lst.Add(new DbSearchObject(
               "PS_Champagne"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbChampagne.Text
               ));
            lst.Add(new DbSearchObject(
               "PS_Guest"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbGuest.Text
               ));
            lst.Add(new DbSearchObject(
               "PS_WeddingSequence"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbWeddingSequence.Text
               ));
            lst.Add(new DbSearchObject(
               "PS_ChurchArrangements"
               , AtrrTypeItem.String
               , AttrSymbolItem.Equal
               , tbChurchArrangements.Text
               ));
            lst.Add(new DbSearchObject(
                "PS_PastorLanguage"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ddlLangPastor.SelectedValue
                ));
            lst.Add(new DbSearchObject(
                "PS_WeddingSpecial"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbWSp.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BouquetCheck"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBouquetCorsage.Text
                ));

            //1-3
            lst.Add(new DbSearchObject(
                "PS_RoutePlan"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbRoutePlan.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_Attractions"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbAttractions.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_PhotoItem"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPhotoItem.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_Avoid"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPhotoAvoid.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_PSpecialClaim"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbPSp.Text
                ));

            //1-4
            lst.Add(new DbSearchObject(
                "PS_SuitSpC"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomSpecialClaim.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_DressSpC"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalSpecialClaim.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_Suit"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomDressNum.Text
                ));

            //1-5
            lst.Add(new DbSearchObject(
                "PS_SitePlan"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbSitePlan.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BanquetContent"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDinnerContent.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_Food"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbFood.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BanquetGuest"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbDinnerGuest.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BSpecialClaim"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBSp.Text
                ));

            //2-2
            lst.Add(new DbSearchObject(
                "PS_BModel"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalModeling.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BModelFocus"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalMakeupEmphasis.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_BSPc"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbBridalHairSpecailClaim.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_GModel"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomHair.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_GSPc"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbGroomHairSpecailClaim.Text
                ));
            lst.Add(new DbSearchObject(
                "PS_GetDress"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbGetDress.Text
                ));
            return lst;
        }
        private List<DbSearchObject> ConferenceItemDbObject(string itemId, string orderId)
        {
            List<DbSearchObject> lst = new List<DbSearchObject>();
            lst.Add(new DbSearchObject(
                "OrderId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , orderId
                ));
            lst.Add(new DbSearchObject(
                "ItemId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , itemId
                ));
            lst.Add(new DbSearchObject(
                "BookingDate"
                , AtrrTypeItem.DateTime
                , AttrSymbolItem.Equal
                , tbConDate.Text
                ));
            lst.Add(new DbSearchObject(
                "IsCheck"
                , AtrrTypeItem.Bit
                , AttrSymbolItem.Equal
                , (cbCompleted.Checked ? "1" : "0")
                ));
            lst.Add(new DbSearchObject(
                "Remark"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , tbOth.Text
                ));
            if (cbCompleted.Checked)
            {
                lst.Add(new DbSearchObject(
                "CheckTime"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
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
            lst.Add(new DbSearchObject(
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }
        private List<List<DbSearchObject>> DressOrderDbObject(string id)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            List<DbSearchObject> lst = new List<DbSearchObject>();
            if (ViewState["CurrentTable2"] != null)
            {
                string str = string.Empty;
                bool isCreate = false;
                if (dgCutomServiceItem.Rows.Count > 0)
                {
                    foreach (GridViewRow dr in dgCutomServiceItem.Rows)
                    {
                        lst = new List<DbSearchObject>();
                        str = ((TextBox)dr.Cells[0].FindControl("tbId")).Text;
                        isCreate = string.IsNullOrEmpty(str);
                        str = ((AjaxControlToolkit.ComboBox)dr.Cells[1].FindControl("cbxChooseDSn")).SelectedValue;
                        if (string.IsNullOrEmpty(str) || !str.Contains(";")) continue;
                        lst.Add(new DbSearchObject(
                            "DressId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , str.Split(';')[0]
                            ));
                        lst.Add(new DbSearchObject(
                            "OrderId"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , id
                            ));
                        str = ((AjaxControlToolkit.ComboBox)dr.Cells[1].FindControl("cbxChooseHSn")).SelectedValue;
                        if (!string.IsNullOrEmpty(str) && str.Contains(";"))
                        {
                            lst.Add(new DbSearchObject(
                                "HairItemId"
                                , AtrrTypeItem.String
                                , AttrSymbolItem.Equal
                                , str.Split(';')[0]
                                ));
                        }
                        lst.Add(new DbSearchObject(
                            "Bust"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[3].FindControl("tbBust")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "Waist"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[4].FindControl("tbWaist")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "Hips"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[5].FindControl("tbHips")).Text
                            ));
                        lst.Add(new DbSearchObject(
                            "IsCheck"
                            , AtrrTypeItem.Bit
                            , AttrSymbolItem.Equal
                            , (((CheckBox)dr.Cells[6].FindControl("cbIsCheck")).Checked ? "1" : "0")
                            ));
                        lst.Add(new DbSearchObject(
                            "IsTry"
                            , AtrrTypeItem.Bit
                            , AttrSymbolItem.Equal
                            , (((CheckBox)dr.Cells[7].FindControl("cbIsTry")).Checked ? "1" : "0")
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
                            "UpdatedateTime"
                            , AtrrTypeItem.DateTime
                            , AttrSymbolItem.Equal
                            , DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
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
                            , ((TextBox)dr.Cells[0].FindControl("tbId")).Text
                            ));
                        }
                    }
                }
            }
            return result;
        }
        private List<List<DbSearchObject>> DressRentDbObject(string orderId, DataSet ds, string startTime)
        {
            List<List<DbSearchObject>> result = new List<List<DbSearchObject>>();
            if (SysProperty.Util.IsDataSetEmpty(ds)) return result;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                List<DbSearchObject> lst = new List<DbSearchObject>();
                lst.Add(new DbSearchObject(
                    "DressId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , dr["DressId"].ToString()
                    ));
                lst.Add(new DbSearchObject(
                    "OrderId"
                    , AtrrTypeItem.String
                    , AttrSymbolItem.Equal
                    , orderId
                    ));
                lst.Add(new DbSearchObject(
                    "StartTime"
                    , AtrrTypeItem.DateTime
                    , AttrSymbolItem.Equal
                    , startTime
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
                        "StatusCode"
                        , AtrrTypeItem.String
                        , AttrSymbolItem.Equal
                        , "67F14E3B-5294-44EE-97CF-948BB2FC3031"
                        ));
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
                result.Add(lst);
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
                        else
                        {
                            lst.Add(new DbSearchObject(
                            "Id"
                            , AtrrTypeItem.String
                            , AttrSymbolItem.Equal
                            , ((TextBox)dr.Cells[0].FindControl("tbReceiptId")).Text
                            ));
                        }
                        result.Add(lst);
                    }
                }
            }
            return result;
        }
        #endregion

        #region Db Write back
        private bool WriteBackData(MsSqlTable table, List<DbSearchObject> lst, string orderId, string itemId)
        {
            try
            {
                if (table == MsSqlTable.OrderInfo)
                {
                    return SysProperty.GenDbCon.UpdateDataIntoTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryUpdateConverter(lst)
                        , " Where Id='" + orderId + "'");
                }
                else
                {
                    SysProperty.GenDbCon.ModifyDataInToTable(
                        "Delete From ConferenceInfo"
                        + " Where OrderId = '" + orderId + "'"
                        + " And ItemId = '" + itemId + "'");
                    return SysProperty.GenDbCon.InsertDataInToTable(
                        SysProperty.Util.MsSqlTableConverter(table)
                        , SysProperty.Util.SqlQueryInsertInstanceConverter(lst)
                        , SysProperty.Util.SqlQueryInsertValueConverter(lst));
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
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
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        private bool WriteBackMultipleInfo(MsSqlTable table, List<List<DbSearchObject>> lst)
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
                result = result | WriteBackData(table, isInsert, item, condStr);
            }
            return result;
        }
        private bool DeleteDresOrder(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id)) return true;
                string sql = "UPDATE DressOrder SET IsDelete = 1"
                + ", UpdateAccId=N'" + ((DataRow)Session["AccountInfo"])["Id"].ToString() + "'"
                + ", UpdatedateTime='" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + "'"
                + " Where Id = '" + id + "'";
                return SysProperty.GenDbCon.ModifyDataInToTable(sql);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }
        #endregion

        #region Document Export
        private void InitialLangList()
        {
            ddlLang.Items.Clear();
            ddlLang.Items.Add(new ListItem(Resources.Resource.TraditionalChineseString, "zh-TW"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.SimplifiedChineseString, "zh-CN"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.EnglishString, "en"));
            ddlLang.Items.Add(new ListItem(Resources.Resource.JapaneseString, "ja-JP"));
            ddlLang.SelectedIndex = new ResourceUtil().OutputLangNameNumber(((string)Session["CultureCode"]));
            ddlLang.SelectedValue = Session["CultureCode"].ToString();
        }
        protected void btnPhotoExport_Click(object sender, EventArgs e)
        {
            CreatePhotoDoc(labelSn.Text, tbBridalName.Text, tbGroomName.Text);
        }

        private void CreatePhotoDoc(string sn, string bridalName, string groomName)
        {
            string filePath = new GroupPhotoNotification().CreateGroupPhoto(ddlLang.SelectedValue, sn
                , bridalName, groomName, "", DateTime.Parse(tbContractDate.Text));
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
                Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                Response.Charset = "UTF-8";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.WriteFile(filePath);
                Response.End();
            }
        }

        protected void btnCouplesInfo_Click(object sender, EventArgs e)
        {
            CreateCouplesInfoDoc(labelSn.Text, tbContractDate.Text, tbLocation.Text
                , tbBridalName.Text, labelBridalEngName.Text, labelBridalPhone.Text
                , tbGroomName.Text, labelGroomEngName.Text, labelGroomPhone.Text
                , ddlOrderType.SelectedItem.Text, labelWeddingCategory.Text, string.Empty);
        }

        private void SetDivByItemId(string ItemSn)
        {
            ResetAllDivControl();
            switch (ItemSn)
            {
                //1
                case "CI1005":
                    divHotel.Visible = true;
                    break;
                case "CI1006":
                    divWeddingInfo.Visible = true;
                    divBouquet.Visible = true;
                    break;
                case "CI1007":
                    divTakePicture.Visible = true;
                    divBouquet.Visible = true;
                    break;
                case "CI1008":
                    divChooseDress.Visible = true;
                    SetDressOrder(Session["OrderId"].ToString());
                    divDress.Visible = true;
                    break;
                case "CI1009":
                    divDinner.Visible = true;
                    break;
                //2
                case "CI2011":
                    //divTryDress.Visible = true;
                    SetDressOrder(Session["OrderId"].ToString());
                    divDress.Visible = true;
                    break;
                case "CI2012":
                    divModelCheck.Visible = true;
                    SetDressOrder(Session["OrderId"].ToString());
                    divDress.Visible = true;
                    break;
                //3
                case "CI3015":
                    //divCehckDress.Visible = true;
                    SetDressOrder(Session["OrderId"].ToString());
                    divDress.Visible = true;
                    break;
                //
                case "CI3017":
                    divGetDress.Visible = true;
                    SetReceiptDetail(Session["OrderId"].ToString());
                    break;
                default:
                    break;
            }
        }

        private void ResetAllDivControl()
        {
            divCehckDress.Visible = false;
            divChooseDress.Visible = false;
            divDinner.Visible = false;
            divGetDress.Visible = false;
            divHotel.Visible = false;
            divModelCheck.Visible = false;
            divTakePicture.Visible = false;
            divTryDress.Visible = false;
            divWeddingInfo.Visible = false;
            divBouquet.Visible = false;
            divDress.Visible = false;
        }


        private void CreateCouplesInfoDoc(
            string sn, string weddingDate, string churchName
            , string bridalName, string bridalEngName, string bridalPhone
            , string groomName, string groomEngName, string groomPhone
            , string orderType, string religiousType, string isLegal)
        {
            string filePath = new CouplesInfoDoc().CreateCouplesInfoDoc(
                ddlLang.SelectedValue, sn, weddingDate, churchName
                , bridalName, bridalEngName, bridalPhone
                , groomName, groomEngName, groomPhone
                , orderType, religiousType, isLegal);
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
                Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8;
                Response.Charset = "UTF-8";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.WriteFile(filePath);
                Response.End();
            }
        }
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            ScriptManager sm = ScriptManager.GetCurrent(Page);
            if (sm.IsInAsyncPostBack)
            {
                //         < link href = "../assets/css/font-awesome.min.css" rel = "stylesheet" />   
                //< link href = "../assets/css/jquery-ui.css" rel = "stylesheet" />
                HtmlLink l = new HtmlLink();
                l = new HtmlLink();
                l.Href = ResolveUrl("../assets/css/font-awesome.min.css");
                l.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(l);
                l = new HtmlLink();
                l.Href = ResolveUrl("../assets/css/jquery-ui.css");
                l.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(l);
                l.Href = ResolveUrl("../assets/css/calendar.css");
                l.Attributes.Add("rel", "stylesheet");
                Page.Header.Controls.Add(l);
            }

        }


        #region 1-4 Choose Dress        
        #region Dress Choosen Table
        protected void dgCutomServiceItem_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SetRowData_dgCutomServiceItem();
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                bool result = true;
                if (!string.IsNullOrEmpty(dt.Rows[rowIndex]["Id"].ToString()))
                {
                    result = DeleteDresOrder(dt.Rows[rowIndex]["Id"].ToString());
                }
                if (dt.Rows.Count > 1 && result)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTable2"] = dt;
                    dgCutomServiceItem.DataSource = dt;
                    dgCutomServiceItem.DataBind();

                    SetPreviousData_dgCutomServiceItem();
                }
            }
        }

        protected void dgCutomServiceItem_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            ddlHairCategory(sender, e);
            ddlService(sender, e);
        }

        private void SetRowData_dgCutomServiceItem()
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
                        TextBox tbId = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("tbId");
                        DropDownList DdlItem = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        AjaxControlToolkit.ComboBox cbxChooseDSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("cbxChooseDSn");
                        TextBox tbBust = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[3].FindControl("tbBust");
                        TextBox tbWaist = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[4].FindControl("tbWaist");
                        TextBox tbHips = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[5].FindControl("tbHips");
                        CheckBox cbIsTry = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[6].FindControl("cbIsTry");
                        CheckBox cbIsCheck = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[7].FindControl("cbIsCheck");
                        Image ImgCDress1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[8].FindControl("ImgCDress1");
                        Image ImgCDress2 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[9].FindControl("ImgCDress2");
                        Image ImgCDress3 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[10].FindControl("ImgCDress3");
                        DropDownList ddlHairCategory = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[11].FindControl("ddlHairCategory");
                        AjaxControlToolkit.ComboBox cbxChooseHSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[12].FindControl("cbxChooseHSn");
                        Image ImgCHair1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[13].FindControl("ImgCHair1");

                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Id"] = tbId.Text;
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = cbxChooseDSn.Text;
                        dtCurrentTable.Rows[i - 1]["Col3"] = tbBust.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = tbWaist.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = tbHips.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = cbIsTry.Checked;
                        dtCurrentTable.Rows[i - 1]["Col7"] = cbIsCheck.Checked;
                        dtCurrentTable.Rows[i - 1]["Col8"] = ImgCDress1.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col9"] = ImgCDress2.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col10"] = ImgCDress3.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col11"] = ddlHairCategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col12"] = cbxChooseHSn.Text;
                        dtCurrentTable.Rows[i - 1]["Col13"] = ImgCHair1.ImageUrl;
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

        private void SetPreviousData_dgCutomServiceItem()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable2"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable2"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox tbId = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("tbId");
                        DropDownList DdlItem = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        AjaxControlToolkit.ComboBox cbxChooseDSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("cbxChooseDSn");
                        TextBox tbBust = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[3].FindControl("tbBust");
                        TextBox tbWaist = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[4].FindControl("tbWaist");
                        TextBox tbHips = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[5].FindControl("tbHips");
                        CheckBox cbIsTry = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[6].FindControl("cbIsTry");
                        CheckBox cbIsCheck = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[7].FindControl("cbIsCheck");
                        Image ImgCDress1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[8].FindControl("ImgCDress1");
                        Image ImgCDress2 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[9].FindControl("ImgCDress2");
                        Image ImgCDress3 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[10].FindControl("ImgCDress3");
                        DropDownList ddlHairCategory = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[11].FindControl("ddlHairCategory");
                        AjaxControlToolkit.ComboBox cbxChooseHSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[12].FindControl("cbxChooseHSn");
                        Image ImgCHair1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[13].FindControl("ImgCHair1");

                        if (cbxChooseDSn == null) continue;
                        tbId.Text = dt.Rows[i]["Id"].ToString();
                        DdlItem.SelectedValue = dt.Rows[i]["Col1"].ToString();
                        if (!string.IsNullOrEmpty(DdlItem.SelectedValue))
                        {
                            ddlServiceItem_SelectedIndexChanged(DdlItem, new EventArgs());
                        }
                        cbxChooseDSn.SelectedValue = dt.Rows[i]["Col2"] == null ? string.Empty : dt.Rows[i]["Col2"].ToString();
                        tbBust.Text = dt.Rows[i]["Col3"] == null ? string.Empty : dt.Rows[i]["Col3"].ToString();
                        tbWaist.Text = dt.Rows[i]["Col4"] == null ? string.Empty : dt.Rows[i]["Col4"].ToString();
                        tbHips.Text = dt.Rows[i]["Col5"] == null ? string.Empty : dt.Rows[i]["Col5"].ToString();
                        cbIsTry.Checked = dt.Rows[i]["Col6"] == null ? false : (string.IsNullOrEmpty(dt.Rows[i]["Col6"].ToString()) ? false : bool.Parse(dt.Rows[i]["Col6"].ToString()));
                        cbIsCheck.Checked = dt.Rows[i]["Col7"] == null ? false : (string.IsNullOrEmpty(dt.Rows[i]["Col7"].ToString()) ? false : bool.Parse(dt.Rows[i]["Col7"].ToString()));
                        ImgCDress1.ImageUrl = dt.Rows[i]["Col8"] == null ? string.Empty : dt.Rows[i]["Col8"].ToString();
                        ImgCDress2.ImageUrl = dt.Rows[i]["Col9"] == null ? string.Empty : dt.Rows[i]["Col9"].ToString();
                        ImgCDress3.ImageUrl = dt.Rows[i]["Col10"] == null ? string.Empty : dt.Rows[i]["Col10"].ToString();
                        ddlHairCategory.SelectedValue = dt.Rows[i]["Col11"].ToString();
                        if (!string.IsNullOrEmpty(ddlHairCategory.SelectedValue))
                        {
                            ddlHairCategory_SelectedIndexChanged(ddlHairCategory, new EventArgs());
                        }
                        cbxChooseHSn.SelectedValue = dt.Rows[i]["Col12"] == null ? string.Empty : dt.Rows[i]["Col12"].ToString();
                        ImgCHair1.ImageUrl = dt.Rows[i]["Col13"] == null ? string.Empty : dt.Rows[i]["Col13"].ToString();
                        rowIndex++;
                    }
                }
            }
        }

        protected void btnAddRowCutomServiceItem_Click(object sender, EventArgs e)
        {
            AddNewRow_dgCutomServiceItem();
        }

        private void AddNewRow_dgCutomServiceItem()
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
                        TextBox tbId = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[0].FindControl("tbId");
                        DropDownList DdlItem = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[1].FindControl("ddlServiceItem");
                        AjaxControlToolkit.ComboBox cbxChooseDSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[2].FindControl("cbxChooseDSn");
                        TextBox tbBust = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[3].FindControl("tbBust");
                        TextBox tbWaist = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[4].FindControl("tbWaist");
                        TextBox tbHips = (TextBox)dgCutomServiceItem.Rows[rowIndex].Cells[5].FindControl("tbHips");
                        CheckBox cbIsTry = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[6].FindControl("cbIsTry");
                        CheckBox cbIsCheck = (CheckBox)dgCutomServiceItem.Rows[rowIndex].Cells[7].FindControl("cbIsCheck");
                        Image ImgCDress1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[8].FindControl("ImgCDress1");
                        Image ImgCDress2 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[9].FindControl("ImgCDress2");
                        Image ImgCDress3 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[10].FindControl("ImgCDress3");
                        DropDownList ddlHairCategory = (DropDownList)dgCutomServiceItem.Rows[rowIndex].Cells[11].FindControl("ddlHairCategory");
                        AjaxControlToolkit.ComboBox cbxChooseHSn = (AjaxControlToolkit.ComboBox)dgCutomServiceItem.Rows[rowIndex].Cells[12].FindControl("cbxChooseHSn");
                        Image ImgCHair1 = (Image)dgCutomServiceItem.Rows[rowIndex].Cells[13].FindControl("ImgCHair1");


                        drCurrentRow = dtCurrentTable.NewRow();
                        dtCurrentTable.Rows[i - 1]["Id"] = tbId.Text;
                        dtCurrentTable.Rows[i - 1]["Col1"] = DdlItem.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col2"] = cbxChooseDSn.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col3"] = tbBust.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = tbWaist.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = tbHips.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = cbIsTry.Checked;
                        dtCurrentTable.Rows[i - 1]["Col7"] = cbIsCheck.Checked;
                        dtCurrentTable.Rows[i - 1]["Col8"] = ImgCDress1.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col9"] = ImgCDress2.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col10"] = ImgCDress3.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col11"] = ddlHairCategory.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col12"] = cbxChooseHSn.SelectedValue;
                        dtCurrentTable.Rows[i - 1]["Col13"] = ImgCHair1.ImageUrl;
                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable2"] = dtCurrentTable;

                    dgCutomServiceItem.DataSource = dtCurrentTable;
                    dgCutomServiceItem.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData_dgCutomServiceItem();
        }

        private void FirstGridViewRow_dgCutomServiceItem()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Id", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dt.Columns.Add(new DataColumn("Col7", typeof(string)));
            dt.Columns.Add(new DataColumn("Col8", typeof(string)));
            dt.Columns.Add(new DataColumn("Col9", typeof(string)));
            dt.Columns.Add(new DataColumn("Col10", typeof(string)));
            dt.Columns.Add(new DataColumn("Col11", typeof(string)));
            dt.Columns.Add(new DataColumn("Col12", typeof(string)));
            dt.Columns.Add(new DataColumn("Col13", typeof(string)));
            dr = dt.NewRow();
            dr["Id"] = string.Empty;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col6"] = false;
            dr["Col7"] = false;
            dr["Col8"] = string.Empty;
            dr["Col9"] = string.Empty;
            dr["Col10"] = string.Empty;
            dr["Col11"] = string.Empty;
            dr["Col12"] = string.Empty;
            dr["Col13"] = string.Empty;
            dt.Rows.Add(dr);

            ViewState["CurrentTable2"] = dt;
            dgCutomServiceItem.DataSource = dt;
            dgCutomServiceItem.DataBind();
        }
        #endregion

        private void ddlService(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                DropDownList ddlService = (DropDownList)e.Row.FindControl("ddlServiceItem");
                ddlService.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("Select * From DressCategory Where IsDelete = 0 and Type='Dress'");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlService.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString() + ";" + e.Row.RowIndex
                        ));
                }
            }
        }

        private void ddlHairCategory(object sender, GridViewRowEventArgs e)
        {
            DataRowView dataItem1 = (DataRowView)e.Row.DataItem;
            if (dataItem1 != null)
            {
                DropDownList ddlHairCategory = (DropDownList)e.Row.FindControl("ddlHairCategory");
                ddlHairCategory.Items.Add(new ListItem(Resources.Resource.SeletionRemindString, string.Empty));
                DataSet ds = SysProperty.GenDbCon.GetDataFromTable("select * from HairStyleCategory where IsDelete=0");
                if (SysProperty.Util.IsDataSetEmpty(ds)) return;
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    ddlHairCategory.Items.Add(new ListItem(
                        SysProperty.Util.OutputRelatedLangName(Session["CultureCode"].ToString(), dr)
                        , dr["Id"].ToString() + ";" + e.Row.RowIndex
                        ));
                }
                //ddlHairCategory.SelectedIndex = 0;
                //cbSerHSn(sender, e, ddlHairCategory.SelectedValue);
            }
        }

        protected void ddlServiceItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] var = ((DropDownList)sender).SelectedValue.ToString().Split(';');
            AjaxControlToolkit.ComboBox cbxChooseDSn = dgCutomServiceItem.Rows[int.Parse(var[1])].FindControl("cbxChooseDSn") as AjaxControlToolkit.ComboBox;
            cbxChooseDSn.Items.Clear();

            DataSet ds1 = SysProperty.GenDbCon.GetDataFromTable("select * from [dbo].[Dress] Where IsDelete=0 And StoreId='"
                + ((DataRow)Session["LocateStore"])["Id"].ToString()
                + "' and cast(Category as nvarchar(max))='" + var[0] + "'");

            if (SysProperty.Util.IsDataSetEmpty(ds1))
            {
                cbxChooseDSn.Enabled = false;
            }
            else
            {
                cbxChooseDSn.Enabled = true;
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    cbxChooseDSn.Items.Add(new ListItem(dr["Sn"].ToString(), dr["Id"].ToString() + ";" + var[1]
                        ));
                }
            }
        }

        protected void cbxChooseDSn_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjaxControlToolkit.ComboBox cbx = sender as AjaxControlToolkit.ComboBox;
            if (string.IsNullOrEmpty(cbx.SelectedValue) || !cbx.SelectedValue.Contains(";")) return;
            string[] var = cbx.SelectedValue.ToString().Split(';');
            try
            {
                for (int cnt = 1; cnt <= 3; cnt++)
                {
                    Image img = dgCutomServiceItem.Rows[int.Parse(var[1].ToString())].FindControl("ImgCDress" + cnt) as Image;
                    if (img != null)
                    {
                        img.ImageUrl = "http:" + SysProperty.ImgRootFolderpath + @"\Dress\" + cbx.SelectedItem.Text.Substring(cbx.SelectedItem.Text.Length - 8) + @"\" + cbx.SelectedItem.Text + "_" + cnt + @".jpg?" + DateTime.Now.Ticks.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

        }

        protected void ddlHairCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] var = ((DropDownList)sender).SelectedValue.ToString().Split(';');
            AjaxControlToolkit.ComboBox cbxChooseHSn = dgCutomServiceItem.Rows[int.Parse(var[1])].FindControl("cbxChooseHSn") as AjaxControlToolkit.ComboBox;
            cbxChooseHSn.Items.Clear();

            DataSet ds1 = SysProperty.GenDbCon.GetDataFromTable("select * from [dbo].HairStyleItem Where IsDelete=0 and cast(Type as nvarchar(max))='" + var[0] + "'");

            if (SysProperty.Util.IsDataSetEmpty(ds1))
            {
                cbxChooseHSn.Enabled = false;
            }
            else
            {
                cbxChooseHSn.Enabled = true;
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    cbxChooseHSn.Items.Add(new ListItem(dr["Sn"].ToString(), dr["Id"].ToString() + ";" + var[1]
                        ));
                }
            }

        }

        protected void cbxChooseHSn_SelectedIndexChanged(object sender, EventArgs e)
        {
            AjaxControlToolkit.ComboBox cbx = sender as AjaxControlToolkit.ComboBox;
            if (string.IsNullOrEmpty(cbx.SelectedValue) || !cbx.SelectedValue.Contains(";")) return;
            string[] var = cbx.SelectedValue.ToString().Split(';');
            try
            {
                Image img = dgCutomServiceItem.Rows[int.Parse(var[1].ToString())].FindControl("ImgCHair1") as Image;
                if (img != null)
                {
                    img.ImageUrl = "http:" + SysProperty.ImgRootFolderpath + @"\HairStyleItem\" + cbx.SelectedItem.Text.Substring(cbx.SelectedItem.Text.Length - 6) + @"\" + cbx.SelectedItem.Text + "_1.jpg?" + DateTime.Now.Ticks.ToString();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
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
            if (ViewState["CurrentTableReceipt"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableReceipt"];
                DataRow drCurrentRow = null;
                int rowIndex = Convert.ToInt32(e.RowIndex);
                if (dt.Rows.Count > 1)
                {
                    dt.Rows.Remove(dt.Rows[rowIndex]);
                    drCurrentRow = dt.NewRow();
                    ViewState["CurrentTableReceipt"] = dt;
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

            ViewState["CurrentTableReceipt"] = dt;
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        private void AddNewRow2()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTableReceipt"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableReceipt"];
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
                    ViewState["CurrentTableReceipt"] = dtCurrentTable;

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
            if (ViewState["CurrentTableReceipt"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTableReceipt"];
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

            if (ViewState["CurrentTableReceipt"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTableReceipt"];
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

                    ViewState["CurrentTableReceipt"] = dtCurrentTable;
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



