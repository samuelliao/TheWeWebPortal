<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressMaintain" %>

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
                    <asp:Label runat="server" Text="開店管理"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="禮服維護"></asp:Label></h3>
                        <hr />
                    </header>

                    <!-- Input -->

                    <div class="row">
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入禮服編號..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇性別 -</option>
                                            <option value="1">F</option>
                                            <option value="1">M</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇禮服類別 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇禮服顏色 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇型態 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇領口 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇後背 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇肩膀 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇質料 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇穿法 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇頭紗 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇配件 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇胸花 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇手套 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇狀態碼 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇使用狀態 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 可否外拍 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="加價金額..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 限國內婚宴 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 大尺碼 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>

                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 加價款 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="加價金額..."></asp:TextBox>

                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <asp:TextBox runat="server" placeholder="成本價..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="訂製價..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 供應商 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="租金..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(narrower)">
                                    <asp:TextBox runat="server" placeholder="售價..."></asp:TextBox>

                                </div>



                            </div>


                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入正面照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入側面照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入背面照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入配件照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入細節照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="12u">
                                    <textarea name="message" id="message" placeholder="其他..." rows="6"></textarea>
                                </div>
                            </div>



                            <div class="row uniform">
                                <div class="12u">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="修改" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" />
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
                                            <th>禮服編號</th>
                                            <th>禮服類別</th>
                                            <th>禮服顏色</th>
                                            <th>型態</th>
                                            <th>領口</th>
                                            <th>後背</th>
                                            <th>肩膀</th>
                                            <th>質料</th>
                                            <th>穿法</th>

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
                    <li>&copy; Untitled. All rights reserved.</li>
                    <li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
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
