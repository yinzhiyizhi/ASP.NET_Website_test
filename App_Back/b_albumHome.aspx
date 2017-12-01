<%@ Page Language="C#" AutoEventWireup="true" CodeFile="b_albumHome.aspx.cs" Inherits="App_Back_b_albumHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>首页相册图片管理</h2>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView ID="lv_albumHome" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="abhome_id">



                </asp:ListView>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [T_albumHome] WHERE [abhome_id] = ?" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [T_albumHome]" UpdateCommand="UPDATE [T_albumHome] SET [abhome_imgurl] = ?, [abhome_nav] = ?, [abhome_enable] = ? WHERE [abhome_id] = ?">
                    <DeleteParameters>
                        <asp:Parameter Name="abhome_id" Type="Int32" />
                    </DeleteParameters>
                   
                    <UpdateParameters>
                        <asp:Parameter Name="abhome_imgurl" Type="String" />
                        <asp:Parameter Name="abhome_nav" Type="String" />
                        <asp:Parameter Name="abhome_enable" Type="Boolean" />
                        <asp:Parameter Name="abhome_id" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </ContentTemplate>

        </asp:UpdatePanel>

    
    </div>
    </form>
</body>
</html>
