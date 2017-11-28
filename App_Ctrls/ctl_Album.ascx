<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_Album.ascx.cs" Inherits="App_Ctrls_ctl_Album" %>


<div id="div_outerLine" runat="server" myctl="Album">
    <div style="display: none;">
        <asp:TextBox ID="txt_Count" runat="server" CssClass="txtCount" />
        <asp:TextBox ID="txt_Now" runat="server" CssClass="txtNow" />
    </div>


    <div id="div_ImgCtlHolder" runat="server" class="imgCtlHolder">
        <div class="ctlPrevNext" id="div_CtlHolder" runat="server">
            <div class="btnPrev"></div>
            <div class="btnNext"></div>
        </div>

        <div class="imgHolder" id="div_ImgHolder" runat="server"></div>

    </div>


    <div id="div_ShortCut" runat="server" class="divShortCutHolder"></div>
    <div class="divShortCutHolder_hide" style="display: none;"></div>

</div>

