using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using newClasses;

public partial class product_prodDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //prodDetail.aspx?pdid=?
        int _pdid = 1;
        try { _pdid = int.Parse(Request["pdid"].ToString()); }
        catch { }


        MyProduct pd1 = new MyProduct(_pdid);

        img_main.ImageUrl = pd1.mainImgUrl;
        lab_pdName.Text = pd1.ProductName;

        td_series.Text = pd1.SeriesName;
        td_color.Text = pd1.ColorName;
        td_size.Text = pd1.SizeName;
        td_screen.Text = pd1.Screen;


        div_feature.InnerHtml = pd1.Feature;
        div_other.InnerHtml = pd1.Other;

        prodAlbum.ImgLinks = pd1.AlbumImgLinks;
        



        //插入最后节点
        HyperLink lastNode = new HyperLink();
        lastNode.NavigateUrl = "~/product/prodDetail.aspx?pdid=" + _pdid;
        lastNode.Text = lab_pdName.Text+"详细情况";
        Master.FindControl("SiteMapPath1").Controls.Add(lastNode);
    }
}