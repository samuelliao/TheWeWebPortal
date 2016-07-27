<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.LoginMaintain" %>

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
<body class="landing" runat="server" onunload="Unnamed_Unload">
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
                        <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStore" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AccountString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbAccount"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,PasswordString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbPwd" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,PasswordConfirmString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbPwdConfirm" TextMode="Password"></asp:TextBox>
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" ID="cbIsValid" Text="<%$ Resources:Resource,IsValidString%>" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" Visible="false"/>
                            </li>
                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click"/>
                            </li>
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" ID="btnSearch" OnClick="btnSearch_Click" />
                            </li>
                        </ul>
                    </div>
                    <hr />
                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true"
                                 AutoGenerateColumns="false" DataKeyField="Id"
                                 OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                 OnItemDataBound="dataGrid_ItemDataBound" OnSortCommand="dataGrid_SortCommand">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:TemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStore" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="" DataField="Account" />
                                        <asp:BoundColumn HeaderText="" DataField="Sn" />
                                        <asp:BoundColumn HeaderText="" DataField="Name" />
                                        <asp:TemplateColumn HeaderText="">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelIsValid" />
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
