using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using System.Data;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library;

using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Thugian.UserControl
{
    public partial class LastestNews : System.Web.UI.UserControl
    {
        private int lang;
        private string width;        
        protected void Page_Load(object sender, EventArgs e) 
        {   
            if (!IsPostBack)
            {
                width = Request.QueryString["w"];            
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                if (lang == 1)
                {
                    lblTitle.Text = "THƯ GIÃN";                    
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Truyện cười " + ConfigurationSettings.AppSettings.Get("relaxprice") + Resources.Resource.wDonViTien + ", Sex và cuộc sống " + ConfigurationSettings.AppSettings.Get("relaxsexprice") + Resources.Resource.wDonViTien + ", Gửi lời yêu thương, Cẩm năng tư vấn " + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien + ")";
                }
                else
                {
                    lblTitle.Text = "THU GIAN";                     
                    //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + "Truyen cuoi " + ConfigurationSettings.AppSettings.Get("relaxprice") + Resources.Resource.wDonViTien + ", Sex va cuoc song " + ConfigurationSettings.AppSettings.Get("relaxsexprice") + Resources.Resource.wDonViTien + ", Gui loi yeu thuong, Cam nang tu van " + ConfigurationSettings.AppSettings.Get("relaxtuvanprice") + Resources.Resource.wDonViTien + ")";
                }
                //   //Sửa bỏi Bình Trần - 25/11/2016  
                DataTable tbThueBao = WapController.W4A_Subscriber_GetInfo(ConvertUtility.ToString(Session["msisdn"]), 1);
                if (tbThueBao.Rows.Count > 0)
                {
                   // lnkDangKy.NavigateUrl = string.Empty;
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Thuê bao đọc truyện";
                        lnkDangKy.Text = "Hạn sử dụng tới " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        ltrDangKy.Text = "Thue bao doc truyen";
                        lnkDangKy.Text = "Han su dung toi " + ConvertUtility.ToDateTime(tbThueBao.Rows[0]["ExpiredDate"]).ToString("dd/MM/yyyy HH:mm");
                    }                    
                }
                else
                {
                   // lnkDangKy.NavigateUrl = "../DangKy.aspx?lang=" + lang.ToString() + "&w=" + width;
                    if (lang == 1)
                    {
                        ltrDangKy.Text = "Đăng ký gói 30 ngày đọc truyện “tẹt ga”. Giá: " + ConfigurationSettings.AppSettings.Get("relaxtruyenprice") + Resources.Resource.wDonViTien + "/tháng";
                       // ltrDK.Text = "» Đăng ký «";
                    }
                    else 
                    {
                        ltrDangKy.Text = "Dang ky goi 30 ngay doc truyen “tet ga”. Gia: " + ConfigurationSettings.AppSettings.Get("relaxtruyenprice") + Resources.Resource.wDonViTien_KD + "/thang";
                      //  ltrDK.Text = "» Dang ky «";
                    }
                }
            }

            
            //lastest News
            //DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(ConfigurationSettings.AppSettings.Get("relax_zoneiddefaut")), 6);
            //rptlastest.DataSource = dtlatest;
            //rptlastest.ItemDataBound += new RepeaterItemEventHandler(rptlastest_ItemDataBound);
            //rptlastest.DataBind();
        }
        
        //protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemIndex < 0) return;
        //    DataRowView curData = (DataRowView)e.Item.DataItem;
        //    HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
        //    Literal ltrLuotxem = (Literal)e.Item.FindControl("ltrLuotxem");            
        //    if (lang == 1)
        //    {
        //        lnkTitle.Text = "<span class=\"blue bold\">" + curData["Content_Headline"].ToString() + "</span>";
        //        ltrLuotxem.Text = Resources.Resource.wLuotXem + curData["Distribution_View"].ToString();                
        //    }
        //    else
        //    {
        //        lnkTitle.Text = "<span class=\"blue bold\">" + curData["Content_HeadlineKD"].ToString() + "</span>";
        //        ltrLuotxem.Text = Resources.Resource.wLuotXem + curData["Distribution_View"].ToString();                
        //    }
        //    lnkTitle.NavigateUrl = "../Download.aspx?id=" + curData["Distribution_ID"].ToString() + "&lang=" + lang + "&w=" + width; 
        //}
    }
}