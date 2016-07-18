<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CustomerMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
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
                        <asp:Label runat="server" Text="案件管理&nbsp;&nbsp;>&nbsp;&nbsp;客戶維護(待修改)"></asp:Label></h3>
                </section>


                <!-- Input -->
                <section class="box special">
                    <div>
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="語系編號"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="會員編號"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入會員編號..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘姓名"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入新娘姓名..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘生日"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘電話"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入新娘電話..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘通訊軟體類型"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘通訊軟體Id"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入新娘Line Id..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘E-Mail"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入新娘E-Mail..."></asp:TextBox>
                                </div>

                            </div>
                        </div>

                    </div>


                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkCustomerMCreate" PostBackUrl="~/CaseMgt/CustomerMCreate.aspx" />
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
        <!-- datepicker -->
        <script src="../assets/js/datepicker.js"></script>
        <script src="../assets/js/jquery-1.10.2.js"></script>
        <script src="../assets/js/jquery-ui.js"></script>
    </form>
</body>

</html>
