using System;
using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hoangdao.UserControlHigh
{
    public partial class List : System.Web.UI.UserControl
    {

        //private string width;
        //private string lang;
        //private static string preurl;
        //private string cpid = string.Empty;
        //private string vmstransactionid = string.Empty;
        //private string msisdn = string.Empty;
        //private string price;
        private int type;

        protected string linkNgay;
        protected string linkTuan;
        protected string linkThang;


        protected void Page_Load(object sender, EventArgs e)
        {
            //preurl = ConfigurationSettings.AppSettings.Get("urldata");
            //price = ConfigurationSettings.AppSettings.Get("hoangdaoprice");
            type = ConvertUtility.ToInt32(Request.QueryString["catid"]);

            if(!Page.IsPostBack)
            {
                string title = HoangdaoController.CungHoangdao[type, 1].ToUpper() + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                lblCatetoryName.Text = title;

                DateTime vTime = DateTime.Now;
                DataTable dtDetail;

                //Link ngay
                string ngayThang;
                if (vTime.Day < 10)
                    ngayThang = "0" + vTime.Day;
                else
                    ngayThang = vTime.Day.ToString();
                if (vTime.Month < 10)
                    ngayThang += "0" + vTime.Month;
                else
                    ngayThang += vTime.Month.ToString();
                dtDetail = HoangdaoController.GetByTypeAndDateHasCache(type, ngayThang);
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        //linkNgay = UrlProcess.HoangDaoChiTiet(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "ngay","1");
                        linkNgay = UrlProcess.HoangDaoDownload(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "1");
                    }
                }

                //Link tuan
                int week = (int)((vTime.Day + 6) / 7);
                if (week == 5) week = 4;
                dtDetail = HoangdaoController.GetByTypeAndMonthAndWeekHasCache(type, vTime.Month.ToString(), week.ToString());
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        //linkTuan = UrlProcess.HoangDaoChiTiet(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "tuan","2");
                        linkTuan = UrlProcess.HoangDaoDownload(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "2");
                    }
                }

                //Link thang
                dtDetail = HoangdaoController.GetByTypeAndMonthHasCache(type, vTime.Month.ToString());
                if (dtDetail.Rows.Count > 0)
                {
                    if (dtDetail.Rows[0]["WapContent"].ToString() != "")
                    {
                        //linkThang = UrlProcess.HoangDaoChiTiet(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "thang","3");
                        linkThang = UrlProcess.HoangDaoDownload(ConvertUtility.ToInt32(dtDetail.Rows[0]["ID"].ToString()), "3");
                    }
                }
            }
        }
    }
}