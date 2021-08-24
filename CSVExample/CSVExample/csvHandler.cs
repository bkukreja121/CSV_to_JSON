using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace CSVExample
{
    public class csvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string ImportFilePath = @"C:\Users\bkukrej\source\repos\CSVExample\CSVExample\utility\addresses.csv";
            string ExportFilePath = @"C:\Users\bkukrej\source\repos\CSVExample\CSVExample\utility\export.csv";

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
                }

                Console.WriteLine("******  REDING FORM CSV AND WRTE TO CSV FILE ******");

                //WRITING TO CSV 

                using (var writer = new StreamWriter(ExportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }


            }


        }
        }
    }
