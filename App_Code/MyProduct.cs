using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using newClasses;

/// <summary>
/// Summary description for MyProduct
/// </summary>
public class MyProduct
{
    private int _id = 0;
    private int _seid = 0; private string _seName = "";     //产品系列ID
    private int _clid = 0; private string _ColorName = "";  //产品颜色
    private int _szid = 0; private string _SizeName = "";   //产品尺寸
    private string _name = "";      //产品名称
    private int _bandwidth = 0;     //产品带宽
    private int _rtime = 0;         //产品响应时间
    private int _lms = 0;           //产品亮度
    private string _screen = "";    //产品分辨率
    private string _feature = "";   //产品特性   副文本字段
    private string _other = "";     //产品其它特性   副文本字段

    //产品四个接口ID
    private int _pt1 = 0; private int _pt2 = 0; private int _pt3 = 0; private int _pt4 = 0;
    //产品四个接口对应的名称
    private string _pt1Name = ""; private string _pt2Name = "";
    private string _pt3Name = ""; private string _pt4Name = "";
    //产品主图片的ID和URL
    private int _img = 0; private string _mainImgUrl = "";
    //产品相册的图片列表
    private string _album = "";

    //声明相册列表的自由变量
    private List<HyperLink> _albumLinks = new List<HyperLink>();


    private List<HyperLink> getAlbumLinks(string __album)
    {
        List<HyperLink> __links = new List<HyperLink>();
        superConn scnn2 = new superConn("data.mdb");
        scnn2.open();
        string _sql2 = "SELECT * FROM T_IMGS WHERE img_id in (" + __album + ")";
        OleDbDataReader dr2 = scnn2.GetDataReader(_sql2);
        HyperLink __link;
        while (dr2.Read())
        {
            __link = new HyperLink();
            __link.ImageUrl = dr2["img_url"].ToString();
            __link.NavigateUrl = dr2["img_nav"].ToString();
            __links.Add(__link);
        }

        scnn2.close();
        return __links;
    }



    //是否推送
    private Boolean _push = false;
    public Boolean Push
    {
        set { _push = value; }
        get { return _push; }
    }








    /// <summary>
    /// 产品ID值，只读
    /// </summary>
    public int prodID
    {
        get { return _id; }
    }



    /// <summary>
    /// 产品系列ID，自动设置产品系列名称
    /// </summary>
    public int SeriesID
    {
        set
        {
            _seid = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdSeries WHERE se_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _seName = dr["se_name"].ToString();
            }

            scnn.close();
        }
        get { return _seid; }
    }


    /// <summary>
    /// 产品系列ID，只读属性，更改此属性请通过SeriesID
    /// </summary>
    public string SeriesName
    {
        get { return _seName; }
    }





    /// <summary>
    /// 产品颜色ID，自动设置产品颜色名称
    /// </summary>
    public int ColorID
    {
        set
        {
            _clid = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdColor WHERE cl_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _ColorName = dr["cl_name"].ToString();
            }

            scnn.close();
        }
        get { return _clid; }
    }


    /// <summary>
    /// 产品颜色，只读属性，更改此属性请通过ColorID
    /// </summary>
    public string ColorName
    {
        get { return _ColorName; }
    }





    /// <summary>
    /// 产品尺寸ID，自动设置产品尺寸名称
    /// </summary>
    public int SizeID
    {
        set
        {
            _szid = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdSize WHERE si_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _SizeName = dr["si_size"].ToString();
            }

            scnn.close();
        }
        get { return _szid; }
    }


    /// <summary>
    /// 产品尺寸，只读属性，更改此属性请通过SizeID
    /// </summary>
    public string SizeName
    {
        get { return _SizeName; }
    }




    /// <summary>
    /// 产品名称，直接设置
    /// </summary>
    public string ProductName
    {
        set { _name = value; }
        get { return _name; }
    }



    /// <summary>
    /// 显示器带宽，直接设置
    /// </summary>
    public int BandWidth
    {
        set { _bandwidth = value; }
        get { return _bandwidth; }
    }



    /// <summary>
    /// 响应时间，直接设置
    /// </summary>
    public int Rtime
    {
        set { _rtime = value; }
        get { return _rtime; }
    }



    /// <summary>
    /// 亮度，直接设置
    /// </summary>
    public int Lms
    {
        set { _lms = value; }
        get { return _lms; }
    }



    /// <summary>
    /// 产品分辨率，直接设置
    /// </summary>
    public string Screen
    {
        set { _screen = value; }
        get { return _screen; }
    }



    /// <summary>
    /// 产品特性，直接设置
    /// </summary>
    public string Feature
    {
        set { _feature = value; }
        get { return _feature; }
    }



    /// <summary>
    /// 产品其它特性，直接设置
    /// </summary>
    public string Other
    {
        set { _other = value; }
        get { return _other; }
    }




    /// <summary>
    /// 产品接口port01
    /// </summary>
    public int Port1_ID
    {
        set
        {
            _pt1 = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdPort WHERE pt_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _pt1Name = dr["pt_name"].ToString();
            }

            scnn.close();
        }
        get { return _pt1; }
    }


    /// <summary>
    /// 产品接口port1，只读属性，更改此属性请通过Port1_ID
    /// </summary>
    public string Port1_Name
    {
        get { return _pt1Name; }
    }



    /// <summary>
    /// 产品接口port02
    /// </summary>
    public int Port2_ID
    {
        set
        {
            _pt2 = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdPort WHERE pt_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _pt2Name = dr["pt_name"].ToString();
            }

            scnn.close();
        }
        get { return _pt2; }
    }


    /// <summary>
    /// 产品接口port2，只读属性，更改此属性请通过Port2_ID
    /// </summary>
    public string Port2_Name
    {
        get { return _pt2Name; }
    }



    /// <summary>
    /// 产品接口port03
    /// </summary>
    public int Port3_ID
    {
        set
        {
            _pt3 = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdPort WHERE pt_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _pt3Name = dr["pt_name"].ToString();
            }

            scnn.close();
        }
        get { return _pt3; }
    }


    /// <summary>
    /// 产品接口port3，只读属性，更改此属性请通过Port3_ID
    /// </summary>
    public string Port3_Name
    {
        get { return _pt3Name; }
    }



    /// <summary>
    /// 产品接口port04
    /// </summary>
    public int Port4_ID
    {
        set
        {
            _pt4 = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM List_pdPort WHERE pt_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _pt4Name = dr["pt_name"].ToString();
            }

            scnn.close();
        }
        get { return _pt4; }
    }


    /// <summary>
    /// 产品接口port4，只读属性，更改此属性请通过Port4_ID
    /// </summary>
    public string Port4_Name
    {
        get { return _pt4Name; }
    }



    /// <summary>
    /// 设置主图片的ID
    /// </summary>
    public int mainImgID
    {
        set
        {
            _img = value;
            superConn scnn = new superConn("DATA.MDB");
            scnn.open();
            string _sql = "SELECT * FROM T_IMGS WHERE img_id=" + value;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                _mainImgUrl = dr["img_url"].ToString();
            }
            scnn.close();
        }
        get { return _img; }
    }

    /// <summary>
    /// 主图片的ID，只读属性，更改此属性请通过mainImgID
    /// </summary>
    public string mainImgUrl
    {
        get { return _mainImgUrl; }
    }



    public string AlbumImgList
    {
        set { _album = value; _albumLinks = getAlbumLinks(value); }
        get { return _album; }
    }

    public List<HyperLink> AlbumImgLinks
    {
        get { return _albumLinks; }
    }














    //public MyProduct()
    //{
    //    //
    //    // TODO: Add constructor logic here
    //    //
    //}

    /// <summary>
    /// 根据数据表的ID，实例化一个产品
    /// </summary>
    /// <param name="ProductID"></param>
    public MyProduct(int ProductID)
    {
        superConn scnn = new superConn("data.mdb");
        scnn.open();
        string _sql = "SELECT T_Product.*, List_pdColor.cl_name, T_IMGS.img_url, List_pdSeries.se_name, List_pdSize.si_size, " +
    " (SELECT list_pdport.pt_name from list_pdport where pt_id = t_product.pd_pt1 ) as Port1, " +
    " (SELECT list_pdport.pt_name from list_pdport where pt_id = t_product.pd_pt2 ) as Port2, " +
    " (SELECT list_pdport.pt_name from list_pdport where pt_id = t_product.pd_pt3 ) as Port3, " +
    " (SELECT list_pdport.pt_name from list_pdport where pt_id = t_product.pd_pt4 ) as Port4 " +
    " FROM T_IMGS INNER JOIN (List_pdSeries INNER JOIN(List_pdSize INNER JOIN(List_pdColor INNER JOIN T_Product ON List_pdColor.cl_id = T_Product.pd_clid) ON List_pdSize.si_id = T_Product.pd_szid) ON List_pdSeries.se_id = T_Product.pd_seid) ON T_IMGS.img_id = T_Product.pd_img " + " WHERE pd_id= " + ProductID;

        OleDbDataReader dr = scnn.GetDataReader(_sql);
        if (dr.Read())
        {
            _id = (int)dr["pd_id"];
            _seid = (int)dr["pd_seid"]; _seName = dr["se_name"].ToString();
            _clid = (int)dr["pd_clid"]; _ColorName = dr["cl_name"].ToString();
            _szid = (int)dr["pd_szid"]; _SizeName = dr["si_size"].ToString();
            _name = dr["pd_name"].ToString();
            _bandwidth = (int)dr["pd_bandwidth"];
            _rtime = (int)dr["pd_rtime"];
            _lms = (int)dr["pd_lms"];
            _screen = dr["pd_screen"].ToString();
            _feature = dr["pd_feature"].ToString();
            _other = dr["pd_other"].ToString();
            _pt1 = (int)dr["pd_pt1"];
            _pt2 = (int)dr["pd_pt2"];
            _pt3 = (int)dr["pd_pt3"];
            _pt4 = (int)dr["pd_pt4"];
            _pt1Name = dr["Port1"].ToString();
            _pt2Name = dr["Port2"].ToString();
            _pt3Name = dr["Port3"].ToString();
            _pt4Name = dr["Port4"].ToString();
            _img = (int)dr["pd_img"];
            _mainImgUrl = dr["img_url"].ToString();
            _album = dr["pd_album"].ToString();

            _albumLinks = getAlbumLinks(_album);
            _push = (Boolean)dr["pd_push"];


        }



    


        scnn.close();
    }



}