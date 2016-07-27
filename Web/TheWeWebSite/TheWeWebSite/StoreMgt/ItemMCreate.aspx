<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ItemMCreate" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->
        <My:Header runat="server" ID="ucHeader" />
        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbName" />
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CnNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCnName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EnglishNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEngName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,JpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbJpName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCategory" />
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">                        
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingStyleString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlWeddingType" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlLocate" OnSelectedIndexChanged="ddlLocate_SelectedIndexChanged" AutoPostBack="true" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalMakeupString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbBridalHairStyle"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomMakeupString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbGroomHairStyle"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">                        
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,FilmingTimeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbFilmTime" style="text-align:right"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,FilmingLocationString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbFilmLocation"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TransportationString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbMovemont"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoNumberString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbPhotoNumber" style="text-align:right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbPhotoNumber" runat="server"
                                 ErrorMessage="Only Numbers allowed" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StayNightString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbStay" style="text-align:right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbStay" runat="server"
                                 ErrorMessage="Only Numbers allowed" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RoomTypeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbRoom"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">                        
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BouquetCorsageString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbCorsage"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StaffString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStaff" />
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ChurchArrangementsString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbDecorate"></asp:TextBox>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingPerformanceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPerformence"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCost" style="text-align:right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbCost" runat="server" 
                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TotalPriceString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbPrice" style="text-align:right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbPrice" runat="server" 
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                    </div>
                </div>

                <div>
                    <div class="row uniform 50%">
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,ChurchFeeString%>" ID="cbChurchCost" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,PastorString%>" ID="cbPastor" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,WeddingCertificateString%>" ID="cbCertificate" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,RingPillowString%>" ID="cbPillow" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,WeddingPensString%>" ID="cbPen" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,LoungeString%>" ID="cbLounge" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,DressIroningString%>" ID="cbIroning" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,MeetingString%>" ID="cbMeeting" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,BreakfastString%>" ID="cbBreakfast" />

                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,LunchString%>" ID="cbLunch" />

                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,CandlelightDinnerString%>" ID="cbDinner" />

                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,WeddingRehersalString%>" ID="cbRehersal" />

                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,LegalWeddingString%>" ID="cbLegal" />
                        </div>
                    </div>
                </div>

            </div>

            <!-- Table -->

            <div style="margin-top: 1.5em">
                <div class="12u">
                    <div class="table-wrapper">
                        <asp:Label runat="server" ID="labelTitle" Text="<%$ Resources:Resource,AdditionalItemString%>" />
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgServiceItem" runat="server"
                                    ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="dgServiceItem_RowDataBound"
                                    OnRowDeleting="dgServiceItem_RowDeleting" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemString%>">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlServiceItem" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NumberString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbNumber" style="text-align:right" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbPrice" runat="server" style="text-align:right"
                                                    OnTextChanged="tbPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button ID="btnAddRow" runat="server"
                                                    Text="Add New Row" OnClick="btnAddRow_Click" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" />
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
                    </li>
                </ul>
            </div>
        </section>

        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
    </form>

</body>
</html>
