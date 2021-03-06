﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyMCreate.aspx.cs" Inherits="TheWeWebSite.BuyMgt.BuyMCreate" %>

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
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <div style="border: dotted; border-width: thin; padding: 15px 5px 5px 5px">
                <asp:Panel runat="server" ID="panelRequest">
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                </div>
                                <asp:Label runat="server" ID="tbRequestStatus" />
                                <asp:DropDownList runat="server" ID="ddlRequestStatus" Style="display: none;" />
                                <asp:TextBox runat="server" ID="tbReqeuster" Style="display: none;" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlStore" Enabled="false" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,DateString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbRequestDate" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbSn" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                                </div>
                                <asp:TextBox CssClass="required" runat="server" ID="tbName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    ControlToValidate="tbName" runat="server"
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
                                        <div style="margin-top: 15px">
                                            <asp:TextBox CssClass="required" runat="server" ID="tbCategory" Visible="false" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                ControlToValidate="tbType" runat="server"
                                                ErrorMessage="required"
                                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
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
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlCurrency" />
                                <asp:TextBox runat="server" ID="tbPrice" Style="text-align: right" Text="0"></asp:TextBox>
                                <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="tbPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,NumberString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbNumber" Style="text-align: right" Text="1"></asp:TextBox>
                                <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbNumber" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)" style="margin-top: 30px;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox runat="server" ID="cbAddOthItem" Text="<%$ Resources:Resource,AddOthItemString%>" AutoPostBack="true" OnCheckedChanged="cbAddOthItem_CheckedChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="6u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbRemark" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="panelAddOthItem" Visible="false">
                            <div class="12u">
                                <div class="row uniform 50%">
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" CssClass="required" ID="tbOthSn"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                            ControlToValidate="tbOthSn" runat="server"
                                            ErrorMessage="required"
                                            CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList CssClass="required" runat="server" ID="ddlOthCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlOthCategory_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlOthCategory" runat="server"
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
                                                <asp:DropDownList CssClass="required" runat="server" ID="ddlOthItemType" AutoPostBack="true" OnSelectedIndexChanged="ddlOthItemType_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="ddlOthItemType" runat="server"
                                                    ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <div style="margin-top: 15px">
                                                    <asp:TextBox CssClass="required" runat="server" ID="tbOthItemType" Visible="false" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatortbOthItemType"
                                                        ControlToValidate="tbOthItemType" runat="server"
                                                        ErrorMessage="required"
                                                        CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlOthItemCurrency" />
                                                <asp:TextBox runat="server" ID="tbOthPrice" Style="text-align: right" Text="0"></asp:TextBox>
                                                <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="tbOthPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="4u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbOthDescription" Rows="3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div style="border: dotted; border-width: thin; padding: 15px 5px 5px 5px">
                <asp:Panel runat="server" ID="panelApproval">
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,DateString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbApprovalDate" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList CssClass="required" runat="server" ID="ddlStatus" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)" style="margin-top: 30px;">
                                <asp:CheckBox runat="server" ID="cbAutoPass" Text="AutoPass" />
                            </div>
                            <div class="6u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbApprovalRemark" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
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
                </div>
            </section>
            <hr />
            <!-- Btn -->
            <div class="Div btn" runat="server" id="divRequestBtn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SaveString%>" ID="btnSave" OnClick="btnSave_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SubmitString%>" ID="btnSubmit" OnClick="btnSubmit_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false"
                            runat="server" CssClass="button alt" Text="<%$ Resources:Resource,AbandonString%>" ID="btnAbandon" OnClick="btnAbandon_Click" />
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
