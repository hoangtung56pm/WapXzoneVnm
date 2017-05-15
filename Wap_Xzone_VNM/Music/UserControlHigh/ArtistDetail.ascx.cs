using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Music;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Music.UserControlHigh
{
    public partial class ArtistDetail : System.Web.UI.UserControl
    {

        private int pagesize = 10;
        private int pagenumber = 3;
        private int curpage = 1;
        private string lang;
        private string width;
        private string artistID;

        protected void Page_Load(object sender, EventArgs e)
        {

            artistID = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(Request.QueryString["cpage"]))
            {
                curpage = ConvertUtility.ToInt32(Request.QueryString["cpage"]);
            }
            
            if (!IsPostBack)
            {
                DataTable ArtistInfo = MusicController.GetArtistByIDHasCache(artistID);
                string name = string.Empty;
                if (ArtistInfo.Rows.Count > 0)
                {
                    //if (lang == "1")
                    //{
                        ltrArtistName.Text = ArtistInfo.Rows[0]["ArtistNameUnicode"].ToString();
                        //ltrSobai.Text = Resources.Resource.wSoBai + totalrecord.ToString();
                        name = ArtistInfo.Rows[0]["ArtistName"].ToString();
                    //}
                    //else
                    //{
                    //    ltrArtistName.Text = "<span class=\"bold\" style=\"color:#B200B2;\">" + ArtistInfo.Rows[0]["ArtistName"].ToString() + "</span>";
                    //    ltrSobai.Text = Resources.Resource.wSoBai_KD + totalrecord.ToString();
                    //}
                }

                //start category list
                int totalrecord = 0;
                DataTable dtCat = MusicController.GetItemByArtistHasCache(AppEnv.CheckSessionTelco(), artistID, curpage, pagesize, out totalrecord);
                rptList.DataSource = dtCat;
                //rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
                rptList.DataBind();
                Paging1.totalrecord = totalrecord;
                Paging1.pagesize = pagesize;
                Paging1.numberpage = pagenumber;
                Paging1.defaultparam = UrlProcess.AmNhacChuyenMucCaSyList(artistID, name, curpage.ToString());
                Paging1.queryparam = UrlProcess.AmNhacChuyenMucCaSyList(artistID, name, curpage.ToString());

            }

        }
    }
}