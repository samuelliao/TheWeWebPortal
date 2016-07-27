<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaseMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.CaseMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
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
                    <asp:ScriptManager runat="server" />
                    <div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AdviosryIdString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbConsultSn"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ContractSnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbCaseSn"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(開始)" ID="labelContractSearchStartDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" style="text-align:right" CssClass="dp" ID="tbContractSearchStartDate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server"  Text="開案日期選擇範圍(結束)" ID="labelContractSearchEndDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" CssClass="dp" style="text-align:right" ID="tbContractSearchEndDate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="結案日期選擇範圍(開始)" ID="labelClosedSearchStartDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" style="text-align:right" CssClass="dp" ID="tbCloseSearchStartDate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="結案日期選擇範圍(結束)" ID="labelClosedSearchEndDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" CssClass="dp" style="text-align:right" ID="tbCloseSearchEndDate"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="12u">

                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,BridalNameString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server"  ID="tbBridalName"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,GroomNameString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server"  ID="tbGroomName"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ProjectString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCategory" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStatus" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LocateString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlLocation" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlProductSet" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                                    ID="btnCreate" PostBackUrl="~/CaseMgt/CaseMCreate.aspx" />
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
                                <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                    AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                    OnItemDataBound="dataGrid_ItemDataBound" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged"
                                    OnDeleteCommand="dataGrid_DeleteCommand"
                                    DataKeyField="Id" OnSortCommand="dataGrid_SortCommand" Font-Size="Small">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AdviosryIdString%>">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkConsult" Text="" OnClick="linkConsult_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ContractSnString%>" DataField="Sn" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,BridalNameString%>">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkCustomerName" Text="" OnClick="linkCustomerName_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,BridalNameString%>" DataField="CustomerName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,GroomNameString%>" DataField="PartnerName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ContractDateString%>" DataField="StartTime" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StatusString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelStatus" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AppointmentDateString%>" DataField="BookingDate" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelCountry" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelArea" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelLocation" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ProductSetString%>">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="labelSet" />
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
        <script src="../assets/js/datepicker.js"></script>
        <script src="../assets/js/jquery-1.10.2.js"></script>
        <script src="../assets/js/jquery-ui.js"></script>


    </form>

</body>
</html>
