using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact_contactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(4));

        //获取新闻
        //string _aid = (Request["aid"] == null) ? "1" : Request["aid"];
        artItem myArt = new artItem(4);
        //div_mainContent.Controls.Add(myArt.getShowPanel());
        div_artHolder.InnerHtml = myArt.artContent;

        //插入最后节点
        //Master.FindControl("SiteMapPath1").Controls.Add(myArt.getLastNode());
    }
}