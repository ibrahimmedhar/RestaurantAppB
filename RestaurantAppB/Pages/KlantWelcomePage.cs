using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;

namespace RestaurantApp.Pages
{
    class KlantWelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = { "Reservering maken", "Mijn reserveringen", "Reservering annuleren", "Promoties bekijken", "Menukaart",  "Recensies inzien", "Recensie plaatsen"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            var selectedoption = options[selectedIndex];

            switch (selectedoption)
            {
                case "Reservering annuleren":
                    ReservatiePage.DeleteReservatie();
                    break;
                case "Promoties bekijken":
                    PromotiePage.ShowPromotie();
                    break;
                case "Recensies inzien":
                    RecensiePage.RecensiesZien();
                    break;
                case "Recensie plaatsen":
                    RecensiePage.RecensiePlaatsen();
                    break;
                case "Menukaart":
                    MenuPage.ShowMenu();
                    break;
                case "Reservering maken":
                    ReservatiePage.ReservatieAanmaken();
                    break;
                case "Mijn reserveringen":
                    ReservatiePage.MyReservatie();
                    break;
            }
        }
    }
}
