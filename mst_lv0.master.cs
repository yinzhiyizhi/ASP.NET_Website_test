using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class mst_lv0 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //遍历数据表格submenuclass
        superConn scnn = new superConn("data.mdb");
        scnn.open();
        string _sql = "SELECT *FROM list_submenuclass";
        OleDbDataReader dr = scnn.GetDataReader(_sql);
        while (dr.Read())
        {
            TableCell td = new TableCell();
            Label lab_title = new Label();
            lab_title.Text = dr["smenu_ttl"].ToString();
            lab_title.CssClass = "submenuTitle";

            td.Controls.Add(lab_title);
            td.Controls.Add(subMenu.getSubmenu((int)dr["smenu_id"]));

            row_links.Controls.Add(td);
        }


        scnn.close();

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
