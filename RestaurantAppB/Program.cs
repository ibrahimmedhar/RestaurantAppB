using RestaurantApp.DAL;
using RestaurantApp.Pages;
using System;

namespace RestaurantApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataStorageHandler.Init("ProjectB.json");
            WelcomePage.Run();
        }
    }
}
