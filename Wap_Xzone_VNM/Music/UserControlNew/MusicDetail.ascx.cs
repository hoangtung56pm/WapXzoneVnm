using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class MusicDetail : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        private int id;
        private string price;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                //Detail
                DataTable dtDetail = MusicController.GetItemDetail(Session["telco"].ToString(), id);
                //end detail                
                if (dtDetail.Rows.Count > 0)
                {
                    price = ConfigurationSettings.AppSettings.Get("ringtoneprice");

                    if (lang == "1")
                    {
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongNameUnicode"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy + "<a Class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByArtistUrlNew(lang, width, dtDetail.Rows[0]["ArtistID"].ToString()) + "\">" + dtDetail.Rows[0]["ArtistNameUnicode"] + "</a>";
                        ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe + "</span>";
                    }
                    else
                    {
                        ltrTenAnh.Text = dtDetail.Rows[0]["SongName"].ToString();
                        ltrCasy.Text = Resources.Resource.wCaSy_KD + "<a Class=\"link-non-black\" href=\"" + UrlProcess.GetMusicByArtistUrl(lang, width, dtDetail.Rows[0]["ArtistID"].ToString()) + "\">" + dtDetail.Rows[0]["ArtistName"] + "</a>";
                        ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                    }
                    if (id == 2843)
                    {
                        if (lang == "1") ltrGiaTai.Text = "Miễn phí";
                        else ltrGiaTai.Text = "Mien phi";
                    }
                    lnkTai.NavigateUrl = "../DownloadNew.aspx?id=" + dtDetail.Rows[0]["W_MItemID"] + "&lang=" + lang + "&w=" + width;
                }
            }
        }
    }
}