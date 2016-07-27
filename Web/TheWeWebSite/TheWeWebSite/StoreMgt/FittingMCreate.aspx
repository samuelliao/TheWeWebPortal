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
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" id="tbSn"></asp:TextBox>
                        </div>                       

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlType" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)" runat="server" id="divEarringType" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlEarringType" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)" runat="server" id="divGender" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,GenderString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlGender" />
                                </ContentTemplate>
                            </asp:UpdatePanel>                            
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStatus" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="出借紀錄"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)"  runat="server" id="divRelatedCategory" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="對應物件"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlRelatedCategory"/>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)" runat="server" id="divRelatedSn" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="對應物件編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRelatedSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbColor1"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)"  runat="server" id="divColor2" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbColor2" ></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)" runat="server" id="divMaterial1">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbMaterial1" ></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)" runat="server" id="divMaterial2" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbMaterial2"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)"  runat="server" id="divLength" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LengthString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlLength" />
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)" runat="server" id="divLace" visible="false">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LaceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbLace" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCost" style="text-align:right"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SupplierString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlSupplier"/>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RentPriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRentPrice" style="text-align:right"></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,OptionalPriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOptionalPrice" style="text-align:right"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SellingPriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbSalesPrice" style="text-align:right"></asp:TextBox>
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
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
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
