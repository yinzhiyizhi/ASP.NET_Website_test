using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class App_Ctrls_ctl_Album : System.Web.UI.UserControl
{
    //最大尺寸定义
    private int _maxWidth = 500;
    private int _maxHeight = 500;
    public int MaxWidth
    {
        set { _maxWidth = value; }
        get { return _maxWidth; }
    }
    public int MaxHeight
    {
        set { _maxHeight = value; }
        get { return _maxHeight; }
    }



    //是否显示缩略图
    private Boolean _showShortCut = true;
    public Boolean ShowShortCut
    {
        set { _showShortCut = value; }
        get { return _showShortCut; }
    }



    //相册列表
    private List<HyperLink> _imgLinks = new List<HyperLink>();
    public List<HyperLink> ImgLinks
    {
        set { _imgLinks = value; }
        get { return _imgLinks; }
    }



    //自动切换相关属性
    private Boolean _autoRoll = false;
    public Boolean AutoRoll
    {
        set { _autoRoll = value; }
        get { return _autoRoll; }
    }
    
    //间隔时间
    private int _interval = 3000;
    public int Interval
    {
        set { _interval = value; }
        get { return _interval; }
    }





    protected void Page_Load(object sender, EventArgs e)
    {
        //尺寸
        div_outerLine.Style.Add("width", _maxWidth + "px");
        div_CtlHolder.Style.Add("width", _maxWidth + "px");
        //div_ImgCtlHolder.Style.Add("height", _maxHeight + "px");
        div_ImgHolder.Style.Add("height", _maxHeight + "px");

        //左右控件设置
        div_CtlHolder.Style.Add("margin-top", (_maxHeight / 2 - 20) + "px");

        //缩略图显示
        if (!_showShortCut) { div_ShortCut.Style.Add("display", "none"); }

        //向缩略图添加图片
        int i = 0;
        foreach(HyperLink _link in _imgLinks)
        {
            _link.Attributes.Add("imgIndex", i.ToString());i++;//增加一个特殊属性记录当前图片状态
            div_ShortCut.Controls.Add(_link);
        }
        //设置初始值
        txt_Count.Text = i.ToString();
        txt_Now.Text = "0";


        Panel _pnl = new Panel();
        _pnl.CssClass = "clr";
        div_ShortCut.Controls.Add(_pnl);


        //向外框添加更多属性
        div_outerLine.Attributes.Add("jsID", ID);
        if (_autoRoll)
        {
            div_outerLine.Attributes.Add("roll","true");
            //timer_album1=setInterval("showNext('album1')",3000);
            //timer_album2=setInterval("showNext('album2')",4000);
            string _js = "timer_" + ID + "=setInterval(\"showNext('" + ID + "')\"," + _interval + ");";
            ScriptManager.RegisterStartupScript(this, this.GetType(), ID, _js, true);
        }



    }
}