<%@ Page Language="C#" MasterPageFile="~/Pages/MasterPage.master" AutoEventWireup="true" CodeFile="ConnectedUsersForm.aspx.cs" Inherits="Pages_AdminPanel_ConnectedUsersForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" Runat="Server">
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="M_UserGridView" runat="server" CssClass="M_UserGridView" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            ShowHeaderWhenEmpty="True" AutoGenerateColumns="True" ViewStateMode="Enabled">
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
        </asp:GridView>
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