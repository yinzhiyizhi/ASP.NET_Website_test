using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class App_Ctrls_newsReader : System.Web.UI.UserControl
{
    private int _newsID;

    public int newsID
    {
        get { return _newsID; }
        set { _newsID = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        superConn scnn = new superConn("DATA.mdb");
        scnn.open();
        string _sql = "SELECT * FROM T_NEWS WHERE news_id=" + _newsID;
        OleDbDataReader dr = scnn.GetDataReader(_sql);
        if (dr.Read())
        {
            newsTitle.InnerText = dr["news_ttl"].ToString();
            newsDateTime.InnerText = ((DateTime)dr["news_date"]).ToShortTimeString();
            newsContent.InnerHtml = dr["news_content"].ToString();
        }


        scnn.close();
    }
}