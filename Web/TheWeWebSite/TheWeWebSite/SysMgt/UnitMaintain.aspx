<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.UnitMaintain" %>
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
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LangCodeString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlLang" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,UnitString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,UnitInputString%>" ID="tbUnit"></asp:TextBox>
                                </div>
                                <!-- Btn -->
                                <div class="Div btn">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" 
                                               ID="btnCreate" OnClick="btnCreate_Click"/>
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
                    <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                    <hr />

                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dgUnit" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
                                 DataKeyField="Id" Font-Size="Medium" OnCancelCommand="dgUnit_CancelCommand"
                                 OnEditCommand="dgUnit_EditCommand" OnDeleteCommand="dgUnit_DeleteCommand"
                                 OnUpdateCommand="dgUnit_UpdateCommand" OnPageIndexChanged="dgUnit_PageIndexChanged">
                                    <PagerStyle Mode="NumericPages" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Id" Visible="false"/>
                                        <asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:Resource,NameString%>" />
                                        <asp:BoundColumn DataField="CnName" HeaderText="<%$ Resources:Resource,CnNameString%>" />
                                        <asp:BoundColumn DataField="EngName" HeaderText="<%$ Resources:Resource,EnglishNameString%>" />
                                        <asp:BoundColumn DataField="JpName" HeaderText="<%$ Resources:Resource,JpNameString%>" />                                        
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,UpdateTimeString%>" DataField="UpdateTime" ReadOnly="true" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeName" ReadOnly="true" />
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
