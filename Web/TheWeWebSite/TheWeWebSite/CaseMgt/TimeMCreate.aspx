<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMCreate" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:ScriptManager runat="server">
                <Scripts>
                    <asp:ScriptReference Path="../assets/js/picker.js" />
                    <asp:ScriptReference Path="../assets/js/jquery.min.js" />
                </Scripts>
            </asp:ScriptManager>
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="labelSn" Enabled="false" />
                            <asp:CheckBox runat="server" ID="cbIsClose" Visible="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ExpectedDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="tbContractDate" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbBridalName" Enabled="false"></asp:TextBox>
                            <asp:Label runat="server" Visible="false" ID="labelBridalEngName" />
                            <asp:Label runat="server" Visible="false" ID="labelBridalPhone" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbGroomName" Enabled="false"></asp:TextBox>
                            <asp:Label runat="server" Visible="false" ID="labelGroomEngName" />
                            <asp:Label runat="server" Visible="false" ID="labelGroomPhone" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCountry" Enabled="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbArea" Enabled="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbLocation" Enabled="false" />
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbProductSet" Enabled="false" />
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
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 450px">
                                <asp:TreeView
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
                            <div>
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" ID="tbRemark" TextMode="MultiLine" Rows="10" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
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
