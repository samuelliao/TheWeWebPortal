﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeMCreate.aspx.cs" Inherits="TheWeWebSite.StoreMgt.EmployeeMCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/jquery-ui.css" rel="stylesheet" />
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
                <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />

                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmployeeSnString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpSn"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,CountryString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlCountry" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmpNameString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder="請輸入姓名..." ID="tbEmpName"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AccountString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbAccount"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmpOnboardDayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="EmpOnBoardDay" style="text-align:right"
                                    Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmpQuitDayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="EmpQuitDay" style="text-align:right"
                                    Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>                        
                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,PhoneString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpPhone"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BdayString%>"></asp:Label>
                            </div>
                            <div>
                                <asp:TextBox runat="server" ID="EmpBDay" style="text-align:right"
                                    Cssclass="date date-1" value="" placeholder="YYYY-MM-DD"></asp:TextBox>
                            </div>
                        </div>
                        <div class="4u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,EmailString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpEmail"></asp:TextBox>
                        </div>
                        <div class="6u 12u(mobilep)">
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
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpPassportId"></asp:TextBox>
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
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpECTel"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BankString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpBank"></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,BankBookString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpBankBook"></asp:TextBox>
                        </div>


                    </div>
                </div>
                <div class="12u">
                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,SalaryString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpSalary"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="tbEmpSalary" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+[.]*\d*"></asp:RegularExpressionValidator>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,InsuranceString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" style="text-align:right" ID="tbEmpInsurance"></asp:TextBox>
                        </div>
                        <div class="8u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,RemarkString%>"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" ID="tbEmpRemark"></asp:TextBox>
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
                            <asp:Label runat="server" Text="員工照片"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="身分證正面"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
                    </div>
                    <div class="2u">
                        <div style="text-align: center">
                            <asp:Label runat="server" Text="身分證背面"></asp:Label>
                        </div>
                        <span class="image fit">
                            <img src="../assets/img/logo_clear.jpg" alt="" /></span>
                        <div class="align-center">
                            <asp:Button runat="server" Text="<%$ Resources:Resource,UploadString%>" />
                        </div>
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
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" ID="btnClear" OnClick="btnClear_Click" />
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
        <!-- datepicker -->
        <script src="../assets/js/picker.js"></script>
    </form>
</body>
</html>

