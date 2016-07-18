<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressMCreate" %>


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
                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;禮服資料庫&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
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
                                <asp:Label runat="server" Text="穿法"></asp:Label>
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
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="胸花"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>
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
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="成本價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="成本價..."></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="訂製價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="訂製價..."></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="供應商"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="租金"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="租金..."></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="售價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="售價..."></asp:TextBox>

                        </div>
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="其他"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="其他..."></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="可否外拍" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="外拍加價金額"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="加價金額..."></asp:TextBox>
                        </div>
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="加價款" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="加價款加價金額"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="加價金額..."></asp:TextBox>
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
                <hr />
            <!-- 照片 -->
            <section>
                <div class="row no-collapse 50% uniform">
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="正面照片"></asp:Label>
                        </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="背面照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="側面照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="其他照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
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
