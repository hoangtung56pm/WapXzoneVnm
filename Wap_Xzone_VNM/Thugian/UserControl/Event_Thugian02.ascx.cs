using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;

using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Thugian.UserControl
{
    public partial class Event_Thugian02 : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string price;
        private string width;        
        private int catID = 298;
        protected void Page_Load(object sender, EventArgs e)
        {
            price = ConfigurationSettings.AppSettings.Get("relaxprice");
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            width = Request.QueryString["w"];
            if (!IsPostBack)
            {
                if (lang == 0)
                {
                    ltrTieude.Text = "Tu van qua 8/3";
                    lnkXemthem.Text = "Xem them » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien_KD + "/tu van)";
                }
                else
                {
                    ltrTieude.Text = "Tư vấn quà 8/3";
                    lnkXemthem.Text = "Xem thêm » ";
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien + "/tư vấn)";
                }
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            }
            lnkXemthem.NavigateUrl = UrlProcess.GetRelaxNewsCategoryUrl(lang.ToString(), "list", width, catID.ToString());
            if (!string.IsNullOrEmpty(Request.QueryString["f"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["f"]);
            }
            else
            {
                Random rnd = new Random();
                curpage = rnd.Next(1, 8);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = TintucController.GetAllNewsByCategory(catID, pagesize, curpage, out totalrecord);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            //Paging1.totalrecord = totalrecord;
            //Paging1.pagesize = pagesize;
            //Paging1.numberpage = pagenumber;
            //Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&e=" + Request.QueryString["e"];
            //Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&a=" + Request.QueryString["a"] + "&b=" + Request.QueryString["b"] + "&c=" + Request.QueryString["c"] + "&d=" + Request.QueryString["d"] + "&e=" + Request.QueryString["e"] + "&f=";            
        }

        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            Literal ltrLuotxem = (Literal)e.Item.FindControl("ltrLuotxem");            
            if (lang == 1)
            {
                lnkTitle.Text = "<span class=\"blue bold\">" + curData["Content_Headline"].ToString() + "</span>";
                ltrLuotxem.Text = Resources.Resource.wLuotXem + curData["Distribution_View"].ToString();                
            }
            else
            {
                lnkTitle.Text = "<span class=\"blue bold\">" + curData["Content_HeadlineKD"].ToString() + "</span>";
                ltrLuotxem.Text = Resources.Resource.wLuotXem_KD + curData["Distribution_View"].ToString();                
            }
            lnkTitle.NavigateUrl = "../Download.aspx?id=" + curData["Distribution_ID"].ToString() + "&lang=" + lang + "&w=" + width;    
        }
    }
}