<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CaseMCreate" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet"/>

</head>
<body>
    <form runat="server">

        <!-- Main -->

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="案件管理&nbsp;&nbsp;>&nbsp;&nbsp;簽約維護&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AdviosryIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CaseIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入案件編號..."></asp:TextBox>
                        </div>


                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MemberIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入會員編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractDateString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AppointDateString%>"></asp:Label>
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
                                <asp:Label runat="server" Text="結案日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="方案"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國家"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地區"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地點"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="套餐"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘姓名"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
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
                                <asp:Label runat="server" Text="新娘通訊軟體類型"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                         <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘通訊軟體ID"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘暱稱"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新娘護照英文"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入會員編號..."></asp:TextBox>
                        </div>
                        
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎姓名"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入案件編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎生日"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                       
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎通訊軟體類型"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎通訊軟體ID"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入案件編號..."></asp:TextBox>
                        </div>

                        
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎暱稱"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..."></asp:TextBox>
                        </div>
                        
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="新郎護照英文"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="地址"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="備註"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入案件編號..."></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="介紹人"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="簡訊手機"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="簡訊稱呼"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入會員編號..."></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="海外婚禮日期"></asp:Label>
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
                                <asp:Label runat="server" Text="海外婚紗拍攝日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國內婚紗拍攝日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國內訂婚日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國內結婚日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國內歸寧日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="國內補請日期"></asp:Label>
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
                                <asp:Label runat="server" Text="訂金付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="二次付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="尾款付款日期"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" CssClass="dp"></asp:TextBox>
                            </div>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="折扣"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="訂金"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="二次付款"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>


                        </div>

                    </div>


                    <div class="12u">

                        <div class="row uniform 50%">


                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="價格"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" placeholder="系統自動帶入諮詢編號..."></asp:TextBox>

                            </div>
                            <!-- 照片 -->
                            <div class="row no-collapse 50% uniform">
                                <div class="5u">
                                    <div style="text-align: center">
                            <asp:Label runat="server" Text="合照照片"></asp:Label>
                        </div>
                                    <span class="image fit">
                                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                                </div>
                                <div class="Div btn">
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                                </div>
                            </div>
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
