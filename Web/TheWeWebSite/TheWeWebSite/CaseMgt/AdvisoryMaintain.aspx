<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisoryMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.AdvisoryMaintain" %>

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
                        <li><a href="remind.aspx">
                            <asp:Label runat="server" Text="工作提醒"></asp:Label></a>
                            <ul>
                                <li><a href="CaseMgt/AdvisoryMaintain.aspx">
                                    <asp:Label runat="server" Text="諮詢維護"></asp:Label></a></li>
                                <li><a href="Main/Case.aspx">
                                    <asp:Label runat="server" Text="訂單維護"></asp:Label></a></li>
                                <li><a href="CaseMgt/TimeMaintain.aspx">
                                    <asp:Label runat="server" Text="時程維護"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="Main/Unsigned.aspx">
                            <asp:Label runat="server" Text="首頁"></asp:Label></a>
                            <ul>
                                <li><a href="Main/Unsigned.aspx">
                                    <asp:Label runat="server" Text="未簽約"></asp:Label></a></li>
                                <li><a href="Main/Case.aspx">
                                    <asp:Label runat="server" Text="已簽約"></asp:Label></a></li>
                                <li><a href="Main/Calendar.aspx">
                                    <asp:Label runat="server" Text="行程表"></asp:Label></a></li>
                                <li><a href="Main/CustomerCalendar.aspx">
                                    <asp:Label runat="server" Text="客戶行程"></asp:Label></a></li>
                                <li><a href="Main/ChurchReservation.aspx">
                                    <asp:Label runat="server" Text="教堂預約"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="StoreMgt/ItemMaintain.aspx">
                            <asp:Label runat="server" Text="開店管理"></asp:Label></a>
                            <ul>
                                <li><a href="StoreMgt/ItemMaintain.aspx">
                                    <asp:Label runat="server" Text="產品維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/DressMaintain.aspx">
                                    <asp:Label runat="server" Text="禮服維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/FittingMaintain.aspx">
                                    <asp:Label runat="server" Text="配件維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/ModelingMaintain.aspx">
                                    <asp:Label runat="server" Text="造型維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/OtherItemMaintain.aspx">
                                    <asp:Label runat="server" Text="婚禮小物維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/ChurchMaintain.aspx">
                                    <asp:Label runat="server" Text="教堂維護"></asp:Label></a></li>
                                <li><a href="StoreMgt/EmployeeMaintain.aspx">
                                    <asp:Label runat="server" Text="員工維護"></asp:Label></a></li>
                            </ul>
                        </li>
                        <li><a href="CaseMgt/CustomerMaintain.aspx">
                            <asp:Label runat="server" Text="案件管理"></asp:Label></a>
                            <ul>
                                <li><a href="CaseMgt/CustomerMaintain.aspx">
                                    <asp:Label runat="server" Text="客戶維護"></asp:Label></a></li>
                                <li><a href="CaseMgt/AdvisoryMaintain.aspx">
                                    <asp:Label runat="server" Text="諮詢維護"></asp:Label></a></li>
                                <li><a href="CaseMgt/CaseMaintain.aspx">
                                    <asp:Label runat="server" Text="案件維護"></asp:Label></a></li>
                                <li><a href="CaseMgt/TimeMaintain.aspx">
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
                        <li><a href="SysMgt/LoginMaintain.aspx">
                            <asp:Label runat="server" Text="系統管理"></asp:Label></a>

                            <ul>
                                <li><a href="SysMgt/LoginMaintain.aspx">
                                    <asp:Label runat="server" Text="登錄維護"></asp:Label></a></li>
                                <li><a href="SysMgt/RootMaintain.aspx">
                                    <asp:Label runat="server" Text="權限類別"></asp:Label></a></li>
                                <li><a href="SysMgt/CaseRootMaintain.aspx">
                                    <asp:Label runat="server" Text="權限案件"></asp:Label></a></li>
                                <li><a href="SysMgt/MsgMaintain.aspx">
                                    <asp:Label runat="server" Text="常用簡訊"></asp:Label></a></li>
                                <li><a href="SysMgt/UnitMaintain.aspx">
                                    <asp:Label runat="server" Text="單位"></asp:Label></a></li>
                                <li><a href="SysMgt/DollarMaintain.aspx">
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
                    <asp:Label runat="server" Text="案件管理"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="諮詢維護"></asp:Label></h3>
                        <hr />
                    </header>

                    <!-- Input -->

                    <div class="row">
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入諮詢案號..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘姓名..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新郎姓名..."></asp:TextBox>
                                </div>
                            </div>


                            <div class="row uniform">
                                <div class="12u">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="查詢" />
                                        </li>
                                    </ul>
                                </div>
                            </div>

                            <hr />



                        </div>
                    </div>

                    <!-- Table -->

                    <div class="row">
                        <div class="12u">

                            <h4>搜尋結果</h4>
                            <hr />
                            <div class="table-wrapper">
                                <table class="alt">
                                    <thead>
                                        <tr>
                                            <th>SEQ</th>
                                            <th>諮詢日期</th>
                                            <th>顧問</th>
                                            <th>會議內容</th>
                                            <th>下次會議日期</th>
                                            <th>下次會議內容</th>
                                            <th>備註</th>
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
                                        </tr>
                                        <tr>
                                            <td>CU00001</td>
                                            <td>Joye</td>
                                            <td>小讌</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
                                            <td>1234321</td>
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
