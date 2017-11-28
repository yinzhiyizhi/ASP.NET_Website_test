using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

public partial class test_test_mailSend : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string _body = "<h3 style='color:red;'>" + TextBox1.Text + "</h3>";

        MailMessage _msg = new MailMessage("zxw51_test_1@163.com", "173654106@qq.com", "测试邮件发送", _body);
        _msg.IsBodyHtml = true;

        SmtpClient _client = new SmtpClient("smtp.163.com", 25);
        _client.DeliveryMethod = SmtpDeliveryMethod.Network;
        _client.Credentials = new NetworkCredential("zxw51_test_1", "765432");

        _client.Send(_msg);
    }
}