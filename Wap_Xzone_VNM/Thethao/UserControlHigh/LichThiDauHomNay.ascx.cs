using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class LichThiDauHomNay : System.Web.UI.UserControl
    {

        private int lang;
        private string width;
        private int pagesize = 2;
        private int pagenumber = 3;
        private int curpage = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }

            if (!IsPostBack)
            {
                //lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                //if (lang == 1)
                //{
                    //ltrLichThiDauHomNay.Text = "LỊCH THI ĐẤU HÔM NAY";
                    //lnkTheThao.Text = "BÓNG ĐÁ";
//                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Tư vấn " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien + ", Thống kê " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien + ", KQ chờ " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien + ")";
                //}
                //else
                //{
                //    ltrLichThiDauHomNay.Text = "LICH THI DAU HOM NAY";
                //    lnkTheThao.Text = "BONG DA";
                //    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "Tu van " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien_KD + ", Thong ke " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien_KD + ", KQ cho " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + ")";
                //}
                //lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "home", width);
                int totalrecord;
                DataTable dt = ThethaoController.AllCompetitionLTDToDayHasCache_Live((int)Constant.DefaultPortal.Mobifone, pagesize, curpage, out totalrecord);
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += rptCategory_ItemDataBound;
                rptCategory.DataBind();
                //Paging1.totalrecord = totalrecord;
                //Paging1.pagesize = pagesize;
                //Paging1.numberpage = pagenumber;
                //Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"];
                //Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&cpage=";
            }

        }
        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrGiaiDau = (Literal)e.Item.FindControl("ltrGiaiDau");
            Repeater rptLichThiDau = (Repeater)e.Item.FindControl("rptLichThiDau");
            int totalrecord;
            DataTable dtItem = ThethaoController.GetAllGameToDayByCompetitionID_LTD_Live(ConvertUtility.ToInt32(curData["W_CompetitionID"]), 20, 1, out totalrecord);

            //if (lang == 1)
            //{
                ltrGiaiDau.Text = curData["NameUnicode"].ToString();
            //}
            //else
            //{
            //    ltrGiaiDau.Text = curData["Name"].ToString();
            //}
            if (dtItem.Rows.Count > 0)
            {
                rptLichThiDau.DataSource = dtItem;
                rptLichThiDau.ItemDataBound += rptlist_ItemDataBound;
                rptLichThiDau.DataBind();
            }
        }


        protected void rptlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Label ltrGame = (Label)e.Item.FindControl("ltrGame");
            Literal ltrTime = (Literal)e.Item.FindControl("ltrTime");
            HyperLink lnkTuVan = (HyperLink)e.Item.FindControl("lnkTuVan");
            HyperLink lnkThongke = (HyperLink)e.Item.FindControl("lnkThongke");
            HyperLink lnkKQCho = (HyperLink)e.Item.FindControl("lnkKQCho");
            //if (lang == 1)
            //{
                ltrGame.Text = "<span class=\"bold\">" + curData["Team_Name1"].ToString() + " ? - ? " + curData["Team_Name2"].ToString() + "</span>";
                lnkTuVan.Text = "Tư vấn";
                lnkThongke.Text = "Thống kê";
                lnkKQCho.Text = "<span class=\"blue bold\">KQ chờ</span>";
            //}
            //else
            //{
            //    ltrGame.Text = "<span class=\"bold\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " ? - ? " + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString()) + "</span>";
            //    lnkTuVan.Text = "Tu van";
            //    lnkThongke.Text = "Thong ke";
            //    lnkKQCho.Text = "<span class=\"blue bold\">KQ cho</span>";
            //}
            if (ThethaoController.GetDetail_YKCG_ByGameID(curData["PK_Game_ID"].ToString()).Rows.Count > 0)
            {
                lnkThongke.Text = "<span class=\"blue bold\">" + lnkThongke.Text + "</span>";
                //lnkThongke.NavigateUrl = "../ThongKe.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                lnkThongke.NavigateUrl = UrlProcess.TheThaoThongKe(curData["Sport_Id"].ToString());
            }
            else
            {
                lnkThongke.Text = "<span class=\"gray bold\">" + lnkThongke.Text + "</span>";
                lnkThongke.Enabled = false;
            }
            DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(curData["PK_Game_ID"].ToString());
            if (tip.Rows.Count > 0)
            {
                lnkTuVan.Text = "<span class=\"blue bold\">" + lnkTuVan.Text + "</span>";
                lnkTuVan.NavigateUrl = "../TuVan.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
            }
            else
            {
                lnkTuVan.Text = "<span class=\"gray bold\">" + lnkTuVan.Text + "</span>";
                lnkTuVan.Enabled = false;
            }
            lnkKQCho.NavigateUrl = "../KQCho.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
            ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
        }

    }
}