<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ItemMCreate" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
        <link href="../assets/css/datePicker.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->
        <section class="box title CreatePage">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStore" Enabled="false" />
                            <asp:Label runat="server" ID="labelBaseId" Visible="false" />
                            <asp:Label runat="server" ID="labelUpdateTime" Visible="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Enabled="false" ID="tbSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>" ></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbName" CssClass="required" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="tbName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CnNameString%>" ></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCnName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EnglishNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEngName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,JpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbJpName" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCategory" CssClass="required" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCategory" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingStyleString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlWeddingType" CssClass="required" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlWeddingType" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required"  runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlCountry" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required"  runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlArea" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required"  runat="server" ID="ddlLocate" OnSelectedIndexChanged="ddlLocate_SelectedIndexChanged" AutoPostBack="true" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlLocate" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalMakeupString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalHairStyle"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomMakeupString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomHairStyle"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,FilmingTimeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Cssclass="date date-1"  ID="tbFilmTime" Style="text-align: right"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,FilmingLocationString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbFilmLocation"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TransportationString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbMovemont"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoNumberString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPhotoNumber" Style="text-align: right"></asp:TextBox>
                            <asp:RegularExpressionValidator
                                Display="Dynamic"
                                ID="RegularExpressionValidator1" ControlToValidate="tbPhotoNumber" runat="server"
                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+" CssClass="error"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StayNightString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbStay" Style="text-align: right"></asp:TextBox>
                            <asp:RegularExpressionValidator
                                CssClass="error"
                                Display="Dynamic"
                                ID="RegularExpressionValidator2" ControlToValidate="tbStay" runat="server"
                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>



                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RoomTypeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRoom"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BouquetCorsageString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCorsage"></asp:TextBox>
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
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
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
                            <asp:TextBox runat="server" ID="tbCost" Style="text-align: right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbCost" runat="server"
                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"
                                CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="12u">
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
               
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="10u 12u(mobilep)">
                            <div class="Div" style="padding-top: 20px">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TotalPriceString%>"></asp:Label>
                            </div>

                            <div runat="server" id="divForStore" visible="false">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="tbPrice" Style="text-align: right"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbPrice" runat="server"
                                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div runat="server" id="divForHoldingCompany" visible="false" style="overflow-y: auto; height: 300px">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView runat="server" ID="PriceTable" DataKeyNames="Id"
                                            AutoGenerateColumns="False" OnRowDataBound="PriceTable_RowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="Id" Visible="false" />
                                                <asp:BoundField HeaderText="<%$ Resources:Resource,ItemString%>" DataField="StoreLv" />
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemString%>">
                                                    <ItemTemplate>
                                                        <asp:TextBox runat="server" ID="tbStorePrice" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="tbStorePrice" runat="server"
                                                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <!-- Table -->

            <div style="margin-top: 1.5em">
                <div class="12u">
                    <div class="table-wrapper">
                        <asp:Label runat="server" ID="labelTitle" Text="<%$ Resources:Resource,ChurchAdditionalItemString%>" />
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgChurchServiceItem" runat="server"
                                    ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="dgChurchServiceItem_RowDataBound"
                                    OnRowDeleting="dgChurchServiceItem_RowDeleting" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemString%>">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlServiceItem" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NumberString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbNumber" Style="text-align: right" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbPrice" runat="server" Style="text-align: right"
                                                    OnTextChanged="tbPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button ID="btnAddRowChurchServiceItem" runat="server"
                                                    Text="Add New Row" OnClick="btnAddRowChurchServiceItem_Click" />
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
            <div style="margin-top: 1.5em">
                <div class="12u">
                    <div class="table-wrapper">
                        <asp:Label runat="server" ID="label1" Text="<%$ Resources:Resource,CustomAdditionalItemString%>" />
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="dgCutomServiceItem" runat="server"
                                    ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="dgCutomServiceItem_RowDataBound"
                                    OnRowDeleting="dgCutomServiceItem_RowDeleting" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,ItemString%>">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlServiceItem" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NumberString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbNumber" Style="text-align: right" runat="server" ></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbPrice" runat="server" Style="text-align: right"
                                                    OnTextChanged="tbPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterStyle HorizontalAlign="Right" />
                                            <FooterTemplate>
                                                <asp:Button ID="btnAddRowCutomServiceItem" runat="server"
                                                    Text="Add New Row" OnClick="btnAddRowCutomServiceItem_Click" />
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
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" CausesValidation="False" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" CausesValidation="False" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" CausesValidation="False"  />
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
        <script src="../assets/js/picker.js"></script>
    </form>

</body>
</html>
