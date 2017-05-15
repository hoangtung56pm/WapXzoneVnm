using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Xoso.Hot
{
    public partial class ThongKe : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                    }
                }

                string url = UrlProcess.GetXosoHomeUrl("1", "320");
                if (Session["msisdn"] != null)
                {
                    //DK1 GAME gui 949
                    DataTable dt = AppEnv.GetExistUser(Session["msisdn"].ToString(), "TK MB");
                    if (dt != null && dt.Rows.Count > 0)//DA DK ROI
                    {
                        Response.Redirect(url);
                    }
                    else//CHUA DK
                    {
                        var entity = new VnmS2RegisterUserInfo();
                        entity.CommandCode = "DK1";
                        entity.Operator = "VNM";
                        entity.RegisteredChannel = "WAP";
                        entity.RegisteredTime = DateTime.Now;
                        entity.RequestId = "0";
                        entity.ServiceId = "949";
                        entity.Status = 1;
                        entity.SubCode = "TK MB";
                        entity.UserId = Session["msisdn"].ToString();

                        string value = AppEnv.Dk1RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK1", "DK1 TK MB");//Andy Service
                        if(value == "1")//DK THANH CONG
                        {
                            AppEnv.InsertVnmRegisterUser(entity);
                        }
                    }
                }

                Response.Redirect(url);
            }
        }
    }
}