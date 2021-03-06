﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisoryMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.AdvisoryMCreate" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->
        <My:Header runat="server" ID="ucHeader" />

        <section class="box title CreatePage">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <div>
                <asp:Panel runat="server" ID="panelBasicInfo">
                    <div class="12u">

                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlStore" Enabled="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbSn" Enabled="false"></asp:TextBox>
                                <asp:Label runat="server" ID="labelConsultDate" Visible="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                            <div style="margin-top: 22px">
                                <asp:CheckBox runat="server" ID="cbReply" Text="<%$ Resources:Resource,IsReplyString%>"></asp:CheckBox>
                            </div>
                                </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,AppointmentDateString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbBookingDate" OnTextChanged="tbBookingDate_TextChanged"
                                            CssClass="date date-1 required" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            ControlToValidate="tbBookingDate" runat="server"
                                            ErrorMessage="required"
                                            CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,LastReceivedTimeString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" Style="text-align: right" ID="tbLastReceived" CssClass="date date-1" value=""
                                    placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                </div>
                                <asp:DropDownList CssClass="required" runat="server" ID="ddlStatus" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlStatus" runat="server"
                                ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                ControlToValidate="tbBridalName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>

                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalEngNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbBridalEngName"></asp:TextBox>
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
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalPhoneString%>"></asp:Label>
                                </div>
                                <asp:TextBox CssClass="required" runat="server" ID="tbBridalPhone"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                                ControlToValidate="tbGroomName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                
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
                                <asp:TextBox runat="server" ID="tbBridalMsgId"></asp:TextBox>
                            </div>


                        </div>
                    </div>
                    <div class="12u">

                        <div class="row uniform 50%">

                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalWorkString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbBridalWork"></asp:TextBox>
                            </div>
                            <div class="4u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalEmailString%>"></asp:Label>
                                </div>
                                <asp:TextBox CssClass="required" runat="server" ID="tbBridalEmail"></asp:TextBox>
                                
                            </div>



                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" CssClass="required" ID="tbGroomName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                ControlToValidate="tbGroomName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomEngNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbGroomEngName"></asp:TextBox>

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
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomPhoneString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbGroomPhone"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="tbGroomMsgId"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomWorkString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbGroomWork"></asp:TextBox>
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

                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,PlannedWeddingFilmDateString%>"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" Style="text-align: right" ID="tbWeddingFilm"
                                        CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                </div>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,PlannedWeddingDateString%>"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" Style="text-align: right" ID="tbWeddingDate"
                                        CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                </div>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticWeddingReceptionDateString%>"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" Style="text-align: right" ID="tbReception"
                                        CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                </div>
                            </div>


                            <div class="6u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbRemark"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="12u">
                        <div class="row uniform 50%">

                            <div class="2u 12u(mobilep)">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,AdvisoryItemString%>"></asp:Label>
                                        </div>
                                        <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                            <asp:CheckBoxList runat="server" ID="cblAdvisory" AutoPostBack="true" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                        </div>
                                        <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                            <asp:CheckBoxList runat="server" ID="cblCountry"
                                                OnSelectedIndexChanged="cblCountry_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                        </div>
                                        <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                            <asp:CheckBoxList runat="server" ID="cblArea"
                                                OnSelectedIndexChanged="cblArea_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                        </div>
                                        <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                            <asp:CheckBoxList runat="server" ID="cblLocation" Height="200px"
                                                OnSelectedIndexChanged="cblLocation_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingPlannerString%>"></asp:Label>
                                        </div>
                                        <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                            <asp:CheckBoxList runat="server" ID="cblWeddingPlanner" Height="200px"
                                                OnSelectedIndexChanged="cblWeddingPlanner_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,HowToKnowString%>"></asp:Label>
                                </div>
                                <div style="overflow-y: scroll; height: 200px; padding-top: 10px">
                                    <asp:CheckBoxList runat="server" ID="ddlSourceInfo" Height="200px" />
                                </div>
                            </div>


                        </div>
                    </div>
                </asp:Panel>
            </div>
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                            ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>"
                            ID="btnModify" OnClick="btnModify_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                            ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>"
                            ID="btnDelete" OnClick="btnDelete_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ExportString%>" ID="btnExport" OnClick="btnExport_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
                            ID="btnCancel" OnClick="btnCancel_Click" />
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

