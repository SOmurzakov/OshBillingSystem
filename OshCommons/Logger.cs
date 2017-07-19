using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Windows.Forms;

namespace OshCommons
{
    public static class Logger
    {

        private static string _longDelimeter = "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
        private static List<string> _registeredCategories = new List<string>();

        private static int limitMessageLength = 0;
        private static string fileNameDateFormat = "yyyy-MM-dd";
        private static string logMessageDateFormat = "HH:mm:ss.fff";
        private static object lockObject = "Hello world";
        private static string logsPath;
        private static string applicationName;

        public static void WriteWithCategory(string category, string message, params object[] parameters)
        {
            WriteWithCategory(category, GetStringFormatted(message, parameters));
        }

        private static string GetStringFormatted(string message, object[] parameters)
        {
            try
            {
                return string.Format(message, parameters);
            }
            catch (Exception)
            {
                return message;
            }
        }

        public static void WriteWithCategory(string category, string message)
        {
            string path = GetLogFileName(category);

            message = DateTime.Now.ToString(logMessageDateFormat) + " " + message + "\n";

            if (!_registeredCategories.Contains(category))
            {
                message = _longDelimeter + message;
                _registeredCategories.Add(category);
            }

            WriteToFile(message, path);
        }

        public static void Write(string message)
        {
            WriteWithCategory(GetApplicationName(), message);
        }

        public static void Write(string message, params object[] parameters)
        {
            Write(GetStringFormatted(message, parameters));
        }

        //

        private static string GetLogFileName(string category)
        {
            string path = string.Format("{0}-{1}.txt", DateTime.Now.ToString(fileNameDateFormat), category);
            path = Path.Combine(GetLogsPath(), path);
            return path;
        }

        private static string GetLogsPath()
        {
            if (string.IsNullOrEmpty(logsPath))
            {

                logsPath = "";

                try
                {
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("LogsPath"))
                    {
                        logsPath = ConfigurationManager.AppSettings["LogsPath"];
                    }
                }
                catch
                {
                }

                if (string.IsNullOrEmpty(logsPath))
                {
                    logsPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Logs");
                }
            }

            if (!Directory.Exists(logsPath))
            {
                Directory.CreateDirectory(logsPath);
            }

            return logsPath;
        }

        private static string GetApplicationName()
        {
            if (applicationName == null)
            {
                try
                {
                    applicationName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
                }
                catch (Exception)
                {
                    applicationName = "common";
                }
            }

            return applicationName;
        }

        private static void WriteToFile(string message, string path)
        {
            lock (lockObject)
            {
                try
                {
                    if (limitMessageLength > 0 && message.Length > limitMessageLength)
                    {
                        message = message.Substring(0, limitMessageLength) + "\n... (truncated) ...\n";
                    }

                    using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
                    {
                        writer.WriteLine(message);
                        writer.Close();
                    }
                }
                catch (Exception)
                {
                }
            }
        }

    }
}
