using Newtonsoft.Json;
using RestaurantApp;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using RestaurantApp.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RestaurantAppB.Pages
{
    public class InlogPage
    {
        public static void Run()
        {
            Console.Clear();
            var list = JsonConvert.DeserializeObject<Dictionary<string,object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var users = JsonConvert.DeserializeObject<List<Gebruikers>>(list["users"].ToString()); 

            Gebruikers user = new Gebruikers
            {

                gebruikersnaam = Beheer.Input("Voer uw gebruikersnaam in: "),
                wachtwoord = Beheer.Input("Voer uw wachtwoord in: "),
                adminRechten = false
            };
 
            for (int i = 0; i < users.Count; i++)
            {
                var currentUser = users[i];
                if (user.gebruikersnaam.Equals(currentUser.gebruikersnaam) && user.wachtwoord.Equals(currentUser.wachtwoord))
                {
                    if (currentUser.adminRechten) 
                    {
                        AdminWelcomePage.Run();
                    }

                    else
                    {
                        KlantWelcomePage.Run();
                    }
                }

                
            }
            Console.Clear();
            Console.WriteLine("Inloggevens zijn onjuist!");
            Console.WriteLine("Probeer het opnieuw of maak een nieuw account aan.");
            Console.ReadKey(true);
            WelcomePage.Run();
        }
    }
}
