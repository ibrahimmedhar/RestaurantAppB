using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;

namespace RestaurantApp.Pages
{
    class GebruikersPage
    {
        public static void GebruikerAanmaken()
        {
            Console.Clear();
            Gebruikers User = new Gebruikers
            {
                gebruikersnaam = Beheer.Input("Voer uw gewenste gebruikersnaam in: "),
                wachtwoord = Beheer.Input("Voer uw gewenste wachtwoord in: "),
                adminRechten = false
            };
            Console.WriteLine("Gebruiker succesvol aangemaakt.") ;
            DataStorageHandler.Storage.users.Add(User);
            Console.ReadKey(true);
            WelcomePage.Run();
        }
    }
}
