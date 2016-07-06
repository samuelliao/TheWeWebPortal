<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="system.aspx.cs" Inherits="TheWeWebSite.SysMgt.system" %>

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
    <link href="../css/btn_8.css" rel="stylesheet" />
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
    <asp:Button    ID="btnSystemMgt" runat="server" Text="系統管理"  class="btn_4"  style="margin-right:10px;"/>
  </div>
  </div>
<div id="content" style="background:#FFFFFF; height:auto;" >
  <div>
          <asp:Button    ID="btnCaseRemind" runat="server" Text="工作提醒"  class="btn_3"/>
  </div>
<div  style="padding-top:10px;" >
                <asp:Button ID="btnCase" runat="server" Text="登錄維護" class="btn_6" />
                <asp:Button ID="btnCaseAdvisory" runat="server" Text="權限類別" class="btn_5" />
                <asp:Button ID="btnCaseList" runat="server" Text="案件權限" class="btn_5" />
                <asp:Button ID="btnCaseTime" runat="server" Text="常用簡訊" class="btn_5" />
                <asp:Button ID="Button1" runat="server" Text="單位" class="btn_5" />
                <asp:Button ID="Button2" runat="server" Text="幣別" class="btn_5" />

  </div>
     <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelStoreId" runat="server" Text="店編號："></asp:Label>
    <input type="text" placeholder="請輸入店編號..."/>
    <asp:Label ID="labelAccount" runat="server" Text="帳號："></asp:Label>
    <input type="text" placeholder="請輸入帳號..."/>
    <asp:Label ID="labelPw" runat="server" Text="密碼："></asp:Label>
    <input type="password" placeholder="請輸入密碼..."/>
    <asp:Label ID="labelConfirmPw" runat="server" Text="密碼確認："></asp:Label>
   <input type="password" placeholder="請再次輸入密碼..."/>
  </div>
  <div style="padding-top:20px;" >
    <asp:Label ID="labelEmployeeId" runat="server" Text="員工編號:"></asp:Label>
    <input type="text" placeholder="請輸入會員編號..."/>
    
    <asp:Label ID="labelEffective" runat="server" Text="是否有效："></asp:Label>
    <select>    <option selected="selected">請選擇是否有效</option></select>
  </div>

       <div style="float:right">
         <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
         <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
         <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>
</div>

  <table class="tablestyle"> 
    <tr>
      <th>店編號</th>
      <th>帳號</th>
      <th>密碼</th>
      <th>會員編號</th>
      <th>是否有效</th>
    </tr>
    <tr>
      <td class="text-left">台北</td>
      <td class="text-left">Joye</td>
      <td class="text-left">**********</td>
      <td class="text-left">1234321</td>
      <td class="text-left">Y</td>
    </tr>
    <tr>
      <td class="text-left">上海</td>
      <td class="text-left">Mary</td>
      <td class="text-left">********</td>
      <td class="text-left">1234321</td>
      <td class="text-left">Y</td>

    </tr>
  </table>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
