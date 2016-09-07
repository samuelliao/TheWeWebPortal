<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMCreate" %>

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
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->

        <section class="box title CreatePage">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <asp:Panel runat="server" ID="panelBasicInfo">
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="labelSn" Enabled="false" />
                                <asp:CheckBox runat="server" ID="cbIsClose" Visible="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ExpectedDateString%>"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbContractDate" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbBridalName" Enabled="false"></asp:TextBox>
                                <asp:Label runat="server" Visible="false" ID="labelBridalEngName" />
                                <asp:Label runat="server" Visible="false" ID="labelBridalPhone" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbGroomName" Enabled="false"></asp:TextBox>
                                <asp:Label runat="server" Visible="false" ID="labelGroomEngName" />
                                <asp:Label runat="server" Visible="false" ID="labelGroomPhone" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbCountry" Enabled="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbArea" Enabled="false" />
                            </div>

                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbLocation" Enabled="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SystemString%>" ID="tbProductSet" Enabled="false" />
                                <asp:Label runat="server" ID="labelWeddingCategory" Visible="false" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlOrderType" Enabled="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="4u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SpecialClaimString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="tbOsp" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 500px">
                                <asp:TreeView CssClass="acidjs-css3-treeview"
                                    NodeIndent="20"
                                    NodeStyle-NodeSpacing="3"
                                    NodeStyle-CssClass="treeNode"
                                    RootNodeStyle-CssClass="rootNode"
                                    LeafNodeStyle-CssClass="leafNode"
                                    SelectedNodeStyle-BackColor="#f2a6a6"
                                    SelectedNodeStyle-Font-Bold="true"
                                    SelectedNodeStyle-ForeColor="#ffffff"
                                    runat="server" Font-Size="Small" ID="tvConf" OnSelectedNodeChanged="tvConf_SelectedNodeChanged" ShowCheckBoxes="Leaf">
                                    <LeafNodeStyle CssClass="leafNode" />
                                    <NodeStyle CssClass="treeNode" />
                                    <RootNodeStyle CssClass="rootNode" />
                                    <SelectedNodeStyle CssClass="selectNode" />
                                </asp:TreeView>
                            </div>
                        </div>
                        <div class="10u 12u(mobilep)">
                            <div class="Div" style="padding-top: 30px">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ConferenceDateString%>"></asp:Label>
                            </div>
                            <div style="margin-bottom: 50px">
                                <div style="float: left">
                                    <asp:TextBox runat="server" Style="text-align: right" ID="tbConDate"
                                        Width="200px"
                                        CssClass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                </div>
                                <div style="float: left; padding: 7px 0 0 10px">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox runat="server" ID="cbCompleted" Text="<%$ Resources:Resource,CompleteString%>" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>


                            <!--Content-->
                            <div>
                                <!-- Step 1-1 飯店住宿-->
                                <div runat="server" visible="false" id="divHotel">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelName"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelName" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelOthName"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelOthName" />
                                    </div>
                                    <div class="5u 12u(mobilep) TimeMaintain" runat="server">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelAddr"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelAddr" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelName2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelName2" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelOthName2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelOthName2" />
                                    </div>
                                    <div class="5u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblHotelAddr2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbHotelAddr2" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblTravelPeriod"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbTravelPeriod" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblStayNight"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbStayNight" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblContact"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbContact" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblFlight"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbFlight" Rows="4" TextMode="MultiLine" />
                                    </div>

                                </div>

                                <!-- Step 1-2 婚禮資訊-->
                                <div visible="false" id="divWeddingInfo" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv" style="margin-top: 30PX">
                                            <asp:CheckBox runat="server" ID="cbLegalWedding" />
                                        </div>
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblPastorLanguage"></asp:Label>
                                        </div>
                                        <asp:DropDownList runat="server" ID="ddlLangPastor" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblWelcomeCard"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbWelcomeCard" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblChampagne"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbChampagne" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGuest"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGuest" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblWeddingSequence"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbWeddingSequence" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblChurchArrangements"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbChurchArrangements" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblWSp"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbWSp" />
                                    </div>
                                </div>

                                <!-- Step 1-3 拍攝資訊-->
                                <div visible="false" id="divTakePicture" runat="server">
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblAttractions"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbAttractions" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblRoutePlan"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbRoutePlan" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblPhotoItem"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbPhotoItem" />
                                    </div>

                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblPhotoAvoid"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbPhotoAvoid" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblPSp"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbPSp" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblPhotoBouquet"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbPhotoBouquet" />
                                    </div>
                                </div>

                                <!-- Step 1-4 挑選禮服-->
                                <div visible="false" id="divChooseDress" runat="server">
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalSpecialClaim"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalSpecialClaim" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGroomDressNum"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGroomDressNum" />
                                    </div>
                                    <div class="9u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGroomSpecialClaim"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGroomSpecialClaim" />
                                    </div>
                                </div>

                                <!-- Step 1-5 晚宴菜單-->
                                <div visible="false" id="divDinner" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblDinnerGuest"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbDinnerGuest" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblSitePlan"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbSitePlan" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblDinnerContent"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbDinnerContent" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblFood"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbFood" />
                                    </div>
                                    <div class="11u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBSp"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBSp" Rows="3" TextMode="MultiLine" />
                                    </div>
                                </div>

                                <!-- Step 1-6 其他-->

                                <!-- Step 2-1 禮服試穿-->
                                <div visible="false" id="divTryDress" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress1"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress1" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress2" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress3"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress3" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress4"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress4" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress5"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress5" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalTryDress6"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalTryDress6" />
                                    </div>
                                </div>

                                <!-- Step 2-2 化妝造型確認-->
                                <div visible="false" id="divModelCheck" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalModeling"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalModeling" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalMakeupEmphasis"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalMakeupEmphasis" />
                                    </div>
                                    <div class="7u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHairSpecailClaim"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHairSpecailClaim" />
                                    </div>
                                    <div class="4u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGroomHair"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGroomHair" />
                                    </div>
                                    <div class="7u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGroomHairSpecailClaim"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGroomHairSpecailClaim" />
                                    </div>

                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair1"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair1" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair2" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair3"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair3" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair4"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair4" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair5"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair5" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalHair6"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalHair6" />
                                    </div>

                                </div>

                                <!-- Step 2-3 禮服行程規劃-->

                                <!-- Step 2-4 其他-->

                                <!-- Step 3-1 禮服尺寸確認-->
                                <div visible="false" id="divCehckDress" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress1"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress1" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress2"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress2" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress3"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress3" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress4"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress4" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress5"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress5" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBridalCheckDress6"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBridalCheckDress6" />
                                    </div>
                                </div>

                                <!-- Step 3-2 行程重點提醒-->

                                <!-- Step 3-3 禮服取件/付款-->
                                <div visible="false" id="divGetDress" runat="server">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblGetDress"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbGetDress" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblDeposit"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbDeposit" />
                                    </div>
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBalanceDue"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBalanceDue" />
                                    </div>
                                </div>

                                <!-- Step 3-4 其他-->
                                <!-- Step 4-1 -->
                                <!-- Step 4-2 -->
                                <!-- Step 4-3 -->
                                <!-- Step 4-4 -->
                                <!-- Step 4-5 -->
                                <!-- Step 4-6 -->
                                <!-- Step 4-7 -->
                                <!-- Step 5-1 -->
                                <!-- Step 5-2 -->
                                <!-- Step 5-3 -->
                                <!-- Step 5-4 -->
                                <!-- Step 5-5 -->
                                <!-- Step 5-6 -->
                                <!-- Step 5-7 -->

                                <!--BouquetPhoto-->
                                <!--BouquetCorsage Start-->
                                <div runat="server" id="divBouquet">
                                    <div class="2u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv">
                                            <asp:Label runat="server" ID="lblBouquetCorsage"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbBouquetCorsage" />
                                    </div>
                                    <!---->
                                    <div class="4u 12u(mobilep) TimeMaintain">
                                        <div class="TimeMaintainDiv" style="text-align: center">
                                            <asp:Label runat="server" ID="lblBouquet1"></asp:Label>
                                        </div>
                                        <span class="image fit">
                                            <asp:Image runat="server" ID="ImgBouquet1" />
                                        </span>
                                    </div>
                                </div>
                                <!--BouquetCorsage End-->
                                <!--挑選禮服-->
                                <div id="divDress" runat="server" class="11u 12u(mobilep) TimeMaintain serch" style="overflow-x: scroll!important">
                                    <div class="TimeMaintainDiv">
                                        <asp:Label runat="server" ID="label1" Text="<%$ Resources:Resource,DressString%>" />
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="dgCutomServiceItem" runat="server"
                                                ShowFooter="True" AutoGenerateColumns="False" OnRowDataBound="dgCutomServiceItem_RowDataBound"
                                                OnRowDeleting="dgCutomServiceItem_RowDeleting" Width="2500px">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Width="0px">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbId" ReadOnly="true" Width="0px" Style="display: none;" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CategoryString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlServiceItem" AutoPostBack="True" OnSelectedIndexChanged="ddlServiceItem_SelectedIndexChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,SnString%>">
                                                        <ItemTemplate>
                                                            <ajaxToolkit:ComboBox ID="cbxChooseDSn" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true" OnSelectedIndexChanged="cbxChooseDSn_SelectedIndexChanged"></ajaxToolkit:ComboBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,BustString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbBust" AutoPostBack="True" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,WaistString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbWaist" AutoPostBack="True" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,HipsString%>">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="tbHips" AutoPostBack="True" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,TryDressString%>">
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="cbIsTry" AutoPostBack="True" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,CheckDressString%>">
                                                        <ItemTemplate>
                                                            <asp:CheckBox runat="server" ID="cbIsCheck" AutoPostBack="True" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ImgFrontString%>">
                                                        <ItemTemplate>
                                                            <div class="6u 12u(mobilep) ">
                                                                <span class="image fit">
                                                                    <asp:Image ID="ImgCDress1" Height="150px" Width="100px" runat="server" ImageUrl="http://127.0.0.1/Photo/Church/CH006/Bouquet/CH006_2.jpg" />
                                                                </span>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ImgBackString%>">
                                                        <ItemTemplate>
                                                            <div class="6u 12u(mobilep) ">
                                                                <span class="image fit">
                                                                    <asp:Image ID="ImgCDress2" Height="150px" Width="100px" runat="server" ImageUrl="http://127.0.0.1/Photo/Church/CH006/Bouquet/CH006_2.jpg" />
                                                                </span>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ImgSideString%>">
                                                        <ItemTemplate>
                                                            <div class="6u 12u(mobilep) ">
                                                                <span class="image fit">
                                                                    <asp:Image ID="ImgCDress3" Height="150px" Width="100px" runat="server" ImageUrl="http://127.0.0.1/Photo/Church/CH006/Bouquet/CH006_2.jpg" />
                                                                </span>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelingString%>">
                                                        <ItemTemplate>
                                                            <asp:DropDownList runat="server" ID="ddlHairCategory" AutoPostBack="True" OnSelectedIndexChanged="ddlHairCategory_SelectedIndexChanged" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelingSnString%>">
                                                        <ItemTemplate>
                                                            <ajaxToolkit:ComboBox ID="cbxChooseHSn" runat="server" AutoCompleteMode="SuggestAppend" AutoPostBack="true" OnSelectedIndexChanged="cbxChooseHSn_SelectedIndexChanged"></ajaxToolkit:ComboBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="<%$ Resources:Resource,ModelingPhotoString%>">
                                                        <ItemTemplate>
                                                            <div class="5u 12u(mobilep) ">
                                                                <span class="image fit">
                                                                    <asp:Image ID="ImgCHair1" runat="server" Height="150px" Width="100px" />
                                                                </span>
                                                            </div>
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

                                <!--Remark-->
                                <div class="11u 12u(mobilep) TimeMaintain">
                                    <div class="TimeMaintainDiv">
                                        <asp:Label runat="server" ID="lblOth"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbOth" Rows="6" TextMode="MultiLine" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>"
                            ID="btnModify" OnClick="btnModify_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
                            ID="btnCancel" OnClick="btnCancel_Click" />
                    </li>
                </ul>
            </div>
            <div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LangCodeString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlLang" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoArrangementString%>"></asp:Label>
                            </div>
                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ExportString%>"
                                ID="btnPhotoExport" OnClick="btnPhotoExport_Click" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CouplesInfoString%>"></asp:Label>
                            </div>
                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ExportString%>"
                                ID="btnCouplesInfo" OnClick="btnCouplesInfo_Click" />
                        </div>
                    </div>
                </div>
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
    </form>
</body>
</html>
