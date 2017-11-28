<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="prodList.aspx.cs" Inherits="product_prodList" %>
<%@ Register Src="~/App_ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>
<%@ Register Src="~/App_Ctrls/ctl_serch.ascx" TagName="serchPanel" TagPrefix="myCtrls"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../App_style/ctl_serch.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" runat="Server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />

    <div class="safeWidth">
        <myCtrls:serchPanel runat="server" ID="serch1" />
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" runat="Server">

    <div class="safeWidth">

        <%--左边，子菜单--%>
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <%--右边，产品列表 + 搜索--%>
        <div class="mainContent">
            <div class="lv_prodList">

                <asp:ListView ID="ListView1" runat="server" GroupPlaceholderID="groupHolder" ItemPlaceholderID="itemHolder" GroupItemCount="3" DataSourceID="SqlDataSource1">

                    <%--主模板--%>
                    <LayoutTemplate>
                        <div runat="server" id="groupHolder"></div>
                        <div class="clr"></div>
                    </LayoutTemplate>

                    <%--分组模板--%>
                    <GroupTemplate>
                        <div runat="server" id="itemHolder"></div>
                    </GroupTemplate>

                    <%--组与组的分割--%>
                    <GroupSeparatorTemplate>
                        <hr class="clr" />
                    </GroupSeparatorTemplate>

                    <%--数据项的模板--%>
                    <ItemTemplate>
                        <a href='<%#Eval("pd_id","prodDetail.aspx?pdid={0}") %>'>
                            <asp:Image ImageUrl='<%#Eval("img_url") %>' runat="server" />
                            <asp:Label runat="server" Text='<%#Eval("pd_name") %>' />
                        </a>
                    </ItemTemplate>

                </asp:ListView>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand=""></asp:SqlDataSource>

            </div>

            <%--分页控件--%>
            <div class="divPager">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="9">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="true" ShowPreviousPageButton="false" />
                    </Fields>
                </asp:DataPager>
            </div>

        </div>

        <div class="clr"></div>

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" style="height: 21px" />

    </div>

</asp:Content>

