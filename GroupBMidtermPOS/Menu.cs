
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace GroupBMidtermPOS
{
    public static class Menu
    {
        public static void DisplayMainMenu(Register register, bool clearScreenOnCall)
        {
            var consoleColor = ConsoleColor.Gray;
            if(clearScreenOnCall) System.Console.Clear();
            foreach (var product in register.listOfProducts)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write($"[{product.ProductNumber}] ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write($"{product.Name}  ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"${product.Price} "); //write out the list of products 1 thru end of list
                Console.ForegroundColor = consoleColor;
            }

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
                FileHandler.Writereceipt("receipt.txt", $"Item: {product.Key.Name.PadRight(30)} x {product.Value.ToString().PadRight(10)}         {(product.Key.Price*product.Value)}");
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

        public static string[] ReceiptFormatter(string[] unformattedStrings)
        {
            var columns = unformattedStrings.Length;
            var columnWidth = 20;
            var totalWidth = columns * columnWidth;
            var copyOfInputArray = new string[unformattedStrings.Length];
            unformattedStrings.CopyTo(copyOfInputArray, 0);
            for (int i = 0; i < unformattedStrings.Length; i++)
            {
                copyOfInputArray[i] = unformattedStrings[0].PadRight(columnWidth);
            }

            return copyOfInputArray;


        }
    }
}