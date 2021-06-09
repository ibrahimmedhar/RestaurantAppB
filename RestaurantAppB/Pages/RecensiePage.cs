using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using RestaurantApp;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using RestaurantApp.Pages;

namespace RestaurantApp.Pages
{
    class RecensiePage
    {
        public static void RecensiesZien()
        {
            Console.Clear();
            var list = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var recencies = JsonConvert.DeserializeObject<List<Recensies>>(list["reviews"].ToString());

            for (int i = 0; i < recencies.Count; i++)
            {
                Console.WriteLine("Naam: " + recencies[i].Naam);
                Console.WriteLine("Cijfer: " + recencies[i].Cijfer);
                Console.WriteLine(recencies[i].Recensie);
                Console.WriteLine("\n");
            }
            Console.WriteLine("Druk op een knop om verder te gaan.");
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

        public static void RecensiePlaatsen()
        {
            Console.Clear();

            Recensies Recensie = new Recensies
            {
                Naam = WelcomePage.gebruiker.gebruikersnaam,
                Cijfer = Beheer.Input("Welke cijfer geeft u het restaurant(Cijfer uit de 10)? \n"),
                Recensie = Beheer.Input("Typ hier uw recensie: \n "),

            };
            Console.WriteLine("Recensie succesvol geplaatst.");
            DataStorageHandler.Storage.reviews.Add(Recensie);
            Console.WriteLine("Druk op een knop om verder te gaan.");
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
