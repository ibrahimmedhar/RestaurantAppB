using Newtonsoft.Json;
using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace RestaurantApp.Pages
{
    public static class MenuPage
    {
        //public static void ShowMenu()
        public static void ShowMenu(bool withKeuze = true)
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var menu = JsonConvert.DeserializeObject<List<Gerecht>>(lijst["menu"].ToString());
            Console.WriteLine("Menu");
            Console.WriteLine("\n---------- Appetizers ----------");
            for (int i = 0; i < menu.Count; i++)
            {

                if (menu[i].gang == "Appetizers")
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(menu[i].GerechtNummer + ". " + menu[i].Naam + " -- " + menu[i].Prijs + "\n" + menu[i].Ingredienten);

                }
            }

            Console.WriteLine("\n---------- Chicken ----------");
            for (int j = 0; j < menu.Count; j++)
                {
                
                    //Console.WriteLine(" ");
                    if (menu[j].gang == "Chicken")
                        {
                        Console.WriteLine(" ");
                        Console.WriteLine(menu[j].GerechtNummer + ". " + menu[j].Naam + " -- " + menu[j].Prijs + "\n" + menu[j].Ingredienten);
                        }
                }

            Console.WriteLine("\n---------- Fish ----------");
            for (int k = 0; k < menu.Count; k++)
                {
                    //Console.WriteLine(" ");
                    if (menu[k].gang == "Fish")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(menu[k].GerechtNummer + ". " + menu[k].Naam + " -- " + menu[k].Prijs + "\n" + menu[k].Ingredienten);
                    }
                }

            //Console.WriteLine(" ");

            Console.WriteLine("\n---------- Vegan ----------");
            for (int z = 0; z < menu.Count; z++)
                {

                    //Console.WriteLine(" ");
                    if (menu[z].gang == "Vegan")
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine(menu[z].GerechtNummer + ". " + menu[z].Naam + " -- " + menu[z].Prijs + "\n" + menu[z].Ingredienten);
                    }
                }               

            if (withKeuze)
            {
                OpgevenKeuze(menu);
            }


            
            Console.WriteLine(" ");
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            if (WelcomePage.gebruiker.adminRechten)
            {
                AdminWelcomePage.Run();
            }
            else
            {
                KlantWelcomePage.Run();
            }
            
        }


        private static void OpgevenKeuze(List<Gerecht> menu)
        {
           
            Console.WriteLine("\nGeef de gerechten nummers door die je wilt bestellen(voorbeeld:12 1 3):");
            string input = Console.ReadLine();

            var gekozenGerechten = input.Trim().Split(" ").Select(Int32.Parse).ToList();


            Console.Clear();


            double totaalPrijs = 0;

            for (int m = 0; m < menu.Count; m++)
            {
                if (gekozenGerechten.Contains(menu[m].GerechtNummer))
                {
                    Console.WriteLine(menu[m].Naam + " " + menu[m].Prijs);
                    totaalPrijs = totaalPrijs + menu[m].Prijs;
                }
            }
            Console.WriteLine("Totaal Prijs : " + totaalPrijs);
        }

    }

}