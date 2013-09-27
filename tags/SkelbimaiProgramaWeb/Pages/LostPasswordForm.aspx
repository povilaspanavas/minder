<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LostPasswordForm.aspx.cs" Inherits="Pages_LostPasswordForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="M_Pass1TextBox" runat="server" CssClass="M_Pass1TextBox"></asp:TextBox>
    <asp:TextBox ID="M_Pass2TextBox" runat="server" CssClass="M_Pass2TextBox"></asp:TextBox>

    <asp:Label ID="Label1" runat="server" Text="Slaptažodis" CssClass=Label1></asp:Label>
    <asp:Label ID="Label2" runat="server" Text="Pakartoti slaptažodį" CssClass=Label2></asp:Label>
    </div>
    
    </form>
</body>
</html>
<style type="text/css">
    .M_Pass1TextBox
    {
        position: fixed;
        top: 40pt;
        left: 120pt;
        height: 20pt;
        width: 120pt;
    }
    
    .M_Pass2TextBox
    {
        position: fixed;
        top: 70pt;
        left: 120pt;
        height: 20pt;
        width: 120pt;
    }
    
    .Label1
    {
        position: fixed;
        top: 40pt;
        left: 25pt;
        height: 20pt;
        width: 60pt;
    }
    
    .Label2
    {
        position: fixed;
        top: 70pt;
        left: 25pt;
        height: 20pt;
        width: 100pt;
    }
</style>