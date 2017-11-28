using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class contact_artDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(4));

        //获取新闻
        string _aid = (Request["aid"] == null) ? "1" : Request["aid"];
        artItem myArt = new artItem(int.Parse(_aid));
        div_mainContent.Controls.Add(myArt.getShowPanel());

        //插入最后节点
        Master.FindControl("SiteMapPath1").Controls.Add(myArt.getLastNode());
    }
}