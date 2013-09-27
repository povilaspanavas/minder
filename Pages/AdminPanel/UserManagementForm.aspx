<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManagementForm.aspx.cs" Inherits="Pages_UserManagementForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="M_UserGridView" runat="server" CssClass="M_UserGridView" BackColor="White" 
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
    
        <asp:Button ID="M_CreateUserButton" runat="server" Text="Sukurti" CssClass="M_CreateUserButton"/>
    
        <asp:LinkButton ID="M_AdminPanelLink" runat="server" CssClass="M_AdminPanelLink">Admin panelė</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>

<style type="text/css">
    .M_UserGridView
    {
        position: fixed;
        top: 20pt;
        left: 150pt;
        height: 12pt;
        width: 600pt;
    }
    
    .M_CreateUserButton
    {
        position: fixed;
        top: 20pt;
        left: 30pt;
        height: 20pt;
        width: 50pt;
    }
    
     .M_AdminPanelLink
    {
        position: fixed;
        top: 60pt;
        left: 30pt;
        height: 20pt;
        width: 70pt;
    }
</style>
