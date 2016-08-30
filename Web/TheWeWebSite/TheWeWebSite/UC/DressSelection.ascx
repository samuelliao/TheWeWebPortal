<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DressSelection.ascx.cs" Inherits="TheWeWebSite.UC.DressSelection" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<div>
    <div class="12u">
        <div class="row uniform 50%">
            <div class="2u 12u(mobilep)">
                <div class="Div">
                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:DropDownList runat="server" ID="ddlType" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="2u 12u(mobilep)">
                <div class="Div">
                    <asp:Label runat="server" Text="<%$ Resources:Resource,StoreString%>"></asp:Label>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <cc1:ComboBox runat="server" ID="cbDress" AutoCompleteMode="SuggestAppend" OnSelectedIndexChanged="cbDress_SelectedIndexChanged" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="row no-collapse 50% uniform">
            <div class="2u">
                <div style="text-align: center">
                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgFrontString%>"></asp:Label>
                    <asp:Label runat="server" Text="" ID="tbFolderPath" Visible="false"></asp:Label>
                </div>
                <span class="image fit">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Image runat="server" ID="ImgFront" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </span>
            </div>
            <div class="2u">
                <div style="text-align: center">
                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgBackString%>"></asp:Label>
                </div>
                <span class="image fit">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Image runat="server" ID="ImgBack" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </span>
            </div>
            <div class="2u">
                <div style="text-align: center">
                    <asp:Label runat="server" Text="<%$ Resources:Resource,ImgSideString%>"></asp:Label>
                </div>
                <span class="image fit">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Image runat="server" ID="ImgSide" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </span>
            </div>
        </div>
        <div class="row no-collapse 50% uniform">
            <div class="2u 12u(modilep)">
                <asp:Button runat="server" ID="btnDelete" OnClick="btnDelete_Click" Text="Delete" />
            </div>
        </div>
    </div>
</div>
