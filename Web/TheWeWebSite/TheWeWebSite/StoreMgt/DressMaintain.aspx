<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
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
                    <asp:ScriptManager runat="server"></asp:ScriptManager>
                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbSn"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,GenderString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlGender" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlDressCategory" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlColor" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlMaterial" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlDressType" />
                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,WornString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlWorn" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NecklineString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlNeckLine" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,DressBackString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlBack" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ShoulderString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlShoulder" />
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
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,UsageStatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlUseStatus" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="<%$ Resources:Resource,OutdoorShootingString%>" ID="cbOutPhoto" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="加價款" ID="cbAddPrice" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="限國內婚宴" ID="cbDomesticWedding" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="<%$ Resources:Resource,BigSizeString%>" ID="cbBigSize" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkDressMCreate" PostBackUrl="~/StoreMgt/DressMCreate.aspx" />
                            </li>
                            <li>
                                <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>" ID="btnSearch" OnClick="btnSearch_Click" />
                            </li>

                        </ul>
                    </div>
                    <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                    <hr />

                    <!-- Table -->

                    <div class="row">
                        <div class="12u">
                            <div class="table-wrapper">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true"
                                            AutoGenerateColumns="false" DataKeyField="Id"
                                            OnDeleteCommand="dataGrid_DeleteCommand" OnItemDataBound="dataGrid_ItemDataBound"
                                            OnPageIndexChanged="dataGrid_PageIndexChanged" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged"
                                            OnSortCommand="dataGrid_SortCommand">
                                            <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                            <PagerStyle Mode="NumericPages" />
                                            <Columns>
                                                <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                                <asp:BoundColumn DataField="Id" Visible="false" />
                                                <asp:BoundColumn DataField="Sn" HeaderText="<%$ Resources:Resource,SnString%>" SortExpression="Sn" />
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CategoryString%>" SortExpression="Category">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelCategory" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="Color" HeaderText="<%$ Resources:Resource,ColorString%>" SortExpression="Color" />
                                                <asp:BoundColumn DataField="Material" HeaderText="<%$ Resources:Resource,MaterialString%>" SortExpression="Material" />
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,TypeString%>" SortExpression="Type">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelType" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,NecklineString%>" SortExpression="Neckline">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelNeckline" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,DressbackString%>" SortExpression="Back">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelDressBack" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ShoulderString%>" SortExpression="Shoulder">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelShoulder" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:TemplateColumn HeaderText="<%$ Resources:Resource,WornString%>" SortExpression="Worn">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" ID="labelWorn" />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:ButtonColumn CommandName="Delete"
                                                    HeaderText="<%$ Resources:Resource,DeleteString%>"
                                                    Text="<%$ Resources:Resource,DeleteString%>" />
                                            </Columns>
                                        </asp:DataGrid>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <hr />
                        </div>
                    </div>
                </section>
            </section>

            <!-- Footer -->
            <footer id="footer">
                <ul class="copyright">
                    <li>&copy; Untitled. All rights reserved.</li>
                    <li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
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
