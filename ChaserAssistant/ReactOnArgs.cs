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
    public static class ReactOnArgs
    {
        public static string WL_Region { get; set; }

        public static int Do(string argument, string parameter)
        {
            bool noerrors = false;

            switch (argument)
            {
                case "--wl":
                    WL_Region = parameter;
                    //if (Warnlagebericht.Bundesland(parameter,0))
                    if(Warnlagebericht2.Region(parameter))
                    {
                        noerrors = true;
                    }
                    else
                    {
                        noerrors = false;
                    }

                    break;

                case "--wv":
                    WL_Region = parameter;
                    if (Wochenvorhersage.Region(parameter))
                    {
                        noerrors = true;
                    }
                    else
                    {
                        noerrors = false;
                    }

                    break;

                case "--warn":
                    Console.WriteLine("Not implemented yet, still in dev");
                    break;

                default:
                    Console.WriteLine("Invalid argument!");
                    noerrors = false;
                    break;
            }

            if (noerrors)
            {
                return 0;
            }
            else
            {
                return 1;
            }


        }


    }
}
