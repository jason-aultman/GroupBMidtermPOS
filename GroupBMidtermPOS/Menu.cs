using System;
using System.Collections.Generic;

namespace GroupBMidtermPOS
{
    public static class Menu
    {
        public static void DisplayMainMenu()
        {
            
        }

        public static void AskForPaymentMethodMenu()
        {
            
        }

        public static void DisplayReciept()
        {
            
        }

        public static void DisplayAllProducts(List<Product> productList)
        {
            foreach (var product in productList)
            {
                Console.WriteLine($"[{product.ProductNumber}] {product.Name} - {product.Description}");
            }
        }
            
    }
}