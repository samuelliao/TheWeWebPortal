<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentMethod.aspx.cs" Inherits="TheWeWebSite.SysMgt.PaymentMethod" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

            <section id="main" class="serch">

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
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LangCodeString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlLang" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>" ForeColor="Red"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" CssClass="required" ID="tbName"></asp:TextBox>
                                </div>
                                <div class="6u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbRemark" TextMode="MultiLine" Rows="2"></asp:TextBox>
                                </div>
                            </div>
                        </div>
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

                    <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                    <hr />
                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dgMethod" AllowPaging="true" AllowSorting="true"
                                    AutoGenerateColumns="false" DataKeyField="Id" OnCancelCommand="dgMethod_CancelCommand"
                                    OnDeleteCommand="dgMethod_DeleteCommand" OnEditCommand="dgMethod_EditCommand"
                                    OnPageIndexChanged="dgMethod_PageIndexChanged" OnUpdateCommand="dgMethod_UpdateCommand"
                                    OnSortCommand="dgMethod_SortCommand">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Id" Visible="false" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,NameString%>" DataField="Name" SortExpression="Name" />
                                        <asp:BoundColumn DataField="CnName" HeaderText="<%$ Resources:Resource,CnNameString%>" SortExpression="CnName" />
                                        <asp:BoundColumn DataField="EngName" HeaderText="<%$ Resources:Resource,EnglishNameString%>" SortExpression="EngName" />
                                        <asp:BoundColumn DataField="JpName" HeaderText="<%$ Resources:Resource,JpNameString%>" SortExpression="JpName" />
                                        <asp:BoundColumn DataField="Remark" HeaderText="<%$ Resources:Resource,RemarkString%>" SortExpression="Remark" />
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
