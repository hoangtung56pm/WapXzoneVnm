using System;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso.UserControlNew
{
    public partial class SelectedDate : System.Web.UI.UserControl
    {
        private string lang;
        private int width;
        private string _cipher;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            lang = Request.QueryString["lang"];
            _cipher = Request.QueryString["link"];
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            if (!IsPostBack)
            {
                if (lang == "1")
                {
                    dgrDay.Items.Add(new ListItem(" Ngày mở thưởng ", "0"));
                    //Button1.Text = "Chọn";
                }
                else
                {
                    dgrDay.Items.Add(new ListItem(" Ngay mo thuong ", "0"));
                }
                for (int i = 1; i < 8; i++)
                {
                    dgrDay.Items.Add(new ListItem(ConvertUtility.ToDateTime(DateTime.Now.AddDays(-i)).ToString("dd/MM/yyyy"), i.ToString()));
                }
                dgrDay.SelectedValue = Request.QueryString["day"];
            }

        }

        protected void dgrDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(UrlProcess.GetXosoHomeUrlNew(lang, width.ToString()) + "&day=" + dgrDay.SelectedValue);
        }
    }
}