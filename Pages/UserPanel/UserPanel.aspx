<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="Pages_UserPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div style="height:100%;width:100%;overflow:scroll;">
    
        <asp:LinkButton ID="M_SettingsLink" runat="server" CssClass="M_SettingsLink">Paieškos nustatymai</asp:LinkButton>
        <asp:LinkButton ID="M_LogOutLink" runat="server" CssClass="M_LogOutLink">Atsijungti</asp:LinkButton>
        <asp:LinkButton ID="M_ProfileLink" runat="server" CssClass="M_ProfileLink">Profilis</asp:LinkButton>

        <asp:Button ID="M_OpenLinkButton" runat="server" CssClass="M_OpenLinkButton" Text="Atidaryti" />
    
        <asp:Button ID="M_DeleteButton" runat="server" CssClass="M_DeleteButton" Text="Ištrinti" />
        <asp:Button ID="M_MarkAsReadButton" runat="server" CssClass="M_MarkAsReadButton" Text="Pažymėti kaip perskaitytą" />
    
        <asp:Button ID="M_SelectAllButton" runat="server" CssClass="M_SelectAllButton" Text="Žymėti viską" />
        <asp:Button ID="M_RefreshButton" runat="server" CssClass="M_RefreshButton" Text="Atnaujinti" />

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
</asp:Content>