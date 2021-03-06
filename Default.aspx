﻿<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/App_Ctrls/ctl_Album.ascx" TagName="myAlbum" TagPrefix="myCtl" %>
<%@ Register Src="~/App_Ctrls/ctl_serch.ascx" TagName="SerchPanel" TagPrefix="myCtl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="App_style/css_Album.css" rel="stylesheet" />
    <link href="App_style/ctl_serch.css" rel="stylesheet" />
    <script src="App_script/js_Album.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" runat="Server">
    <div class="divHomeAlbumHolder">
        <myCtl:myAlbum ID="album_home" MaxWidth="760" MaxHeight="280" ShowShortCut="false" AutoRoll="true" runat="server" />
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" runat="Server">
    <div class="safeWidth">
        <%--推送产品的listview--%>
        <asp:ListView ID="lv_pushProd" runat="server" DataSourceID="ads_pushProd" ItemPlaceholderID="itemHolder">
            <LayoutTemplate>
                <div class="divPushProds">
                    <asp:PlaceHolder runat="server" ID="itemHolder"></asp:PlaceHolder>
                    <div class="clr"></div>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <a class="aPushProdItem" href='<%#Eval("pd_id","product/prodDetail.aspx?pdid={0}") %>'>
                    <asp:Image ImageUrl='<%#Eval("img_url") %>' runat="server" />
                    <p>
                        <asp:Label runat="server" Text='<%#Eval("pd_name") %>'></asp:Label></p>
                </a>
            </ItemTemplate>
        </asp:ListView>

        <asp:SqlDataSource ID="ads_pushProd" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT TOP 4 T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img) WHERE (T_Product.pd_push = true)"></asp:SqlDataSource>


        <%--产品搜索栏--%>
        <myCtl:SerchPanel ID="serch_home" runat="server" SkinName="skin_home" />



        <div id="news_and_video">
            <div id="div_pushNews">
                <asp:HyperLink ID="HyperLink1" ImageUrl="~/App_imgs/back_homeNewsTitle.jpg" NavigateUrl="~/news/" ToolTip="更多新闻" runat="server"></asp:HyperLink>

                <asp:ListView ID="lv_pushNews" runat="server" DataSourceID="ads_pushNews" ItemPlaceholderID="itemHolder">

                    <LayoutTemplate>
                        <div>
                            <asp:PlaceHolder ID="itemHolder" runat="server"></asp:PlaceHolder>
                        </div>
                    </LayoutTemplate>

                    <ItemTemplate>
                        <a class="pushnewsItem" href='<%#Eval("news_id","news/newsDetail.aspx?nid={0}") %>' title='<%#Eval("news_ttl") %>'>
                            <p style="float: left; width: 280px;"><%#Eval("news_ttl") %></p>
                            <p style="float: right;"><%#Eval("news_date","{0:D}") %></p>
                            <div class="clr"></div>
                        </a>
                    </ItemTemplate>



                </asp:ListView>
                <asp:SqlDataSource ID="ads_pushNews" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT TOP 5 news_id, news_ttl, news_date FROM T_NEWS WHERE (news_enable = true) AND (news_push = true) ORDER BY news_order DESC, news_id"></asp:SqlDataSource>
            </div>


            <div id="div_video">
                <object type="application/x-shockwave-flash" id="flash_video" width="360" height="240" data="video/exr.swf"></object>
            </div>

            <div class="clr"></div>


        </div>


    </div>

</asp:Content>

