<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remind.aspx.cs" Inherits="TheWeWebSite.CaseMgt.case_remind" %>

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
    <asp:Button    ID="btnFirst" runat="server" Text="首頁"  class="btn_1" />
    <asp:Button    ID="btnStoreMgt" runat="server" Text="開店管理"   class="btn_1" />
    <asp:Button    ID="btnCaseMgt" runat="server" Text="案件管理"   class="btn_1" />
    <asp:Button    ID="btnSerchMgt" runat="server" Text="查詢管理"  class="btn_1" />
    <asp:Button    ID="btnBuyMgt" runat="server" Text="採購作業"  class="btn_1"/>
    <asp:Button    ID="btnSellMgt" runat="server" Text="銷貨作業"  class="btn_1" />
    <asp:Button    ID="btnFinancialMgt" runat="server" Text="財務作業"  class="btn_1"/>
    <asp:Button    ID="btnSystemMgt" runat="server" Text="系統管理"  class="btn_1"  style="margin-right:10px;"/>
  </div>
  </div>
<div id="content" style="background:#FFFFFF; height:auto;" >
  <div>
          <asp:Button    ID="btnCaseRemind" runat="server" Text="工作提醒"  class="btn_6"/>
  </div>
<div  style="padding-top:10px;" >
          <asp:Button    ID="btnCaseAdvisory" runat="server" Text="諮詢維護"  class="btn_5"/>
          <asp:Button     runat="server" Text="訂單維護"  class="btn_5"/>
          <asp:Button    ID="btnCaseTime" runat="server" Text="時程維護"  class="btn_5"/>
  </div>

  <table class="tablestyle"> 
  <tr> 
    <th>案件編號</th> 
    <th>會員編號</th>
    <th>新娘</th>
    <th>新郎</th>
    <th>事件</th>
  </tr>
  <tr>
      <td class="text-left">CU00001</td>
      <td class="text-left">Joye</td>
      <td class="text-left">小讌</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
    </tr>
    <tr>
      <td class="text-left">CU00001</td>
      <td class="text-left">Joye</td>
      <td class="text-left">小讌</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
    </tr>
</table>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
