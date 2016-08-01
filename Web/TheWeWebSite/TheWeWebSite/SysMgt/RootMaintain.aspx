<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RootMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.RootMaintain" %>

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
                        <asp:Label runat="server" ID="labelPageTitle"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">
                    <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                    AllowPaging="true" AllowSorting="true" DataKeyField="Id" Font-Size="Small"
                                    OnDeleteCommand="dataGrid_DeleteCommand" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged"
                                    OnPageIndexChanged="dataGrid_PageIndexChanged" OnSortCommand="dataGrid_SortCommand"
                                    OnItemDataBound="dataGrid_ItemDataBound">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                        <asp:BoundColumn DataField="Id" Visible="false" />
                                        <asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:Resource,PermissionCategoryString%>" SortExpression="Name" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StoreSnString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="dgLabelStoreDisplayName" Text="" />
                                                <asp:Label runat="server" ID="LabelStoreId" Text="" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:ButtonColumn CommandName="Delete"
                                            HeaderText="<%$ Resources:Resource,DeleteString%>"
                                            Text="<%$ Resources:Resource,DeleteString%>" />
                                    </Columns>
                                </asp:DataGrid>
                            </div>
                            <hr />
                            <div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,PermissionCategoryString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbPermissionCategory" />

                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,StoreSnString%>"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlStore" />
                                        </div>
                                        <asp:Table runat="server" ID="table1" CssClass="alt">
                                            <asp:TableHeaderRow runat="server">
                                                <asp:TableHeaderCell Text="Id" HorizontalAlign="Center" VerticalAlign="Middle" Visible="false" />
                                                <asp:TableHeaderCell Text="FunctionTypeSn" HorizontalAlign="Center" VerticalAlign="Middle" Visible="false" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,OperationString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,ViewString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,CreateString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,ModifyString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,DeleteString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <asp:TableHeaderCell Text="<%$ Resources:Resource,ExportString%>" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TableHeaderRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,StoreMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,OrderMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,PurchaseMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,SalesMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,FinMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                            <asp:TableRow>
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Visible="false" />
                                                <asp:TableCell Text="<%$ Resources:Resource,SysMgtString%>" />
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                                <asp:TableCell>
                                                    <asp:CheckBox runat="server" Checked="true" Text=" " />
                                                </asp:TableCell>
                                            </asp:TableRow>
                                        </asp:Table>
                                        <!-- Btn -->

                                        <div class="Div btn">
                                            <ul class="actions">
                                                <li>
                                                    <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                                                        ID="btnCreate" OnClick="btnCreate_Click" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,UpdateString%>"
                                                        ID="btnUpdate" OnClick="btnUpdate_Click" Visible="false" />
                                                </li>
                                                <li>
                                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                                                        ID="btnClear" OnClick="btnClear_Click" />
                                                </li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
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
