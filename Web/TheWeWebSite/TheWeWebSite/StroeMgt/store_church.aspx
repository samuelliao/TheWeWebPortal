<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="store_church.aspx.cs" Inherits="TheWeWebSite.StroeMgt.store_church" %>

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

                <asp:Label ID="labelLocate" runat="server" Text="台北" Style="font-size: 20px; color: #516CC5; padding-right: 10px;"></asp:Label>
                <asp:Button ID="btnFirst" runat="server" Text="首頁" class="btn_1" />
                <asp:Button ID="btnStoreMgt" runat="server" Text="開店管理" class="btn_4" />
                <asp:Button ID="btnCaseMgt" runat="server" Text="案件管理" class="btn_1" />
                <asp:Button ID="btnSerchMgt" runat="server" Text="查詢管理" class="btn_1" />
                <asp:Button ID="btnBuyMgt" runat="server" Text="採購作業" class="btn_1" />
                <asp:Button ID="btnSellMgt" runat="server" Text="銷貨作業" class="btn_1" />
                <asp:Button ID="btnFinancialMgt" runat="server" Text="財務作業" class="btn_1" />
                <asp:Button ID="btnSystemMgt" runat="server" Text="系統管理" class="btn_1" Style="margin-right: 10px;" />
            </div>
        </div>
        <div id="content" style="background: #FFFFFF; height: auto;">
            <div>
                <asp:Button ID="btnCaseRemind" runat="server" Text="工作提醒" class="btn_3" />
            </div>
            <div style="padding-top: 10px;">
                <asp:Button ID="btnFirstAdvisory" runat="server" Text="產品維護" class="btn_5" />
                <asp:Button ID="btnFirstCase" runat="server" Text="禮服維護" class="btn_5" />
                <asp:Button ID="btnFirstSchedule" runat="server" Text="教堂維護" class="btn_6" />
                <asp:Button ID="btnFirstClient" runat="server" Text="員工維護" class="btn_5" />
            </div>

               <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelCountry" runat="server" Text="國家："></asp:Label>
    <select> <option selected="selected">請選擇國家</option></select>
    <asp:Label ID="labelArea" runat="server" Text="地區："></asp:Label>
<select> <option selected="selected">請選擇地區</option></select>
    <asp:Label ID="labelChurchName" runat="server" Text="教堂名稱："></asp:Label>
    <select> <option selected="selected">請選擇教堂名稱</option></select>
 <asp:Button ID="Button1" runat="server" class="btn_8" Text="查詢"/>
  </div>

             <div style="padding-top: 10px; float: right;">

                <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
                <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
                <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>

            </div>

            <table class="tablestyle"> 
    <tr> 
    <th>諮詢編號</th> 
    <th>顧問</th>
    <th>諮詢者</th>
    <th>電話</th>
    <th>預約日期</th>
    <th>內容說明</th>
    <th>最後一次回覆時間</th>
    <th>備註</th>
    <th>回覆</th>
    <th>行程表</th> 
  </tr>
  <tr>
      <td class="text-left">CU00001</td>
      <td class="text-left">Joye</td>
      <td class="text-left">小讌</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
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
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
      <td class="text-left">1234321</td>
    </tr>
</table>
        </div>
        <div id="footer" ></div>


    </form>
</body>
</html>
