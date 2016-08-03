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

        <!-- Main -->
        <My:Header runat="server" ID="ucHeader" />

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <div>
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
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
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlCountry" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="ddlArea" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,NameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbName" />
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CnNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCnName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EnglishNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEngName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,JpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbJpName" placeholder="<%$ Resources:Resource,NameInputString%>"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CapacitiesString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbCapacities"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbCapacities" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RedCarpetLengthString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbRedCarpetLength"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="tbRedCarpetLength" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RedCarpetTypeString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server"  ID="tbRedCarpetType"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PatioHeightString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbPatioHeight"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="tb{atioHeight" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PriceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbPrice"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="tbPrice" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,WeddingAppointmentTimeString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 200px">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="dgBookTable" runat="server"
                                            ShowFooter="True" AutoGenerateColumns="False"
                                            OnRowDeleting="dgBookTable_RowDeleting" Font-Size="Small">
                                            <Columns>
                                                <asp:TemplateField HeaderText="<%$ Resources:Resource,StartString%>">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="tbStart" style="text-align:right" runat="server"
                                                            Cssclass="date date-1" value="HH:MM" data-type="time"></asp:TextBox>
                                                    </ItemTemplate>
                                                    <FooterStyle HorizontalAlign="Right" />
                                                    <FooterTemplate>
                                                        <asp:Button ID="btnAddRow" runat="server"
                                                            Text="Add New Row" OnClick="btnAddRow_Click" />
                                                    </FooterTemplate>
                                                </asp:TemplateField>
                                                <asp:CommandField ShowDeleteButton="True" />
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div style="margin-top: 1.6em">
                                <span class="image fit">
                                    <asp:Image runat="server" ID="ImageMeal" ImageUrl="../assets/img/logo_clear.jpg" />
                                </span>
                                <div class="align-center">
                                    <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUploadMeal" OnClick="btnUploadMeal_Click" />
                                </div>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ServiceAndPriceDescriptionString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 200px">
                                <asp:TextBox runat="server"  ID="tbMealDescription" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <div style="overflow-y: auto; height: 200px">
                                <asp:TextBox runat="server"  TextMode="MultiLine" ID="tbRemark"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

                <hr />
                <!-- 照片 -->
                <section>
                    <div class="row no-collapse 50% uniform">
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="imgPhoto1" ImageUrl="../assets/img/logo_clear.jpg" />
                            </span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnPhoto1" OnClick="btnPhoto1_Click" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="Image2" ImageUrl="../assets/img/logo_clear.jpg" />
                            </span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnPhoto2" OnClick="btnPhoto2_Click" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="Image3" ImageUrl="../assets/img/logo_clear.jpg" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnPhoto3" OnClick="btnPhoto3_Click" />
                            </div>
                        </div>
                        <div class="2u">
                            <div style="text-align: center">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhotoString%>"></asp:Label>
                            </div>
                            <span class="image fit">
                                <asp:Image runat="server" ID="Image4" ImageUrl="../assets/img/logo_clear.jpg" /></span>
                            <div class="align-center">
                                <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnPhoto4" OnClick="btnPhoto4_Click" />
                            </div>
                        </div>
                    </div>
                </section>
                <hr />


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
                            ID="btnModify" OnClick="btnModify_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>"
                            ID="btnClear" OnClick="btnClear_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>"
                            ID="btnDelete" OnClick="btnDelete_Click" Visible="false" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>"
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
    </form>
</body>
</html>

