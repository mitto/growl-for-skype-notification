using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Growl_for_Skype_Notification
{
    public static class LogManager
    {
        private static readonly string FileName = String.Format("log-{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));

        public static void WriteLineTSV(DateTime time, string type, string name, string id, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string path = Path.Combine(SettingManager.LogFileDirectoryPath, FileName + ".tsv");

            using (var writer = File.AppendText(path))
            {
                writer.WriteLine("{0}\t{1}\t{2}\t{3}", date, type, name, message);
            }
        }

        public static void WriteLineCSV(DateTime time, string type, string name, string id, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string path = Path.Combine(SettingManager.LogFileDirectoryPath, FileName + ".csv");

            using (var writer = File.AppendText(path))
            {
                writer.WriteLine("{0},{1},{2},{3}", date, type, name, message);
            }
        }

    }
}
