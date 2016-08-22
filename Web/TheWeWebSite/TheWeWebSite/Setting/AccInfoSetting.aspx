<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccInfoSetting.aspx.cs" Inherits="TheWeWebSite.Setting.AccInfoSetting" %>

<%@ Register TagPrefix="My" TagName="Header" Src="~/Header.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
    <link href="../assets/css/datePicker.css" rel="stylesheet" />
</head>
<body>
    <form runat="server">

        <!-- Main -->
        <My:Header runat="server" ID="ucHeader" />
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
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmpOnboardDayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:textbox runat="server" ID="EmpOnBoardDay" Style="text-align:right" Enabled="false"></asp:textbox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmployeeSnString%>"></asp:Label>
                            </div>
                            <asp:textbox runat="server" Style="text-align: right" ID="tbEmpSn" Enabled="false"></asp:textbox>
                            <asp:Label runat="server" ID="labelPw" Visible="false" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AccountString%>"></asp:Label>
                            </div>
                            <asp:textbox runat="server" ID="tbAccount" Enabled="false"></asp:textbox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PasswordString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPwd" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PasswordConfirmInputString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbPwdConfirm" TextMode="Password"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbEmpPhone"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="EmpBDay" Style="text-align: right"
                                    CssClass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmailString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpEmail"></asp:TextBox>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AddressString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpAddress"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PassportNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpPassportName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PassportIdString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbEmpPassportId"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmergencyContactString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpEC"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmergencyContactTelString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbEmpECTel"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BankString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbEmpBank"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BankBookString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" Style="text-align: right" ID="tbEmpBankBook"></asp:TextBox>
                        </div>


                    </div>
                </div>
            </div>

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
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgIdCardFrontString%>"></asp:Label>
                                <asp:FileUpload ID="FileUpload2"  runat="server" />
                            </div>
                            <div class="fileUpload">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ImgIdCardBackString%>"></asp:Label>
                                <asp:FileUpload ID="FileUpload3"  runat="server" />
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
                            <asp:Image runat="server" ID="ImgSide" />
                            </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgIdCardFrontString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgFront" />
                        </span>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="<%$ Resources:Resource,ImgIdCardBackString%>"></asp:Label>
                        </div>
                        <span class="image fit">
                            <asp:Image runat="server" ID="ImgBack" />
                        </span>
                    </div>
                </div>
            </section>
            <hr />
            <!-- Btn -->
            <div class="Div btn">
                <ul class="actions">
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ModifyString%>" ID="btnModify" OnClick="btnModify_Click" />
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
