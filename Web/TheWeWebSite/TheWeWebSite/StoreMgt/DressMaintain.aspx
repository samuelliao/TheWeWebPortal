<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressMaintain" %>

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
                        <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;禮服維護(待修改)"></asp:Label></h3>
                </section>

                <!-- Input -->

                <section class="box special">
                    <div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="禮服編號"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="請輸入禮服編號..."></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="性別"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="禮服類別"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="禮服顏色"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="型態"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="領口"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="後背"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="肩膀"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="質料"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="頭紗"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="配件"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="胸花"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>

                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="手套"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="狀態碼"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="使用狀態"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" />

                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="可否外拍" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="加價款" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="限國內婚宴" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="大尺碼" />
                                </div>

                            </div>
                        </div>


                    </div>


                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkDressMCreate" PostBackUrl="~/StoreMgt/DressMCreate.aspx" />
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
