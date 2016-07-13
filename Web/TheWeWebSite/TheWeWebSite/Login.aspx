<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheWeWebSite.Login" %>

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


            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <p>
                    <asp:Label runat="server" Text="Login"></asp:Label>
                </p>
                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <select>
                        <option value="">- 請選擇店別 -</option>
                        <option value="1">1</option>
                        <option value="1">2</option>
                        <option value="1">3</option>
                    </select>
                </div>

                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <asp:TextBox runat="server" placeholder="請輸入帳號..."></asp:TextBox>
                </div>


                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15%;">
                    <asp:TextBox runat="server" placeholder="請輸入密碼..."></asp:TextBox>
                </div>
                <div>
                    <asp:Button runat="server" CssClass="button alt" Text="Login" />
                </div>

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
