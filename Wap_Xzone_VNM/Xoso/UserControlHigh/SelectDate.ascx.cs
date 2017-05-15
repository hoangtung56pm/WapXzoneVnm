using System;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.UserControlHigh
{
    public partial class SelectDate : System.Web.UI.UserControl
    {

        private string lang;
        private int width;
        private string cipher;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            lang = Request.QueryString["lang"];
            cipher = Request.QueryString["link"];
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!IsPostBack)
            {
                if (lang == "1")
                {
                    dropDay.Items.Add(new ListItem(" Ngày mở thưởng ", "0"));
                    Button1.Text = "Chọn";
                }
                else
                {
                    dropDay.Items.Add(new ListItem(" Ngay mo thuong ", "0"));
                }
                for (int i = 1; i < 8; i++)
                {
                    dropDay.Items.Add(new ListItem(ConvertUtility.ToDateTime(DateTime.Now.AddDays(-i)).ToString("dd/MM/yyyy"), i.ToString()));
                }
                dropDay.SelectedValue = Request.QueryString["day"];
            }
        }
        protected void dropDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Response.Redirect(UrlProcess.GetXosoHomeUrl(lang, width.ToString()) + "&day=" + dropDay.SelectedValue);
            string url = UrlProcess.XoSoHome() + "?day=" + dropDay.SelectedValue;
            Response.Redirect(url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect(UrlProcess.GetXosoHomeUrl(lang, width.ToString()) + "&day=" + dropDay.SelectedValue);
            string url = UrlProcess.XoSoHome() + "?day=" + dropDay.SelectedValue;
            Response.Redirect(url);
        }

    }
}