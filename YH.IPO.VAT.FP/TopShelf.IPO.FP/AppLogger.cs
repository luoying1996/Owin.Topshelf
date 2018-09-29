using System;
using System.IO;
using System.Text;

namespace TopShelf.IPO.FP
{
    public class AppLogger
    {
        public static string Info(string msg)
        {
            WriteTextLog(msg, DateTime.Now);
            return msg;
        }
        public static void WriteTextLog(string strMessage, DateTime time)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"System\Log\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string fileFullPath = path + time.ToString("yyyy-MM-dd") + ".System.txt";
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Message: {0}-,{1}", time, strMessage);
            str.Append("-----------------------------------------------------------\r\n");
            StreamWriter sw;
            if (!File.Exists(fileFullPath))
            {
                sw = File.CreateText(fileFullPath);
            }
            else
            {
                sw = File.AppendText(fileFullPath);
            }
            sw.WriteLine(str.ToString());
            sw.Close();
        }
    }
}
