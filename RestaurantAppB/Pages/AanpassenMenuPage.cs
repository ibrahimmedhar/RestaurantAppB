using Newtonsoft.Json;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using RestaurantApp.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RestaurantApp.Pages
{
    class AanpassenMenuPage
    {
        public static void ShowAanpassen()
        {
            Console.Clear();
            //var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            //var menu = JsonConvert.DeserializeObject<List<Gang>>(lijst["menu"].ToString());
            //Gang[] menu = JsonConvert.DeserializeObject<Gang[]>(File.ReadAllText(@"Menu.json"));
            //Console.WriteLine("Menu");
            Gang[] menu = JsonConvert.DeserializeObject<Gang[]>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            Console.WriteLine("Menu");
            for (int i = 0; i < menu.Length; i++)
            {
                Console.WriteLine(" ");
                Console.WriteLine(menu[i].Naam);
                for (int j = 0; j < menu[i].Gerechten.Length; j++)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(menu[i].Gerechten[j].GerechtNummer + ". " + menu[i].Gerechten[j].Naam + " -- " + menu[i].Gerechten[j].Prijs);

                    for (int a = 0; a < menu[i].Gerechten[j].Ingredienten.Length; a++)
                    {
                        Console.WriteLine(menu[i].Gerechten[j].Ingredienten[a]);
                    }
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("Geef de gerecht nummer door die je wilt Aanpassen:");
            string gerechtnummer = Console.ReadLine();

            var gekozenGerecht = int.Parse(gerechtnummer.Trim());

            Console.Clear();
            for (int i = 0; i < menu.Length; i++)
            {
                for (int j = 0; j < menu[i].Gerechten.Length; j++)
                {
                    if (gekozenGerecht == menu[i].Gerechten[j].GerechtNummer)
                    {
                        Console.WriteLine(" ");
                        //menu[i].Gerechten[j].GerechtNummer = 5; // voorbeeld aanpassing gerehctnummer 
                        Console.WriteLine(menu[i].Gerechten[j].GerechtNummer + ". " + menu[i].Gerechten[j].Naam + " -- " + menu[i].Gerechten[j].Prijs);

                        for (int a = 0; a < menu[i].Gerechten[j].Ingredienten.Length; a++)
                        {
                            Console.WriteLine(menu[i].Gerechten[j].Ingredienten[a]);
                        }
                    }
                }
            }

            Console.WriteLine(" ");
            Console.WriteLine("Geef nieuwe naam door: ");
            string aanpassing = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Geef nieuwe prijs door: ");
            string aanpassingprijs = Console.ReadLine();

            Console.WriteLine(" ");
            Console.WriteLine("Geef nieuwe ingredienten door: ");
            string aanpassingingredient = Console.ReadLine();

            /*DataStorageHandler.Storage.users.f
            string json = File.ReadAllText("@Menu.json");
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
            jsonObj["Bots"][0]["Password"] = "new password";
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText("settings.json", output);*/

        }
    }
}
