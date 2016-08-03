<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchReservation.aspx.cs" Inherits="TheWeWebSite.Main.ChurchReservation" %>

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
<body class="landing">
    <form runat="server">
        <div id="page-wrapper">

            <!-- Header -->
            <My:Header runat="server" ID="ucHeader" />

            <!-- Main -->

            <section id="main">

                <!-- Text -->
                <section class="box title">
                    <h3>
                        <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
                </section>

                <!-- Input -->
                <section class="box special">
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <!-- Calendar-->
                    <div class="row">
                        <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div style="overflow-y: auto; height: 500px">
                                                <asp:TreeView runat="server" Height="100%" ID="tvChurch" OnSelectedNodeChanged="tvChurch_SelectedNodeChanged" SelectedNodeStyle-BackColor="Pink" />
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="10u 12u(mobilep)">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:Calendar runat="server" ID="calendar" OnPreRender="calendar_PreRender" OnDayRender="calendar_DayRender" OnVisibleMonthChanged="calendar_VisibleMonthChanged" SelectedDayStyle-BackColor="Pink" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
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
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
        <script src="../assets/js/table.js"></script>
    </form>
</body>
</html>
