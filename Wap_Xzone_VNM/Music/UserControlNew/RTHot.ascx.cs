using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlNew
{
    public partial class RTHot : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            if(lang == 1)
            {
                litGia.Text = "(Giá: " + AppEnv.GetSetting("ringtoneprice") + " đ/nhạc chuông)";
            }
            else
            {
                litGia.Text = "(Gia: " + AppEnv.GetSetting("ringtoneprice") + " d/nhac chuong)";
            }

            DataTable dtHottest = Library.Component.Music.MusicController.GetItemTopByAlbum(3, Session["telco"].ToString(), 20);
            Random rnd = new Random();
            while (dtHottest.Rows.Count > 3)
            {
                dtHottest.Rows.RemoveAt(rnd.Next(0, dtHottest.Rows.Count));
                dtHottest.AcceptChanges();
            }
            rptMusic.DataSource = dtHottest;
            rptMusic.ItemDataBound += rptMusic_ItemDataBound;
            rptMusic.DataBind();
        }

        protected void rptMusic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal) e.Item.FindControl("litBlank");
                if(lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"f5f5f5\"><tr><td align=\"left\" valign=\"top\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}