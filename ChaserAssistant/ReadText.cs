using System;
using System.Net;
using System.IO;

namespace ChaserAssistant
{
    public static class ReadText
    {
        internal static string remember = string.Empty;

        public static void GetWebsiteContent(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";

                try
                {


                    //string ret = client.DownloadString(url);
                    //Console.WriteLine(ret);

                    // Sonderzeichen ausmerzen
                    var data = client.DownloadData(url);
                    var encoded = System.Text.Encoding.UTF7.GetString(data);

                    Console.WriteLine(encoded);


                }
                catch (WebException we)
                {
                    // WebException.Status holds useful information 
                    Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
                    //Console.WriteLine("Vormals gewähltes land: " + remember);
                    //Console.ReadKey();

                }
                catch (NotSupportedException ne)
                {
                    // other errors 
                    Console.WriteLine("NotSupportedException: " + ne.Message);
                }

            }
        }
    }
}
