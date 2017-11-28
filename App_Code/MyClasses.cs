using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
///MyClasses 的摘要说明
/// </summary>
namespace newClasses
{

    //自定义数据库连接类
    public class superConn
    {

        public OleDbConnection cnn;
        private OleDbCommand cmd;
        private OleDbDataReader datar;

        public superConn(string mdbFileName)
        {
            string _path = "~\\App_Data\\" + mdbFileName;
            string str_conn = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="
                + System.Web.HttpContext.Current.Server.MapPath(_path);
            //MapPath(_path); 
            cnn = new OleDbConnection(str_conn);
        }

        // superConn.open()
        public void open()
        {
            cnn.Open();
        }

        public void close()
        {
            cnn.Close();
        }

        public OleDbDataReader GetDataReader(string _sql)
        {
            cmd = new OleDbCommand(_sql, cnn);
            datar = cmd.ExecuteReader();
            return datar;
        }

        //返回DDL控件,表名列表
        public DropDownList GetDDLforTableList()
        {
            DropDownList _ddl = new DropDownList();

            cnn.Open();

            DataTable dt = cnn.GetSchema("Tables", null);

            foreach (DataRow dr in dt.Select("TABLE_TYPE='TABLE'"))
            {
                string s = dr["TABLE_NAME"].ToString();
                _ddl.Items.Add(new ListItem(s));

            }

            cnn.Close();

            return _ddl;
        }

        //返回table,详细表内容
        public Table GetTable(string _tableName)
        {
            Table _tbl = new Table();
            cnn.Open();

            cmd = new OleDbCommand("SELECT * FROM " + _tableName, cnn);
            datar = cmd.ExecuteReader();


            int i_fcount = datar.FieldCount;

            TableHeaderRow thr = new TableHeaderRow();
            for (int i = 0; i < i_fcount; i++)
            {
                TableHeaderCell thd = new TableHeaderCell();
                thd.Text = datar.GetName(i);
                thr.Cells.Add(thd);

            }
            _tbl.Rows.Add(thr);



            while (datar.Read())
            {
                TableRow tr = new TableRow();
                for (int i = 0; i < i_fcount; i++)
                {
                    TableCell td = new TableCell();
                    td.Text = datar[i].ToString();
                    tr.Cells.Add(td);

                }

                _tbl.Rows.Add(tr);
            }


            cnn.Close();
            return _tbl;
        }

    }





    //文件管理类
    public class superFile
    {

        public string _fileName;
        public string _fileTitle;
        public string _fileDir = "~/filesDownload";

        //1
        public superFile()
        {
            _fileName = _fileTitle = "";
        }

        //2
        public superFile(int _id)
        {
            _fileName = _fileTitle = "";
            superConn sconn = new superConn("fileMNG.mdb");
            sconn.open();
            string _sql = "SELECT * FROM T_FILES WHERE f_id=" + _id;
            OleDbDataReader dr = sconn.GetDataReader(_sql);
            if (dr.Read())
            {
                _fileTitle = dr["f_title"].ToString();
                _fileName = dr["f_name"].ToString();
            }
            sconn.close();

        }

        //下载
        public void fileDownload()
        {
            string _path = System.IO.Path.Combine(HttpContext.Current.Server.MapPath(_fileDir), _fileName);

            if (System.IO.File.Exists(_path))
            {

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.Buffer = true;

                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + _fileTitle);
                HttpContext.Current.Response.ContentType = "application/unknow";
                HttpContext.Current.Response.TransmitFile(_path);
                HttpContext.Current.Response.End();

            }

        }


    }



    //读取文章的类
    public class superArtReader
    {

        public string ArtTitle;
        public string ArtContent;
        private string ArtID;

        /// <summary>
        /// 构造一个空文章对象
        /// </summary>
        public superArtReader()
        {
            ArtTitle = "";
            ArtContent = "";
        }



        /// <summary>
        /// 通过ID从数据库获取对应ID的文章
        /// </summary>
        /// <param name="artID"></param>
        public superArtReader(string artID)
        {
            ArtID = artID;
            ArtTitle = "";
            ArtContent = "";

            superConn scnn = new superConn("DATA.mdb");
            scnn.open();
            string _sql = "select * from T_article WHERE art_id=" + artID;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                ArtTitle = dr["art_ttl"].ToString();
                ArtContent = dr["art_content"].ToString();
            }
            scnn.close();

        }



    }




    //新闻类:superNews静态类
    //superNewsItem动态类

    //superNewsItem动态类
    public class superNewsItem
    {
        private int news_id;
        private int news_ncid;
        private string nc_ttl;

        public string news_ttl;
        public string news_guide;
        public DateTime news_date;
        public int news_imgid;
        private string img_url;
        public string news_content;
        public int news_order;
        public Boolean news_enable;
        public Boolean news_home;

        /// <summary>
        /// 构造空新闻条目
        /// </summary>
        public superNewsItem()
        {


        }

        /// <summary>
        /// 根据新闻的ID,从数据库获取新闻和相关信息;
        /// </summary>
        /// <param name="newsid"></param>
        public superNewsItem(int newsid)
        {
            superConn scnn = new superConn("DATA.mdb");
            scnn.open();
            string _sql = "SELECT T_NEWS.*, T_imgMng.img_url, List_newsClass.nc_ttl FROM List_newsClass INNER JOIN (T_imgMng INNER JOIN T_NEWS ON T_imgMng.img_id = T_NEWS.news_imgid) ON List_newsClass.nc_id = T_NEWS.news_ncid WHERE news_id=" + newsid;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                news_id = int.Parse(dr["news_id"].ToString());
                news_ncid = int.Parse(dr["news_ncid"].ToString());
                nc_ttl = dr["nc_ttl"].ToString();
                news_ttl = dr["news_ttl"].ToString();
                news_guide = dr["news_guide"].ToString();
                news_date = (DateTime)dr["news_date"];
                news_imgid = int.Parse(dr["news_imgid"].ToString());
                img_url = dr["img_url"].ToString();
                news_content = dr["news_content"].ToString();
                news_order = int.Parse(dr["news_order"] is DBNull ? "0" : dr["new_order"].ToString());
                news_enable = (Boolean)dr["news_enable"];
                news_home = (Boolean)dr["news_home"];
            }
            scnn.close();
        }


        //更细致:将新闻类别设定为一个类,有属性ID,ClassName, 返回一个新闻类别的类,更符合调用逻辑
        /// <summary>
        /// 获取类别名称
        /// </summary>
        /// <returns>string型,类别名称</returns>
        public string getClassName()
        {
            return nc_ttl;
        }

        public int getClassID()
        {
            return news_ncid;
        }

        /// <summary>
        /// 以类别ID来设置新闻所属类别
        /// </summary>
        /// <param name="classID"></param>
        public void setClass(int classID)
        {
            superConn scnn = new superConn("DATA.mdb");
            scnn.open();
            string _sql = "SELECT * FROM List_newsClass WHERE nc_id=" + classID;
            OleDbDataReader dr = scnn.GetDataReader(_sql);
            if (dr.Read())
            {
                news_ncid = int.Parse(dr["nc_id"].ToString());
                nc_ttl = dr["nc_ttl"].ToString();
            }
            scnn.close();
        }


    }





    //图片管理类
    //1. 静态类,图片上传类,只提供对应的方法
    public static class superImgUploader
    {



        /// <summary>
        /// 返回待上传文件的数量
        /// </summary>
        /// <returns></returns>
        public static int imgsCount()
        {
            int _count = 0;
            foreach (superImg _img in (superImg[])HttpContext.Current.Session["UploadImgs"])
            {
                if (_img != null) { _count++; }
            }
            return _count;
        }

        /// <summary>
        /// 添加一个图片对象到列表中
        /// </summary>
        /// <param name="ObjectImg">图片对象superImg</param>
        /// <returns>返回添加结果</returns>
        public static Boolean addImg(superImg ObjectImg)
        {
            Boolean _added = false;
            for (int i = 0; i < 10; i++)
            {
                if (((superImg[])HttpContext.Current.Session["UploadImgs"])[i] == null)
                {
                    ((superImg[])HttpContext.Current.Session["UploadImgs"])[i] = ObjectImg;
                    _added = true;
                    break;
                }
            }
            return _added;
        }


        /// <summary>
        /// 从列表中移除指定图片对象
        /// </summary>
        /// <param name="imgIndex">0-9 图片列表编号索引</param>
        public static void removeImg(int imgIndex)
        {
            ((superImg[])HttpContext.Current.Session["UploadImgs"])[imgIndex] = null;
        }


        /// <summary>
        /// 清除所有上传列表
        /// </summary>
        public static void clear()
        {
            HttpContext.Current.Session["UploadImgs"] = new superImg[10];
        }


        /// <summary>
        /// 上传列表中的所有文件
        /// </summary>
        public static void uploadAll()
        {
            foreach (superImg si in (superImg[])HttpContext.Current.Session["UploadImgs"])
            {
                if (si != null)
                {
                    if (si.readToUpload() == true)
                    {
                        string targPath = HttpContext.Current.Server.MapPath("~/test/" + si.targFname);
                        si.pstImgFile.SaveAs(targPath);

                        if (File.Exists(targPath))
                        {
                            si.uploaded();
                        }

                    }
                }
            }
            clear();
        }



        public static void setCID(int i, int value)
        {
            ((superImg[])HttpContext.Current.Session["UploadImgs"])[i].setCID(value);
        }

    }







    //2.图片对象类
    public class superImg
    {

        public HttpPostedFile pstImgFile;
        public string Title;
        public string orgFname;
        public string targFname;

        private int img_id;             //
        public int img_cid;             //需要默认值
        private string img_cname;       //

        private Boolean uploadDone;     //默认FALSH





        /// <summary>
        /// 构建一个空superImg对象
        /// </summary>
        public superImg()
        {

        }


        /// <summary>
        /// 通过postedFile构建一个superImg对象
        /// </summary>
        /// <param name="pstFile"></param>
        public superImg(HttpPostedFile _pstFile)
        {
            pstImgFile = _pstFile;
            Title = "新上传文件";
            orgFname = _pstFile.FileName;
            targFname = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(orgFname);
            img_cid = 1;
            uploadDone = false;
        }


        /// <summary>
        /// 通过数据库img_id构建对应的superImg对象
        /// </summary>
        /// <param name="imgID">数据表T_imgMng.img_id的值</param>
        public superImg(int imgID)
        {

        }


        /// <summary>
        /// 检测属性,并返回对象是否具备上传条件
        /// </summary>
        /// <returns></returns>
        public Boolean readToUpload()
        {
            Boolean _ready = true;
            if (pstImgFile == null) { _ready = false; }
            if (Title == null || Title == "") { _ready = false; }
            if (orgFname == "" || orgFname == null) { _ready = false; }
            if (targFname == "" || targFname == null) { _ready = false; }
            if (uploadDone == true) { _ready = false; }

            return _ready;
        }


        public void uploaded()
        {
            uploadDone = true;
        }


        public void setCID(int cidValue)
        {
            img_cid = cidValue;
        }




    }
}
