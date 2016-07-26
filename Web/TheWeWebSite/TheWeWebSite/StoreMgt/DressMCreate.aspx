<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressMCreate" %>


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

        <section class="box title">
            <h3>
                <asp:Label runat="server" Text="" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="禮服編號"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="性別"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlGender" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="禮服類別"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlDressCategory" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="禮服顏色"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbColor" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="型態"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlDressType" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="領口"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlNeckline" />

                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="後背"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlBack" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="肩膀"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlShoulder" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="質料"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbMaterial"></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="穿法"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlWorn" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="頭紗"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlVeil" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="配件"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />

                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="拖尾"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlTrailing" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="胸花"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCorsage" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="手套"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlGloves" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="狀態碼"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlStatus" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="使用狀態"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlUseStatus"/>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="成本價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="" ID="tbCost"></asp:TextBox>

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="訂製價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbCustomPrice" ></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="供應商"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlSupplier" />

                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="租金"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbRentPrice"></asp:TextBox>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="售價"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPrice"></asp:TextBox>

                        </div>
                        <div class="6u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="其他"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOthers"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="可否外拍" ID="cbOutPhoto" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="外拍加價金額"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbOutPhotoPrice"></asp:TextBox>
                        </div>
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="加價款" ID="cbPlusItem" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="加價款加價金額"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPlusItemPrice"></asp:TextBox>
                        </div>
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="限國內婚宴" ID="cbDomesticWedding" />
                        </div>
                        <div style="margin-top: 1.6em">
                            <asp:CheckBox runat="server" Text="大尺碼" ID="cbBigSize" />
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
                            <asp:Label runat="server" Text="正面照片"></asp:Label>
                        </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload1" OnClick="btnUpload1_Click" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="背面照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload2" OnClick="btnUpload2_Click" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="側面照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload3" OnClick="btnUpload3_Click" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="其他照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload4" OnClick="btnUpload4_Click" />
                    </div>
                </div>
                <div class="2u">
                    <div style="text-align: center">
                        <asp:Label runat="server" Text="其他照片"></asp:Label>
                    </div>
                    <span class="image fit">
                        <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                    <div class="align-center">
                        <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" ID="btnUpload5" OnClick="btnUpload5_Click" />
                    </div>
                </div>
                </div>
            </section>
            <hr />
            <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
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
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click"/>
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" ID="btnDelete" OnClick="btnDelete_Click" />
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,CancelString%>" ID="btnCancel" OnClick="btnCancel_Click" />
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
    </form>
</body>
</html>
