<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.MsgMaintain" %>

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
                        <asp:Label runat="server" Text="系統管理&nbsp;&nbsp;>&nbsp;&nbsp;常用簡訊(待修改)"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">

                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="12u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="簡訊名稱"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入簡訊名稱..."></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="12u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="簡訊內容"></asp:Label>
                                    </div>
                                    <textarea name="message" id="message" placeholder="請輸入簡訊內容..." rows="6"></textarea>
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
                                            <th>簡訊名稱</th>
                                            <th>簡訊內容</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>$</td>
                                            <td>35簡訊內容簡訊內容簡訊內容簡訊內容簡訊內容</td>
                                        </tr>
                                        <tr>
                                            <td>¥</td>
                                            <td>0.簡訊內容簡訊內容簡訊內容簡訊內容簡訊內容簡訊內容</td>
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
