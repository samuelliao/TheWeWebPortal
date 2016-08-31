<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Unsigned.aspx.cs" Inherits="TheWeWebSite.Main.Unsigned" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
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
                    <div class="2u 12u(mobilep)" runat="server" id="divStore" style="display: none;">
                        <asp:DropDownList runat="server" ID="ddlStore" />
                    </div>
                    <!-- Table -->
                    <div class="row serch">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                    AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                    OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" OnItemDataBound="dataGrid_ItemDataBound"
                                    DataKeyField="Id" OnSortCommand="dataGrid_SortCommand" Font-Size="Small">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StoreString%>" SortExpression="StoreId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStore" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AdviosryIdString%>" SortExpression="Sn">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkConsult" Text="" OnClick="linkConsult_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeName" SortExpression="EmployeeName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,BridalNameString%>" DataField="BridalName" SortExpression="BridalName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,PhoneString%>" DataField="BridalPhone" SortExpression="BridalPhone" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,StartDateString%>" DataField="ConsultDate" SortExpression="ConsultDate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AppointmentDateString%>" DataField="BookingDate" SortExpression="BookingDate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ContentString%>" DataField="ContactMethod" SortExpression="ContactMethod" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,LastReceivedTimeString%>" DataField="LastReceivedDate" SortExpression="LastReceivedDate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,RemarkString%>" DataField="Remark" SortExpression="Remark" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,IsReplyString%>" SortExpression="IsReply">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelIsReply" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                    </Columns>
                                </asp:DataGrid>
                            </div>
                            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
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
    </form>
</body>
</html>
