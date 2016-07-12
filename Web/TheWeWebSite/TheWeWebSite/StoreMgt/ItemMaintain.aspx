<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ItemMaintain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>
<body class="landing">
    <form runat="server">
        <div id="page-wrapper">

            <!-- Header -->
            <header id="header">
                <h1>
                    <asp:Label runat="server" Text="台北"></asp:Label></h1>

                <nav id="nav">
                    <ul>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WorkReminderString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="linkWorkReminder" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkConsultMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkOrderMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMgt" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,MainPageString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkMain" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultString%>" PostBackUrl="~/Main/Unsigned.aspx" ID="LinkUnsigned" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ScheduleString%>" PostBackUrl="~/Main/Case.aspx" ID="LinkCase" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ScheduleString%>" PostBackUrl="~/Main/Calendar.aspx" ID="LinkCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerScheduleString%>" PostBackUrl="~/Main/CustomerCalendar.aspx" ID="LinkCustomerCalendar" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LocationReservationString%>" PostBackUrl="~/Main/ChurchReservation.aspx" ID="LinkChurchReservtion" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StoreMgtString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkItemMaintain" />                            
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ProductMaintainString%>" PostBackUrl="~/StoreMgt/ItemMaintain.aspx" ID="LinkProductMgt" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,DressMaintainString%>" PostBackUrl="~/StoreMgt/DressMaintain.aspx" ID="LinkDressMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,AccessoryMaintainString%>" PostBackUrl="~/StoreMgt/FittingMaintain.aspx" ID="LinkFittingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,StyleMaintainString%>" PostBackUrl="~/StoreMgt/ModelingMaintain.aspx" ID="LinkModelingMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,WeddingItemMaintainString%>" PostBackUrl="~/StoreMgt/OtherItemMaintain.aspx" ID="LinkOtherItemMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ChurchMaintainString%>" PostBackUrl="~/StoreMgt/ChurchMaintain.aspx" ID="LinkChurchMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,EmployeeMaintainString%>" PostBackUrl="~/StoreMgt/EmployeeMaintain.aspx" ID="LinkEmployeeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,OrderMgtString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCaseMgt" />                            
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CustomerMaintainString%>" PostBackUrl="~/CaseMgt/CustomerMaintain.aspx" ID="LinkCustomerMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ConsultMaintainString%>" PostBackUrl="~/CaseMgt/AdvisoryMaintain.aspx" ID="LinkButton1" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,ContractMaintainString%>" PostBackUrl="~/CaseMgt/CaseMaintain.aspx" ID="LinkCaseMaintain" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,TimetableMaintainString%>" PostBackUrl="~/CaseMgt/TimeMaintain.aspx" ID="LinkTimeMaintain" />
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SearchMgtString%>" ID="LinkSearchMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PurchaseMgtString%>" ID="LinkPuchaseMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SalesMgtString%>" ID="LinkSalesMgtString" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,FinMgtString%>" ID="LinkFinMgt" />
                        </li>
                        <li>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SysMgtString%>" ID="LinkSysMgt" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                            <ul>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LoginMaintainString%>" ID="LinkLoginMaintain" PostBackUrl="~/SysMgt/LoginMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,PermissionCategoryString%>" ID="LinkRootMaintain" PostBackUrl="~/SysMgt/RootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CasePermissionMgtString%>" ID="LinkCaseRootMaintain" PostBackUrl="~/SysMgt/CaseRootMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,SNSMgtString%>" ID="LinkMsgMaintain" PostBackUrl="~/SysMgt/MsgMaintain.aspx" />
                                </li>
                                <li>
                                    <asp:LinkButton runat="server" Text="<%$ Resources:Resource,CurrencyString%>" ID="LinkDollarMaintain" PostBackUrl="~/SysMgt/DollarMaintain.aspx" />
                                </li>
                            </ul>
                        </li>
                        <li><a>
                            <asp:LinkButton runat="server" Text="<%$ Resources:Resource,LogoutString%>" ID="LinkLogout" PostBackUrl="~/Login.aspx" />
                        </li>
                    </ul>
                </nav>
            </header>

            <!-- Banner -->
            <section id="banner">
                <h2>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label></h2>
                <p>
                    <asp:Label runat="server" Text="The We Wedding"></asp:Label>
                </p>

            </section>

            <!-- Main -->

            <section id="main" class="container">

                <!-- Text -->
                <section class="box special">
                    <header class="major">
                        <h3>
                            <asp:Label runat="server" Text="客戶維護"></asp:Label></h3>
                        <hr />
                    </header>

                    <!-- Input -->

                    <div class="row">
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇語系編號 -</option>
                                            <option value="1">Ch</option>
                                            <option value="1">Tw</option>
                                            <option value="1">En</option>
                                            <option value="1">Jp</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入會員編號..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘姓名..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <input placeholder="請輸入新娘生日..."  type="text" onfocus="(this.type='date')"  id="date" /> 
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘電話..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘Line Id..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘E-Mail..."></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘護照英文..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="12u">
                                    <asp:TextBox runat="server" placeholder="請輸入新娘地址..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <div class="select-wrapper">
                                        <select>
                                            <option value="">- 請選擇搜尋管道 -</option>
                                            <option value="1">a</option>
                                            <option value="1">b</option>
                                            <option value="1">c</option>
                                            <option value="1">d</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入簡訊手機..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="6u 12u(mobilep)">
                                    <asp:TextBox runat="server" placeholder="請輸入簡訊稱呼..."></asp:TextBox>
                                </div>
                            </div>

                            <div class="row uniform 50%">
                                <div class="12u">
                                    <textarea name="message" id="message" placeholder="備註..." rows="6"></textarea>
                                </div>
                            </div>

                            <div class="row uniform">
                                <div class="12u">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="修改" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" />
                                        </li>
                                    </ul>
                                </div>
                            </div>

                            <hr />



                        </div>
                    </div>

                    <!-- Table -->

                    <div class="row">
                        <div class="12u">

                            <h4>搜尋結果</h4>
                            <hr />
                            <div class="table-wrapper">
                                <table class="alt">
                                    <thead>
                                        <tr>
                                            <th>諮詢案號</th>
                                            <th>案件代號</th>
                                            <th>產品</th>
                                            <th>產品內容</th>
                                            <th>成案日期</th>
                                            <th>結案日期</th>
                                            <th>費用</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>A12322</td>
                                            <td>C02331</td>
                                            <td>Projct_1</td>
                                            <td>item_1,item_2,item3item_1,item_2,item4,item_5,item_6,item7,item_12,item_21,item8,item_15,item_22,item9,item_10,item_20,item30</td>
                                            <td>2016/02/03</td>
                                            <td>2016/06/13</td>
                                            <td>$231000</td>
                                        </tr>
                                        <tr>
                                            <td>A14322</td>
                                            <td>C02215</td>
                                            <td>Projct_2</td>
                                            <td>item_1,item_2</td>
                                            <td>2016/01/15</td>
                                            <td>2016/07/22</td>
                                            <td>$100000</td>
                                        </tr>
                                    </tbody>

                                </table>
                            </div>
                            <hr />
                        </div>
                    </div>

                   


                </section>

                 
            </section>

            <!-- CTA -->
           

            <!-- Footer -->
            <footer id="footer">
                <ul class="copyright">
                    <li>&copy; Untitled. All rights reserved.</li>
                    <li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
                </ul>
            </footer>

        </div>

         <!-- Calendar-->
                    <div id="calendar-wrap">
    		<header>
    			<h1>August 2014</h1>
    		</header>
    		<div id="calendar">
    			<ul class="weekdays">
    				<li>Sunday</li>
    				<li>Monday</li>
    				<li>Tuesday</li>
    				<li>Wednesday</li>
    				<li>Thursday</li>
    				<li>Friday</li>
    				<li>Saturday</li>
    			</ul>

    			<!-- Days from previous month -->

    			<ul class="days">
    				<li class="day other-month">
    					<div class="date">27</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">28</div>
    					<div class="event">
    						<div class="event-desc">
    							HTML 5 lecture with Brad Traversy from Eduonix
    						</div>
    						<div class="event-time">
    							1:00pm to 3:00pm
    						</div>
    					</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">29</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">30</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">31</div>    					
    				</li>

    				<!-- Days in current month -->

    				<li class="day">
    					<div class="date">1</div>    					
    				</li>
    				<li class="day">
    					<div class="date">2</div>
    					<div class="event">
    						<div class="event-desc">
    							Career development @ Community College room #402
    						</div>
    						<div class="event-time">
    							2:00pm to 5:00pm
    						</div>
    					</div>     					
    				</li>
    			</ul>

    				<!-- Row #2 -->

    			<ul class="days">
    				<li class="day">
    					<div class="date">3</div>    					
    				</li>
    				<li class="day">
    					<div class="date">4</div>    					
    				</li>
    				<li class="day">
    					<div class="date">5</div>    					
    				</li>
    				<li class="day">
    					<div class="date">6</div>    					
    				</li>
    				<li class="day">
    					<div class="date">7</div>
    					<div class="event">
    						<div class="event-desc">
    							Group Project meetup
    						</div>
    						<div class="event-time">
    							6:00pm to 8:30pm
    						</div>
    					</div>     					
    				</li>
    				<li class="day">
    					<div class="date">8</div>    					
    				</li>
    				<li class="day">
    					<div class="date">9</div>    					
    				</li>
    			</ul>

    				<!-- Row #3 -->

    			<ul class="days">
    				<li class="day">
    					<div class="date">10</div>    					
    				</li>
    				<li class="day">
    					<div class="date">11</div>    					
    				</li>
    				<li class="day">
    					<div class="date">12</div>    					
    				</li>
    				<li class="day">
    					<div class="date">13</div>    					
    				</li>
    				<li class="day">
    					<div class="date">14</div><div class="event">
    						<div class="event-desc">
    							Board Meeting
    						</div>
    						<div class="event-time">
    							1:00pm to 3:00pm
    						</div>
    					</div>     					
    				</li>
    				<li class="day">
    					<div class="date">15</div>    					
    				</li>
    				<li class="day">
    					<div class="date">16</div>    					
    				</li>
    			</ul>

    				<!-- Row #4 -->

    			<ul class="days">
    				<li class="day">
    					<div class="date">17</div>    					
    				</li>
    				<li class="day">
    					<div class="date">18</div>    					
    				</li>
    				<li class="day">
    					<div class="date">19</div>    					
    				</li>
    				<li class="day">
    					<div class="date">20</div>    					
    				</li>
    				<li class="day">
    					<div class="date">21</div>    					
    				</li>
    				<li class="day">
    					<div class="date">22</div>
    					<div class="event">
    						<div class="event-desc">
    							Conference call
    						</div>
    						<div class="event-time">
    							9:00am to 12:00pm
    						</div>
    					</div>     					
    				</li>
    				<li class="day">
    					<div class="date">23</div>    					
    				</li>
    			</ul>

    					<!-- Row #5 -->

    			<ul class="days">
    				<li class="day">
    					<div class="date">24</div>    					
    				</li>
    				<li class="day">
    					<div class="date">25</div>
    					<div class="event">
    						<div class="event-desc">
    							Conference Call
    						</div>
    						<div class="event-time">
    							1:00pm to 3:00pm
    						</div>
    					</div>     					
    				</li>
    				<li class="day">
    					<div class="date">26</div>    					
    				</li>
    				<li class="day">
    					<div class="date">27</div>    					
    				</li>
    				<li class="day">
    					<div class="date">28</div>    					
    				</li>
    				<li class="day">
    					<div class="date">29</div>    					
    				</li>
    				<li class="day">
    					<div class="date">30</div>    					
    				</li>
    			</ul>

    			<!-- Row #6 -->

    			<ul class="days">
    				<li class="day">
    					<div class="date">31</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">1</div> <!-- Next Month -->    					
    				</li>
    				<li class="day other-month">
    					<div class="date">2</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">3</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">4</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">5</div>    					
    				</li>
    				<li class="day other-month">
    					<div class="date">6</div>    					
    				</li>
    			</ul>

    		</div><!-- /. calendar -->
    	</div><!-- /. wrap -->

        <!-- Scripts -->
        <script src="assets/js/jquery.min.js"></script>
        <script src="assets/js/jquery.dropotron.min.js"></script>
        <script src="assets/js/jquery.scrollgress.min.js"></script>
        <script src="assets/js/skel.min.js"></script>
        <script src="assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="assets/js/main.js"></script>
        <script src="assets/js/table.js"></script>
    </form>
</body>
</html>
