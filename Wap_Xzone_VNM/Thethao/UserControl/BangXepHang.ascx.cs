using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.UrlProcess;
using System.Drawing;
using System.Configuration;

using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Thethao.UserControl
{
    public partial class BangXepHang : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static int catid;
        //private int curpage = 1;
        //private int pagesize = 6;
        //private int pagenumber = 3;
        //private string tab;        
        //private string tvprice;
        //private string tkprice;
        //private string kqcprice;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            //tab = Request.QueryString["tab"];            
            if (!IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                DataSet ds = ThethaoController.GetAll_CompetitionRelationInfo(catid);
                if (lang == 1)
                {
                    ltrBangxephang.Text = "BẢNG XẾP HẠNG";
                    lnkTheThao.Text = "BÓNG ĐÁ";
                    lblDiem.Text = "Điểm";
                    lblDoi.Text = "Đội";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        lblCompetitonName.Text = ds.Tables[0].Rows[0]["NameUnicode"].ToString();
                    }
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                        {
                            ltrRoundName.Text = " - " + ds.Tables[3].Rows[0]["Name"];
                        }
                        //ltrRoundName.Text = ds.Tables[3].Rows[0]["Name"].ToString();
                    }
                }
                else
                {
                    ltrBangxephang.Text = "BANG XEP HANG";
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
                        //ltrRoundName.Text = UnicodeUtility.UnicodeToKoDau(ds.Tables[3].Rows[0]["Name"].ToString());
                    }
                }
                lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrl(lang.ToString(), "home", width);
                //Get ra bang xep hang
                if (ds.Tables.Count >= 4)
                {
                    DataTable dtbxh = ds.Tables[2];
                    rptbxh.DataSource = dtbxh;
                    rptbxh.ItemDataBound += new RepeaterItemEventHandler(rptbxh_ItemDataBound); ;
                    rptbxh.DataBind();
                }
            }

        }
        protected void rptbxh_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal lblstt = (Literal)e.Item.FindControl("lblstt");
            Literal lblCode = (Literal)e.Item.FindControl("lblCode");
            Literal lblwin = (Literal)e.Item.FindControl("lblwin");
            Literal lblDraw = (Literal)e.Item.FindControl("lblDraw");
            Literal lblLost = (Literal)e.Item.FindControl("lblLost");
            Literal lblPoint = (Literal)e.Item.FindControl("lblPoint");
            lblstt.Text = curData["Position"].ToString();
            lblCode.Text = curData["TeamCode"].ToString();
            lblwin.Text = curData["Total_Won"].ToString();
            lblDraw.Text = curData["Total_Draw"].ToString();
            lblLost.Text = curData["Total_Lost"].ToString();
            lblPoint.Text = curData["Point"].ToString();

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
                if (ConvertUtility.ToInt32(curData["Status"]) == 1)
                {
                    ltrGame.Text = curData["Team_Name1"].ToString() + " ? - ? " + curData["Team_Name2"].ToString();
                    if (ThethaoController.GetDetail_YKCG_ByGameID(curData["PK_Game_ID"].ToString()).Rows.Count > 0)
                    {
                        //charing
                        //string content1 = cpid + "&" + Constant.thethao + "6" + curData["Sport_Id"].ToString() + "&" + tkprice + "&" + vmstransactionid;
                        //lnkThongke.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content1, ConfigurationSettings.AppSettings.Get("vmskey")));                        
                        lnkThongke.NavigateUrl = "../ThongKe.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                    }
                    else
                    {
                        lnkThongke.Enabled = false;
                    }
                    //charing 
                    DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(curData["PK_Game_ID"].ToString());
                    if (tip.Rows.Count > 0)
                    {
                        //string content2 = cpid + "&" + Constant.thethao + "7" + curData["Sport_Id"].ToString() + "&" + tvprice + "&" + vmstransactionid;
                        //lnkTuVan.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content2, ConfigurationSettings.AppSettings.Get("vmskey")));
                        lnkTuVan.NavigateUrl = "../TuVan.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                    }
                    else
                    {
                        lnkTuVan.Enabled = false;
                    }

                    //string content3 = cpid + "&" + Constant.thethao + "8" + curData["Sport_Id"].ToString() + "&" + kqcprice + "&" + vmstransactionid;
                    //lnkKQCho.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content3, ConfigurationSettings.AppSettings.Get("vmskey")));

                    lnkKQCho.NavigateUrl = "../KQCho.aspx?id=" + curData["Sport_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                }
                else
                {
                    ltrGame.Text = curData["Team_Name1"].ToString() + " " + curData["Team1Score"].ToString() + " - " + curData["Team2Score"].ToString() + " " + curData["Team_Name2"].ToString();
                    lnkThongke.Enabled = false;
                    lnkTuVan.Enabled = false;
                    lnkKQCho.Enabled = false;
                }
                lnkTuVan.Text = "Tư vấn";
                lnkThongke.Text = "Thống kê";
                lnkKQCho.Text = "KQ chờ";
            }
            else
            {
                if (ConvertUtility.ToInt32(curData["Status"]) == 1)
                {
                    ltrGame.Text = UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " ? - ? " + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString());

                    //charing
                    //string content1 = cpid + "&" + Constant.thethao + "6" + curData["Sport_Id"].ToString() + "&" + tkprice + "&" + vmstransactionid;
                    //lnkThongke.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content1, ConfigurationSettings.AppSettings.Get("vmskey")));

                    //charing 
                    DataTable tip = ThethaoController.GetDetail_Tip_ByGameID(curData["PK_Game_ID"].ToString());
                    if (tip.Rows.Count > 0)
                    {
                        //string content2 = cpid + "&" + Constant.thethao + "7" + curData["Sport_Id"].ToString() + "&" + tvprice + "&" + vmstransactionid;
                        //lnkTuVan.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content2, ConfigurationSettings.AppSettings.Get("vmskey")));
                    }

                    //string content3 = cpid + "&" + Constant.thethao + "8" + curData["Sport_Id"].ToString() + "&" + kqcprice + "&" + vmstransactionid;
                    //lnkKQCho.NavigateUrl = ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content3, ConfigurationSettings.AppSettings.Get("vmskey")));
                    lnkThongke.NavigateUrl = UrlProcess.GetCompetitionThongKeUrl(lang.ToString(), width, curData["PK_Game_ID"].ToString());
                    lnkTuVan.NavigateUrl = UrlProcess.GetCompetitionTuVanUrl(lang.ToString(), width, curData["PK_Game_ID"].ToString());
                    lnkKQCho.NavigateUrl = UrlProcess.GetCompetitionKQChoUrl(lang.ToString(), width, curData["PK_Game_ID"].ToString());
                }
                else
                {
                    ltrGame.Text = UnicodeUtility.UnicodeToKoDau(curData["Team_Name1"].ToString()) + " " + curData["Team1Score"].ToString() + " - " + curData["Team2Score"].ToString() + " " + UnicodeUtility.UnicodeToKoDau(curData["Team_Name2"].ToString());
                    lnkThongke.Enabled = false;
                    lnkTuVan.Enabled = false;
                    lnkKQCho.Enabled = false;

                }
            }
            ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
        }
    }
}