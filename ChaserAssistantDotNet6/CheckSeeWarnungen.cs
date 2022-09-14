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
using System.Text;

namespace ChaserAssistantDotNet6
{
    public static class CheckSeeWarnungen
    {
        public static Dictionary<int, string> Warnungen = new Dictionary<int, string>();
        public static Dictionary<int, string> Urls = new Dictionary<int, string>();

        public static bool Landkreis(string lk)
        {
            string landkreis = string.Empty;

            if (lk.Length == 1)
            {
                landkreis = "_" + lk + "X";
            }
            else
            {
                landkreis = "_" + lk;
            }

            StringBuilder warntexte = new StringBuilder();

            Urls.Add(1, "https://opendata.dwd.de/weather/alerts/txt/GER/");
            Urls.Add(2, "https://opendata.dwd.de/weather/alerts/txt/SU/");
            Urls.Add(3, "https://opendata.dwd.de/weather/alerts/txt/MS/");
            Urls.Add(4, "https://opendata.dwd.de/weather/alerts/txt/OF/");
            Urls.Add(5, "https://opendata.dwd.de/weather/alerts/txt/PD/");
            Urls.Add(6, "https://opendata.dwd.de/weather/alerts/txt/LZ/");
            Urls.Add(7, "https://opendata.dwd.de/weather/alerts/txt/HA/");
            Urls.Add(8, "https://opendata.dwd.de/weather/alerts/txt/EM/");

            using (HttpClient client = new())
            {
                //client.Encoding = System.Text.Encoding.UTF7;
                //client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";

                foreach (var address in Urls)
                {
                    try
                    {
                        // Sonderzeichen ausmerzen
                        var data = client.GetStreamAsync(address.Value).ToString();
                        var encoded = System.Text.Encoding.UTF8.GetBytes(data).ToString();

                        string noHTML = Regex.Replace(encoded, @"<[^>]+>|&nbsp;", "").Trim();

                        string[] splitted = noHTML.Split(null);
                        int counter = 0;

                        for (int i = 0; i < splitted.Length; i++)
                        {
                            //Console.WriteLine(splitted[i]);
                            //Console.WriteLine(landkreis);
                            if (string.IsNullOrWhiteSpace(splitted[i]))
                            {
                                continue;
                            }
                            else if (splitted[i].StartsWith("WWHA50") && splitted[i].Contains(landkreis))
                            {
                                counter++;
                                //Console.WriteLine(counter.ToString() + " - " + address.Value + splitted[i]);
                                Warnungen.Add(counter, address.Value + splitted[i]);

                            }
                        }

                        //Console.WriteLine(noHTML);


                    }
                    catch (WebException we)
                    {
                        // WebException.Status holds useful information 
                        Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
                        return false;
                    }
                    catch (NotSupportedException ne)
                    {
                        // other errors 
                        Console.WriteLine("NotSupportedException: " + ne.Message);
                        return false;
                    }

                }



            }


            if (Warnungen.Count > 0)
            {
                foreach (var warnung in Warnungen)
                {

                    warntexte.Append("------------------------------------------");
                    warntexte.Append(ReadText.GetWebsiteContent(warnung.Value));
                    //TextOutput.Show(warnung.Value);
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***** ChaserAssistant - aktuell gültige Seewetter-Warnungen für " + lk);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                TextOutput.Show(warntexte.ToString());
                return true;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("***** ChaserAssistant - keine Warnungen für angegebenes Gebiet gefunden");
                return false;
            }




        }
    }
}
