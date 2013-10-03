<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="CreateSettingsForm.aspx.cs"
    Inherits="Pages_UserPanel_CreateSettingsForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="M_NameTextBox" runat="server" CssClass="M_NameTextBox"></asp:TextBox>
        <asp:TextBox ID="M_UrlTextBox" runat="server" CssClass="M_UrlTextBox"></asp:TextBox>
        <asp:DropDownList ID="M_DropDownList" runat="server" CssClass="M_DropDownList">
        </asp:DropDownList>

        <asp:Button ID="M_SaveButton" runat="server" Text="Išsaugoti" CssClass="M_SaveButton" />
        <asp:Button ID="M_CancelButton" runat="server" Text="Atšaukti" CssClass="M_CancelButton" />
        <asp:Label ID="Label1" runat="server" Text="Pavadinimas" CssClass="Label1"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Nuoroda" CssClass="Label2"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Tinklapis" CssClass="Label3"></asp:Label>
        <asp:Label ID="M_LogLabel" runat="server" CssClass="M_LogLabel" 
            Font-Bold="True"></asp:Label>
    </div>
    </form>
</asp:Content>