using System;
using System.Web.UI;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.DichvuTet
{
    public partial class DauTri : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {

                //Session["msisdn"] = "0988888888";

                //if(AppEnv.isMobileBrowser())
                //{
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

                    if (Session["msisdn"] != null)
                    {
                        string code = Request.QueryString["c"];
                        if (!string.IsNullOrEmpty(code))
                        {
                            #region CALL Andy Webservice

                            string strResult = AppEnv.DangKyDinhVuTet(Session["msisdn"].ToString(), "DT gửi 1119", "DT");
                            if (strResult == "0")
                            {
                                pnlThanhCong.Visible = true;
                                litThanhCong.Text = "Đăng ký thành công. Hàng ngày hệ thống sẽ gửi câu hỏi về máy điện thoại của bạn !";
                            }
                            else if (strResult == "1")
                            {
                                pnlThanhCong.Visible = true;
                                litThanhCong.Text = "Bạn đã đăng ký dịch vụ này rồi. Xin cảm ơn !";
                            }
                            else
                            {
                                pnlThanhCong.Visible = true;
                                litThanhCong.Text = "Hệ thống đang bận. Xin vui lòng thử lại sau !";
                            }

                            #endregion
                        }
                        else
                        {
                            pnlThongBao.Visible = true;
                        }
                    }
                    else
                    {
                        pnlThongBaoSoanSms.Visible = true;
                    }
                //}
                //else
                //{
                //    pnlThongBaoWeb.Visible = true;
                //}
            }
        }
    }
}