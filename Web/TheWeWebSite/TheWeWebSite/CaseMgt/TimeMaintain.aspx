﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
        <link href="../assets/css/jquery-ui.css" rel="stylesheet"/>
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
                        <asp:Label runat="server" Text="案件管理&nbsp;&nbsp;>&nbsp;&nbsp;時程維護(待修改)"></asp:Label></h3>
                </section>

                <!-- Input -->
                <section class="box special">
                    <div>
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="案件編號"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入案件編號..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(開始)"></asp:Label>
                                    </div>
                                   <div> <asp:TextBox runat="server"  CssClass="dp"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(結束)"></asp:Label>
                                    </div>
                                   <div> <asp:TextBox runat="server"  CssClass="dp"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新娘"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入查詢新娘..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="新郎"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入查詢新郎..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="國家"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server"/>

                                </div>
                                
                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="地區"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server"/>

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="地點"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server"/>

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="產品"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server"/>

                                </div>

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="會議日期選擇範圍(開始)"></asp:Label>
                                    </div>
                                    <div> <asp:TextBox runat="server"  CssClass="dp"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="會議日期選擇範圍(結束)"></asp:Label>
                                    </div>
                                    <div> <asp:TextBox runat="server"  CssClass="dp"></asp:TextBox> </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkTimeMCreate" PostBackUrl="~/CaseMgt/TimeMCreate.aspx" />
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
                                            <th>諮詢編號</th>
                                            <th>案件編號</th>
                                            <th>開案日期</th>
                                            <th>會員編號</th>
                                            <th>狀態</th>
                                            <th>結案日期</th>
                                            <th>國家</th>
                                            <th>地區</th>
                                            <th>地點</th>
                                            <th>套餐</th>

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
