using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using newClasses;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for artItem
/// </summary>
public class artItem
{
    public string artTitle;
    public string artContent;

    public artItem(int artID)
    {
        superConn scnn = new superConn("DATA.MDB");
        scnn.open();
        string sql = "SELECT * FROM T_artMng WHERE art_id=" + artID;
        OleDbDataReader dr = scnn.GetDataReader(sql);
        if (dr.Read())
        {
            artTitle = dr["art_title"].ToString();
            artContent = dr["art_content"].ToString();
        }

        scnn.close();
    }


    /// <summary>
    /// 构造文章显示的panel
    /// </summary>
    /// <returns></returns>
    public Panel getShowPanel()
    {
        Panel _pnl, _pnlContent;
        Label _labTitle;

        _pnl = new Panel();
        _pnl.CssClass = "newsDetail";

        _labTitle = new Label();
        _labTitle.CssClass = "newsTitle";
        _labTitle.Text = artTitle;
        _pnl.Controls.Add(_labTitle);

        _pnlContent = new Panel();
        _pnlContent.CssClass = "newsContent cke_show_borders";
        Literal l = new Literal();
        l.Text = artContent;
        _pnlContent.Controls.Add(l);
        _pnl.Controls.Add(_pnlContent);

        return _pnl;
    }

    //插入最后的节点
    public Label getLastNode()
    {
        Label _lab = new Label();
        _lab.Text = artTitle;
        return _lab;
    }
}