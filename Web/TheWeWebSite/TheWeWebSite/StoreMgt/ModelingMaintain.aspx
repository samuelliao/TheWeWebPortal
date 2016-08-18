<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModelingMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ModelingMaintain" %>

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
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ModelingSnString%>"></asp:Label>
                                </div>
                                <asp:TextBox runat="server" ID="tbSn" placeholder="<%$ Resources:Resource,SnInputString%>"></asp:TextBox>
                            </div>
                            <div class="2u 12u(mobilep)">
                                <div class="Div">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>" ></asp:Label>
                                </div>
                                            <asp:DropDownList runat="server" ID="ddlCategory" />
                            </div>
                            <!-- Btn -->

                            <div class="Div btn">
                                <ul class="actions">

                                    <li>
                                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkModelingMCreate" PostBackUrl="~/StoreMgt/ModelingMCreate.aspx" />
                                    </li>
                                    <li>
                                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" OnClick="btnSearch_Click" id="btnSearch"/>
                                    </li>

                                </ul>
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
                                 AutoGenerateColumns="false" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" Font-Size="Small"
                                 OnDeleteCommand="dataGrid_DeleteCommand" OnSortCommand="dataGrid_SortCommand" 
                                 OnPageIndexChanged="dataGrid_PageIndexChanged" OnItemDataBound="dataGrid_ItemDataBound">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <Columns>                                        
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select"/>
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ModelingSnString%>" DataField="Sn" SortExpression="Sn"/>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CategoryString%>" SortExpression="Type">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="dgLabelType" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,DescriptionString%>" DataField="Description" SortExpression="Description"/>
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
