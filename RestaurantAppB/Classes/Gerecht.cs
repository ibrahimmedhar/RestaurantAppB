using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantApp.Classes
{
   public  class Gerecht
    {
        public string Naam { get; set; }
        public int GerechtNummer { get; set; }
        public double Prijs { get; set; }
        public string[] Ingredienten { get; set; }
    }
}
