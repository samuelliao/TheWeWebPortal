<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.EmployeeMaintain" %>

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
                    <asp:Label runat="server" Text="開店管理"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="員工維護"></asp:Label></h3>
                        <hr />
                    </header>
                    <!-- Input -->

                    <div class="row">
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入員工編號..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇權限類別 -</option>
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
                                            <option value="">- 請選擇語系編號 -</option>
                                            <option value="1">1</option>
                                            <option value="1">2</option>
                                            <option value="1">3</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入姓名..."></asp:TextBox>

                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入電話..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <input placeholder="請輸入生日..." type="text" onfocus="(this.type='date')" id="date" />
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="12u">
                                    <asp:TextBox runat="server" placeholder="請輸入E-Mail..."></asp:TextBox>

                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="12u">
                                    <asp:TextBox runat="server" placeholder="請輸入地址..."></asp:TextBox>

                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入護照英文名稱..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入護照號碼..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入電話..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入電話..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入緊急聯絡人..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入緊急連絡人電話..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入存摺號碼..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入帳戶號碼..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入薪資..."></asp:TextBox>

                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入勞健保..."></asp:TextBox>
                                </div>
                            </div>
                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入身分證正面照面..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="9u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請匯入身分證反面照片..."></asp:TextBox>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:Button runat="server" CssClass="button alt" Text="上傳" />
                                </div>
                            </div>


                            <div class="row uniform 50%">
                                <div class="12u">
                                    <textarea name="message" id="message" placeholder="備註..." rows="6"></textarea>
                                </div>
                            </div>



                            <div class="row uniform">
                                <div class="12u">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="查詢" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="新增" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="修改" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="清除" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="刪除" />
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
                                            <th>語系編號</th>
                                            <th>員工編號</th>
                                            <th>姓名</th>
                                            <th>電話</th>
                                            <th>地址</th>
                                            <th>生日</th>
                                            <th>權限類別</th>
                                            <th>到職日期</th>
                                            <th>離職日期</th>
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
