using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM
{
    public partial class VoteNew : BasePage
    {
        protected string Msisdn;
        protected string VoteSum;

        private string price;
        private string logPrice;

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
                        //ltrXinChao.Text = "Xin chào <b>" + msisdn + "</b>";
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                        //ltrXinChao.Text = "Xin chào <b>khách</b>";
                    }
                }

                string madichvu = Request.QueryString["t"];
                string message = string.Empty;
                string serviceId = "8579";
                

                if (!string.IsNullOrEmpty(madichvu))
                {
                    if (Session["msisdn"] != null)
                    {
                        price = "5000";
                        string messageReturn;
                        madichvu = madichvu.ToUpper();

                        var charging = new Library.VNMCharging.VNMChargingGW();
                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Vote " + madichvu);

                        if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                        {
                            messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", madichvu, out logPrice);
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
                            entity.Registration_Channel = "WAP";
                            entity.Status = 1;
                            entity.Operator = "vnmobile";
                            entity.Vote_Count = 1;

                            entity.Vote_PersonId = 1;
                            entity.IsDislike = 0;
                            entity.Dislike_Count = 1;
                            entity.Dislike_PersonId = 0;
                            DataTable dt = WapController.NewVoteRegisterInsert(entity);

                            if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                            {
                                litThongBao.Text = "Chúc mừng bạn đã đăng ký thành công Gameshow 'Hẹn Hò cùng Hot Girl'.<br /> Hãy vote để Hẹn Hò với 1 trong 5 Hot Girl Xinh Đẹp";
                            }
                            else if (dt.Rows[0]["RETURN_ID"].ToString() == "1")
                            {
                                DataTable dtVoteInfo = WapController.NewVoteGetUserInfo(Session["msisdn"].ToString());
                                int voteCount = ConvertUtility.ToInt32(dtVoteInfo.Rows[0]["Vote_Count"].ToString());
                                string voteTop = GetTopVote(voteCount);

                                litThongBao.Text = "Số lượt Vote của bạn : " + voteCount + " .<br />Bạn đang thuộc top : " + voteTop + " những người Vote nhiều nhất. <br />Hãy vote để Hẹn Hò với 1 trong 5 Hot Girl Xinh Đẹp";
                            }

                            #endregion
                        }
                        else
                        {
                            litThongBao.Text = "Đăng ký không thành công. Vui lòng thử loại hoặc tài khoản không đủ tiền";
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
                        eLog.Registration_Channel = "WAP";
                        eLog.Status = 1;
                        eLog.Operator = "vnmobile";

                        if (messageReturn == "1")
                            eLog.Reason = "Succ";
                        else
                            eLog.Reason = messageReturn;

                        eLog.Price = ConvertUtility.ToInt32(price);
                        eLog.Vote_PersonId = 1;

                        WapController.NewVoteChargedUserLogInsert(eLog);

                        #endregion

                    }
                    else
                    {
                        if (madichvu == "VOTE1")
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

                DataSet dtVote = WapController.NewGetTopUserVote();
                if (dtVote.Tables[0].Rows.Count > 0)
                {
                    rptTop.DataSource = dtVote.Tables[0];
                    rptTop.DataBind();

                    VoteSum = dtVote.Tables[1].Rows[0]["Like"].ToString();
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

        private static string GetTopVote(int vote)
        {
            string str = "";

            if (vote >= 1 && vote <= 10)
            {
                str = "100";
            }
            else if (vote >= 11 && vote <= 50)
            {
                str = "50";
            }
            else if (vote >= 51)
            {
                str = "10";
            }

            return str;
        }

    }
}