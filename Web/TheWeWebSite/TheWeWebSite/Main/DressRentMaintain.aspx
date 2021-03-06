﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressRentMaintain.aspx.cs" Inherits="TheWeWebSite.Main.DressRentMaintain" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                    <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)" runat="server" id="divStore" style="display: none;">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStore" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(開始)" ID="labelContractSearchStartDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbContractSearchStartDate"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(結束)" ID="labelContractSearchEndDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" Style="text-align: right" ID="tbContractSearchEndDate"
                                            CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStatus" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCategory" />
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
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                    ID="btnSearch" OnClick="btnSearch_Click" />
                            </li>
                        </ul>
                    </div>                    
                    <hr />
                    <!-- Table -->

                    <div class="row serch">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                    AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                    OnItemDataBound="dataGrid_ItemDataBound"
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
                                         <asp:TemplateColumn HeaderText="<%$ Resources:Resource,SnString%>">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkDressSn" Text="" OnClick="linkDressSn_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>   
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,StartString%>" DataField="StartTime" SortExpression="StartTime" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EndString%>" DataField="EndTime" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StatusString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStatus" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ContractSnString%>">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkConsult" Text="" OnClick="linkConsult_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>         
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelLocation" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
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