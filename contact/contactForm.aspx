<%@ Page Title="" Language="C#" MasterPageFile="~/mst_lv0.master" AutoEventWireup="true" CodeFile="contactForm.aspx.cs" Inherits="contact_artDetail" EnableEventValidation="false" %>

<%@ Register Src="~/App_Ctrls/subPageImg.ascx" TagName="subPageImg" TagPrefix="myCtrls" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cph_bigimg" runat="Server">
    <myCtrls:subPageImg ID="spimg1" runat="server" imgID="4" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="cph_content_temp" runat="Server">




    <div class="safeWidth">
        <div class="submenuHolder fl" runat="server" id="submenuHolder"></div>

        <%--表单内容--%>

        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>

        <div class="mainContent fr divSubmitForm" runat="server" id="div_mainContent">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:MultiView ID="mv_form" runat="server" ActiveViewIndex="0">
                <asp:View ID="v_input" runat="server">
                    
                        <p>
                            名字:           
                                <br />
                            <asp:TextBox ID="txt_name" runat="server" />

                        </p>
                        <p>
                            联系电话：<br />
                            <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
                        </p>
                        <p>
                            留言：<br />
                            <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine" Rows="7" Columns="60"></asp:TextBox>
                        </p>
                        <hr />
                        <asp:Button ID="btn_confirm" runat="server" Text="确认" CssClass="btn" OnClick="btn_confirm_Click" />
                        <input type="reset" value="重新填写" class="btn" />
                   
                </asp:View>

                <asp:View ID="v_success" runat="server">
                    <div class="divInfo_success">
                        <h4>您的信息已成功提交，我们会尽快处理您的留言。</h4>
                        <a href="contactForm.aspx">[返回]</a>
                    </div>
                </asp:View>

            </asp:MultiView>
            </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <div class="clr"></div>
    </div>
</asp:Content>

