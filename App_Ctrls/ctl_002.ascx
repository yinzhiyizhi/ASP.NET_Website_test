<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_002.ascx.cs" Inherits="App_Ctrls_ctl_002" %>

<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>


<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Button ID="btn_min" runat="server" Text="-" OnClick="btn_min_Click" />
        <asp:TextBox ID="txt_value" runat="server" Text="0" />
        <asp:Button ID="btn_add" runat="server" Text="+" OnClick="btn_add_Click" />
    </ContentTemplate>
</asp:UpdatePanel>

