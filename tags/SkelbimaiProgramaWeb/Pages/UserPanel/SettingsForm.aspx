<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SettingsForm.aspx.cs" Inherits="Pages_UserPanel_SettingsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" CssClass="Panel1">
            <div>
    <asp:GridView ID="M_SettingsGrid" runat="server" CssClass="M_SettingsGrid" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            ShowHeaderWhenEmpty="True" AutoGenerateColumns="True">
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
        <asp:Button ID="M_CreateSettingsButton" runat="server" Text="Sukurti" CssClass="M_CreateSettingsButton" />
        <asp:LinkButton ID="M_UserPanelLink" runat="server" CssClass="M_UserPanelLink">Pagrindinis</asp:LinkButton>
      </div>
                 </asp:Panel>
        
    
    </form>
</body>
</html>

<style type="text/css">

     .Panel1
    {
        position: fixed;
        top: 30pt;
        left: 120pt;
        height: 20pt;
        width: 600pt;
    }

    .M_SettingsGrid
    {
        position: fixed;
        top: 30pt;
        left: 120pt;
        height: 20pt;
        width: 600pt;
    }
    
    .M_CreateSettingsButton
    {
        position: fixed;
        top: 30pt;
        left: 20pt;
        height: 20pt;
        width: 80pt;
    }
    
    .M_UserPanelLink
    {
        position: fixed;
        top: 60pt;
        left: 20pt;
        height: 12pt;
        width: 80pt;
    }
</style>
