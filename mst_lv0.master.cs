using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mst_lv0 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void menuPreRender(object sender,EventArgs e)
    {
        try
        {
            MenuItem mi = menu_mainNav.FindItem(SiteMap.CurrentNode.ResourceKey);
                mi.Selected = true;
            lbl_subpageTitle.Text = mi.Text;
        }
        catch { }
    }
}
