<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ChurchMCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;教堂資料庫&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="教堂編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國家名稱"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地區名稱"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地點名稱"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="教堂名稱"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="容納人數"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="聖潔之道長度"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="聖潔之道類型"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="婚禮時間"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="售價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>

                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="餐點" />
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="服務項目及價格說明"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="備註"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>

                <hr />
                <!-- 照片 -->
                <section>
                    <div class="row no-collapse 50% uniform">
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="教堂照片1"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="教堂照片2"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="教堂照片3"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="教堂照片4"></asp:Label>
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


            </div>
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
    </form>
</body>
</html>

