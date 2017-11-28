<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="test_submenu.aspx.cs" Inherits="test_test_submenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="content_temp" ContentPlaceHolderID="cph_content_temp" runat="server">    
    <div class="submenuHolder" runat="server" id="div_submenuHolder">
        <%--<asp:BulletedList ID="BulletedList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="menu_ttl" DataValueField="menu_url" DisplayMode="HyperLink"></asp:BulletedList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [T_subMenu] WHERE ([menu_classid] = ?)">
            <SelectParameters>
                <asp:Parameter DefaultValue="4" Name="menu_classid" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>--%>
    </div>
    
    <asp:Panel ID="Panel1" runat="server"></asp:Panel>




    <%=DateTime.Now.ToFileTime()-dt_start %>

</asp:Content>
