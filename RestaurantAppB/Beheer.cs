using System;
using System.Collections.Generic;
using System.Text;
using RestaurantApp.Pages;

namespace RestaurantApp
{
    class Beheer
    {
        public static string Input(string vraag = null)
        {
            if (vraag != null)
            {
                Console.Write(vraag);
            }
            return Console.ReadLine();
        }
    }
}
