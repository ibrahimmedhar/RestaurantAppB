using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;
using RestaurantApp.Classes;

namespace RestaurantApp.Pages
{
    class WelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = { "Promoties", "Gebruiker aanmaken" , "Overzicht menu"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Promoties")
            {
                PromotiePage.PromotieAanmaken();
            }

            if (options[selectedIndex] == "Gebruiker aanmaken")
            {
                GebruikersPage.GebruikerAanmaken();
            }

            if (options[selectedIndex] == "Overzicht menu")
            {
                MenuPage.Main();
            }
        }
    }
}
