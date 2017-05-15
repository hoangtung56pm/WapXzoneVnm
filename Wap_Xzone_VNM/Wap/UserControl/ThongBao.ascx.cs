using System;
using System.Data;
using WapXzone_VNM.Library.Component.Wap;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class ThongBao : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["MaiTho"] != null)
                {
                    pnlThongBao.Visible = true;
                    litThongBao.Text = "Quý khách được hưởng khuyến mãi MIỄN PHÍ 100 ĐIỂM cho chương trình 'Anh tài bóng đá' khi truy cập vào wap Vietnamobile.<br /><br />Để xem thông tin dịch vụ vui lòng truy cập: <a href='http://visport.vn'>http://visport.vn</a> <br /><br />Để hủy dịch vụ vui lòng soạn HUY BD gửi 979. Chân thành cảm ơn";
                    Session["MaiTho"] = null;
                }
                else if (Session["VmGame"] != null)
                {
                    pnlThongBao.Visible = true;
                    litThongBao.Text = "Dịch vụ Game tặng bạn tải game MIỄN PHÍ.<br /> Hàng tuần bạn sẽ nhận được game vào thứ 3,6.<br />Link tải game miễn phí: http://vmgame.vn/wap/home/s2register <br />Để hủy dịch vụ, soạn tin: HUY gửi 2288";
                    Session["VmGame"] = null;
                }
                else if (Session["VClip"] != null)
                {
                    pnlThongBao.Visible = true;
                    litThongBao.Text = "Dịch vụ DV VMclip của Vietnamobile tặng bạn MIỄN PHÍ 3 ngày sử dụng dịch vụ.<br /> Truy cập ngay: http://kho-clip.com/ để sử dụng dịch vụ<br /> Để hủy dịch vụ, soạn CLIP OFF gửi 949. HT 19001255";
                    Session["VClip"] = null;
                }
                else
                {
                    if (Session["S2_94x"] != null)
                    {
                        string message = Session["S2_94x"].ToString();
                        DataTable dt = WapController.VnmS294XConfigGetInfo(message);
                        if(dt != null && dt.Rows.Count > 0)
                        {
                            pnlThongBao.Visible = true;
                            litThongBao.Text = dt.Rows[0]["Definition_Description"].ToString();
                            Session["S2_94x"] = null;
                        }
                    }
                }
            }
        }
    }
}