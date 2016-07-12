<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TheWeWebSite.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../css/btn_1.css" rel="stylesheet" />
    <link href="../css/btn_2.css" rel="stylesheet" />
    <link href="../css/btn_3.css" rel="stylesheet" />
    <link href="../css/btn_4.css" rel="stylesheet" />
    <link href="../css/btn_5.css" rel="stylesheet" />
    <link href="../css/btn_6.css" rel="stylesheet" />
    <link href="../css/btn_7.css" rel="stylesheet" />
    <link href="../css/btn_8.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/footer.css" rel="stylesheet" />
    <link href="../css/header.css" rel="stylesheet" />
    <link href="../css/month.css" rel="stylesheet" />
    <link href="../css/tablestyle.css" rel="stylesheet" />
</head>
<body style="height: 100%">
    <form runat="server">

        <div id="header" style="height: 100px;">
            <div style="width: auto; float: left;">
                <img src="../img/圖層_1.png" style="width: 181px; height: 104px" runat="server" />
            </div>

        </div>

        <div id="content" style="background: #FFFFFF; height: auto; text-align: center; margin-top: 200px;">

            <div style="padding: 5px;">

                <asp:Label ID="labelStore" runat="server" Text="<%$ Resources:Resource,StoreString%>" Style="font-size: 20px;"></asp:Label>
                <asp:DropDownList Width="150px" runat="server" ID="ddlStore" OnLoad="ddlStore_Load" />
            </div>
            <div style="padding: 5px;">
                <asp:Label ID="labelAccount" runat="server" Text="<%$ Resources:Resource,AccountString%>" Style="font-size: 20px;"></asp:Label>
                <asp:TextBox runat="server" ID="tbAccount" TextMode="SingleLine" Width="150px" />
            </div>
            <div style="padding: 5px;">
                <asp:Label ID="labelPw" runat="server" Text="<%$ Resources:Resource,PasswordString%>" Style="font-size: 20px;"></asp:Label>
                <asp:TextBox runat="server" ID="tbPassword" TextMode="Password" Width="150px" />
            </div>
            <div style="padding: 5px;margin-top: 30px;">
                <asp:Label runat="server" ID="labelWarnText" Font-Size="20px" ForeColor="Red" Visible="false" />
                <br/>
                <asp:Button ID="btnLogin" runat="server" class="btn_2" Text="<%$ Resources:Resource,LoginString%>" OnClick="btnLogin_Click" />
            </div>


        </div>
        <div id="footer"></div>


    </form>
</body>
</html>
