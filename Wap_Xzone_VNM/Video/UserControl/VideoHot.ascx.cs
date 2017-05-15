using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class VideoHot : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        private static string preurl;        

        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            int totalrecord = 0;
            //Tải nhiều nhất
            DataTable dtHottest = VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), 1, -1, (int)Constant.Video.Lastest, 15, 1, out totalrecord);

            if (dtHottest != null && dtHottest.Rows.Count > 0)
            {
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

            if (lang == 1)
            {
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien + "/video)";
            }
            else
            {
                //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("videoprice") + Resources.Resource.wDonViTien_KD + "/video)";
            }

            //rptHottest.DataSource = dtHottest;
            //rptHottest.ItemDataBound += rptlastest_ItemDataBound;
            //rptHottest.DataBind();
        }

        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Image imgAvatar = (Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            lnkXem.NavigateUrl = "../View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~","");
        }       
    }
}