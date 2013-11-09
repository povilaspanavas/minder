<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" EnableViewState="false"
    ValidateRequest="false" CodeBehind="Default.aspx.cs" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v13.1" Namespace="DevExpress.ExpressApp.Web.Templates"
    TagPrefix="cc3" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v13.1" Namespace="DevExpress.ExpressApp.Web.Controls"
    TagPrefix="cc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    
    <meta http-equiv="Expires" content="0" />
</head>
<body class="VerticalTemplate">
    <form id="form2" runat="server">
    <cc3:XafUpdatePanel ID="UPPopupWindowControl" runat="server">
        <cc4:XafPopupWindowControl runat="server" ID="PopupWindowControl" />
    </cc3:XafUpdatePanel>
    <cc4:ASPxProgressControl ID="ProgressControl" runat="server" />
    <div runat="server" id="Content" />
    </form>

    <script type="text/javascript">
        var timeout = setTimeout("ReloadIfNeeded(60000);", 60000);
        function ReloadIfNeeded(interval) {
            if (document.URL.indexOf("SKAdvertNew_ListView") >= 0)
                location.reload(true);
            else 
                timeout = setTimeout("ReloadIfNeeded(" + interval + ");", interval);
        }
    </script>

<audio id="beep" src="Sounds/beep.wav" preload="auto"></audio>    
<script type="text/javascript">
    function PlayBeep() {
        document.getElementById('beep').play();
    }
</script>
<!--<embed src="beep.wav" autostart=true width=0 height=0 name="sound1" enablejavascript="true"> -->
</body>
</html>
