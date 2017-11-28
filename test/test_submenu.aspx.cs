using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_test_submenu : System.Web.UI.Page
{
    public long dt_start;
    protected void Page_Init(object sender,EventArgs e)
    {
        dt_start = DateTime.Now.ToFileTime();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        div_submenuHolder.Controls.Add(subMenu.getSubmenu(4));

    }
}