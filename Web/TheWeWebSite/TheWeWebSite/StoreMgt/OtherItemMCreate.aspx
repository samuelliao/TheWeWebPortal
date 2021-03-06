﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OtherItemMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.OtherItemMCreate" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>
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
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->
        <section class="box title CreatePage">
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
                            <asp:TextBox runat="server" CssClass="required" ID="tbOthSn"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                ControlToValidate="tbOthSn" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox CssClass="required" runat="server" ID="tbOthName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                ControlToValidate="tbOthName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="ddlCategory" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlOthCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlOthCategory_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlOthCategory" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="ddlType" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    <div style="margin-top: 15px">
                                        <asp:TextBox CssClass="required" runat="server" ID="tbType" Visible="false" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                                            ControlToValidate="tbType" runat="server"
                                            ErrorMessage="required"
                                            CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CurrencyString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCurrency" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOthPrice" Style="text-align: right"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="tbOthPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CurrencyString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCostCurrency" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOthCost" Style="text-align: right"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbOthCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>" />
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlCountry" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>" />
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlArea" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="Div">
                                        <asp:Label runat="server" ID="labelHolderTitle" Text="<%$ Resources:Resource,StoreString%>" />
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStore" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOthDescription" Rows="2"></asp:TextBox>
                        </div>

                    </div>
                </div>
                <hr />
                <!-- 照片 -->
                <section>

                    <div class="row no-collapse 50% uniform">
                        <div class="2u" runat="server" id="divPhotoUpload">
                            <div class="ImageUploadBtn">
                                <button class="Div btn actions button alt" id="btnUploadPanel" onclick="uploadPanelControl();">
                                    <asp:Literal runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                                </button>
                            </div>
                            <div id="uploadPanel" style="display: none;">
                                <div runat="server" id="divUpload">
                                    <div class="fileUpload">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                    <div class="fileUpload">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                    </div>
                                    <div class="fileUpload">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                                        <asp:FileUpload ID="FileUpload3" runat="server" />
                                    </div>
                                    <div class="fileUpload">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                        <asp:FileUpload ID="FileUpload4" runat="server" />
                                    </div>
                                    <div style="text-align: left; margin-top: 15px;">
                                        <asp:Button CausesValidation="true" runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload"
                                            OnClick="btnUpload_Click" OnClientClick="uploadPanelControl();" />
                                    </div>
                                </div>
                            </div>
                        </div>
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
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
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
