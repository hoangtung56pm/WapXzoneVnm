using System;
using System.Data;
using System.IO;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.Hot
{
    public partial class DocTruyen : BasePage
    {
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!Page.IsPostBack)
        //    {
        //        if (Session["msisdn"] == null)
        //        {
        //            int is3g = 0;
        //            string msisdn = MobileUtils.GetMSISDN(out is3g);
        //            if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
        //            {
        //                Session["telco"] = Constant.T_Vietnamobile;
        //                Session["msisdn"] = msisdn;
        //            }
        //            else
        //            {
        //                Session["msisdn"] = null;
        //                Session["telco"] = Constant.T_Undefined;
        //            }
        //        }

        //        string url = "/Thugian/Default.aspx?display=home&w=320&lang=1";
        //        if (Session["msisdn"] != null)
        //        {
        //            AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK DTR");
        //            //string value = AppEnv.Dk1RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK1", "DK1 DTR");//Andy Service
        //        }

        //        Response.Redirect(url);
        //    }
        //}
        ILog logger = LogManager.GetLogger(typeof(DocTruyen));
        private int width;
        private string lang;
        protected FileInfo[] files;
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Debug("----------");
            lang = Request.QueryString["lang"];
            if (string.IsNullOrEmpty(lang))
            {
                Response.Redirect("/Thugian/Hot/DocTruyen.aspx?w=320&lang=1");
            }

            Session["LastPage"] = Request.RawUrl;

            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                #region TU DONG DK SUB DOC TRUYEN

                if (!Page.IsPostBack)
                {
                    if (Session["msisdn"] == null)
                    {
                        int is3g;
                        string msisdn = MobileUtils.GetMSISDN(out is3g);
                        logger.Debug("msisdn:" + msisdn);
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
                        string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK TR");//ANDY Service S2_94x
                        string[] res = value.Split('|');
                        if (res.Length > 0)
                        {
                            if (res[0] == "1")//DK THANH CONG
                            {
                                pnlThongBao.Visible = true;
                            }
                        }
                    }

                    Session["ChargedSub"] = "1";
                }

                #endregion

                DataTable dt = TintucController.GetTopRandomForDtr();
                if (dt != null && dt.Rows.Count > 0)
                {
                    rptDocTruyen.DataSource = dt;
                    rptDocTruyen.DataBind();
                }
            }
        }

    }
}