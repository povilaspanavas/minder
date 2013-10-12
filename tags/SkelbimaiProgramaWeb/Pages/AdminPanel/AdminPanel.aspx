<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="Pages_AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div>
        
       
        
    </div>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar" runat="server">
    			<div id="recent-posts-2" class="widget widget_recent_entries">
                    <h4 class="widget_title">Administravimas</h4>
                    <ul>
                        <li>
				            <asp:HyperLink ID="M_AdminPanelLink" runat="server">Administravimo panelė</asp:HyperLink>
						</li>
					    <li>
				            <asp:HyperLink ID="M_UserManagementLink" runat="server">Vartotojai</asp:HyperLink>
						</li>
					    <li>
				            <asp:HyperLink ID="M_ConnectedUserLink" runat="server">Prisijungę vartotojai</asp:HyperLink>
						</li>
				    </ul>
	            </div>
                <div id="recent-comments-2" class="widget widget_recent_entries">
                    <h4 class="widget_title">Kita</h4>
                    <ul>
					    <li>
				            <asp:HyperLink ID="M_LogOutLink" runat="server">Atsijungti</asp:HyperLink>
						</li>
				    </ul>
	            </div>
</asp:Content>