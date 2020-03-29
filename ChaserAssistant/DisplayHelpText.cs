using System;
namespace ChaserAssistant
{
    public static class DisplayHelpText
    {
        public static void Output()
        {
            Console.Clear();
            Console.WriteLine("\n===================================");
            Console.WriteLine("=== ChaserAssistant Version 0.1 ===");
            Console.WriteLine("===================================");

            Console.WriteLine("\nArguments:");
            Console.WriteLine("--wl <Region> : Warnlagebericht Region des DWD");
            Console.WriteLine("\tRegionen:");
            Console.WriteLine("\t\tBW: Baden-Württemberg");
            Console.WriteLine("\t\tBY: Bayern");
            Console.WriteLine("\t\tSR: Saarland / Rheinland-Pfalz");
            Console.WriteLine("\t\tRP: Rheinland-Pfalz / Saarland");
            Console.WriteLine("\t\tBB: Berlin + Brandenburg");
            Console.WriteLine("\t\tMV: Mecklenburg-Vorpommern");
            Console.WriteLine("\tNRW: Nordrhein-Westfalen");
            Console.WriteLine("\t\tSX: Sachsen");
            Console.WriteLine("\t\tSA: Sachsen-Anhalt");
            Console.WriteLine("\t\tTH: Thüringen");

            Console.WriteLine("\n--wv <Region> : Wochenvorhersage");
            Console.WriteLine("\tRegionen:");
            Console.WriteLine("\t\tDE: Deutschland");

            Console.WriteLine("\n--checkdir <URL> : Webverzeichnis auslesen");
            Console.WriteLine();
        }
    }
}
