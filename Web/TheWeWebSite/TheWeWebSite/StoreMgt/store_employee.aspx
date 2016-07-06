<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="store_employee.aspx.cs" Inherits="TheWeWebSite.StroeMgt.store_employee" %>

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
                <asp:Button ID="btnStoreDress" runat="server" Text="禮服維護" class="btn_5" />
                <asp:Button ID="btnStoreChurch" runat="server" Text="教堂維護" class="btn_5" />
                <asp:Button ID="btnStroeEmployee" runat="server" Text="員工維護" class="btn_6" />
            </div>
  
  
            <div style="padding-top: 20px;">
                <asp:Label ID="labelLanguageId" runat="server" Text="語系編號："></asp:Label>
<select>
                    <option  selected="selected">請選擇語系編號</option>
                </select>
                <asp:Label ID="labelEmployeeId" runat="server" Text="員工編號："></asp:Label>
                <input type="text" placeholder="請輸入員工編號..."/>
                <asp:Label ID="labelName" runat="server" Text="姓名："></asp:Label>
                <input type="text" placeholder="請輸入姓名..."/>
                <asp:Label ID="labelPhone" runat="server" Text="電話："></asp:Label>
                <input type="tel" placeholder="請輸入電話..."/>
            </div>
            <div style="padding-top: 10px;">
                <asp:Label ID="labelAddress" runat="server" Text="地址："></asp:Label>
                <input type="text" placeholder="請輸入地址..."/>
                <asp:Label ID="labelBirthday" runat="server" Text="生日："></asp:Label>
                <input type="date" />
            </div>
            <div style="padding-top: 10px;">
                <asp:Label ID="labelRootCase" runat="server" Text="權限類別："></asp:Label>
                <select>
                    <option  selected="selected">請選擇權限類別</option>
                </select>
                <asp:Label ID="labelComeDate" runat="server" Text="到職日期："></asp:Label>
                <input type="date" />
                <asp:Label ID="labelLeaveDate" runat="server" Text="離職日期："></asp:Label>
                <input type="date" />
                <asp:Label ID="labelOther" runat="server" Text="備註："></asp:Label>
                <input type="text" placeholder="請輸入備註..."/>
            </div>
            <div style="padding-top: 10px; float: right;">

                <asp:Button ID="btnInsert" runat="server" class="btn_7" Text="新增"/>
                <asp:Button ID="btnEdit" runat="server" class="btn_7" Text="修改"/>
                <asp:Button ID="BtnDel" runat="server" class="btn_7" Text="刪除"/>
                <asp:Button ID="btnSerch" runat="server" class="btn_7" Text="查詢"/>
                <asp:Button ID="btnClean" runat="server" class="btn_7" Text="清除"/>
            </div>



            <table class="tablestyle">
                <tr>

                    <th>語系編號</th>
                    <th>員工編號</th>
                    <th>姓名</th>
                    <th>電話</th>
                    <th>地址</th>
                    <th>生日</th>
                    <th>權限類別</th>
                    <th>到職日期</th>
                    <th>離職日期</th>
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
