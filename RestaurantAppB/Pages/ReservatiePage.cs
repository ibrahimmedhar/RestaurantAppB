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

            string gebruikersnaam = "Gast";
            string voornaam = "filler";
            string achternaam = "filler";
            string telefoonnummer = "filler";
            string email = "filler";

            if (WelcomePage.gebruiker == null)
            {
                voornaam = Beheer.Input("Voornaam:");
                achternaam = Beheer.Input("Achternaam:");
                telefoonnummer = Beheer.Input("Telefoonnummer:");
                email = Beheer.Input("eMail:");
            }
            else if(WelcomePage.gebruiker.adminRechten)
            {
                voornaam = Beheer.Input("Voornaam:");
                achternaam = Beheer.Input("Achternaam:");
                telefoonnummer = Beheer.Input("Telefoonnummer:");
                email = Beheer.Input("eMail:");
            }
            else
            {
                gebruikersnaam = WelcomePage.gebruiker.gebruikersnaam;
                voornaam = WelcomePage.gebruiker.voornaam;
                achternaam = WelcomePage.gebruiker.achternaam;
                telefoonnummer = WelcomePage.gebruiker.telefoonnummer;
                email = WelcomePage.gebruiker.emailadres;
            }

            Console.WriteLine("Reservatie aanmaken:");

            string datum = Beheer.Input("Kies een datum(dd-mm-jj): ");
            int datumlengte = datum.Length;
            char[] datumarray = datum.ToCharArray();

            if (datumlengte != 8 || datumarray[2] != '-' || datumarray[5] != '-')
            {
                Console.WriteLine("Dit is niet een geldige datum, probeer het opnieuw.");
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

            Console.WriteLine("1. 10:00-12:00 \n2. 12:00-14:00 \n3. 14:00-16:00 \n4. 16:00-18:00 \n5. 18:00-20:00");
            int tijdslot = Int32.Parse(Beheer.Input("Kies een tijdslot: "));

            if (tijdslot < 1 || tijdslot > 5)
            {
                Console.WriteLine("Dit is niet een geldige tijdslot, probeer het opnieuw.");
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

            int aantalMensen = Int32.Parse(Beheer.Input("Aantal mensen: "));

            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            int[] grid = new int[] {
                1 , 0 , 0 , 4 , 0 , 0 , 0 , 12, 13, 14, 15, 15, 12, 13, 14, 0 , 0 , 0 , 1 , 3 ,
                11, 0 , 0 , 11, 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 11, 11,
                0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
                2 , 0 , 0 , 5 , 0 , 0 , 7 , 0 , 0 , 9 , 11, 11, 0 , 0 , 1 , 1 , 0 , 0 , 1 , 4 ,
                11, 0 , 0 , 11, 0 , 0 , 11, 0 , 0 , 11, 11, 11, 0 , 0 , 11, 11, 0 , 0 , 11, 11,
                0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 ,
                3 , 0 , 0 , 6 , 0 , 0 , 8 , 0 , 0 , 1 , 10, 11, 0 , 0 , 1 , 2 , 0 , 0 , 1 , 5 ,
                11, 0 , 0 , 11, 0 , 0 , 11, 0 , 0 , 11, 11, 11, 0 , 0 , 11, 11, 0 , 0 , 11, 11, };

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].datum == datum && Reserve[i].tijdslot == tijdslot)
                {
                    switch (Reserve[i].tafel)
                    {
                        case 1:
                            grid[0] = 0; grid[20] = 0;
                            break;
                        case 2:
                            grid[60] = 0; grid[80] = 0;
                            break;
                        case 3:
                            grid[120] = 0; grid[140] = 0;
                            break;
                        case 4:
                            grid[3] = 0; grid[23] = 0;
                            break;
                        case 5:
                            grid[63] = 0; grid[83] = 0;
                            break;
                        case 6:
                            grid[123] = 0; grid[143] = 0;
                            break;
                        case 7:
                            grid[66] = 0; grid[86] = 0;
                            break;
                        case 8:
                            grid[126] = 0; grid[146] = 0;
                            break;
                        case 9:
                            grid[69] = 0; grid[70] = 0; grid[71] = 0; grid[89] = 0; grid[90] = 0; grid[91] = 0;
                            break;
                        case 10:
                            grid[129] = 0; grid[130] = 0; grid[131] = 0; grid[149] = 0; grid[150] = 0; grid[151] = 0;
                            break;
                        case 11:
                            grid[74] = 0; grid[75] = 0; grid[94] = 0; grid[95] = 0;
                            break;
                        case 12:
                            grid[134] = 0; grid[135] = 0; grid[154] = 0; grid[155] = 0;
                            break;
                        case 13:
                            grid[18] = 0; grid[19] = 0; grid[38] = 0; grid[39] = 0;
                            break;
                        case 14:
                            grid[78] = 0; grid[79] = 0; grid[98] = 0; grid[99] = 0;
                            break;
                        case 15:
                            grid[138] = 0; grid[139] = 0; grid[158] = 0; grid[159] = 0;
                            break;
                    }
                }
            }


            GenerateGrid(grid);

            int tafel = Int32.Parse(Beheer.Input("Kies een tafel: "));
            if (tafel < 0 || tafel > 15)
            {
                Console.WriteLine("Dit is niet een geldige tafel, probeer het opnieuw.");
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

            int passen = mensenaantafel(tafel);

            if (aantalMensen > passen)
            {
                Console.WriteLine("Er passen geen  " + aantalMensen + " mensen aan tafel " + tafel + ", probeer een andere tafel.");
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


            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].datum == datum && Reserve[i].tijdslot == tijdslot && Reserve[i].tafel == tafel)
                {
                    Console.WriteLine("Deze tafel is bezet, probeer een andere tafel.");
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
            }

            string ReservatieID = generator.RandomString(8);

            Reservaties reservatie = new Reservaties
            {
                voornaam = voornaam,
                achternaam = achternaam,
                gebruikersnaam = gebruikersnaam,
                telefoonnummer = telefoonnummer,
                emailadres = email,

                datum = datum,
                tijdslot = tijdslot,
                aantalMensen = aantalMensen,
                tafel = tafel,

                reservatieId = ReservatieID
            };
            Console.WriteLine("Uw reservatie is gemaakt.");
            DataStorageHandler.Storage.reservaties.Add(reservatie);

            if (WelcomePage.gebruiker == null)
            {
                Console.WriteLine("Noteer uw reservatieID, deze heeft u later nodig als u uw reservering wilt inzien of annuleren.");
                Console.WriteLine("Uw reservatieID is: " + ReservatieID);
            }
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            if (WelcomePage.gebruiker == null)
            {
                WelcomePage.Run();
            }
            else if(WelcomePage.gebruiker.adminRechten)
            {
                AdminWelcomePage.Run();
            }
            else
            {
                KlantWelcomePage.Run();
            }
        }
        public static void MyReservatie()
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].gebruikersnaam == WelcomePage.gebruiker.gebruikersnaam)
                {
                    Console.WriteLine("Voornaam: " + Reserve[i].voornaam);
                    Console.WriteLine("Achternaam: " + Reserve[i].achternaam);
                    Console.WriteLine("Datum: " + Reserve[i].datum);
                    Console.WriteLine("Tijdslot: " + Reserve[i].tijdslot);
                    Console.WriteLine("Aantal mensen: " + Reserve[i].aantalMensen);
                    Console.WriteLine("Tafel: " + Reserve[i].tafel);
                    Console.WriteLine("ReservatieID: " + Reserve[i].reservatieId);
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            KlantWelcomePage.Run();
        }

        public static void ShowReserveringen()
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            Console.WriteLine("Er zijn " + Reserve.Count + " reserveringen.");
            Console.WriteLine(" ");

            for (int i = 0; i < Reserve.Count; i++)
            {
                Console.WriteLine("Voornaam: " + Reserve[i].voornaam);
                Console.WriteLine("Achternaam: " + Reserve[i].achternaam);
                Console.WriteLine("Datum: " + Reserve[i].datum);
                Console.WriteLine("Tijdslot: " + Reserve[i].tijdslot);
                Console.WriteLine("Aantal mensen: " + Reserve[i].aantalMensen);
                Console.WriteLine("Tafel: " + Reserve[i].tafel);
                Console.WriteLine("ReservatieID: " + Reserve[i].reservatieId);
                Console.WriteLine(" ");

            }
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            AdminWelcomePage.Run();
        }

        public static int mensenaantafel(int tafel)
        {
            switch (tafel)
            {
                case 1:
                    return 2;
                case 2:
                    return 2;
                case 3:
                    return 2;
                case 4:
                    return 2;
                case 5:
                    return 2;
                case 6:
                    return 2;
                case 7:
                    return 2;
                case 8:
                    return 2;
                case 9:
                    return 6;
                case 10:
                    return 6;
                case 11:
                    return 4;
                case 12:
                    return 4;
                case 13:
                    return 4;
                case 14:
                    return 4;
                case 15:
                    return 4;
            }
            return 0;
        }

        public static void LookupReservatie()
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            string code = Beheer.Input("Geef uw reservatieID: ");
            bool print = false;

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].reservatieId == code)
                {
                    Console.Clear();
                    Console.WriteLine("Voornaam: " + Reserve[i].voornaam);
                    Console.WriteLine("Achternaam: " + Reserve[i].achternaam);
                    Console.WriteLine("Datum: " + Reserve[i].datum);
                    Console.WriteLine("Tijdslot: " + Reserve[i].tijdslot);
                    Console.WriteLine("Aantal mensen: " + Reserve[i].aantalMensen);
                    Console.WriteLine("Tafel: " + Reserve[i].tafel);
                    print = true;
                }
            }
            if (print)
            {
                Console.WriteLine("Druk op een knop om verder te gaan.");
                Console.ReadKey(true);
                GastWelcomePage.Run();
            }
            else
            {
                Console.WriteLine("Reservering is niet gevonden.");
                Console.WriteLine("Druk op een knop om verder te gaan.");
                Console.ReadKey(true);
                GastWelcomePage.Run();
            }
        }

        public static void DeleteReservatie()
        {
            Console.Clear();
            var lijst = JsonConvert.DeserializeObject<Dictionary<string, object>>(File.ReadAllText(@"../../../DAL/ProjectB.json"));
            var Reserve = JsonConvert.DeserializeObject<List<Reservaties>>(lijst["reservaties"].ToString());

            string code = Beheer.Input("Geef reservatieID van de reservering die u wilt annuleren: ");
            bool deleted = false;

            for (int i = 0; i < Reserve.Count; i++)
            {
                if (Reserve[i].reservatieId == code)
                {
                    DataStorageHandler.Storage.reservaties.RemoveAt(i);
                    deleted = true;
                }
            }
            if (deleted)
            {
                Console.WriteLine("Uw reservering is verwijdert");
            }
            else
            {
                Console.WriteLine("Reservering is niet gevonden.");
            }
            Console.WriteLine("Druk op een knop om verder te gaan.");
            Console.ReadKey(true);
            if (WelcomePage.gebruiker == null)
            {
                WelcomePage.Run();
            }
            else if (WelcomePage.gebruiker.adminRechten)
            {
                AdminWelcomePage.Run();
            }
            else
            {
                KlantWelcomePage.Run();
            }
        }

        public static void GenerateGrid(int[] Restaurantgrid)
        {
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