<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ItemMCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;產品資料庫&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="產品編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="婚禮演奏"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘髮妝"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎髮妝"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="拍攝時間"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="拍攝地點"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="移動方式"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="照片張數"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="住宿"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="房型"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘捧花,新郎胸花"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>


                <div>
                    <div class="row uniform 50%">
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="教堂使用費" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="牧師" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="教堂佈置" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="結婚證明書" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="戒枕" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="簽名筆" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="中文婚禮工作人員" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="新娘休息室" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="熨燙禮服" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="抵達後的開會討論" />
                        </div>
                        <div class="Check Div">
                            <asp:CheckBox runat="server" Text="早餐" />
                        </div>
                    </div>
                </div>

            </div>

            <!-- Table -->

            <div style="margin-top:1.5em">
                <div class="12u">
                    <div class="table-wrapper">
                        <table class="alt">
                            <thead>
                                <tr>
                                    <th>附加項目</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>花瓣雨</td>
                                    <td>50</td>
                                    <td>$10000</td>
                                </tr>
                                <tr>
                                    <td>花瓣雨</td>
                                    <td>50</td>
                                    <td>$10000</td>
                                </tr>
                            </tbody>

                        </table>
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
    </form>

</body>
</html>
