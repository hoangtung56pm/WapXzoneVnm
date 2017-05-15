using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Thugian.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int curpage = 1;
        private int tpage = 1;
        private static int lang;
        private string width;
        private static string preurl;
        private static int catid;
        private string [] zonelist;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];
            catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            zonelist = ConfigurationSettings.AppSettings.Get("relax_zoneid").Split(',');
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            if (!IsPostBack)
            {
                rptZoneList.DataSource = zonelist;
                rptZoneList.ItemDataBound+=rptZoneList_ItemDataBound;
                rptZoneList.DataBind();
                
               
            }

        }
        protected void rptZoneList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            string curData = (string)e.Item.DataItem;
            Label lblCatetoryName = (Label)e.Item.FindControl("lblCatetoryName");
            Repeater rptCategory = (Repeater)e.Item.FindControl("rptCategory");
            Panel pnlDangKy = (Panel)e.Item.FindControl("pnlDangKy");
            Literal litContent = (Literal)e.Item.FindControl("litContent");

            string url = string.Empty;
            string display = string.Empty;
            ////Sửa bỏi Bình Trần - 25/11/2016 
            //if (curData == "118") //TRUYEN CUOI
            //{
            //    pnlDangKy.Visible = true;
            //    url = "/ThuGian/Cuoi.aspx?lang=" + lang + "&w=" + width;
            //    display = "Trải nghiệm Truyện Cười cực HOT";
            //}
            //else if(curData == "268") //DIA DIEM AN CHOI
            //{
            //    pnlDangKy.Visible = true;
            //    url = "/ThuGian/AnChoi.aspx?lang=" + lang + "&w=" + width;
            //    display = "Trải nghiệm Địa điểm Ăn chơi cực HOT";
            //}
            //else if(curData == "258") //CAM NANG TU VAN
            //{
            //    pnlDangKy.Visible = true;
            //    url = "/ThuGian/Sex.aspx?lang=" + lang + "&w=" + width;
            //    display = "Trải nghiệm dịch vụ SEX và Cuộc Sống cực HOT";
            //}
            //else if(curData == "255") //DOC TRUYEN
            //{
            //    pnlDangKy.Visible = true;
            //    url = "/ThuGian/DocTruyen.aspx?lang=" + lang + "&w=" + width;
            //    display = "Trải nghiệm dịch vụ Đọc Truyện cực HOT";
            //}
            //else if(curData == "375")//CUNG HOANG DAO
            //{
            //    pnlDangKy.Visible = true;
            //    url = "/ThuGian/CungHoangDao.aspx?lang=" + lang + "&w=" + width;
            //    display = "Trải nghiệm dịch vụ Cung hoàng đạo cực HOT";
            //}   

            string content = " <a class=\"link-non-orange\" href=\"" + url + "\"><span class=\"orange bold\"> " + AppEnv.CheckLang(display) + " </span></a>";
            litContent.Text = content;

            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(ConvertUtility.ToInt32(curData));
            if (lang == 1)
            {
                lblCatetoryName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
            }
            else {
                lblCatetoryName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
            }

            DataTable dt = TintucController.GetAllCategoryExeptCatIDHasCache(ConvertUtility.ToInt32(curData), catid);
            rptCategory.DataSource = dt;
            rptCategory.ItemDataBound += rptCategory_ItemDataBound;
            rptCategory.DataBind();
           
        }
        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");
            if (lang == 1)
            {
                lnkCatName.Text = curData["Zone_Name"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Zone_Alias"].ToString();
            }
            lnkCatName.NavigateUrl = UrlProcess.GetRelaxNewsCategoryUrl(lang.ToString(), "list", width, curData["Zone_ID"].ToString());
        }
    }
}