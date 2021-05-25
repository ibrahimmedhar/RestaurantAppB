using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;
using RestaurantApp.Classes;

namespace RestaurantApp.Pages
{
    class KlantWelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = { "Promoties inzien", "Overzicht menu", "Bestellen", "Recensie(s) inzien of plaatsen" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            /*if (options[selectedIndex] == "Promoties inzien")
            {
                PromotiePage.ShowPromotie();
            }
            */
            if (options[selectedIndex] == "Overzicht menu")
            {
                MenuPage.ShowMenu();
            }

            if (options[selectedIndex] == "Bestellen")
            {
                BestellenPage.Bestellen();
            }

            if (options[selectedIndex] == "Recensie(s) inzien of plaatsen")
            {
                RecensiePage.RecensiePlaatsen();
            }
        }

    }
}
