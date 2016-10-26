<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogMgt.aspx.cs" Inherits="TheWeWebSite.LogMgt" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="./assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="./assets/css/main.css" rel="stylesheet" />
    <link href="./assets/css/main.css" rel="stylesheet" />
</head>
<body class="landing">
    <form runat="server">
        <div id="page-wrapper">
            <asp:ScriptManager runat="server" ID="scriptMgt"></asp:ScriptManager>
            <!-- Main -->

            <section id="main" class="serch">
                <!-- Text -->
                <section class="box title">
                    <h3>
                        <asp:Label runat="server" ID="labelPageTitle"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">
                    <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:ListBox runat="server" ID="listLogs" AutoPostBack="true" OnSelectedIndexChanged="listLogs_SelectedIndexChanged" Height="300px"></asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <hr />
                            <div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="12u 12u(mobilep)">
                                            <asp:UpdatePanel runat="server">
                                                <ContentTemplate>
                                                    <asp:TextBox runat="server" ID="tbLog" ReadOnly="true" TextMode="MultiLine" Rows="6" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
            </section>



            <!-- Footer -->
            <footer id="footer">
                <ul class="copyright">
                    <li>rights.</li>
                    <li>The We Wedding</li>
                </ul>
            </footer>

        </div>

        <!-- Scripts -->
        <script src="./assets/js/jquery.min.js"></script>
        <script src="./assets/js/jquery.dropotron.min.js"></script>
        <script src="./assets/js/jquery.scrollgress.min.js"></script>
        <script src="./assets/js/skel.min.js"></script>
        <script src="./assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="./assets/js/main.js"></script>
        <script src="./assets/js/table.js"></script>
    </form>
</body>
</html>
