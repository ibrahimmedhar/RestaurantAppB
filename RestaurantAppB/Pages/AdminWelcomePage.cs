using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;

namespace RestaurantApp.Pages
{
    class AdminWelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Admin menu: ";
            string[] options = { "Reservering maken", "Reserveringen inzien", "Reservering annuleren", "Promotie maken", "Promoties inzien", "Menukaart", "Menu bijwerken", "Recensies inzien"};
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            var selectedoption = options[selectedIndex];

            switch (selectedoption)
            {
                case "Promoties inzien":
                    PromotiePage.ShowPromotie();
                    break;
                case "Recensies inzien":
                    RecensiePage.RecensiesZien();
                    break;
                case "Promotie maken":
                    PromotiePage.PromotieAanmaken();
                    break;
                case "Menukaart":
                    MenuPage.ShowMenu();
                    break;
                case "Menu bijwerken":
                    AanpassenMenuPage.ShowAanpassen();
                    break;
                case "Reservering maken":
                    ReservatiePage.ReservatieAanmaken();
                    break;
                case "Reserveringen inzien":
                    ReservatiePage.ShowReserveringen();
                    break;
                case "Reservering annuleren":
                    ReservatiePage.DeleteReservatie();
                    break;
            }
        }
    }
}
