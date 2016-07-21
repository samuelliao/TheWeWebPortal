<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimeMCreate.aspx.cs" Inherits="TheWeWebSite.CaseMgt.TimeMCreate" %>

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
                <asp:Label runat="server" Text="案件管理&nbsp;&nbsp;>&nbsp;&nbsp;時程維護&nbsp;&nbsp;>&nbsp;&nbsp;新增修改刪除(待修改)" ID="labelPageTitle"></asp:Label></h3>
        </section>

        <!-- Input -->
        <section class="insert">
            <div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,Sntring%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlSn" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ContractDateString%>"></asp:Label>
                            </div>
                            <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbContractDate"></asp:TextBox> </div>
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
                            <asp:DropDownList runat="server" ID="ddlCountry" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,AreaString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlArea" />
                        </div>
                    </div>
                </div>
                <div class="12u">

                    <div class="row uniform 50%">
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,LocationString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" ID="ddlLocation" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ProductSetString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server"  ID="ddlProductSet"/>
                        </div>

                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="會議次數"></asp:Label>
                            </div>
                            <asp:TextBox runat="server" placeholder=""></asp:TextBox>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,ConferenceDateString%>"></asp:Label>
                            </div>
                            <div> <asp:TextBox runat="server"  CssClass="dp" ID="tbConDate"></asp:TextBox> </div>
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                        <div class="2u 12u(mobilep)">
                            <div class="Div">
                                <asp:Label runat="server" Text="會議完成度"></asp:Label>
                            </div>
                            <asp:DropDownList runat="server" />
                        </div>
                    </div>


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
                            ID="btnModify" OnClick="btnModify_Click"/>
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,ClearString%>" 
                            ID="btnClear" OnClick="btnClear_Click"/>
                    </li>
                    <li>
                        <asp:Button runat="server" CssClass="button alt" Text="<%$ Resources:Resource,DeleteString%>" 
                            ID="btnDelete" OnClick="btnDelete_Click"/>
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
        <script src="../assets/js/datepicker.js"></script>
        <script src="../assets/js/jquery-1.10.2.js"></script>
        <script src="../assets/js/jquery-ui.js"></script>
    </form>
</body>
</html>
