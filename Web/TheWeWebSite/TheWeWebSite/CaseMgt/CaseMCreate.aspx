<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseMCreate.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="TheWeWebSite.CaseMgt.CaseMCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />

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
            <cc1:TabContainer runat="server">
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <asp:Label runat="server" Text="<%$ Resources:Resource,BasicInfoString%>"></asp:Label>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="panelBasicInfo">
                            <div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,AdviosryIdString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" Enabled="false" ID="tbAdvisorySn"></asp:TextBox>
                                            <asp:DropDownList runat="server" ID="ddlStore" Style="display: none" />
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,CaseIdString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox CssClass="required" runat="server" ID="tbCaseSn"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                        ControlToValidate="tbCaseSn" runat="server"
                                                        ErrorMessage="required"
                                                        CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <asp:Label runat="server" ID="tbSysSn" Visible="false"></asp:Label>
                                        </div>


                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,MemberIdString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" Enabled="false" ID="tbCustomerSn"></asp:TextBox>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                            </div>
                                            <asp:DropDownList CssClass="required" runat="server" ID="ddlStatus" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlStatus" runat="server"
                                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractDateString%>"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox runat="server" Style="text-align: right" ID="tbContractTime" Enabled="false"
                                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,AppointmentDateString%>"></asp:Label>
                                            </div>
                                            <div>
                                                <asp:TextBox runat="server" Style="text-align: right" ID="tbAppointDate"
                                                    CssClass="date date-1 required" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                                    ControlToValidate="tbAppointDate" runat="server"
                                                    ErrorMessage="required"
                                                    CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbCloseDay" Enabled="false"
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
                                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlOrderType" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlOrderType_SelectedIndexChanged" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlOrderType" runat="server"
                                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>

                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlCountry" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="ddlCountry" runat="server"
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
                                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlArea" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlArea" runat="server"
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
                                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlLocate" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlLocate_SelectedIndexChanged" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlLocate" runat="server"
                                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlProductSet" AutoPostBack="true"
                                                        OnSelectedIndexChanged="ddlProductSet_SelectedIndexChanged" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlProductSet" runat="server"
                                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                            <asp:TextBox CssClass="required" runat="server" ID="tbBridalName"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                                                ControlToValidate="tbBridalName" runat="server"
                                                ErrorMessage="required"
                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalPhoneString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbBridalPhone"></asp:TextBox>

                                        </div>
                                        <div class="4u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalEmailString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbBridalEmail"></asp:TextBox>

                                        </div>
                                    </div>
                                </div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox CssClass="required" runat="server" ID="tbGroomName"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                                                ControlToValidate="tbGroomName" runat="server"
                                                ErrorMessage="required"
                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>

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
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomPhoneString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbGroomPhone"></asp:TextBox>
                                        </div>
                                        <div class="4u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomEmailString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbGroomEmail"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="4u 12u(mobilep)">
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
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,CurrencyString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList runat="server" ID="ddlCurrency" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox CssClass="required" runat="server" ID="tbContractPrice" Style="text-align: right"
                                                        OnTextChanged="tbContractPrice_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="tbContractPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
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
                                                    <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbDiscount" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,TotalPriceString%>"></asp:Label>
                                            </div>
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox CssClass="required" runat="server" ID="tbTotalPrice" Style="text-align: right"></asp:TextBox>
                                                    <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="tbTotalPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </div>
                                    </div>
                                </div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <!-- 照片 -->
                                        <div class="row no-collapse 20% uniform" style="position: fixed; bottom: 0px;">
                                            <div class="5u 12u(mobilep)">
                                                <div style="text-align: center">
                                                    <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                                                </div>
                                                <span class="image fit">
                                                    <asp:Image runat="server" ID="ImgFront" />
                                                </span>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div style="margin-top: 1.5em" class="serch">
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
                                                                <asp:DropDownList runat="server" ID="ddlServiceItem" AutoPostBack="true" OnSelectedIndexChanged="ddlServiceItem_SelectedIndexChanged" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,NumberString%>">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="tbNumber" runat="server" Style="text-align: right"></asp:TextBox>
                                                                <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="tbNumber" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyString%>">
                                                            <ItemTemplate>
                                                                <asp:Label ID="tbCurrency" Style="text-align: right" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="tbPrice" runat="server" OnTextChanged="tbPrice_TextChanged" Style="text-align: right" AutoPostBack="true"></asp:TextBox>
                                                                <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator4" ControlToValidate="tbPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                                            </ItemTemplate>
                                                            <FooterStyle HorizontalAlign="Right" />
                                                            <FooterTemplate>
                                                                <asp:Button CausesValidation="false"
                                                                    ID="btnAddRow" runat="server"
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
                        </asp:Panel>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server" ID="tabBalanceOfPayment">
                    <HeaderTemplate>
                        <asp:Label runat="server" Text="<%$ Resources:Resource,IncomeDetailString%>"></asp:Label>
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CaseIdString%>"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="labelCaseSn" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="labelBridalName" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="labelGroomName" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                    </div>
                                    <asp:Label runat="server" ID="labelLocation" />
                                </div>
                            </div>
                        </div>
                        <div class="row serch">
                            <div class="12u">
                                <div class="table-wrapper">
                                    <asp:Label runat="server" ID="label4" Text="<%$ Resources:Resource,IncomeDetailString%>" />
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView2" runat="server"
                                                ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
                                                OnRowDeleting="GridView2_RowDeleting" Font-Size="Small">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="0px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbReceiptId" ReadOnly="true" Width="0px" Style="display: none;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CategoryString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbCategory" Font-Size="Small" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,DateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" Style="text-align: right" ID="tbIncomeDate" Font-Size="Small"
                                                                CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,PaymentMethodString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlPaymentMethod" Font-Size="Small" Width="80px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlCurrency" Font-Size="Small" Width="80px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbCash" Style="text-align: right" Width="80px" Font-Size="Small" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbCash" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ExpectedPaymentDateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" Style="text-align: right" ID="tbPaymentDate" Font-Size="Small"
                                                                CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,StoreString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlStore" Font-Size="Small" Width="150px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ReceiptDateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" Style="text-align: right" ID="tbReceiptDate" Font-Size="Small"
                                                                CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ReceiptSnString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbReceiptSn" Font-Size="Small"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,TotalPriceString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbTotalPrice" Font-Size="Small" Style="text-align: right" Width="80px" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbTotalPrice" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SalesString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbSales" Style="text-align: right" Font-Size="Small" Width="80px" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="tbSales" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,TaxString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="tbTax" runat="server" Style="text-align: right" Width="80px" Font-Size="Small"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="tbTax" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Button CausesValidation="false"
                                                                ID="btnAddRow2" runat="server"
                                                                Text="Add New Row" OnClick="btnAddRow2_Click" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="0px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbType" ReadOnly="true" Width="0px" Style="display: none;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="50px" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row serch">
                            <div class="12u">
                                <div class="table-wrapper">
                                    <asp:Label runat="server" ID="labelPaymentTable" Text="<%$ Resources:Resource,PaymentString%>" />
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridViewPayment" runat="server"
                                                ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="GridViewPayment_RowDataBound"
                                                OnRowDeleting="GridViewPayment_RowDeleting" Font-Size="Small">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="0px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbReceiptId" ReadOnly="true" Width="0px" Style="display: none;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CategoryString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbCategory" Font-Size="Small" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,DateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" Style="text-align: right" ID="tbIncomeDate" Font-Size="Small"
                                                                CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,PaymentMethodString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlPaymentMethod" Font-Size="Small" Width="80px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlCurrency" Font-Size="Small" Width="80px" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,PriceString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbCash" Style="text-align: right" Width="80px" Font-Size="Small" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbCash" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ExpectedPaymentDateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" Style="text-align: right" ID="tbPaymentDate" Font-Size="Small"
                                                                CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CurrencyRateString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbRate" Style="text-align: right" Width="80px" Font-Size="Small"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbRate" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,RemittanceFeeString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbFee" Style="text-align: right" Width="80px" Font-Size="Small"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbFee" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,TotalPriceString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbTotalPrice" Style="text-align: right" Width="80px" Font-Size="Small" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbTotalPrice" runat="server"
                                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,StoreString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlStore" Font-Size="Small" />
                                                        </ItemTemplate>
                                                        <FooterStyle HorizontalAlign="Right" />
                                                        <FooterTemplate>
                                                            <asp:Button CausesValidation="false"
                                                                ID="btnPaymentAddRow" runat="server"
                                                                Text="Add New Row" OnClick="btnPaymentAddRow_Click" />
                                                        </FooterTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="0px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbType" ReadOnly="true" Width="0px" Style="display: none;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" ItemStyle-Width="50px" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>

            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <div>
                                    <asp:FileUpload ID="ImgUpload" onchange="submitFileUpload(this);" runat="server" Style="display: none;" />
                                </div>
                                <div class="align-center">
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUploadTrigger" OnClientClick="showFileBroswerDialog();" />
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload" OnClick="btnUpload_Click" Style="display: none;" />
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUpload" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ExportString%>" ID="btnExport" OnClick="btnExport_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
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
        <script src="../assets/js/picker.js"></script>
        <script type="text/javascript">
            function showFileBroswerDialog() {
                var upload = document.getElementById('<%=ImgUpload.ClientID%>');
                upload.click();
            }
            function submitFileUpload(fileUpload) {
                if (fileUpload.value != null) {
                    document.getElementById('<%=btnUpload.ClientID%>').click();
                }
            }
        </script>
    </form>
</body>
</html>
