<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MsgMaintain.aspx.cs" Inherits="TheWeWebSite.SysMgt.MsgMaintain" %>

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
                        <asp:Label runat="server" Text="系統管理&nbsp;&nbsp;>&nbsp;&nbsp;常用簡訊(待修改)" ID="labelPageTitle"></asp:Label></h3>
                </section>
                <!-- Input -->
                <section class="box special">

                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="12u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,NameInputString%>" ID="tbName"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="12u 12u(mobilep)">
                                     <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ContentString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbContent" placeholder="<%$ Resources:Resource,ContentInputString%>"
                                        TextMode="MultiLine" Rows="6"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" 
                                    ID="btnCreate" OnClick="btnCreate_Click"/>
                            </li>
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                    ID="btnClear" OnClick="btnClear_Click" />
                            </li>

                        </ul>
                    </div>
                    <asp:Label Text="" Visible="false" runat="server" ID="labelWarnStr" ForeColor="Red" />
                    <hr />

                    <!-- Table -->
                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true"
                                AllowSorting="true" DataKeyField="Id" AutoGenerateColumns="false"
                                 OnCancelCommand="dataGrid_CancelCommand" OnDeleteCommand="dataGrid_DeleteCommand"
                                 OnEditCommand="dataGrid_EditCommand" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                 OnSortCommand="dataGrid_SortCommand" Font-Size="Small" OnUpdateCommand="dataGrid_UpdateCommand" >
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                    <PagerStyle Mode="NumericPages" />
                                    <Columns>
                                        <asp:BoundColumn DataField="Id" Visible="false" />
                                        <asp:BoundColumn DataField="Name" HeaderText="<%$ Resources:Resource,NameString%>" SortExpression="Name" />
                                        <asp:BoundColumn DataField="SnsContent" HeaderText="<%$ Resources:Resource,ContentString%>" SortExpression="SnsContent" />
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
