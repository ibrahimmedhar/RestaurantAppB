using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RestaurantApp.DAL
{
    class DataStorageHandler
    {
        private static string StorageFileLocation { get; set; }
        public static DataStorage Storage { get; set; }

        public static void Init(string filename)
        {
            if (!(File.Exists(filename)))
            {
                using StreamWriter sw = File.CreateText(filename);
            }

            StorageFileLocation = filename;
            string fileContent = File.ReadAllText(StorageFileLocation);

            try
            {
                Storage = JsonConvert.DeserializeObject<DataStorage>(fileContent);
                if (Storage == null)
                { Storage = new DataStorage(); }
            }
            catch (Exception)
            {
                Storage = new DataStorage();
            }
        }
        public static void SaveChanges()
        {
            string result = JsonConvert.SerializeObject(Storage, Formatting.Indented);

            File.WriteAllText(StorageFileLocation, result);
        }
    }
}
