// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace ChaserAssistantDotNet6
{
    class MainClass
    {

        public static string dwdURL = string.Empty;
        public static Dictionary<string, string> RegionPathDictionary = null;
        public static string toDo = string.Empty;


        public static void Main(string[] args)
        {
            RegionPathDictionary = new Dictionary<string, string>();
            RegionPathDictionary.Add("de", "https://opendata.dwd.de/weather/alerts/txt/GER/");
            RegionPathDictionary.Add("bw", "https://opendata.dwd.de/weather/alerts/txt/SU/");
            RegionPathDictionary.Add("by", "https://opendata.dwd.de/weather/alerts/txt/MS/");
            RegionPathDictionary.Add("rps", "https://opendata.dwd.de/weather/alerts/txt/OF/");
            RegionPathDictionary.Add("he", "https://opendata.dwd.de/weather/alerts/txt/OF/");
            RegionPathDictionary.Add("bb", "https://opendata.dwd.de/weather/alerts/txt/PD/");
            RegionPathDictionary.Add("mv", "https://opendata.dwd.de/weather/alerts/txt/PD/");
            RegionPathDictionary.Add("sx", "https://opendata.dwd.de/weather/alerts/txt/LZ/");
            RegionPathDictionary.Add("xa", "https://opendata.dwd.de/weather/alerts/txt/LZ/");
            RegionPathDictionary.Add("th", "https://opendata.dwd.de/weather/alerts/txt/LZ/");
            RegionPathDictionary.Add("nb", "https://opendata.dwd.de/weather/alerts/txt/HA/");
            RegionPathDictionary.Add("sh", "https://opendata.dwd.de/weather/alerts/txt/HA/");
            RegionPathDictionary.Add("nrw", "https://opendata.dwd.de/weather/alerts/txt/EM/");

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
                                CheckFTPDir.ReadDirectoryContent(args[i + 1]);
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