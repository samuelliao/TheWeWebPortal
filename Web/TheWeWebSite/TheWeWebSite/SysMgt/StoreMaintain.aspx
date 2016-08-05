<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoreMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.StoreMaintain" %>

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
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlCountry" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlArea" />
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,LangCodeString%>"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlLang" />
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,StoreNameInputString%>" ID="tbName"></asp:TextBox>
                                        </div>    
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,StoreLevelString%>" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlLv" />
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>" ForeColor="Red"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SnInputString%>" ID="tbSn" Width="200px" ReadOnly="true"></asp:TextBox>
                                        </div>                                    
                                    </div>                                   
                                </div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,AddressString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,AddressInputString%>" ID="tbAdress"></asp:TextBox>
                                        </div>
                                        <div class="2u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbRemark" Width="200px" TextMode="MultiLine" Height="300px"></asp:TextBox>
                                        </div>
                                    </div>                                   
                                </div>
                                <div class="Div btn">
                                        <ul class="actions">
                                            <li>
                                                <asp:Button runat="server" Text="<%$ Resources:Resource,SearchString%>" ID="btnSearch"
                                                    OnClick="btnSearch_Click" />
                                            </li>
                                            <li>
                                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate"
                                                    OnClick="btnCreate_Click" />
                                            </li>
                                            <li>
                                                <asp:Button runat="server" Text="<%$ Resources:Resource,ClearString%>"
                                                    ID="btnClear" OnClick="btnClear_Click" />
                                            </li>
                                        </ul>
                                    </div>                                
                            </div>
                             <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                            <hr />

                            <!-- Table -->
                            <div class="row">
                                <div class="12u">
                                    <div class="table-wrapper" style="overflow: auto;">
                                        <asp:DataGrid runat="server" ID="dgStore" AllowPaging="true" AllowSorting="true"
                                            AutoGenerateColumns="false" DataKeyField="Id" OnCancelCommand="dgStore_CancelCommand"
                                            OnDeleteCommand="dgStore_DeleteCommand" OnEditCommand="dgStore_EditCommand"
                                            OnPageIndexChanged="dgStore_PageIndexChanged" OnUpdateCommand="dgStore_UpdateCommand"
                                            OnItemDataBound="dgStore_ItemDataBound" Font-Size="Medium" OnSortCommand="dgStore_SortCommand">
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                            <PagerStyle Mode="NumericPages" />
                                            <Columns>
                                                <asp:BoundColumn DataField="Id" Visible="false" />
                                                <asp:BoundColumn DataField="Sn" HeaderText="<%$ Resources:Resource,SnString%>" SortExpression="Sn" />
                                                <asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:Resource,NameString%>" SortExpression="Name" />
                                                <asp:BoundColumn DataField="CnName" HeaderText="<%$ Resources:Resource,CnNameString%>" SortExpression="CnName" />
                                                <asp:BoundColumn DataField="EngName" HeaderText="<%$ Resources:Resource,EnglishNameString%>" SortExpression="EngName" />
                                                <asp:BoundColumn DataField="JpName" HeaderText="<%$ Resources:Resource,JpNameString%>" SortExpression="JpName" />
                                                <asp:BoundColumn DataField="Addr" HeaderText="<%$ Resources:Resource,AddressString%>" SortExpression="Addr" />
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StoreLevelString%>" SortExpression="GradeLv">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelDgHoldingCompany" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlDgHoldingCompany" />
                                                    </EditItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>" SortExpression="CountryName">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlDgCountry" OnSelectedIndexChanged="ddlDgCountry_SelectedIndexChanged" Width="200px" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelDgCountry" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>" SortExpression="AreaName">
                                                    <EditItemTemplate>
                                                        <asp:DropDownList runat="server" ID="ddlDgArea" Width="200px" />
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelDgArea" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="Description" HeaderText="<%$ Resources:Resource,RemarkString%>" SortExpression="Description" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,UpdateTimeString%>" DataField="UpdateTime" ReadOnly="true" SortExpression="UpdateTime" />
                                                <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeName" ReadOnly="true" SortExpression="EmployeeName" />
                                                <asp:EditCommandColumn EditText="<%$ Resources:Resource,ModifyString%>"
                                                    CancelText="<%$ Resources:Resource,CancelString%>"
                                                    UpdateText="<%$ Resources:Resource,UpdateString%>"
                                                    HeaderText="<%$ Resources:Resource,ModifyString%>" />
                                                <asp:ButtonColumn CommandName="Delete"
                                                    HeaderText="<%$ Resources:Resource,DeleteString%>"
                                                    Text="<%$ Resources:Resource,DeleteString%>" />
                                            </Columns>
                                        </asp:DataGrid>
                                    </div>
                                    <hr />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
