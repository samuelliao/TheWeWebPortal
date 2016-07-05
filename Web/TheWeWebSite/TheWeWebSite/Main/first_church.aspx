<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="first_church.aspx.cs" Inherits="TheWeWebSite.Main.first_church" %>

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
    <asp:Button    ID="btnFirst" runat="server" Text="首頁"  class="btn_4" />
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
          <asp:Button    ID="btnCaseRemind" runat="server" Text="工作提醒"  class="btn_3"/>
  </div>
<div  style="padding-top:10px;" >
          <asp:Button    ID="btnFirstAdvisory" runat="server" Text="諮詢行程"  class="btn_5"/>
          <asp:Button    ID="btnFirstCase" runat="server" Text="案件行程"  class="btn_5"/>
          <asp:Button    ID="btnFirstSchedule" runat="server" Text="行程表"  class="btn_5"/>
          <asp:Button    ID="btnFirstClient" runat="server" Text="客戶行程"  class="btn_5"/>
          <asp:Button    ID="btnFirstChurch" runat="server" Text="教堂預約"  class="btn_6"/>
  </div>

 <div style="margin-top: 20px;";>
	    <div style="float:left;border-color:#000000;border-style:inset;border-width:1px;padding:5px; margin-top: 10px; width:15%; height: 480px; ">
	      <h2 style="font-size:30px;">教堂</h2>
	      <ul>
   <li><a >台灣</a></li>
   <li><a >日本</a></li>
   <ul>
   <li style="font-size:14px;">北海道</li>
   <li style="font-size:14px;">東京都</li>
   <ul>
   <li style="font-size:6px;">花園塔王子-森林教堂</li>
   <li style="font-size:6px;">品川王子-白色教堂</li>
   </ul>
   <li style="font-size:14px;">長野縣</li>
   </ul>
   <li><a >英國</a></li>
   <li><a >法國</a></li>
   <li><a >義大利</a></li>
   <li><a >不丹</a></li>
   
  </ul>
 </div>

        
  </div>
    <div style="float:left;  padding:5px; width:80%; height: 450px;  margin-top:15px" > 
    <table class="month" >
    <caption ><span class="date" >2016 .  July </span> 
         <asp:Button    ID="btnInsert" runat="server" Text="新增" class="btn_8" style=" margin-right:20px; background:#F288B8; color:#FFFFFF; float:right;" />

    </caption>
    <tr>
    <th scope="col"><span>Sun</th>
        <th scope="col">Mon</th>
        <th scope="col">Tue</th>
        <th scope="col">Wed</th>
        <th scope="col">Thu</th>
        <th scope="col">Fri</th>
        <th scope="col">Sat</th>
        
    </tr>
    <tr>
        <td >26</td>
        <td>27</td>
        <td class="active">28
        <ul>
            <li >台灣拍照</li>
        </ul>
        </td>
        <td>29</td>
        <td>30</td>
        <td>1</td>
        <td>2</td>
    </tr>
    <tr>
        <td class="active">3
        <ul>
            <li>香港婚禮</li>
        </ul>
        </td>
        <td>4</td>
        <td>5</td>
        <td>6</td>
        <td>7</td>
        <td>8</td>
        <td class="active">9
        <ul>
            <li >日本婚禮</li>
            <li>香港婚禮</li>
        </ul>
        </td>
    </tr>
    <tr>
        <td>10</td>
        <td>11</td>
        <td>12</td>
        <td class="active">13
        <ul>
            <li>上海婚禮</li>
        </ul>
        </td>
        <td >14
        </td>
        <td>15</td>
        <td>16</td>
    </tr>
    <tr>
        <td>17</td>
        <td>18</td>
        <td>19</td>
        <td>20</td>
        <td>21</td>
        <td class="active">22
        <ul>
            <li>日本婚禮</li>
        </ul>
        </td>
        <td>23
        </td>
    </tr>
    <tr>
        <td>24</td>
        <td>25</td>
        <td >26
        </td>
        <td class="active">27
            <ul>
            <li >日本婚禮</li>
            <li>台灣婚禮</li>
            </ul>
        </td>
        
        <td >28</td>
        <td >29</td>
        <td >30</td>
    </tr>
</table>
    </div>
  </div>
<div id="footer" ></div>


    </form>
</body>
</html>
