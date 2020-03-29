using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace ChaserAssistant
{
    public static class CheckWarnung
    {
        public static Dictionary<int, string> Warnungen = new Dictionary<int, string>();

        public static void CreateCollection(string url)
        {

            using (WebClient client = new WebClient())
            {
                client.Encoding = System.Text.Encoding.UTF7;
                client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";

                try
                {                
                    // Sonderzeichen ausmerzen
                    var data = client.DownloadData(url);
                    var encoded = System.Text.Encoding.UTF7.GetString(data);

                    string noHTML = Regex.Replace(encoded, @"<[^>]+>|&nbsp;", "").Trim();
                    string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");

                    string[] splitted = noHTML.Split(null);
                    int counter = 0;

                    for (int i = 0; i < splitted.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(splitted[i]))
                        {
                            continue;
                        }
                        else if (splitted[i].StartsWith("WW"))
                        {
                            counter++;
                            Warnungen.Add(counter, splitted[i]);
                        }

                    }


                    Console.WriteLine("Test für BaWü:");
                    foreach (var warnung in Warnungen)
                    {
                        Console.WriteLine(warnung.ToString());

                        if (warnung.Key == Warnungen.Count)
                        {
                            Console.WriteLine("Latest:");
                            Console.WriteLine(warnung.ToString());
                        }

                    }



                    //Console.WriteLine(noHTML);


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
