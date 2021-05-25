using System;
using System.Text;
using RestaurantApp.Classes;
using RestaurantApp.DAL;

namespace RestaurantApp.Pages
{
    class ReservatiePage
    {
        public static void ReservatieAanmaken()
        {
            Console.Clear();
            RandomGenerator generator = new RandomGenerator();
            
            Reservaties reservatie = new Reservaties
            {
                voornaam = Beheer.Input("Voer uw voornaam in: "),
                achternaam = Beheer.Input("Voer uw achternaam in: "),
                aantalMensen = Int32.Parse(Beheer.Input("Aantal mensen: ")),
                reservatieId = generator.RandomString(10)
            };
            Console.WriteLine("Uw reservatie is gemaakt.");
            DataStorageHandler.Storage.reservaties.Add(reservatie);
            Console.ReadKey(true);
            WelcomePage.Run();
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