<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FittingMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.FittingMaintain" %>

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

            <!-- Main --

            <section id="main">
                <!-- Text -->
            <section class="box title">
                <h3>
                    <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
            </section>

            <!-- Input -->

            <section class="box special">
                <asp:ScriptManager runat="server"></asp:ScriptManager>
                <div>
                    <div class="12u">
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbSn"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlCategory" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlType" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlStatus" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <!-- Btn -->

                            <div class="Div btn">
                                <ul class="actions">
                                    <li>
                                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                                            ID="LinkFittingMCreate" PostBackUrl="~/StoreMgt/FittingMCreate.aspx" />
                                    </li>
                                    <li>
                                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                            ID="btnSearch" OnClick="btnSearch_Click" />
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <hr />
                <!-- Table -->
                <div class="row">
                    <div class="12u">
                        <div class="table-wrapper">
                            <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true" DataKeyField="Id"
                                AutoGenerateColumns="false" OnItemDataBound="dataGrid_ItemDataBound"
                                OnDeleteCommand="dataGrid_DeleteCommand" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" OnSortCommand="dataGrid_SortCommand">
                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                <PagerStyle VerticalAlign="Middle" Mode="NumericPages" />
                                <Columns>
                                    <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                    <asp:BoundColumn Visible="false" DataField="Id" />
                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,SnString%>" DataField="Sn" SortExpression="Sn" />
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CategoryString%>">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="dgLabelCategory" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,TypeString%>" SortExpression="Category">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="dgLabelType" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StatusString%>" SortExpression="StatusCode">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="dgLabelStatus" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,SellingPriceString%>" SortExpression="SellsPrice">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="dgLabelSalesPrice" Style="text-align: right" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,RentPriceString%>" SortExpression="RentPrice">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="dgLabelRentPrice" Style="text-align: right" />
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
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
    </form>
</body>
</html>
