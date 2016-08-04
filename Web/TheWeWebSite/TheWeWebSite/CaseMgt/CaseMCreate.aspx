<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CaseMCreate" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../assets/css/datePicker.css" rel="stylesheet" />

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
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AdviosryIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbAdvisorySn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CaseIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCaseSn"></asp:TextBox>
                        </div>


                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MemberIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCustomerSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbContractTime"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                            </div>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AppointmentDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbAppointDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractCloseDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbCloseDay"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlOrderType" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlOrderType_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlArea" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlLocate" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlLocate_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlProductSet" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlProductSet_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalBdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbBridalBday"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalCommunicationTypeString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlBridalMsgerType" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalCommunicationIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalMsgerId"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNicknameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalNickname"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalPassportString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalPassportName"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomBdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbGroomBday"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomCommunicationTypeString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlGroomMsgerType" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomCommunicationIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomMsgerId"></asp:TextBox>
                        </div>


                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNicknameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomNickname"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomPassportString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomPassportName"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AddressString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbAddress"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRemark"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ReferralsString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbReferrals"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPhone" Style="text-align: right"></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnsTitleString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbMsgerTitle"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,OverseaWeddingDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbOverseaWeddingDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,OverseaWddingFilmingDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbOverSeaWedFilmDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticWeddingFilmingDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbDomesticWedFilmDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticEngagementDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbDomesticEngagementDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticWeddingDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbDomesticWeddingDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticMotheringDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbDomesticMotheringDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticWeddingReceptionDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbDomesticWeddReceptionDate"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbContractPrice" Style="text-align: right"
                                        OnTextChanged="tbContractPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbContractPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DiscountString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbDiscount" Style="text-align: right"
                                        OnTextChanged="tbDiscount_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbDiscount" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TotalPriceString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbTotalPrice" Style="text-align: right"
                                        OnTextChanged="tbTotalPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbTotalPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="訂金"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbDeposit1" Style="text-align: right"
                                        OnTextChanged="tbDeposit1_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbDeposit1" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="二次付款"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbDeposit2" Style="text-align: right"
                                        OnTextChanged="tbDeposit2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="tbDeposit2" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="尾款"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbPayOff" Style="text-align: right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="tbPayOff" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="訂金付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbDeposit1Date"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="二次付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbDeposit2Date"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="尾款付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbPayOffDate"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <!-- 照片 -->
                        <div class="row no-collapse 50% uniform">
                            <div class="5u">
                                <div style="text-align: center">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoString%>"></asp:Label>
                                    <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                                </div>
                                <span class="image fit">
                                    <asp:Image runat="server" ID="ImgFront" />
                                </span>
                                <div style="margin-bottom: 1.5em">
                                    <asp:FileUpload ID="ImgUpload" runat="server" />
                                </div>
                                <div class="align-center">
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload" OnClick="btnUpload_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
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
                                                <asp:TextBox ID="tbNumber" runat="server"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                            <ItemTemplate>
                                                <asp:TextBox ID="tbPrice" runat="server" OnTextChanged="tbPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
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
        <!-- datepicker -->
        <script src="../assets/js/datepicker.js"></script>
        <script src="../assets/js/jquery-1.10.2.js"></script>
        <script src="../assets/js/jquery-ui.js"></script>
        <!-- datepicker -->
        <script src="../assets/js/picker.js"></script>
    </form>
</body>
</html>
