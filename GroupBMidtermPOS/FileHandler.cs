using System;
using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class FileHandler
    {
        //private static Stream productAddItem;
        //public static List<Product> ShoppingCart = new List<Product> { };

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

            StreamReader streamReader = new StreamReader(fileName);
            using StreamReader reader = streamReader;
        {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    Product product = new Product();
                    string[] values = line.Split(',');


                    //product number (I don't have an actual value in the .txt file, just the order they appear in)
                    int parseInt;
                    if (int.TryParse(values[0], out parseInt))
                    {
                        product.ProductNumber = parseInt;
                    }


                    //name
                    product.Name = values[1];


                    //category
                    ProductCategoryEnum category;

                    if (Enum.TryParse(values[2], out category))
                    {
                        product.ProductCategory = category;
                    }


                    //desc
                    product.Description = values[3];


                    //price
                    decimal parseDbl;
                    if (decimal.TryParse(values[4], out parseDbl))

                    {
                        product.Price = (double)parseDbl;
                    }


                    InventoryData.Add(product);
                }
            }
            return InventoryData;
        }

    }

}