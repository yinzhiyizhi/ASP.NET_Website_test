using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class product_prodList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //子菜单的插入
        submenuHolder.Controls.Add(subMenu.getSubmenu(5));

        //SELECT T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img)
        //访问地址时，url有3中可能：
        //1.prodList.aspx
        //2.prodList.aspx?seid=1
        //3.prodList.aspx?type=serch  这表示通过搜索来访问

        string _type = Request["type"];
        string _seid = Request["seid"] == null ? "1" : Request["seid"];
        string _sqlDefault = "SELECT T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img) where pd_seid=" + _seid;
        Label lab_LastNode = new Label();


        if (_type == "serch")
        {
            _sqlDefault = Session["sql_serch"] == null ? _sqlDefault : Session["sql_serch"].ToString();
            lab_LastNode.Text = "搜索结果";
        }
        else
        {
            superConn scnn = new superConn("data.mdb");
            scnn.open();
            string _sql = "SELECT * FROM LIST_PDSERIES WHERE se_id=" + _seid;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                lab_LastNode.Text = dr["se_name"].ToString() + "产品列表";
            }

            scnn.close();
        }

        //SQL
        SqlDataSource1.SelectCommand = _sqlDefault;
        //NODE
        Master.FindControl("SiteMapPath1").Controls.Add(lab_LastNode);


    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["sql_serch"] = "SELECT T_Product.pd_id, T_Product.pd_name, T_IMGS.img_url FROM (T_IMGS INNER JOIN T_Product ON T_IMGS.img_id = T_Product.pd_img) " + "WHERE pd_clid=4";
        Response.Redirect("~/product/prodList.aspx?type=serch");
    }
}