﻿using System;
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
            string[] options = { "Klant inloggen", "Admin inloggen", "Account aanmaken"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();

            if (options[selectedIndex] == "Klant inloggen")
            {
                KlantWelcomePage.Run();
            }

            if (options[selectedIndex] == "Admin inloggen")
            {
                AdminWelcomePage.Run();
            }

            if (options[selectedIndex] == "Account aanmaken")
            {
                GebruikersPage.GebruikerAanmaken();
            }

        }
    }
}
