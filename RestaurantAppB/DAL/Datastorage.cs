using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Classes;

namespace RestaurantApp.DAL
{
    public class DataStorage
    {
        public List<Promoties> promotions { get; set; } = new List<Promoties>();
        public List<Gebruikers> users { get; set; } = new List<Gebruikers>();
        public List<Reservaties> reservaties { get; set; } = new List<Reservaties>();
        public List<Gang> menu { get; set; } = new List<Gang>();

        public List<Gang> aanpassenmenu { get; set; } = new List<Gang>();
    }

}
