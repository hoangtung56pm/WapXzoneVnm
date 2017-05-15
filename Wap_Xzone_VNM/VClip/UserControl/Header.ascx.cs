using System;
using System.Data;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.VClip.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        public string Msisdn;
        protected int lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            }
            if (Session["msisdn"] != null)
            {
                if (Session["telco"].ToString() == Constant.T_Undefined)
                {
                    Msisdn = "Khách";
                }
                else
                {
                    Msisdn = Session["msisdn"].ToString();
                }
            }
            else
            {
                Msisdn = "Khách";
            }

        }
    }
}