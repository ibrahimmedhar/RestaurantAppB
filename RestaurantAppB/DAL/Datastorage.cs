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
        public List<Recensies> reviews { get; set; } = new List<Recensies>();
        public List<Reservaties> reservaties { get; set; } = new List<Reservaties>();

    }

}
