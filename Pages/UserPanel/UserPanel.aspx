﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="Pages_UserPanel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinkButton ID="M_SettingsLink" runat="server" CssClass="M_SettingsLink">Paieškos nustatymai</asp:LinkButton>
        <asp:LinkButton ID="M_LogOutLink" runat="server" CssClass="M_LogOutLink">Atsijungti</asp:LinkButton>
    
        <asp:GridView ID="M_AdvertGrid" runat="server" CssClass="M_AdvertGrid" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            ShowHeaderWhenEmpty="True" AutoGenerateColumns="True" ViewStateMode="Enabled">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
<style type="text/css">
    .M_SettingsLink
    {
        position: fixed;
        top: 30pt;
        left: 20pt;
        height: 12pt;
        width: 100pt;
    }
    
    .M_LogOutLink
    {
        position: fixed;
        top: 50pt;
        left: 20pt;
        height: 12pt;
        width: 100pt;
    }
    
    .M_AdvertGrid
    {
        position: fixed;
        top: 30pt;
        left: 150pt;
        height: 12pt;
        width: 600pt;
    }
</style>
