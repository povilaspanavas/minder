<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="NewUserForm.aspx.cs" Inherits="Pages_AdminPanel_NewUserForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="M_UserNameTextBox" runat="server" CssClass="M_UserNameTextBox"></asp:TextBox>
        <asp:TextBox ID="M_EmailTextBox" runat="server" CssClass="M_EmailTextBox"></asp:TextBox>
        <asp:TextBox ID="M_PassTextBox" runat="server" CssClass="M_PassTextBox"></asp:TextBox>
        <asp:CheckBox ID="M_TempPassCheckBox" runat="server" 
            CssClass="M_TempPassCheckBox" Text="Laikinas slaptažodis"/>
        <asp:Button ID="M_SaveButton" runat="server" Text="Išsaugoti" CssClass="M_SaveButton"/>
        <asp:Button ID="M_CancelButton" runat="server" Text="Atšaukti" CssClass="M_CancelButton" />
        <asp:Label ID="Label1" runat="server" Text="Vartotojo vardas" CssClass="Label1"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="El. paštas" CssClass="Label2"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Slaptažodis" CssClass="Label3"></asp:Label>
        <asp:Button ID="M_GeneratePassButton" runat="server" Text="Generuoti slaptažodį" CssClass="M_GeneratePassButton"/>
        <asp:Label ID="M_LogLabel" runat="server" Text="" CssClass="M_LogLabel"></asp:Label>
        <asp:CheckBox ID="M_BlockedCheckBox" runat="server" CssClass="M_BlockedCheckBox" Text="Blokuotas" />
    </div>
    </form> 
</asp:Content>