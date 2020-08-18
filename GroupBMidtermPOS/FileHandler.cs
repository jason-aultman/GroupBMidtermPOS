namespace GroupBMidtermPOS
{
    public class FileHandler
    {
        public static void CreateFile(string productListFile)
        {
            if (!File.Exists(productListFile))
                File.Create(productListFile);
        }

        public static void WriteToFile(string productItemName)
        {
            writer.WriteLine;
        }
    }

    public static void ReadFromFile(string productAddItem)
    {
        using (StreamReader reader = new StreamReader(productAddItem))
        {
            List<string> fileLines = File.ReadAllLines("products.txt").ToList();
            var line = reader.ReadLine();
            Console.WriteLine(line);
        }
    }
}