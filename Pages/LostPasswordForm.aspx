<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LostPasswordForm.aspx.cs" Inherits="Pages_LostPasswordForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="M_EmailTextBox" runat="server" CssClass="M_Pass1TextBox"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Text="El. paštas" CssClass="Label1"></asp:Label>
            <asp:Button ID="M_OkButton" runat="server" Text="Gerai" CssClass="M_OkButton" />
            <asp:Label ID="M_LogLabel" runat="server" CssClass="M_LogLabel" Font-Bold="True"></asp:Label>
             </div>

    </form>
</body>
</html>
<style type="text/css">
    .M_Pass1TextBox {
        position: fixed;
        top: 40pt;
        left: 120pt;
        height: 12pt;
        width: 120pt;
    }

    .Label1 {
        position: fixed;
        top: 40pt;
        left: 25pt;
        height: 12pt;
        width: 60pt;
    }

    .M_OkButton {
        position: fixed;
        top: 40pt;
        left: 250pt;
        height: 20pt;
        width: 60pt;
    }

    .M_LogLabel {
        position: fixed;
        top: 70pt;
        left: 50pt;
        height: 40pt;
        width: 300pt;
    }

</style>
