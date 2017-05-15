using System;
using System.Web;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM
{
    public class Global : System.Web.HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();

        }
        //protected void Application_Start(object sender, EventArgs e)
        //{

        //}

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string url = Request.Url.AbsolutePath.Remove(0, Request.ApplicationPath.Length);
            url = url.ToLower();
            string[] arrUrl = url.Split('/');

            #region Rewrite 3 DV MOI
            
            if(url.Contains(Constant.TinTucRewrite))
            {
                #region Tin_Tuc

                string newUrl = "";
                if (arrUrl[0].ToLower() == Constant.TinTucRewrite + ".aspx")
                {
                    newUrl = "/TinHot/Default.aspx?display=home&w=320&lang=1";
                }
                else
                {
                    if (arrUrl.Length == 5)//CHUYEN MUC TIN
                    {
                        newUrl = UrlProcess.GetHotNewsCategoryUrl("1", "320", arrUrl[2], ConvertUtility.ToInt32(arrUrl[3]));
                    }
                    else if (arrUrl.Length == 4)//CHI TIET TIN
                    {
                        newUrl = UrlProcess.GetHotNewsDetailUrl("1", "320", arrUrl[2]);
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

                #endregion
            }
            else if(url.Contains(Constant.TinKhuyenMaiRewrite))
            {

                #region Tin_Khuyen_Mai

                string id;
                string newUrl = "";

                if(arrUrl[1].ToLower() == "chuyen-muc")//CHUYEN MUC TIN
                {
                    id = arrUrl[2];
                    newUrl = UrlProcess.WebNewsCategoryUrl(id);
                }
                else if(arrUrl[1].ToLower() == "chi-tiet")//CHI TIET TIN
                {
                    id = arrUrl[2];
                    newUrl = UrlProcess.WebNewsDetailUrl(id);
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

                #endregion

            }
            else if (url.Contains(Constant.GioiTinhRewrite))
            {
                #region Gioi_Tinh

                string newUrl = "";
                if (arrUrl[0].ToLower() == Constant.GioiTinhRewrite + ".aspx")
                {
                    newUrl = "/GioiTinh/Default.aspx?display=home&w=320&lang=1";
                }
                else
                {
                    if (arrUrl.Length == 5)//CHUYEN MUC TIN
                    {
                        //newUrl = UrlProcess.GetHotNewsCategoryUrl("1", "320", arrUrl[2], ConvertUtility.ToInt32(arrUrl[3]));
                        newUrl = "/GioiTinh/Default.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl.Length == 4)//CHI TIET TIN
                    {
                        //newUrl = UrlProcess.GetHotNewsDetailUrl("1", "320", arrUrl[2]);
                        newUrl = "/GioiTinh/Default.aspx?display=detail&w=320&lang=1&id=" + arrUrl[2];
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
                
                #endregion
            }
            else if (url.Contains(Constant.TruyenOnlineRewrite))
            {
                #region Truyen_Online

                string newUrl = "";
                if (arrUrl[0].ToLower() == Constant.TruyenOnlineRewrite + ".aspx")
                {
                    newUrl = "/Truyen/Default.aspx?display=home&w=320&lang=1";
                }
                else
                {
                    if (arrUrl.Length == 5)//CHUYEN MUC TIN
                    {
                        //newUrl = UrlProcess.GetHotNewsCategoryUrl("1", "320", arrUrl[2], ConvertUtility.ToInt32(arrUrl[3]));
                        newUrl = "/Truyen/Default.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl.Length == 4)//CHI TIET TIN
                    {
                        //newUrl = UrlProcess.GetHotNewsDetailUrl("1", "320", arrUrl[2]);
                        newUrl = "/Truyen/Default.aspx?display=detail&w=320&lang=1&id=" + arrUrl[2];
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
                    
                #endregion
            }
            else if (url.Contains(Constant.TruyenAudioRewrite))
            {
                #region MyRegion

                string newUrl = "";
                if (arrUrl[0].ToLower() == Constant.TruyenAudioRewrite + ".aspx")
                {
                    newUrl = "/Truyen/Default.aspx?display=homeaudio&w=320&lang=1";
                }
                else
                {
                    if (arrUrl.Length == 5)//CHUYEN MUC TIN
                    {
                        newUrl = "/Truyen/Default.aspx?display=listaudio&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl.Length == 4)//CHI TIET TIN
                    {
                        //newUrl = UrlProcess.GetHotNewsDetailUrl("1", "320", arrUrl[2]);
                        newUrl = "/Truyen/Default.aspx?display=detailaudio&w=320&lang=1&id=" + arrUrl[2];
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

                #endregion
            }

            #endregion

            #region Rewrite DV VOTE

            //if (arrUrl.Length >= 3 && arrUrl[0] == "dang-ky")
            //{
            //    url = AppEnv.GetSetting("WapDefault") + "/sub/dangky.aspx?t=" + arrUrl[1] + "&k=" + arrUrl[2] + "&lang=1&w=320";
            //    Response.Redirect(url);
            //}
            //else if (arrUrl.Length >= 2 && arrUrl[0] == "ai-sexy-hon")
            //{
            //    string name = arrUrl[1].Replace(".aspx", "");
            //    if (name == "mai-tho")
            //    {
            //        url = AppEnv.GetSetting("WapDefault") + "/Wap/S2/Vote/Ketqua.aspx?t=vote1";
            //        Response.Redirect(url);
            //    }
            //    else if (name == "linh-miu")
            //    {
            //        url = AppEnv.GetSetting("WapDefault") + "/Wap/S2/Vote/Ketqua.aspx?t=vote2";
            //        Response.Redirect(url);
            //    }
            //}

            #endregion

            #region Rewrite DV BI MAT HOT-GIRL
            
            //if(arrUrl.Length == 2)
            //{
            //    if (arrUrl[0] == "bi-mat-hot-girl" && arrUrl[1] == "mai-tho.aspx")
            //    {
            //        HttpContext.Current.RewritePath("/gach.aspx?t=gach", false);
            //    }
            //    else if (arrUrl[0] == "scandal-1-hot-girl" && arrUrl[1] == "mai-tho.aspx")
            //    {
            //        HttpContext.Current.RewritePath("/gach.aspx?t=gach1", false);
            //    }
            //    else if (arrUrl[0] == "scandal-2-hot-girl" && arrUrl[1] == "mai-tho.aspx")
            //    {
            //        HttpContext.Current.RewritePath("/gach.aspx?t=gach2", false);
            //    }
            //    else if (arrUrl[0] == "scandal-3-hot-girl" && arrUrl[1] == "mai-tho.aspx")
            //    {
            //        HttpContext.Current.RewritePath("/gach.aspx?t=gach3", false);
            //    }
            //}

            #endregion

            #region Rewrite DV S2 94x

            if (arrUrl.Length == 1 && arrUrl[0] == "trang-chu.aspx")
            {
                HttpContext.Current.RewritePath("/Wap/DefaultHigh.aspx", false);
            }
            else if (arrUrl.Length == 1 && arrUrl[0] == "login.aspx")
            {
                HttpContext.Current.RewritePath("/Wap/login.aspx", false);
            }
            else if (arrUrl.Length == 1 && arrUrl[0] == "hot-girl.aspx")
            {
                HttpContext.Current.RewritePath("/VoteNew.aspx", false);
            }
            else if (arrUrl.Length == 1 && arrUrl[0] == "hot-girl-vote.aspx")
            {
                HttpContext.Current.RewritePath("/VoteNew.aspx?t=VOTE1", false);
            }
            else if (arrUrl.Length == 1 && arrUrl[0] == "trung-xe-sh.aspx")
            {
                AppEnv.BigPromotionRegistered();
                Response.Redirect("http://wap.vietnamobile.com.vn/Bigpromotion.aspx");
            }
            else if (arrUrl.Length == 1 && arrUrl[0].ToLower() == "trieu-phu-bong-da.aspx")
            {
                Response.Redirect("http://visport.vn/Wap/GameShow.aspx");
            }
            else if (arrUrl.Length == 1)
            {
                string madichvu = arrUrl[0];
                if (madichvu == "video-hang-ngay.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=VDH", false);
                }
                else if (madichvu == "xem-hoang-dao.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=CHD", false);
                }
                else if(madichvu == "tran-cau-dinh.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=TIP", false);
                }
                else if(madichvu == "tu-van-xo-so.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=VE", false);
                }
                else if(madichvu == "top-game-hot.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=G1", false);
                }
                else if(madichvu == "top-clip-hot.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=C1", false);
                }
                else if(madichvu == "truyen-cuoi-hot.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=FUN", false);
                }
                else if(madichvu == "video-hot.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=VIDEO3", false);
                }
                else if (madichvu == "f8-clip.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=f8clip", false);
                }
                else if (madichvu == "kpop.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=kpop", false);
                }
                else if(madichvu == "im-tai-game-tuan.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=GB", false);
                }
                else if (madichvu == "im-tai-nhac-tuan.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=NHAC", false);
                }
                else if(madichvu == "ht-clip-hot.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=HTCLIP", false);
                }
                else if(madichvu == "ht-fun-truyen.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=HTFUNNY", false);
                }
                else if (madichvu == "da-dia-diem-an-choi.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=DAVIP", false);
                }
                else if (madichvu == "dv-tai-9game.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=9GAME", false);
                }

                else if (madichvu == "c-pic.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=CPIC", false);
                }
                else if (madichvu == "c-anh2.aspx")
                {
                    HttpContext.Current.RewritePath("/sub/DangKyS2_94x.aspx?t=CANH2", false);
                }
                else if(madichvu == "dau-tri.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/DauTri.aspx", false);
                }
                else if (madichvu == "dang-ky-dau-tri.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/DauTri.aspx?c=dautri", false);
                }
                else if (madichvu == "gieo-que.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/GieoQue.aspx", false);
                }
                else if (madichvu == "dang-ky-gieo-que.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/GieoQue.aspx?c=gieoque", false);
                }
                else if (madichvu == "kham-pha.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/KhamPha.aspx", false);
                }
                else if (madichvu == "dang-ky-kham-pha.aspx")
                {
                    HttpContext.Current.RewritePath("/DichvuTet/KhamPha.aspx?c=khampha", false);
                }
                
            }

            #endregion

            #region Smartphone Rewrite

            #region GAME

            if (url.Contains(Constant.GameRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.GameRewrite + ".aspx")
                {
                    newUrl = "/Game/DefaultHigh.aspx";
                    //HttpContext.Current.RewritePath("/Game/DefaultHigh.aspx", false);
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC GAME
                {
                    newUrl = "/Game/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if (arrUrl.Length == 4)//CHI TIET GAME
                {
                    newUrl = "/Game/DefaultHigh.aspx?display=detail&id=" + arrUrl[2];
                }
                else if (arrUrl.Length == 3 && url.Contains("download.aspx"))//Download GAME
                {
                    newUrl = "/Game/DownloadHigh.aspx?id=" + arrUrl[1];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }

            #endregion

            #region THU GIAN

            if (url.Contains(Constant.ThuGianRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.ThuGianRewrite + ".aspx")
                {
                    newUrl = "/ThuGian/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC THU_GIAN
                {
                    newUrl = "/ThuGian/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if (arrUrl.Length == 3)//CHI TIET THU_GIAN
                {
                    //newUrl = "/ThuGian/DefaultHigh.aspx?display=detail&w=320&lang=1&id=" + arrUrl[2];
                    newUrl = "/ThuGian/DownloadHigh.aspx?id=" + arrUrl[1];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

            }

            #endregion

            #region VIDEO

            if (url.Contains(Constant.VideoRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.VideoRewrite + ".aspx")
                {
                    newUrl = "/Video/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC VIDEO
                {
                    newUrl = "/Video/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if (arrUrl.Length == 4)//CHI TIET VIDEO
                {
                    newUrl = "/Video/DefaultHigh.aspx?display=detail&w=320&lang=1&id=" + arrUrl[2];
                }
                else if(arrUrl.Length == 3 && url.Contains("download.aspx"))//Download VIDEO
                {
                    newUrl = "/Video/DownloadHigh.aspx?id=" + arrUrl[1];
                }
                else if (arrUrl.Length == 3 && url.Contains("view.aspx"))//View VIDEO
                {
                    newUrl = "/Video/ViewHigh.aspx?id=" + arrUrl[1];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

            }
            else if (url.Contains(Constant.YoutubeFilmRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 3)//CHUYEN MUC VIDEO YOUTUBE
                {
                    string key = Request.QueryString["key"];
                    if (!string.IsNullOrEmpty(key))
                    {
                        newUrl = "/Video/DefaultHigh.aspx?display=ysearch&w=320&lang=1&key=" + key + "&cpage=" + ConvertUtility.ToInt32(arrUrl[1]);
                    }
                    else
                    {
                        newUrl = "/Video/DefaultHigh.aspx?display=ylist&w=320&lang=1&cpage=" + ConvertUtility.ToInt32(arrUrl[1]);
                    }
                }
                else if (arrUrl.Length == 4)//CHI TIET VIDEO YOUTUBE
                {
                    newUrl = "/Video/DefaultHigh.aspx?display=ydetail&w=320&lang=1&id=" + arrUrl[2];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }

            #endregion

            #region HOANG DAO

            if (url.Contains(Constant.HoangDaoRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.HoangDaoRewrite + ".aspx")
                {
                    newUrl = "/HoangDao/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC HOANG DAO
                {
                    newUrl = "/HoangDao/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if (arrUrl.Length == 4)//CHI TIET HOANG DAO
                {
                    string[] arr = arrUrl[2].Split('-');
                    newUrl = "/HoangDao/DefaultHigh.aspx?display=detail&w=320&lang=1&id=" + arr[0] + "&l=" + arr[1];
                }
                else if (arrUrl.Length == 3)//DOWNLOAD HOANG DAO
                {
                    string[] arr = arrUrl[1].Split('-');
                    newUrl = "/HoangDao/DownloadHigh.aspx?id=" + arr[0] + "&l=" + arr[1];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }

            #endregion

            #region PHAN MEM

            if (url.Contains(Constant.PhanMemRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.PhanMemRewrite + ".aspx")
                {
                    newUrl = "/PhanMem/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC PHAN MEM
                {
                    newUrl = "/PhanMem/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if (arrUrl.Length == 4)//CHI TIET PHAN MEM
                {
                    newUrl = "/PhanMem/DefaultHigh.aspx?display=detail&id=" + arrUrl[2];
                }
                else if(arrUrl.Length == 3)//DOWNLOAD PHAN MEM
                {
                    newUrl = "/PhanMem/DownloadHigh.aspx?id=" + arrUrl[1];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

            }

            #endregion

            #region HINH NEN

            if (url.Contains(Constant.HinhNenRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.HinhNenRewrite + ".aspx")
                {
                    newUrl = "/HinhNen/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 5)//CHUYEN MUC HINH NEN
                {
                    newUrl = "/HinhNen/DefaultHigh.aspx?display=list&w=320&lang=1&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                }
                else if(arrUrl.Length == 4 && url.Contains("download"))//DOWNLOAD HINH NEN
                {
                    newUrl = "/HinhNen/DownloadHigh.aspx?display=download&w=320&lang=1&id=" + arrUrl[2] + "&catid=" + arrUrl[1];
                }
                else if (arrUrl.Length == 4)//CHI TIET HINH NEN
                {
                    newUrl = "/HinhNen/DefaultHigh.aspx?display=detail&w=320&lang=1&id=" + arrUrl[2];
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

            }

            #endregion

            #region AM NHAC

            if (url.Contains(Constant.AmNhacRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.AmNhacRewrite + ".aspx")
                {
                    newUrl = "/Music/DefaultHigh.aspx";
                }
                else if(arrUrl.Length == 3)
                {
                    newUrl = "/Music/DownloadHigh.aspx?id=" + arrUrl[1];
                }
                else if (arrUrl.Length == 4)//Album Chi Tiet
                {
                    if (arrUrl[1] == "album")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=byalb&id=" + arrUrl[2];
                    }
                    else if (arrUrl[1] == "chi-tiet")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=mdt&id=" + arrUrl[2];
                    }
                }
                else if (arrUrl.Length == 5)//Album LIST
                {
                    if (arrUrl[1] == "album")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=album&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl[1] == "ca-sy")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=artist&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl[1] == "ca-sy-list")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=byart&id=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl[1] == "the-loai")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=style&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl[1] == "the-loai-list")
                    {
                        newUrl = "/Music/DefaultHigh.aspx?display=bysty&id=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }

            }

            #endregion

            #region THE THAO

            if (url.Contains(Constant.TheThaoRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.TheThaoRewrite + ".aspx")
                {
                    newUrl = "/TheThao/DefaultHigh.aspx";
                }
                else if(arrUrl.Length == 2)
                {
                    if (arrUrl[1] == "tu-van-dac-biet.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=tvdb";
                    }
                    else if (arrUrl[1] == "thong-ke-dac-biet.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=cgd&tab=tkdb";
                    }
                    else if (arrUrl[1] == "ket-qua-hom-nay.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=kqtdhn";
                    }
                    else if (arrUrl[1] == "bang-xep-hang.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=cgd&tab=bxh";
                    }
                    else if (arrUrl[1] == "ket-qua-thi-dau.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=cgd&tab=kqtd";
                    }
                    else if (arrUrl[1] == "lich-thi-dau.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=cgd&tab=ltd";
                    }
                    else if (arrUrl[1] == "lich-thi-dau-hom-nay.aspx")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=ltdhn";
                    }
                }
                else if (arrUrl.Length == 3)
                {
                    if(arrUrl[2] == "tran-cau-vang.aspx")
                    {
                        newUrl = "/TheThao/TuVanDacBietHigh.aspx?id=" + arrUrl[1];
                    }
                    else if (arrUrl[2] == "thong-ke.aspx")
                    {
                        newUrl = "/TheThao/ThongKeHigh.aspx?id=" + arrUrl[1];
                    }
                }
                else if(arrUrl.Length == 4)
                {
                    if(arrUrl[1] == "thong-ke")
                    {
                        newUrl = "/TheThao/ThongKeDacBietHigh.aspx?catid=" + arrUrl[2];
                    }
                    else if (arrUrl[1] == "bang-xep-hang")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=bxh&catid=" + arrUrl[2];
                    }
                    //else if (arrUrl[1] == "ket-qua-thi-dau")
                    //{
                    //    newUrl = "/TheThao/DefaultHigh.aspx?display=kqtd&catid=" + arrUrl[2];
                    //}
                }
                else if (arrUrl.Length == 5)//ket-qua-thi-dau
                {
                    if (arrUrl[1] == "ket-qua-thi-dau")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=kqtd&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    else if (arrUrl[1] == "lich-thi-dau")
                    {
                        newUrl = "/TheThao/DefaultHigh.aspx?display=ltd&catid=" + arrUrl[2] + "&cpage=" + ConvertUtility.ToInt32(arrUrl[3]);
                    }
                    
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }

            #endregion

            #region XO SO

            if (url.Contains(Constant.XoSoRewrite))
            {
                string newUrl = "";
                if (arrUrl.Length == 1 && arrUrl[0] == Constant.XoSoRewrite + ".aspx")
                {
                    newUrl = "/XoSo/DefaultHigh.aspx";
                }
                else if (arrUrl.Length == 4)//CHI TIET XO SO
                {
                    if(arrUrl[3] == Constant.XoSo_Kqxs_Rewrite + ".aspx")
                    {
                        string[] value = arrUrl[2].Split('-');
                        newUrl = "/XoSo/KQXSHigh.aspx?day=" + value[1] + "&id=" + value[0];
                    }
                    else if (arrUrl[3] == Constant.XoSo_KqbyDay_Rewrite + ".aspx")
                    {
                        newUrl = "/XoSo/KQByDayHigh.aspx?id=" + arrUrl[2];
                    }
                    else if (arrUrl[3] == Constant.XoSo_KqCho_Rewrite + ".aspx")
                    {
                        newUrl = "/XoSo/KQChoHigh.aspx?id=" + arrUrl[2];
                    }
                    else if(arrUrl[3] == Constant.XoSo_ThongKe_Rewrite + ".aspx")
                    {
                        newUrl = "/XoSo/ThongKeHigh.aspx?id=" + arrUrl[2];
                    }
                    else if (arrUrl[3] == Constant.XoSo_Kq20ngay_Rewrite + ".aspx")
                    {
                        newUrl = "/XoSo/KQ20NHigh.aspx?id=" + arrUrl[2];
                    }
                }

                if (!string.IsNullOrEmpty(newUrl))
                {
                    HttpContext.Current.RewritePath(newUrl, false);
                }
                else
                {
                    Response.Redirect(AppEnv.GetSetting("WapDefault"));
                }
            }

            #endregion

            

                #endregion

            }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}