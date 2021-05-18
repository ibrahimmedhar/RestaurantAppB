using Newtonsoft.Json;
using RestaurantApp.Classes;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RestaurantApp.Pages
{
    class MenuPage
    {
        public static void ShowMenu()
        {
            Console.Clear();

            Gang[] menu = JsonConvert.DeserializeObject<Gang[]>(File.ReadAllText(@"Menu.json"));

            Console.WriteLine("Menu");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(menu[i].Naam);
                for (int j = 0; j < menu[i].Gerechten.Length; j++)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(menu[i].Gerechten[j].GerechtNummer + ". " + menu[i].Gerechten[j].Naam + " -- " + menu[i].Gerechten[j].Prijs);

                    for (int a =0; a<menu[i].Gerechten[j].Ingredienten.Length; a++)
                    {
                        Console.WriteLine("Ingredienten" + ": " + menu[i].Gerechten[j].Ingredienten[a]);
                    }
                }

            }
            Console.WriteLine(" ");
            Console.WriteLine("Geef de gerechten nummers door die je wilt bestellen:");
            string input = Console.ReadLine();

            var gekozenGerechten = input.Split(" ").Select(Int32.Parse).ToList();

            Console.Clear();

            double totaalPrijs = 0;

            for (int m = 0; m < menu.Length; m++)
            {
                for (int g = 0; g < menu[m].Gerechten.Length; g++)
                {
                    if (gekozenGerechten.Contains(menu[m].Gerechten[g].GerechtNummer))
                    {
                        Console.WriteLine(menu[m].Gerechten[g].Naam + " " + menu[m].Gerechten[g].Prijs);
                        totaalPrijs = totaalPrijs + menu[m].Gerechten[g].Prijs;
                }

            }
            }
            Console.WriteLine("Totaal Prijs : " + totaalPrijs);
       }
    }
}
