/*  ChaserAssistant - a tool to fetch stormchasing information 

    Copyright(C) 2020 Willy Weinmann

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace ChaserAssistant
{
    public static class Wochenvorhersage
    {
        public static Dictionary<int, string> WVHS = new Dictionary<int, string>();

        public static string GetFilenameOnServer(string url)
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
                    //string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");
                    string filename = string.Empty;

                    string[] splitted = noHTML.Split(null);
                    int counter = 0;

                    for (int i = 0; i < splitted.Length; i++)
                    {
                        if (string.IsNullOrWhiteSpace(splitted[i]))
                        {
                            continue;
                        }
                        else if (splitted[i].StartsWith("VHDL35"))
                        {
                            if (splitted[i].StartsWith("VHDL35_DWOG") && ReactOnArgs.WL_Region.ToLower() == "de")
                            {
                                counter++;
                                WVHS.Add(counter, splitted[i]);
                                continue;
                            }

                        }

                    }



                    foreach (var bericht in WVHS)
                    {
                        //Console.WriteLine(bericht.ToString());

                        if (bericht.Key == WVHS.Count)
                        {
                            //Console.WriteLine("Latest:");
                            //Console.WriteLine(bericht.ToString());
                            filename = bericht.Value;
                        }
                    }

                    return filename;

                }
                catch (WebException we)
                {
                    // WebException.Status holds useful information 
                    Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
                    return "Error, WebException Wochenvorhersage";
                }
                catch (NotSupportedException ne)
                {
                    // other errors 
                    Console.WriteLine("NotSupportedException: " + ne.Message);
                    return "Error, NotSupportedException Wochenvorhersage";
                }
            }

        }


        public static bool Region(string region)
        {
            bool noerrors = false;
            string file = string.Empty;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** ChaserAssistant - aktuellste Wochenvorhersage DE:" + region);
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            switch (region)
            {
                case "DE":
                case "de":
                    file = GetFilenameOnServer(MainClass.DE_PATH);
                    MainClass.dwdURL = MainClass.DE_PATH + file;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
                    file = string.Empty;
                    break;

                default:
                    Console.WriteLine("Default ....: " + MainClass.dwdURL);
                    noerrors = false;
                    break;
            }

            if (noerrors)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
