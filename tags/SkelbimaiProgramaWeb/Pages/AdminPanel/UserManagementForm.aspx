<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="UserManagementForm.aspx.cs" Inherits="Pages_UserManagementForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
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
</asp:Content>