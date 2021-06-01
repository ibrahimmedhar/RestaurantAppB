using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Classes
{
    public class Reservaties
    {
        public string voornaam { get; set; }
        public string achternaam { get; set; }
        public int tijdslot { get; set; }
        public int aantalMensen { get; set; }
        public int tafel { get; set; }
        public string reservatieId { get; set; }
    }
}
