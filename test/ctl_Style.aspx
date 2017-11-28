<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ctl_Style.aspx.cs" Inherits="test_ctl_Style" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../App_style/CSS_DEFAULT.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            子菜单样式：
        <div class="submenuHolder">
            <asp:BulletedList ID="BulletedList1" runat="server">
                <asp:ListItem Value="菜单项1"></asp:ListItem>
                <asp:ListItem Value="菜单项2"></asp:ListItem>
                <asp:ListItem>菜单项3</asp:ListItem>
                <asp:ListItem>菜单项4</asp:ListItem>
            </asp:BulletedList>
        </div>
        </div>

        <br />

        子页大标题样式2：<br />
        <asp:Label ID="lbl_subpageTitle" runat="server" Text="子页大标题" CssClass="labSubpageTitle" />

        <br />

        子页子标题：label实现：<br />
        <asp:Label ID="Label1" runat="server" Text="子页子标题" CssClass="labSubpageSubTitle"></asp:Label>

        <br />

        新闻列表项样式：
        <a href="www.163.com">
            <div class="newsListItem">
                <img src="../_uploadImgs/newsTmp.gif" alt="" />
                <div class="divText">
                    <h4>新闻标题</h4>
                    <span>时间</span>
                    <p>内容</p>
                </div>
            </div>
            <div class="clr"></div>
        </a>





    </form>
</body>
</html>
