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
            string[] options = { "Promotie aanmaken", "Promoties inzien", "Reservatie aanmaken", "Reserveringen inzien", "Menukaart", "Recensies bekijken" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Promoties inzien")
            {
                PromotiePage.ShowPromotie();
            }

            if (options[selectedIndex] == "Promotie aanmaken")
            {
                PromotiePage.PromotieAanmaken();
            }

            if (options[selectedIndex] == "Menukaart")
            {
                MenuPage.ShowMenu();
            }

            if (options[selectedIndex] == "Reservatie aanmaken")
            {
                ReservatiePage.ReservatieAanmaken();
            }

            if (options[selectedIndex] == "Reserveringen inzien")
            {
                ReservatiePage.ShowReservatie();
            }
        }
    }
}
