<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TheWeWebSite.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div runat="server" style="text-align:center">
    <div style="padding:5px; text-align: center;">
    <label for="select" style=" font-size: 20px">店別:</label>
    <select name="select" id="select">
    </select>
  </div>
  <div style="padding:5px; text-align: center;">
      <asp:Label ID="labelAccount" Font-Size="20px" Text="Account:" runat="server" />
      <asp:TextBox ID="tbAccount" TextMode="SingleLine" runat="server" />    
  </div>
  <div style="padding:5px;">
      <asp:Label ID="lPassword" Text="Password:" runat="server" Font-Size="20px" />
      <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" />
  </div>
  <div style="padding:5px;">
      <asp:Button ID="btnSubmit" CssClass="btn_2" runat="server" Text="Login"  OnClick="btnSubmit_Click"/>
  </div>
        </div>
</asp:Content>
