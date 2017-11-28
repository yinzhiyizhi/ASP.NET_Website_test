using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class news_newsLIst : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(1));

        //子页面标题
        superConn scnn = new superConn("DATA.MDB");
        scnn.open();
        string _ncid = (Request["ncid"] == null) ? "1" : Request["ncid"];
        string sql = "SELECT * FROM List_newsClass where nc_id=" + _ncid;
        OleDbDataReader dr = scnn.GetDataReader(sql);
        if (dr.Read())
        {
            lab_subtitle.Text = dr["nc_ttl"].ToString();
        }

        scnn.close();
    }
}