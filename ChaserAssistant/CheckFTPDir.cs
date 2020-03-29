using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ChaserAssistant
{
    public static class CheckFTPDir
    {
        public static void ReadDirectoryContent(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF7;
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";

                try
                {


                    //string ret = client.DownloadString(url);
                    //Console.WriteLine(ret);

                    // Sonderzeichen ausmerzen
                    var data = client.DownloadData(url);
                    var encoded = System.Text.Encoding.UTF7.GetString(data);

                    string noHTML = Regex.Replace(encoded, @"<[^>]+>|&nbsp;", "").Trim();
                    string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");

                    Console.WriteLine(noHTML);


                }
                catch (WebException we)
                {
                    // WebException.Status holds useful information 
                    Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
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
