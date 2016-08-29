<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DressRentMaintain.aspx.cs" Inherits="TheWeWebSite.StoreMgt.DressRentMaintain" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>The We Wedding</title>
    <link href="../assets/css/font-awesome.min.css" rel="stylesheet" />
    <link href="../assets/css/main.css" rel="stylesheet" />
</head>
<body class="landing">
    <form runat="server">
        <div id="page-wrapper">

            <!-- Header -->

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
                                <div class="2u 12u(mobilep)" runat="server" id="divStore" style="display: none;">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStore" />
                                </div>
                                <div class="2u 12u(mobilep)" runat="server" >
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MemberIdString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbMemberSn" placeholder="<%$ Resources:Resource,SnInputString%>"></asp:TextBox>
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,SnString%>"></asp:Label>
                                    </div>
                                    <asp:TextBox runat="server" ID="tbSn" placeholder="<%$ Resources:Resource,SnInputString%>"></asp:TextBox>
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
                                    <asp:DropDownList runat="server" ID="ddlDressCategory" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,ColorString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlColor" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,MaterialString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlMaterial" />
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
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,WornString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlWorn" />
                                </div>
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,NecklineString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlNeckLine" />
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
                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,StatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlStatus" />

                                </div>
                            </div>
                        </div>
                        <div class="12u">
                            <div class="row uniform 50%">

                                <div class="2u 12u(mobilep)">
                                    <div class="Div">
                                        <asp:Label runat="server" Text="<%$ Resources:Resource,UsageStatusString%>"></asp:Label>
                                    </div>
                                    <asp:DropDownList runat="server" ID="ddlUseStatus" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="<%$ Resources:Resource,OutdoorShootingString%>" ID="cbOutPhoto" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="加價款" ID="cbAddPrice" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="限國內婚宴" ID="cbDomesticWedding" />
                                </div>
                                <div style="margin-top: 1.6em">
                                    <asp:CheckBox runat="server" Text="<%$ Resources:Resource,BigSizeString%>" ID="cbBigSize" />
                                </div>
                            </div>
                        </div>



                    </div>


                    <!-- Btn -->

                    <div class="Div btn">
                    </div>
                    <asp:Label runat="server" ID="labelWarnString" ForeColor="Red" Visible="false" />
                    <hr />

                    <!-- Table -->


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
    </form>
</body>
</html>
