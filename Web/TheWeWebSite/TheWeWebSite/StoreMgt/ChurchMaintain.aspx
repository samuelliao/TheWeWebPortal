<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ChurchMaintain" %>

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
                        <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;教堂維護(待修改)" ID="labelPageTitle"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">

                    <div>
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="3u 12u(mobilep)">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="3u 12u(mobilep)">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlArea" AutoPostBack="true" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbName" TextMode="SingleLine" placeholder="<%$ Resources:Resource,ChurchNameInputString%>" />
                                </div>
                            </div>
                        </div>

                        <!-- Btn -->

                        <div class="Div btn">
                            <ul class="actions">
                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>"
                                        ID="btnCreate" PostBackUrl="~/StoreMgt/ChurchMCreate.aspx" />
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
                                    <asp:DataGrid runat="server" ID="dgChurch" CssClass="alt" AllowPaging="true"
                                        AllowSorting="true" AutoGenerateColumns="false" OnSelectedIndexChanged="dgChurch_SelectedIndexChanged"
                                        OnDeleteCommand="dgChurch_DeleteCommand" OnPageIndexChanged="dgChurch_PageIndexChanged"
                                        DataKeyField="Id" Font-Size="Small" OnItemDataBound="dgChurch_ItemDataBound">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <FooterStyle BackColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                        <PagerStyle Mode="NumericPages" />
                                        <Columns>
                                            <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                            <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false" />
                                            <asp:BoundColumn HeaderText="CountryId" DataField="CountryId" Visible="false" />
                                            <asp:BoundColumn HeaderText="AreaId" DataField="AreaId" Visible="false" />
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="dgLabelCountry" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="dgLabelArea" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="dgLabelChurch" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn HeaderText="<%$ Resources:Resource,CapacitiesString%>" DataField="Capacities" />
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,PriceString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="dgLabelPrice" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:BoundColumn HeaderText="<%$ Resources:Resource,RemarkString%>" DataField="Remark"></asp:BoundColumn>
                                            <asp:ButtonColumn CommandName="Delete"
                                                HeaderText="<%$ Resources:Resource,DeleteString%>"
                                                Text="<%$ Resources:Resource,DeleteString%>" />
                                        </Columns>
                                    </asp:DataGrid>
                                </div>
                                <hr />
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
