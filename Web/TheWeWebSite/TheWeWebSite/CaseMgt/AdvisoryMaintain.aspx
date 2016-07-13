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
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WorkReminderString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="linkWorkReminder" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkConsultMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkOrderMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMgt" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,MainPageString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkMain" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkUnsigned" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractScheduleString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkCase" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ScheduleString%>" PostBackUrl="~/Main/Calendar.aspx" ID="LinkCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerScheduleString%>" PostBackUrl="~/Main/CustomerCalendar.aspx" ID="LinkCustomerCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LocationReservationString%>" PostBackUrl="~/Main/ChurchReservation.aspx" ID="LinkChurchReservtion" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StoreMgtString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkItemMaintain" />                            
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ProductMaintainString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkProductMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,DressMaintainString%>" PostBackUrl="~/StoreMgt/DressMaintain.aspx" ID="LinkDressMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,AccessoryMaintainString%>" PostBackUrl="~/StoreMgt/FittingMaintain.aspx" ID="LinkFittingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StyleMaintainString%>" PostBackUrl="~/StoreMgt/ModelingMaintain.aspx" ID="LinkModelingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WeddingItemMaintainString%>" PostBackUrl="~/StoreMgt/OtherItemMaintain.aspx" ID="LinkOtherItemMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ChurchMaintainString%>" PostBackUrl="~/StoreMgt/ChurchMaintain.aspx" ID="LinkChurchMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,EmployeeMaintainString%>" PostBackUrl="~/StoreMgt/EmployeeMaintain.aspx" ID="LinkEmployeeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,OrderMgtString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCaseMgt" />                            
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerMaintainString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCustomerMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkButton1" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/CaseMgt/CaseMaintain.aspx" ID="LinkCaseMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SearchMgtString%>" ID="LinkSearchMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>" ID="LinkPuchaseMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SalesMgtString%>" ID="LinkSalesMgtString" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,FinMgtString%>" ID="LinkFinMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SysMgtString%>" ID="LinkSysMgt" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LoginMaintainString%>" ID="LinkLoginMaintain" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PermissionCategoryString%>" ID="LinkRootMaintain" PostBackUrl="~/SysMgt/RootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CasePermissionMgtString%>" ID="LinkCaseRootMaintain" PostBackUrl="~/SysMgt/CaseRootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SNSMgtString%>" ID="LinkMsgMaintain" PostBackUrl="~/SysMgt/MsgMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CurrencyString%>" ID="LinkDollarMaintain" PostBackUrl="~/SysMgt/DollarMaintain.aspx" />
                                </li>
                            </ul>
                        </li>
                        <li><a>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LogoutString%>" ID="LinkLogout" PostBackUrl="~/Login.aspx" />
                        </li>
                    </ul>
                </nav>
            </header>

            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <p>
                    <asp:Label runat="server" Text="<%$ Resources:Resource,OrderMgtString%>"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>"></asp:Label></h3>
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
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" />
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
