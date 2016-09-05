<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FittingMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.FittingMCreate" %>

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
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                <cc1:TabContainer runat="server">
                    <cc1:TabPanel runat="server" HeaderText="<%$ Resources:Resource,BasicInfoString%>">
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

                                        <asp:TextBox CssClass="required" runat="server" ID="tbSn"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                            ControlToValidate="tbSn" runat="server"
                                            ErrorMessage="required"
                                            CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CategoryString%>"></asp:Label>
                                        </div>
                                        <asp:DropDownList CssClass="required" runat="server" ID="ddlCategory" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCategory" runat="server"
                                            ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                        <asp:TextBox runat="server" ID="tbCategory" Style="display: none;" />
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList CssClass="required" runat="server" ID="ddlType" AutoPostBack="true" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlType" runat="server"
                                                    ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <div style="display: none;" runat="server" id="divNewType">
                                                    <div style="margin-left: 0.5em; margin-top: 7px">
                                                        <asp:Label runat="server" Text="<%$ Resources:Resource,CreateItemString%>"></asp:Label>
                                                    </div>
                                                    <asp:TextBox CssClass="required" runat="server" ID="tbType" Style="display: none;" />
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divEarringType" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,TypeString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlEarringType" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divGender" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,GenderString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList runat="server" ID="ddlGender" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList CssClass="required" runat="server" ID="ddlStatus" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddlStatus" runat="server"
                                            ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divRelatedCategory" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CorrespondString%>"></asp:Label>
                                        </div>
                                        <asp:DropDownList runat="server" ID="ddlRelatedCategory" />
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divRelatedSn" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CorrespondSnString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbRelatedSn"></asp:TextBox>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbColor1"></asp:TextBox>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divColor2" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbColor2"></asp:TextBox>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divMaterial1">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbMaterial1"></asp:TextBox>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divMaterial2" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbMaterial2"></asp:TextBox>
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divLength" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,LengthString%>"></asp:Label>
                                        </div>
                                        <asp:DropDownList runat="server" ID="ddlLength" />
                                    </div>
                                    <div class="2u 12u(mobilep)" runat="server" id="divLace" visible="false">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,LaceString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbLace" />
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,SupplierString%>"></asp:Label>
                                        </div>
                                        <asp:DropDownList runat="server" ID="ddlSupplier" />
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,CostString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbCost" Style="text-align: right"></asp:TextBox>
                                        <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="tbCost" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,RentPriceString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbRentPrice" Style="text-align: right"></asp:TextBox>
                                        <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbRentPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,OptionalPriceString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbOptionalPrice" Style="text-align: right"></asp:TextBox>
                                        <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="tbOptionalPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="2u 12u(mobilep)">
                                        <div class="Div">
                                            <asp:Label runat="server" Text="<%$ Resources:Resource,SellingPriceString%>"></asp:Label>
                                        </div>
                                        <asp:TextBox runat="server" ID="tbSalesPrice" Style="text-align: right"></asp:TextBox>
                                        <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator4" ControlToValidate="tbSalesPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </cc1:TabPanel>
                    <cc1:TabPanel runat="server" ID="tabRentRecord" HeaderText="<%$ Resources:Resource,RentRecordString%>">
                        <ContentTemplate>
                            <div class="12u">
                            <div class="row uniform 50%">
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlCategory2" Enabled="false" />
                                </div>
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
                                        <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
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
                <hr />
                <!-- 照片 -->
                <section>

                    <div class="row no-collapse 50% uniform">
                        <div class="2u" runat="server" id="divPhotoUpload">
                            <div class="ImageUploadBtn">
                                <button class="Div btn actions button alt" id="btnUploadPanel" onclick="uploadPanelControl();">
                                    <asp:Literal runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                                </button>
                            </div>
                            <div id="uploadPanel" style="display: none;">
                                <div class="fileUpload">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </div>
                                <div class="fileUpload">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                                    <asp:FileUpload ID="FileUpload2" runat="server" />
                                </div>
                                <div class="fileUpload">
                                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
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
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="ImgBack" />
                            </span>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
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
            </div>
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>" ID="btnCreate" OnClick="btnCreate_Click" />
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
