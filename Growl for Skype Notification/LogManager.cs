using System;
using System.IO;

namespace Growl_for_Skype_Notification
{
    public enum LogType
    {
        Csv,
        Tsv
    }

    public static class LogManager
    {
        private static readonly string FileName = String.Format("log-{0}", DateTime.Now.ToString("yyyyMMddHHmmss"));

        public static void WriteLine(DateTime time, string type, string name, string id, string message, LogType logtype = LogType.Csv)
        {
            switch (logtype)
            {
                case LogType.Csv:
                    WriteLineCsv(time, type, name, id, message);
                    break;
                case LogType.Tsv:
                    WriteLineTsv(time, type, name, id, message);
                    break;
            }
        }

        private static void WriteLineTsv(DateTime time, string type, string name, string id, string message)
        {
            string date = time.ToLongDateString() + time.ToLongTimeString();
            string path = Path.Combine(SettingManager.LogFileDirectoryPath, FileName + ".tsv");

            using (var writer = File.AppendText(path))
            {
                writer.WriteLine("{0}\t{1}\t{2}\t{3}", date, type, name, message);
            }
        }

        private static void WriteLineCsv(DateTime time, string type, string name, string id, string message)
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
