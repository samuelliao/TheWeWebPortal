<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CustomerMCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="案件管理&nbsp;&nbsp;>&nbsp;&nbsp;客戶維護&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
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
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘護照英文"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入新娘護照英文..."></asp:TextBox>
                        </div>
                        <div class="4u">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘地址"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入新娘地址..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="搜尋管道"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>

                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="簡訊稱呼"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入簡訊稱呼..."></asp:TextBox>
                        </div>

                        <div class="10u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="備註"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="備註..."></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkCaseMCreate" PostBackUrl="~/SysMgt/CaseMCreate.aspx" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" />
                    </li>

                </ul>
            </div>
        </section>

        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
        <!-- datepicker -->
        <script src="../assets/js/datepicker.js"></script>
        <script src="../assets/js/jquery-1.10.2.js"></script>
        <script src="../assets/js/jquery-ui.js"></script>
    </form>
</body>
</html>

