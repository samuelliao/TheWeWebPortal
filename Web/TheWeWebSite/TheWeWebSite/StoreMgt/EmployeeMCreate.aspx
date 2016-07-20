<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.EmployeeMCreate" %>

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
                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;員工資料庫&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="員工編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入員工編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="權限類別"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="語系編號"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlLang" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="姓名"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入姓名..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="到職日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="離職日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">

                            <div class="Div">
                                <asp:Label runat="server" Text="電話"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入電話..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="生日"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="E-Mail"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入E-Mail..."></asp:TextBox>
                        </div>
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地址"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入地址..."></asp:TextBox>
                        </div>

                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="護照英文名稱"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入護照英文名稱..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="護照號碼"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入護照號碼..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="緊急連絡人"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入緊急連絡人..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="緊急連絡人電話"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入緊急連絡人電話..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="帳戶號碼"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入帳戶號碼..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="存摺號碼"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入存摺號碼..."></asp:TextBox>
                        </div>
                        

                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="薪資"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入薪資..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="勞健保"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入勞健保..."></asp:TextBox>
                        </div>
                        <div class="8u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="備註"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="備註..."></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <hr />
            <!-- 照片 -->
            <section>
                <div class="row no-collapse 50% uniform">
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="員工照片"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="身分證正面"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="身分證背面"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
                    </div>

                </div>
            </section>
            <hr />
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" />
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

