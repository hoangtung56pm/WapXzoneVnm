using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;

namespace VmgPortal.Modules.Adsvertising.Lib
{
    public class MultimediaUtility
    {
        public static string strInitFlashWithActiveContent(string fileName, int width, int height, string _align)
        {
            string retVal = "<script type=\"text/javascript\">";
            retVal += "AC_FL_RunContent( 'codebase','http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0','width','" + width + "','height','" + height + "','id','" + fileName + "','align','" + _align + "','src','" + fileName + "','quality','high','bgcolor','','name','" + fileName + "','allowscriptaccess','sameDomain','pluginspage','http://www.macromedia.com/go/getflashplayer','movie','" + fileName + "' );";
            retVal += "</script>";
            return retVal;
        }
        public static string strInitFlash(string flashURL, int width, int height)
        {
            string retVal = "<EMBED align=baseline src='" + flashURL + "'";
            if (width != 0) retVal += " width=" + width;
            if (height != 0) retVal += " height=" + height;

            retVal += " type=audio/x-pn-realaudio-plugin autostart=\"true\" controls=\"ControlPanel\" console=\"Clip1\" border=\"0\">";
            return retVal;
        }



        public static string strInitMultimedia(string mediaPath, int width, int height)
        {
            string retVal = "<EMBED pluginspage='http://www.microsoft.com/Windows/Downloads/Contents/Products/MediaPlayer/' ";
            if (width != 0) retVal += " width=" + width;
            if (height != 0) retVal += " height=" + height;

            retVal += " src='" + mediaPath + "' type='application/x-mplayer2' ShowStatusBar='1' AutoStart='true' ShowControls='1'></embed>";
            return retVal;
        }
    }
}
