/*  ChaserAssistand - a tool to fetch stormchasing information 

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
