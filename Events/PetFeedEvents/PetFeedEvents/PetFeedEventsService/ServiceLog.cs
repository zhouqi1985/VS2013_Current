using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PetFeedEventsService
{
    public class ServiceLog
    {
        public static void InfoLog(string msg)
        {
            string txt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Information." + msg;
            SaveFile(txt);
        }

        public static void ErrorLog(Exception ex)
        {
            string txt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "Exception." + ex.Message;
            SaveFile(txt);
        }

        private static void SaveFile(string txt)
        {
            string LogPath = AppDomain.CurrentDomain.BaseDirectory + "Log\\" + DateTime.Now.ToString("yyyyMMdd") + "log.txt";
            if (!Directory.Exists(LogPath)) Directory.CreateDirectory(Path.GetDirectoryName(LogPath));
            StreamWriter sw = new StreamWriter(LogPath, true, Encoding.GetEncoding("utf-8"));
            sw.WriteLine(txt);
            sw.Close();
        }

    }
}
