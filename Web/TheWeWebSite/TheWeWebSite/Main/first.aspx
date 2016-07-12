<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="first.aspx.cs" Inherits="TheWeWebSite.Main.first" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>The We Wedding</title>
    <link href="../css/btn_1.css" rel="stylesheet" />
    <link href="../css/btn_2.css" rel="stylesheet" />
    <link href="../css/btn_3.css" rel="stylesheet" />
    <link href="../css/btn_4.css" rel="stylesheet" />
    <link href="../css/btn_5.css" rel="stylesheet" />
    <link href="../css/btn_6.css" rel="stylesheet" />
    <link href="../css/btn_7.css" rel="stylesheet" />
    <link href="../css/content.css" rel="stylesheet" />
    <link href="../css/footer.css" rel="stylesheet" />
    <link href="../css/header.css" rel="stylesheet" />
    <link href="../css/month.css" rel="stylesheet" />
    <link href="../css/tablestyle.css" rel="stylesheet" />
</head>
<body style="height:100%">
    <form  runat="server">
     
<div id="header" style="height:100px;" >
  <div style="width:auto; float:left;">
      <img  src="../img/圖層_1.png"  style=" width:181px ;height:104px " runat="server" /></div>

<div style=" margin:0px auto; float:right;  ">
 
    <asp:Label ID="labelLocate" runat="server" Text="台北"  style="font-size:20px; color:#516CC5; padding-right:10px; "></asp:Label>
    <asp:Button    ID="btnFirst" runat="server" Text="<%$ Resources:Resource,MainPageString%>"  CssClass="btn_4" />
    <asp:Button    ID="btnStoreMgt" runat="server" Text="<%$ Resources:Resource,StoreMgtString%>"   CssClass="btn_1" />
    <asp:Button    ID="btnCaseMgt" runat="server" Text="<%$ Resources:Resource,OrderMgtString%>"   CssClass="btn_1" />
    <asp:Button    ID="btnSerchMgt" runat="server" Text="<%$ Resources:Resource,SearchMgtString%>"  CssClass="btn_1" />
    <asp:Button    ID="btnBuyMgt" runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>"  CssClass="btn_1"/>
    <asp:Button    ID="btnSellMgt" runat="server" Text="<%$ Resources:Resource,SalesMgtString%>"  CssClass="btn_1" />
    <asp:Button    ID="btnFinancialMgt" runat="server" Text="<%$ Resources:Resource,FinMgtString%>"  CssClass="btn_1"/>
    <asp:Button    ID="btnSystemMgt" runat="server" Text="<%$ Resources:Resource,SysMgtString%>"  CssClass="btn_1" OnClick="btnSystemMgt_Click"  style="margin-right:10px;"/>
  </div>
  </div>
<div id="content" style="background:#FFFFFF; height:auto;" >
  <div>
          <asp:Button    ID="btnCaseRemind" runat="server" Text="<%$ Resources:Resource,WorkReminderString%>"  CssClass="btn_3"/>
  </div>
<div  style="padding-top:10px;" >
          <asp:Button    ID="btnFirstAdvisory" runat="server" Text="<%$ Resources:Resource,ConsultScheduleString%>"  CssClass="btn_6"/>
          <asp:Button    ID="btnFirstCase" runat="server" Text="<%$ Resources:Resource,OrderScheduleString%>"  CssClass="btn_5"/>
          <asp:Button    ID="btnFirstSchedule" runat="server" Text="<%$ Resources:Resource,ScheduleString%>"  CssClass="btn_5"/>
          <asp:Button    ID="btnFirstClient" runat="server" Text="<%$ Resources:Resource,CustomerScheduleString%>"  CssClass="btn_5"/>
          <asp:Button    ID="btnFirstChurch" runat="server" Text="<%$ Resources:Resource,LocationReservationString%>"  CssClass="btn_5"/>
  </div>
<asp:GridView runat="server" ID="gvConsultTimetable" CssClass="tablestyle" 
    AllowSorting="True" AllowPaging="True"
    ShowHeaderWhenEmpty="True" >
    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />    
    <Columns>
        <asp:TemplateField HeaderText="Test">
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
