<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ChurchMaintain" %>

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
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <section class="box title">
                            <h3>
                                <asp:Label runat="server" Text="開店管理&nbsp;&nbsp;>&nbsp;&nbsp;教堂維護(待修改)"></asp:Label></h3>
                        </section>
                        <!-- Input -->
                        <section class="box special">

                            <div>
                                <div class="12u">

                                    <div class="row uniform 50%">
                                        <div class="3u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="國家"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlCountry" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>

                                        <div class="3u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="地區"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlArea" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                        <div class="6u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="教堂"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlChruch" OnSelectedIndexChanged="ddlChruch_SelectedIndexChanged" AutoPostBack="true" />
                                        </div>
                                    </div>
                                </div>
                                <div class="12u">
                                    <div class="row uniform 50%">
                                        <div class="3u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="教堂"></asp:Label>
                                            </div>
                                            <asp:DropDownList runat="server" ID="ddlLang" />
                                        </div>
                                        <div class="3u 12u(mobilep)">
                                            <div class="Div">
                                                <asp:Label runat="server" Text="教堂名稱"></asp:Label>
                                            </div>
                                            <asp:TextBox runat="server" ID="tbChurchName" TextMode="SingleLine" placeholder="<%$ Resources:Resource,ChurchNameInputString%>" />
                                        </div>
                                    </div>
                                </div>



                                <!-- Btn -->

                                <div class="Div btn">
                                    <ul class="actions">
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>"
                                                ID="btnCreate" OnClick="btnCreate_Click" />
                                        </li>
                                        <li>
                                            <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                                ID="btnSearch" OnClick="btnSearch_Click" />
                                        </li>


                                    </ul>
                                </div>
                                <hr />
                                <!-- Table -->
                                <div class="row">
                                    <div class="12u">
                                        <div class="table-wrapper">
                                            <asp:DataGrid runat="server" ID="dgChurch" CssClass="alt" AllowPaging="true"
                                                AllowSorting="true" OnEditCommand="dgChurch_EditCommand" OnCancelCommand="dgChurch_CancelCommand"
                                                OnDeleteCommand="dgChurch_DeleteCommand" OnPageIndexChanged="dgChurch_PageIndexChanged"
                                                OnUpdateCommand="dgChurch_UpdateCommand" AutoGenerateColumns="false" OnItemDataBound="dgChurch_ItemDataBound"
                                                DataKeyField="Id" Font-Size="Medium">
                                                <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <FooterStyle BackColor="White" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                <ItemStyle VerticalAlign="Middle" HorizontalAlign="Left" />
                                                <Columns>
                                                    <asp:BoundColumn HeaderText="Id" DataField="Id" Visible="false" />
                                                    <asp:BoundColumn HeaderText="CountryId" DataField="CountryId" Visible="false" />
                                                    <asp:BoundColumn HeaderText="AreaId" DataField="AreaId" Visible="false" />
                                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,CountryString%>">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList runat="server" ID="dgDdlCountry" OnSelectedIndexChanged="dgDdlCountry_SelectedIndexChanged" AutoPostBack="true" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="dgLabelCountry" Text="" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,AreaString%>">
                                                        <EditItemTemplate>
                                                            <asp:DropDownList runat="server" ID="dgDdlArea" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label runat="server" ID="dgLabelArea" Text="" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,NameString%>" DataField="Name" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,CnNameString%>" DataField="CnName" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,EngNameString%>" DataField="EngName" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,JpNameString%>" DataField="JpName" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,CapacitiesString%>" DataField="Capacities" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,PriceString%>" DataField="Price" />
                                                    <asp:BoundColumn HeaderText="<%$ Resources:Resource,RemarkString%>" DataField="Remark"></asp:BoundColumn>
                                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,MealString%>" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Image runat="server" ID="ImgMealUpload" />
                                                            <asp:FileUpload ID="fileImgMeal" runat="server" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="ImgMeal" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="<%$ Resources:Resource,PhotoString%>" Visible="false">
                                                        <EditItemTemplate>
                                                            <asp:Image runat="server" ID="imgChurchUpload" />
                                                            <asp:FileUpload runat="server" ID="fileImgChurch" />
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Image runat="server" ID="imgChurch1" />
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
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

                    </ContentTemplate>
                </asp:UpdatePanel>

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
