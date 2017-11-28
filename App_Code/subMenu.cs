using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using newClasses;

/// <summary>
/// Summary description for subMenu
/// </summary>
public static class subMenu
{
    /// <summary>
    /// 返回子菜单的bulletedList控件
    /// </summary>
    /// <param name="classID">数据库中classID的值</param>
    /// <returns></returns>
    public static BulletedList getSubmenu(int classID)
    {
        BulletedList blist = (BulletedList)HttpContext.Current.Application["submenu"];
        //div_submenuHolder.Controls.Add(blist);
        BulletedList blist_now = new BulletedList();
        blist_now.DisplayMode = BulletedListDisplayMode.HyperLink;
        foreach (ListItem li in blist.Items)
        {
            if (li.Attributes["classid"] == classID.ToString())//使用数据库中classID的值
            {
                blist_now.Items.Add(li);
            }
        }
        return blist_now;
    }



    /// <summary>
    /// 重写application的内容
    /// </summary>
    public static void reWriteApplication()
    {
        ListItem li;
        BulletedList fulllist = new BulletedList();

        newClasses.superConn scnn = new newClasses.superConn("DATA.MDB");

        scnn.open();
        string _sql = "SELECT * FROM T_SUBMENU WHERE MENU_ENABLE=TRUE ORDER BY MENU_CLASSID,MENU_ORDER DESC";
        System.Data.OleDb.OleDbDataReader dr = scnn.GetDataReader(_sql);
        while (dr.Read())
        {
            li = new ListItem();
            li.Text = dr["menu_ttl"].ToString();
            li.Value = dr["menu_url"].ToString();
            li.Attributes.Add("classid", dr["menu_classid"].ToString());//增加一个classid属性
            fulllist.Items.Add(li);
        }

        scnn.close();

        HttpContext.Current.Application.Lock();
        HttpContext.Current.Application["submenu"] = fulllist;
        HttpContext.Current.Application.UnLock();
    }



}