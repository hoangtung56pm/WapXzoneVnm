using System;
using System.Data;
using System.IO;
using System.Net;
using System.Xml;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM
{
    public partial class vote : System.Web.UI.Page
    {
        protected string Msisdn;
        protected void Page_Load(object sender, EventArgs e)
        {
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