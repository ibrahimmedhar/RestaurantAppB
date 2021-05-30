using System;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace RestaurantApp.Pages
{
    class ReservatiePage
    {
        public static void ReservatieAanmaken()
        {
            Console.Clear();
            RandomGenerator generator = new RandomGenerator();

            string voornaam = Beheer.Input("Voer uw voornaam in: ");
            string achternaam = Beheer.Input("Voer uw achternaam in: ");

            Console.WriteLine("1. 10:00-12:00 \n2. 12:00-14:00 \n3. 14:00-16:00 \n4. 16:00-18:00 \n5. 18:00-20:00");

            int tijdslot = Int32.Parse(Beheer.Input("Tijdslot: "));
            int aantalMensen = Int32.Parse(Beheer.Input("Aantal mensen: "));

            GenerateGrid();
            int tafel = Int32.Parse(Beheer.Input("tafel: "));

            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].tijdslot == tijdslot && Reserve[i].tafel == tafel)
                {
                    Console.WriteLine("Deze tafel is bezet, probeer een andere tafel.");
                    Console.ReadKey(true);
                    KlantWelcomePage.Run();
                }
            }

            Reservaties reservatie = new Reservaties
            {
                voornaam = voornaam,
                achternaam = achternaam,
                tijdslot = tijdslot,
                aantalMensen = aantalMensen,
                tafel = tafel,
                reservatieId = generator.RandomString(10)
            };
            Console.WriteLine("Uw reservatie is gemaakt.");
            DataStorageHandler.Storage.reservaties.Add(reservatie);
            Console.ReadKey(true);
            WelcomePage.Run();
        }

        public static void ShowReservatie()
            {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            Console.WriteLine("Er zijn " + Reserve.Count + " reservatie(s)");
            Console.WriteLine(" ");

            for (int i = 0; i < Reserve.Count; i++)
            {
                Console.WriteLine("Voornaam: " + Reserve[i].voornaam);
                Console.WriteLine("Achternaam: " + Reserve[i].achternaam);
                Console.WriteLine("Tijdslot: " + Reserve[i].tijdslot);
                Console.WriteLine("Aantal mensen: " + Reserve[i].aantalMensen);
                Console.WriteLine("Tafel: " + Reserve[i].tafel);
                Console.WriteLine("ReservatieID: " + Reserve[i].reservatieId);
                Console.WriteLine(" ");
                
            }
            Console.ReadKey(true);
            AdminWelcomePage.Run();

        }

        public static void GenerateGrid()
        {
            int[] Restaurantgrid = new int[] {
                1 , 0 , 0 , 4 , 0 , 0 , 0 , 12, 13, 14, 15, 15, 12, 13, 14, 0 , 0 , 0 , 1 , 3 , 
                11, 0 , 0 , 11, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 11, 11,  
                0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
                2 , 0 , 0 , 5 , 0 , 0 , 7 , 0 , 0 , 9 , 11, 11, 0 , 0 , 1 , 1 , 0 , 0 , 1 , 4 , 
                11, 0 , 0 , 11, 0 , 0 , 11, 0 , 0 , 11, 11, 11, 0 , 0 , 11, 11, 0 , 0 , 11, 11, 
                0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 
                3 , 0 , 0 , 6 , 0 , 0 , 8 , 0 , 0 , 1 , 10, 11, 0 , 0 , 1 , 2 , 0 , 0 , 1 , 5 , 
                11, 0 , 0 , 11, 0 , 0 , 11, 0 , 0 , 11, 11, 11, 0 , 0 , 11, 11, 0 , 0 , 11, 11, };

            int Rows = 8;
            int Columns = 20;

            string Restaurant = "";
            int k = 0;

            for (int i = 0; i < Rows; i++)
            {

                for (int j = 0; j < Columns; j++)
                {

                    if (k >= Restaurantgrid.Length)
                    {
                        Restaurant += " ";
                    }
                    else
                    {
                        if (Restaurantgrid[k] == 0)
                        {
                            Restaurant += " ";
                        }
                        else if (Restaurantgrid[k] == 1)
                        {
                            Restaurant += "1";
                        }
                        else if (Restaurantgrid[k] == 2)
                        {
                            Restaurant += "2";
                        }
                        else if (Restaurantgrid[k] == 3)
                        {
                            Restaurant += "3";
                        }
                        else if (Restaurantgrid[k] == 4)
                        {
                            Restaurant += "4";
                        }
                        else if (Restaurantgrid[k] == 5)
                        {
                            Restaurant += "5";
                        }
                        else if (Restaurantgrid[k] == 6)
                        {
                            Restaurant += "6";
                        }
                        else if (Restaurantgrid[k] == 7)
                        {
                            Restaurant += "7";
                        }
                        else if (Restaurantgrid[k] == 8)
                        {
                            Restaurant += "8";
                        }
                        else if (Restaurantgrid[k] == 9)
                        {
                            Restaurant += "9";
                        }
                        else if (Restaurantgrid[k] == 10)
                        {
                            Restaurant += "0";
                        }
                        else if (Restaurantgrid[k] == 11)
                        {
                            Restaurant += "X";
                        }
                        else if (Restaurantgrid[k] == 12)
                        {
                            Restaurant += "B";
                        }
                        else if (Restaurantgrid[k] == 13)
                        {
                            Restaurant += "A";
                        }
                        else if (Restaurantgrid[k] == 14)
                        {
                            Restaurant += "R";
                        }
                        else if (Restaurantgrid[k] == 15)
                        {
                            Restaurant += "-";
                        }
                    }
                    k++;
                }
                Restaurant += "\n";
            }
            Console.WriteLine(Restaurant);
        }
    }

    
    public class RandomGenerator
    {
        private readonly Random _random = new Random();  
        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}