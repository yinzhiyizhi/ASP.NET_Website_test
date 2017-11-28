<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ctl_serch.ascx.cs" Inherits="App_Ctrls_ctl_serch" %>


<div class="ctl_outline" id="div_ctlOutline" runat="server" myctl="serch">

    <div class="divKey">
        <span class="title">关键字搜索：</span>
        <asp:TextBox ID="txt_key" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_key" SetFocusOnError="true" ValidationGroup="keySerch" />
        <asp:Button ID="btn_serch_key" Text="搜索" runat="server" ValidationGroup="keySerch" OnClick="btn_serch_key_Click" />
    </div>


    <div class="divCondition">
        <p class="title">颜色</p>
        <asp:CheckBoxList ID="chkList_color" runat="server" DataSourceID="ADS_COLOR" DataTextField="cl_name" DataValueField="cl_id" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>

        <asp:SqlDataSource ID="ADS_COLOR" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [List_pdColor]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="A" runat="server"></asp:SqlDataSource>


        <hr />


        <p class="title">尺寸</p>
        <asp:CheckBoxList ID="chkList_size" runat="server" DataSourceID="ADS_SIZE" DataTextField="si_size" DataValueField="si_id" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>


        <asp:SqlDataSource ID="ADS_SIZE" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [List_pdSize]"></asp:SqlDataSource>


        <hr />


        <p class="title">接口</p>
        <asp:CheckBoxList ID="chkList_port" runat="server" DataSourceID="ADS_PORT" DataTextField="pt_name" DataValueField="pt_id" RepeatDirection="Horizontal" RepeatLayout="Flow"></asp:CheckBoxList>

        <asp:SqlDataSource ID="ADS_PORT" runat="server" ConnectionString="Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\DATA.mdb;Persist Security Info=True" ProviderName="System.Data.OleDb" SelectCommand="SELECT * FROM [List_pdPort]"></asp:SqlDataSource>


        <hr />
                                                                                                                                                   
        <div class="al_r">
            <asp:Button ID="btn_serch_condition" runat="server" Text="条件搜索" OnClick="btn_serch_condition_Click" />
        </div>

    </div>

</div>


