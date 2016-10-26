<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheWeWebSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="assets/css/main.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <asp:ScriptManager runat="server" />
        <div>
            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15em;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlStore" AutoPostBack="true" OnSelectedIndexChanged="ddlStore_SelectedIndexChanged" />
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                </div>

                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15EM;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox runat="server" TextMode="SingleLine" ID="tbAccount" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="color: #000; margin-bottom: 10px; margin-left: auto; margin-right: auto; width: 15EM;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:TextBox runat="server" ID="tbPassword" TextMode="Password"></asp:TextBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div style="color: #000; margin-bottom: auto; margin-left: auto; margin-right: auto; width: 15EM; vertical-align: bottom; margin-top: 30px;">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:CheckBox runat="server" ID="cbRemember" Style="vertical-align: central; text-align: left;" Text="Remember me" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div>
                    <asp:Label runat="server" ID="labelWarnText" ForeColor="Red" />
                    <br />
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,LoginString%>" OnClick="btnLogin_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>                    
                </div>
            </section>
        </div>


    </form>
</body>
</html>
