<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<!--[if lt IE 7]> <html class="lt-ie9 lt-ie8 lt-ie7" lang="en"> <![endif]-->
<!--[if IE 7]> <html class="lt-ie9 lt-ie8" lang="en"> <![endif]-->
<!--[if IE 8]> <html class="lt-ie9" lang="en"> <![endif]-->
<!--[if gt IE 8]><!--> <html lang="en"> <!--<![endif]-->
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
  <title>Login Form</title>
  <!--[if lt IE 9]><script src="//html5shim.googlecode.com/svn/trunk/html5.js"></script><![endif]-->
</head>
<body>
  <section class="container">
    <div class="login">
      <h1>Prisijungti</h1>
      <form method="post" runat="server">
      <p><asp:TextBox ID="UsernameTextBox" CssClass="userNameTextBox" runat="server" placeholder="Prisijungimo vardas"></asp:TextBox></p>
      <p><asp:TextBox ID="PasswordTextBox" CssClass="passwordTextBox" runat="server" TextMode="Password" placeholder="Slaptažodis"></asp:TextBox></p>
        <p class="submit"><asp:Button ID="LoginButton" runat="server" Text="Prisijungti" CssClass="loginButton" /></p>
      </form>
    </div>

    <div class="login-help">
      <p><asp:HyperLink ID="HyperLink1" runat="server" CssClass="lostPasswordLink" NavigateUrl="~/Pages/LostPasswordForm.aspx">Pamiršau slaptažodį</asp:HyperLink>.</p>
    </div>
  </section>
    
  <div runat="server" class="label" id="LoginLabel">
      <p class="login-label">
        <asp:Label ID="LogLabel" runat="server" CssClass="logLabel"></asp:Label>
      </p>
  </div>
</body>
</html>
