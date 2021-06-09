using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Classes
{
   public  class Gerecht
    {
        public string gang { get; set; }
        public string Naam { get; set; }
        public int GerechtNummer { get; set; }
        public int Prijs { get; set; }
        public string Ingredienten { get; set; }
    }
}
