<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ItemMaintain" %>

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
                    <div>
                        <div class="row uniform 50%">
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlStore" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbSn" placeholder="<%$ Resources:Resource,SnInputString%>"></asp:TextBox>
                            </div>                            
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlLocation" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlCategory" />
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingStyleString%>"></asp:Label>
                                </div>
                                <asp:DropDownList runat="server" ID="ddlWeddingType" />
                            </div>
                        </div>
                        <!-- Btn -->

                        <div class="Div btn">
                            <ul class="actions">
                                <li>
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkItemMCreate" PostBackUrl="~/StoreMgt/ItemMCreate.aspx" />
                                </li>
                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" ID="btnSearch" OnClick="btnSearch_Click" />
                                </li>

                            </ul>
                        </div>
                    </div>
                    <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />

                    <hr />
                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false" AllowPaging="true"
                                    AllowSorting="true" DataKeyField="Id" OnDeleteCommand="dataGrid_DeleteCommand"
                                    OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                    OnSortCommand="dataGrid_SortCommand" OnItemDataBound="dataGrid_ItemDataBound">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                        <asp:BoundColumn DataField="Id" Visible="false" />
                                        <asp:BoundColumn DataField="Sn" SortExpression="Sn" HeaderText="<%$ Resources:Resource,SnString%>" />
                                        <asp:TemplateColumn SortExpression="StoreId" HeaderText="<%$ Resources:Resource,StoreString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStore" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn SortExpression="Category" HeaderText="<%$ Resources:Resource,ProjectString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelCategroy" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,WeddingStyleString%>" SortExpression="WeddingCategory">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelWeddingStyle" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>" SortExpression="CountryId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelCountry" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>" SortExpression="AreaId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelArea" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>" SortExpression="ChurchId">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelLocation" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,PriceString%>" SortExpression="Price">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="dgLabelPrice" />
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
