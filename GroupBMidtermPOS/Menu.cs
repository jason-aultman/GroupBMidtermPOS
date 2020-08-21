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

        public static void DisplayOrderSummary(List<KeyValuePair<Product,int>> shoppingCart, Register register)
        {
            Console.WriteLine("Order Summary: ");
            foreach (var product in shoppingCart)
            {
                Console.WriteLine($"Quantity {product.Value} Item{product.Key.Name}Price {product.Key.Price}");//quantity-item-price for each item. may need for each statement
            }

            var subTotal = register.GetSubtotal(shoppingCart);
            var tax = register.GetTotalSalesTax(register.GetSubtotal(shoppingCart));
            tax = Math.Round(tax, 2, MidpointRounding.AwayFromZero);
            var total = Math.Round((subTotal + tax), 2, MidpointRounding.AwayFromZero);
            Console.WriteLine($"Subtotal ${subTotal}");//subtotal
            Console.WriteLine($"Tax ${tax}");//tax
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"Total ${total} ");//total

        }

        public static bool AskToContinueToShop()
        {
            Console.WriteLine("Would you like to continue to shop? (Y/N)");
            var continueYesNo = Console.ReadLine().ToLower();
            if (ValidateInput.CheckYesNo(continueYesNo) )//todo 
            {
                return true;
            }
            else 
            {
                Console.WriteLine("Please make a valid input");
                AskToContinueToShop();
            }

            return false;
        }

        public static void AskForPaymentMethodMenu()
        {
            Console.WriteLine("Enter Payment Type: ");// working with the enums
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit/Debit Card");
            Console.WriteLine("3. Check");
            var paymentType = Console.ReadLine();
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