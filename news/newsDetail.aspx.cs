using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class news_newsDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(1));

        //获取新闻
        string _nid = (Request["nid"] == null) ? "1" : Request["nid"];
        newsReader_1.newsID = int.Parse(_nid);

        //插入最后节点
        superConn scnn = new superConn("DATA.MDB");
        scnn.open();
        string sql = "SELECT List_newsClass.* FROM T_NEWS INNER JOIN List_newsClass " +
            " ON T_NEWS.news_ncid = List_newsClass.nc_id" +
            " WHERE news_id=" + _nid;
        OleDbDataReader dr = scnn.GetDataReader(sql);
        if (dr.Read())
        {
            HyperLink lastNode = new HyperLink();
            lastNode.NavigateUrl = "~/news/newsList.aspx?ncid="+dr["nc_id"].ToString();
            lastNode.Text = dr["nc_ttl"].ToString();
            Master.FindControl("SiteMapPath1").Controls.Add(lastNode);
        }

        scnn.close();

        


    }
}