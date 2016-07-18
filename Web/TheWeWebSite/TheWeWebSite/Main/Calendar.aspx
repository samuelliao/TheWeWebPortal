<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calendar.aspx.cs" Inherits="TheWeWebSite.Main.Calendar" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
</head>

<body class="landing">
    <form runat="server">
        <div id="page-wrapper">

            <!-- Header -->
            <My:Header runat="server" ID="ucHeader" />

            <!-- Main -->
            <section id="main">

                <!-- Text -->
                <section class="box title">
                    <h3>
                        <asp:Label runat="server" Text="首頁&nbsp;&nbsp;>&nbsp;&nbsp;行程表(待修改)"></asp:Label></h3>
                </section>

                <!-- Input -->
                <section class="box special">
                    <!-- Calendar-->
                    <div class="row">
                        <div class="12u">
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
                                        <div class="date">14</div>
                                        <div class="event">
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
                                        <div class="date">1</div>
                                        <!-- Next Month -->
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

                            </div>
                        </div>
                    </div>

                </section>


            </section>

            <!-- Footer -->
            <footer id="footer">
                <ul class="copyright">
                    <li>rights.</li>
                    <li>The We Wedding</li>
                </ul>
            </footer>

        </div>

        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
        <script src="../assets/js/table.js"></script>
    </form>
</body>
</html>
