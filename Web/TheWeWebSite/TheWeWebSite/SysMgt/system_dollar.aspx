<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="system_dollar.aspx.cs" Inherits="TheWeWebSite.SysMgt.system_dollar" %>

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

            <div style="margin: 0px auto; float: right;">
                <asp:Label ID="label1" runat="server" Text="台北" Style="font-size: 20px; color: #516CC5; padding-right: 10px;"></asp:Label>
                <asp:Button ID="btnFirst" runat="server" Text="<%$ Resources:Resource,MainPageString%>" CssClass="btn_1" />
                <asp:Button ID="btnStoreMgt" runat="server" Text="<%$ Resources:Resource,StoreMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnCaseMgt" runat="server" Text="<%$ Resources:Resource,OrderMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnSerchMgt" runat="server" Text="<%$ Resources:Resource,SearchMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnBuyMgt" runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnSellMgt" runat="server" Text="<%$ Resources:Resource,SalesMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnFinancialMgt" runat="server" Text="<%$ Resources:Resource,FinMgtString%>" CssClass="btn_1" />
                <asp:Button ID="btnSystemMgt" runat="server" Text="<%$ Resources:Resource,SysMgtString%>" CssClass="btn_4" Style="margin-right: 10px;" />
            </div>
        </div>
        <div id="content" style="background: #FFFFFF; height: auto;">
            <div style="padding-top: 10px;">
                <asp:Button ID="btnCase" runat="server" Text="登錄維護" class="btn_5" />
                <asp:Button ID="btnCaseAdvisory" runat="server" Text="權限類別" class="btn_5" />
                <asp:Button ID="btnCaseList" runat="server" Text="案件權限" class="btn_5" />
                <asp:Button ID="btnCaseTime" runat="server" Text="常用簡訊" class="btn_5" />
                <asp:Button ID="Button1" runat="server" Text="單位" class="btn_5" />
                <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource,CurrencyString%>" CssClass="btn_6" />
            </div>

            <div style="padding-top: 20px;">
                <asp:Label ID="labeldollar" runat="server" Text="<%$ Resources:Resource,CurrencyString%>" />
                <asp:TextBox runat="server" ID="tbCurrencyName" Text="" TextMode="SingleLine" placeholder="<%$ Resources:Resource,CurrencyInputString%>" />
            </div>

            <div style="padding: 5px; margin-top: 20px;">
                <div style="text-align: center">
                    <asp:Button ID="btnInsert" runat="server" class="btn_8" Text="新增" Style="margin-right: 5px;" OnClick="btnInsert_Click" />
                </div>

                <asp:DataGrid runat="server" ID="dgCurrency" CssClass="tablestyle" ShowHeader="true"
                    AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dgCurrency_PageIndexChanged"
                    OnEditCommand="dgCurrency_EditCommand" OnCancelCommand="dgCurrency_CancelCommand"
                    OnDeleteCommand="dgCurrency_DeleteCommand" AutoGenerateColumns="false">
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <Columns>
                        <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CurrencyString%>" DataField="Name"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CurrencyRateString%>" DataField="Rate"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ModifiedTimeString%>" DataField="UpdateTime"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeAccount"></asp:BoundColumn>
                        <asp:BoundColumn HeaderText="EmployeeId" DataField="EmployeeId" Visible="false"></asp:BoundColumn>
                        <asp:EditCommandColumn EditText="<%$ Resources:Resource,ModifyString%>" CancelText="Cancel" UpdateText="Update" HeaderText="<%$ Resources:Resource,ModifyString%>"></asp:EditCommandColumn>
                        <asp:ButtonColumn CommandName="Delete" HeaderText="<%$ Resources:Resource,DeleteString%>" Text="<%$ Resources:Resource,DeleteString%>"></asp:ButtonColumn>
                    </Columns>
                </asp:DataGrid>
            </div>
            <div id="footer"></div>
    </form>
</body>
</html>
