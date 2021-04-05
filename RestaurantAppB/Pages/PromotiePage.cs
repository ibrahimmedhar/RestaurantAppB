using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;

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
    }
}
