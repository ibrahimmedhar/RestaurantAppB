using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Classes
{
    public class Gebruikers
    {
        public string gebruikersnaam { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string telefoonnummer { get; set; }
        public string emailadres {get; set;}
        public string wachtwoord { get; set; }
        public bool adminRechten { get; set; }
    }
}
