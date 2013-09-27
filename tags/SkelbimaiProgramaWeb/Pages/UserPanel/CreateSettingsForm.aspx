<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateSettingsForm.aspx.cs"
    Inherits="Pages_UserPanel_CreateSettingsForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
</body>
</html>
<style type="text/css">
    .M_NameTextBox
    {
        position: fixed;
        top: 30pt;
        left: 150pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_UrlTextBox
    {
        position: fixed;
        top: 50pt;
        left: 150pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_DropDownList
    {
        position: fixed;
        top: 70pt;
        left: 150pt;
        height: 17pt;
        width: 120pt;
    }
    
    .M_SaveButton
    {
        position: fixed;
        top: 100pt;
        left: 150pt;
        height: 20pt;
        width: 60pt;
    }
    
    .M_CancelButton
    {
        position: fixed;
        top: 100pt;
        left: 220pt;
        height: 20pt;
        width: 60pt;
    }
    
    .Label1
    {
        position: fixed;
        top: 30pt;
        left: 70pt;
        height: 12pt;
        width: 70pt;
    }
    
    .Label2
    {
        position: fixed;
        top: 50pt;
        left: 70pt;
        height: 12pt;
        width: 70pt;
    }
    
    .Label3
    {
        position: fixed;
        top: 70pt;
        left: 70pt;
        height: 12pt;
        width: 70pt;
    }
    
    .M_LogLabel
    {
        position: fixed;
        top: 140pt;
        left: 70pt;
        height: 50pt;
        width: 200pt;
    }
</style>
