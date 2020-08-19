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

            //   StreamReader streamReader = new StreamReader(fileName);
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line = "";
                while ((!reader.EndOfStream))
                {
                    Product product = new Product();
                    line = reader.ReadLine();
                    string[] values = line.Split(',',5);
                    
                    //REMOVED BECAUSE AS YOU SAID SANDY, IS NOT USED
                    //product number (I don't have an actual value in the .txt file, just the order they appear in) --Looks great Sandy, just what we need --Jason
                    
                    // if (int.TryParse(values[0], out int parseInt))
                    // {
                    //     product.ProductNumber = parseInt;
                    // }
                    
                    //name
                    product.Name = values[0];  //CHANGED THIS TO 0 INDEX
                    
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