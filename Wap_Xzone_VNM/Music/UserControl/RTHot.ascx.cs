using System;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class RTHot : System.Web.UI.UserControl
    {
        private int pagesize = 3;        
        protected int lang;
        protected string width;
        private static string preurl;        
        protected void Page_Load(object sender, EventArgs e)
        {            
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];            
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);            
                        
            if (lang == 0)
            {
                lnkXemThem.Text = "Nhac HOT";
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("ringtoneprice") + Resources.Resource.wDonViTien_KD + "/nhac chuong)";
            }
            else
            {
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("ringtoneprice") + Resources.Resource.wDonViTien + "/nhạc chuông)";
            }
            lnkXemThem.NavigateUrl = UrlProcess.GetMusicHomeUrl(lang.ToString(), width);
            //Tải nhiều nhất
            //DataTable dtHottest = WapXzone_VNM.Library.Component.Music.MusicController.GetItemTopByAlbumHasCache(3, Session["telco"].ToString(), 3);
            DataTable dtHottest = WapXzone_VNM.Library.Component.Music.MusicController.GetItemTopByAlbum(3, Session["telco"].ToString(), 20);
            Random rnd = new Random();
            while (dtHottest.Rows.Count > 3)
            {
                dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                dtHottest.AcceptChanges();
            }
            rptHottest.DataSource = dtHottest;
            rptHottest.ItemDataBound += rptlastest_ItemDataBound;
            rptHottest.DataBind();
        }
        
        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;            
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrCasy = (Literal)e.Item.FindControl("ltrCasy");            
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");            
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["SongNameUnicode"].ToString() + "</span>";
                ltrCasy.Text = Resources.Resource.wCaSy + curData["ArtistNameUnicode"].ToString();                
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else 
            {
                lnkTenAnh.Text = "<span class=\"blue bold\">" + curData["SongName"].ToString() + "</span>";
                ltrCasy.Text = Resources.Resource.wCaSy_KD + curData["ArtistName"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkTenAnh.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_MItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetMusicDetailUrl(lang.ToString(), width, curData["W_MItemID"].ToString()) + "&g=1"; 
        }       
    }
}