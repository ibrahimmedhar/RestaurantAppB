using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;
using RestaurantApp.Classes;
using RestaurantAppB.Pages;

namespace RestaurantApp.Pages
{
    class WelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = {"Inloggen", "Account aanmaken"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Inloggen")
            {
                InlogPage.Run();
            }

            if (options[selectedIndex] == "Account aanmaken")
            {
                MenuPage.ShowMenu();
                GebruikersPage.GebruikerAanmaken();
            }

        }
    }
}
