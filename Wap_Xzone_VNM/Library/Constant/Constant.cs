using System;
using System.Collections.Generic;

using System.Web;

namespace WapXzone_VNM.Library.Constant
{
    public class Constant
    {

        public static string tintucchung = "00";
        public static string hoangdao = "53";
        public static string thethao = "02";
        public static string giaitri_haihuoc = "03";
        public static string nhacchuong = "21";
        public static string hinhnen = "31";
        public static string clipchung = "40";
        public static string ungdungchung = "50";
        public static string game = "51";
        public static string xoso = "55";

        public static string TinTucRewrite = "tin-tuc";

        public static string TinKhuyenMaiRewrite = "tin-khuyen-mai";

        public static string GioiTinhRewrite = "gioi-tinh";
        public static string TruyenOnlineRewrite = "truyen-online";
        public static string TruyenAudioRewrite = "truyen-audio";
        public static string GameRewrite = "smartphone-game";
        public static string ThuGianRewrite = "smartphone-thu-gian";

        public static string VideoRewrite = "smartphone-video";

        public static string HuongDan = "huongdan";

        public static string YoutubeFilmRewrite = "mphim";
        public static string YoutubeFilmRewriteCatName = "phim-hot";
        public static string YoutubeFilmRewriteSearch = "tim-phim";

        public static string HoangDaoRewrite = "smartphone-hoang-dao";
        public static string PhanMemRewrite = "smartphone-phan-mem";
        public static string HinhNenRewrite = "smartphone-hinh-nen";
        public static string AmNhacRewrite = "smartphone-am-nhac";
        public static string TheThaoRewrite = "smartphone-the-thao";
        public static string XoSoRewrite = "smartphone-xo-so";
        public static string XoSo_Kqxs_Rewrite = "ket-qua-xo-so";
        public static string XoSo_KqbyDay_Rewrite = "ket-qua-theo-ngay";
        public static string XoSo_KqCho_Rewrite = "ket-qua-cho";
        public static string XoSo_ThongKe_Rewrite = "thong-ke";
        public static string XoSo_Kq20ngay_Rewrite = "ket-qua-20-ngay";

        public enum Lang : int
        {
            //Tieng viet khong dau
            ENG = 0,

            //Tieng viet co dau
            VN = 1,
        }
        //Man hinh mac dinh
        public enum DefaultScreen : int
        {
          Standard = 320,
        }
        //Portal mac dinh
        public enum DefaultPortal : int
        {
            Mobifone = 94,
        }
        //Cau hinh trang hinh nen
        public enum HinhNen : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
        }

        //Cau hinh trang game
        public enum Game : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
        }
        //Cau hinh trang Video
        public enum Video : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
        }
        //Cau hinh trang RingTone
        public enum RingTone : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
            //HOT 100
            Hot100 = 4,
        }
        //Cau hinh trang RingBackTone
        public enum RingBackTone : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
        }
        //Cau hinh trang Phan mem
        public enum APP : int
        {
            //La category
            Category = 1,
            //La Moi nhat 
            Lastest = 2,
            //La top dowload
            Topdownload = 3,
        }
        public enum MessageType : int
        {
            //Ko tinh tien
            FREE = 0,
            //Tinh tien 
            CHARGE = 1,
            //Refund
            REFUND = 2,

        }
        //Cau hinh telCo
        public static string T_Undefined = "Undefined";
        public static string T_Mobifone = "Mobifone";
        public static string T_Vinaphone = "Vinaphone";
        public static string T_Viettel = "Viettel";
        public static string T_Vietnamobile = "Vietnamobile";
        public static string T_VietnamobileWap = "vietnamobile.com.vn";

        public enum Chancel : int
        {
            WALLPAPER = 1,
            RINGTONE = 2,
            GAME = 3,
            APP = 4,
            VIDEO = 5,
            YKCG = 6,
            TIP = 7,
            KQCHO = 8,
            KQXS = 9,
            SOICAU = 10,
            XSKQCHO = 11,
            XS20 = 12,
            THUGIAN = 13,
            GAME87 = 14,
            THUPHAP = 15,
            DIEMTHI = 16,
            HOANGDAO = 17,
            TUVI = 18,
        }

        public static string[] pmContentTypeVNM = {"TEXT","WP","TT", "JG", "APP", "VID", "YKCG", "TIP", "KQCHO",
            "KQXS", "SOICAU", "XSKQCHO", "XOSO20", "RELAX", "GAME87", "THUPHAP", "DiemThi", "Tu vi", "Tu vi"};


        public const int E_OK = 0; // Thanh cong

        public const int E_UNKNOWN = 1;//:       Lenh khong ho tro

        public const int E_FAILSE = 2;//:        That bai

        public const int E_NOTCONNECT = 3;//Mat ket noi toi CCS

        public const int E_OVERLOADED = 4;//:    Qua tai

        public const int E_TIMEOUT = 5;//:       Timeout    

        public const int E_INVALID_USERPASS = 6;// Sai username, password

        public const int NOT_HAS_PERMISSION = 7;// Khong co quyen thuc hien ham nay

        public const int WEBSERVICE_ERROR = 8; // Webservice dang bi loi

        public const int SUBCRIBER_NOT_FOUND = 9;//Khong tim thay thue bao nay

        public const int INVALID_SYNTAX = 10;// Cau truc lenh khong dung

        public const int MDN_IS_PROCESSING = 11;// Dang thuc hien giao dich truoc do

        public const int NOT_ENOUGH_MONEY = 12;// Khong du tien thuc hien dich vu

        public const int INVALID_STATE = 13; // Trang thai khong hop le

        public const int INVALID_AMOUNT = 14;// So tien khong hop le

        public const int INVALID_CURRENCY = 15;// Don vi khong hop le

        public const int FAIL_TO_DEDUCT = 16; // Deduct khong thanh cong

        public const int INVALID_CONDITION = 17;// Dieu kien khong hop le

        public const int WEBSERVICE_NOT_INITIALIZED = 18;// Khong thuc hien giao dich nay

        public const int E_INVALID_MSISDN = 19;// MSISDN khong hop le

        public const int E_INVALID_MSISDN_INVITE = 20;//MSISDN cua thue bao duoc moi trong friend&family khong hop le
            
    }
}
