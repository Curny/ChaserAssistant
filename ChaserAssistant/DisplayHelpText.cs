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
using System.Reflection;
using System.Diagnostics;

namespace ChaserAssistant
{
    public static class DisplayHelpText
    {
        public static void Output()
        {
            Console.Clear();
            Console.WriteLine("\n==============================================");
            Console.WriteLine("=== ChaserAssistant Version " + Assembly.GetEntryAssembly().GetName().Version + " ===");
            Console.WriteLine("==============================================");
            Console.WriteLine("\nArguments:");

            Console.WriteLine("--wl <Region> : Warnlagebericht Region des DWD");
            Console.WriteLine("\tRegionen:");
            Console.WriteLine("\t\tBB : Berlin + Brandenburg");
            Console.WriteLine("\t\tBW : Baden-Württemberg");
            Console.WriteLine("\t\tBY : Bayern");
            Console.WriteLine("\t\tHE : Hessen");
            Console.WriteLine("\t\tMV : Mecklenburg-Vorpommern");
            Console.WriteLine("\t\tNB : Niedersachsen + Bremen");
            Console.WriteLine("\t\tNRW: Nordrhein-Westfalen");
            Console.WriteLine("\t\tRPS: Rheinland-Pfalz + Saarland");
            Console.WriteLine("\t\tSX : Sachsen");
            Console.WriteLine("\t\tSA : Sachsen-Anhalt");
            Console.WriteLine("\t\tSHH: Schleswig-Holstein + Hamburg");
            Console.WriteLine("\t\tTH : Thüringen");

            Console.WriteLine("\n--wv <Region> : Wochenvorhersage");
            Console.WriteLine("\tRegionen:");
            Console.WriteLine("\t\tDE: Deutschland");

            Console.WriteLine("\n--warn <Autokennzeichen> : aktuelle Wetterwarnungen für Gebiet ausgeben");

            Console.WriteLine("\n--see <gebiet> : Seewetterwarnungen, z. B. KA für Kattegatt");
            Console.WriteLine("\tRegionen:");
            Console.WriteLine("\t\tKA: Kattegatt");
            Console.WriteLine("\t\tBO: Boddengewässe Ost");
            Console.WriteLine("\t\tFO: Forties");
            Console.WriteLine("\t\tHE: Helgoland");
            Console.WriteLine("\t\tIJ: Ijsselmeer");
            Console.WriteLine("\t\tKO: Engl. Kanal Ostteil");
            Console.WriteLine("\t\tKW: Engl. Kanal Westteil");

            Console.WriteLine("\n--checkdir <URL> : Webverzeichnis auslesen");
            Console.WriteLine();
        }
    }
}
