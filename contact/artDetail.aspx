<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="artDetail.aspx.cs" Inherits="contact_artDetail" %>
<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" Runat="Server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" Runat="Server">
    <div class="safeWidth">
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <div class="mainContent fr" runat="server" id="div_mainContent">
            
        </div>

        <div class="clr"></div>
    </div>
</asp:Content>

