using System;
using System.Collections.Generic;
using System.Xml.Schema;

namespace GroupBMidtermPOS
{
    static class Program
    {
        static void Main(string[] args)
        {           
            var shoppingCart = new List<KeyValuePair<Product, int>>();
            Register register = new Register(); //open a new Register

            Console.WriteLine("WELCOME TO CHUCKY'S TOY KINGDOM!!!");
            Console.WriteLine("**********************************");
            Console.WriteLine("Menu: Choose an Item");

            Menu.DisplayMainMenu(register);

            //call the Validator.cs -- this is a new class that will hold all the user input validation before anything else happens
            
            var userItem = Console.ReadLine();

            Console.WriteLine("Enter Quantity:");
            //maybe move this to Validator.cs class (new)
            var takeUserQuantity = int.TryParse(Console.ReadLine(), out int userItemQuantity); // take user user's quantity
            if (!takeUserQuantity)
            {
                Console.WriteLine("Something went wrong");
            }

            var kvpUserSelection = new KeyValuePair<Product, int>(register.listOfProducts[1], userItemQuantity);


           Console.WriteLine($"Subtotal: {register.GetSubtotal(kvpUserSelection)}");
            shoppingCart.Add(kvpUserSelection);
            //items customer selected
            //price of items * quantity = total

           Menu.AskToContinueToShop();
           
           Menu.DisplayOrderSummary(shoppingCart, register);

           Menu.AskForPaymentMethodMenu();

        }
    }
}