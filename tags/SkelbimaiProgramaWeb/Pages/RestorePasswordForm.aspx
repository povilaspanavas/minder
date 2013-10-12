<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RestorePasswordForm.aspx.cs" Inherits="Pages_RestorePasswordForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="M_PassTextBox" runat="server" CssClass="M_PassTextBox"></asp:TextBox>
            <asp:TextBox ID="M_Pass2TextBox" runat="server" CssClass="M_Pass2TextBox"></asp:TextBox>
            <asp:Button ID="M_OkButton" runat="server" Text="Gerai" CssClass="M_OkButton" />
            <asp:Label ID="M_LogLabel" runat="server" Text=""></asp:Label>
        </div>

    </form>
</body>
</html>

<style type="text/css">
    .M_PassTextBox {
        position: fixed;
        top: 40pt;
        left: 120pt;
        height: 12pt;
        width: 120pt;
    }

    .M_Pass2TextBox {
        position: fixed;
        top: 60pt;
        left: 120pt;
        height: 12pt;
        width: 120pt;
    }

    .M_OkButton {
        position: fixed;
        top: 90pt;
        left: 150pt;
        height: 20pt;
        width: 50pt;
    }
</style>
