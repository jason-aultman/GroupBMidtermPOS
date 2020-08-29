
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GroupBMidtermPOS
{
    public static class Menu
    {
        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("**********************************");
            Console.WriteLine();
        }
        public static void DisplayMainMenu(Register register, bool clearScreenOnCall)
        {
            var consoleColor = ConsoleColor.Gray;
            if(clearScreenOnCall) System.Console.Clear();
            foreach (var product in register.listOfProducts)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"[{product.ProductNumber}] ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{product.Name}  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"${product.Price} "); //write out the list of products 1 thru end of list
                Console.ForegroundColor = consoleColor;
            }

        }

        public static void GetItemDetail (Product product)
        {
            Console.WriteLine($"{product.Name} - {product.Price:C} - {product.ProductCategory} - {product.Description} ");
        }

        public static bool DisplayTransactionDetails(List<KeyValuePair<Product, int>> shoppingCart, Register register, KeyValuePair<Product, int> kvpUserSelection)
        {
            bool clearConsole;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Transaction total: {register.GetSubtotal(kvpUserSelection):C}");
            Console.WriteLine($"Subtotal: {register.GetSubtotal(shoppingCart):C}");
            clearConsole = true;
            Console.ForegroundColor = ConsoleColor.Gray;
            return clearConsole;
        }


        public static void DisplayOrderSummary(List<KeyValuePair<Product,int>> shoppingCart, Register register)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Order Summary: ");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            foreach (var product in shoppingCart)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"Item: ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{product.Key.Name} ");
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"Quantity: {product.Value} ");
                
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Price: {product.Key.Price:C}");
                FileHandler.Writereceipt("receipt.txt", $"Item: {product.Key.Name.PadRight(30)} x {product.Value.ToString().PadRight(10)}         {(product.Key.Price*product.Value):C}");
            }

            var subTotal = register.GetSubtotal(shoppingCart);
            var tax = register.GetTotalSalesTax(register.GetSubtotal(shoppingCart));
            tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            var total = Math.Round((subTotal + tax), 2, MidpointRounding.AwayFromZero);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Subtotal :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{subTotal:C}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Tax :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{tax:C}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Total :");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{total:C} ");
            Console.WriteLine();

        }

      
        public static PaymentTypeEnum AskForPaymentMethodMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter Payment Type: ");// working with the enums
            Console.WriteLine("-----------------------------");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit/Debit Card");
            Console.WriteLine("3. Check");
            Console.ForegroundColor = ConsoleColor.Gray;
            var paymentType = int.Parse(Console.ReadLine());

            return (PaymentTypeEnum)paymentType;

        }

        public static void Displayreceipt()
        {
            
            
        }

        public static void DisplayAllProducts(List<Product> productList)
        {
            if (productList != null)
            {
                foreach (var product in productList)
                {
                    Console.WriteLine($"[{product.ProductNumber}] {product.Name} - {product.Description}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No results returned!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public static void DisplayReceipt(string path)
        {
            var paidDisplayReceipt = new List<string>();
            //go to file handler file
            //var receiptWriterPath = path;
            //call file reader

            string displayReceipt = FileHandler.ReadFile(path);
            Console.WriteLine(displayReceipt);
        }

        public static void Printreceipt(string path)
        //We need to display this to the screen
        {
            FileHandler.Writereceipt(path, $"{DateTime.Now.ToString()}", false);
            var businessNameAndAddress = new string[]
            {
              "Chucky's Toy Kingdom", "40 Pearl St NW #200", "Grand Rapids, MI 49503", "555-555-1234", "-----------------------------------------------------------","\n"
            };
            foreach (var addressLine in businessNameAndAddress)
            {
                FileHandler.Writereceipt(path, addressLine, true);
            }
        }

       
    }
}