using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Ctrls_testCtrl_001 : System.Web.UI.UserControl
{
    public string Title
    {
        get { return Label1.Text; }
        set { Label1.Text = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}