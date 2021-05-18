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
            string[] options = { "Promoties aanmaken", "Overzicht menu" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Promoties aanmaken")
            {
                PromotiePage.PromotieAanmaken();
            }

            if (options[selectedIndex] == "Overzicht menu")
            {
                MenuPage.ShowMenu();
            }

        }
    }
}
