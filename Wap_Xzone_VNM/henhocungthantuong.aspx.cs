using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM
{
    public partial class henhocungthantuong : BasePage
    {
        protected string Msisdn;
        protected void Page_Load(object sender, EventArgs e)
        {

            Response.Redirect("vote.aspx");

            if (!Page.IsPostBack)
            {
                //if (AppEnv.GetSetting("TestFlag") == "1")
                //{
                //    Session["telco"] = Constant.T_Vietnamobile;
                //    Session["msisdn"] = "84929004805";
                //    Msisdn = Session["msisdn"].ToString();
                //}

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

                //DataTable dtMt = WapController.GetTopUserVote(1);
                //DataTable dtLm = WapController.GetTopUserVote(2);

                //if(dtMt != null && dtMt.Rows.Count > 0)
                //{
                //    rptMaiTho.DataSource = dtMt;
                //    rptMaiTho.DataBind();
                //}

                //if (dtLm != null && dtLm.Rows.Count > 0)
                //{
                //    rptLinhMiu.DataSource = dtLm;
                //    rptLinhMiu.DataBind();
                //}

            }
        }
    }
}