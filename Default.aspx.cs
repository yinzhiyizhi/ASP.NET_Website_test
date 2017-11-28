using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //1.相册控件图片源
        superConn scnn = new superConn("data.mdb");
        scnn.open();
        string _sql = "SELECT * FROM T_albumHome WHERE abHome_enable=true";
        OleDbDataReader dr = scnn.GetDataReader(_sql);
        List<HyperLink> _links = new List<HyperLink>();
        HyperLink _l;
        while (dr.Read())
        {
            _l = new HyperLink();
            _l.ImageUrl = dr["abhome_imgurl"].ToString();
            _l.NavigateUrl = dr["abhome_nav"].ToString();
            _links.Add(_l);
        }

        scnn.close();
        album_home.ImgLinks = _links;



        //2.隐藏母版页内容
        Master.FindControl("divmst_sitemapPath").Visible = false;
        Master.FindControl("lbl_subpageTitle").Visible = false;



    }
}