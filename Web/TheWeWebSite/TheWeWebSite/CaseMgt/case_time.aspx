<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="case_time.aspx.cs" Inherits="TheWeWebSite.CaseMgt.case_time" %>

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
                <asp:Button ID="btnCaseAdvisory" runat="server" Text="諮詢維護" class="btn_5" />
                <asp:Button ID="btnCaseList" runat="server" Text="案件維護" class="btn_5" />
                <asp:Button ID="btnCaseTime" runat="server" Text="時程維護" class="btn_6" />
  </div>

       <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
   <asp:Label ID="labelCaseId" runat="server" Text="案件編號："></asp:Label>
     <input type="text" placeholder="請輸入案件編號..."/>
   <asp:Label ID="labelBreide" runat="server" Text="新娘："></asp:Label>
    <input type="text" placeholder="請輸入查詢新娘..."/>
   <asp:Label ID="labelBreidegroom" runat="server" Text="新郎："></asp:Label>
    <input type="text" placeholder="由系統填寫..."/>
   <asp:Label ID="labelStartDate" runat="server" Text="開案日期："></asp:Label>
    <input type="date" />
  </div>
  <div style="padding-top:10px; " >
   <asp:Label ID="labelCountry" runat="server" Text="國家："></asp:Label>
    <input type="text" placeholder="由系統填寫..."/>
   <asp:Label ID="labelArea" runat="server" Text="地區："></asp:Label>
    <input type="text" placeholder="由系統填寫..."/>
   <asp:Label ID="labelLocation" runat="server" Text="地點："></asp:Label>
    <input type="text" placeholder="由系統填寫..."/>
        
       <asp:Button ID="btnReservation1" runat="server" class="btn_8" Text="預約" />

   <asp:Label ID="labelMeetingDate" runat="server" Text="會議日期："></asp:Label>
    <input type="date" />
  </div>
    <div>
	<div style="float:left; width: 25%; padding:5px; ">
      <table class="tablestyle"> 
    <tr>
      <th>會議項目</th>
    
    </tr>
    <tr>
      <td class="text-left">第一次會議</td>

    </tr>
    <tr>
     <td class="text-left">第二次會議</td>    </tr>
     <tr>
     <td class="text-left">第三次會議</td>    </tr>
      <td class="text-left">第四次會議</td>    </tr>
       <td class="text-left">第五次會議</td>    </tr>
    </table>
    </div>
    
      <div  style="border-color:#000000;border-style:solid;border-width:3px;padding:5px; margin-top: 10px; width:70%; float: right; height: 300px;">
     
      <div style="padding-top:10px; " >
   <asp:Label ID="labelHotel" runat="server" Text="住宿飯店："></asp:Label>
    <input type="text" placeholder="請輸入住宿飯店..."/>
   <asp:Label ID="labelHotelAddress" runat="server" Text="地址："></asp:Label>
    <input type="text" placeholder="請輸入地址..."/>
  </div>
     <div style="padding-top:10px; " >
   <asp:Label ID="labelHotelPeople" runat="server" Text="人數："></asp:Label>
    <input type="text" placeholder="請輸入人數..."/>
   <asp:Label ID="labelHotelDate" runat="server" Text="住宿日期："></asp:Label>
    <input type="date" />
    <div style="padding-top:10px; float: right;">
         <asp:Button ID="btnReservation2" runat="server" class="btn_8" Text="預約"/>
 
    <input type="date" />
    </div>
  </div>
  <div style="padding-top:10px; " >
   <asp:Label ID="labelHotelFood" runat="server" Text="餐飲："></asp:Label>
    <input type="text" placeholder="餐飲..."/>
   <asp:Label ID="labelAnnex" runat="server" Text="附件："></asp:Label>
   
  </div>
  <div style="padding-top:10px; " >
   <asp:Label ID="labelBouquet" runat="server" Text="捧花："></asp:Label>
    <input type="text" placeholder="捧花..."/>
   <asp:Label ID="labelBouquetPhoto" runat="server" Text="照片："></asp:Label>

  </div>
</div>
    </div>
</div>
<div id="footer"></div>


    </form>
</body>
</html>
