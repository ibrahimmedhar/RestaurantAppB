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
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var menu = JsonConvert.DeserializeObject<List<Gerecht>>(lijst["menu"].ToString());
            Console.WriteLine("Menu");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(menu[i].GerechtNummer + ". " + menu[i].Naam + " -- " + menu[i].Prijs + "\n" + menu[i].Ingredienten);
                Console.WriteLine(" ");
            }


            Console.WriteLine(" ");
            Console.WriteLine("Geef de gerecht nummer door die je wilt Aanpassen:");
            string gerechtnummer = Console.ReadLine();

            var gekozenGerecht = int.Parse(gerechtnummer.Trim());

            Console.Clear();
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine(" ");
                //menu[i].Gerechten[j].GerechtNummer = 5; // voorbeeld aanpassing gerehctnummer 
                Console.WriteLine(menu[i].GerechtNummer + ". " + menu[i].Naam + " -- " + menu[i].Prijs + "\n" + menu[i].Ingredienten);
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
