<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CustomerMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../assets/css/datePicker.css" rel="stylesheet" />
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
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SnInputString%>" ID="tbSn"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,NameInputString%>" ID="tbName"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,BdayString%>"></asp:Label>
                                    </div>
                                    <div >
                                        <asp:TextBox runat="server" Cssclass="date date-1" value="" placeholder="YYYY-MM-DD" ID="tbBday"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,PhoneString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,PhoneInputString%>" ID="tbPhone"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MsgString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlMsgerType"/>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MsgIdString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server"  ID="tbMsgId"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                
                                <div class="4u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,EmailString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,EmailInputString%>" ID="tbEmail"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                    </div>


                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                                     ID="LinkCustomerMCreate" PostBackUrl="~/CaseMgt/CustomerMCreate.aspx" />
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
                                <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true" DataKeyField="Id"
                                 AutoGenerateColumns="false" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged" Font-Size="Small"
                                 OnDeleteCommand="dataGrid_DeleteCommand" OnSortCommand="dataGrid_SortCommand" 
                                 OnPageIndexChanged="dataGrid_PageIndexChanged" OnItemDataBound="dataGrid_ItemDataBound">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <Columns>                                        
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,ModifyString%>" CommandName="Select"/>
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,NameString%>" DataField="Name" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,NickNameString%>" DataField="Nickname" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,PassportNameString%>" DataField="EngName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,BdayString%>" DataField="Bday" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,PhoneString%>" DataField="Phone" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,EmailString%>" DataField="Email" />                                        
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,MsgString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="dgLabelMsg" />
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
        <!-- datepicker -->
        <script src="../assets/js/picker.js"></script>

    </form>
</body>

</html>
