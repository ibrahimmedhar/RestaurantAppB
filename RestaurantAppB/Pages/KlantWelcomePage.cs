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
            string[] options = { "Reservering aanmaken", "Promoties bekijken", "Menukaart", "Recensie(s) inzien", "Recensie plaatsen", "Mijn reservering", "Bestellen" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Promoties bekijken")
            {
                PromotiePage.ShowPromotie();
            }
            
            if (options[selectedIndex] == "Menukaart")
            {
                MenuPage.ShowMenu();
            }

            if (options[selectedIndex] == "Bestellen")
            {
                BestellenPage.Bestellen();
            }

            if (options[selectedIndex] == "Reservering aanmaken")
            {
                ReservatiePage.ReservatieAanmaken();
            }
        }

    }
}
