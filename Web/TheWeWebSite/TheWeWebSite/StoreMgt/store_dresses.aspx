<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="store_dresses.aspx.cs" Inherits="TheWeWebSite.StroeMgt.store_dresses" %>

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
                <asp:Button ID="btnStore" runat="server" Text="產品維護" class="btn_5" />
                <asp:Button ID="btnStoreDress" runat="server" Text="禮服維護" class="btn_6" />
                <asp:Button ID="btnStoreChurch" runat="server" Text="教堂維護" class="btn_5" />
                <asp:Button ID="btnStroeEmployee" runat="server" Text="員工維護" class="btn_5" />
            </div>

               <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelDressId" runat="server" Text="禮服編號："></asp:Label>
    <input type="text" placeholder="請輸入禮服編號..."/>
    <asp:Label ID="labelDressGender" runat="server" Text="性別："></asp:Label>
<select> <option  selected="selected">請選擇性別</option></select>
    <asp:Label ID="labelDressCategory" runat="server" Text="禮服類別："></asp:Label>
    <select> <option  selected="selected">請選擇禮服類別</option></select>
    <asp:Label ID="labelDressColor" runat="server" Text="禮服顏色："></asp:Label>
   <select><option  selected="selected">請選擇禮服顏色</option></select>
  </div>
      <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelDressType" runat="server" Text="型態："></asp:Label>
    <select><option  selected="selected">請選擇型態</option></select>
    <asp:Label ID="labelDressNeckline" runat="server" Text="領口："></asp:Label>
<select><option  selected="selected">請選擇領口</option></select>
    <asp:Label ID="labelDressBack" runat="server" Text="後背："></asp:Label>
    <select><option  selected="selected">請選擇後背</option></select>
    <asp:Label ID="labelDressShoulder" runat="server" Text="肩膀："></asp:Label>
    <select><option  selected="selected">請選擇肩膀</option></select>
  </div>
      <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelDressMaterial" runat="server" Text="質料："></asp:Label>
    <select><option  selected="selected">請選擇質料</option></select>
    <asp:Label ID="labelDressWorn" runat="server" Text="穿法："></asp:Label>
<select><option  selected="selected">請選擇穿法</option></select>
    <asp:Label ID="labelDressVeil" runat="server" Text="頭紗："></asp:Label>
    <select><option  selected="selected">請選擇頭紗</option></select>
    <asp:Label ID="labelDressFitting" runat="server" Text="配件："></asp:Label>
    <select><option  selected="selected">請選擇配件</option></select>
  </div>
      <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelDressCorsage" runat="server" Text="胸花："></asp:Label>
    <select><option  selected="selected">請選擇胸花</option></select>
    <asp:Label ID="labelDressGloves" runat="server" Text="手套："></asp:Label>
<select><option  selected="selected">請選擇手套</option></select>
    <asp:Label ID="labelDressOther" runat="server" Text="其他："></asp:Label>
    <input type="text" placeholder="請輸入其他..."/>
    <asp:Label ID="labelDressStatusCode" runat="server" Text="：">狀態碼：</asp:Label>
    <select><option  selected="selected">請選擇狀態碼</option></select>
  </div>
      <div style="padding-top:20px;" 　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　>
    <asp:Label ID="labelDressUseStatus" runat="server" Text="使用狀況："></asp:Label>		
    <select><option  selected="selected">請選擇使用狀態</option></select>
    <input type="checkbox" id="checkOutsider"/>
    <asp:Label ID="labelOutsider" runat="server" Text="可外拍"></asp:Label>
     <asp:Label ID="labelIncrease" runat="server" Text="加價"></asp:Label>
<input type="text"/>
    <asp:Label ID="labelRent" runat="server" Text="租金："></asp:Label>
<input type="text"/>

    <input type="checkbox" id="checkDomesticWedding"/>
    <asp:Label ID="labelDomesticWedding" runat="server" Text="現國內婚宴"></asp:Label>
    <input type="checkbox" id="checkIncreaseType"/>
    <asp:Label ID="labelIncreaseType" runat="server" Text="加價款"></asp:Label>
    <input type="checkbox" id="checkBigSize"/>
    <asp:Label ID="labelBigSize" runat="server" Text="大尺碼"></asp:Label>
  </div>


            <div style="padding-top: 10px; float: right;">

                <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
                <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
                <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>

            </div>


            <table class="tablestyle"> 
    <tr> 
    <th>禮服編號</th> 
    <th>禮服類別</th>
    <th>禮服顏色</th>
    <th>型態</th>
    <th>領口</th>
    <th>後背</th>
    <th>肩膀</th>
    <th>質料</th>
    <th>穿法</th>
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
    </tr>
</table>
        </div>
        <div id="footer"></div>


    </form>
</body>
</html>
