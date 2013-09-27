<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 383px">

            <asp:TextBox ID="UsernameTextBox" CssClass="userNameTextBox" runat="server"></asp:TextBox>
        <asp:TextBox ID="PasswordTextBox" CssClass="passwordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        <asp:Button ID="LoginButton" runat="server" Text="Prisijungti" CssClass="loginButton" />
        <asp:Label ID="PasswordLabel" runat="server" Text="Slaptažodis" CssClass="passwordLabel"></asp:Label>
        <asp:Label ID="LogLabel" runat="server" CssClass="logLabel"></asp:Label>
        <asp:Label ID="UserNameLabel" runat="server" Text="Vartotojo vardas" CssClass="userNameLabel"></asp:Label>
        <asp:Label ID="LoginLabel" runat="server" Text="Prašome prisijungti" CssClass="loginLabel"></asp:Label>
        <asp:HyperLink ID="LostPasswordLink" runat="server" CssClass="lostPasswordLink" NavigateUrl="~/Pages/LostPasswordForm.aspx">Pamiršau slaptažodį</asp:HyperLink>

    </div>
    </form>
</body>
</html>
<style type="text/css">
    .userNameTextBox
    {
        position: fixed;
        top: 60pt;
        left: 100pt;
        height: 12pt;
        width: 130pt;
    }
    
    .passwordTextBox
    {
        position: fixed;
        top: 80pt;
        left: 100pt;
        height: 12pt;
        width: 130pt;
    }
    
    .loginLabel
    {
        position: fixed;
        top: 30pt;
        left: 110pt;
        height: 12pt;
        width: 130pt;
        font-weight: bold;
    }
    
    .userNameLabel
    {
        position: fixed;
        top: 60pt;
        left: 10pt;
        height: 12pt;
        width: 130pt;
    }
    
    .passwordLabel
    {
        position: fixed;
        top: 80pt;
        left: 10pt;
        height: 12pt;
        width: 130pt;
    }
    
    .loginButton
    {
        position: fixed;
        top: 100pt;
        left: 120pt;
        height: 20pt;
        width: 80pt;
    }
    
    .logLabel
    {
        position: fixed;
        top: 150pt;
        left: 10pt;
        height: 40pt;
        width: 300pt;
    }
    
    .lostPasswordLink
    {
        position: fixed;
        top: 125pt;
        left: 115pt;
        height: 20pt;
        width: 100pt;
    }
</style>
