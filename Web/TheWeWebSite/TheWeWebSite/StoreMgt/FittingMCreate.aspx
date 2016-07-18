<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FittingMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.FittingMCreate" %>


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
                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;配件資料庫&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="配件編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="配件分類"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="配件細項分類"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="物品狀況"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="出借紀錄"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="對應物件"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                    </div>
                </div>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="對應物件編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="顏色1"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="顏色2"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="材質1"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="材質2"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="長度"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="花邊"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="成本價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="供應商"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="出租價格"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="加選價格"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="販售價格"></asp:Label>
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
                             <div style="text-align:center">
                                <asp:Label runat="server" Text="正面照片"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                             <div style="text-align:center">
                                <asp:Label runat="server" Text="背面照片"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                             <div style="text-align:center">
                                <asp:Label runat="server" Text="側面照片"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                             <div style="text-align:center">
                                <asp:Label runat="server" Text="其他照片"></asp:Label>
                            </div>
                            <span class="image fit">
                                <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                        </div>
                        <div class="2u">
                             <div style="text-align:center">
                                <asp:Label runat="server" Text="其他照片"></asp:Label>
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
