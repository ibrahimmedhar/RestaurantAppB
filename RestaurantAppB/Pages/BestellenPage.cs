using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using RestaurantApp.Classes;

namespace RestaurantApp.Pages
{
    class BestellenPage
    {
        public static void Bestellen()
        {
            Console.Clear();
            Gang[] menu = JsonConvert.DeserializeObject<Gang[]>(File.ReadAllText(@"Menu.json"));
            Console.WriteLine("Geef de gerechten nummers door die je wilt bestellen:");
            string input = Console.ReadLine();

            var gekozenGerechten = input.Split(" ").Select(Int32.Parse).ToList();


            for (int m = 0; m < menu.Length; m++)
            {
                for (int g = 0; g < menu[m].Gerechten.Length; g++)
                {
                    if (gekozenGerechten.Contains(menu[m].Gerechten[g].GerechtNummer))
                    {
                        Console.WriteLine(menu[m].Gerechten[g].Naam);
                    }

                }
            }
            Console.ReadKey(true);
            WelcomePage.Run();
        }

    }
}
