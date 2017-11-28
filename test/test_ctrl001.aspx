<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="test_ctrl001.aspx.cs" Inherits="test_test_ctrl001" %>

<%@ Register Src="~/App_Ctrls/testCtrl_001.ascx" TagName="myctl001" TagPrefix="myCtrls" %>
<%@ Register Src="~/App_Ctrls/ctl_002.ascx" TagName="myctl002" TagPrefix="myCtrls" %>
<%@ Register Src="~/App_Ctrls/newsReader.ascx" TagName="newsReader" TagPrefix="myCtrls" %>
<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content_temp" runat="Server">
    <myCtrls:myctl001 ID="ctl001" runat="server" Title="自定义的标题" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div>
        <myCtrls:myctl002 ID="ct2" runat="server" />
    </div>

    <div>
        <myCtrls:myctl002 ID="Myctl1" runat="server" />
    </div>

    <div>
        <myCtrls:myctl002 ID="Myctl2" runat="server" />
    </div>

    <div>
        <myCtrls:newsReader ID="reader_01" runat="server" newsID="2" />
    </div>

    <div>
        <myCtrls:subPageImg ID="spimg1" runat="server" imgID="1" />
    </div>
</asp:Content>

