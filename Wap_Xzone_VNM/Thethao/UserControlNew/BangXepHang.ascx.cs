using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlNew
{
    public partial class BangXepHang : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private static int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];       
            if (!IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                DataSet ds = ThethaoController.GetAll_CompetitionRelationInfo(catid);
                if (lang == 1)
                {
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Tư vấn " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien + ", Thống kê " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien + ", KQ chờ " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien + ")";
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
                    }
                }
                else
                {
                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + "Tu van " + ConfigurationSettings.AppSettings.Get("tipprice") + Resources.Resource.wDonViTien_KD + ", Thong ke " + ConfigurationSettings.AppSettings.Get("ykcgprice") + Resources.Resource.wDonViTien_KD + ", KQ cho " + ConfigurationSettings.AppSettings.Get("kqchoprice") + Resources.Resource.wDonViTien_KD + ")";
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
                    }
                }
                lnkTheThao.NavigateUrl = UrlProcess.GetSportHomeUrlNew(lang.ToString(), "home", width);
                //Get ra bang xep hang
                if (ds.Tables.Count >= 4)
                {
                    DataTable dtbxh = ds.Tables[2];
                    rptbxh.DataSource = dtbxh;
                    rptbxh.ItemDataBound += rptbxh_ItemDataBound; ;
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

    }
}