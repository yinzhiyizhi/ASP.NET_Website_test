using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Ctrls_ctl_002 : System.Web.UI.UserControl
{
    public int Value
    {
        get { return int.Parse(txt_value.Text); }
        //修改代码，规避输入问题
        set { txt_value.Text = value.ToString(); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    //修改代码，合并按钮代码
    protected void btn_min_Click(object sender, EventArgs e)
    {
        int _v = int.Parse(txt_value.Text);
        if (_v > 0) { _v--;txt_value.Text = _v.ToString(); }
    }

    protected void btn_add_Click(object sender, EventArgs e)
    {
        int _v = int.Parse(txt_value.Text);
        if (_v < 10) { _v++; txt_value.Text = _v.ToString(); }
    }
}