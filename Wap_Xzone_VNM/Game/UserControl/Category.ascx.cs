using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Component.Game;

namespace WapXzone_VNM.Game.UserControl
{
    public partial class Category : System.Web.UI.UserControl
    {
       
        private string lang;
        private string width;
        private static string preurl;
        private static int totalcat;
        private int hotro;
        private int catID;
        private bool freecate = false;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
                width = Request.QueryString["w"];
                hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);
                preurl = ConfigurationSettings.AppSettings.Get("urldata");
                DataTable dt = GameController.GetAllCategoryExeptCatIDHasCache(Session["telco"].ToString(), (int)Constant.Game.Category, 0);
                totalcat = dt.Rows.Count;                
                rptCategory.DataSource = dt;
                rptCategory.ItemDataBound += new RepeaterItemEventHandler(rptCategory_ItemDataBound); ;
                rptCategory.DataBind();
                catID = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                if (catID == 0)
                {
                    DataTable dtCat = GameController.GetGameDetailByIDHasCache(Session["telco"].ToString(), ConvertUtility.ToInt32(Request.QueryString["id"]));
                    if (dtCat.Rows.Count > 0)
                    {
                        catID = ConvertUtility.ToInt32(dtCat.Rows[0]["W_GameCategoryID"]);
                    }
                }
                if (ConfigurationSettings.AppSettings.Get("freecate").IndexOf("," + catID.ToString() + ",") > -1)
                    freecate = true;
                if (freecate == false)
                {
                    if (lang == "1")
                    {
                        ltrTheLoai.Text = Resources.Resource.gTheLoaiGame;
                        //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien + "/game)";
                    }
                    else
                    {
                        ltrTheLoai.Text = Resources.Resource.gTheLoaiGame_KD;
                        //ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("gameprice") + Resources.Resource.wDonViTien_KD + "/game)";
                    }
                }
                else
                {
                    //ltrGia.Text = "";
                }
            }           
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");            
            if (lang == "1")
            {
                lnkCatName.Text = curData["Title_Unicode"].ToString();
            }
            else
            {
                lnkCatName.Text = curData["Title"].ToString();
            }
            if (curData["W_GameCategoryID"].ToString() == "14" || curData["W_GameCategoryID"].ToString() == "23" || curData["W_GameCategoryID"].ToString() == "24")
                lnkCatName.Text = lnkCatName.Text + " <img src=\"../img/hot_icon.gif\">";
            lnkCatName.NavigateUrl = UrlProcess.GetGameCategoryUrl(lang.ToString(), width, curData["W_GameCategoryID"].ToString(), hotro.ToString());
        }
    }
}