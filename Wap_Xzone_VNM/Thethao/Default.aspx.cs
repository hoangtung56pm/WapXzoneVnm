﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library;
using System.Configuration;


namespace WapXzone_VNM.Thethao
{
    public partial class Default : BasePage
    {
        private int width;
        private string display;
        private int lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);        
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }
            if (string.IsNullOrEmpty(Request.QueryString["display"]))
            {
                display = "home";
            }
            else
            {
                display = Request.QueryString["display"];
            }            
            switch (display)
            {
                case "home":
                    plContent.Controls.Add(LoadControl("../Video/UserControl/Video4Bongda.ascx"));
                    plContent.Controls.Add(LoadControl("UserControl/Gold.ascx"));
                    break;
                case "list":
                    plContent.Controls.Add(LoadControl("UserControl/List.ascx"));
                    break;
                case "cgd":
                    plContent.Controls.Add(LoadControl("UserControl/Category.ascx"));
                    break;
                case "bxh":
                    plContent.Controls.Add(LoadControl("UserControl/BangXepHang.ascx"));
                    break;
                case "ltd":
                    plContent.Controls.Add(LoadControl("UserControl/LichThiDau.ascx"));
                    break;
                case "ltdhn":
                    plContent.Controls.Add(LoadControl("UserControl/LichThiDauHomNay.ascx"));
                    break;
                case "kqtd":
                    plContent.Controls.Add(LoadControl("UserControl/KetQuaThiDau.ascx"));
                    break;
                case "kqtdhn":
                    plContent.Controls.Add(LoadControl("UserControl/KetQuaThiDauHomNay.ascx"));
                    break;
                case "tvdb":
                    plContent.Controls.Add(LoadControl("UserControl/TuVanDacBiet.ascx"));
                    break;                
            }
        }

    }
}