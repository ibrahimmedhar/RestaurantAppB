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
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var menu = JsonConvert.DeserializeObject<List<Gerecht>>(lijst["menu"].ToString());
            Console.WriteLine("Geef de gerechten nummers door die je wilt bestellen:");
            string input = Console.ReadLine();

            var gekozenGerechten = input.Split(" ").Select(Int32.Parse).ToList();


            for (int m = 0; m < menu.Count; m++)
            {
                if (gekozenGerechten.Contains(menu[m].GerechtNummer))
                {
                    Console.WriteLine(menu[m].Naam);
                }
            }
            Console.ReadKey(true);
            if (WelcomePage.gebruiker.adminRechten)
            {
                AdminWelcomePage.Run();
            }
            else
            {
                KlantWelcomePage.Run();
            }
        }

    }
}
