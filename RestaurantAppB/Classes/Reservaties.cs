using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Classes
{
    public class Reservaties
    {
        public string gebruikersnaam { get; set; }
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public string telefoonnummer { get; set; }
        public string emailadres { get; set; }

        public string datum { get; set; }
        public int tijdslot { get; set; }
        public int aantalMensen { get; set; }
        public int tafel { get; set; }

        public string reservatieId { get; set; }
    }
}
