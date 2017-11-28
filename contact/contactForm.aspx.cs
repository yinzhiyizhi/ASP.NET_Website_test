using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using newClasses;
using System.Net;
using System.Net.Mail;

public partial class contact_artDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(4));

        
        

    }

    protected void btn_confirm_Click(object sender, EventArgs e)
    {
        //1.写入数据库
        string _name, _phone, _content;
        string _date;
        _name = txt_name.Text;
        _phone = txt_phone.Text;
        _content = txt_msg.Text;
        _date = DateTime.Now.ToString();

        superConn scnn = new superConn("data.mdb");
        scnn.open();
        string sql = "INSERT INTO T_MESSAGE (msg_name,msg_phone,msg_date,msg_message) values " + "('" + _name + "','" + _phone + "','" + _date + "','" + _content + "')";
        OleDbCommand cmd = new OleDbCommand(sql, scnn.cnn);
        cmd.ExecuteNonQuery();

        scnn.close();

        //2.邮件发送
        string _from, _to, _subject, _body;
        _from = "mailformytest@163.com";
        _to = "173654106@qq.com";
        _subject = _name + "提交的留言[" + _date + "]";
        _body = _content;

        MailMessage _msg = new MailMessage(_from, _to, _subject, _body);

        SmtpClient _client = new SmtpClient("smtp.163.com", 25);
        _client.DeliveryMethod = SmtpDeliveryMethod.Network;
        _client.Credentials = new NetworkCredential("mailformytest@163.com", "zxcvbnm123");

        _client.Send(_msg);


        //3.mv切换

        mv_form.SetActiveView(v_success);
    }
}