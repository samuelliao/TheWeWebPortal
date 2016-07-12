<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CustomerMaintain" %>

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
                            <asp:Label runat="server" Text="客戶維護"></asp:Label></h3>
                        <hr />
                    </header>

                    <!-- Input -->

                    <div class="row">
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇語系編號 -</option>
                                            <option value="1">Ch</option>
                                            <option value="1">Tw</option>
                                            <option value="1">En</option>
                                            <option value="1">Jp</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入會員編號..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘姓名..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <input placeholder="請輸入新娘生日..." type="text" onfocus="(this.type='date')" id="date" />
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘電話..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘Line Id..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘E-Mail..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘護照英文..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="12u">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘地址..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇搜尋管道 -</option>
                                            <option value="1">a</option>
                                            <option value="1">b</option>
                                            <option value="1">c</option>
                                            <option value="1">d</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入簡訊手機..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入簡訊稱呼..."></asp:TextBox>
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
                                            <asp:Button runat="server" CssClass="button alt" Text="新增" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="修改" />
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
                                            <th>諮詢案號</th>
                                            <th>案件代號</th>
                                            <th>產品</th>
                                            <th>產品內容</th>
                                            <th>成案日期</th>
                                            <th>結案日期</th>
                                            <th>費用</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>A12322</td>
                                            <td>C02331</td>
                                            <td>Projct_1</td>
                                            <td>item_1,item_2,item3item_1,item_2,item4,item_5,item_6,item7,item_12,item_21,item8,item_15,item_22,item9,item_10,item_20,item30</td>
                                            <td>2016/02/03</td>
                                            <td>2016/06/13</td>
                                            <td>$231000</td>
                                        </tr>
                                        <tr>
                                            <td>A14322</td>
                                            <td>C02215</td>
                                            <td>Projct_2</td>
                                            <td>item_1,item_2</td>
                                            <td>2016/01/15</td>
                                            <td>2016/07/22</td>
                                            <td>$100000</td>
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
