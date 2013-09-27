<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUserForm.aspx.cs" Inherits="Pages_AdminPanel_NewUserForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
</body>
</html>
<style type="text/css">
    .M_UserNameTextBox
    {
        position: fixed;
        top: 20pt;
        left: 100pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_EmailTextBox
    {
        position: fixed;
        top: 40pt;
        left: 100pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_PassTextBox
    {
        position: fixed;
        top: 60pt;
        left: 100pt;
        height: 12pt;
        width: 120pt;
    }
    
    .M_TempPassCheckBox
    {
        position: fixed;
        top: 80pt;
        left: 100pt;
        height: 12pt;
        width: 110pt;
    }
    
    .M_BlockedCheckBox
    {
        position: fixed;
        top: 100pt;
        left: 100pt;
        height: 12pt;
        width: 110pt;
    }
    
    .M_SaveButton
    {
        position: fixed;
        top: 120pt;
        left: 100pt;
        height: 20pt;
        width: 50pt;
    }
    
    .M_CancelButton
    {
        position: fixed;
        top: 120pt;
        left: 160pt;
        height: 20pt;
        width: 50pt;
    }
    
    .Label1
    {
        position: fixed;
        top: 20pt;
        left: 10pt;
        height: 12pt;
        width: 100pt;
    }
    
    .Label2
    {
        position: fixed;
        top: 40pt;
        left: 10pt;
        height: 12pt;
        width: 100pt;
    }
    
    .Label3
    {
        position: fixed;
        top: 60pt;
        left: 10pt;
        height: 12pt;
        width: 100pt;
    }
    
    .M_LogLabel
    {
        position: fixed;
        top: 150pt;
        left: 10pt;
        height: 80pt;
        width: 400pt;
    }
    
    .M_GeneratePassButton
    {
        position: fixed;
        top: 60pt;
        left: 230pt;
        height: 20pt;
        width: 100pt;
    }
</style>
