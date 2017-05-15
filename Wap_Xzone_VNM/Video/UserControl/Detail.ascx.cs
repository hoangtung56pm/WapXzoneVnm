using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using System.Data;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;

using WapXzone_VNM.Library;

namespace WapXzone_VNM.Video.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int tpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int id;        
        private string price;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");            
            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            if (!IsPostBack)
            {
                if (ConvertUtility.ToInt32(Request.QueryString["g"]) == 1)
                    txtSoDienThoaiTang.Focus();
                //Detail
                DataTable dtDetail = VideoController.GetVideoDetailByIDHasCache(Session["telco"].ToString(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {                    
                    price = ConfigurationSettings.AppSettings.Get("videoprice");
                    lnkCateChannel.NavigateUrl = UrlProcess.GetVideoCategoryUrl(lang.ToString(), width, dtDetail.Rows[0]["W_VCategoryID"].ToString());
                    lnkHomeChannel.NavigateUrl = UrlProcess.GetVideoHomeUrl(lang.ToString(), width);   
                    if (lang == 1)
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title_Unicode"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["VTitle_Unicode"].ToString();
                        ltrLuottai.Text = Resources.Resource.wLuotTai + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang + price + Resources.Resource.wDonViTien;
                        lnkTai.Text = "<span class=\"bold\">"+ Resources.Resource.wTaiVe + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang;
                        ltrCungTheLoai.Text = Resources.Resource.vVideoCungTheLoai;
                    }
                    else
                    {
                        lnkCateChannel.Text = dtDetail.Rows[0]["Title"].ToString().ToUpper();
                        ltrTenAnh.Text = dtDetail.Rows[0]["VTitle"].ToString();
                        ltrLuottai.Text = Resources.Resource.wLuotTai_KD + dtDetail.Rows[0]["Download"].ToString().ToUpper();
                        //ltrGiaTai.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                        //ltrGiaTang.Text = Resources.Resource.wGiaTang_KD + price + Resources.Resource.wDonViTien_KD;
                        lnkTai.Text = "<span class=\"bold\">" + Resources.Resource.wTaiVe_KD + "</span>";
                        ltrGuiTang.Text = Resources.Resource.wGuiTang_KD;
                        ltrCungTheLoai.Text = Resources.Resource.vVideoCungTheLoai_KD;
                    }
                    lnkTai.NavigateUrl = "../Download.aspx?id=" + dtDetail.Rows[0]["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
                    lnkXem.NavigateUrl = "../View.aspx?id=" + dtDetail.Rows[0]["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
                    WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    ws.GenerateAvatarThumnail(dtDetail.Rows[0]["VThumnail"].ToString(), 120, 90);
                    imgDetail.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["VThumnail"].ToString(), 120, 90).Replace("~", "");
                    //imgDetail.ImageUrl = preurl + dtDetail.Rows[0]["VThumnail"].ToString().Replace("~", "");
                    //Other 
                    if (!string.IsNullOrEmpty(Request.QueryString["tpage"]))
                        tpage = ConvertUtility.ToInt32(Request.QueryString["tpage"]);
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
                    rptCungTheLoai.DataSource = dtltopdownload;
                    rptCungTheLoai.ItemDataBound += new RepeaterItemEventHandler(rptTopdownload_ItemDataBound);
                    rptCungTheLoai.DataBind();
                    Paging1.totalrecord = totaltopdownload;
                    Paging1.pagesize = pagesize;
                    Paging1.numberpage = pagenumber;
                    Paging1.defaultparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"];
                    Paging1.queryparam = "?lang=" + Request.QueryString["lang"] + "&display=" + Request.QueryString["display"] + "&w=" + Request.QueryString["w"] + "&id=" + Request.QueryString["id"] + "&tpage=";
                    //end lastest 
                }
            }
            
        }
        protected void rptTopdownload_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            System.Web.UI.WebControls.Image imgAvatar = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgAvatar");
            HyperLink lnkAvatar = (HyperLink)e.Item.FindControl("lnkAvatar");
            HyperLink lnkTenAnh = (HyperLink)e.Item.FindControl("lnkTenAnh");
            Literal ltrTheloai = (Literal)e.Item.FindControl("ltrTheloai");
            Literal ltrLuottai = (Literal)e.Item.FindControl("ltrLuottai");
            HyperLink lnkTai = (HyperLink)e.Item.FindControl("lnkTai");
            HyperLink lnkTang = (HyperLink)e.Item.FindControl("lnkTang");
            HyperLink lnkXem = (HyperLink)e.Item.FindControl("lnkXem");
            if (lang == 1)
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle_Unicode"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai + curData["Web_Name"].ToString();
                ltrLuottai.Text = Resources.Resource.wLuotTai + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang + "</span>";
            }
            else
            {
                lnkTenAnh.Text = "<span class=\"bold\">" + curData["VTitle"].ToString() + "</span>";
                ltrTheloai.Text = Resources.Resource.wTheLoai_KD + UnicodeUtility.UnicodeToKoDau(curData["Web_Name"].ToString());
                ltrLuottai.Text = Resources.Resource.wLuotTai_KD + curData["Download"].ToString();
                lnkTai.Text = "<span class=\"orange bold\">" + Resources.Resource.wTai_KD + "</span>";
                lnkTang.Text = "<span class=\"orange bold\">" + Resources.Resource.wTang_KD + "</span>";
            }
            lnkAvatar.NavigateUrl = lnkTenAnh.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString());
            lnkTai.NavigateUrl = "../Download.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            lnkTang.NavigateUrl = UrlProcess.GetVideoDetailUrl(lang.ToString(), "detail", width, curData["W_VItemID"].ToString()) + "&g=1";
            lnkXem.NavigateUrl = "../View.aspx?id=" + curData["W_VItemID"].ToString() + "&lang=" + lang + "&w=" + width;
            WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
            ws.GenerateAvatarThumnail(curData["VThumnail"].ToString(), 60, 45);
            imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(curData["VThumnail"].ToString(), 60, 45).Replace("~", "");
            //imgAvatar.ImageUrl = preurl + curData["VThumnail"].ToString().Replace("~", "");
        }

        protected void btnTang_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SendGift.aspx?id=" + Request.QueryString["id"] + "&sdt=" + txtSoDienThoaiTang.Text.Trim() + "&lang=" + lang + "&w=" + width);
        }
    }
}