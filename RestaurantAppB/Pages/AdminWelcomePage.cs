using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;
using RestaurantApp.Classes;

namespace RestaurantApp.Pages
{
    class AdminWelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = { "Promoties inzien", "Promoties aanmaken", "Menukaart", "Recensies bekijken", "Reserveren", "Reserveringen inzien"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Promoties inzien")
            {
                PromotiePage.ShowPromotie();
            }

            if (options[selectedIndex] == "Promoties aanmaken")
            {
                PromotiePage.PromotieAanmaken();
            }

            if (options[selectedIndex] == "Menukaart")
            {
                MenuPage.ShowMenu();
            }

            if (options[selectedIndex] == "Reserveren")
            {
                ReservatiePage.ReservatieAanmaken();
            }
        }
    }
}
