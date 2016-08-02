<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMCreate" %>

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
                            <asp:Label runat="server" ID="labelSn" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:Label runat="server" ID="tbContractDate"></asp:Label>
                            </div>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbBridalName"></asp:Label>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbGroomName"></asp:Label>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbCountry" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbArea" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbLocation" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                            </div>
                            <asp:Label runat="server" ID="tbProductSet" />
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 200px">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TreeView runat="server" Font-Size="Small" ID="tvConf" OnSelectedNodeChanged="tvConf_SelectedNodeChanged" ShowCheckBoxes="Leaf" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ConferenceDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox runat="server" style="text-align:right" ID="tbConDate"
                                            Cssclass="date date-1" value="" placeholder="YYYY-MM-DD HH:MM APM" data-timeformat="HH:MM"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CompleteString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:CheckBox runat="server" ID="cbCompleted" Text="<%$ Resources:Resource,CompleteString%>" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbRemark" TextMode="MultiLine" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>"
                            ID="btnModify" OnClick="btnModify_Click" />
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
    </form>
</body>
</html>
