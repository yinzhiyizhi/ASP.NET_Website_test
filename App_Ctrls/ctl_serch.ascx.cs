using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Ctrls_ctl_serch : System.Web.UI.UserControl
{
    public enum SerchPanelSkin { skin1,skin_home}

    private SerchPanelSkin _skinName = SerchPanelSkin.skin1;

    //private string _skinName = "skin1";
    public SerchPanelSkin SkinName
    {
        set { _skinName = value; }
        get { return _skinName; }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        div_ctlOutline.Attributes.Add("CtlSkin", _skinName.ToString());
    }

    protected void btn_serch_key_Click(object sender, EventArgs e)
    {
        string _sql = " SELECT T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img) ";
        string _key = txt_key.Text;
        string _where = " WHERE pd_name LIKE '%"+_key+"%' OR pd_feature LIKE '%"+_key+"%' ";

        Session["sql_serch"] = _sql + _where;
        Response.Redirect("~/product/prodList.aspx?type=serch");

    }

    protected void btn_serch_condition_Click(object sender, EventArgs e)
    {
        //string _where = " WHERE pd_id>0 ";
        string _sql = "SELECT T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img) ";


        ////color
        //int i_color = chkList_color.SelectedIndex;//如果用户不选择，返回-1，如果用户有选择，最小从0开始
        //string s_color = "";//获取选中项构成的列表

        //if (i_color >= 0)
        //{
        //    foreach(ListItem li in chkList_color.Items)
        //    {
        //        s_color += li.Selected ? li.Value + "," : "";
        //    }

        //    _where += " AND pd_clid in (" + s_color + ") ";
        //}


        ////size
        //int i_size = chkList_size.SelectedIndex;
        //string s_size = "";

        //if (i_size>= 0)
        //{
        //    foreach(ListItem li in chkList_size.Items)
        //    {
        //        s_size+= li.Selected ? li.Value + "," : "";
        //    }

        //    _where += " AND pd_szid in (" + s_size + ") ";
        //}


        List<string> _wList = new List<string>();//声明一个空的字符串列表

        int i_color = chkList_color.SelectedIndex;//如果用户不选择，返回-1，如果用户有选择，最小从0开始
        string s_color = "";//获取选中项构成的列表

        if (i_color >= 0)
        {
            foreach (ListItem li in chkList_color.Items)
            {
                s_color += li.Selected ? li.Value + "," : "";
            }
            _wList.Add(" pd_clid in (" + s_color + ") ");
        }


        int i_size = chkList_size.SelectedIndex;
        string s_size = "";

        if (i_size >= 0)
        {
            foreach (ListItem li in chkList_size.Items)
            {
                s_size += li.Selected ? li.Value + "," : "";
            }
            _wList.Add(" pd_szid in(" + s_size + ") ");
        }


        int i_port = chkList_port.SelectedIndex;
        string s_port = "";
        if (i_port >= 0)
        {
            foreach(ListItem li in chkList_port.Items)
            {
                s_port += li.Selected ? li.Value + "," : "";
            }
            string _s = " (pd_pt1 in (" + s_port + ") OR pd_pt2 in (" + s_port + ") OR pd_pt3 in (" + s_port + ") OR pd_pt4 in (" + s_port + ")) ";
            _wList.Add(_s);
        }

        string _w2 = " WHERE ";
        Boolean _first = true;
        foreach(string _s in _wList)
        {
            _w2 += (_first ? "" : " AND ") + _s;
            _first = false;
        }



        Session["sql_serch"] = _sql + _w2;
        //Response.Write(_sql + _w2);
        Response.Redirect("~/product/prodList.aspx?type=serch");


    }
}