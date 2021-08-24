using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CSVExample
{
    public class ReadCSVToJSON
    {
        public static void ImplementCSVToJSON()
        {
            string ImportFilePath = @"C:\Users\bkukrej\source\repos\CSVExample\CSVExample\utility\addre.csv";
            string ExportFilePath = @"C:\Users\bkukrej\source\repos\CSVExample\CSVExample\utility\exp.json";

            //REad the CSV file \
            using (var reader = new StreamReader(ImportFilePath))

            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from addresses");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.state);
                    Console.WriteLine("\t" + addressData.code);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("******  REDING FORM CSV AND WRTE TO JSON FILE ******");
                // write to JSON

                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(ExportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }



            }

        }
    }
    }