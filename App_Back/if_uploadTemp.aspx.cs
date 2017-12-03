using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class App_Back_if_uploadTemp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_upload_Click(object sender, EventArgs e)
    {
        if(fup_1.HasFile)
        {
            HttpPostedFile _file = fup_1.PostedFile;
            //保存扩展名
            string _ext = Path.GetExtension(_file.FileName);
            //目标路径
            string _targPath = MapPath("~/App_Back/temp" + _ext);
            //保存文件
            _file.SaveAs(_targPath);

            //将文件名作为一个参数
            string _js="showPopup('temp"+_ext+"')";
            //构建一个strartupscript
            ScriptManager.RegisterStartupScript(this, this.GetType(), "", _js, true);
        }

    }
}