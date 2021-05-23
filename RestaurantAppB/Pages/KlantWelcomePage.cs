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
            string[] options = { "Promoties inzien", "Aanpassen menu", "Overzicht menu", "recensie(s) inzien/plaatsen", "Reserveren", "Mijn reservering", "Bestellen" };
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
        }

    }
}
