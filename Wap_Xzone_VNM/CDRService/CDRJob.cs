using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Common.Logging;
using Quartz;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
namespace CDRService
{
    public class CDRJob : IJob
    {
        log4net.ILog _logger = log4net.LogManager.GetLogger("File");
         private DataTable dtCDR;

        public CDRJob()
        {
            dtCDR = new DataTable();
        }

        public virtual void Execute(JobExecutionContext context)
        {
            try
            {
                SqlDataReader dr = null;
                DateTime fromTime = DateTime.Now.AddMinutes(Convert.ToInt32(ConfigurationManager.AppSettings.Get("timeFrequency")));
                DateTime toTime = DateTime.Now;
                try
                {
                    dtCDR = Controller.GetAllTransaction(fromTime, toTime);
                    if (dtCDR != null && dtCDR.Rows.Count > 0)
                    {
                        string fileName = "VMGWAP_" + DateTime.Now.ToString("yyyyMMdd");
                        string folderName = ConfigurationManager.AppSettings.Get("fileFolderName") + DateTime.Now.ToString("yyyyMMdd") + "\\";
                        if (!Directory.Exists(folderName))
                        {
                            Directory.CreateDirectory(folderName);
                            fileName += "_0001.cdr";
                        }
                        else {
                            DirectoryInfo di = new DirectoryInfo(folderName);
                            FileInfo[] files = di.GetFiles("*.cdr");
                            DateTime lastest = DateTime.Now.AddDays(-1);
                            string lastestfile = string.Empty;
                            foreach (FileInfo f in files) { 
                                if(lastest < f.LastWriteTime){
                                    lastest = f.LastWriteTime;
                                    lastestfile = f.Name;
                                }
                            }
                            string str="1";
                            if(!(string.IsNullOrEmpty(lastestfile))){
                                str = lastestfile.Substring(lastestfile.LastIndexOf("_")+1,4);
                            }
                            fileName += "_" + (Convert.ToInt32(str)+1).ToString().PadLeft(4,'0') + ".cdr";
                        }
                        string path = folderName + fileName;

                        WriteFileToFtpAndHardDisk(path, dtCDR, fileName); 
                    }
                }
                catch (Exception ex) 
                { 
                    _logger.Info("=========SportSMSJob: ==============");
                    _logger.Info(ex.Message);
                }
            }
            catch (Exception ex)
            {
                _logger.Info(ex.Message);
            }
        }

        private void WriteFileToFtpAndHardDisk(string path, DataTable dt, string fileName)
        {
            try
            {
                FileStream Tex = File.Create(path);
                foreach (DataRow row in dt.Rows)
                {
                    CDRInfo info = new CDRInfo();

                    info.Datetime = Convert.ToDateTime(row["Wap_TransactionOn"]).ToString("yyyyMMddHHmmss");
                    info.A_Number = row["Wap_Transaction_Mobile"].ToString();
                    info.B_Number = "049219";
                    info.EventID = "000000";
                    info.CPID = "000009";//VMG CP
                    info.ContentID = row["Wap_TransactionName"].ToString();
                    if (row["ErrorCode"].ToString() == "0")
                        info.Status = "1";
                    else
                        info.Status = "0";
                    info.Cost = row["Wap_Transaction_Amount"].ToString();
                    info.ChannelType = "WAP";
                    info.Information = "0";
                    AddText(Tex, info.Datetime + ":");
                    AddText(Tex, info.A_Number + ":");
                    AddText(Tex, info.B_Number + ":");
                    AddText(Tex, info.EventID + ":");
                    AddText(Tex, info.CPID + ":");
                    AddText(Tex, info.ContentID + ":");
                    AddText(Tex, info.Status + ":");
                    AddText(Tex, info.Cost + ":");
                    AddText(Tex, info.ChannelType + ":");
                    AddText(Tex, info.Information);
                    AddText(Tex, Environment.NewLine);
                }

                Tex.Close();
                Tex.Dispose();
                
                //Open the stream and read it back.
                if (Convert.ToInt32(ConfigurationManager.AppSettings.Get("OpenFTP")) == 1)
                {
                    FileStream fsread = File.OpenRead(path);
                    try
                    {
                        _logger.Debug("Open FTPConnection");
                        FtpConnection connection = new FtpConnection();
                        connection.Host = ConfigurationManager.AppSettings.Get("ftpAddress");
                        connection.UserName = ConfigurationManager.AppSettings.Get("ftpConnectionUserName");
                        connection.Password = ConfigurationManager.AppSettings.Get("ftpConnectionPassWord");
                        connection.RemoteDirectory = "/";
                        connection.MakeDirectory(DateTime.Now.ToString("yyyyMMdd"));
                        connection.Upload(fsread,DateTime.Now.ToString("yyyyMMdd") + "/" + fileName);
                        _logger.Debug("fpt path: " + DateTime.Now.ToString("yyyyMMdd") + "/" + fileName);
                        fsread.Close();
                        fsread.Dispose();
                        _logger.Debug("Upload file successfully");

                    }
                    catch (Exception ex)
                    {
                        _logger.Debug("Happen error when write file:" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Debug("Happen error when write file:" + ex.Message);
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        private string GetCategoryName(int _type)
        {
            switch (_type)
            {
                case 1: return "Hinh Nen"; 
                case 2: return "Nhac chuong"; 
                case 3: return "Java Game"; 
                case 4: return "Mobile App";
                case 5: return "Video"; 
                case 6: return "Y kien chuyen gia";
                case 7: return "Tip"; 
                case 8: return "Ket qua cho bong da"; 
                case 9: return "Ket qua xo so";
                case 10: return "Soi cau"; 
                case 11: return "Ket qua xo so cho";
                case 12: return "Ket qua xo so 20 ngay"; 
                case 13: return "Truyen cuoi"; 
                case 14: return "Tran cau 87";
                default: return "";
            }
        }
    }
}
