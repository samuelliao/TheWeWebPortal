<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChurchMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.ChurchMCreate" %>

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
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:TextBox runat="server" ID="tbSn" Enabled="false"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:Label runat="server" ID="tbSysSn" Visible="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlCountry" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddlCountry" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="required" runat="server" ID="ddlArea" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlArea" runat="server"
                                        ErrorMessage="required" CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox CssClass="required" runat="server" ID="tbName" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                                ControlToValidate="tbName" runat="server"
                                ErrorMessage="required"
                                CssClass="error" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CnNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCnName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EnglishNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEngName"></asp:TextBox>
                        </div>

                    </div>
                </div>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,JpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbJpName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CapacitiesString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbCapacities"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator1" ControlToValidate="tbCapacities" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RedCarpetLengthString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbRedCarpetLength"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator2" ControlToValidate="tbRedCarpetLength" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RedCarpetTypeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRedCarpetType"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PatioHeightString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbPatioHeight"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator3" ControlToValidate="tbPatioHeight" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbPrice"></asp:TextBox>
                            <asp:RegularExpressionValidator CssClass="error" Display="Dynamic" ID="RegularExpressionValidator4" ControlToValidate="tbPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ServiceAndPriceDescriptionString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="tbMealDescription" TextMode="MultiLine" Height="150px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" TextMode="MultiLine" ID="tbRemark" Height="150px"></asp:TextBox>
                            </div>
                        </div>                        
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="6u 12u(mobilep) serch">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingAppointmentTimeString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgBookTable" runat="server" OnRowDeleting="dgBookTable_RowDeleting"
                                            AutoGenerateColumns="False" Font-Size="Small">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="0px">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbId" runat="server" Style="display:none;" Width="0px"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,StartString%>">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbStart" Style="text-align: right; margin-top: 15px" runat="server"
                                                            CssClass="date date-1" value="HH:MM" data-type="time"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,EndString%>">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbEnd" Style="text-align: right; margin-top: 15px" runat="server"
                                                            CssClass="date date-1" value="HH:MM" data-type="time"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowDeleteButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div style="float: right">
                                <asp:Button ID="btnAddRow" runat="server"
                                    Text="Add New Row" OnClick="btnAddRow_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <hr />
            <!-- 照片 -->
            <div class="12u" runat="server" id="divPhotoUpload">
                <div class="ImageUploadBtn" style="margin-top:0PX!important">
                    <button class="Div btn actions button alt" id="btnUploadPanel" onclick="uploadPanelControl();">
                        <asp:Literal runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                    </button>
                </div>
                <div id="uploadPanel" style="display: none;">
                        <div class="fileUpload" runat="server" id="divUpload">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload1" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload2" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload3" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload4" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,BouquetPictureString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload5" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,MapPhotoString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload6" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,DMPhotoString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload7" Width="80px"  runat="server" />
                            <asp:Label runat="server" Text="<%$ Resources:Resource,MealString%>"></asp:Label>
                            <asp:FileUpload ID="FileUpload8" Width="80px"  runat="server" />
                        </div>
                    <div style="text-align: left; margin-top: 15px;">
                        <asp:Button CausesValidation="true" runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload"
                            OnClick="btnUpload_Click" OnClientClick="uploadPanelControl();" />
                    </div>
                </div>
            </div>
                    <hr />

            <div class="row no-collapse 50% uniform">
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                        <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgFront" />
                    </span>

                </div>
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgBack" />
                    </span>
                </div>
            </div>
            <hr />
            <div class="row no-collapse 50% uniform">
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgSide" />
                    </span>
                </div>
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,ImgOtherString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgOther1" />
                    </span>
                </div>

            </div>
            <hr />
            <div class="row no-collapse 50% uniform">
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,BouquetPictureString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgBouquet" />
                    </span>
                </div>
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,MapPhotoString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgMap" />
                    </span>
                </div>
            </div>
            <hr />
            <div class="row no-collapse 50% uniform">
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,DMPhotoString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgDM" />
                    </span>
                </div>
                <div class="6u 12u(mobilep)">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="<%$ Resources:Resource,MealString%>"></asp:Label>
                    </div>
                    <span class="image fit">
                        <asp:Image runat="server" ID="ImgMeal" />
                    </span>
                </div>
            </div>

            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">

                    <li>
                        <asp:Button runat="server" Text="<%$ Resources:Resource,CreateString%>"
                            ID="btnCreate" OnClick="btnCreate_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>"
                            ID="btnModify" OnClick="btnModify_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                            ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>"
                            ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button CausesValidation="false" runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
                            ID="btnCancel" OnClick="btnCancel_Click" />
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
        <!-- datepicker -->
        <script src="../assets/js/picker.js"></script>
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

