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
    public partial class KetQuaThiDau : System.Web.UI.UserControl
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
                    ltrLichthidau.Text = "KẾT QUẢ THI ĐẤU";
                    lnkTheThao.Text = "BÓNG ĐÁ";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCompetitonName.Text = ds.Tables[0].Rows[0]["NameUnicode"].ToString();
                    }
                    if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                    {
                        ltrRoundName.Text = " - " + UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                    }
                    //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    //{
                    //    ltrRoundName.Text = " - " + ds.Tables[3].Rows[0]["Name"].ToString();
                    //}                   
                }
                else
                {
                    ltrLichthidau.Text = "KET QUA THI DAU";
                    lnkTheThao.Text = "BONG DA";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCompetitonName.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    }

                    if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                    {
                        ltrRoundName.Text = " - " + UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                    }

                    //if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    //{
                    //    ltrRoundName.Text = " - " + UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                    //}                   
                }
                lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "home", width);
                //Get ra danh sach tran dau
                if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
                {
                    curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
                }

                int totalrecord = 0;
                DataTable dtlst = ThethaoController.GetAllGameByCompetitionID_KQ(catid, pagesize, curpage, out totalrecord);
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
            if (curData["Status"].ToString() == "1")
            {
                HyperLink lnkTuVan = (HyperLink)e.Item.FindControl("lnkTuVan");
                HyperLink lnkThongke = (HyperLink)e.Item.FindControl("lnkThongke");
                HyperLink lnkKQCho = (HyperLink)e.Item.FindControl("lnkKQCho");
                Panel pnlDichvu = (Panel)e.Item.FindControl("pnlDichvu");
                pnlDichvu.Visible = true;
                if (lang == 1)
                {
                    ltrGame.Text = "<span class=\"bold\">" + curData["Team_Name1"].ToString() + " ? - ? " + curData["Team_Name2"].ToString() + "</span>";
                    lnkTuVan.Text = "<span class=\"blue bold\">Tư vấn</span>";
                    lnkThongke.Text = "<span class=\"blue bold\">Thống kê</span>";
                    lnkKQCho.Text = "<span class=\"blue bold\">KQ chờ</span>";
                }
                else
                {
                    ltrGame.Text = "<span class=\"bold\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " ? - ? " + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString()) + "</span>";
                    lnkTuVan.Text = "<span class=\"blue bold\">Tu van</span>";
                    lnkThongke.Text = "<span class=\"blue bold\">Thong ke</span>";
                    lnkKQCho.Text = "<span class=\"blue bold\">KQ cho</span>";
                }
                if (ThethaoController.GetDetail_YKCG_ByGameID(curData["PK_Game_ID"].ToString()).Rows.Count > 0)
                {
                    lnkThongke.NavigateUrl = "../ThongKe.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                }
                else
                {
                    lnkThongke.Enabled = false;
                }
                DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(curData["PK_Game_ID"].ToString());
                if (tip.Rows.Count > 0)
                {
                    lnkTuVan.NavigateUrl = "../TuVan.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                }
                else
                {
                    lnkTuVan.Enabled = false;
                }
                lnkKQCho.NavigateUrl = "../KQCho.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                if (lang == 1)
                {
                    ltrGame.Text = "<span class=\"bold orange\">" + curData["Team_Name1"].ToString() + " </span><span class=\"bold blue\">" + curData["Team1Score"].ToString() + " - " + curData["Team2Score"].ToString() + " </span> <span class=\"bold\">" + curData["Team_Name2"].ToString() + "</span>";
                }
                else
                {
                    ltrGame.Text = "<span class=\"bold orange\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " </span><span class=\"bold blue\">" + curData["Team1Score"].ToString() + " - " + curData["Team2Score"].ToString() + " </span> <span class=\"bold\">" + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString()) + "</span>";
                }
                ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
            }
            // CLIP
            //int clipID = ThethaoController.Clip4Bongda(curData["PK_Game_ID"].ToString());
            //if (clipID > 0)
            //{
            //    HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            //    HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            //    HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            //    Panel pnlClip = (Panel)e.Item.FindControl("pnlClip");
            //    pnlClip.Visible = true;
            //    lnkTai.NavigateUrl = "../../Video/Download.aspx?id=" + clipID.ToString() + "&lang=" + lang + "&w=" + width;
            //    lnkXem.NavigateUrl = "../../Video/View.aspx?id=" + clipID.ToString() + "&lang=" + lang + "&w=" + width;
            //    lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, clipID.ToString()) + "&g=1";
            //    if (lang == 1)
            //    {
            //        lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
            //        lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            //    }
            //    else
            //    {
            //        lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
            //        lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            //    }
            //}
        }
    }
}