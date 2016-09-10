<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="TheWeWebSite.Header" %>
<header id="header">
    <div>
        <asp:ScriptManager runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <h1>
                    <asp:Label runat="server" Text="台北" ID="labelStoreName" Font-Size="Larger" Font-Bold="true"></asp:Label>
                    <asp:LinkButton runat="server" ForeColor="Red" Style="margin-left: 20px;" Font-Size="Medium" Font-Underline="true" ID="linkCaseReminder" OnClick="linkCaseReminder_Click" />
                    <asp:LinkButton runat="server" ForeColor="Red" Style="margin-left: 5px;" Font-Size="Medium" Font-Underline="true" ID="LinkAdvisoryReminder" OnClick="LinkAdvisoryReminder_Click" />
                </h1>
            </ContentTemplate>
        </asp:UpdatePanel>
        <nav id="nav">
            <ul>
                <li>
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,WorkReminderString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="linkWorkReminder" />
                    <ul>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkConsultMgt" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkOrderMgt" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMgt" />
                        </li>
                    </ul>
                </li>
                <li runat="server" id="liMainFunction">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,MainPageString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkMain" />
                    <ul>
                        <li>

                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ConsultScheduleString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkUnsigned" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ContractScheduleString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkCase" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ScheduleString%>" PostBackUrl="~/Main/Calendar.aspx" ID="LinkCalendar" />
                        </li>
                        <!--<li>
                                    <asp:LinkButton CausesValidation="false"  runat="server" Text="<%$ Resources:Resource,CustomerScheduleString%>" PostBackUrl="~/Main/CustomerCalendar.aspx" ID="LinkCustomerCalendar" />
                                </li>-->
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,LocationReservationString%>" PostBackUrl="~/Main/ChurchReservation.aspx" ID="LinkChurchReservtion" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,DressRentString%>" PostBackUrl="~/Main/DressRentMaintain.aspx" ID="LinkDressTimeMaintain" />
                        </li>
                    </ul>
                </li>
                <li runat="server" id="liStoreMgt">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,StoreMgtString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkItemMaintain" />
                    <ul>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ProductMaintainString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkProductMgt" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,DressMaintainString%>" PostBackUrl="~/StoreMgt/DressMaintain.aspx" ID="LinkDressMaintain" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,AccessoryMaintainString%>" PostBackUrl="~/StoreMgt/FittingMaintain.aspx" ID="LinkFittingMaintain" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,StyleMaintainString%>" PostBackUrl="~/StoreMgt/ModelingMaintain.aspx" ID="LinkModelingMaintain" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,WeddingItemMaintainString%>" PostBackUrl="~/StoreMgt/OtherItemMaintain.aspx" ID="LinkOtherItemMaintain" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ChurchMaintainString%>" PostBackUrl="~/StoreMgt/ChurchMaintain.aspx" ID="LinkChurchMaintain" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,EmployeeMaintainString%>" PostBackUrl="~/StoreMgt/EmployeeMaintain.aspx" ID="LinkEmployeeMaintain" />
                        </li>

                    </ul>
                </li>
                <li runat="server" id="liOrderMgt">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,OrderMgtString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkCaseMgt" />
                    <ul>

                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkButton1" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/CaseMgt/CaseMaintain.aspx" ID="LinkCaseMaintain" />
                        </li>
                        <!--
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,CustomerMaintainString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCustomerMaintain" />
                        </li>-->
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMaintain" />
                        </li>
                    </ul>
                </li>
                <li runat="server" id="liPurchaseMgt" style="display: none;">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>" ID="LinkPuchaseMgt" />
                </li>
                <li runat="server" id="liSalesMgt" style="display: none;">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,SalesMgtString%>" ID="LinkSalesMgtString" />
                </li>
                <li runat="server" id="liFinMgt" style="display: none;">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,FinMgtString%>" ID="LinkFinMgt" />
                </li>
                <li runat="server" id="liSysMgt">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,SysMgtString%>" ID="LinkSysMgt" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                    <ul>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,LoginMaintainString%>" ID="LinkLoginMaintain" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,PermissionCategoryString%>" ID="LinkRootMaintain" PostBackUrl="~/SysMgt/RootMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,CasePermissionMgtString%>" ID="LinkCaseRootMaintain" PostBackUrl="~/SysMgt/CaseRootMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,SNSMgtString%>" ID="LinkMsgMaintain" PostBackUrl="~/SysMgt/MsgMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,CountryString%>" ID="LinkCountryMaintain" PostBackUrl="~/SysMgt/CountryMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,AreaString%>" ID="LinkAreaMaintain" PostBackUrl="~/SysMgt/AreaMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,StoreString%>" ID="LinkStoreMaintain" PostBackUrl="~/SysMgt/StoreMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,UnitString%>" ID="LinkUnitMaintain" PostBackUrl="~/SysMgt/UnitMaintain.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,CurrencyString%>" ID="LinkDollarMaintain" PostBackUrl="~/SysMgt/DollarMaintain.aspx" />
                        </li>
                    </ul>
                </li>
                <li runat="server" id="li1">
                    <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,SettingString%>" ID="btnSetting" PostBackUrl="~/Setting/AccInfoSetting.aspx" />
                    <ul>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,AccountSettingString%>" ID="btnAccSetting" PostBackUrl="~/Setting/AccInfoSetting.aspx" />
                        </li>
                        <li>
                            <asp:LinkButton CausesValidation="false" runat="server" Text="<%$ Resources:Resource,LogoutString%>" ID="btnLogout" OnClick="btnLogout_Click" />
                        </li>
                    </ul>
                </li>
            </ul>
        </nav>
        <br />
        <div>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>

                    <asp:Timer runat="server" ID="Timer1" OnTick="Timer1_Tick" Interval="3600000" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />

</header>
