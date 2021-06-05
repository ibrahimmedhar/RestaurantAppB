using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.DAL;

namespace RestaurantApp.Pages
{
    class GastWelcomePage
    {
        public static void Run()
        {
            DataStorageHandler.SaveChanges();
            Console.Clear();
            string prompt = "Welkom bij ons Restaurant!";
            string[] options = { "Reservering maken", "Reservering opzoeken", "Reservering verwijderen" };
            ConsoleMenu StartPagina = new ConsoleMenu(prompt, options);
            StartPagina.DisplayOptions();
            int selectedIndex = StartPagina.Run();
            var selectedoption = options[selectedIndex];

            switch (selectedoption)
            {
                case "Reservering maken":
                    ReservatiePage.ReservatieAanmaken();
                    break;
                case "Reservering opzoeken":
                    ReservatiePage.LookupReservatie();
                    break;
                case "Reservering verwijderen":
                    ReservatiePage.DeleteReservatie();
                    break;

            }
        }
    }
}
