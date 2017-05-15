using System;
using System.Data;
using WapXzone_VNM.VClip.Library;
using WapXzone_VNM.VClip.Library.UrlProcess;
using System.Web;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.VClip.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {
        protected string Back;
        protected int lang;
        protected string width;
        protected int id;
        protected string Description;

        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (!Page.IsPostBack)
            {
                if (Request.UrlReferrer != null) hplBack.NavigateUrl = Request.UrlReferrer.ToString();

                //Detail
                DataTable dtDetail = VideoController.GetVideoDetailByIDHasCache(Session["telco"].ToString(), id);
                if (dtDetail != null && dtDetail.Rows.Count > 0)
                {
                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    Description = dtDetail.Rows[0]["VDescription_Unicode"].ToString();

                    int totaltopdownload = 0;
                    DataTable dtltopdownload = VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_VCategoryID"]), id, 0, 6, 1, out totaltopdownload);
                    foreach (DataRow iRow in dtltopdownload.Rows)
                    {
                        if ((int)iRow["W_VItemID"] == id)
                        {
                            iRow.Delete();
                            dtltopdownload.AcceptChanges();
                            break;
                        }
                    }

                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.DataBind();

                    lblDownPrice.Text = AppEnv.GetSetting("TaiMacDinh") + "đ";
                    lblViewPrice.Text = AppEnv.GetSetting("XemMacDinh") + "đ";
                }
            }
        }

        public void rptDetail_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Play")
            {
                if (ConvertUtility.ToString(Session["msisdn"]).ToString() == "")
                {
                    string url = UrlProcess.GetVideoSmsUrl(lang.ToString(), width);

                    Response.Redirect(url);
                }

                id = ConvertUtility.ToInt32(e.CommandArgument);

                Response.Redirect("http://wap.vietnamobile.com.vn/VClip/View.aspx?id=" + id + "&lang=" + lang + "&w=" + width);
            }
        }

        protected void lnkTaiVeMay_Click(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (ConvertUtility.ToString(Session["msisdn"]).ToString() == "")
            {
                string url = UrlProcess.GetVideoSmsUrl(lang.ToString(), width);

                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("http://wap.vietnamobile.com.vn/VClip/Download.aspx?id=" + id + "&lang=" + lang + "&w=" + width);
            }
        }

        protected void lnkXemOnline_Click(object sender, EventArgs e)
        {
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            if (ConvertUtility.ToString(Session["msisdn"]).ToString() == "")
            {
                string url = UrlProcess.GetVideoSmsUrl(lang.ToString(), width);

                Response.Redirect(url);
            }
            else
            {
                Response.Redirect("http://wap.vietnamobile.com.vn/VClip/View.aspx?id=" + id + "&lang=" + lang + "&w=" + width);
            }
        }

    }
}