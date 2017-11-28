<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="newsDetail.aspx.cs" Inherits="news_newsDetail" %>
<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>
<%@ Register Src="~/App_Ctrls/newsReader.ascx" TagPrefix="myCtrls" TagName="newsReader" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="content_img" ContentPlaceHolderID="cph_bigimg" runat="server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="cph_content_temp" Runat="Server">
    <div class="safeWidth">
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <div class="mainContent fr">
            <myCtrls:newsReader ID="newsReader_1" runat="server" newsID="1" />
        </div>

        <div class="clr"></div>
    </div>

</asp:Content>

