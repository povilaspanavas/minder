<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TempPassForm.aspx.cs" Inherits="Pages_UserPanel_TempPassForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="M_Pass1TextBox" runat="server" CssClass="M_Pass1TextBox" 
            TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="M_Pass2TextBox" runat="server" CssClass="M_Pass2TextBox" 
            TextMode="Password"></asp:TextBox>
        
        <asp:Label ID="Label1" runat="server" Text="Prašome nustatyti savo slaptažodį" 
            Font-Bold="True" CssClass="Label1"></asp:Label>

        <asp:Label ID="Label2" runat="server" Text="Slaptažodis" CssClass="Label2"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Pakartoti slaptažodį" CssClass="Label3"></asp:Label>

         <asp:Button ID="M_OkButton" runat="server" CssClass="M_OkButton" Text="Gerai" />
         <asp:Label ID="M_LogLabel" runat="server" Text="" CssClass="M_LogLabel"></asp:Label>
    
    </div>
   
    
   
    </form>
</body>
</html>
<style type="text/css">
    .M_Pass1TextBox
    {
        position: fixed;
        top: 50pt;
        left: 120pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_Pass2TextBox
    {
        position: fixed;
        top: 70pt;
        left: 120pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_OkButton
    {
        position: fixed;
        top: 90pt;
        left: 150pt;
        height: 20pt;
        width: 50pt;
    }
    
    .Label1
    {
        position: fixed;
        top: 10pt;
        left: 100pt;
        height: 12pt;
        width: 200pt;
    }
    
    .Label2
    {
        position: fixed;
        top: 50pt;
        left: 20pt;
        height: 12pt;
        width: 100pt;
    }
    
    .Label3
    {
        position: fixed;
        top: 70pt;
        left: 20pt;
        height: 12pt;
        width: 100pt;
    }
    
    .M_LogLabel
    {
        position: fixed;
        top: 120pt;
        left: 20pt;
        height: 36pt;
        width: 250pt;
    }
</style>