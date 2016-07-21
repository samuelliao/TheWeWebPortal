<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMaintain.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMaintain" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/calendar.css" rel="stylesheet" />
        <link href="../assets/css/jquery-ui.css" rel="stylesheet"/>
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
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,SnInputString%>" ID="tbCaseSn"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(開始)" ID="labelContractStartDate"></asp:Label>
                                    </div>
                                   <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbContractStartDate"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(結束)" ID="labelContractEndDate"></asp:Label>
                                    </div>
                                   <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbContractEndDate"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,BridalString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,NameInputString%>" ID="tbBridalName"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,GroomString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" placeholder="<%$ Resources:Resource,NameInputString%>" ID="tbGroomName"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCountry"/>

                                </div>
                                
                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlArea"/>

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,LocationString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlLocation"/>

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlProductSet"/>

                                </div>

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="會議日期選擇範圍(開始)" ID="labelConStartDate"></asp:Label>
                                    </div>
                                    <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbConStartDate"></asp:TextBox> </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="會議日期選擇範圍(結束)" ID="labelConEndDate"></asp:Label>
                                    </div>
                                    <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbConEndDate"></asp:TextBox> </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- Btn -->

                    <div class="Div btn">
                        <ul class="actions">

                            <li>
                                <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="LinkTimeMCreate" PostBackUrl="~/CaseMgt/TimeMCreate.aspx" />
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
                                <asp:DataGrid runat="server" ID="dataGrid" AllowPaging="true" AllowSorting="true" AutoGenerateColumns="false"
                                 DataKeyField="Id" OnDeleteCommand="dataGrid_DeleteCommand" OnSelectedIndexChanged="dataGrid_SelectedIndexChanged"
                                 OnSortCommand="dataGrid_SortCommand" OnItemDataBound="dataGrid_ItemDataBound" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                 Font-Size="Small">
                                    <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <PagerStyle Mode="NumericPages" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    <Columns>
                                        <asp:ButtonColumn Text="<%$ Resources:Resource,ModifyString%>" CommandName="Select"/>
                                        <asp:BoundColumn Visible="false" DataField="Id" />
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AdvisoryIdString%>">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="linkConsult" Text="" />
                                                <asp:Label runat="server" ID="labelConsultId" Text="" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ContractSnString%>">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="linkContract" Text="" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:TemplateColumn HeaderText="<%$ Resources:Resource,BridalNameString%>">
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="linkCustomerName" Text="" />
                                                <asp:Label runat="server" ID="labelCustomerId" Text="" Visible="false" />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CustomerString%>" DataField="" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,CopntractDateString%>" DataField="StartTime" />                                        
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,StatusString%>" DataField="StatusName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AppointmentDateString%>" DataField="BookingDate" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ContryString%>" DataField="CountryName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,AreaString%>" DataField="AreaName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,LocationString%>" DataField="LocationName" />
                                        <asp:BoundColumn HeaderText="<%$ Resources:Resource,ProductSetString%>" DataField="ProductSetName" />
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
