<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="Pages_AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div>
        <asp:LinkButton ID="M_UserManagementLink" runat="server" CssClass="M_UserManagementLink">Vartotojai</asp:LinkButton>
       <asp:LinkButton ID="M_ConnectedUserLink" runat="server" CssClass="M_ConnectedUserLink">Prisijungę vartotojai</asp:LinkButton>
        <asp:LinkButton ID="M_LogOutLink" runat="server" CssClass="M_LogOutLink">Atsijungti</asp:LinkButton>
        
    </div>
    </form>
</asp:Content>