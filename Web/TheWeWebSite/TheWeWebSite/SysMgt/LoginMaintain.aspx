<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.LoginMaintain" %>

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
                        <asp:Label runat="server" Text="系統管理&nbsp;&nbsp;>&nbsp;&nbsp;登錄維護(待修改)"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">

                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="店編號"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="帳號"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入帳號..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="密碼"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入密碼..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="確認密碼"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請確認密碼..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="員工編號"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入員工編號..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="是否有效"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkCaseMCreate" PostBackUrl="~/CaseMgt/CaseMCreate.aspx" />
                            </li>
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" />
                            </li>

                        </ul>
                    </div>
                    <hr />
                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <table class="alt">
                                    <thead>
                                        <tr>
                                            <th>店編號</th>
                                            <th>帳號</th>
                                            <th>密碼</th>
                                            <th>會員編號</th>
                                            <th>是否有效</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>台北</td>
                                            <td>Joye</td>
                                            <td>**********</td>
                                            <td>1234321</td>
                                            <td>Y</td>
                                        </tr>
                                        <tr>
                                            <td>台北</td>
                                            <td>Joye</td>
                                            <td>**********</td>
                                            <td>1234321</td>
                                            <td>Y</td>
                                        </tr>
                                    </tbody>

                                </table>
                            </div>
                            <hr />
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
