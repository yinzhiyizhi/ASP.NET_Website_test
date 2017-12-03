using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using newClasses;
using System.Data.OleDb;

public partial class App_Back_b_albumHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_addNew_Click(object sender, EventArgs e)
    {
        string _filename = txt_temp.Text;
        string _ext = Path.GetExtension(_filename);
        string _imgurl = "~/_uploadImgs/" + DateTime.Now.ToFileTime().ToString() + _ext;
        string _nav = txt_nav.Text;
        string _enable = chk_enable.Checked ? "true" : "false";

        File.Move(MapPath(_filename), MapPath(_imgurl));

        superConn scnn = new superConn("data.mdb");
        scnn.open();
        string _sql = "INSERT INTO T_albumHome (abhome_imgurl,abhome_nav,abhome_enable) values ('"+_imgurl+"','"+_nav+"',"+_enable+")";
        OleDbCommand cmd = new OleDbCommand(_sql, scnn.cnn);
        cmd.ExecuteNonQuery();

        ScriptManager.RegisterStartupScript(this, this.GetType(), "", "location.reload();", true);

        scnn.close();
    }
}