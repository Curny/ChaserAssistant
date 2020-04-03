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

namespace ChaserAssistant
{
    class MainClass
    {    

        public const string DE_PATH = "https://opendata.dwd.de/weather/alerts/txt/GER/";
        public const string BW_PATH = "https://opendata.dwd.de/weather/alerts/txt/SU/";
        public const string BY_PATH = "https://opendata.dwd.de/weather/alerts/txt/MS/";
        public const string OF_PATH = "https://opendata.dwd.de/weather/alerts/txt/OF/";
        public const string PD_PATH = "https://opendata.dwd.de/weather/alerts/txt/PD/";
        public const string LZ_PATH = "https://opendata.dwd.de/weather/alerts/txt/LZ/";
        public const string HA_PATH = "https://opendata.dwd.de/weather/alerts/txt/HA/";
        public const string EM_PATH = "https://opendata.dwd.de/weather/alerts/txt/EM/";

        public static string dwdURL = string.Empty;
        public static string toDo = string.Empty;


        public static void Main(string[] args)
        {
            string warnlageLand = string.Empty;
            string restURL = string.Empty;

            /*
            int datepart_d = DateTime.Now.Day;
            int datepart_h = DateTime.Now.Hour;
            int datepart_m = DateTime.Now.Minute;
            */           


            // check for arguments in the command line
            if (args.Length == 0)
            {
                DisplayHelpText.Output();
                Environment.Exit(0);
            }
            else if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    if (!args[0].Contains("--") || string.IsNullOrEmpty(args[0]))
                    {
                        Console.WriteLine("Invalid argument.");
                        Environment.Exit(1);
                    }

                    toDo = args[i];

                    switch (args[i])
                    {
                        case "--debug":
                            Console.Clear();
                            Console.WriteLine("***** Debug output:");
                            for (int j = 0; j < args.Length; j++)
                            {
                                Console.WriteLine("args " + j + ": " + args[j]);
                            }
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        case "--help":
                        case "--h":
                            DisplayHelpText.Output();
                            break;

                        case "--wl":
                            try
                            {                            
                                if (ReactOnArgs.Do(args[i], args[i + 1]) == 1)
                                {
                                    Console.WriteLine("***** FEHLER: unbekannte Region");
                                    Environment.Exit(1);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("***** FEHLER: keine Region angegeben");
                                Environment.Exit(1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\n***** FEHLER ReactOnArgs:\n" + ex.Message.ToString());
                            }

                            break;


                        case "--wv":
                            try
                            {
                                if (ReactOnArgs.Do(args[i], args[i + 1]) == 1)
                                {
                                    Console.WriteLine("***** FEHLER: unbekannte Region");
                                    Environment.Exit(1);
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("***** FEHLER: keine Region angegeben");
                                Environment.Exit(1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("\n***** FEHLER:\n" + ex.Message.ToString());
                            }


                            break;

                        case "--checkdir":
                            try
                            {
                                CheckFTPDir.ReadDirectoryContent(args[i+1]);
                                Environment.Exit(0);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("--checkdir ERROR: \n" + ex.Message);
                                Environment.Exit(1);
                            }
                            break;

                        case "--warn":
                            try
                            {
                                if (ReactOnArgs.Do(args[i], args[i + 1]) == 1)
                                {
                                    Console.WriteLine("***** FEHLER: unbekannte Region");
                                    Environment.Exit(1);
                                }

                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("*** FEHLER: kein Landkreis angegeben");
                                Environment.Exit(1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Environment.Exit(1);
                            }
                            
                            break;
                        case "--see":
                            try
                            {
                                if (ReactOnArgs.Do(args[i], args[i + 1]) == 1)
                                {
                                    Console.WriteLine("***** FEHLER: unbekannte Region");
                                    Environment.Exit(1);
                                }

                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("*** FEHLER: kein Landkreis angegeben");
                                Environment.Exit(1);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                Environment.Exit(1);
                            }

                            break;
                        default:
                            break;
                    }
                }


            }



            //Console.WriteLine(args.Length.ToString());
            //Console.WriteLine(restURL);
            //ReadText.GetWebsiteContent(dwdURL+restURL);

        }
    }
}
