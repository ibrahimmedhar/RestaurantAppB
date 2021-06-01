using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using Newtonsoft.Json;
using System.IO;

namespace RestaurantApp.Pages
{
    class PromotiePage
    {
        public static void PromotieAanmaken()
        {
            Console.Clear();
            Promoties Guest = new Promoties
            {
                promotietitel = Beheer.Input("Wat is de titel van de promotie?: "),
                gerecht = Beheer.Input("Om welk(e) gerecht(en) gaat de promotie?: "),
                vandatum = Beheer.Input("Wanneer begint de promotie?: "),
                totdatum = Beheer.Input("Tot hoelang geld de promotie?: "),
                beginprijs = Beheer.Input("Wat was de originele prijs?: "),
                eindprijs = Beheer.Input("Wat is de promotieprijs?: "),
                korting = Beheer.Input("Wat is het verschil tussen de beginprijs en de eindprijs?: ")
            };
            Console.WriteLine("Promotie succesvol aangemaakt.");
            DataStorageHandler.Storage.promotions.Add(Guest);
            Console.ReadKey(true);
            WelcomePage.Run();
        }

        public static void ShowPromotie()
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json")); 
            var promo = JsonConvert.DeserializeObject<List<Promoties>>(lijst["promotions"].ToString());
            Console.WriteLine("We hebben " + promo.Count + " promotie(s)");
            Console.WriteLine(" ");
            for (int i = 0; i < promo.Count; i++)
            {
                Console.WriteLine(promo[i].promotietitel);
                Console.WriteLine("Deze promotie valt op: " + promo[i].gerecht);
                Console.WriteLine("Deze promotie geld van " + promo[i].vandatum + " tot " + promo[i].totdatum + ".");
                Console.WriteLine("De oude prijs is: " + promo[i].beginprijs + " Euro, de nieuwe prijs is: " + promo[i].eindprijs + " Euro.");
                Console.WriteLine("Dit is een korting van " + promo[i].korting + " Euro.");
                Console.WriteLine(" ");
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
