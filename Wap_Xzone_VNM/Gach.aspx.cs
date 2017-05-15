using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM
{
    public partial class Gach : BasePage
    {

        private int width;
        private string lang;
        private string price;
        private string logPrice;

        private string madichvu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                        ltrXinChao.Text = "Xin chào <b>" + msisdn + "</b>";
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                        ltrXinChao.Text = "Xin chào <b>khách</b>";
                    }
                }
                else
                {
                    ltrXinChao.Text = "Xin chào <b>" + Session["msisdn"] + "</b>";
                }

                #region Xử lý ĐẶT GẠCH

                string message = string.Empty;
                string serviceId = "8379";
                madichvu = Request.QueryString["t"];
                madichvu = madichvu.ToUpper();

                string regisChannel = "WAP";
                if(madichvu == "GACH1")
                {
                    regisChannel = "VMG1";
                }
                else if(madichvu == "GACH2")
                {
                    regisChannel = "VMG2";
                }
                else if(madichvu == "GACH3")
                {
                    regisChannel = "VMG3";
                }

                madichvu = madichvu.Replace("1", "").Replace("2", "").Replace("3", "");

                if(!string.IsNullOrEmpty(madichvu))
                {
                    madichvu = madichvu.ToUpper().Trim();

                    if (Session["msisdn"] != null)
                    {
                        price = "5000";
                        string messageReturn;

                        var charging = new Library.VNMCharging.VNMChargingGW();
                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Vote " + madichvu);

                        if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                        {
                            messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Vote " + madichvu, out logPrice);
                            price = logPrice;
                        }

                        if (messageReturn == "1")//Charged Thanh Cong
                        {
                            #region DK USER

                            var entity = new VoteRegisteredInfo();
                            entity.User_ID = Session["msisdn"].ToString();
                            entity.Request_ID = "0";
                            entity.Service_ID = serviceId;
                            entity.Command_Code = madichvu;
                            entity.Service_Type = 1;
                            entity.Charging_Count = 0;
                            entity.FailedChargingTime = 0;
                            entity.RegisteredTime = DateTime.Now;
                            entity.ExpiredTime = DateTime.Now.AddDays(1);
                            entity.Registration_Channel = regisChannel;
                            entity.Status = 1;
                            entity.Operator = "vnmobile";
                            entity.Vote_Count = 1;

                            entity.Vote_PersonId = 1;
                            entity.IsDislike = 0;
                            entity.Dislike_Count = 1;
                            entity.Dislike_PersonId = 0;
                            DataTable dt = WapController.SecretRegisterInsert(entity);

                            if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                            {
                                litThongBao.Text = "Chúc mừng bạn đã đăng ký thành công Gameshow 'BÍ MẬT ĐỘNG TRỜI CỦA MAI THỎ'.<br /> Hãy đặt gạch càng nhiều để có cơ hội hẹn hò và biết bí mật đằng sau của Mai Thỏ là gì.<br /> Chi tiết truy cập http://wap.vietnamobile.com.vn. HT: 19001255";
                            }
                            else if (dt.Rows[0]["RETURN_ID"].ToString() == "1")
                            {
                                DataTable dtVoteInfo = WapController.SecretGetCountByPersonId(Session["msisdn"].ToString(), 1);
                                litThongBao.Text = "Bạn đã ĐẶT GẠCH thành công cho : " + dtVoteInfo.Rows[0]["Name"] + ".<br /> Số lượt GẠCH của bạn : " + dtVoteInfo.Rows[0]["Count"] + "<br /> Bạn đang thuộc top : " + dtVoteInfo.Rows[0]["Top"] + " những người ĐẶT GẠCH nhiều nhất <br /> ĐẶT GẠCH càng nhiều bạn càng có cơ hội hẹn hò và biết bí mật đằng sau của Mai Thỏ là gì.<br /> Chi tiết truy cập: http://wap.vietnamobile.com.vn. HT: 19001255";
                            }

                            #endregion
                        }
                        else
                        {
                            litThongBao.Text = lang == "1" ? "Đăng ký không thành công. Vui lòng thử loại hoặc tài khoản không đủ tiền" : "Dang ky khong thanh cong. Vui long thu lai hoac tai khoan khong du tien";
                        }

                        #region Log Doanh Thu

                        var eLog = new VoteChargedUserLogInfo();

                        eLog.User_ID = Session["msisdn"].ToString();
                        eLog.Request_ID = "0";
                        eLog.Service_ID = serviceId;
                        eLog.Command_Code = madichvu;
                        eLog.Service_Type = 1;
                        eLog.Charging_Count = 0;
                        eLog.FailedChargingTime = 0;
                        eLog.RegisteredTime = DateTime.Now;
                        eLog.ExpiredTime = DateTime.Now.AddDays(1);
                        eLog.Registration_Channel = regisChannel;
                        eLog.Status = 1;
                        eLog.Operator = "vnmobile";

                        if (messageReturn == "1")
                            eLog.Reason = "Succ";
                        else
                            eLog.Reason = messageReturn;

                        eLog.Price = ConvertUtility.ToInt32(price);
                        eLog.Vote_PersonId = 1;

                        WapController.SecretChargedUserLogInsert(eLog);

                        #endregion

                    }
                    else
                    {
                        if (madichvu == "GACH")
                        {
                            message = "Hệ thống không xác định được số điện thoại của bạn.<br /> Vui lòng truy cập bằng 3G/GPRS<br /> Hoặc soạn tin: " + madichvu + " gửi " + serviceId;
                            litThongBao.Text = message;
                        }
                        else
                        {
                            message =
                                "Hệ thống không xác định được số điện thoại của bạn.<br /> Vui lòng truy cập bằng 3G/GPRS";
                            litThongBao.Text = message;
                        }
                    }
                }

                
                #endregion

                DataSet dsMt = WapController.SecretGetTopUserVote(1);

                if (dsMt != null && dsMt.Tables[0].Rows.Count > 0)
                {
                    rptMaiTho.DataSource = dsMt.Tables[0];
                    rptMaiTho.DataBind();
                    lblMtUnLike.Text = dsMt.Tables[1].Rows[0]["Like"].ToString();

                    rptLinhMiu.DataSource = dsMt.Tables[0];
                    rptLinhMiu.DataBind();
                    lblLmUnLike.Text = dsMt.Tables[1].Rows[0]["Like"].ToString();
                }

                #region FACEBOOK Comment

                string url = AppEnv.GetSetting("WapDefault") + Request.RawUrl;

                ltCommentFB.Text = "<div class=\"fb-comments\" data-mobile=\"false\" data-href='" + url + "' data-width=\"320\" data-num-posts=\"5\"></div>";

                string Facebook_raw_data = get_web_content("http://api.facebook.com/restserver.php?method=links.getStats&urls=" + url);

                XmlDocument dom = new XmlDocument();
                dom.LoadXml(Facebook_raw_data);

                #endregion

            }
        }

        public string get_web_content(string url)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.Method = WebRequestMethods.Http.Get;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string output = reader.ReadToEnd();
            response.Close();

            return output;
        }

    }
}