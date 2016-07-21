﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisoryMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.AdvisoryMCreate" %>

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

        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <asp:ScriptManager runat="server"></asp:ScriptManager>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AppointmentDateString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBookingDate" CssClass="dp"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LastReceivedTimeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbLastReceived" CssClass="dp"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStatus" />
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalName"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalEngNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalEngName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalPhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalPhone"></asp:TextBox>

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
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalMsgId"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalBdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp" ID="tbBridalBday"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalWorkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalWork"></asp:TextBox>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalEmailString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbBridalEmail"></asp:TextBox>
                        </div>



                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomEngNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomEngName"></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomPhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomPhone"></asp:TextBox>
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
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomMsgId"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomBdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp" ID="tbGroomBday"></asp:TextBox>
                            </div>
                        </div>




                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomWorkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomWork"></asp:TextBox>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomEmailString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbGroomEmail"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">

                        <div class="2u 12u(mobilep)">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AdvisoryItemString%>"></asp:Label>
                                    </div>
                                    <div style="overflow-y: scroll; height: 200px;">
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
                                    <div style="overflow-y: scroll; height: 200px;">
                                        <asp:CheckBoxList runat="server" ID="cblCountry" Height="200px"
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
                                    <div style="overflow-y: scroll; height: 200px;">
                                        <asp:CheckBoxList runat="server" ID="cblArea" Height="200px"
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
                                    <div style="overflow-y: scroll; height: 200px;">
                                        <asp:CheckBoxList runat="server" ID="cblLocation" Height="200px" />
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
                                    <div style="overflow-y: scroll; height: 200px;">
                                        <asp:CheckBoxList runat="server" ID="cblWeddingPlanner" Height="200px" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>



                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PlannedWeddingFilmDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp" ID="tbWeddingFilm"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PlannedWeddingDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp" ID="tbWeddingDate"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DomesticWeddingReceptionDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp" ID="tbReception"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,HowToKnowString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: scroll; height: 200px;">
                                <asp:CheckBoxList runat="server" ID="ddlSourceInfo" Height="200px" />
                            </div>
                        </div>

                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" TextMode="MultiLine" ID="tbRemark"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Btn -->
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
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
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                            ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>"
                            ID="btnDelete" OnClick="btnDelete_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
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
    </form>
</body>
</html>

