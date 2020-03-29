using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ChaserAssistant
{
    public static class Warnlagebericht
    {
        public static Dictionary<int, string> timeString = new Dictionary<int, string>();
        static string restURL = string.Empty;
        static int selection;

        public static bool Bundesland(string bundesLand, int select)
        {
            bool noerrors = false;
            int datepart_d = DateTime.Now.Day;

            if (timeString.Count == 0)
            {
                timeString.Add(1, "0130");
                timeString.Add(2, "0200");
                timeString.Add(3, "0400");
                timeString.Add(4, "0630");
                timeString.Add(5, "0730");
                timeString.Add(6, "0800");
                timeString.Add(7, "0830");
                timeString.Add(8, "1030");
                timeString.Add(9, "1130");
                timeString.Add(10, "1230");
                timeString.Add(11, "1300");
                timeString.Add(12, "1430");
                timeString.Add(13, "1500");
                timeString.Add(14, "1530");
                timeString.Add(15, "1730");
                timeString.Add(16, "1800");
                timeString.Add(17, "1830");
                timeString.Add(18, "2030");
                timeString.Add(19, "2130");
            }

            if (string.IsNullOrEmpty(ReadText.remember))
            {
                ReadText.remember = bundesLand;
            }


            if (select == 0)
            {
                CheckRestString();
            }
            else
            {
                ReCheckRestString(select);
            }


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***** ChaserAssistant - aktuellster Warnlagebricht Region: " + bundesLand);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine(restURL);
            //Console.ReadKey();



            switch (bundesLand)
            {
                case "BW":
                    MainClass.dwdURL = MainClass.BW_WARNLAGEBRICHT + datepart_d.ToString() + restURL;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
                    break;
                case "BY":
                    MainClass.dwdURL = MainClass.BY_WARNLAGEBRICHT + datepart_d.ToString() + restURL;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
                    break;
                case "RP":
                    MainClass.dwdURL = MainClass.RP_WARNLAGEBRICHT + datepart_d.ToString() + restURL;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
                    break;
                case "SR":
                    MainClass.dwdURL = MainClass.SR_WARNLAGEBRICHT + datepart_d.ToString() + restURL;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
                    break;
                case "PD": // Berlin + Brandenburg
                    MainClass.dwdURL = MainClass.PD_WARNLAGEBRICHT + datepart_d.ToString() + restURL;
                    ReadText.GetWebsiteContent(MainClass.dwdURL);
                    noerrors = true;
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


        internal static void CheckRestString()
        {
            TimeSpan ts;
            ts = DateTime.Now.TimeOfDay;

            int i = timeString.Count;

                restURL = timeString[i].ToString();
                selection = i;
        }

        internal static void ReCheckRestString(int select)
        {
            foreach (var item in timeString)
            {
                if (item.Key == (selection + select))
                {
                    restURL = item.Value;
                    selection = item.Key;
                }
            }
            //Console.WriteLine("selection: " + selection + " - result: " + restURL);
            //Console.ReadKey();
           
        }
           
    }
}
