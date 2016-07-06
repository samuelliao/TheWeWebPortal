<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case_advisory.aspx.cs" Inherits="TheWeWebSite.CaseMgt.case_advisory" %>

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
                <asp:Button ID="btnCase" runat="server" Text="客戶維護" class="btn_5" />
                <asp:Button ID="btnCaseAdvisory" runat="server" Text="諮詢維護" class="btn_6" />
                <asp:Button ID="btnCaseList" runat="server" Text="案件維護" class="btn_5" />
                <asp:Button ID="btnCaseTime" runat="server" Text="時程維護" class="btn_5" />
  </div>

    <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelAdvisoryId" runat="server" Text="諮詢案號："></asp:Label>
     <input type="text" placeholder="請輸入諮詢案號..."/>
     <asp:Label ID="labeBrideName" runat="server" Text="新娘姓名："></asp:Label>
    <input type="text" placeholder="請輸入新娘姓名..."/>
     <asp:Label ID="labelBridegroomName" runat="server" Text="新郎姓名："></asp:Label>
    <input type="date" />
         <asp:Button ID="btnSerch" runat="server" class="btn_8" Text="查詢"/>
  </div>

  <table class="tablestyle"> 
    <tr>
      <th>SEQ</th>
      <th>諮詢日期</th>
      <th>顧問</th>
      <th>會議內容</th>
      <th>下次會議日期</th>
      <th>下次會議內容</th>
      <th>備註</th>
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

     <div  style="border-color:#000000;border-style:solid;border-width:3px;padding:5px; margin-top: 10px; ">
  <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelAdvisoryDate" runat="server" Text="諮詢日期："></asp:Label>
  <input type="date" />
     <asp:Label ID="labelReservationDate" runat="server" Text="預約日期："></asp:Label>
    <input type="date" />
    <div style="float:right">
         <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
         <asp:Button ID="btnSave" runat="server" class="btn_7" Text="存檔"/>
         <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
         <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>
</div>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelInterest" runat="server" Text="興趣事項："></asp:Label>
    <select style="width: 300px">
     <option selected="selected">請選擇興趣事項</option>
  </select>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelInterestCountry" runat="server" Text="興趣國家："></asp:Label>
     <select  style="width: 300px">
     <option selected="selected">請選擇興趣國家</option>
  </select>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelInterestChurch" runat="server" Text="興趣教堂："></asp:Label>
     <select style="width: 300px">
     <option selected="selected">請選擇興趣教堂</option>
  </select>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelWeddingConsultants" runat="server" Text="婚禮顧問："></asp:Label>
     <select  style="width: 300px">
     <option selected="selected">請選擇婚禮顧問</option>
  </select>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelPredictionPhoto" runat="server" Text="預計拍攝日："></asp:Label>
<input type="date" />
  <input type="checkbox" id="checkPredictionPhotoNotyet"/>
      <asp:Label ID="labelPredictionPhotoNotyet" runat="server" Text="未決定"></asp:Label>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelPredictionWedding" runat="server" Text="預計婚禮日："></asp:Label>
<input type="date" />
  <input type="checkbox" id="checkPredictionWeddingNotyet"/>
      <asp:Label ID="labelPredictionWeddingNotyet" runat="server" Text="未決定"></asp:Label>
  <div style="padding-top:10px; float: right;"> 
   <asp:Label ID="labelCaseOkDate" runat="server" Text="結案時間："></asp:Label>
<input type="date" />
  </div>
  </div>
  <div style="padding-top:10px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
     <asp:Label ID="labelBanquet" runat="server" Text="國內宴客日："></asp:Label>
<input type="date" />
  <input type="checkbox" id="checkBanquetNotyet"/>
      <asp:Label ID="labelBanquetNotyet" runat="server" Text="未決定"></asp:Label>
  <div style=" float: right;"> 
   <asp:Label ID="labelPaidDate" runat="server" Text="簽約時間："></asp:Label>
<input type="date" />
  </div>
  </div>
  </div>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
