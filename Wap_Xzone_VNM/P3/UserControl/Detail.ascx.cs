using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using log4net;
using WapXzone_VNM.PM;
using WapXzone_VNM.Library;

namespace WapXzone_VNM.P3.UserControl
{

    public partial class Detail : System.Web.UI.UserControl
    {
        protected string title = "";
        protected string image = "";
        protected string link = "";
        protected string view = "";
        protected string time = "";
        private string messageReturn = string.Empty;
        int price = ConvertUtility.ToInt32(AppEnv.GetSetting("VideoPriceForP3"));
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                if (!CheckConfirm())
                {
                    btnOK_Click(btnOK, EventArgs.Empty);
                }
                else
                {
                    trConfirm.Visible = true;

                    Data data = Controller.GetDataDetail(id);

                    title = "THÔNG BÁO";
                    ltrThongBao.Text = "Bạn có đồng ý mua Video <br /> <b style=\"color:red;\">" + data.name + "</b> <br /> với giá <b>" + price + "(VND) ?</b>";
                }

                rptList.DataSource = Controller.GetDataRandom(0, 5);
                rptList.DataBind();
            }
        }

        private bool CheckConfirm()
        {
            return ConvertUtility.ToInt32(AppEnv.GetSetting("CheckConfirm")) == 1 ? true : false;
        }

        protected string GetLinkDetail(object id)
        {
            return "/P3/default.aspx?display=detail&id=" + id;
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {
            if (Session["msisdn"] == null)
            {
                Data data = Controller.GetDataDetail(id);

                title = data.name;
                image = data.image;
                link = data.linkfile;
                view = data.views;
                time = data.time;

                HienThiNoiDung(data);
            }
            else 
            {
                Data data = Controller.GetDataDetail(id);

                title = data.name;
                image = data.image;
                link = data.linkfile;
                view = data.views;
                time = data.time;

                int status = 1;
                string debit_status = string.Empty;

                string type = "VIDEO";
                DateTime sentTime = DateTime.Now;

                int partnerId = 60;

                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price.ToString(), "D", "VID", Request.QueryString["id"]);

                if (messageReturn == "1")
                {
                    status = 0;
                    HienThiNoiDung(data);
                    Session["transactionid"] = null;
                }

                DBController.Transaction_Insert_New(id.ToString(), title, 5, Session["msisdn"].ToString(), 3, 0, price, partnerId, ConvertUtility.ToDecimal(DateTime.Now.ToString("yyyyMMddHHmmss")), DateTime.Now, "debit_status: " + debit_status, status);

            }
            
        }

        protected void HienThiNoiDung(Data data)
        {
            trConfirm.Visible = false;
            trContent.Visible = true;

            title = data.name;
            image = data.image;
            link = data.linkfile;
            view = data.views;
            time = data.time;

            hplTai.NavigateUrl = link;


            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Info("Dich vu: Video - parameter: " + price + " - Ten: " + title + " - id: " + id);
            logger.Info("Video Url:" + link);
            string clientIP = HttpContext.Current.Request.UserHostAddress;
            logger.Info("IP:" + clientIP);
            logger.Info("Current Url:" + Request.RawUrl);
            logger.Info("Header: " + Request.Headers.ToString());
            logger.Info("Current TransactionID: " + ConvertUtility.ToString(Session["transactionid"]));
            //end log 
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect("/P3/Default.aspx");
        }
    }
}