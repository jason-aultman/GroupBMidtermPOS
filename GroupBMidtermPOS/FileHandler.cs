using System;
using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class FileHandler
    {
       

        public static string currentDirectory = Directory.GetCurrentDirectory();

        public static DirectoryInfo directory = new DirectoryInfo(currentDirectory);

       

       


        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static void WriteFile(string fileName, string inventoryContent)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.Write(inventoryContent);
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
                   
                    line = reader.ReadLine();
                    string[] values = line.Split(',',4);
                    
                  
                    //name
                    var productName = values[0];  //CHANGED THIS TO 0 INDEX
                    
                    //category

                    var productCategoryEnum = values[1];
                    

                    //desc
                    var productDescription = values[3];


                    //price
                    var productPrice=0.0;
                    if (double.TryParse(values[2], out double parseDbl))

                    {
                        productPrice = parseDbl;
                    }
                    var product = new Product(productName, productCategoryEnum,productPrice, productDescription);

                    InventoryData.Add(product);
                }

                return InventoryData;
            }
        }

        public static void Writereceipt(string filePath, string words, bool append=true)
        {
            using (StreamWriter writer = new StreamWriter(filePath, append))
            { 
                writer.WriteLine(words);
            }
        }
    }
}