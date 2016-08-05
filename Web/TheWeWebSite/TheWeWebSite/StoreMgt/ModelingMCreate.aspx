﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelingMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ModelingMCreate" %>


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
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbSn" ReadOnly="true"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                                    <asp:TextBox runat="server" ID="tbType" Visible="false" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,DescriptionString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="..." ID="tbDescription"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <hr />
                <section>
                    <div class="row no-collapse 50% uniform">
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                                <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>

                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="ImgFront" />
                            </span>
                            <div style="margin-bottom: 1.5em">
                                <asp:FileUpload ID="ImgFrontUpload" runat="server" />
                            </div>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnImgFrontUpload"
                                    OnClick="btnImgFrontUpload_Click" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="ImgBack" /></span>
                            <div style="margin-bottom: 1.5em">
                                <asp:FileUpload ID="ImgBackUpload" runat="server" />
                            </div>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnImgBackUpload" OnClick="btnImgBackUpload_Click" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="ImgSide" /></span>
                            <div style="margin-bottom: 1.5em">
                                <asp:FileUpload ID="ImgSideUpload" runat="server" />
                            </div>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnImgSideUpload" OnClick="btnImgSideUpload_Click" />
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
