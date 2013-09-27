<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="Pages_AdminPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="M_UserManagementLink" runat="server" CssClass="M_UserManagementLink">Vartotojai</asp:LinkButton>
       <asp:LinkButton ID="M_ConnectedUserLink" runat="server" CssClass="M_ConnectedUserLink">Prisijungę vartotojai</asp:LinkButton>
        <asp:LinkButton ID="M_LogOutLink" runat="server" CssClass="M_LogOutLink">Atsijungti</asp:LinkButton>
        
    </div>
    </form>
</body>
</html>
<style type="text/css">
    .M_UserManagementLink
    {
        position: fixed;
        top: 20pt;
        left: 20pt;
        height: 12pt;
        width: 50pt;
    }
    
    .M_LogOutLink
    {
        position: fixed;
        top: 60pt;
        left: 20pt;
        height: 12pt;
        width: 50pt;
    }
    
     .M_ConnectedUserLink
    {
        position: fixed;
        top: 40pt;
        left: 20pt;
        height: 12pt;
        width: 100pt;
    }
</style>
