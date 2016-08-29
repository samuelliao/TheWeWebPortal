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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (SysProperty.Util == null) Response.Redirect("../Login.aspx", true);
                else
                {
                    SysProperty.DataSetSortType = true;
                    InitialPastorLanguage();
                    InitialConferenceItem();
                    InitialLangList();
                    InitialOrderType();
                    InitialTextAndHint();
                    
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
            lblBouquetCorsage.Text = Resources.Resource.BouquetCorsageString;
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
            lblBridalDress1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString;
            lblBridalDress2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString;
            lblBridalDress3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString;
            lblBridalDress4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString;
            lblBridalDress5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString;
            lblBridalDress6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString;
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
            lblDeposit.Text = Resources.Resource.DepositString + Resources.Resource.PaymentString;
            lblBalanceDue.Text = Resources.Resource.BalanceDueString + Resources.Resource.PaymentString;

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
            tbBouquetCorsage.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BouquetCorsageString);
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
            tbBridalDress1.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString);
            tbBridalDress2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "1" + Resources.Resource.ChooseString);
            tbBridalDress3.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "2" + Resources.Resource.ChooseString);
            tbBridalDress4.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.EveningDressString + "3" + Resources.Resource.ChooseString);
            tbBridalDress5.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString);
            tbBridalDress6.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString);
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
            tbDeposit.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.DepositString + Resources.Resource.PaymentString);
            tbBalanceDue.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BalanceDueString + Resources.Resource.PaymentString);

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
                            , dr["Id"].ToString()));
                    }
                    tvConf.Nodes.Add(conNode);
                }
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
            }
        }
        private void InitialOrderType()
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

        private void ShowErrorMsg(string msg)
        {
            labelWarnString.Text = msg;
            labelWarnString.Visible = !string.IsNullOrEmpty(msg);
        }
        private void TransferToOtherPage()
        {
            Session.Remove("OrderId");
            Server.Transfer("TimeMaintain.aspx", true);
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            string itemId = tvConf.SelectedValue;
            string orderId = Session["OrderId"].ToString();
            if (string.IsNullOrEmpty(itemId)) return;
            bool result = WriteBackData(MsSqlTable.ConferenceInfo, ConferenceItemDbObject(itemId, orderId), orderId, itemId);
            if (!result) return;
            else
            {
                tvConf.SelectedNode.Checked = cbCompleted.Checked;
                WriteBackData(MsSqlTable.OrderInfo, OrderInfoDbObject(itemId), orderId, itemId);
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
                SysProperty.Log.Error(ex.Message);
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
                + ", o.PS_SuitSpC , o.PS_DressSpC"
                + ", o.PS_BModel , o.PS_BModelFocus , o.PS_BSPc , o.PS_GModel , o.PS_GSPc"
                + ", p.IsLegal , p.StayNight , p.Corsage , p.Decoration"
                + ", o.PS_RoutePlan , o.PS_Attractions , o.PS_PhotoItem , o.PS_Avoid , o.PS_PSpecialClaim"
                + ", o.PS_SitePlan , o.PS_BanquetContent , o.PS_Food, o.PS_BanquetGuest , o.PS_BSpecialClaim"
                + ", do.Bust , do.Waist , do.Hips , do.IsCheck , do.IsTry "
                + " FROM[TheWe].[dbo].[OrderInfo] as o"
                + " Left join Consultation as c on c.Id = o.ConsultId"
                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " Left join ProductSet as p on p.Id = o.SetId"
                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                + " Left join WeddingCategory as wc on wc.id=p.WeddingCategory"
                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
                + " Left join DressOrder as do on do.OrderId = o.id"
                + " WHERE o.IsDelete = 0 and o.Id='" + id + "'";
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
                    + " FROM[TheWe].[dbo].[ConferenceInfo] as info"
                    + " Left join ConferenceItem as item on item.Id = info.ItemId"
                    + " Where info.IsDelete=0 " + condStr;
                return SysProperty.GenDbCon.GetDataFromTable(sql);
            }
            catch (Exception ex)
            {
                SysProperty.Log.Error(ex.Message);
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
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return null;
            }
        }
        private DataSet GetWeddingCategory(string id)
        {
            try
            {
                string sql = "Select * From WeddingCategory Where Id = '" + id + "'";
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

        private void SetOrderInfo(string id)
        {
            string cultureCode = Session["CultureCode"].ToString();
            DataSet ds = GetOrderInfo(id);
            if (SysProperty.Util.IsDataSetEmpty(ds)) return;
            DataRow dr = ds.Tables[0].Rows[0];
            tbBridalName.Text = dr["CustomerName"].ToString();

            tbGroomName.Text = dr["PartnerName"].ToString();
            tbProductSet.Text = SysProperty.Util.OutputRelatedLangName(
                cultureCode
                , dr["SetName"].ToString()
                , dr["SetCnName"].ToString()
                , dr["SetEngName"].ToString()
                , dr["SetJpName"].ToString());
            ddlOrderType.SelectedValue = dr["ServiceType"].ToString();
            tbLocation.Text = SysProperty.Util.OutputRelatedLangName(cultureCode, SysProperty.GetChurchById(dr["ChurchId"].ToString()));
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
            tbBouquetCorsage.Text = dr["Corsage"].ToString(); //教堂新娘新郎捧花(照片選擇)
            tbChampagne.Text = dr["PS_Champagne"].ToString();
            tbGuest.Text = dr["PS_Guest"].ToString();
            tbWeddingSequence.Text = dr["PS_WeddingSequence"].ToString();
            tbChurchArrangements.Text = dr["PS_ChurchArrangements"].ToString();
            tbWSp.Text = dr["WSp"].ToString();
            ddlLangPastor.SelectedValue = dr["PS_PastorLanguage"].ToString();

            //1-3
            tbRoutePlan.Text = dr["PS_RoutePlan"].ToString();
            tbPhotoItem.Text = dr["PS_PhotoItem"].ToString();
            //tbPhotoBouquet.Text = dr["Bouquet"].ToString();//教堂新娘新郎捧花(照片選擇)
            tbPhotoAvoid.Text = dr["PS_Avoid"].ToString();
            tbPSp.Text = dr["PS_PSpecialClaim"].ToString();
            tbAttractions.Text = dr["PS_Attractions"].ToString();

            //1-4
            tbBridalDress1.Text = dr["Sn"].ToString(); //從DressOrder那撈
            tbBridalDress2.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalDress3.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalDress4.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalDress5.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalDress6.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalSpecialClaim.Text = dr["PS_DressSpC"].ToString();
            tbGroomDressNum.Text = dr["PS_Suit"].ToString();
            tbGroomSpecialClaim.Text = dr["PS_SuitSpC"].ToString();

            //1-5
            tbSitePlan.Text = dr["PS_SitePlan"].ToString();
            tbDinnerContent.Text = dr["PS_BanquetContent"].ToString();
            tbFood.Text = dr["PS_Food"].ToString();
            tbDinnerGuest.Text = dr["PS_BanquetGuest"].ToString();
            tbBSp.Text = dr["PS_BSpecialClaim"].ToString();


            //2-1
            tbBridalTryDress1.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalTryDress2.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalTryDress3.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalTryDress4.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalTryDress5.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalTryDress6.Text = dr["Sn"].ToString();//從DressOrder那撈

            //2-2
            
            tbBridalHair1.Text = dr["Sn"].ToString(); //從DressOrder那撈
            tbBridalHair2.Text = dr["Sn"].ToString(); //從DressOrder那撈
            tbBridalHair3.Text = dr["Sn"].ToString(); //從DressOrder那撈
            tbBridalHair4.Text = dr["Sn"].ToString(); //從DressOrder那撈
            tbBridalHair5.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalHair6.Text = dr["Sn"].ToString(); //從DressOrder那撈

            tbBridalHairSpecailClaim.Text = dr["PS_BSPc"].ToString();
            tbGroomHair.Text = dr["PS_GModel"].ToString(); 
            tbGroomHairSpecailClaim.Text = dr["PS_GSPc"].ToString(); 
            tbBridalModeling.Text = dr["PS_BModel"].ToString(); 
            tbBridalMakeupEmphasis.Text = dr["PS_BModelFocus"].ToString();
            //3-1
            tbBridalCheckDress1.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalCheckDress2.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalCheckDress3.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalCheckDress4.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalCheckDress5.Text = dr["Sn"].ToString();//從DressOrder那撈
            tbBridalCheckDress6.Text = dr["Sn"].ToString();//從DressOrder那撈


            //3-3
            tbGetDress.Text = dr["Sn"].ToString();//?
            tbDeposit.Text = dr["Sn"].ToString();//?
            tbBalanceDue.Text = dr["Sn"].ToString();//?

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
                        if (tvConf.Nodes[index].ChildNodes[i].Value == nowConf)
                        {
                            tvConf.Nodes[index].ChildNodes[i].Selected = true;
                            tvConf_SelectedNodeChanged(tvConf, new EventArgs());
                        }

                        if (tvConf.Nodes[index].ChildNodes[i].Value == dr["ItemId"].ToString())
                        {
                            tvConf.Nodes[index].ChildNodes[i].Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        protected void tvConf_SelectedNodeChanged(object sender, EventArgs e)
        {
            string id = tvConf.SelectedValue;
            if (string.IsNullOrEmpty(id))
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
                    + " And ItemId = '" + id + "'");
                SetDivByItemId(id);
                if (SysProperty.Util.IsDataSetEmpty(ds))
                {
                    tbOth.Text = string.Empty;
                    tbConDate.Text = string.Empty;
                    cbCompleted.Checked = false;
                }
                else
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    tbOth.Text = dr["Remark"].ToString();
                    tbConDate.Text = SysProperty.Util.ParseDateTime("DateTime", dr["BookingDate"].ToString());
                    cbCompleted.Checked = bool.Parse(dr["IsCheck"].ToString());
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
                "EmployeeId"
                , AtrrTypeItem.String
                , AttrSymbolItem.Equal
                , ((DataRow)Session["AccountInfo"])["Id"].ToString()
                ));
            return lst;
        }

        #endregion

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
                SysProperty.Log.Error(ex.Message);
                ShowErrorMsg(ex.Message);
                return false;
            }
        }

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

        private void SetDivByItemId(string ItemId)
        {
            ResetAllDivControl();
            switch (ItemId)
            {
                case "1e739102-b86d-45db-ba67-3674f8393bb2":
                    divHotel.Visible = true;
                    break;
                case "73b4f75a-26a2-4818-94f7-a8834d2d4a23":
                    divWeddingInfo.Visible = true;
                    break;
                case "efef815c-cac3-4ea5-9e8e-e83138f56272":
                    divTakePicture.Visible = true;
                    break;
                case "25536c21-df26-4986-bda1-8b3dd187f4e8":
                    divChooseDress.Visible = true;
                    break;
                case "2d9983e0-8a96-473a-a492-8c68df58a63b":
                    divDinner.Visible = true;
                    break;
                case "947fe231-4bb0-4790-841f-04a16c7def3a":
                    divTryDress.Visible = true;
                    break;
                case "095eca7c-2b6f-4d78-9eae-676acf064a9b":
                    divModelCheck.Visible = true;
                    break;
                case "f3aa0079-0896-4816-9db0-5abb66f1aac1":
                    divCehckDress.Visible = true;
                    break;
                case "735dd34b-70f5-4361-a28f-f443f3ad6d1d":
                    divGetDress.Visible = true;
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
    }



}