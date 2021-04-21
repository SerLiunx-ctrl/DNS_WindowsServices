using System;
using System.IO;
using System.Net;
using System.Text;

namespace DNS_WindowsServices.Utils
{
    class Internet
    {
        public static string Post(string str,string url)
        {
            string result = "";
            var req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            byte[] data = Encoding.UTF8.GetBytes(str);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
                return "error";
            }
            return result;
        }

        public static string GetIpaddress(string ipserver)
        {
            return StringDownload(ipserver);
        }

        public static string GetVersion(string url)
        {
            if (StringDownload(url) == "error")
                return "无法获取最新版本";

            return StringDownload(url);
        }

        private static string StringDownload(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = Encoding.Default;
                string response = client.DownloadString(url);
                return response;
            }
            catch (Exception)
            {
                return "error";
            }
        }

    }
}
