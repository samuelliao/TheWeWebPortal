﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="TheWeWebSite.Main.Case" %>

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
            <header id="header">
                <h1>
                    <asp:Label runat="server" Text="台北"></asp:Label></h1>

                <nav id="nav">
                    <ul>
                        <li><a href="../remind.aspx">
                            <asp:Label runat="server" Text="工作提醒"></asp:Label></a>
                            <ul>
                                <li><a href="../CaseMgt/AdvisoryMaintain.aspx">
                                    <asp:Label runat="server" Text="諮詢維護"></asp:Label></a></li>
                                <li><a href="../Main/Case.aspx">
                                    <asp:Label runat="server" Text="訂單維護"></asp:Label></a></li>
                                <li><a href="../CaseMgt/TimeMaintain.aspx">
                                    <asp:Label runat="server" Text="時程維護"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="../Unsigned.aspx">
                            <asp:Label runat="server" Text="首頁"></asp:Label></a>
                            <ul>
                                <li><a href="../Unsigned.aspx">
                                    <asp:Label runat="server" Text="未簽約"></asp:Label></a></li>
                                <li><a href="../Case.aspx">
                                    <asp:Label runat="server" Text="已簽約"></asp:Label></a></li>
                                <li><a href="../Calendar.aspx">
                                    <asp:Label runat="server" Text="行程表"></asp:Label></a></li>
                                <li><a href="../CustomerCalendar.aspx">
                                    <asp:Label runat="server" Text="客戶行程"></asp:Label></a></li>
                                <li><a href="../ChurchReservation.aspx">
                                    <asp:Label runat="server" Text="教堂預約"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="../ItemMaintain.aspx">
                            <asp:Label runat="server" Text="開店管理"></asp:Label></a>
                            <ul>
                                <li><a href="../ItemMaintain.aspx">
                                    <asp:Label runat="server" Text="產品維護"></asp:Label></a></li>
                                <li><a href="../DressMaintain.aspx">
                                    <asp:Label runat="server" Text="禮服維護"></asp:Label></a></li>
                                <li><a href="../FittingMaintain.aspx">
                                    <asp:Label runat="server" Text="配件維護"></asp:Label></a></li>
                                <li><a href="../ModelingMaintain.aspx">
                                    <asp:Label runat="server" Text="造型維護"></asp:Label></a></li>
                                <li><a href="../OtherItemMaintain.aspx">
                                    <asp:Label runat="server" Text="婚禮小物維護"></asp:Label></a></li>
                                <li><a href="../ChurchMaintain.aspx">
                                    <asp:Label runat="server" Text="教堂維護"></asp:Label></a></li>
                                <li><a href="../EmployeeMaintain.aspx">
                                    <asp:Label runat="server" Text="員工維護"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="../CustomerMaintain.aspx">
                            <asp:Label runat="server" Text="案件管理"></asp:Label></a>
                            <ul>
                                <li><a href="../CustomerMaintain.aspx">
                                    <asp:Label runat="server" Text="客戶維護"></asp:Label></a></li>
                                <li><a href="../AdvisoryMaintain.aspx">
                                    <asp:Label runat="server" Text="諮詢維護"></asp:Label></a></li>
                                <li><a href="../CaseMaintain.aspx">
                                    <asp:Label runat="server" Text="案件維護"></asp:Label></a></li>
                                <li><a href="../TimeMaintain.aspx">
                                    <asp:Label runat="server" Text="時程維護"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a>
                            <asp:Label runat="server" Text="查詢管理"></asp:Label></a>
                        </li>
                        <li><a>
                            <asp:Label runat="server" Text="採購作業"></asp:Label></a>
                        </li>
                        <li><a>
                            <asp:Label runat="server" Text="銷貨作業"></asp:Label></a>
                        </li>
                        <li><a>
                            <asp:Label runat="server" Text="財務作業"></asp:Label></a>
                        </li>
                        <li><a href="../LoginMaintain.aspx">
                            <asp:Label runat="server" Text="系統管理"></asp:Label></a>

                            <ul>
                                <li><a href="../LoginMaintain.aspx">
                                    <asp:Label runat="server" Text="登錄維護"></asp:Label></a></li>
                                <li><a href="../RootMaintain.aspx">
                                    <asp:Label runat="server" Text="權限類別"></asp:Label></a></li>
                                <li><a href="../CaseRootMaintain.aspx">
                                    <asp:Label runat="server" Text="權限案件"></asp:Label></a></li>
                                <li><a href="../MsgMaintain.aspx">
                                    <asp:Label runat="server" Text="常用簡訊"></asp:Label></a></li>
                                <li><a href="../UnitMaintain.aspx">
                                    <asp:Label runat="server" Text="單位"></asp:Label></a></li>
                                <li><a href="../DollarMaintain.aspx">
                                    <asp:Label runat="server" Text="幣別"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a>
                            <asp:Label runat="server" Text="Logout"></asp:Label></a>
                        </li>
                    </ul>
                </nav>
            </header>

            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <p>
                    <asp:Label runat="server" Text="首頁"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="已簽約"></asp:Label></h3>
                        <hr />
                    </header>

                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <table class="alt">
                                    <thead>
                                        <tr>
                                            <th>案件編號</th>
                                            <th>新娘</th>
                                            <th>新郎</th>
                                            <th>下次會議</th>
                                            <th>目的</th>
                                            <th>上次會議備註</th>
                                            <th>行程</th>
                                            <th>產品</th>
                                            <th>教堂</th>
                                            <th>費用</th>
                                            <th>顧問</th>

                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>CU00001</td>
                                            <td>Joye</td>
                                            <td>小讌</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>234</td>
                                        </tr>
                                        <tr>
                                            <td>CU00001</td>
                                            <td>Joye</td>
                                            <td>小讌</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>234</td>
                                        </tr>
                                    </tbody>

                                </table>
                            </div>
                            <hr />
                        </div>
                    </div>




                </section>


            </section>

            <!-- CTA -->


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