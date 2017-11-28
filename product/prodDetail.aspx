<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="prodDetail.aspx.cs" Inherits="product_prodDetail" %>

<%@ Register Src="~/App_Ctrls/ctl_Album.ascx" TagName="MyAlbum" TagPrefix="MyCtl" %>
<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="MyCtrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../App_style/css_Album.css" rel="stylesheet" />
    <script src="../App_script/js_Album.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" runat="Server">
    <MyCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" runat="Server">
    <div class="safeWidth">
        <div class="divMainImgHolder">
            <asp:Image ID="img_main" runat="server" />
        </div>

        <div class="divMainInfo">
            <asp:Label ID="lab_pdName" runat="server" Text="产品名称" CssClass="labProdName" />
            <hr />
            <asp:Table ID="tbl_param" runat="server">
                <asp:TableRow>
                    <asp:TableCell ID="td_series" ColumnSpan="2" CssClass="tdSeries"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>颜色</asp:TableCell>
                    <asp:TableCell ID="td_color" CssClass="tdContent"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>尺寸</asp:TableCell>
                    <asp:TableCell ID="td_size" CssClass="tdContent"></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>分辨率</asp:TableCell>
                    <asp:TableCell ID="td_screen" CssClass="tdContent"></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>

        <div class="clr"></div>


        <div class="divTabButtons">
            <label id="btn_feature" class="tabButton now" targid="feature">产品特性</label>
            <label id="btn_detail" class="tabButton" targid="detail">详细参数</label>
            <label id="btn_album" class="tabButton" targid="album">产品相册</label>
        </div>

        <div class="divTabs">
            <div class="divTab" tabid="feature">
                <div runat="server" class="cke_show_borders" id="div_feature"></div>
                <div runat="server" class="cke_show_borders" id="div_other"></div>
            </div>
            <div class="divTab" tabid="detail">详细参数</div>
            <div class="divTab" tabid="album">
                    <MyCtl:MyAlbum ID="prodAlbum" runat="server" MaxWidth="600" MaxHeight="250" />
            </div>
        </div>

    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".tabButton").click(function () {
                var _targ = $(this).attr("targid");
                $(".divTab").hide();
                $(".divTab[tabid='" + _targ + "']").show();
                $(".tabButton").removeclass("now");
                $(this).addClass("now");
            });
        });
    </script>



</asp:Content>

