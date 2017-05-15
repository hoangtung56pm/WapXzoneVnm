using System.Configuration;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Library.UrlProcess
{
    public class UrlProcess
    {
        //Trang chu mac dinh
        public static string GetWapHomeUrl(string lang, string width)
        {
            return "/Wap/Default.aspx?lang=" + lang + "&w=" + width;
        }

        public static string GetWapHomeUrlNew(string lang, string width)
        {
            return "/Wap/DefaultNew.aspx?lang=" + lang + "&w=" + width;
        }

        //Trang chu redirect
        public static string GetVNMOtherHomeUrl()
        {
            return "/Wap/Default.aspx";
        }
        public static string GetVNMLienket(string lang, string width, string display)
        {
            return "/Wap/Lienket.aspx?lang=" + lang + "&w=" + width + "&display=" + display;
        }
        //#region Trang giai tri
        ////Trang chu giai tri
        //public static string GetGiaitri_HomeUrl(string lang, string width)
        //{
        //    return "~/Giaitri/Default.aspx?lang=" + lang + "&w=" + width;
        //}
        //#endregion

        #region Trang am nhac
        //Trang chu am nhac
        public static string GetMusicHomeUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }

        public static string GetMusicHomeUrlNew(string lang, string width)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
        }

        //=======================
        public static string GeMusicStyleUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=style&w=" + width;
        }
        public static string GeMusicStyleUrlNew(string lang, string width)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=style&w=" + width;
        }
        public static string GeMusicAlbumUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=album&w=" + width;
        }
        public static string GeMusicAlbumUrlNew(string lang, string width)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=album&w=" + width;
        }
        public static string GeMusicArtistUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=artist&w=" + width;
        }
        public static string GeMusicArtistUrlNew(string lang, string width)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=artist&w=" + width;
        }
        //-----------------------------------------
        public static string GetMusicByStyleUrl(string lang, string width, string styleid)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=bysty&w=" + width + "&id=" + styleid;
        }
        public static string GetMusicByStyleUrlNew(string lang, string width, string styleid)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=bysty&w=" + width + "&id=" + styleid;
        }
        public static string GetMusicByArtistUrl(string lang, string width, string artistid)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=byart&w=" + width + "&id=" + artistid;
        }
        public static string GetMusicByArtistUrlNew(string lang, string width, string artistid)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=byart&w=" + width + "&id=" + artistid;
        }
        public static string GetMusicByAlbumUrl(string lang, string width, string albumid)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=byalb&w=" + width + "&id=" + albumid;
        }
        public static string GetMusicByAlbumUrlNew(string lang, string width, string albumid)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=byalb&w=" + width + "&id=" + albumid;
        }
        public static string GetMusicByOrderUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=newest&w=" + width;
        }
        //-------------------------------

        //
        public static string GetMusicDetailUrl(string lang, string width, string id)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=mdt&w=" + width + "&id=" + id;
        }
        public static string GetMusicDetailUrlNew(string lang, string width, string id)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=mdt&w=" + width + "&id=" + id;
        }
        //
        public static string GeMusicArtistDetailUrl(string lang, string width, string artistID)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=artd&w=" + width + "&artid=" + artistID;
        }//
        public static string GetMusicSearchResultUrl(string lang, string width, string key, string type)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=sr&w=" + width + "&key=" + key + "&type=" + type;
        }
        public static string GetMusicSearchResultUrlNew(string lang, string width, string key, string type)
        {
            return "/Music/DefaultNew.aspx?lang=" + lang + "&display=sr&w=" + width + "&key=" + key + "&type=" + type;
        }
        //
        public static string GetMusicNewsListUrl(string lang, string width)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=news&w=" + width;
        }
        //
        public static string GetMusicNewsDetailUrl(string lang, string width, string id)
        {
            return "/Music/Default.aspx?lang=" + lang + "&display=ndt&w=" + width + "&id=" + id;
        }
        public static string GetMusicDownloadUrlNew(string lang,string width,string id)
        {
            return "/Music/DownloadNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
        }
        #endregion

        #region Trang nhac chuong
        //Trang chu nhac chuong
        public static string GetRingToneHomeUrl(string lang, string width)
        {
            return "~/Nhacchuong/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        //Trang chi tiet nhac chuong
        public static string GetRingToneDetailUrl(string lang, string display, string width, string id)
        {
            return "~/Nhacchuong/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
        }
        //Trang Category Nhac chuong
        public static string GetRingToneCategoryUrl(string lang, string width, string catid)
        {
            return "~/Nhacchuong/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
        }
        //Trang ket qua tim kiem
        public static string GetRingToneSearchResultUrl(string lang, string width, string key)
        {
            return "~/Nhacchuong/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
        }
        // Charging
        public static string GetRingToneSendGiftUrl(string lang, string width, string id, string sdt)
        {
            return "~/Nhacchuong/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt;
        }
        public static string GetRingToneDownloadUrl(string lang, string width, string id)
        {
            return "~/Nhacchuong/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
        }
        #endregion        

        #region Trang hoang dao
        //Trang chu hoang dao
        public static string GetHoangdaoHomeUrl(string lang, string width)
        {
            return "~/HoangDao/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        public static string GetHoangdaoHomeUrlNew(string lang, string width)
        {
            return "/HoangDao/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        public static string GetHoangdaoBoiVuiUrl(string lang, string width, string display)
        {
            return "~/HoangDao/Boivui.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
        }
        public static string GetHoangdaoBoiVuiUrl(string lang, string width, string display, string level, string id)
        {
            return "~/HoangDao/Boivui.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&l=" + level + "&id=" + id;
        }
        //Trang loai hoang dao (ngay, thang nam)
        public static string GetHoangdaoTypeUrl(string lang, string display, string width, string type)
        {
            return "~/HoangDao/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&type=" + type;
        }

        public static string GetHoangdaoTypeUrlNew(string lang, string display, string width, string type)
        {
            return "/HoangDao/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&type=" + type;
        }
        ////Trang  chi tiet
        //public static string GetHoangdaoDetailUrl(string lang, string display, string width, string level, string id)
        //{
        //    return "~/HoangDao/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&level=" + level + "&id=" + id;
        //}
        //Trang download
        public static string GetHoangdaoDownloadUrl(string lang, string width, string level, string id)
        {
            return "~/HoangDao/Download.aspx?l=" + level + "&id=" + id + "&lang=" + lang + "&w=" + width;
        }        
        #endregion

        //Trang TuVi
        public static string GetTuViDetailUrl(string lang, string width, string id)
        {
            return "/TuVi/Default.aspx?lang=" + lang + "&display=detail&w=" + width + "&id=" + id;
        }

        public static string GetTuViHomeUrl(string lang, string width)
        {
            return "/TuVi/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }

        #region Trang hinh nen
        //Trang chu hinh nen
        public static string GetWallpaperHomeUrl(string lang, string width)
        {
            return "/Hinhnen/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        public static string GetWallpaperHomeUrlNew(string lang, string width)
        {
            return "/Hinhnen/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        //Trang Category hinh nen
        public static string GetWallpaperCategoryUrl(string lang, string width, string catid)
        {
            return "~/Hinhnen/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
        }
        public static string GetWallpaperCategoryUrlNew(string lang, string width, string catid)
        {
            return "/Hinhnen/DefaultNew.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
        }
        //Trang chi tiet hinh nen
        public static string GetWallpaperDetailUrl(string lang, string display, string width, string id)
        {
            return "~/Hinhnen/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
        }
        public static string GetWallpaperDetailUrlNew(string lang, string display, string width, string id)
        {
            return "/Hinhnen/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
        }  
        //Trang tải ảnh
        public static string GetWallpaperDownloadUrl(string lang, string width, string id, string catid)
        {
            return "~/Hinhnen/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }
        public static string GetWallpaperDownloadUrlNew(string lang, string width, string id, string catid)
        {
            return "/Hinhnen/DownloadNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&catid=" + catid;
        }
        //Trang tặng ảnh
        public static string GetWallpaperSendGiftUrl(string lang, string width, string id, string sdt, string catid)
        {
            return "~/Hinhnen/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt + "&catid=" + catid;
        }
        //Trang ket qua tim kiem
        public static string GetWallpaperSearchResultUrl(string lang, string width, string key)
        {
            return "~/Hinhnen/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
        }
        public static string GetWallpaperSearchResultUrlNew(string lang, string width, string key)
        {
            return "/Hinhnen/DefaultNew.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
        }
        #endregion
        #region Trang ban can biet
        //Trang chu ban can biet
        public static string GetYouNeedKnowHomeUrl(string lang, string display, string width)
        {
            return "~/Bancanbiet/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
        }
        //Trang get theo bank
        public static string GetBankUrl(string lang, string display, string width, string catid)
        {
            return "~/Bancanbiet/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid;
        }
        //Trang get theo bank theo city
        public static string GetBankByCityUrl(string lang, string display, string width, string catid, string city)
        {
            return "~/Bancanbiet/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid + "&id=" + city;
        }
        //Trang ket qua tim kiem
        public static string GetLocationSearchResultUrl(string lang, string display, string width, string key, string bankid)
        {
            return "~/Bancanbiet/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key + "&bankid=" + bankid;
        }
        #endregion
        #region Trang nhac cho
        //Trang chu nhac cho
            public static string GetRBTHomeUrl(string lang, string display, string width)
            {
                return "~/Nhaccho/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
            }
        //Trang tim kiem nhac cho
            public static string GetRingBackToneSearchResultUrl(string lang, string display, string width, string key)
            {
                return "~/Nhaccho/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key;
            }
        //Trang chi tiet nhac cho
        public static string GetRingBackToneDetailUrl(string lang, string display, string width, string id)
        {
            return "~/Nhaccho/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
        }
        //Trang Category Nhac cho
        public static string GetRingBackToneCategoryUrl(string lang, string display, string width, string catid)
        {
            return "~/Nhaccho/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid;
        }
        //Trang charging nhac cho
        public static string GetRingBackToneChargingUrl(string lang, string display, string width, string id)
        {
            return "~/Nhaccho/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
        }
        #endregion

        #region Trang Phan mem
        //Trang chu phan mem
            public static string GetAppHomeUrl(string lang, string width, string hotro)
            {
                return "~/Phanmem/Default.aspx?lang=" + lang + "&display=home&w=" + width + "&hotro=" + hotro;
            }
            public static string GetAppHomeUrlNew(string lang, string width, string hotro)
            {
                return "/Phanmem/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width + "&hotro=" + hotro;
            }
            //Trang Category Phan mem
            public static string GetAppCategoryUrl(string lang, string width, string catid, string hotro)
            {
                return "~/Phanmem/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid + "&hotro=" + hotro;
            }
            public static string GetAppCategoryUrlNew(string lang, string width, string catid, string hotro)
            {
                return "/Phanmem/DefaultNew.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid + "&hotro=" + hotro;
            }
            //Trang ket qua tim kiem
            public static string GetAppSearchResultUrl(string lang, string width, string key, string hotro)
            {
                return "~/Phanmem/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key + "&hotro=" + hotro;
            }
            public static string GetAppSearchResultUrlNew(string lang, string width, string key, string hotro)
            {
                return "/Phanmem/DefaultNew.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key + "&hotro=" + hotro;
            }
            //Trang chi tiet phan mem
            public static string GetAppDetailUrl(string lang, string display, string width, string id, string hotro)
            {
                return "~/Phanmem/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            public static string GetAppDetailUrlNew(string lang, string display, string width, string id, string hotro)
            {
                return "/Phanmem/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            //Trang charging của Phan mem        
            public static string GetAppSendGiftUrl(string lang, string width, string id, string sdt, string hotro)
            {
                return "~/Phanmem/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt + "&hotro=" + hotro;
            }
            public static string GetAppDownloadUrl(string lang, string width, string id, string hotro)
            {
                return "~/Phanmem/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            public static string GetAppDownloadUrlNew(string lang, string width, string id, string hotro)
            {
                return "/Phanmem/DownloadNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
        
        #endregion
        #region Trang The thao
                //Trang chu the thao
                public static string GetSportHomeUrl(string lang, string display, string width)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
                }
                public static string GetSportHomeUrlNew(string lang, string display, string width)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
                }
                public static string GetSportNewsDetailUrlNew(string lang, string width,int id)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=newsdetail&w=" + width + "&id=" + id;
                }
                public static string GetSportNewsCategoryUrlNew(string lang, string width, int id)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=category&w=" + width + "&id=" + id;
                }
                //Trang giai dau
                public static string GetCompetitionCategoryUrl(string lang, string display, string width, string catid,string tab)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid + "&tab=" + tab;
                }
                //Trang Thống kê đặc biệt
                public static string GetCompetitionTKDBUrl(string lang, string width, string catid)
                {
                    return "~/Thethao/ThongKeDacBiet.aspx?lang=" + lang + "&w=" + width + "&catid=" + catid;
                }
                public static string GetCompetitionTKDBUrlNew(string lang, string width, string catid)
                {
                    return "/Thethao/ThongKeDacBietNew.aspx?lang=" + lang + "&w=" + width + "&catid=" + catid;
                }
                //Trang Bảng xếp hạng
                public static string GetCompetitionBXHUrl(string lang, string width, string catid)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&display=bxh&w=" + width + "&catid=" + catid;
                }
                public static string GetCompetitionBXHUrlNew(string lang, string width, string catid)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=bxh&w=" + width + "&catid=" + catid;
                }
                //Trang Lịch thi đấu
                public static string GetCompetitionLTDUrl(string lang, string width, string catid)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&display=ltd&w=" + width + "&catid=" + catid;
                }
                public static string GetCompetitionLTDUrlNew(string lang, string width, string catid)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=ltd&w=" + width + "&catid=" + catid;
                }
                //Trang Kết quả thi đấu
                public static string GetCompetitionKQTDUrl(string lang, string width, string catid)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&display=kqtd&w=" + width + "&catid=" + catid;
                }
                public static string GetCompetitionKQTDUrlNew(string lang, string width, string catid)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&display=kqtd&w=" + width + "&catid=" + catid;
                }
                //Các giải đấu
                public static string GetCompetitionUrl(string lang, string width, string tab)
                {
                    return "~/Thethao/Default.aspx?lang=" + lang + "&w=" + width + "&display=cgd&tab=" + tab;
                }
                public static string GetCompetitionUrlNew(string lang, string width, string tab)
                {
                    return "/Thethao/DefaultNew.aspx?lang=" + lang + "&w=" + width + "&display=cgd&tab=" + tab;
                }
                //Tư vấn
                public static string GetCompetitionTuVanUrl(string lang, string width, string id)
                {                    
                    return "~/Thethao/TuVan.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
                }
                //Tư vấn
                public static string GetCompetitionTuVanDacBietUrl(string lang, string width, string id)
                {
                    return "~/Thethao/TuVanDacBiet.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
                }
                //Thống kê
                public static string GetCompetitionThongKeUrl(string lang, string width, string id)
                {
                    return "~/Thethao/ThongKe.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
                }                
                //Đăng ký
                public static string GetCompetitionDangKyUrl(string lang, string width)
                {
                    return "~/Thethao/DangKy.aspx?lang=" + lang + "&w=" + width;
                }
                //KQCho
                public static string GetCompetitionKQChoUrl(string lang, string width, string id)
                {
                    return "~/Thethao/KQCho.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
                }
        #endregion

        #region Trang Thu gian
            public static string GetRelaxHomeUrl(string lang, string width)
            {
                return "~/Thugian/Default.aspx?lang=" + lang + "&display=home&w=" + width;
            }
            public static string GetRelaxHomeUrlNew(string lang, string width)
            {
                return "/Thugian/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
            }
            //Trang Category Thu gian
            public static string GetRelaxNewsCategoryUrl(string lang, string display, string width, string catid)
            {
                return "~/Thugian/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid;
            }
            public static string GetRelaxNewsCategoryUrlNew(string lang, string display, string width, string catid)
            {
                return "/Thugian/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid;
            }
            //Trang danh sach Category theo zoneID
            public static string GetRelaxNewsCategoryByZoneUrl(string lang, string display, string width, string zoneid)
            {
                return "~/Thugian/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&zoneid=" + zoneid;
            }
            //Trang thu gian chi tiet
            //public static string GetRelaxNewsDetailUrl(string lang, string display, string width, string id)
            //{
            //    return "~/Thugian/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            //}
            public static string GetRelaxDownloadUrl(string lang, string width, string id)
            {
                return "~/Thugian/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
            }
            public static string GetRelaxDangKyUrl(string lang, string width)
            {
                return "~/Thugian/DangKy.aspx?lang=" + lang + "&w=" + width;
            }

            //Trang ket qua tim kiem
            public static string GetRelaxNewsSearchResultUrl(string lang, string display, string width, string key)
            {
                return "~/Thugian/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key;
            }
        #endregion
        #region Trang tin tuc
            //Trang chu tin tuc
            public static string GetNewsHomeUrl(string lang, string width)
                {
                    return "/Tintuc/Default.aspx?lang=" + lang + "&display=home&w=" + width;
                }

            public static string GetNewsHomeUrlNew(string lang, string width)
            {
                return "/Tintuc/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
            }
            //Trang ket qua tim kiem
            public static string GetNewsSearchResultUrl(string lang, string display, string width, string key)
            {
                return "~/Tintuc/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key;
            }
            //Trang Tin chi tiet
            public static string GetNewsDetailUrl(string lang, string display, string width, string id)
            {
                return "~/Tintuc/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }

            public static string GetHotNewsDetailUrl(string lang, string width, string id)
            {
                return "/TinHot/Default.aspx?lang=" + lang + "&display=" + "detail" + "&w=" + width + "&id=" + id;
            }

            public static string GetNewsDetailUrlTheThaoSo(string lang, string width, string id)
            {
                return "/Tintuc/Default.aspx?lang=" + lang + "&display=ndetail&w=" + width + "&id=" + id;
            }

            public static string GetNewsDetailUrlNew(string lang, string display, string width, string id)
            {
                return "/Tintuc/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }
            //Trang Category Tin tuc

            public static string GetLastestNewsTheThaoSo(string lang, string width)
            {
                return "~/Tintuc/Default.aspx?lang=" + lang + "&display=nlist&w=" + width;
            }

            public static string GetNewsCategoryUrl(string lang, string width, string catid)
            {
                return "/Tintuc/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
            }

            public static string WebNewsCategoryUrl(string catid)
            {
                return "/TinHot/Default.aspx?display=wlist&catid=" + catid;
            }

            public static string WebNewsDetailUrl(string id)
            {
                return "/TinHot/Default.aspx?display=wDetail&id=" + id;
            }

            public static string GetHotNewsCategoryUrl(string lang, string width, string catid,int page)
            {
                return "/TinHot/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid + "&cpage=" + page;
            }

            public static string GetNewsCategoryUrlNew(string lang, string width, string catid)
            {
                return "/Tintuc/DefaultNew.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
            }

            public static string GetTinTucNewDownloadUrl(string lang, string width, string id)
            {
                return "/tintuc247/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
            }
            public static string GetTinTucNewSearchResultUrl(string lang, string display, string width, string key)
            {
                return "/tintuc247/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key;
            }
            public static string GetTinTucNewDetailUrl(string lang, string display, string width, string id)
            {
                return "/tintuc247/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }
            public static string GetTinTucNewCategoryUrl(string lang, string width, string catid)
            {
                return "/tintuc247/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
            }

            public static string GetTinTucNewHomeUrl(string lang, string width)
            {
                return "/tintuc247/Default.aspx?lang=" + lang + "&display=home&w=" + width;
            }
        #endregion
        #region Trang video
            //Trang chu Video
            public static string GetVideoHomeUrl(string lang, string width)
            {
                return "/Video/Default.aspx?lang=" + lang + "&display=home&w=" + width;
            }

            public static string GetVideoHomeUrlNew(string lang, string width)
            {
                return "/Video/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
            }

            //Trang chi tiet Video
            public static string GetVideoDetailUrl(string lang, string display, string width, string id)
            {
                return "~/Video/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }
            public static string GetVideoDetailUrlNew(string lang, string display, string width, string id)
            {
                return "/Video/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }
            public static string GetVideoDetailUrlYoutube(string lang, string width, string id)
            {
                return "/Video/Default.aspx?lang=" + lang + "&display=ydetail&w=" + width + "&id=" + id;
            }

            //Trang Category Video
            public static string GetVideoCategoryUrl(string lang, string width, string catid)
            {
                return "~/Video/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
            }

            public static string GetVideoCategoryUrlYoutube(string lang, string width)
            {
                return "/Video/Default.aspx?lang=" + lang + "&display=ylist&w=" + width;
            }

            public static string GetVideoCategoryUrlNew(string lang, string width, string catid)
            {
                return "/Video/DefaultNew.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid;
            }

            //Trang ket qua tim kiem
            public static string GetVideoSearchResultUrl(string lang, string width, string key)
            {
                return "~/Video/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
            }

            public static string GetVideoSearchResultUrlNew(string lang, string width, string key)
            {
                return "/Video/DefaultNew.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
            }    

            //Trang charging của Video
            public static string GetVideoSendGiftUrl(string lang, string width, string id, string sdt)
            {
                return "~/Video/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt;
            }
            public static string GetVideoDownloadUrl(string lang, string width, string id)
            {
                return "~/Video/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
            }
            public static string GetVideoDownloadUrlNew(string lang, string width, string id)
            {
                return "/Video/DownloadNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
            }
            public static string GetVideoViewUrlNew(string lang, string width, string id)
            {
                return "/Video/ViewNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id;
            }
        #endregion
        
        #region Trang tin tuc V///
            //Trang chu V///
            public static string GetVNMNewsHomeUrl(string lang, string display, string width)
            {
                return "~/VNM/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width;
            }
            //Trang ket qua tim kiem
            public static string GetVNMNewsSearchResultUrl(string lang, string display, string width, string key)
            {
                return "~/VNM/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&key=" + key;
            }
            //Trang Tin chi tiet
            public static string GetVNMNewsDetailUrl(string lang, string display, string width, string id)
            {
                return "~/VNM/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id;
            }
            //Trang Category Tin tuc
            public static string GetVNMNewsCategoryUrl(string lang, string display, string width, string catid)
            {
                return "~/VNM/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&catid=" + catid;
            }
        #endregion
        #region Trang Xo so
            //Trang chu xo so
            public static string GetXosoHomeUrl(string lang, string width)
            {
                return "/Xoso/Default.aspx?lang=" + lang + "&display=home&w=" + width;
            }
            public static string GetXosoHomeUrlNew(string lang, string width)
            {
                return "/Xoso/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width;
            }
            //Trang xo so soi cau
            public static string GetXosoSoiCauDownloadUrl(string lang, string width, string id)
            {            
                return "~/Xoso/SoiCau.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }
            //Trang xo so kết quả trực tiếp
            public static string GetXosoKQChoDownloadUrl(string lang, string width, string id)
            {
                return "~/Xoso/KQCho.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }
            //Trang xo so kết quả 30 ngày
            public static string GetXosoKQ20NDownloadUrl(string lang, string width, string id)
            {
                return "~/Xoso/KQ20N.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }
            //Trang xo so kết quả by ngay
            public static string GetXosoKQByDayDownloadUrl(string lang, string width, string id)
            {
                return "~/Xoso/KQByDay.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }
            //Trang xo so kết quả 
            public static string GetXosoKQXSDownloadUrl(string lang, string width, string id, string day)
            {
                return "~/Xoso/KQXS.aspx?id=" + id + "&day=" + day + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterXoSoUrl(string lang,string width,string id)
            {
                return "/Xoso/S2/DangKyXS.aspx?id=" + id + "&lang=" + lang + "&w=" + width;         
            }

            public static string GetS2RegisterXoSoUrl2G(string lang, string width, string id)
            {
                return "/Xoso/S2/DangKyXS2G.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterSoiCauUrl(string lang, string width, string id)
            {
                return "/Xoso/S2/DangKySC.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterSoiCauUrl2G(string lang, string width, string id)
            {
                return "/Xoso/S2/DangKySC2G.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterResultXoSoUrl(string lang, string width, string id)
            {
                return "/Xoso/S2/KQXS.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterResultXoSoUrl2G(string lang, string width, string id)
            {
                return "/Xoso/S2/KQXS2G.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterResultSoiCauUrl(string lang, string width, string id)
            {
                return "/Xoso/S2/KQSC.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

            public static string GetS2RegisterResultSoiCauUrl2G(string lang, string width, string id)
            {
                return "/Xoso/S2/KQSC2G.aspx?id=" + id + "&lang=" + lang + "&w=" + width;
            }

        #endregion
        #region Trang Tra cuu
            //Trang chu tra cuu
            public static string GetTracuuHomeUrl(string lang, string width)
            {
                return "~/Bancanbiet/Default.aspx?lang=" + lang + "&display=home&w=" + width;
            }
        #endregion

        #region Trang Game
            //Trang chu Game
            public static string GetGameHomeUrl(string lang, string width, string hotro)
            {
                return "/Game/Default.aspx?lang=" + lang + "&display=home&w=" + width + "&hotro=" + hotro;
            }

            public static string GetGameHomeUrlNew(string lang, string width, string hotro)
            {
                return "/Game/DefaultNew.aspx?lang=" + lang + "&display=home&w=" + width + "&hotro=" + hotro;
            }
            
            //Trang ket qua tim kiem
            public static string GetGameSearchResultUrl(string lang, string width, string key, string hotro)
            {
                return "~/Game/Default.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
            }

            public static string GetGameSearchResultUrlNew(string lang, string width, string key, string hotro)
            {
                return "/Game/DefaultNew.aspx?lang=" + lang + "&display=search&w=" + width + "&key=" + key;
            }    

            //Trang chi tiet Game
            public static string GetGameDetailUrl(string lang, string display, string width, string id, string hotro)
            {
                return "~/Game/Default.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            public static string GetGameDetailUrlNew(string lang, string display, string width, string id, string hotro)
            {
                return "/Game/DefaultNew.aspx?lang=" + lang + "&display=" + display + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            } 

            //Trang Category Game
            public static string GetGameCategoryUrl(string lang, string width, string catid, string hotro)
            {
                return "~/Game/Default.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid + "&hotro=" + hotro;
            }
            public static string GetGameCategoryUrlNew(string lang, string width, string catid, string hotro)
            {
                return "/Game/DefaultNew.aspx?lang=" + lang + "&display=list&w=" + width + "&catid=" + catid + "&hotro=" + hotro;
            }
            //Trang charging của Game        
            public static string GetGameSendGiftUrl(string lang, string width, string id, string sdt, string hotro)
            {
                return "~/Game/SendGift.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&sdt=" + sdt + "&hotro=" + hotro;
            }
            public static string GetGameDownloadUrl(string lang, string width, string id, string hotro)
            {
                return "~/Game/Download.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            public static string GetGameDownloadUrlNew(string lang, string width, string id, string hotro)
            {
                return "/Game/DownloadNew.aspx?lang=" + lang + "&w=" + width + "&id=" + id + "&hotro=" + hotro;
            }
            //Trang download cua Game
            public static string GetGameDownloadItem(string telco, string itemtype, string itemid, string encode)
            {
                //itemtype = 1 : hinh nen
                //itemtype = 2 : Nhac chuong
                //itemtype = 3: game
                //itemtype = 4: app
                //itemtype = 5: video
                //itemtype = 6: y kien chuyen gia
                //itemtype = 7: tip
                //itemtype = 8: ket qua cho
                //itemtype = 9: ket qua xo so
                //itemtype = 10: soi cau
                //itemtype = 11: ket qua xoso cho
                //itemtype = 12: ket qua xoso 20 ngay lien tiep
                //itemtype = 13: truyen cuoi
                return ConfigurationSettings.AppSettings.Get("vnmdownload") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
            }

        
            public static string GetGameS2RegisterUrl(string lang,string width)
            {
                return "/Game/S2_DangKy.aspx?lang=" + lang + "&w=" + width;
            }

            public static string GetGameS2RegisterUrl2G(string lang, string width)
            {
                return "/Game/S2_DangKy2G.aspx?lang=" + lang + "&w=" + width;
            }

            public static string GetGameS2RegisterSuccessUrl(string lang, string width)
            {
                return "/Game/S2_KetQua.aspx?lang=" + lang + "&w=" + width;
            }

            public static string GetGameS2RegisterSuccessUrl2G(string lang, string width)
            {
                return "/Game/S2_KetQua2G.aspx?lang=" + lang + "&w=" + width;
            }

        #endregion
        //Trang download
        public static string GetDownloadItem(string telco, string itemtype, string itemid, string encode)
        {
            //itemtype = 1 : hinh nen
            //itemtype = 2 : Nhac chuong
            //itemtype = 3: game
            return ConfigurationSettings.AppSettings.Get("download") + "?telco=" + telco + "&type=" + itemtype + "&id=" + itemid + "&code=" + encode;
        }

        #region Diem thi
        //Trang chu diem thi
        public static string GetDiemthiHomeUrl(string lang, string width)
        {
            return "~/Diemthi/Default.aspx?lang=" + lang + "&display=home&w=" + width;
        }
        //
        public static string GetDiemthi_DT_THCSUrl(string lang, string width)
        {
            return "~/Diemthi/DT_THCS.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_XH_THCSUrl(string lang, string width)
        {
            return "~/Diemthi/XH_THCS.aspx?lang=" + lang + "&w=" + width;
        }
        //
        public static string GetDiemthi_DT_PTTHUrl(string lang, string width)
        {
            return "~/Diemthi/DT_PTTH.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_XH_PTTHUrl(string lang, string width)
        {
            return "~/Diemthi/XH_PTTH.aspx?lang=" + lang + "&w=" + width;
        }
        //
        public static string GetDiemthi_DT_DHUrl(string lang, string width)
        {
            return "~/Diemthi/DT_DH.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_XH_DHUrl(string lang, string width)
        {
            return "~/Diemthi/XH_DH.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_DiemchuanUrl(string lang, string width)
        {
            return "~/Diemthi/Diemchuan.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_TilechoiUrl(string lang, string width)
        {
            return "~/Diemthi/TiLeChoi.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_DauTruotUrl(string lang, string width)
        {
            return "~/Diemthi/DauTruot.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_1_3Url(string lang, string width)
        {
            return "~/Diemthi/1_3.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_DapanUrl(string lang, string width)
        {
            return "~/Diemthi/Dapan.aspx?lang=" + lang + "&w=" + width;
        }
        //
        public static string GetDiemthi_MaTinhUrl(string lang, string width)
        {
            return "~/Diemthi/MaTinh.aspx?lang=" + lang + "&w=" + width;
        }
        public static string GetDiemthi_MaTruongUrl(string lang, string width)
        {
            return "~/Diemthi/MaTruong.aspx?lang=" + lang + "&w=" + width;
        }
        #endregion

        #region Download Free

        public static string GetGameFreeDownloadUrlNew(string lang, string width)
        {
            return "/Wap/GameDownloadNew.aspx?lang=" + lang + "&w=" + width;
        }

        public static string GetRingToneFreeDownloadUrlNew(string lang, string width)
        {
            return "/Wap/RTDownloadNew.aspx?lang=" + lang + "&w=" + width;
        }

        public static string GetWallpaperFreeDownloadUrlNew(string lang, string width)
        {
            return "/Wap/WallpaperDownloadNew.aspx?lang=" + lang + "&w=" + width;
        }

        public static string GetVideoFreeDownloadUrlNew(string lang, string width)
        {
            return "/Wap/VideoDownloadNew.aspx?lang=" + lang + "&w=" + width;
        }
        
        #endregion

        #region URL REWRITE
        
        public static string TinTucHome()
        {
            return "/" + Constant.Constant.TinTucRewrite + ".aspx";
        }

        public static string TinTucChuyenMuc(int catId,int page,string cateName)
        {
            //cateName = UnicodeUtility.RemoveSpecialCharacter(cateName);
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ","-");

            return "/" + Constant.Constant.TinTucRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string WebTinTucChuyenMuc(string catId,string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");
            return "/" + Constant.Constant.TinKhuyenMaiRewrite + "/chuyen-muc/" + catId + "/" + cateName + ".aspx";
        }

        public static string WebTinTucChiTiet(string id, string title)
        {
            title = UnicodeUtility.UnicodeToKoDau(title).Replace(" ", "-");
            title = UnicodeUtility.RemoveSpecialCharacter(title);
            return "/" + Constant.Constant.TinKhuyenMaiRewrite + "/chi-tiet/" + id + "/" + title + ".aspx";
        }

        public static string TinTucChiTiet(int id,string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TinTucRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string GioiTinhHome()
        {
            return "/" + Constant.Constant.GioiTinhRewrite + ".aspx";
        }

        public static string GioiTinhChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.GioiTinhRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string GioiTinhChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.GioiTinhRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string TruyenOnlineHome()
        {
            return "/" + Constant.Constant.TruyenOnlineRewrite + ".aspx";
        }

        public static string TruyenOnlineChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.TruyenOnlineRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string TruyenOnlineChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TruyenOnlineRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string TruyenAudioHome()
        {
            return "/" + Constant.Constant.TruyenAudioRewrite + ".aspx";
        }

        public static string TruyenAudioChuyenMuc(string catId, int page, string cateName)
        {
            cateName = UnicodeUtility.RemoveSpecialCharacter(cateName);
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.TruyenAudioRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string TruyenAudioChiTiet(string id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TruyenAudioRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        #endregion

        #region URL REWRITE GAME

        public static string GameHome()
        {
            return "/" + Constant.Constant.GameRewrite + ".aspx";
        }

        public static string GameChuyenMuc(int catId, int page, string cateName)
        {
            //cateName = UnicodeUtility.RemoveSpecialCharacter(cateName);
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.GameRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string GameChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.GameRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string GameDownload(int id)
        {
            return "/" + Constant.Constant.GameRewrite + "/" + id + "/download.aspx";
        }

        #endregion

        #region URL REWRITE THU_GIAN

        public static string ThuGianHome()
        {
            return "/" + Constant.Constant.ThuGianRewrite + ".aspx";
        }

        public static string ThuGianChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.ThuGianRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string ThuGianChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.ThuGianRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string ThuGianDowload(string id)
        {
            return "/" + Constant.Constant.ThuGianRewrite + "/" + id + "/" + "download.aspx";
        }

        #endregion

        #region URL REWRITE VIDEO

        public static string VideoHome()
        {
            return "/" + Constant.Constant.VideoRewrite + ".aspx";
        }
        

        public static string VideoChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.VideoRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string YoutubeChuyenMuc(int page, string cateName)
        {
            cateName = UnicodeUtility.RemoveSpecialCharacter(cateName);
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.YoutubeFilmRewrite + "/" + page + "/" + cateName + ".aspx";
        }

        public static string YoutubeTimKiem(string key,int page, string cateName)
        {
            cateName = UnicodeUtility.RemoveSpecialCharacter(cateName);
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.YoutubeFilmRewrite + "/" + page + "/" + cateName + ".aspx?key=" + key;
        }

        public static string YoutubeChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.YoutubeFilmRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string VideoChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.VideoRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string VideoDownload(int id)
        {
            return "/" + Constant.Constant.VideoRewrite + "/" + id + "/download.aspx";
        }

        public static string VideoView(int id)
        {
            return "/" + Constant.Constant.VideoRewrite + "/" + id + "/view.aspx";
        }

        #endregion

        #region URL REWRITE HOANG_DAO

        public static string HoangDaoHome()
        {
            return "/" + Constant.Constant.HoangDaoRewrite + ".aspx";
        }

        public static string HoangDaoChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.HoangDaoRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string HoangDaoChiTiet(int id, string name,string type)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.HoangDaoRewrite + "/chi-tiet/" + id + "-" + type + "/" + name + ".aspx";
        }

        public static string HoangDaoDownload(int id,string type)
        {
            return "/" + Constant.Constant.HoangDaoRewrite + "/" + id + "-" + type + "/download.aspx";
        }

        #endregion

        #region URL REWRITE PHAN MEM

        public static string PhanMemHome()
        {
            return "/" + Constant.Constant.PhanMemRewrite + ".aspx";
        }

        public static string PhanMemChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.PhanMemRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string PhanMemChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.PhanMemRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string PhanMemDowload(string id)
        {
            return "/" + Constant.Constant.PhanMemRewrite + "/" + id + "/" + "download.aspx";
        }

        #endregion

        #region HINH NEN

        public static string HinhNenHome()
        {
            return "/" + Constant.Constant.HinhNenRewrite + ".aspx";
        }

        public static string HinhNenChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.HinhNenRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string HinhNenChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.HinhNenRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string HinhNenDowload(int id,int catId)
        {
            return "/" + Constant.Constant.HinhNenRewrite + "/" + catId + "/" + id + "/" + "download.aspx";
        }

        #endregion

        #region MUSIC

        public static string AmNhacHome()
        {
            return "/" + Constant.Constant.AmNhacRewrite + ".aspx";
        }

        public static string AmNhacChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChuyenMucAlbum(string catId, string cateName, string page)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/album/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChuyenMucCaSy(string catId, string cateName, string page)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/ca-sy/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChuyenMucCaSyList(string catId, string cateName, string page)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/ca-sy-list/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChuyenMucTheLoai(string catId, string cateName, string page)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/the-loai/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChuyenMucTheLoaiList(string catId, string cateName, string page)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/the-loai-list/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string AmNhacChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string AmNhacAlbumChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.AmNhacRewrite + "/album/" + id + "/" + name + ".aspx";
        }

        public static string AmNhacDowload(string id)
        {
            return "/" + Constant.Constant.AmNhacRewrite + "/" + id + "/" + "download.aspx";
        }

        #endregion

        #region XO SO

        public static string XoSoHome()
        {
            return "/" + Constant.Constant.XoSoRewrite + ".aspx";
        }

        public static string XoSoChuyenMuc(int catId, int page, string cateName)
        {
            cateName = UnicodeUtility.UnicodeToKoDau(cateName).Replace(" ", "-");

            return "/" + Constant.Constant.XoSoRewrite + "/chuyen-muc/" + catId + "/" + page + "/" + cateName + ".aspx";
        }

        public static string XoSoChiTiet(int id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.XoSoRewrite + "/chi-tiet/" + id + "/" + name + ".aspx";
        }

        public static string XoSoChiTietNew(int id,string day, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.XoSoRewrite + "/chi-tiet/" + id + "-" + day + "/" + name + ".aspx";
        }

        public static string XoSoDowload(int id, int catId)
        {
            return "/" + Constant.Constant.XoSoRewrite + "/" + catId + "/" + id + "/" + "download.aspx";
        }

        #endregion

        #region The Thao

        public static string TheThaoHome()
        {
            return "/" + Constant.Constant.TheThaoRewrite + ".aspx";
        }

        public static string TheThaoTuVanDacBiet()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/tu-van-dac-biet.aspx";
        }

        public static string TheThaoThongKeDacBiet()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/thong-ke-dac-biet.aspx";
        }

        public static string TheThaoBangXepHang()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/bang-xep-hang.aspx";
        }

        public static string TheThaoLichThiDau()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/lich-thi-dau.aspx";
        }

        public static string TheThaoLichThiDauHomNay()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/lich-thi-dau-hom-nay.aspx";
        }

        public static string TheThaoKetQuaThiDau()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/ket-qua-thi-dau.aspx";
        }

        public static string TheThaoKetQuaThiDauChiTiet(string id, string name,string page)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            //return "/" + Constant.Constant.TheThaoRewrite + "/ket-qua-thi-dau" + "/" + id + "/" + name + ".aspx";
            return "/" + Constant.Constant.TheThaoRewrite + "/ket-qua-thi-dau/" + id + "/" + page + "/" + name + ".aspx";
        }

        public static string TheThaoLichThiDauChiTiet(string id, string name, string page)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TheThaoRewrite + "/lich-thi-dau/" + id + "/" + page + "/" + name + ".aspx";
        }

        public static string TheThaoBangXepHangChiTiet(string id, string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TheThaoRewrite + "/bang-xep-hang" + "/" + id + "/" + name + ".aspx";
        }

        public static string TheThaoKetQuaHomNay()
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/ket-qua-hom-nay.aspx";
        }

        public static string TheThaoThongKeDacBietChiTiet(string id,string name)
        {
            name = UnicodeUtility.RemoveSpecialCharacter(name);
            name = UnicodeUtility.UnicodeToKoDau(name).Replace(" ", "-");

            return "/" + Constant.Constant.TheThaoRewrite + "/thong-ke" + "/" + id + "/" + name + ".aspx";
        }

        public static string TheThaoTranCauVang(string id)
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/" + id + "/tran-cau-vang.aspx";
        }

        public static string TheThaoThongKe(string id)
        {
            return "/" + Constant.Constant.TheThaoRewrite + "/" + id + "/thong-ke.aspx";
        }

        #endregion
    }
}
