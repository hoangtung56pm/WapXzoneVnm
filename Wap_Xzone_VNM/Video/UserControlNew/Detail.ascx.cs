using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlNew
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int tpage = 1;
        protected int lang;
        protected string width;
        private static string preurl;
        private int id;
        private string price;

        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                  //Detail
                DataTable dtDetail = VideoController.GetVideoDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    lnkCateChannel.NavigateUrl = UrlProcess.GetVideoCategoryUrlNew(lang.ToString(), width, dtDetail.Rows[0]["W_VCategoryID"].ToString());
                    lnkHomeChannel.NavigateUrl = UrlProcess.GetVideoHomeUrlNew(lang.ToString(), width);

                    if (lang == 1)
                    {
                        litGia.Text = "(Giá: " + AppEnv.GetSetting("videoprice") + " đ/video)";
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                    }
                    else
                    {
                        litGia.Text = "(Gia: " + AppEnv.GetSetting("videoprice") + " d/video)";
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                    }

                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    int totaltopdownload = 0;
                    DataTable dtltopdownload = VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), ConvertUtility.ToInt32(dtDetail.Rows[0]["W_VCategoryID"]), id, 0, pagesize, tpage, out totaltopdownload);
                    foreach (DataRow iRow in dtltopdownload.Rows)
                    {
                        if ((int)iRow["W_VItemID"] == id)
                        {
                            iRow.Delete();
                            dtltopdownload.AcceptChanges();
                            break;
                        }
                    }

                    if (dtltopdownload.Rows.Count > 0)
                    {
                        rptVideoCungLoai.DataSource = dtltopdownload;
                        rptVideoCungLoai.ItemDataBound += rptVideoCungLoai_ItemDataBound;
                        rptVideoCungLoai.DataBind();
                    }
                }
            }
        }

        protected void rptVideoCungLoai_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.ItemIndex < 2)
            {
                Literal litBlank = (Literal) e.Item.FindControl("litBlank");
                if(litBlank != null)
                {
                    litBlank.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}