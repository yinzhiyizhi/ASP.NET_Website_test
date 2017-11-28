using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class App_Ctrls_subPageImg : System.Web.UI.UserControl
{
    private string _url;
    private int _imgID;

    public int imgID
    {
        set { _imgID = value; }
        get { return _imgID; }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        superConn scnn = new superConn("DATA.MDB");
        scnn.open();
        string sql = "SELECT * FROM T_IMGS WHERE img_id=" + _imgID;
        OleDbDataReader dr = scnn.GetDataReader(sql);
        if (dr.Read()) {
            Image1.ImageUrl = dr["img_url"].ToString();
        }
        scnn.close();
    }
}