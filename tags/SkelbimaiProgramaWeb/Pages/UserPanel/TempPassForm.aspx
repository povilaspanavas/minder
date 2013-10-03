<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="TempPassForm.aspx.cs" Inherits="Pages_UserPanel_TempPassForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
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
</asp:Content>