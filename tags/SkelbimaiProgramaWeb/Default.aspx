<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div style="height: 383px">
        <asp:TextBox ID="UsernameTextBox" CssClass="userNameTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="PasswordTextBox" CssClass="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="LoginButton" runat="server" Text="Prisijungti" CssClass="loginButton" />
        <asp:Label ID="PasswordLabel" runat="server" Text="Slaptažodis" CssClass="passwordLabel"></asp:Label>
        <asp:Label ID="LogLabel" runat="server" CssClass="logLabel"></asp:Label>
        <asp:Label ID="UsernameLabel" runat="server" Text="Vartotojo vardas" CssClass="userNameLabel"></asp:Label>
        <asp:Label ID="LoginLabel" runat="server" Text="Prašome prisijungti" CssClass="loginLabel"></asp:Label>
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="lostPasswordLink" NavigateUrl="~/Pages/LostPasswordForm.aspx">Pamiršau slaptažodį</asp:HyperLink>
    </div>
    </form>
</asp:Content>
