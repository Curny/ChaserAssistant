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

namespace ChaserAssistantDotNet6
{
    public static class Warnlagebericht2
    {
        //public static Dictionary<int, string> WLB = new Dictionary<int, string>();
        public static bool noerrors = true;

        public static string GetFilenameOnServer(string url)
        {
            Dictionary<int, string> WLB = new Dictionary<int, string>();
            using (HttpClient client = new())
            {
                // next 2 lines are mainly for Windows:
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                //client.Encoding = System.Text.Encoding.UTF7;
                //client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/79.0.3945.130 Safari/537.36";

                try
                {
                    // Sonderzeichen ausmerzen
                    var data = client.GetStreamAsync(url).ToString();
                    var encoded = System.Text.Encoding.UTF8.GetBytes(data).ToString();

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
                        else if (splitted[i].StartsWith("VHDL30"))
                        {
                            // Hier liegen meherere Regionen in einem Verzeichnis und müssen auseinanderdividiert werden:
                            if (splitted[i].StartsWith("VHDL30_DWLG") && ReactOnArgs.WL_Region.ToLower()  == "sx")
                            {
                                // Sachsen
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWLH") && ReactOnArgs.WL_Region.ToLower()  == "sa")
                            {
                                // Sachsen-Anhalt
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWLI") && ReactOnArgs.WL_Region.ToLower()  == "th")
                            {
                                // Thüringen
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWPH") && ReactOnArgs.WL_Region.ToLower()  == "mv")
                            {
                                // Mecklenburg-Vorpommern
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWPG") && ReactOnArgs.WL_Region.ToLower()  == "bb")
                            {
                                // Berlin-Brandenburg
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWHG") && ReactOnArgs.WL_Region.ToLower() == "nb")
                            {
                                // Niedersachsen und Bremen
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWHH") && ReactOnArgs.WL_Region.ToLower()  == "shh")
                            {
                                // Schleswig-Holstein und Hamburg
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWOI") && ReactOnArgs.WL_Region.ToLower() == "rps")
                            {
                                // Rheinland-Pfalz und Saarland
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWOH") && ReactOnArgs.WL_Region.ToLower() == "he")
                            {
                                // Hessen
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            else if (splitted[i].StartsWith("VHDL30_DWOG") && ReactOnArgs.WL_Region.ToLower() == "de")
                            {
                                // Ganz Deutschland
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }

                            // für alle Verzeichnisse, wo nicht mehrere Regionen im Verzeichnis liegen:
                            else if (!splitted[i].Contains("_DWL") && !splitted[i].Contains("_DWP") && !splitted[i].Contains("_DWH") && !splitted[i].Contains("_DWO"))
                            {
                                counter++;
                                WLB.Add(counter, splitted[i]);
                                continue;
                            }
                        }
                    }


                    /*
                    // Hier holen wir den letzten (aktuellsten) Bericht aus der Liste:
                    foreach (var bericht in WLB)
                    {
                        //DEBUG:
                        //Console.WriteLine(bericht.ToString());

                        if (bericht.Key == WLB.Count)
                        {
                            //DEBUG:
                            //Console.WriteLine("Latest:");
                            //Console.WriteLine(bericht.ToString());
                            filename = bericht.Value;
                        }

                    }*/

                    filename = WLB[WLB.Count - 1];
                    return filename;
                }
                catch (WebException we)
                {
                    // WebException.Status holds useful information 
                    Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
                    noerrors = false;
                    return "Error";
                }
                catch (NotSupportedException ne)
                {
                    // other errors 
                    Console.WriteLine("NotSupportedException: " + ne.Message);
                    noerrors = false;
                    return "Error";
                }
            }

        }


        public static bool Region(string region)
        {
            //noerrors = false;
            string file = string.Empty;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** ChaserAssistant - aktuellster Warnlagebricht Region: " + region);
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            if (MainClass.RegionPathDictionary.ContainsKey(region.ToLower()))
            {
                file = GetFilenameOnServer(MainClass.RegionPathDictionary[region.ToLower()]);
                if (noerrors)
                {
                    MainClass.dwdURL = MainClass.RegionPathDictionary[region.ToLower()] + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));

                    // Sven
                    // hier das noerrors Ergebnis von GetWebsiteContent prüfen!
                    noerrors = true;
                    file = string.Empty;
                }
            }
            else
            {
                noerrors = false;
            }

            /*switch (region)
            {
                case "DE": // ganz Deutschland
                case "de":
                    file = GetFilenameOnServer(MainClass.DE_PATH);
                    MainClass.dwdURL = MainClass.DE_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "BW": // Baden-Württemberg
                case "bw":
                    file = GetFilenameOnServer(MainClass.BW_PATH);
                    MainClass.dwdURL = MainClass.BW_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "BY": // Bayern
                case "by":
                    file = GetFilenameOnServer(MainClass.BY_PATH);
                    MainClass.dwdURL = MainClass.BY_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "RPS": // Rheinland-Pfalz und Saarland
                case "rps":
                    file = GetFilenameOnServer(MainClass.OF_PATH);
                    MainClass.dwdURL = MainClass.OF_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;
                
                case "HE": // Hessem
                case "he":
                    file = GetFilenameOnServer(MainClass.OF_PATH);
                    MainClass.dwdURL = MainClass.OF_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "BB": // Berlin + Brandenburg
                case "bb":
                    file = GetFilenameOnServer(MainClass.PD_PATH);
                    MainClass.dwdURL = MainClass.PD_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "MV": // Mecklenburg-Vorpommern
                case "mv":
                    file = GetFilenameOnServer(MainClass.PD_PATH);
                    MainClass.dwdURL = MainClass.PD_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "SX": // Sachsen
                case "sx":
                    file = GetFilenameOnServer(MainClass.LZ_PATH);
                    MainClass.dwdURL = MainClass.LZ_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "SA": // Sachsen-Anhalt
                case "sa":
                    file = GetFilenameOnServer(MainClass.LZ_PATH);
                    MainClass.dwdURL = MainClass.LZ_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "TH": // Thüringen
                case "th":
                    file = GetFilenameOnServer(MainClass.LZ_PATH);
                    MainClass.dwdURL = MainClass.LZ_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "NB": // Niedersachsen und Bremen
                case "nb":
                    file = GetFilenameOnServer(MainClass.HA_PATH);
                    MainClass.dwdURL = MainClass.HA_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "SHH": // Schleswig-Holstein und Hamburg
                case "shh":
                    file = GetFilenameOnServer(MainClass.HA_PATH);
                    MainClass.dwdURL = MainClass.HA_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                case "NRW": // Schleswig-Holstein und Hamburg
                case "nrw":
                    file = GetFilenameOnServer(MainClass.EM_PATH);
                    MainClass.dwdURL = MainClass.EM_PATH + file;
                    TextOutput.Show(ReadText.GetWebsiteContent(MainClass.dwdURL));
                    noerrors = true;
                    file = string.Empty;
                    break;

                default:

                    noerrors = false;
                    break;
            }*/

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

