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
            string[] options = { "Promoties inzien", "Promotie aanmaken", "Menukaart", "recensie(s) inzien/plaatsen", "Reserveren", "Reserveringen inzien"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            var selectedoption = options[selectedIndex];

            switch (selectedoption)
            {
                case "Promoties inzien":
                    PromotiePage.ShowPromotie();
                    break;
                case "recensies inzien":
                    RecensiePage.RecensiesZien();
                    break;
                case "recensies plaatsen":
                    RecensiePage.RecensiePlaatsen();
                    break;
                case "Promotie aanmaken":
                    PromotiePage.PromotieAanmaken();
                    break;
                case "Menukaart":
                    MenuPage.ShowMenu();
                    break;
                case "Reserveren":
                    ReservatiePage.ReservatieAanmaken();
                    break;


            }

            //if (selectedoption == "Promoties inzien")
            //{
            //    PromotiePage.ShowPromotie();
            //}

            //if (selectedoption == "recensie(s) inzien/plaatsen")
            //{
            //    RecensiePage.RecensiesZienPlaatsen();
            //}

            //if (selectedoption == "Promoties aanmaken")
            //{
            //    PromotiePage.PromotieAanmaken();
            //}

            //if (selectedoption == "Menukaart")
            //{
            //    MenuPage.ShowMenu();
            //}

            //if (options[selectedIndex] == "Reservatie aanmaken")
            //{
            //    ReservatiePage.ReservatieAanmaken();
            //}

            //if (options[selectedIndex] == "Reserveringen inzien")
            //{
            //    ReservatiePage.ShowReservatie();
            //}
            //if (selectedoption == "Reserveren")
            //{
            //    ReservatiePage.ReservatieAanmaken();
            //}
        }
    }
}
