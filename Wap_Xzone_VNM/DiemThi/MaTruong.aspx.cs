using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Component.Transaction;
using log4net;

namespace WapXzone_VNM.Diemthi
{
    public partial class MaTruong : BasePage
    {
        private int width;        
        private string lang;        
        private string chitietGiaodich=string.Empty;
        private string messageReturn = string.Empty;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];            
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            if (lang == "1")
            {
                ltrDichvu.Text = "TRA MÃ TRƯỜNG 2011";
                ltrTukhoa.Text = "Tên trường";
                ltrGia.Text = "Giá: miễn phí";
            }
            else
            {
                ltrDichvu.Text = "TRA MA TRUONG 2011";
                ltrTukhoa.Text = "Ten truong";
                ltrGia.Text = "Gia: mien phi";
            }            
        }

        protected void rptMaTruong_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrDiv = (Literal)e.Item.FindControl("ltrDiv");
            Literal ltrMaTruong = (Literal)e.Item.FindControl("ltrMaTruong");
            Literal ltrTenTruong = (Literal)e.Item.FindControl("ltrTenTruong");
            if (e.Item.ItemIndex % 2 == 1)
            { 
                ltrDiv.Text = "<div class=\"ts-4cols-1\">";
            }
            else
            {
                ltrDiv.Text = "<div class=\"ts-4cols-0\">";
            }
            ltrMaTruong.Text = curData["MaTruong"].ToString();
            if (lang == "1")
            {
                ltrTenTruong.Text = curData["TenTruong"].ToString();
            }
            else
            {
                ltrTenTruong.Text = curData["TenTruong_KD"].ToString();
            }
        }

        protected void btnThucHien_Click(object sender, ImageClickEventArgs e)
        {
            string tuKhoa = txtTukhoa.Text.Trim().ToLower();
            tuKhoa = tuKhoa.Replace("đại học", "").Replace("dai hoc", "").Replace("cao đẳng", "").Replace("cao dang", "").Replace("trung cấp", "").Replace("trung cap", "").Replace("học viện", "").Replace("hoc vien", "").Replace("trung học", "").Replace("trung hoc", "");
            rptMaTruong.DataSource = WapXzone_VNM.Library.Component.DiemThi.DiemThiController.TimKiem(tuKhoa.Trim()); ;
            rptMaTruong.ItemDataBound += new RepeaterItemEventHandler(rptMaTruong_ItemDataBound);
            rptMaTruong.DataBind();
        }  
    }
}
