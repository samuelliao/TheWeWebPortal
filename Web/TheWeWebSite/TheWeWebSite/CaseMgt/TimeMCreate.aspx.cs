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

        private void InitiallblText()
        {
            //1-1
            lblHotelName.Text = Resources.Resource.HotelString+"1" + Resources.Resource.NameString;
            lblHotelCnName.Text = Resources.Resource.HotelString + "1" + Resources.Resource.CnNameString;
            lblHotelEngName.Text = Resources.Resource.HotelString + "1" + Resources.Resource.EnglishNameString;
            lblHotelJpName.Text = Resources.Resource.HotelString + "1" + Resources.Resource.JpNameString;
            lblHotelAddr.Text = Resources.Resource.HotelString + "1" + Resources.Resource.AddressString;
            lblHotelName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.NameString;
            lblHotelCnName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.CnNameString;
            lblHotelEngName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.EnglishNameString;
            lblHotelJpName2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.JpNameString;
            lblHotelAddr2.Text = Resources.Resource.HotelString + "2" + Resources.Resource.AddressString;
            lblTravelPeriod.Text = Resources.Resource.TravelPeriodString;
            lblStayNight.Text = Resources.Resource.StayNightString;
            lblFlight.Text = Resources.Resource.FlightString;
            lblContact.Text = Resources.Resource.ContactString;


            //1-2
            lblWeddingStyle.Text = Resources.Resource.WeddingStyleString;
            lblLegalWedding.Text = Resources.Resource.LegalWeddingString;
            lblPastorLanguage.Text = Resources.Resource.PastorString+ Resources.Resource.LanguageString;
            lblWelcomeCard.Text = Resources.Resource.WelcomeCardString;
            lblBouquetCorsage.Text = Resources.Resource.BouquetCorsageString;
            lblChampagne.Text = Resources.Resource.ChampagneString;
            lblGuest.Text = Resources.Resource.GuestString;
            lblWeddingSequence.Text = Resources.Resource.WeddingSequenceString;
            lblChurchArrangements.Text = Resources.Resource.ChurchArrangementsString;
            lblAdditionService.Text = Resources.Resource.AdditionServiceString;

            //1-3
            lblRoutePlan.Text = Resources.Resource.RoutePlanString;
            lblPhotoItem.Text = Resources.Resource.PhotoItemString;
            lblPhotoBouquet.Text = Resources.Resource.PhotoBouquetString;
            lblPhotoSpecialClaim.Text = Resources.Resource.PhotoSpecialClaimString;
            lblPhotoAvoid.Text = Resources.Resource.PhotoAvoidString;

            //1-4
            lblBridalDress1.Text = Resources.Resource.BridalString + Resources.Resource.WhiteDressString + Resources.Resource.ChooseString;
            lblBridalDress2.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString+"1" + Resources.Resource.ChooseString;
            lblBridalDress3.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString+"2" + Resources.Resource.ChooseString;
            lblBridalDress4.Text = Resources.Resource.BridalString + Resources.Resource.EveningDressString+"3" + Resources.Resource.ChooseString;
            lblBridalDress5.Text = Resources.Resource.BridalString + Resources.Resource.BathrobeString + Resources.Resource.ChooseString;
            lblBridalDress6.Text = Resources.Resource.BridalString + Resources.Resource.KimonoString + Resources.Resource.ChooseString;
            lblBridalSpecialClaim.Text = Resources.Resource.BridalString + Resources.Resource.DressString + Resources.Resource.SpecialClaimString;
            lblGroomDressNum.Text = Resources.Resource.GroomString+Resources.Resource.SuitString + Resources.Resource.NumberString;
            lblGroomSpecialClaim.Text = Resources.Resource.GroomString + Resources.Resource.SuitString + Resources.Resource.SpecialClaimString;

            //1-5
            lblSitePlan.Text = Resources.Resource.SitePlanString;
            lblDinnerContent.Text = Resources.Resource.BanquetContentString;
            lblFood.Text = Resources.Resource.FoodString;
            lblDinnerGuest.Text = Resources.Resource.BanquetPeopleString;
            lblAdditionClaim.Text = Resources.Resource.AdditionServiceString;


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
            lblDeposit.Text = Resources.Resource.DepositString+Resources.Resource.PaymentString;
            lblBalanceDue.Text = Resources.Resource.BalanceDueString+Resources.Resource.PaymentString;

            //Oth
            lblOth.Text = Resources.Resource.RemarkString;

        }
        private void InitialtbPlaceHolder()
        {
            //1-1
            tbHotelName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.NameString);
            tbHotelCnName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.CnNameString);
            tbHotelEngName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.EnglishNameString);
            tbHotelJpName.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.JpNameString);
            tbHotelAddr.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "1" + Resources.Resource.AddressString);
            tbHotelName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.NameString);
            tbHotelCnName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.CnNameString);
            tbHotelEngName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.EnglishNameString);
            tbHotelJpName2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.JpNameString);
            tbHotelAddr2.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.HotelString + "2" + Resources.Resource.AddressString);
            tbTravelPeriod.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.TravelPeriodString);
            tbStayNight.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.StayNightString);
            tbFlight.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.FlightString);
            tbContact.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ContactString);


            //1-2
            tbWeddingStyle.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WeddingStyleString);
            tbLegalWedding.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.LegalWeddingString);
            tbPastorLanguage.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PastorString + Resources.Resource.LanguageString);
            tbWelcomeCard.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WelcomeCardString);
            tbBouquetCorsage.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.BouquetCorsageString);
            tbChampagne.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ChampagneString);
            tbGuest.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.GuestString);
            tbWeddingSequence.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.WeddingSequenceString);
            tbChurchArrangements.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.ChurchArrangementsString);
            tbAdditionService.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AdditionServiceString);

            //1-3
            tbRoutePlan.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.RoutePlanString);
            tbPhotoItem.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoItemString);
            tbPhotoBouquet.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoBouquetString);
            tbPhotoSpecialClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.PhotoSpecialClaimString);
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
            tbAdditionClaim.Attributes.Add("placeholder", Resources.Resource.AddString + Resources.Resource.AdditionServiceString);


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
            divCehckDress.Visible = true;
            divChooseDress.Visible = true;
            divDinner.Visible = true;
            divGetDress.Visible = true;
            divHotel.Visible = true;
            divModelCheck.Visible = true;
            divTakePicture.Visible = true;
            divTryDress.Visible = true;
            divWeddingInfo.Visible = true;
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
        private DataSet GetOrderInfo(string id)
        {
            try
            {
                string sql = "SELECT o.[Id] as Id,[ConsultId], c.Sn As ConsultSn,o.[Sn],o.[StartTime]"
                + ",o.[CustomerId],cus.Name AS CustomerName,o.[ConferenceCategory], ci.Name As StatusName, ci.JpName AS StatusJpName"
                + ", cus.EngName AS CustomerEngName, pr.EngName AS PartnerEngName, cus.Phone As CustomerPhone, pr.Phone AS PartnerPhone"
                + ", ci.CnName AS StatusCnName, ci.EngName AS StatusEngName,[CloseTime],o.[CountryId],o.[AreaId]"
                + ", o.[ChurchId],SetId, p.Name AS SetName, p.EngName AS SetEngName, o.ServiceType"
                + ", o.[OverseaFilmDate], o.[OverseaWeddingDate], o.[LocalFilmingDate], o.[LocalWeddingDate]"
                + ", p.JpName AS SetJpName, p.CnName AS SetCnName,o.BookingDate,o.PartnerId, pr.Name AS PartnerName"
                + ", p.WeddingCategory"
                + " FROM[TheWe].[dbo].[OrderInfo] as o"
                + " Left join Consultation as c on c.Id = o.ConsultId"
                + " Left join vwEN_Customer as cus on cus.Id = o.CustomerId"
                + " Left join ProductSet as p on p.Id = o.SetId"
                + " Left join ConferenceItem as ci on ci.Id = o.ConferenceCategory"
                + " Left join vwEN_Partner as pr on pr.Id = o.PartnerId"
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
                tbRemark.Enabled = false;
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
                tbRemark.Enabled = false;
                btnModify.Enabled = false;
            }
            else
            {
                tbConDate.Enabled = !cbIsClose.Checked;
                cbCompleted.Enabled = !cbIsClose.Checked;
                tbRemark.Enabled = !cbIsClose.Checked;
                btnModify.Enabled = !cbIsClose.Checked;
                DataSet ds = GetConferenceList(
                    " And OrderId = '" + Session["OrderId"].ToString() + "'"
                    + " And ItemId = '" + id + "'");
                if (SysProperty.Util.IsDataSetEmpty(ds))
                {
                    tbRemark.Text = string.Empty;
                    tbConDate.Text = string.Empty;
                    cbCompleted.Checked = false;
                }
                else
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    tbRemark.Text = dr["Remark"].ToString();
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
                , tbRemark.Text
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
                case "CI1005":
                    divHotel.Visible = true;
                    break;
                case "CI1006":
                    divWeddingInfo.Visible = true;
                    break;
                case "CI1007":
                    divTakePicture.Visible = true;
                    break;
                case "CI1008":
                    divChooseDress.Visible = true;
                    break;
                case "CI1009":
                    divDinner.Visible = true;
                    break;
                case "CI2011":
                    divTryDress.Visible = true;
                    break;
                case "CI2012":
                    divModelCheck.Visible = true;
                    break;
                case "CI3015":
                    divCehckDress.Visible = true;
                    break;
                case "CI3017":
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