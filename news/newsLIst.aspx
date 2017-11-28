<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="newsLIst.aspx.cs" Inherits="news_newsLIst" %>

<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>


<asp:Content ID="content_img" ContentPlaceHolderID="cph_bigimg" runat="server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="cph_content_temp" runat="Server">
    <div class="safeWidth">
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <div class="mainContent fr">
            
            <asp:Label ID="lab_subtitle" runat="server" Text="子页子标题" CssClass="labSubpageSubTitle"></asp:Label>
            <asp:ListView ID="ListView1" runat="server" DataSourceID="ads_listview" ItemPlaceholderID="itemHolder">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="itemHolder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>

                <ItemTemplate>
                    <a href='newsDetail.aspx?nid=<%#Eval("news_id") %>'>
                        <div class="newsListItem">
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("img_url") %>'/>
                            
                            <div class="divText">
                                <h4><%#Eval("news_ttl") %></h4>
                                <span><%#Eval("news_date","{0:D}") %></span>
                                <p><%#Eval("news_guide") %>......</p>
                            </div>
                        </div>
                        <div class="clr"></div>
                    </a>

                </ItemTemplate>
            </asp:ListView>
            <asp:SqlDataSource ID="ads_listview" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT T_IMGS.*, T_NEWS.* FROM (T_IMGS INNER JOIN T_NEWS ON T_IMGS.img_id = T_NEWS.news_imgTitle) WHERE news_ncid=?">
                <SelectParameters>
                    <asp:QueryStringParameter Name="news_ncid" QueryStringField="ncid" Type="Int32" DefaultValue="1" />
                </SelectParameters>
            </asp:SqlDataSource>
            <%--分页控件--%>
            <div class="divPager">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowNextPageButton="false"/>
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="true" ShowPreviousPageButton="false"/>
                    </Fields>
                </asp:DataPager>
            </div>

        </div>

        <div class="clr"></div>
    </div>

</asp:Content>

