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
        public static void RecensiePlaatsen()
        {
            Console.Clear();
            var list = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"ProjectB.json"));
            var recencies = JsonConvert.DeserializeObject<List<Recensies>>(list["reviews"].ToString());

            for (int i = 0; i < recencies.Count; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(recencies[i]);
            }


                Recensies Recensie = new Recensies
            {
                Cijfer = Beheer.Input("Welke cijfer geeft u het restaurant?"),
                Recensie = Beheer.Input("typ hier uw recensie: "),

            };
            Console.WriteLine("Recensie succesvol geplaatst.");
            DataStorageHandler.Storage.reviews.Add(Recensie);
            Console.ReadKey(true);
            WelcomePage.Run();
        }
    }
}
