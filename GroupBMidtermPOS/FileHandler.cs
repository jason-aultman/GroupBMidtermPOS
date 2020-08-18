using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;

namespace GroupBMidtermPOS
{
    public class FileHandler
    {
        //check if files exists, if not, create it
        public static void CreateFile(string productListFile)
        {
            if (!File.Exists(productListFile))
                File.Create(productListFile);
        }

        //Modifying, or writing, to file
        public static void WriteToFile(string productListFile, bool canAppend, List<string> linesOfInput = null)
        {
            using (StreamWriter writer = new StreamWriter(productListFile, canAppend))
            {
                if (linesOfInput == null)
                {
                    writer.WriteLine(" the list goes in here somehow");
                }
                else
                {
                    foreach (var line in linesOfInput)
                    {
                        List<string> fileLines = File.ReadAllLines("products.txt").ToList();
                        var line = reader.ReadLine();
                        Console.WriteLine(line);
                        writer.WriteLine(line);
                    }
                }
            }
        }

        //Reading from file
        public static void ReadFromFile(string productAddName)
        {
            using (StreamReader reader = new StreamReader(productAddItem))
            {
                List<string> fileLines = File.ReadAllLines("products.txt").ToList();
                var line = reader.ReadLine();
                Console.WriteLine(line);
            }
        }
                //        using (StreamReader reader = new StreamReader(productAddItem))
                //        {
                //            List<string> fileLines = File.ReadAllLines("products.txt").ToList();
                //            var line = reader.ReadLine();
                //            Console.WriteLine(line);
                //        }
            

        //Deleting from file
        public static void DeleteFile(string fileName)
        {
            File.Delete(fileName);
        }
    }
}