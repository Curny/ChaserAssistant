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
