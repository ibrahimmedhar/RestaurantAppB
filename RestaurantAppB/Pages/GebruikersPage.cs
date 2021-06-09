using System;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace RestaurantApp.Pages
{
    class GebruikersPage
    {
        public static void GebruikerAanmaken()
        {
            Console.Clear();
            string username = Beheer.Input("Voer uw gewenste gebruikersnaam in: ");

            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].gebruikersnaam == username)
                {
                    Console.WriteLine("Deze gebruikersnaam is al in gebruik, probeer een andere.");
                    Console.WriteLine("Druk op een knop om verder te gaan.");
                    Console.ReadKey(true);
                    WelcomePage.Run();
                }
            }
            
            Gebruikers User = new Gebruikers
            {
                gebruikersnaam = username,
                wachtwoord = Beheer.Input("Voer uw gewenste wachtwoord in: "),
                voornaam = Beheer.Input("wat is uw voornaam? "),
                achternaam = Beheer.Input("wat is uw achternaam? "),
                emailadres = Beheer.Input("wat is uw emailadres? "),
                telefoonnummer = Beheer.Input("wat is uw telefoonnummer? "),
                adminRechten = false
            };

            Console.WriteLine("Gebruiker succesvol aangemaakt!") ;
            DataStorageHandler.Storage.users.Add(User);
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            WelcomePage.Run();
        }
    }
}
