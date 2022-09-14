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
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace ChaserAssistantDotNet6
{
    public static class CheckFTPDir
    {
        public static void ReadDirectoryContent(string url)
        {
            using (HttpClient client = new())
            {
                

                try
                {


                    //string ret = client.DownloadString(url);
                    //Console.WriteLine(ret);

                    // Sonderzeichen ausmerzen
                    var data = client.GetAsync(url).ToString();

                    if (data != null)
                    {
                        var encoded = System.Text.Encoding.UTF8.GetBytes(data).ToString();

                        string noHTML = Regex.Replace(encoded, @"<[^>]+>|&nbsp;", "").Trim();
                        string noHTMLNormalised = Regex.Replace(noHTML, @"\s{2,}", " ");

                        Console.WriteLine(noHTML);
                    }
                    


                }
                catch (WebException we)
                {
                    // WebException.Status holds useful information 
                    Console.WriteLine("WebException: " + we.Message + "\n" + we.Status.ToString() + "\nURL: " + MainClass.dwdURL);
                }
                catch (NotSupportedException ne)
                {
                    // other errors 
                    Console.WriteLine("NotSupportedException: " + ne.Message);
                }
            }
        }
    }
}
