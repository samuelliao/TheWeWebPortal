<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMCreate.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="TheWeWebSite.StoreMgt.DressMCreate" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->
        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <div class="12u">
                <div class="row uniform 50%">
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlStore" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbSn"></asp:TextBox>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,GenderString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlGender" />

                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlDressCategory" />

                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbColor" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbColor2" />
                    </div>

                </div>
            </div>

            <div class="12u">
                <div class="row uniform 50%">
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlDressType" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbMaterial"></asp:TextBox>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbMaterial2"></asp:TextBox>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,NecklineString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlNeckline" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,DressBackString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlBack" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ShoulderString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlShoulder" />
                    </div>
                </div>

            </div>
            <div class="12u">
                <div class="row uniform 50%">
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,WornString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlWorn" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,VeilString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlVeil" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,TrailingString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlTrailing" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,CorsageString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlCorsage" />

                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,GlovesString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlGloves" />
                    </div>



                </div>
            </div>
            <div class="12u">
                <div class="row uniform 50%">
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlStatus" />

                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,UsageStatusString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlUseStatus" />
                    </div>
                    <div class="4u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,FittingString%>"></asp:Label>
                        </div>
                        <div style="overflow-y: auto">
                            <asp:TextBox runat="server" ID="tbFitting"></asp:TextBox>
                        </div>
                    </div>
                    <div class="4u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,OtherString%>"></asp:Label>
                        </div>
                        <div style="overflow-y: auto;">
                            <asp:TextBox runat="server" ID="tbOthers"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <div class="12u">
                <div class="row uniform 50%">
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbCost" Style="text-align: right"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbCost"
                            runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,CustomPriceString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbCustomPrice" Style="text-align: right"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbCustomPrice" runat="server"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,SupplierString%>"></asp:Label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlSupplier" />
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,RentPriceString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbRentPrice" Style="text-align: right"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbRentPrice" runat="server"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="2u 12u(mobilep)">
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,SellingPriceString%>"></asp:Label>
                        </div>
                        <asp:TextBox runat="server" ID="tbSellsPrice" Style="text-align: right"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbSellsPrice" runat="server"
                            ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                    </div>
                </div>
            </div>

            <div class="12u">
                <div class="row uniform 50%">
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:CheckBox runat="server" Text="<%$ Resources:Resource,OutdoorShootingString%>"
                                    ID="cbOutPhoto" OnCheckedChanged="cbOutPhoto_CheckedChanged" AutoPostBack="true" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,OutdoorShootingPriceString%>"></asp:Label>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox runat="server" ID="tbOutdoorPlusPrice" Style="text-align: right" Enabled="false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="tbOutdoorPlusPrice" runat="server"
                                    ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:CheckBox runat="server" Text="<%$ Resources:Resource,AdditionalPurchaseString%>" ID="cbPlusItem" OnCheckedChanged="cbPlusItem_CheckedChanged" AutoPostBack="true" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <div class="Div">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,AdditionalPurchasePriceString%>"></asp:Label>
                        </div>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:TextBox runat="server" ID="tbPlusItemPrice" Style="text-align: right" Enabled="false"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="tbPlusItemPrice" runat="server"
                                    ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" Text="<%$ Resources:Resource,DomesticWeddingOnlyString%>" ID="cbDomesticWedding" />
                    </div>
                    <div>
                        <asp:CheckBox runat="server" Text="<%$ Resources:Resource,BigSizeString%>" ID="cbBigSize" />
                    </div>
                </div>
            </div>
            <hr />
            <!-- 照片 -->
            <section>
                <div class="4u" runat="server" id="divPhotoUpload">
                    <button id="btnUploadPanel" onclick="uploadPanelControl();">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </button>
                    <div id="uploadPanel" style="display: none;">
                        <div style="margin-bottom: 1.5em">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload1" Width="250px" runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload2" Width="250px" runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload3" Width="250px" runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload4" Width="250px" runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload5" Width="250px" runat="server" />
                        </div>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload"
                                OnClick="btnUpload_Click" OnClientClick="uploadPanelControl();" />
                        </div>
                        <hr />
                    </div>
                </div>
                <div class="row no-collapse 50% uniform">
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                            <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgFront" />
                        </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgBack" />
                        </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgSide" />
                        </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgOther1" />
                        </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgOther2" />
                        </span>
                    </div>
                </div>
            </section>
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
        <script type="text/javascript">
            function uploadPanelControl() {
                var div = document.getElementById('uploadPanel');
                if (div.style.display == 'none') {
                    displayUploadControl('false', 'true');
                } else {
                    displayUploadControl('true', 'true');
                }
            }
            function displayUploadControl(type, reset) {
                if (type == "true") {
                    document.getElementById('uploadPanel').style.display = 'inline';
                    document.getElementById('btnUploadPanel').style.display = 'none';
                    if (reset == 'true') {
                        localStorage.setItem('show', 'false'); //store state in localStorage
                    }
                } else {
                    document.getElementById('uploadPanel').style.display = 'none';
                    document.getElementById('btnUploadPanel').style.display = 'inline';
                    if (reset == 'true') {
                        localStorage.setItem('show', 'true'); //store state in localStorage
                    }
                }
            }
            window.onload = function () {
                var show = localStorage.getItem('show');
                displayUploadControl(show, 'false');
            }
        </script>
    </form>
</body>
</html>
