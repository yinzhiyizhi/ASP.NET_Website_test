<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="contactUs.aspx.cs" Inherits="contact_contactUs" %>

<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=qwS4MwTmSyG60idGbmKRMyEvKht7YNyb"></script>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" runat="Server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" runat="Server">

    <div class="safeWidth">
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <div class="mainContent fr" runat="server" id="div_mainContent">

            <asp:Label ID="Label1" CssClass="labSubpageSubTitle" Text="联系方式" runat="server"></asp:Label><br />

            <div id="div_baiduMap" style="height: 300px; border: 1px solid silver;">
            </div>

            <div id="div_artHolder" class="cke_show_borders" style="margin-top:10px;" runat="server"></div>
            
        </div>


        <div class="clr"></div>
    </div>

    <script src="../App_script/js_BaiduMap.js"></script>
</asp:Content>

