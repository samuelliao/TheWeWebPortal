<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CustomerMCreate" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
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
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbSn" placeholder="<%$ Resources:Resource,SnInputString%>" Enabled="false"/>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NickNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbNickName" placeholder="<%$ Resources:Resource,NickNameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" style="text-align:right" ID="tbBday"
                                    Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,PhoneInputString%>" ID="tbPhone"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MsgString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlMsgerType" />
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,MsgIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbMsgId"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmailString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,EmailInputString%>" ID="tbEmail"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PassportNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,PassportNameInputString%>" ID="tbPassportName"></asp:TextBox>
                        </div>
                        <div class="4u">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AddressString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,AddressInputString%>" ID="tbAddr"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnsTitleString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SnsTitleInputString%>" ID="tbSnsTitle"></asp:TextBox>
                        </div>

                        <div class="10u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,RemarkString%>"
                                ID="tbRemark" ></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                            ID="btnCreate" OnClick="btnCreate_Click" Visible="true" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>"
                            ID="btnModify" OnClick="btnModify_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                            ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>"
                            ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
                            ID="btnCancel" OnClick="btnCancel_Click" />
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

