<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case.aspx.cs" Inherits="TheWeWebSite.CaseMgt._case" %>

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
    <asp:Button    ID="btnCaseMgt" runat="server" Text="案件管理"   class="btn_4" />
    <asp:Button    ID="btnSerchMgt" runat="server" Text="查詢管理"  class="btn_1" />
    <asp:Button    ID="btnBuyMgt" runat="server" Text="採購作業"  class="btn_1"/>
    <asp:Button    ID="btnSellMgt" runat="server" Text="銷貨作業"  class="btn_1" />
    <asp:Button    ID="btnFinancialMgt" runat="server" Text="財務作業"  class="btn_1"/>
    <asp:Button    ID="btnSystemMgt" runat="server" Text="系統管理"  class="btn_1"  style="margin-right:10px;"/>
  </div>
  </div>
<div id="content" style="background:#FFFFFF; height:auto;" >
  <div>
          <asp:Button    ID="btnCaseRemind" runat="server" Text="工作提醒"  class="btn_3"/>
  </div>
<div  style="padding-top:10px;" >
                <asp:Button ID="btnCase" runat="server" Text="客戶維護" class="btn_6" />
                <asp:Button ID="btnCaseAdvisory" runat="server" Text="諮詢維護" class="btn_5" />
                <asp:Button ID="btnCaseList" runat="server" Text="案件維護" class="btn_5" />
                <asp:Button ID="btnCaseTime" runat="server" Text="時程維護" class="btn_5" />

    <div style="padding-top:10px; float:right ">
         <asp:Button ID="btnSerch" runat="server" class="btn_7" Text="查詢"/>
         <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
         <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
         <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>
    </div>
  </div>

      </div>
  <div style="padding-top:20px;">
     <asp:Label ID="labelLanguageId" runat="server" Text="語系編號："></asp:Label>
    <select>
      <option selected="selected">請選擇語系編號</option>
    </select>
     <asp:Label ID="labelMemberId" runat="server" Text="會員編號："></asp:Label>
    <input type="text" placeholder="請輸入會員編號..."/>
     <asp:Label ID="labelBrideBirthday" runat="server" Text="新娘生日："></asp:Label>
    <input type="date" />
     <asp:Label ID="labelBridegroomBirthday" runat="server" Text="新郎生日："></asp:Label>
    <input type="date"/>
  </div>
  <div style="padding-top:10px; " >
     <asp:Label ID="labeBrideName" runat="server" Text="新娘姓名："></asp:Label>
    <input type="text" placeholder="請輸入新娘姓名..."/>
     <asp:Label ID="labelBrideTel" runat="server" Text="新娘電話："></asp:Label>
    <input type="tel" placeholder="請輸入新娘電話..."/>
     <asp:Label ID="labelBirdeLine" runat="server" Text="新娘Line ID："></asp:Label>
    <input type="text" placeholder="請輸入新娘Line ID..."/>
     <asp:Label ID="labelBrideMain" runat="server" Text="新娘Mail："></asp:Label>
    <input type="email" placeholder="請輸入新娘Mail..."/>
     <asp:Label ID="labelBrideNickname" runat="server" Text="新娘暱稱："></asp:Label>
    <input type="text" placeholder="請輸入新娘暱稱..."/>
  </div>
  <div style="padding-top:10px; " >
     <asp:Label ID="labelBridegroomName" runat="server" Text="新郎姓名："></asp:Label>
    <input type="text" placeholder="請輸入新郎姓名..."/>
     <asp:Label ID="labelBridegroomTel" runat="server" Text="新郎電話："></asp:Label>
    <input type="tel" placeholder="請輸入新郎電話..."/>
     <asp:Label ID="labelBridegroomLine" runat="server" Text="新郎Line ID："></asp:Label>
    <input type="text" placeholder="請輸入新郎Line ID..."/>
     <asp:Label ID="labelBridegroomMail" runat="server" Text="新郎Mail："></asp:Label>
    <input type="email" placeholder="請輸入新郎Mail..."/>
     <asp:Label ID="labelBridegroomNickname" runat="server" Text="新郎暱稱："></asp:Label>
    <input type="text" placeholder="請輸入新郎暱稱..."/>
  </div>
  <div style="padding-top:10px; " >
     <asp:Label ID="labelBridePassport" runat="server" Text="新娘護照英文："></asp:Label>
    <input type="text" placeholder="請輸入新娘護照英文..."/>
     <asp:Label ID="labelBridegroomPassport" runat="server" Text="新郎護照英文："></asp:Label>
    <input type="tel" placeholder="請輸入新郎護照英文..."/>
     <asp:Label ID="labelOther" runat="server" Text="備註："></asp:Label>
    <input type="text" placeholder="請輸入備註..."/>
  </div>
  <div style="padding-top:10px; " >
     <asp:Label ID="labelAddress" runat="server" Text="地址："></asp:Label>
    <input type="text" placeholder="請輸入地址..."/>
  </div>
  <div style="padding-top:10px; " >
     <asp:Label ID="laberSerchSource" runat="server" Text="搜尋管道："></asp:Label>
    <select>
      <option selected="selected">請選擇搜尋管道</option>
    </select>
     <asp:Label ID="labelTel" runat="server" Text="簡訊手機："></asp:Label>
    <input type="tel" placeholder="請輸入簡訊手機..."/>
     <asp:Label ID="labelTelName" runat="server" Text="簡訊稱呼："></asp:Label>
    <input type="text" placeholder="請輸入簡訊稱呼..."/>
  </div>



  <table class="tablestyle"> 
    <tr>
      <th>諮詢案號</th>
      <th>案件代號</th>
      <th>產品</th>
      <th>產品內容</th>
      <th>成案日期</th>
      <th>結案日期</th>
      <th>費用</th>
    </tr>
    <tr>
      <td class="text-left">CU00001</td>
      <td class="text-left">Joye</td>
      <td class="text-left">小讌</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
    </tr>
    <tr>
      <td class="text-left">CU00001</td>
      <td class="text-left">Joye</td>
      <td class="text-left">小讌</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
    </tr>
  </table>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
