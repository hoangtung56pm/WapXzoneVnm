using System;
using System.Data;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class StyleDetail : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private string StyleID;
        protected void Page_Load(object sender, EventArgs e)
        {

            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            StyleID = Request.QueryString["id"].ToString();

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            //start category list
            int totalrecord = 0;
            DataTable dtCat = MusicController.GetItemByStyleHasCache(Session["telco"].ToString(), StyleID, curpage, pagesize, out totalrecord);
            rptList.DataSource = dtCat;
            //rptList.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptList.DataBind();
            
            if (!IsPostBack)
            {
                DataTable StyleInfo = MusicController.GetStyleByIDHasCache(StyleID);
                if (StyleInfo.Rows.Count > 0)
                {
                    //if (lang == "1")
                    //{
                    ltrStyleName.Text = StyleInfo.Rows[0]["StyleNameUnicode"].ToString();
                    string name = StyleInfo.Rows[0]["StyleName"].ToString();

                    //    ltrSobai.Text = Resources.Resource.wSoBai + totalrecord.ToString();
                    //}
                    //else
                    //{
                    //    ltrStyleName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + StyleInfo.Rows[0]["StyleName"].ToString() + "</span>";
                    //    ltrSobai.Text = Resources.Resource.wSoBai_KD + totalrecord.ToString();
                    //}

                    Paging1.totalrecord = totalrecord;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = UrlProcess.AmNhacChuyenMucTheLoaiList(StyleID, name, curpage.ToString());
                    Paging1.queryparam = UrlProcess.AmNhacChuyenMucTheLoaiList(StyleID, name, curpage.ToString());
                }
            }
        }
    }
}