using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using System.Drawing;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Thethao.UserControl
{
    public partial class LichThiDau : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static int catid;
        private int curpage = 1;
        private int pagesize = 6;
        private int pagenumber = 3;
        private string tab;

        private string tvprice;
        private string tkprice;
        private string kqcprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            tab = Request.QueryString["tab"];
            tvprice = ConfigurationSettings.AppSettings.Get("tipprice");
            tkprice = ConfigurationSettings.AppSettings.Get("ykcgprice");
            kqcprice = ConfigurationSettings.AppSettings.Get("kqchoprice");

            if (!IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                DataSet ds = ThethaoController.GetAll_CompetitionRelationInfo(catid);
                if (lang == 1)
                {
                    lnkLichthidau.Text = "LỊCH THI ĐẤU";
                    lnkTheThao.Text = "BÓNG ĐÁ";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCompetitonName.Text = ds.Tables[0].Rows[0]["NameUnicode"].ToString();
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                        {
                            ltrRoundName.Text = " - " + ds.Tables[3].Rows[0]["Name"].ToString();
                        }
                    }
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Tư vấn " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien + ", Thống kê " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien + ", KQ chờ " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    lnkLichthidau.Text = "LICH THI DAU";
                    lnkTheThao.Text = "BONG DA";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCompetitonName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                        {
                            ltrRoundName.Text = " - " + UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                        }

                        //ltrRoundName.Text = " - " + UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                    }
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "Tu van " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien_KD + ", Thong ke " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien_KD + ", KQ cho " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + ")";
                }
                lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "home", width);
                //Get ra danh sach tran dau
                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }
                int totalrecord = 0;
                DataTable dtlst = ThethaoController.GetAllGameByCompetitionID_LTD(catid, pagesize, curpage, out totalrecord);
                rptLichThiDau.DataSource = dtlst;
                rptLichThiDau.ItemDataBound += new RepeaterItemEventHandler(rptlist_ItemDataBound); ;
                rptLichThiDau.DataBind();
                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;
                Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"];
                Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&catid=" + Request.QueryString["catid"] + "&cpage=";
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
            if (lang == 1)
            {
                ltrGame.Text = "<span class=\"bold\">" + curData["Team_Name1"].ToString() + " ? - ? " + curData["Team_Name2"].ToString() + "</span>";
                lnkTuVan.Text = "Tư vấn";
                lnkThongke.Text = "Thống kê";
                lnkKQCho.Text = "<span class=\"blue bold\">KQ chờ</span>";
            }
            else
            {
                ltrGame.Text = "<span class=\"bold\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " ? - ? " + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString()) + "</span>";
                lnkTuVan.Text = "Tu van";
                lnkThongke.Text = "Thong ke";
                lnkKQCho.Text = "<span class=\"blue bold\">KQ cho</span>";
            }
            if (ThethaoController.GetDetail_YKCG_ByGameID(curData["PK_Game_ID"].ToString()).Rows.Count > 0)
            {
                lnkThongke.Text = "<span class=\"blue bold\">" + lnkThongke.Text + "</span>";
                lnkThongke.NavigateUrl = "../ThongKe.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
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