using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using WapXzone_VNM.Library.Cache;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;

using System.Collections.Generic;

using System.Web;

using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Library.Component.Menu
{
    public class MenuController
    {        
        public static DataTable GetAllMenuExeptMenuName(string menuName, string lang, string w)
        {
            DataTable dtMenu = new DataTable("QuickMenu");
            dtMenu.Columns.Add("MenuName_Unicode", typeof(String));
            dtMenu.Columns.Add("MenuName" , typeof(String));
            dtMenu.Columns.Add("MenuUrl", typeof(String));

            DataRow row;
            if (menuName != "Hoangdao")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Cung hoàng đạo ";
                row["MenuName"] = " Cung hoang dao ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetHoangdaoHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }
            
            if (menuName != "Sport")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Bóng đá 360 ";
                row["MenuName"] = " Bong da 360 ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetSportHomeUrl(lang, "home", w);
                dtMenu.Rows.Add(row);
            }
            
            if (menuName != "RingTone")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Âm nhạc ";
                row["MenuName"] = " Am nhac ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetRingToneHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }

            if (menuName != "Wallpaper")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Hình ảnh ";
                row["MenuName"] = " Hinh anh ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetWallpaperHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }
            
            if (menuName != "Game")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Javagame ";
                row["MenuName"] = " Javagame ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetGameHomeUrl(lang, w, "0");
                dtMenu.Rows.Add(row);
            }
            
            if (menuName != "App")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Phần mềm ";
                row["MenuName"] = " Phan mem ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetAppHomeUrl(lang, w,"0");
                dtMenu.Rows.Add(row);
            }

            //if (menuName != "Mobifone")
            //{
            //    row = dtMenu.NewRow();
            //    row["MenuName_Unicode"] = " Mobifone ";
            //    row["MenuName"] = " Mobifone ";
            //    row["MenuUrl"] = "http://wap.mobifone.com.vn";
            //    dtMenu.Rows.Add(row);
            //}

            if (menuName != "Video")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Video clip ";
                row["MenuName"] = " Video clip ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetVideoHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }

            if (menuName != "Thugian")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Thư giãn, giải trí";
                row["MenuName"] = " Thu gian, giai tri";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetRelaxHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }
            
            if (menuName != "TraCuu")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Tra cứu ";
                row["MenuName"] = " Tra cuu ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetTracuuHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }

            if (menuName != "XoSo")
            {
                row = dtMenu.NewRow();
                row["MenuName_Unicode"] = " Xổ số ";
                row["MenuName"] = " Xo so ";
                row["MenuUrl"] = UrlProcess.UrlProcess.GetXosoHomeUrl(lang, w);
                dtMenu.Rows.Add(row);
            }                
            return dtMenu;
        }
    }
}
