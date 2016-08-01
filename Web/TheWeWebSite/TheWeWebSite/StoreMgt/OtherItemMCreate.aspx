<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherItemMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.OtherItemMCreate" %>


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
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbOthSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbOthName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)" >
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlOthCategory" />
                        </div>
                        <div class="2u 12u(mobilep)" style="display:none">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CreateItemString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbCreateType"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbOthPrice" style="text-align:right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbOthPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbOthCost" style="text-align:right"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbOthCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>" />
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStore" />
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbOthDescription" TextMode="MultiLine" Rows="6"></asp:TextBox>
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
                            <asp:Label runat="server" Text="補充照片"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                            </div>
                    </div>
            </div>
            </section>

            </div>
            <hr />
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
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
