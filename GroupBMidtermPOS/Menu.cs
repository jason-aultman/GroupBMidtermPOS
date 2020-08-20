using System;
using System.Collections.Generic;

namespace GroupBMidtermPOS
{
    public static class Menu
    {
        public static void DisplayMainMenu(Register register)
        {
            foreach (var product in register.listOfProducts)
            {
                Console.WriteLine($"[{product.ProductNumber}] {product.Name} "); //write out the list of products 1 thru end of list
            }

        }

        public static void AskForPaymentMethodMenu()
        {
            
        }

        public static void DisplayReciept()
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
                Console.WriteLine("No results returned!");
            }
        }
            
    }
}