using System;
using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class FileHandler
    {
        public static string currentDirectory = Directory.GetCurrentDirectory();

        public static DirectoryInfo directory = new DirectoryInfo(currentDirectory);

        public static string fileName = Path.Combine(directory.FullName, "Inventory.csv");

        public static List<Product> fileContents = ReadInventoryData(fileName);


        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }


        public static List<Product> ReadInventoryData(string fileName)
        {
            List<Product> InventoryData = new List<Product>();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = "";
                while ((!reader.EndOfStream))
                {
                    Product product = new Product();
                    line = reader.ReadLine();
                    string[] values = line.Split(',',5);
                    
                    //name
                    product.Name = values[0];
                    
                    //category
                    if (Enum.TryParse(values[1], out ProductCategoryEnum category))
                    {
                        product.ProductCategory = category;
                    }

                    //desc
                    product.Description = values[3];

                    //price
                   
                    if (double.TryParse(values[2], out double parseDbl))
                    {
                        product.Price = parseDbl;
                    }

                    InventoryData.Add(product);
                }

                return InventoryData;
            }
        }
    }
}