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
            string[] options = { "Reserveren", "Promoties bekijken", "Menukaart",  "recensies inzien", "recensie plaatsen", "Mijn reservering", "Bestellen" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            var selectedoption = options[selectedIndex];

            switch (selectedoption)
            {
                case "Promoties bekijken":
                    PromotiePage.ShowPromotie();
                    break;
                case "recensies inzien":
                    RecensiePage.RecensiesZien();
                    break;
                case "recensie plaatsen":
                    RecensiePage.RecensiePlaatsen();
                    break;
                case "Menukaart":
                    MenuPage.ShowMenu();
                    break;
                case "Reserveren":
                    ReservatiePage.ReservatieAanmaken();
                    break;


            }

            //if (options[selectedIndex] == "Promoties")
            //{
            //    PromotiePage.ShowPromotie();
            //}
            
            //if (options[selectedIndex] == "Menukaart")
            //{
            //    MenuPage.ShowMenu();
            //}

            //if (options[selectedIndex] == "Bestellen")
            //{
            //    BestellenPage.Bestellen();
            //}

            //if (options[selectedIndex] == "Reserveren")
            //{
            //    ReservatiePage.ReservatieAanmaken();
            //}

            //if (options[selectedIndex] == "Reservering aanmaken")
            //{
            //    ReservatiePage.ReservatieAanmaken();
            //}
        }

    }
}
