<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DollarMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.DollarMaintain" %>

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
                        <asp:Label runat="server" ID="labelPageTitle" Text=""></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">

                    <div>
                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CurrencyString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbCurrency" placeholder="<%$ Resources:Resource,CurrencyNameInputString%>" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CurrencyRateString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,CurrencyRateInputString%>" ID="tbRate" />
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbRate" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                </div>

                                <!-- Btn -->
                                <div class="Div btn">
                                    <ul class="actions">

                                        <li>
                                            <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                                                ID="btnCreate" OnClick="btnCreate_Click" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" Text="<%$ Resources:Resource,ClearString%>"
                                             ID="btnClear" OnClick="btnClear_Click" />
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>


                    <hr />
                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dgCurrency" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" DataKeyField="Id" OnCancelCommand="dgCurrency_CancelCommand"
                                    OnDeleteCommand="dgCurrency_DeleteCommand" OnEditCommand="dgCurrency_EditCommand"
                                    OnPageIndexChanged="dgCurrency_PageIndexChanged" OnUpdateCommand="dgCurrency_UpdateCommand">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Id" Visible="false" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CurrencyString%>" DataField="Name" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CurrencyRateString%>" DataField="Rate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,UpdateTimeString%>" DataField="UpdateTime" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmployeeString%>" DataField="EmployeeName" />
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

            <!-- CTA -->


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
