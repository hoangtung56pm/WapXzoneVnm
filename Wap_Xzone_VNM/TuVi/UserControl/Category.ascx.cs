using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone.Library;
using WapXzone.Library.Utilities;
using WapXzone.Library.UrlProcess;
using WapXzone.Library.Constant;

using System.Globalization;
using WapXzone.Library.Component.TuVi;

namespace WapXzone.TuVi.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
        private int lang;
        private int width;
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        private string price;
        private int type;
        protected void Page_Load(object sender, EventArgs e)
        {
            cipher = Request.QueryString["link"];
            price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            

            if (width == 0)
            {
                width = (int)Constant.DefaultScreen.Standard;
            }            
            if (!IsPostBack)
            {
                if (lang == 0)
                {
                    lblTitle.Text = "TU VI";
                    ltrHuongdan.Text = "Ban hay dien day du cac thong tin sau:";
                    lblNgaysinh.Text = "Ngay sinh:";
                    lblGioitinh.Text = "Gioi tinh:";
                    ltrGia.Text = "Gia dich vu: " + ConfigurationSettings.AppSettings.Get("tuviprice") + " VND";
                    ddlGioitinh.Items.RemoveAt(1);
                    ListItem tItem = new ListItem();
                    tItem.Text = "Nu";
                    tItem.Value = "10";
                    ddlGioitinh.Items.Add(tItem);
                }
                else
                {
                    ltrGia.Text = "Giá dịch vụ: " + ConfigurationSettings.AppSettings.Get("tuviprice") + " VNĐ";
                }
            }
        }

        protected void btnXem_Click(object sender, EventArgs e)
        {
            string strNgaySinh = txtNgay.Text.Trim() + "/" + txtThang.Text.Trim() + "/" + txtNam.Text.Trim();
            try
            {
                DateTime dateValue = DateTime.Parse(strNgaySinh, new CultureInfo("fr-FR", false));
                DataTable dt = TuViController.Horoscope_Get4Wap(ConvertUtility.ToInt32(ddlGioitinh.SelectedValue), strNgaySinh);
                if (dt == null)
                {
                    if (lang == 1)
                        lblThongbao.Text = "Dữ liệu về ngày sinh chưa được cập nhật. Vui lòng thử lại sau!";
                    else
                        lblThongbao.Text = "Du lieu ve ngay sinh chua duoc cap nhat. Vui long thu lai sau!";
                    lblThongbao.Visible = true;
                    return;
                }
                else
                {
                    string content = cpid + "&" + Constant.hoangdao + "9" + dt.Rows[0]["ID"].ToString() + "&" + ConfigurationSettings.AppSettings.Get("tuviprice") + "&" + vmstransactionid;                    
                    Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                }
            }
            catch 
            {
                if (lang == 1)
                    lblThongbao.Text = "Thông tin ngày sinh bạn nhập không chính xác. Vui lòng nhập lại!";
                else
                    lblThongbao.Text = "Thong tin ngay sinh ban nhap khong chinh xac. Vui long nhap lai!";
                lblThongbao.Visible = true;
            }

        }
    }
}