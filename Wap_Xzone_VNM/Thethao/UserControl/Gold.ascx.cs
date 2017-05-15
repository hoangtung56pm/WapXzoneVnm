using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.Tintuc;
using System.Configuration;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Thethao.UserControl
{
    public partial class Gold : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static int catid;
        private int curpage = 1;
        private int pagesize = 6;
        private int pagenumber = 3;
        private string preurl;
        private string tvprice;
        private string tkprice;
        private string kqcprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            tvprice = ConfigurationSettings.AppSettings.Get("tipprice");
            tkprice = ConfigurationSettings.AppSettings.Get("ykcgprice");
            kqcprice = ConfigurationSettings.AppSettings.Get("kqchoprice");
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    ltrTitle.Text = "TIÊU ĐIỂM THỂ THAO";
                    lnkCacTinKhac.Text = "Các tin khác »";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Tư vấn " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien + ", Thống kê " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien + ", KQ chờ " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "Tu van " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien_KD + ", Thong ke " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien_KD + ", KQ cho " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + ")";
                }
                DataTable tbThueBao = WapController.W4A_Subscriber_GetInfo(ConvertUtility.ToString(Session["msisdn"]), 2);
                if (tbThueBao.Rows.Count > 0)
                {
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Thuê bao ngày";
                        lnkDangKy.Text = "Hạn sử dụng tới " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        ltrDangKy.Text = "Thue bao ngay";
                        lnkDangKy.Text = "Han su dung toi " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    lnkDangKy.NavigateUrl = string.Empty;
                }
                else
                {
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Đăng ký sử dụng trọn gói dịch vụ bóng đá. Giá: " + ConfigurationSettings.AppSettings.Get("bongdathangprice") + Resources.Resource.wDonViTien + "/ngày.";
                        lnkDangKy.Text = "<span class=\"blue bold\">» Đăng ký «</span>";
                    }
                    else
                    {
                        ltrDangKy.Text = "Dang ky su dung tron goi dich vu bong da. Gia: " + ConfigurationSettings.AppSettings.Get("bongdathangprice") + Resources.Resource.wDonViTien_KD + "/ngay.";
                        lnkDangKy.Text = "<span class=\"blue bold\">» Dang ky «</span>";
                    }
                    lnkDangKy.NavigateUrl = "../DangKy.aspx?lang=" + lang.ToString() + "&w" + width;
                }

                lnkCacTinKhac.NavigateUrl = UrlProcess.GetLastestNewsTheThaoSo(lang.ToString(), width);
                lnkTranCauVang.NavigateUrl = "../TuVanDacBiet.aspx?id=4&lang=" + lang.ToString() + "&w" + width;
                lnkTuVanDacBiet.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "tvdb", width);
                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }


                //DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("thethao_zoneiddefaut")), 3);
                DataTable dtlatest = ThethaoController.GetHomeNewsHasCache();
                if(dtlatest != null && dtlatest.Rows.Count > 0)
                {
                    rptNewLastest.DataSource = dtlatest;
                    rptNewLastest.ItemDataBound += rptNewLastest_ItemDataBound;
                    rptNewLastest.DataBind();
                }
               
                int totalrecord = 0;
                DataTable dtlstTip = ThethaoController.GetAllGameByTip(pagesize, curpage, out totalrecord);
                rptTrancaudinh.DataSource = dtlstTip;
                rptTrancaudinh.ItemDataBound += new RepeaterItemEventHandler(rptTrancaudinh_ItemDataBound);
                rptTrancaudinh.DataBind();
                Pagging1.totalrecord = totalrecord;
                Pagging1.pagesize = pagesize;
                Pagging1.numberpage = pagenumber;
                Pagging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"];
                Pagging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&tpage=" + Request.QueryString["tpage"] + "&cpage=";
            }
        }

        protected void rptTrancaudinh_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Label ltrGame = (Label)e.Item.FindControl("ltrGame");
            Literal ltrTime = (Literal)e.Item.FindControl("ltrTime");
            HyperLink lnkTuVan = (HyperLink)e.Item.FindControl("lnkTuVan");
            HyperLink lnkThongke = (HyperLink)e.Item.FindControl("lnkThongke");
            HyperLink lnkKQCho = (HyperLink)e.Item.FindControl("lnkKQCho");
            if (lang == 1)
            {
                ltrGame.Text = "<span class=\"bold\">" + curData["Team_Name1"].ToString() + " - " + curData["Team_Name2"].ToString() + "</span>";
                lnkTuVan.Text = "Tư vấn";
                lnkThongke.Text = "Thống kê";
                lnkKQCho.Text = "<span class=\"blue bold\">KQ chờ</span>";
            }
            else
            {
                ltrGame.Text = "<span class=\"bold\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString() + " - " + curData["Team_Name2"].ToString()) + "</span>";
                lnkTuVan.Text = "Tu van";
                lnkThongke.Text = "Thong ke";
                lnkKQCho.Text = "<span class=\"blue bold\">KQ cho</span>";
            }
            if (ThethaoController.GetDetail_YKCG_ByGameID(curData["PK_Game_ID"].ToString()).Rows.Count > 0)
            {
                //charing
                //string content1 = cpid + "&" + Constant.thethao + "6" + curData["Sport_Id"].ToString() + "&" + tkprice + "&" + vmstransactionid;
                // ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content1, ConfigurationSettings.AppSettings.Get("vmskey")));                    
                lnkThongke.NavigateUrl = "../ThongKe.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                lnkThongke.Text = "<span class=\"blue bold\">" + lnkThongke.Text + "</span>";
            }
            else
            {
                lnkThongke.Text = "<span class=\"bold\">" + lnkThongke.Text + "</span>";
                lnkThongke.Enabled = false;
            }
            //charing
            //check neu ton tai tu van roi thi hien thi link ko thi an di
            DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(curData["PK_Game_ID"].ToString());
            if (tip.Rows.Count > 0)
            {
                //string content2 = cpid + "&" + Constant.thethao + "7" + curData["Sport_Id"].ToString() + "&" + tvprice + "&" + vmstransactionid;
                //lnkTuVan.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content2, ConfigurationSettings.AppSettings.Get("vmskey")));
                lnkTuVan.NavigateUrl = "../TuVan.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                lnkTuVan.Text = "<span class=\"blue bold\">" + lnkTuVan.Text + "</span>";
            }
            else
            {
                lnkTuVan.Text = "<span class=\"bold\">" + lnkTuVan.Text + "</span>";
                lnkTuVan.Enabled = false;
            }
            //string content3 = cpid + "&" + Constant.thethao + "8" + curData["Sport_Id"].ToString() + "&" + kqcprice + "&" + vmstransactionid;
            //lnkKQCho.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content3, ConfigurationSettings.AppSettings.Get("vmskey")));
            lnkKQCho.NavigateUrl = "../KQCho.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;

            ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
        }

        protected void rptNewLastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitlelist = (HyperLink)e.Item.FindControl("lnkTitlelist");
            Image imglist = (Image)e.Item.FindControl("imglist");
            Panel pn = (Panel)e.Item.FindControl("othernews");
            if (e.Item.ItemIndex == 0)
            {
                if (lang == 1)
                {
                    lnkTitle.Text = curData["Content_Headline"].ToString();
                    //ltrTeaser.Text = curData["Content_Teaser"].ToString();                        
                }
                else
                {
                    lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
                    //ltrTeaser.Text = curData["Content_TeaserKD"].ToString();
                }
                //Ảnh đại diện
                if (string.IsNullOrEmpty(ConvertUtility.ToString(curData["Content_Avatar"])))
                {
                    imgAvatar.ImageUrl = "/Images/icon_app52.png";
                }
                else
                {
                    //WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    //ws.GenerateAvatarThumnail(curData["Content_Avatar"].ToString(), 51, 51);
                    //imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["Content_Avatar"].ToString(), 51, 51).Replace("~", "");

                    imgAvatar.ImageUrl = AppEnv.GetAvatarTheThaoSo(curData["Content_Avatar"].ToString(), 51, 51);
                }
                lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrlTheThaoSo(lang.ToString(),width, curData["Distribution_ID"].ToString());
                ltrTime.Text = ConvertUtility.ToDateTime(curData["Content_CreateDate"]).ToString("dd/MM/yyyy HH:mm");
                pn.Visible = false;
            }
            else
            {
                if (lang == 1)
                {
                    lnkTitlelist.Text = curData["Content_Headline"].ToString();
                }
                else
                {
                    lnkTitlelist.Text = curData["Content_HeadlineKD"].ToString();
                }

                lnkTitlelist.NavigateUrl = UrlProcess.GetNewsDetailUrlTheThaoSo(lang.ToString(),width, curData["Distribution_ID"].ToString());
                pn.Visible = true;
            }

        }
    }
}
