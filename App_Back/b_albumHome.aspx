<%@ Page Language="C#" AutoEventWireup="true" CodeFile="b_albumHome.aspx.cs" Inherits="App_Back_b_albumHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_style/CSS_DEFAULT.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <h2>首页相册图片管理</h2>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ListView ID="lv_albumHome" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="abhome_id" ItemPlaceholderID="itemHolder">
                    <LayoutTemplate>
                        <table style="border:1px solid silver;">
                            <thead>
                                <td style="width:250px;">图片预览</td>
                                <td style="width:300px;">链接地址</td>
                                <td>有效显示</td>
                                <td></td>
                            </thead>
                            <asp:PlaceHolder ID="itemHolder" runat="server"></asp:PlaceHolder>
                        </table>
                    </LayoutTemplate>


                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("abhome_imgurl") %>' Width="100%"/>
                            </td>
                            <td>
                                <%#Eval("abhome_nav") %>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBox1" runat="server" Enabled="false" Checked='<%#Eval("abhome_enable") %>'/>
                            </td>
                            <td>
                                <asp:Button ID="btn_delete" runat="server" Text="删除图片" CommandName="Delete" OnClientClick="return confirm('确认删除么？')"/>
                                <asp:Button ID="btn_edit" runat="server" Text="修改图片信息" CommandName="Edit"/>
                            </td>
                        </tr>

                    </ItemTemplate>

                    
                    <EditItemTemplate>
                        <tr>
                            <td>
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("abhome_imgurl") %>' Width="100%"/>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_e_nav" runat="server"  Text='<%#Bind("abhome_nav") %>' />
                            </td>
                            <td>
                                <asp:CheckBox ID="cke_e_enable" runat="server"  Checked='<%#Bind("abhome_enable") %>'/>
                            </td>
                            <td>
                                <asp:Button ID="btn_update" runat="server" Text="保存修改" CommandName="Update"/>
                                <asp:Button ID="btn_cancel" runat="server" Text="取消" CommandName="Cancel"/>
                            </td>
                        </tr>

                    </EditItemTemplate>


                </asp:ListView>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" DeleteCommand="DELETE FROM [T_albumHome] WHERE [abhome_id] = ?" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [T_albumHome]" UpdateCommand="UPDATE [T_albumHome] SET  [abhome_nav] = ?, [abhome_enable] = ? WHERE [abhome_id] = ?">
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


        <iframe src="if_uploadTemp.aspx" style="border:none;margin:5px;"></iframe>
        <asp:TextBox ID="txt_temp" runat="server"></asp:TextBox>
        <asp:Button ID="btn_showMpop" runat="server" Text="显示模式弹出层" />
        <ajaxToolkit:ModalPopupExtender ID="m1" runat="server" PopupControlID="div_Mpop" TargetControlID="btn_showMpop" CancelControlID="btn_cancel" BackgroundCssClass="mpopBack">

        </ajaxToolkit:ModalPopupExtender>



        <div id="div_Mpop" runat="server">
            <div class="al_c" style="min-height:300px;">
                <img style="max-width:300px;margin:0px auto;" src="" alt="" id="img_preview" runat="server" />
            </div>
            <hr />

            <p>
                链接地址：
                <asp:TextBox ID="txt_nav" runat="server" Width="300"></asp:TextBox>
            </p>

            <p>
                有效显示：
                <asp:CheckBox ID="chk_enable" runat="server" />
            </p>

            <p>
                <asp:Button ID="btn_addNew" runat="server" Text="添加" />

                <asp:Button ID="btn_cancel" runat="server" Text="取消" />
            </p>

        </div>
    
    </div>
    </form>
</body>
</html>
