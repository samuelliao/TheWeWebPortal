<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ChurchMaintain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body class="landing">
    <form runat="server">
        <div id="page-wrapper">

            <!-- Header -->
            <header id="header">
                <h1>
                    <asp:Label runat="server" Text="台北"></asp:Label></h1>

                <nav id="nav">
                    <ul>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WorkReminderString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="linkWorkReminder" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkConsultMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkOrderMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMgt" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,MainPageString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkMain" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkUnsigned" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractScheduleString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkCase" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ScheduleString%>" PostBackUrl="~/Main/Calendar.aspx" ID="LinkCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerScheduleString%>" PostBackUrl="~/Main/CustomerCalendar.aspx" ID="LinkCustomerCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LocationReservationString%>" PostBackUrl="~/Main/ChurchReservation.aspx" ID="LinkChurchReservtion" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StoreMgtString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkItemMaintain" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ProductMaintainString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkProductMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,DressMaintainString%>" PostBackUrl="~/StoreMgt/DressMaintain.aspx" ID="LinkDressMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,AccessoryMaintainString%>" PostBackUrl="~/StoreMgt/FittingMaintain.aspx" ID="LinkFittingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StyleMaintainString%>" PostBackUrl="~/StoreMgt/ModelingMaintain.aspx" ID="LinkModelingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WeddingItemMaintainString%>" PostBackUrl="~/StoreMgt/OtherItemMaintain.aspx" ID="LinkOtherItemMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ChurchMaintainString%>" PostBackUrl="~/StoreMgt/ChurchMaintain.aspx" ID="LinkChurchMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,EmployeeMaintainString%>" PostBackUrl="~/StoreMgt/EmployeeMaintain.aspx" ID="LinkEmployeeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,OrderMgtString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCaseMgt" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerMaintainString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCustomerMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkButton1" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/CaseMgt/CaseMaintain.aspx" ID="LinkCaseMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SearchMgtString%>" ID="LinkSearchMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>" ID="LinkPuchaseMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SalesMgtString%>" ID="LinkSalesMgtString" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,FinMgtString%>" ID="LinkFinMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SysMgtString%>" ID="LinkSysMgt" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LoginMaintainString%>" ID="LinkLoginMaintain" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PermissionCategoryString%>" ID="LinkRootMaintain" PostBackUrl="~/SysMgt/RootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CasePermissionMgtString%>" ID="LinkCaseRootMaintain" PostBackUrl="~/SysMgt/CaseRootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SNSMgtString%>" ID="LinkMsgMaintain" PostBackUrl="~/SysMgt/MsgMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CurrencyString%>" ID="LinkDollarMaintain" PostBackUrl="~/SysMgt/DollarMaintain.aspx" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LogoutString%>" ID="LinkLogout" PostBackUrl="~/Login.aspx" />
                        </li>
                    </ul>
                </nav>
            </header>

            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <p>
                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreMgtString%>"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <header class="major">
                                <h3>
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ChurchMaintainString%>"></asp:Label></h3>
                                <hr />
                            </header>
                            <!-- Input -->

                            <div class="row">
                                <div class="12u">

                                    <div class="row uniform 50%">
                                        <div class="6u 12u(mobilep)">
                                            <div class="select-wrapper">
                                                <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                            </div>

                                        </div>
                                        <div class="6u 12u(mobilep)">
                                            <div class="select-wrapper">
                                                <asp:DropDownList runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row uniform 50%">
                                        <div class="6u 12u(mobilep)">
                                            <div class="select-wrapper">
                                                <asp:DropDownList runat="server" ID="ddlChruch" OnSelectedIndexChanged="ddlChruch_SelectedIndexChanged" AutoPostBack="true" />
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row uniform 50%">
                                        <div class="12u">
                                            <textarea name="message" id="message" placeholder="備註..." rows="6"></textarea>
                                        </div>
                                    </div>

                                    <div class="row uniform">
                                        <div class="12u">
                                            <ul class="actions">
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                                        ID="btnSearch" OnClick="btnSearch_Click" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="清除" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" />
                                                </li>
                                            </ul>
                                        </div>
                                    </div>

                                    <hr />
                                </div>
                            </div>
                            <!-- Table -->

                            <div class="row">
                                <div class="12u">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SearchResultString%>" />
                                    <hr />
                                    <div class="table-wrapper">
                                        <asp:GridView runat="server" ID="gvChurch" CssClass="alt" AllowPaging="true"
                                             AllowSorting ="true">
                                            <
                                            <Columns>
                                                
                                            </Columns>
                                        </asp:GridView>
                                        <asp:DataGrid runat="server" ID="dgChurch" CssClass="alt" AllowPaging="true"
                                            AllowSorting="true" OnEditCommand="dgChurch_EditCommand" OnCancelCommand="dgChurch_CancelCommand"
                                            OnDeleteCommand="dgChurch_DeleteCommand" OnPageIndexChanged="dgChurch_PageIndexChanged"
                                            OnUpdateCommand="dgChurch_UpdateCommand" AutoGenerateColumns="false" OnItemDataBound="dgChurch_ItemDataBound">
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <FooterStyle BackColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <Columns>
                                                <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false" />
                                                <asp:BoundColumn HeaderText="CountryId" DataField="CountryId" Visible="false" />
                                                <asp:BoundColumn HeaderText="AreaId" DataField="AreaId" Visible="false" />                                                 
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="dgDdlCountry" OnSelectedIndexChanged="dgDdlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="dgLabelCountry" Text="" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="dgDdlArea" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="dgLabelArea" Text="" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,NameString%>" DataField="Name" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,CnNameString%>" DataField="CnName" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,EngNameString%>" DataField="EngName" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,JpNameString%>" DataField="JpName" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,CapacitiesString%>" DataField="Capacities" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,PriceString%>" DataField="Price" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,RemarkString%>" DataField="Remark">                                                    
                                                </asp:BoundColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,MealString%>" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Image runat="server" ID="ImgMealUpload" />
                                                        <asp:FileUpload ID="fileImgMeal" runat="server" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image runat="server" ID="ImgMeal" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,PhotoString%>" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:Image runat="server" ID="imgChurchUpload" />
                                                        <asp:FileUpload runat="server" ID="fileImgChurch" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Image runat="server" ID="imgChurch1" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:EditCommandColumn EditText="<%$ Resources:Resource,ModifyString%>"
                                                    CancelText="<%$ Resources:Resource,CancelString%>"
                                                    UpdateText="<%$ Resources:Resource,UpdateString%>"
                                                    HeaderText="<%$ Resources:Resource,ModifyString%>" />
                                                <asp:ButtonColumn CommandName="Delete"
                                                    HeaderText="<%$ Resources:Resource,DeleteString%>"
                                                    Text="<%$ Resources:Resource,DeleteString%>" />
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                    <hr />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </section>


            </section>

            <!-- CTA -->


            <!-- Footer -->
            <footer id="footer">
                <ul class="copyright">
                    <li>rights.</li>
                    <li>The We Wedding</li>
                </ul>
            </footer>

        </div>

        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
        <script src="../assets/js/table.js"></script>
    </form>
</body>
</html>
