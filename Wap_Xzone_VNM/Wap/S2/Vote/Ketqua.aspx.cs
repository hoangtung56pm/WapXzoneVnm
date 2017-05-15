using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.Vote
{
    public partial class Ketqua : BasePage
    {
        private int width;
        private string lang;
        private string price;
        private string logPrice;

        private string madichvu;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            madichvu = Request.QueryString["t"];
            madichvu = madichvu.ToUpper().Trim();

            //int votePrice = 2000;
            price = "5000";

            if (!Page.IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                        litMsisdn.Text = "Xin chào <b>" + msisdn + "</b>";
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                        litMsisdn.Text = "Xin chào <b>khách</b>";
                    }
                }

                string messageReturn;
                int votePersonId = 1;

                if (Session["msisdn"] != null)
                {

                    #region Xu Ly Charging

                    var charging = new Library.VNMCharging.VNMChargingGW();

                    

                    //if (AppEnv.GetSetting("TestFlag") == "1")
                    //{
                    //    messageReturn = "1";
                    //}
                    //else
                    //{
                    //messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price.ToString(), "D", "VID", "Vote " + madichvu);
                    //}

                    //var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Vote " + madichvu);

                    if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                    {
                        messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Vote " + madichvu, out logPrice);
                        price = logPrice;
                    }

                    //pnlSMS.Visible = false;
                    //pnlThongBao.Visible = false;
                    //pnlNoiDung.Visible = true;

                    if(messageReturn == "1")//Charged Thanh Cong
                    {
                        
                        int disLike = 0;
                        int dislikePersonId = 1;
                        string personName = "";

                        if (madichvu == "VOTE1")
                        {
                            votePersonId = 1;
                            disLike = 0;
                            personName = "Mai Thỏ";
                        }
                        else if(madichvu == "VOTE2")
                        {
                            votePersonId = 2;
                            disLike = 0;
                            personName = "Linh Miu";
                        }
                        else if(madichvu == "GACH1")
                        {
                            votePersonId = 2;
                            dislikePersonId = 1;
                            disLike = 1;
                            personName = "Mai Thỏ";
                        }
                        else if(madichvu == "GACH2")
                        {
                            votePersonId = 1;
                            dislikePersonId = 2;
                            disLike = 1;
                            personName = "Linh Miu";
                        }

                        var entity = new VoteRegisteredInfo();
                        entity.User_ID = Session["msisdn"].ToString();
                        entity.Request_ID = "0";
                        entity.Service_ID = "8279";
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

                        entity.Vote_PersonId = votePersonId;
                        entity.IsDislike = disLike;
                        entity.Dislike_Count = 1;
                        entity.Dislike_PersonId = dislikePersonId;

                        if(madichvu == "VOTE1" || madichvu == "VOTE2")
                        {
                            DataTable dt = WapController.VoteRegisterInsert(entity);
                            if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                            {
                                litThongBao.Text = "Chúc mừng bạn đã đăng ký thành công Gameshow 'Hẹn hò cùng thần tượng'.<br /> Hãy vote cho " + personName + " để trở thành người chiến thắng.<br /> Chi tiết truy cập http://wap.vietnamobile.com.vn. HT: 19001255";
                            }
                            else if (dt.Rows[0]["RETURN_ID"].ToString() == "1")
                            {
                                //litThongBao.Text = "Bạn đã vote thành công cho " + personName + ".<br /> Vote càng nhiều bạn càng có cơ hội là 1 trong 3 người hẹn hò thần tượng.<br /> Soạn: Vote1 gửi 8279 để gặp Mai Thỏ. Soạn: Vote2 gửi 8279 để gặp Linh Miu<br /> Chi tiết truy cập: http://wap.vietnamobile.com.vn. HT: 19001255";

                                //DataTable dtVoteInfo = WapController.VoteGetCount(Session["msisdn"].ToString(), madichvu);
                                //if (dtVoteInfo.Rows[0]["Count"].ToString() == "0")
                                //{
                                    int revotePersonId = 0;
                                    if(madichvu == "VOTE2")
                                    {
                                        revotePersonId = 2;
                                    }
                                    else if(madichvu == "VOTE1")
                                    {
                                        revotePersonId = 1;
                                    }
                                    DataTable dtVoteInfo = WapController.VoteGetCountByPersonId(Session["msisdn"].ToString(), revotePersonId);
                                //}

                                litThongBao.Text = "Bạn đã vote thành công cho : " + dtVoteInfo.Rows[0]["Name"] + ".<br /> Số lượt vote của bạn : " + dtVoteInfo.Rows[0]["Count"] + "<br /> Bạn đang thuộc top : " + dtVoteInfo.Rows[0]["Top"] + " những người vote nhiều nhất <br /> Vote càng nhiều bạn càng có cơ hội là 1 trong 4 người hẹn hò thần tượng.<br /> Chi tiết truy cập: http://wap.vietnamobile.com.vn. HT: 19001255";

                            }
                        }
                        else if(madichvu == "GACH1" || madichvu == "GACH2")
                        {
                            DataTable dtDislike = WapController.VoteRegisterDislikeInsert(entity);
                            DataTable dt = WapController.VoteRegisterInsert(entity);
                            if (dt.Rows[0]["RETURN_ID"].ToString() == "0")//DK DICH VU LAN DAU
                            {
                                litThongBao.Text = "Chúc mừng bạn đã đăng ký thành công Gameshow 'Hẹn hò cùng thần tượng'.<br /> Hãy ném gạch " + personName + " mà bạn không thích để trở thành người chiến thắng.<br /> Chi tiết truy cập: http://wap.vietnamobile.com.vn. HT: 19001255";
                            }
                            else if (dt.Rows[0]["RETURN_ID"].ToString() == "1")
                            {
                                //litThongBao.Text = "Bạn đã Ném gạch " + personName + " thành công.<br /> Ném gạch càng nhiều bạn có cơ hội là 1 trong 3 người hẹn hò thần tượng.<br /> Soạn: Gach1 gửi 8279 để gặp gỡ Linh Miu. Soạn: Gach2 gửi 8279 để gặp Mai Thỏ .<br /> Chi tiết truy cập:  http://wap.vietnamobile.com.vn. HT: 19001255";

                                DataTable dtGachInfo = WapController.VoteGetCount(Session["msisdn"].ToString(), madichvu);
                                litThongBao.Text = "Bạn đã ném gạch " + dtGachInfo.Rows[0]["Name"] + " thành công .<br />Số Gạch của bạn : " + dtGachInfo.Rows[0]["Count"] + "<br /> Bạn đang thuộc top: " + dtGachInfo.Rows[0]["Top"] + " những người Ném Gạch nhiều nhất <br />Ném Gạch càng nhiều bạn càng có cơ hội là 1 trong 4 người hẹn hò thần tượng.<br /> Chi tiết truy cập : http://wap.vietnamobile.com.vn. HT: 19001255";

                            }
                        }

                        //#region Log Doanh Thu

                        //var eLog = new VoteChargedUserLogInfo();

                        //eLog.User_ID = Session["msisdn"].ToString(); ;
                        //eLog.Request_ID = "0";
                        //eLog.Service_ID = "8279";
                        //eLog.Command_Code = madichvu;
                        //eLog.Service_Type = 1;
                        //eLog.Charging_Count = 0;
                        //eLog.FailedChargingTime = 0;
                        //eLog.RegisteredTime = DateTime.Now;
                        //eLog.ExpiredTime = DateTime.Now.AddDays(1);
                        //eLog.Registration_Channel = "WAP";
                        //eLog.Status = 1;
                        //eLog.Operator = "vnmobile";
                        //eLog.Reason = "Succ";
                        //eLog.Price = 2000;
                        //eLog.Vote_PersonId = votePersonId;

                        //WapController.VoteChargedUserLogInsert(eLog);

                        //#endregion

                    }
                    else
                    {
                        litThongBao.Text = lang == "1" ? "Đăng ký không thành công. Vui lòng thử loại hoặc tài khoản không đủ tiền" : "Dang ky khong thanh cong. Vui long thu lai hoac tai khoan khong du tien";
                    }

                    #region Log Doanh Thu

                    var eLog = new VoteChargedUserLogInfo();

                    eLog.User_ID = Session["msisdn"].ToString(); ;
                    eLog.Request_ID = "0";
                    eLog.Service_ID = "8279";
                    eLog.Command_Code = madichvu;
                    eLog.Service_Type = 1;
                    eLog.Charging_Count = 0;
                    eLog.FailedChargingTime = 0;
                    eLog.RegisteredTime = DateTime.Now;
                    eLog.ExpiredTime = DateTime.Now.AddDays(1);
                    eLog.Registration_Channel = "WAP";
                    eLog.Status = 1;
                    eLog.Operator = "vnmobile";

                    if(messageReturn == "1")
                        eLog.Reason = "Succ";
                    else
                        eLog.Reason = messageReturn;

                    eLog.Price = ConvertUtility.ToInt32(price);
                    eLog.Vote_PersonId = votePersonId;

                    WapController.VoteChargedUserLogInsert(eLog);

                    #endregion

                    #endregion
                }
                else
                {

                    if (madichvu == "VOTE1" || madichvu == "VOTE2" || madichvu == "GACH1" || madichvu == "GACH2")
                    {
                        litThongBao.Text = "Hệ thống không xác định được số điện thoại của bạn.<br /> Vui lòng truy cập bằng 3G/GPRS<br /> Hoặc soạn tin: " + madichvu + " gửi " + "8279"; ;
                    }
                    else
                    {
                        litThongBao.Text = "Hệ thống không xác định được số điện thoại của bạn.<br /> Vui lòng truy cập bằng 3G/GPRS";
                    }

                    //litThongBao.Text = "Hệ thống không xác định được số điện thoại của bạn.<br /> Vui lòng truy cập bằng 3G/GPRS <br /> Hoặc soạn tin: " + madichvu + " gửi " + "8279";

                    //pnlSMS.Visible = true;
                    //if (lang == "1")
                    //{
                    //    ltrHuongdan.Text = "Thông Báo";
                    //    ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng 3G/GPRS hoặc soạn tin: " + madichvu + " gửi " + "8279";
                    //}
                    //else
                    //{
                    //    ltrHuongdan.Text = "Thong Bao";
                    //    ltrSMS.Text =
                    //        "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang 3G/GPRS hoac soan tin " + madichvu + " gui " + "8279";
                    //}
                }

                DataSet dsMt = WapController.GetTopUserVote(1);
                DataSet dsLm = WapController.GetTopUserVote(2);

                //DataTable dtMt = WapController.GetTopUserVote(1);
                //DataTable dtLm = WapController.GetTopUserVote(2);

                if (dsMt != null && dsMt.Tables[0].Rows.Count > 0)
                {
                    rptMaiTho.DataSource = dsMt.Tables[0];
                    rptMaiTho.DataBind();

                    lblMtLike.Text = dsMt.Tables[1].Rows[0]["Like"].ToString();
                    lblMtUnLike.Text = dsMt.Tables[2].Rows[0]["UnLike"].ToString();
                }

                if (dsLm != null && dsLm.Tables[0].Rows.Count > 0)
                {
                    rptLinhMiu.DataSource = dsLm.Tables[0];
                    rptLinhMiu.DataBind();

                    lblLmLike.Text = dsLm.Tables[1].Rows[0]["Like"].ToString();
                    lblLmUnLike.Text = dsLm.Tables[2].Rows[0]["UnLike"].ToString();
                }

                #region FACEBOOK Comment

                string url = AppEnv.GetSetting("WapDefault") + "/vote.aspx";

                ltCommentFB.Text = "<div class=\"fb-comments\" data-mobile=\"false\" data-href='" + url + "' data-width=\"320\" data-num-posts=\"5\"></div>";

                string Facebook_raw_data = get_web_content("http://api.facebook.com/restserver.php?method=links.getStats&urls=" + url);

                XmlDocument dom = new XmlDocument();
                dom.LoadXml(Facebook_raw_data);

                #endregion
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
           
        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            //pnlNoiDung.Visible = true;
            //if (thuchien)
            //{
            //    if (lang == "1")
            //    {
            //        ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ " + GetName(madichvu) + ". Kết quả sẽ được gửi đến điện thoại của bạn hàng tuần ngay sau khi trận đấu kết thúc";
            //    }
            //    else
            //    {
            //        ltrNoiDung.Text = "Ban da dang ky thanh cong dich vu " + UnicodeUtility.UnicodeToKoDau(GetName(madichvu)) + ". Ket qua se duoc gui den dien thoai cua ban hang tuan ngay sau khi tran dau ket thuc";
            //    }
            //}
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            //Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));

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