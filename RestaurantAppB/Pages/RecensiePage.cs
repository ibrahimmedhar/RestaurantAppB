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
        public static void RecensiesZienPlaatsen()
        {
            Console.Clear();
            var list = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var recencies = JsonConvert.DeserializeObject<List<Recensies>>(list["reviews"].ToString());

            for (int i = 0; i < recencies.Count; i++)
            {
                Console.WriteLine(" ");
                var x = recencies[i];
                Console.WriteLine(recencies[i].Naam);
                Console.WriteLine(recencies[i].Cijfer);
                Console.WriteLine(recencies[i].Recensie);
                Console.WriteLine("\n");
            }


            Recensies Recensie = new Recensies
            {
                Naam = WelcomePage.gebruiker.gebruikersnaam,
                Cijfer = Beheer.Input("Welke cijfer geeft u het restaurant? \n"),
                Recensie = Beheer.Input("typ hier uw recensie: \n "),

            };
            Console.WriteLine("Recensie succesvol geplaatst.");
            DataStorageHandler.Storage.reviews.Add(Recensie);
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
