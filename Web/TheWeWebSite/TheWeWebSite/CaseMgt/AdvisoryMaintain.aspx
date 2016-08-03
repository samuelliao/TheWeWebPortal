<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvisoryMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.AdvisoryMaintain" %>

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
                        <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
                </section>
                <!-- Input -->

                <section class="box special">
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,AdviosryIdString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server"  ID="tbConsultSn"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server"  ID="tbBridalName"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server"  ID="tbGroomName"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="開案日期選擇範圍(開始)" ID="labelSearchStartDate"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" style="text-align:right" Cssclass="date date-1" value="" 
                                        placeholder="YYYY-MM-DD" ID="tbSearchStartDate"></asp:TextBox>
                                </div>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="開案日期選擇範圍(結束)" ID="labelSearchEndDate"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" style="text-align:right" Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"
                                        ID="tbSearchEndDate"></asp:TextBox>
                                </div>
                            </div>                            
                        </div>
                    </div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="會議日期選擇範圍(開始)" ID="labelBookStartDate"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" style="text-align:right" Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"
                                         ID="tbBookStartDate"></asp:TextBox>
                                </div>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="會議日期選擇範圍(結束)" ID="labelBookEndDate"></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox runat="server" style="text-align:right" Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"
                                         ID="tbBookEndDate"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->
                    <div class="Div btn">
                        <ul class="actions">
                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkAdvisoryMCreate" PostBackUrl="~/CaseMgt/AdvisoryMCreate.aspx" />
                            </li>
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                    ID="btnSearch" OnClick="btnSearch_Click" />
                            </li>

                        </ul>
                    </div>
                    <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                    <hr />

                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                    AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                    OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" OnDeleteCommand="dataGrid_DeleteCommand"
                                    DataKeyField="Id" OnSortCommand="dataGrid_SortCommand" Font-Size="Small">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AdviosryIdString%>" DataField="Sn" SortExpression="Sn"/>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,BridalNameString%>" DataField="BridalName" SortExpression="BridalName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,GroomNameString%>" DataField="GroomName" SortExpression="GroomName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,PhoneString%>" DataField="BridalPhone" SortExpression="BridalPhone" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,StartDateString%>" DataField="ConsultDate" SortExpression="ConsultDate" />                                        
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AppointmentDateString%>" DataField="BookingDate" SortExpression="BookingDate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ContentString%>" DataField="ContactMethod" SortExpression="ContactMethod" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,LastReceivedTimeString%>" DataField="LastReceivedDate" SortExpression="LastReceivedDate" />
                                        <asp:ButtonColumn CommandName="Delete"
                                            HeaderText="<%$ Resources:Resource,DeleteString%>"
                                            Text="<%$ Resources:Resource,DeleteString%>" />
                                    </Columns>
                                </asp:DataGrid>
                            </div>
                            <hr />
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
        <!-- datepicker -->
        <script src="../assets/js/picker.js"></script>
    </form>
</body>

</html>
