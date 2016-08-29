<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="TheWeWebSite.Main.Case" %>

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
                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="2u 12u(mobilep)" runat="server" id="divStore" style="display: none;">
                                <asp:DropDownList runat="server" ID="ddlStore" />
                            </div>
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
                                    DataKeyField="Id" OnSortCommand="dataGrid_SortCommand" OnItemDataBound="dataGrid_ItemDataBound"
                                    OnPageIndexChanged="dataGrid_PageIndexChanged" Font-Size="Small">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StoreString%>" SortExpression="StoreId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStore" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AdviosryIdString%>" SortExpression="ConsultSn">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkConsult" Text="" OnClick="linkConsult_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ContractSnString%>" SortExpression="Sn">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkContract" Text="" OnClick="linkContract_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,BridalNameString%>" SortExpression="CustomerId">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkCustomerName" Text="" OnClick="linkCustomerName_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,GroomNameString%>" SortExpression="PartnerId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelPartnerName" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AppointmentDateString%>" DataField="BookingDate" SortExpression="BookingDate" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StatusString%>" SortExpression="StatusId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelConference" Text="" Visible="true" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>" SortExpression="ChurchId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelLocation" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ProductSetString%>" SortExpression="SetId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelSet" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,TotalPriceString%>" DataField="TotalPrice" SortExpression="TotalPrice" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeName" SortExpression="EmployeeId" />
                                    </Columns>
                                </asp:DataGrid>
                            </div>
                            <hr />
                            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
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
