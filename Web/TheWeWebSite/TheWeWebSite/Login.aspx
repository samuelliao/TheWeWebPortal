<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheWeWebSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="assets/css/main.css" rel="stylesheet" />
    <link href="assets/css/calendar.css" rel="stylesheet" />
</head>
<body class="landing">
    <form runat="server" style="background-color: Pink">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div id="page-wrapper">

            <!-- Header -->


            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlStore"/>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <asp:TextBox runat="server" TextMode="SingleLine" ID="tbAccount" />
                </div>


                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <asp:TextBox runat="server" ID="tbPassword" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" ID="labelWarnText" ForeColor="Red" />
                    <br />
                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,LoginString%>" OnClick="btnLogin_Click" />
                </div>
            </section>



            <!-- Footer -->
            <footer id="footer" style="background-color: pink">
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
