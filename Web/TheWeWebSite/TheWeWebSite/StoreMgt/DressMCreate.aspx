<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMCreate.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="TheWeWebSite.StoreMgt.DressMCreate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">
        <My:Header runat="server" ID="ucHeader" />
        <!-- Main -->
        <section class="box title CreatePage">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">

            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
            <cc1:TabContainer runat="server">
                <cc1:TabPanel runat="server">
                    <HeaderTemplate>
                        <asp:Label runat="server" Text="<%$ Resources:Resource,DressString%>" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStore" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbSn" CssClass="required"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                        ControlToValidate="tbSn" runat="server"
                                        ErrorMessage="required"
                                        CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                    <asp:DropDownList runat="server" ID="ddlDressCategory" CssClass="required" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlDressCategory" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbColor" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbColor2" />
                                </div>

                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlDressType" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbMaterial"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbMaterial2"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NecklineString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlNeckline" />
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
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,WornString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlWorn" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,VeilString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlVeil" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,TrailingString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlTrailing" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CorsageString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCorsage" />

                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,GlovesString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlGloves" />
                                </div>



                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStatus" CssClass="required" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlStatus" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,UsageStatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlUseStatus" />
                                </div>
                                <div class="4u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,FittingString%>"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" ID="tbFitting"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="4u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,OtherString%>"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" ID="tbOthers"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbCost" Style="text-align: right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbCost"
                                        runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CustomPriceString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbCustomPrice" Style="text-align: right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbCustomPrice" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SupplierString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlSupplier" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,RentPriceString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbRentPrice" Style="text-align: right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tbRentPrice" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SellingPriceString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbSellsPrice" Style="text-align: right"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbSellsPrice" runat="server"
                                        ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>

                        <div class="12u">
                            <div class="row uniform 50%">
                                <div>
                                    <asp:CheckBox runat="server" CssClass="Div" Text="<%$ Resources:Resource,DomesticWeddingOnlyString%>" ID="cbDomesticWedding" />
                                </div>
                                <div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox runat="server" Text="<%$ Resources:Resource,OutdoorShootingString%>"
                                                ID="cbOutPhoto" OnCheckedChanged="cbOutPhoto_CheckedChanged" AutoPostBack="true"
                                                CssClass="Div" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div>
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,OutdoorShootingPriceString%>"></asp:Label>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" ID="tbOutdoorPlusPrice" Style="text-align: right" Enabled="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="tbOutdoorPlusPrice" runat="server"
                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:CheckBox CssClass="Div" runat="server" Text="<%$ Resources:Resource,AdditionalPurchaseString%>" ID="cbPlusItem" OnCheckedChanged="cbPlusItem_CheckedChanged" AutoPostBack="true" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div>
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,AdditionalPurchasePriceString%>"></asp:Label>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox runat="server" ID="tbPlusItemPrice" Style="text-align: right" Enabled="false"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="tbPlusItemPrice" runat="server"
                                                ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*" CssClass="error" Display="Dynamic"></asp:RegularExpressionValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                <div>
                                    <asp:CheckBox runat="server" CssClass="Div" Text="<%$ Resources:Resource,BigSizeString%>" ID="cbBigSize" />
                                </div>
                            </div>
                        </div>
                        <hr />
                        <!-- 照片 -->
                        <section>

                            <div class="row no-collapse 50% uniform">
                                <div class="2u">
                                    <div runat="server" id="divPhotoUpload">
                                        <div class="ImageUploadBtn">
                                            <button id="btnUploadPanel" onclick="uploadPanelControl();" class="Div btn actions button alt">
                                                <asp:Literal runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                                            </button>
                                        </div>
                                        <div id="uploadPanel" style="display: none;">
                                            <div class="fileUpload">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                                                <asp:FileUpload ID="FileUpload1" runat="server" />
                                            </div>
                                            <div class="fileUpload">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                                                <asp:FileUpload ID="FileUpload2" runat="server" />
                                            </div>
                                            <div class="fileUpload">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                                                <asp:FileUpload ID="FileUpload3" runat="server" />
                                            </div>
                                            <div class="fileUpload">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                                <asp:FileUpload ID="FileUpload4" runat="server" />
                                            </div>
                                            <div class="fileUpload">
                                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                                <asp:FileUpload ID="FileUpload5" runat="server" />
                                            </div>
                                            <div style="text-align: left; margin-top: 15px;">
                                                <asp:Button CausesValidation="true" runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload"
                                                    OnClick="btnUpload_Click" OnClientClick="uploadPanelControl();" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="2u">
                                    <div style="text-align: center">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                                        <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                                    </div>
                                    <span class="image fit">
                                        <asp:Image runat="server" ID="ImgFront" />
                                    </span>
                                </div>
                                <div class="2u">
                                    <div style="text-align: center">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                                    </div>
                                    <span class="image fit">
                                        <asp:Image runat="server" ID="ImgBack" />
                                    </span>
                                </div>
                                <div class="2u">
                                    <div style="text-align: center">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                                    </div>
                                    <span class="image fit">
                                        <asp:Image runat="server" ID="ImgSide" />
                                    </span>
                                </div>
                                <div class="2u">
                                    <div style="text-align: center">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                    </div>
                                    <span class="image fit">
                                        <asp:Image runat="server" ID="ImgOther1" />
                                    </span>
                                </div>
                                <div class="2u">
                                    <div style="text-align: center">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                    </div>
                                    <span class="image fit">
                                        <asp:Image runat="server" ID="ImgOther2" />
                                    </span>
                                </div>

                            </div>
                        </section>
                        <hr />
                        <!-- Btn -->
                        <div class="Div btn">
                            <ul class="actions">

                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
                                </li>
                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" />
                                </li>
                                <li>
                                    <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
                                </li>
                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                                </li>
                                <li>
                                    <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
                                </li>
                            </ul>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
                <cc1:TabPanel runat="server" ID="tabRentRecord">
                    <HeaderTemplate>
                        <asp:Label runat="server" Text="<%$ Resources:Resource,DressRentString%>" />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbDressId2" ReadOnly="true" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStatus2" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(開始)" ID="labelSearchStartDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" Style="text-align: right" CssClass="date date-1" value=""
                                            placeholder="YYYY-MM-DD" ID="tbSearchStartDate"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="開案日期選擇範圍(結束)" ID="labelSearchEndDate"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:TextBox runat="server" Style="text-align: right" CssClass="date date-1" value="" placeholder="YYYY-MM-DD"
                                            ID="tbSearchEndDate"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="Div btn">
                            <ul class="actions">
                                <li>
                                    <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,SearchString%>"
                                        ID="btnSearch" OnClick="btnSearch_Click" />
                                </li>
                            </ul>
                        </div>
                        <div class="row serch">
                            <div class="12u">
                                <div class="table-wrapper">
                                    <asp:DataGrid runat="server" ID="dataGrid" AutoGenerateColumns="false"
                                        AllowPaging="true" AllowSorting="true" OnPageIndexChanged="dataGrid_PageIndexChanged"
                                        OnItemDataBound="dataGrid_ItemDataBound" DataKeyField="Id"
                                        OnSortCommand="dataGrid_SortCommand" Font-Size="Small">
                                        <HeaderStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                        <PagerStyle Mode="NumericPages" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <Columns>
                                            <asp:ButtonColumn Text="<%$ Resources:Resource,SearchString%>" CommandName="Select" />
                                            <asp:BoundColumn Visible="false" DataField="Id" />
                                            <asp:BoundColumn HeaderText="<%$ Resources:Resource,StartString%>" DataField="StartTime" />
                                            <asp:BoundColumn HeaderText="<%$ Resources:Resource,EndString%>" DataField="EndTime" />
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,StatusString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="labelStatus" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,ContractSnString%>">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" ID="linkConsult" Text="" OnClick="linkConsult_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="<%$ Resources:Resource,LocateString%>">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" ID="labelLocation" />
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                    </asp:DataGrid>
                                </div>
                                <hr />
                            </div>
                        </div>
                    </ContentTemplate>
                </cc1:TabPanel>
            </cc1:TabContainer>

        </section>

        <!-- Scripts -->
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/jquery.dropotron.min.js"></script>
        <script src="../assets/js/jquery.scrollgress.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <!--[if lte IE 8]><script src="assets/js/ie/respond.min.js"></script><![endif]-->
        <script src="../assets/js/main.js"></script>
        <script type="text/javascript">
            function uploadPanelControl() {
                var div = document.getElementById('uploadPanel');
                if (div.style.display == 'none') {
                    displayUploadControl('false', 'true');
                } else {
                    displayUploadControl('true', 'true');
                }
            }
            function displayUploadControl(type, reset) {
                if (type == "true") {
                    document.getElementById('uploadPanel').style.display = 'inline';
                    document.getElementById('btnUploadPanel').style.display = 'none';
                    if (reset == 'true') {
                        localStorage.setItem('show', 'false'); //store state in localStorage
                    }
                } else {
                    document.getElementById('uploadPanel').style.display = 'none';
                    document.getElementById('btnUploadPanel').style.display = 'inline';
                    if (reset == 'true') {
                        localStorage.setItem('show', 'true'); //store state in localStorage
                    }
                }
            }
            window.onload = function () {
                var show = localStorage.getItem('show');
                displayUploadControl(show, 'false');
            }
        </script>
    </form>
</body>
</html>
