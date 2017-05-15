using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.SQLHelper;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string Msisdn = ConvertUtility.ToString(Request.QueryString["msisdn"]);
            string ID = ConvertUtility.ToString(Request.QueryString["id"]);
            string Type = ConvertUtility.ToString(Request.QueryString["type"]);
            string ck = ConvertUtility.ToString(Request.QueryString["ck"]);
            string md5 = SecurityMethod.MD5Encrypt(Msisdn + ID);
            string model = AppEnv.GetUserAgent();

            if (Msisdn != String.Empty)
            {
                Session["msisdn"] = Msisdn;
                if (!string.IsNullOrEmpty(Msisdn) && MobileUtils.CheckOperator(Msisdn, "vietnammobile"))
                {
                    Session["telco"] = Constant.T_Vietnamobile;                                    

                }
                else
                {
                    Session["msisdn"] = null;
                    Session["telco"] = Constant.T_Undefined;
                }
                //CheckSum
                string str_check = Msisdn + ID;
                if (SecurityMethod.MD5Encrypt(str_check) == ck)
                {
                    //Check ID dịch vụ
                    if (ID != string.Empty)
                    {
                        DataTable dt = S2_TTKD_ServiceConfig_GetInfo(ConvertUtility.ToInt32(ID));
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            string Link_Detail_Smartphone = dt.Rows[0]["Link_Detail_Smartphone"].ToString();
                            string Link_Default_Smartphone = dt.Rows[0]["Link_Default_Smartphone"].ToString();
                            string Link_Detail = dt.Rows[0]["Link_Detail"].ToString();
                            string Link_Default = dt.Rows[0]["Link_Default"].ToString();
                            if (Type != String.Empty)
                            {
                                if (model == "high")
                                {
                                    Response.Redirect(Link_Detail_Smartphone);
                                }
                                else
                                {
                                    Response.Redirect(Link_Detail);
                                    //Response.Redirect(Link_Detail_Smartphone);
                                }
                                //Vào trang chi tiết
                                //lblStatus.Text = "Vào trang chi tiết";
                                //Response.Redirect(LinkDetail);
                            }
                            else
                            {
                                if (model == "high")
                                {
                                    Response.Redirect(Link_Default_Smartphone);
                                }
                                else
                                {
                                    Response.Redirect(Link_Default);
                                    //Response.Redirect(Link_Default_Smartphone);
                                }
                                //Vào trang mặc định
                                //lblStatus.Text = "Vào trang mặc định";
                                //Response.Redirect(LinkDefault);
                            }
                        }

                    }
                    else
                    {
                        //Lỗi ko có ID dịch vụ
                        //lblStatus.Text = "Lỗi ko có ID dịch vụ";
                        lblAlert.Text = "Lỗi ko có ko có dịch vụ, vui lòng xem lại !";
                        litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
                    }
                }
                else
                {
                    //Lỗi MD5(msisdn+id) != ck
                    //lblStatus.Text = "Lỗi MD5(msisdn+id) != ck";
                    lblAlert.Text = "Số điện thoại hoặc dịch vụ không đúng, vui lòng xem lại !";
                    litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");
                }
            }
            else
            {
                //Thông báo ko có SĐT
                //lblStatus.Text = "Lỗi ko có ko có SĐT";
                //lblAlert.Text = "Lỗi ko có ko có số điện thoại, vui lòng xem lại !";
                //litScript.Text = ("<script type=\"text/javascript\">$(function () {$(\"#popup-login\").modal(); }) </script>");

            }
        }



        #region Method
        //public static DataTable S2_TTKD_ServiceConfig_GetInfo(int Service_Id)
        //{
        //    DataSet ds = SqlHelper.ExecuteDataset(AppEnv.GetConnectionString("ConnectionString_TTND_Services"), CommandType.Text,
        //                String.Format("Select Link_Detail_Smartphone,Link_Default_Smartphone,Link_Detail,Link_Default from S294x_ServiceConfig where Service_Id = " + Service_Id + ""));
        //    if (ds != null && ds.Tables.Count > 0)
        //        return ds.Tables[0];
        //    return null;
        //}
        public static DataTable S2_TTKD_ServiceConfig_GetInfo(int Service_Id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(AppEnv.GetConnectionString("ConnectionString_TTND_Services")
                                                , "S294x_ServiceConfig_GetInfo", Service_Id);

            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #endregion
    }
}